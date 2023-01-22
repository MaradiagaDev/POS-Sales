using NeoCobranza.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCobranza.Clases
{
    public class Auditorias
    {
        public Conexion conexion;
        public Auditorias(Conexion conexion)
        {
            this.conexion = conexion;

        }

        //Procedimientos generales para las auditorias
        public DataTable Mostra_Filtroauditoria(string filtro)
        {
            DataTable dtResultado = new DataTable("AuditoriaFiltro");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@filtro", SqlDbType.NVarChar);
            param[0].Value = filtro;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_FiltroSeguridad";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }
        public void Insertar(string nombreUsuario,string descripcion, string id,string objeto)
        {
           
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@nombreUser", SqlDbType.NVarChar);
            param[0].Value = nombreUsuario;
            param[1] = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
            param[1].Value = descripcion;
            param[2] = new SqlParameter("@id", SqlDbType.NVarChar);
            param[2].Value = id;
            param[3] = new SqlParameter("@Objeto", SqlDbType.NVarChar);
            param[3].Value = objeto;



            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_IngresarHistorial";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }
    }
}
