using NeoCobranza.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ReportingServices.Diagnostics.Internal;
using System.Diagnostics.Contracts;

namespace NeoCobranza.DataController
{
    public class CProforma
    {


        public Conexion conexion;
        public CProforma(Conexion conexion)
        {
            this.conexion = conexion;

        }

        //BUSCAR ATAUD
        public DataTable FiltroAtaud(String filtro)
        {
            DataTable dtResultado = new DataTable("Buscar Ataud");




            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "Mostrar_TodoAtaudes";
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
        // MOSTRAR SERVICIOS
        public DataTable FiltroServicios(String filtro)
        {
            DataTable dtResultado = new DataTable("Buscar Servicios");




            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "FiltroServicios";
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
        public void AgregarProforma(string descripcion, float total, int idTasa, int idCliente,int idVendedor)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[5];
            
            param[0] = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
            param[0].Value = descripcion;
            
            param[1] = new SqlParameter("@total", SqlDbType.Float);
            param[1].Value = total;
            
            param[2] = new SqlParameter("@idTasa", SqlDbType.Int);
            param[2].Value = idTasa;
            
            param[3] = new SqlParameter("@idCliente", SqlDbType.Int);
            param[3].Value = idCliente;

            param[4] = new SqlParameter("@idVendedor", SqlDbType.Int);
            param[4].Value = idVendedor;



            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Add_Proforma";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                //cmd.ExecuteNonQuery();

                DataTable dtResultado = new DataTable("NombreDpto");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtResultado);

                MessageBox.Show(dtResultado.Rows[0]["id"].ToString(), "Agregado");

            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.ToString(),"error");
            }

        }

        public void AgregarDetallesProforma(int idServicio, float Subtotal, int NoServicios, float descuento,int idProforma)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[5];

            param[0] = new SqlParameter("@idServicio", SqlDbType.Int);
            param[0].Value = idServicio;

            param[1] = new SqlParameter("@Subtotal", SqlDbType.Float);
            param[1].Value = Subtotal;

            param[2] = new SqlParameter("@NoServicios", SqlDbType.Int);
            param[2].Value = NoServicios;

            param[3] = new SqlParameter("@Descuento", SqlDbType.Float);
            param[3].Value = descuento;


            param[4] = new SqlParameter("@idProforma", SqlDbType.Int);
            param[4].Value = idProforma;


            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DetallesProforma";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();

                

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "error");
            }

        }

        public string MostrarIdProforma()
        {
            DataTable dtResultado = new DataTable("IdProforma");


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "MostrarUltimaProforma";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

            sqlData.Fill(dtResultado);


            return dtResultado.Rows[0]["IdProforma"].ToString();
        }

        public void AgregarDetallesProformaAtaud(int idServicio, int NoServicios, float descuento, int idProforma)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@idServicio", SqlDbType.Int);
            param[0].Value = idServicio;

            
            param[1] = new SqlParameter("@NoServicios", SqlDbType.Int);
            param[1].Value = NoServicios;

            param[2] = new SqlParameter("@Descuento", SqlDbType.Float);
            param[2].Value = descuento;


            param[3] = new SqlParameter("@idProforma", SqlDbType.Int);
            param[3].Value = idProforma;


            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[DetallesAtaud]";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "error");
            }

        }
        public string MostrarIdAtaud(string nombre)
        {
            DataTable dtResultado = new DataTable("BuscarDeptp");




            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "IdAtaud";
            sqlCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter filtroDato = new SqlParameter();
            filtroDato.ParameterName = "@nombre";
            filtroDato.SqlDbType = SqlDbType.NVarChar;
            filtroDato.Size = 100;
            filtroDato.Value = nombre;

            sqlCommand.Parameters.Add(filtroDato);

            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

            sqlData.Fill(dtResultado);


            return dtResultado.Rows[0]["IdAtaud"].ToString();
        }

        public DataTable BusarServicios(int id)
        {
            DataTable dtResultado = new DataTable("Buscar Servicios");




            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "cargarDgvServiciosProformas";
            sqlCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter filtroDato = new SqlParameter();
            filtroDato.ParameterName = "@idProforma";
            filtroDato.SqlDbType = SqlDbType.VarChar;
            filtroDato.Size = 200;
            filtroDato.Value = id;

            sqlCommand.Parameters.Add(filtroDato);

            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

            sqlData.Fill(dtResultado);
            return dtResultado;
        }

        public void ELiminarDetalles(int proforma)
        {
            try
            {
                string query = "exec eliminarServicios " + proforma;
                SqlCommand sqlCommand = new SqlCommand(query, conexion.connect);
                sqlCommand.ExecuteNonQuery();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                    
            }
        }

    }
}
