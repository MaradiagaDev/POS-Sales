using NeoCobranza.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.DataController
{
    public class CAuditoria
    {

        Conexion conexion;
        public CAuditoria(Conexion conexion)
        {
            this.conexion = conexion;   
        }

        //DATOS DE LLENADO
        public DataTable Usuarios()
        {
            DataTable dtResultado = new DataTable("BuscarCliente");




            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "VerUsuario";
            sqlCommand.CommandType = CommandType.StoredProcedure;


           
            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

            sqlData.Fill(dtResultado);


            return dtResultado;
        }
        public DataTable BuscarModificacionesProforma(string FechaInicial, string FechaFinal, string Filtro, string NombreUsuario, string Accion)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[5];

            param[0] = new SqlParameter("@fechaInicial", SqlDbType.DateTime);
            param[0].Value = FechaInicial;

            param[1] = new SqlParameter("@fechaFinal", SqlDbType.DateTime);
            param[1].Value = FechaFinal;

            param[2] = new SqlParameter("@filtro", SqlDbType.NVarChar);
            param[2].Value = Filtro;

            param[3] = new SqlParameter("@NombreUsuario", SqlDbType.NVarChar);
            param[3].Value = NombreUsuario;

            param[4] = new SqlParameter("@Accion", SqlDbType.NVarChar);
            param[4].Value = Accion;

            
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "HistorialProforma";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                //cmd.ExecuteNonQuery();

                DataTable dtResultado = new DataTable("NombreDpto");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtResultado);

                return dtResultado;   
        }
        public DataTable BuscarModificacionesProformaSin(string FechaInicial, string FechaFinal, string NombreUsuario, string Accion)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@fechaInicial", SqlDbType.DateTime);
            param[0].Value = FechaInicial;

            param[1] = new SqlParameter("@fechaFinal", SqlDbType.DateTime);
            param[1].Value = FechaFinal;

          
            param[2] = new SqlParameter("@NombreUsuario", SqlDbType.NVarChar);
            param[2].Value = NombreUsuario;

            param[3] = new SqlParameter("@Accion", SqlDbType.NVarChar);
            param[3].Value = Accion;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HistorialProformaSin";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);
            //cmd.ExecuteNonQuery();

            DataTable dtResultado = new DataTable("NombreDpto");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dtResultado);

            return dtResultado;
        }
        public DataTable HistorialServicio(string FechaInicial, string FechaFinal, string NombreUsuario, string Accion)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@fechaInicial", SqlDbType.DateTime);
            param[0].Value = FechaInicial;

            param[1] = new SqlParameter("@fechaFinal", SqlDbType.DateTime);
            param[1].Value = FechaFinal;


            param[2] = new SqlParameter("@NombreUsuario", SqlDbType.NVarChar);
            param[2].Value = NombreUsuario;

            param[3] = new SqlParameter("@Accion", SqlDbType.NVarChar);
            param[3].Value = Accion;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HistorialServicios";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);
            //cmd.ExecuteNonQuery();

            DataTable dtResultado = new DataTable("NombreDpto");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dtResultado);

            return dtResultado;
        }
        public DataTable HistorialCliente(string FechaInicial, string FechaFinal, string NombreUsuario, string Accion)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@fechaInicial", SqlDbType.DateTime);
            param[0].Value = FechaInicial;

            param[1] = new SqlParameter("@fechaFinal", SqlDbType.DateTime);
            param[1].Value = FechaFinal;


            param[2] = new SqlParameter("@NombreUsuario", SqlDbType.NVarChar);
            param[2].Value = NombreUsuario;

            param[3] = new SqlParameter("@Accion", SqlDbType.NVarChar);
            param[3].Value = Accion;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HistorialCliente";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);
            //cmd.ExecuteNonQuery();

            DataTable dtResultado = new DataTable("NombreDpto");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dtResultado);

            return dtResultado;
        }
        public DataTable HistorialContrato(string FechaInicial, string FechaFinal, string NombreUsuario, string Accion)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@fechaInicial", SqlDbType.DateTime);
            param[0].Value = FechaInicial;

            param[1] = new SqlParameter("@fechaFinal", SqlDbType.DateTime);
            param[1].Value = FechaFinal;


            param[2] = new SqlParameter("@NombreUsuario", SqlDbType.NVarChar);
            param[2].Value = NombreUsuario;

            param[3] = new SqlParameter("@Accion", SqlDbType.NVarChar);
            param[3].Value = Accion;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HistorialContrato";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);
            //cmd.ExecuteNonQuery();

            DataTable dtResultado = new DataTable("NombreDpto");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dtResultado);

            return dtResultado;
        }

    }
}
