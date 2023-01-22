using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoCobranza.Data;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NeoCobranza.DataController
{
    public class CGeneral
    {
        public Conexion conexion;

        public CGeneral(Conexion conexion)
        {
            this.conexion = conexion;

        }

        //PROCEDIMEINTO DE VISTA
        public DataTable MostrarDepartamentos()
        {
            DataTable dtResultado = new DataTable("NombreDpto");


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "dbo_Departamente";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

            sqlData.Fill(dtResultado);


            return dtResultado;
        }
        public DataTable MostrarFirmas()
        {
            DataTable dtResultado = new DataTable("NombreFirma");


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "dbo_FirmaCompañia";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

            sqlData.Fill(dtResultado);


            return dtResultado;
        }
        //
        public DataTable MostrarServicios()
        {
            DataTable dtResultado = new DataTable("NombreServicio");


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "dbo_Ataudes";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

            sqlData.Fill(dtResultado);


            return dtResultado;
        }
        //
        public DataTable MostrarAgencias()
        {
            DataTable dtResultado = new DataTable("NombreAgencia");


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "dbo_Agencias";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

            sqlData.Fill(dtResultado);


            return dtResultado;
        }
        public string BuscarDepartamento(String filtro)
        {
            DataTable dtResultado = new DataTable("BuscarDeptp");




            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "Mostar_dato_Departamento";
            sqlCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter filtroDato = new SqlParameter();
            filtroDato.ParameterName = "@nombre";
            filtroDato.SqlDbType = SqlDbType.NVarChar;
            filtroDato.Size = 50;
            filtroDato.Value = filtro;

            sqlCommand.Parameters.Add(filtroDato);

            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

            sqlData.Fill(dtResultado);


            return dtResultado.Rows[0]["id"].ToString();
        }
        public string BuscarIdCliente(String filtro)
        {
            DataTable dtResultado = new DataTable("BuscarCliente");




            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "Mostar_ID_Cliente";
            sqlCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter filtroDato = new SqlParameter();
            filtroDato.ParameterName = "@nombre";
            filtroDato.SqlDbType = SqlDbType.NVarChar;
            filtroDato.Size = 500;
            filtroDato.Value = filtro;

            sqlCommand.Parameters.Add(filtroDato);

            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

            sqlData.Fill(dtResultado);

            try
            {


                return dtResultado.Rows[0]["id"].ToString();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return "";
        }
        public DataGridView cargarDgvProforma(int idProforma, DataGridView dgvServicios)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "cargarDgvServiciosProformas";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter id = new SqlParameter();
            id.ParameterName = "@idProforma";
            id.SqlDbType = SqlDbType.Int;
            id.Value = idProforma;

            sqlCommand.Parameters.Add(id);
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            sqlDataAdapter.Fill(dataTable);
            int totalFilas = dataTable.Rows.Count - 1;
            for(int i = 0; i<totalFilas; i++)
            {
                dgvServicios.Rows.Add();
                dgvServicios.Rows[i].Cells["IdServicio"].Value = dataTable.Rows[i]["IdServicio"];
                dgvServicios.Rows[i].Cells["Servicio"].Value = dataTable.Rows[i]["Servicio"];
                dgvServicios.Rows[i].Cells["PrecioDolar"].Value = dataTable.Rows[i]["PrecioDolar"];
                dgvServicios.Rows[i].Cells["Cantidad"].Value = dataTable.Rows[i]["NoServicios"];
                

            }
            return dgvServicios;
            
        }
    }
}
