using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NeoCobranza.ViewModels
{
    public class DataUtilities
    {
        private List<object> vGlobListParameters = new List<object>();
        private List<string> vGlobListParamentersNames = new List<string>();

        private List<string> vGlobListColumnNames = new List<string>();
        private List<object> vGlobListColumnValues = new List<object>();

        private Dictionary<string, object> vOutputValues = new Dictionary<string, object>();

        private string vGlobServerName = "DESKTOP-GKTE05O\\SQLEXPRESS"; //"DESKTOP-GKTE05O\\SQLEXPRESS""DF-INF-PRO2\\SQLEXPRESS"
        private string vGlobUserName = "LoginPos";
        private string vGlobUserPassword = "facil123$";

        public SqlConnection vGlobConnection;

        public DataUtilities() 
        {
           string connectionString = "Server=" + vGlobServerName + ";Database=POSIDEVBD;UID=" + vGlobUserName + ";PWD=" + vGlobUserPassword + "; MultipleActiveResultSets=True"; //CASA
           //string connectionString = "Server=" + vGlobServerName + ";Database=POSIDEVBD;Integrated Security=True"; //TRABAJO

            vGlobConnection = new SqlConnection(connectionString);
        }

        public void SetParameter(string parameterName, object value)
        {
            if (string.IsNullOrWhiteSpace(parameterName))
            {
                throw new ArgumentException("El nombre del parámetro no puede ser nulo, vacío o contener solo espacios.");
            }

            vGlobListParamentersNames.Add(parameterName);
            vGlobListParameters.Add(value);
        }

        public void SetColumns(string columnName, object value)
        {
            if (string.IsNullOrWhiteSpace(columnName))
            {
                throw new ArgumentException("El nombre del parámetro no puede ser nulo, vacío o contener solo espacios.");
            }

            vGlobListColumnNames.Add(columnName);
            vGlobListColumnValues.Add(value);
        }

        public DataTable ExecuteStoredProcedure(string procedureName)
        {

            if (string.IsNullOrWhiteSpace(procedureName))
            {
                throw new ArgumentException("El nombre del procedimiento no puede ser nulo, vacío o contener solo espacios.");
            }

            DataTable resultTable = new DataTable();

            try
            {
                // Limpiar salidas anteriores
                vOutputValues.Clear();
                bool wasConnectionOpen = HandleConnectionState(true);

                using (SqlCommand command = new SqlCommand(procedureName, vGlobConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros: si el valor es SqlParameter (para OUTPUT) se agrega directamente.
                    for (int i = 0; i < vGlobListParamentersNames.Count; i++)
                    {
                        object paramValue = vGlobListParameters[i];
                        if (paramValue is SqlParameter sqlParam)
                        {
                            command.Parameters.Add(sqlParam);
                        }
                        else
                        {
                            command.Parameters.AddWithValue(vGlobListParamentersNames[i], paramValue);
                        }
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(resultTable);
                    }

                    // Recorrer los parámetros y almacenar los de salida
                    foreach (SqlParameter param in command.Parameters)
                    {
                        if (param.Direction == ParameterDirection.Output ||
                            param.Direction == ParameterDirection.InputOutput ||
                            param.Direction == ParameterDirection.ReturnValue)
                        {
                            vOutputValues[param.ParameterName] = param.Value;
                        }
                    }
                }

                // Limpia las listas de parámetros
                ClearParameters();

                if (!wasConnectionOpen)
                {
                    HandleConnectionState(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar el procedimiento almacenado: " + ex.Message, "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return resultTable;
        }


        private bool HandleConnectionState(bool openConnection)
        {
            if (openConnection)
            {
                if (vGlobConnection.State == ConnectionState.Closed)
                {
                    vGlobConnection.Open();
                    return false; 
                }
                return true; 
            }
            else
            {
                if (vGlobConnection.State == ConnectionState.Open)
                {
                    vGlobConnection.Close();
                }
                return false;
            }
        }

        public DataTable getRecordByPrimaryKey(string tableName, object keyValue)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentException("El nombre de la tabla no puede ser nulo, vacío o contener solo espacios.");
            }

            if (keyValue == null)
            {
                throw new ArgumentNullException(nameof(keyValue), "El valor de la clave primaria no puede ser nulo.");
            }

            DataTable resultTable = new DataTable();

            try
            {
                bool wasConnectionOpen = HandleConnectionState(true);

                string primaryKeyColumn = null;
                using (SqlCommand command = new SqlCommand(@"
            SELECT COLUMN_NAME
            FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS TC
            INNER JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE CCU
                ON TC.CONSTRAINT_NAME = CCU.CONSTRAINT_NAME
            WHERE TC.TABLE_NAME = @TableName AND TC.CONSTRAINT_TYPE = 'PRIMARY KEY';", vGlobConnection))
                {
                    command.Parameters.AddWithValue("@TableName", tableName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            primaryKeyColumn = reader["COLUMN_NAME"].ToString();
                        }
                    }
                }

                if (string.IsNullOrWhiteSpace(primaryKeyColumn))
                {
                    throw new InvalidOperationException($"No se encontró una clave primaria para la tabla '{tableName}'.");
                }

                using (SqlCommand command = new SqlCommand($"SELECT * FROM {tableName} WHERE {primaryKeyColumn} = @KeyValue", vGlobConnection))
                {
                    command.Parameters.AddWithValue("@KeyValue", keyValue);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(resultTable);
                    }
                }

                if (!wasConnectionOpen)
                {
                    HandleConnectionState(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message, "Error",
                  MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return resultTable;
        }

        public DataTable getRecordByColumn(string tableName, string columnName, object columnValue)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentException("El nombre de la tabla no puede ser nulo, vacío o contener solo espacios.");
            }

            if (string.IsNullOrWhiteSpace(columnName))
            {
                throw new ArgumentException("El nombre de la columna no puede ser nulo, vacío o contener solo espacios.");
            }

            if (columnValue == null)
            {
                throw new ArgumentNullException(nameof(columnValue), "El valor de la columna no puede ser nulo.");
            }

            DataTable resultTable = new DataTable();

            try
            {
                bool wasConnectionOpen = HandleConnectionState(true);

                bool columnExists = false;
                using (SqlCommand command = new SqlCommand(@"
            SELECT 1
            FROM INFORMATION_SCHEMA.COLUMNS
            WHERE TABLE_NAME = @TableName AND COLUMN_NAME = @ColumnName;", vGlobConnection))
                {
                    command.Parameters.AddWithValue("@TableName", tableName);
                    command.Parameters.AddWithValue("@ColumnName", columnName);

                    object result = command.ExecuteScalar();
                    columnExists = result != null;
                }

                if (!columnExists)
                {
                    throw new InvalidOperationException($"La columna '{columnName}' no existe en la tabla '{tableName}'.");
                }

                using (SqlCommand command = new SqlCommand($"SELECT * FROM {tableName} WHERE {columnName} = @ColumnValue", vGlobConnection))
                {
                    command.Parameters.AddWithValue("@ColumnValue", columnValue);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(resultTable);
                    }
                }

                if (!wasConnectionOpen)
                {
                    HandleConnectionState(false);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al obtener el registro por columna: " + ex.Message, ex);
            }

            return resultTable;
        }

        public void UpdateRecordByPrimaryKey(string tableName, object keyValue)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentException("El nombre de la tabla no puede ser nulo, vacío o contener solo espacios.");
            }

            if (keyValue == null)
            {
                throw new ArgumentNullException(nameof(keyValue), "El valor de la clave primaria no puede ser nulo.");
            }

            if (vGlobListColumnNames.Count == 0 || vGlobListColumnValues.Count == 0)
            {
                throw new InvalidOperationException("No se han especificado columnas ni valores para actualizar.");
            }

            if (vGlobListColumnNames.Count != vGlobListColumnValues.Count)
            {
                throw new InvalidOperationException("El número de columnas y valores no coincide.");
            }

            try
            {
                bool wasConnectionOpen = HandleConnectionState(true);

                string primaryKeyColumn = null;
                using (SqlCommand command = new SqlCommand(@"
        SELECT COLUMN_NAME
        FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS TC
        INNER JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE CCU
            ON TC.CONSTRAINT_NAME = CCU.CONSTRAINT_NAME
        WHERE TC.TABLE_NAME = @TableName AND TC.CONSTRAINT_TYPE = 'PRIMARY KEY';", vGlobConnection))
                {
                    command.Parameters.AddWithValue("@TableName", tableName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            primaryKeyColumn = reader["COLUMN_NAME"].ToString();
                        }
                    }
                }

                if (string.IsNullOrWhiteSpace(primaryKeyColumn))
                {
                    throw new InvalidOperationException($"No se encontró una clave primaria para la tabla '{tableName}'.");
                }

                // Construir la consulta UPDATE dinámicamente
                StringBuilder updateQuery = new StringBuilder($"UPDATE {tableName} SET ");
                for (int i = 0; i < vGlobListColumnNames.Count; i++)
                {
                    if (i > 0)
                    {
                        updateQuery.Append(", ");
                    }
                    updateQuery.Append($"{vGlobListColumnNames[i]} = @ColumnValue{i}");
                }
                updateQuery.Append($" WHERE {primaryKeyColumn} = @KeyValue");

                using (SqlCommand command = new SqlCommand(updateQuery.ToString(), vGlobConnection))
                {
                    // Agregar valores para las columnas a actualizar
                    for (int i = 0; i < vGlobListColumnNames.Count; i++)
                    {
                        command.Parameters.AddWithValue($"@ColumnValue{i}", vGlobListColumnValues[i]);
                    }

                    // Agregar el valor de la clave primaria
                    command.Parameters.AddWithValue("@KeyValue", keyValue);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new InvalidOperationException($"No se pudo actualizar el registro con la clave primaria '{keyValue}' en la tabla '{tableName}'.");
                    }
                }

                vGlobListColumnNames.Clear();
                vGlobListColumnValues.Clear();

                if (!wasConnectionOpen)
                {
                    HandleConnectionState(false);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al actualizar el registro: " + ex.Message, ex);
            }
        }

        public void InsertRecord(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentException("El nombre de la tabla no puede ser nulo, vacío o contener solo espacios.");
            }

            if (vGlobListColumnNames.Count == 0 || vGlobListColumnValues.Count == 0)
            {
                throw new InvalidOperationException("No se han especificado columnas ni valores para insertar.");
            }

            if (vGlobListColumnNames.Count != vGlobListColumnValues.Count)
            {
                throw new InvalidOperationException("El número de columnas y valores no coincide.");
            }

            try
            {
                bool wasConnectionOpen = HandleConnectionState(true);

                // Construir la consulta INSERT dinámicamente
                StringBuilder insertQuery = new StringBuilder($"INSERT INTO {tableName} (");
                insertQuery.Append(string.Join(", ", vGlobListColumnNames));
                insertQuery.Append(") VALUES (");
                for (int i = 0; i < vGlobListColumnValues.Count; i++)
                {
                    if (i > 0)
                    {
                        insertQuery.Append(", ");
                    }
                    insertQuery.Append($"@Value{i}");
                }
                insertQuery.Append(")");

                using (SqlCommand command = new SqlCommand(insertQuery.ToString(), vGlobConnection))
                {
                    // Agregar valores para las columnas
                    for (int i = 0; i < vGlobListColumnValues.Count; i++)
                    {
                        command.Parameters.AddWithValue($"@Value{i}", vGlobListColumnValues[i]);
                    }

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new InvalidOperationException($"No se pudo insertar el registro en la tabla '{tableName}'.");
                    }
                }

                vGlobListColumnNames.Clear();
                vGlobListColumnValues.Clear();

                if (!wasConnectionOpen)
                {
                    HandleConnectionState(false);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al insertar el registro: " + ex.Message, ex);
            }
        }

        public DataTable GetAllRecords(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentException("El nombre de la tabla no puede ser nulo, vacío o contener solo espacios.");
            }

            DataTable resultTable = new DataTable();

            try
            {
                bool wasConnectionOpen = HandleConnectionState(true);

                string query = $"SELECT * FROM {tableName}";

                using (SqlCommand command = new SqlCommand(query, vGlobConnection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(resultTable);
                    }
                }

                if (!wasConnectionOpen)
                {
                    HandleConnectionState(false);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al obtener todos los registros: " + ex.Message, ex);
            }

            return resultTable;
        }

        public void DeleteRecordByColumn(string tableName, string columnName, object columnValue)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentException("El nombre de la tabla no puede ser nulo, vacío o contener solo espacios.");
            }

            if (string.IsNullOrWhiteSpace(columnName))
            {
                throw new ArgumentException("El nombre de la columna no puede ser nulo, vacío o contener solo espacios.");
            }

            if (columnValue == null)
            {
                throw new ArgumentNullException(nameof(columnValue), "El valor de la columna no puede ser nulo.");
            }

            try
            {
                bool wasConnectionOpen = HandleConnectionState(true);

                // Verificar si la columna existe
                bool columnExists = false;
                using (SqlCommand command = new SqlCommand(@"
            SELECT 1
            FROM INFORMATION_SCHEMA.COLUMNS
            WHERE TABLE_NAME = @TableName AND COLUMN_NAME = @ColumnName;", vGlobConnection))
                {
                    command.Parameters.AddWithValue("@TableName", tableName);
                    command.Parameters.AddWithValue("@ColumnName", columnName);

                    object result = command.ExecuteScalar();
                    columnExists = result != null;
                }

                if (!columnExists)
                {
                    throw new InvalidOperationException($"La columna '{columnName}' no existe en la tabla '{tableName}'.");
                }

                // Eliminar registros
                using (SqlCommand command = new SqlCommand($"DELETE FROM {tableName} WHERE {columnName} = @ColumnValue", vGlobConnection))
                {
                    command.Parameters.AddWithValue("@ColumnValue", columnValue);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new InvalidOperationException($"No se encontraron registros para eliminar en la tabla '{tableName}' con la columna '{columnName}' igual a '{columnValue}'.");
                    }
                }

                if (!wasConnectionOpen)
                {
                    HandleConnectionState(false);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al eliminar registros por columna: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Sobrecarga para establecer un parámetro con tipo y dirección (útil para OUTPUT).
        /// </summary>
        public void SetParameter(string parameterName, SqlDbType type, ParameterDirection direction)
        {
            if (string.IsNullOrWhiteSpace(parameterName))
            {
                throw new ArgumentException("El nombre del parámetro no puede ser nulo, vacío o contener solo espacios.");
            }

            SqlParameter param = new SqlParameter(parameterName, type)
            {
                Direction = direction
            };

            vGlobListParamentersNames.Add(parameterName);
            vGlobListParameters.Add(param);
        }

        /// <summary>
        /// Limpia la lista de parámetros y el diccionario de salida.
        /// </summary>
        public void ClearParameters()
        {
            vGlobListParamentersNames.Clear();
            vGlobListParameters.Clear();
        }

        public void ClearOutPutParameters()
        {
            vOutputValues.Clear();
        }

        public object GetParameterValue(string parameterName)
        {
            if (vOutputValues.ContainsKey(parameterName))
            {
                return vOutputValues[parameterName];
            }
            throw new KeyNotFoundException("El parámetro de salida no se encontró: " + parameterName);
        }
    }
}
