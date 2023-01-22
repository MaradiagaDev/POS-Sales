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
    public class Imagen
    {
        //VARIABLE DE CONEXION
        public Conexion _conexion;



        //CONSTRUCTOR DE CONSULTAS
        public Imagen(Conexion conexion)
        {
            this._conexion= conexion;
        }

        //PROCEDIMIENTOS GENERALES-------------------------------------


        //Mostrar la ultima imagen insertada en la tabla
        public string Mostrar_Ultima_Imagen()
        {
            SqlCommand cmd = new SqlCommand();


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UltimoIdImagen";
            cmd.Connection = _conexion.connect;
            

            DataTable dtResultado = new DataTable("NombreDpto");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dtResultado);

            return dtResultado.Rows[0]["IdImagen"].ToString();
        }

        //Mostrar imagen relacionada al contrato
        public SqlDataReader Mostrar_Imagen(int id)
        {
            SqlCommand cmdI = new SqlCommand();

            SqlParameter param = new SqlParameter();

            param = new SqlParameter("@id", SqlDbType.Int);
            param.Value = id;




            cmdI.CommandType = CommandType.StoredProcedure;
            cmdI.CommandText = "MostrarImagen";
            cmdI.Connection = _conexion.connect;
            cmdI.Parameters.Add(param);


            SqlDataReader dr = cmdI.ExecuteReader();


            dr.Read();
            return dr;

        }
        public SqlDataReader Mostrar_Imagen_Ventas(int id)
        {
            SqlCommand cmdI = new SqlCommand();

            SqlParameter param = new SqlParameter();

            param = new SqlParameter("@id", SqlDbType.Int);
            param.Value = id;




            cmdI.CommandType = CommandType.StoredProcedure;
            cmdI.CommandText = "MostrarImagenVentas";
            cmdI.Connection = _conexion.connect;
            cmdI.Parameters.Add(param);


            SqlDataReader dr = cmdI.ExecuteReader();


            dr.Read();
            return dr;

        }
    }
}
