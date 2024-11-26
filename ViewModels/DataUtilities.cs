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

        private string vGlobServerName = "DF-INF-PRO2"; //"DESKTOP-GKTE05O\\SQLEXPRESS";Integrated Security=True
        private string vGlobUserName = "LoginPos";
        private string vGlobUserPassword = "facil123$";

        private SqlConnection vGlobConnection;

        public DataUtilities() 
        {
            //string connectionString = "Server=" + vGlobServerName + ";Database=POSIDEVBD;UID=" + vGlobUserName + ";PWD=" + vGlobUserPassword + "; MultipleActiveResultSets=True"; //CASA
            string connectionString = "Server=" + vGlobServerName + ";Database=POSIDEVBD;Integrated Security=True"; //TRABAJO

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

        public DataTable ExecuteStoredProcedure(string procedureName)
        {
            if (string.IsNullOrWhiteSpace(procedureName))
            {
                throw new ArgumentException("El nombre del procedimiento no puede ser nulo, vacío o contener solo espacios.");
            }

            DataTable resultTable = new DataTable();

            try
            {
                bool wasConnectionOpen = HandleConnectionState(true);

                using (SqlCommand command = new SqlCommand(procedureName, vGlobConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    for (int i = 0; i < vGlobListParamentersNames.Count; i++)
                    {
                        command.Parameters.AddWithValue(vGlobListParamentersNames[i], vGlobListParameters[i]);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(resultTable);
                    }
                }

                vGlobListParamentersNames.Clear();
                vGlobListParameters.Clear();


                if (!wasConnectionOpen)
                {
                    HandleConnectionState(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar el procedimiento almacenado: " + ex.Message,"Error",
                    MessageBoxButton.OK,MessageBoxImage.Error);
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


    }
}
