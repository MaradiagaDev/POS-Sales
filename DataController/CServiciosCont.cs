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
    public class CServiciosCont
    {
        public Conexion conexion;
        public CServiciosCont(Conexion conexion)
        {
            this.conexion = conexion;   
        }

        public void InsertarServicio(string nombre, float monto)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@nombre", SqlDbType.NVarChar);
            param[0].Value = nombre;

            param[1] = new SqlParameter("@monto", SqlDbType.Float);
            param[1].Value = monto;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertarServiciosContratos";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Servicio ingresado", "Info");
           
        }
        public void ActualizarServicio(int id,string nombre, float monto)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@nombre", SqlDbType.NVarChar);
            param[1].Value = nombre;

            param[2] = new SqlParameter("@precio", SqlDbType.Float);
            param[2].Value = monto;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ActualizarServiciosContratos";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Servicio Actulizado", "Info");

        }

        public DataTable MostrarServicios(string filtro)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter param = new SqlParameter();

            param= new SqlParameter("@filtro", SqlDbType.NVarChar);
            param.Value = filtro;

            


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ListarServiciosContratos";
            cmd.Connection = conexion.connect;
            cmd.Parameters.Add(param);
            //cmd.ExecuteNonQuery();

            DataTable dtResultado = new DataTable("NombreDpto");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dtResultado);

            return dtResultado;
        }

        public string MostrarUltimaImagen()
        {
            SqlCommand cmd = new SqlCommand();


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UltimoIdImagen";
            cmd.Connection = conexion.connect;
            //cmd.ExecuteNonQuery();

            DataTable dtResultado = new DataTable("NombreDpto");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dtResultado);

            return dtResultado.Rows[0]["IdImagen"].ToString() ;
        }
        public void ActualializarImagen(int idImage,int idAtaud)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@idImagen", SqlDbType.Int);
            param[0].Value = idImage;

            param[1] = new SqlParameter("@idAtaud", SqlDbType.Int);
            param[1].Value = idAtaud;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertarLlaveImagen";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);
            cmd.ExecuteNonQuery();



        }
        public SqlDataReader MostrarImagen(int id)
        {
            SqlCommand cmdI = new SqlCommand();

            SqlParameter param = new SqlParameter();

            param = new SqlParameter("@id", SqlDbType.Int);
            param.Value = id;




            cmdI.CommandType = CommandType.StoredProcedure;
            cmdI.CommandText = "MostrarImagen";
            cmdI.Connection = conexion.connect;
            cmdI.Parameters.Add(param);

            
            SqlDataReader dr = cmdI.ExecuteReader();


            dr.Read();
            return dr;
            
        }

        public void CambiarServicios(int id)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter param = new SqlParameter();

            param = new SqlParameter("@id", SqlDbType.Int);
            param.Value = id;




            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CambiarServiciosContratos";
            cmd.Connection = conexion.connect;
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Cambio de estado realizado", "Info");

        }
        public void BorrarImagen(int id)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter param = new SqlParameter();

            param = new SqlParameter("@id", SqlDbType.Int);
            param.Value = id;




            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "BorrarImagen";
            cmd.Connection = conexion.connect;
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();
            MessageBox.Show("ImagenBorrada", "Info");

        }


    }
}
