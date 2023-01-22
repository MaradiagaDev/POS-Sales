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
    public class Usuario
    {

        //Definicion de variables propias de la clase
        private string _nombreUsuario;
        private int _idUsuario;
        //Variable de conexion
        private Conexion _conexion;

        //Constructor
        public Usuario(Conexion conexion)
        {
            
        }
        //getters y setters
        public string NombreUsuario { get => _nombreUsuario; set => _nombreUsuario = value; }
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }


        //PROCEDIMIENTO GENERALES ------------------------------------------------------------------

        public DataTable Listar_Todos()
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();



            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Listar_Todos";
            cmd.Connection = _conexion.connect;


            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);




            return dtResultado;
        }

        public void Deshabilitar()
        {

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@usuario", SqlDbType.NVarChar);
            param[0].Value = _nombreUsuario;

           


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Deshabilitar_Usuario";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }
        public void Camibiar_Estado()
        {

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = _idUsuario;




            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_CambioEstado_Usuario";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }
        public string Verificar_Habilitado()
        {
            DataTable dtResultado = new DataTable("Obtener");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@usuario", SqlDbType.NVarChar);
            param[0].Value = _nombreUsuario;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Verificar_Usuario";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);




            return dtResultado.Rows[0]["Estado"].ToString();
        }
    }
}
