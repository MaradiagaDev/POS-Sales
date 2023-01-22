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
    public class CServiciosVD
    {

        public Conexion conexion;

        public CServiciosVD(Conexion conexion)
        {
            this.conexion = conexion;   
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

            return dtResultado.Rows[0]["IdImagen"].ToString();
        }
        public SqlDataReader MostrarImagen(int id)
        {
            SqlCommand cmdI = new SqlCommand();

            SqlParameter param = new SqlParameter();

            param = new SqlParameter("@id", SqlDbType.Int);
            param.Value = id;




            cmdI.CommandType = CommandType.StoredProcedure;
            cmdI.CommandText = "MostrarImagenVentas";
            cmdI.Connection = conexion.connect;
            cmdI.Parameters.Add(param);


            SqlDataReader dr = cmdI.ExecuteReader();


            dr.Read();
            return dr;

        }
        public DataTable FiltroAtaud(String filtro)
        {
            DataTable dtResultado = new DataTable("Buscar Ataud");




            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "Mostrar_TodoAtaudesMod";
            sqlCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter filtroDato = new SqlParameter();
            filtroDato.ParameterName = "@filtro";
            filtroDato.SqlDbType = SqlDbType.VarChar;
            filtroDato.Size = 200;
            filtroDato.Value = filtro;

            sqlCommand.Parameters.Add(filtroDato);

            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

            sqlData.Fill(dtResultado);


            return dtResultado;

        }
        public void ActualializarImagen(int idImage, int idAtaud)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@idImagen", SqlDbType.Int);
            param[0].Value = idImage;

            param[1] = new SqlParameter("@idAtaud", SqlDbType.Int);
            param[1].Value = idAtaud;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertarLlaveImagenVentas";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);
            cmd.ExecuteNonQuery();
           


        }
        public DataTable FiltroServicios(String filtro)
        {
            DataTable dtResultado = new DataTable("Buscar Ataud");




            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "FiltroServiciosMod";
            sqlCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter filtroDato = new SqlParameter();
            filtroDato.ParameterName = "@filtro";
            filtroDato.SqlDbType = SqlDbType.VarChar;
            filtroDato.Size = 200;
            filtroDato.Value = filtro;

            sqlCommand.Parameters.Add(filtroDato);

            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

            sqlData.Fill(dtResultado);


            return dtResultado;
        }
        public void CambiarEstado(int idServicio, string Estado)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@idServicio", SqlDbType.Int);
            param[0].Value = idServicio;

            param[1] = new SqlParameter("@Estado", SqlDbType.NVarChar);
            param[1].Value = Estado;

            

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CambiarEstado";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "error");
            }

        }
        public void Acualizar(int idServicio, string nmbre,string descripcion,string precioDolar, string tipo)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[5];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = idServicio;

            param[1] = new SqlParameter("@Servicio", SqlDbType.NVarChar);
            param[1].Value = nmbre;

            param[2] = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
            param[2].Value = descripcion;

            param[3] = new SqlParameter("@PrecioDolar", SqlDbType.NVarChar);
            param[3].Value = precioDolar;

            param[4] = new SqlParameter("@Tipo", SqlDbType.NVarChar);
            param[4].Value = tipo;

            


            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ActualizarServicio";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "error");
            }

        }
        public void Insertar( string nmbre, string descripcion, string precioDolar, string tipo)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[4];

            

            param[0] = new SqlParameter("@Servicio", SqlDbType.NVarChar);
            param[0].Value = nmbre;

            param[1] = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
            param[1].Value = descripcion;

            param[2] = new SqlParameter("@PrecioDolar", SqlDbType.NVarChar);
            param[2].Value = precioDolar;

            param[3] = new SqlParameter("@Tipo", SqlDbType.NVarChar);
            param[3].Value = tipo;




            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CreateServices";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                //cmd.ExecuteNonQuery();


                DataTable dtResultado = new DataTable("NombreDp");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtResultado);


                MessageBox.Show(dtResultado.Rows[0]["mensaje"].ToString(), "Agregado");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "error");
            }

        }




    }
}
