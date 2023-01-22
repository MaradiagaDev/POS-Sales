using NeoCobranza.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Clases
{
    public class ProformaVenta
    {
    

        //Variable del objeto de conexion
        private Conexion _conexion;

        //Constructor(Actualizacion o consulta)
        public ProformaVenta( Conexion conexion)
        {
            

            this._conexion = conexion;

        }



        //Funcionamiento del panel
        public DataTable Listar_Servicios(string filtro)
        {

            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@filtro", SqlDbType.NVarChar);
            param[0].Value = filtro;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_ListarServicios_ProformaVD";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);




            return dtResultado;

        }

        public DataTable ProcediemientoReporte(int idProforma)
        {

            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = idProforma;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Seleccion_Servicios_ProformasVd";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;

        }

        public DataTable Procediemiento_Cliente(int idProforma)
        {

            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = idProforma;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Seleccion_Cliente_ProformasVd";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;

        }
        public DataTable Procediemiento_Vendedor(int idProforma)
        {

            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = idProforma;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Seleccion_Vendedor_ProformasVd";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;

        }
        public DataTable Procediemiento_Descripcion(int idProforma)
        {

            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = idProforma;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Seleccion_Descripcion_ProformasVd";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;

        }
        public DataTable Listar_Ataudes(string filtro)
        {

            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@filtro", SqlDbType.NVarChar);
            param[0].Value = filtro;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_ListarAtaudes_ProformaVD";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);




            return dtResultado;

        }

        public void Insertar_Proforma_Venta(string descripcion,
            int tasa,
            int cliente,
            int vendedor,
            float subtotal,
            float montoDescuento,
            float montoIva,
            float montoTotal)
        {

            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[8];

            param[0] = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
            param[0].Value =descripcion;

            param[1] = new SqlParameter("@IdTasa", SqlDbType.Int);
            param[1].Value = tasa;

            param[2] = new SqlParameter("@IdCliente", SqlDbType.Int);
            param[2].Value = cliente;

            param[3] = new SqlParameter("@idVendedor", SqlDbType.Int);
            param[3].Value = vendedor;

            param[4] = new SqlParameter("@SubTotal", SqlDbType.Float);
            param[4].Value = subtotal;

            param[5] = new SqlParameter("@MontoDescuento", SqlDbType.Float);
            param[5].Value = montoDescuento;

            param[6] = new SqlParameter("@MontoIva", SqlDbType.Float);
            param[6].Value = montoIva;

            param[7] = new SqlParameter("@MontoTotal", SqlDbType.Float);
            param[7].Value = montoTotal;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Insertar_ProformaVD";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();


        }
        public void Actualizar_Descripcion(int idProforma,string descripcion)
        {

            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@idProforma", SqlDbType.Int);
            param[0].Value = idProforma;

            param[1] = new SqlParameter("@descripcion", SqlDbType.NVarChar);
            param[1].Value = descripcion;

            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Actualizar_Descripcion";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();


        }
        public void EliminarDetalles(int idProforma)
        {

            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@idProforma", SqlDbType.Int);
            param[0].Value = idProforma;

       

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_EliminarDetalles_ProformaVd";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();


        }
        public int Id_Ultima()
        {

            DataTable dtResultado = new DataTable("Obtener_Id");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();



            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_UltimoID_Proforma";
            cmd.Connection = _conexion.connect;
           

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return int.Parse(dtResultado.Rows[0]["IdProforma"].ToString());

        }

        public void Insertar_Detalles(int cantidad,
            float subTotal,
            float iva,
            string porcentaje,
            float montoDes,
            int idProforma,
            int idCategoria)
        {

            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[7];

            param[0] = new SqlParameter("@NoServicios", SqlDbType.Int);
            param[0].Value = cantidad;

            param[1] = new SqlParameter("@Subtotal", SqlDbType.Float);
            param[1].Value = subTotal;

            param[2] = new SqlParameter("@Iva", SqlDbType.Float);
            param[2].Value = iva;

            param[3] = new SqlParameter("@PorcentajeDes", SqlDbType.NVarChar);
            param[3].Value = porcentaje;

            param[4] = new SqlParameter("@MontoDes", SqlDbType.Float);
            param[4].Value = montoDes;

            param[5] = new SqlParameter("@IdProforma", SqlDbType.Int);
            param[5].Value = idProforma;

            param[6] = new SqlParameter("@IdCategoria", SqlDbType.Int);
            param[6].Value = idCategoria;

           

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_InsertarDetalle_ProformaVD";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();


        }

        public void Procedimiento_Proforma(int idProforma,
            int idtasa,
            float subtotal,
            float montoDes,
            float iva,
            float total)
        {

            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[6];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = idProforma;

            param[1] = new SqlParameter("@idTasa", SqlDbType.Int);
            param[1].Value = idtasa;

            param[2] = new SqlParameter("@Subtotal", SqlDbType.Float);
            param[2].Value = subtotal;

            param[3] = new SqlParameter("@MontoDes", SqlDbType.Float);
            param[3].Value = montoDes;

            param[4] = new SqlParameter("@iva", SqlDbType.Float);
            param[4].Value = iva;

            param[5] = new SqlParameter("@Total", SqlDbType.Float);
            param[5].Value = total;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_ActualizarDef_ProformaVenta";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int idProforma)
        {

            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = idProforma;

           

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Delete_ProformaVenta";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();


        }

        public void DeletePC(int idProforma)
        {

            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = idProforma;



            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Delete_ProformaContrato";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();


        }

    }
}
