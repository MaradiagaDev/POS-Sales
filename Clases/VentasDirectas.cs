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
    public class VentasDirectas
    {
        //Variable de conexion
        public Conexion conexion;

        //Constructor
        public VentasDirectas(Conexion conexion)
        {
            //Incializacion
            this.conexion = conexion;
        }


        //PROCEDIMIENTO ALMACENADO PARA LLENAR EL CMB CATEGORIAS
        public DataTable CmbCategorias()
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_NombreAtaud_Categoria";
            cmd.Connection = conexion.connect;


            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
            
            sqlData.Fill(dtResultado);

            return dtResultado;
        }
        public DataTable CmbCategoriasServicios()
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_MostrarServicios_VentasDirectas";
            cmd.Connection = conexion.connect;


            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public string Mostrar_Ultima_Venta()
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_UltimaVenta_General";
            cmd.Connection = conexion.connect;


            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado.Rows[0][0].ToString();
        }
        public string Mostra_PrecioXNombre(string nombre)
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@NombreServicio", SqlDbType.NVarChar);
            param[0].Value = nombre;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Mostrar_PrecioXNombre_Ataudes";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);




            return dtResultado.Rows[0]["MontoVD"].ToString();
        }
        public string Mostra_idXNombre_Categoria(string nombre)
        {
            DataTable dtResultado = new DataTable("Obte");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@nombre", SqlDbType.NVarChar);
            param[0].Value = nombre;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_BuscarPorNombre_Categoria";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);


            if (dtResultado.Rows.Count == 0)
            {
                return "0";
            }
            else
            {
                return dtResultado.Rows[0]["IdEstandar"].ToString();
            }


        }
        

        //Que muestre el stock por ataud
        public DataTable Mostra_Stock(string filtro, int IdCategoria)
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@filtro", SqlDbType.NVarChar);
            param[0].Value = filtro;

            param[1] = new SqlParameter("@idEstandar", SqlDbType.Int);
            param[1].Value = IdCategoria;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_VerStockDisponible_Ataudes";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);



            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        

        //PRECEDIMIENTO PARA  INSERTAR VENTA DIRECTA
        public void VentaDirecta(string descripcion, int idCliente, int idVendedor,string noRecibo, string tipo,string estado,float monto)
        {

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[7];

            param[0] = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
            param[0].Value = descripcion;

            param[1] = new SqlParameter("@IdCliente", SqlDbType.Int);
            param[1].Value = idCliente;

            param[2] = new SqlParameter("@IdVendedor", SqlDbType.Int);
            param[2].Value = idVendedor;

            param[3] = new SqlParameter("@NoRecibo", SqlDbType.NVarChar);
            param[3].Value = noRecibo;

            param[4] = new SqlParameter("@Tipo", SqlDbType.NVarChar);
            param[4].Value = tipo;

            param[5] = new SqlParameter("@Estado", SqlDbType.NVarChar);
            param[5].Value = estado;

            param[6] = new SqlParameter("@MontoIncial", SqlDbType.Float);
            param[6].Value = monto;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_InsertarVenta_General";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
            
                
            
        }

        public void VentaFutura(int idVenta, int Descuento ,int idAtaud)
        {

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@IdVenta", SqlDbType.Int);
            param[0].Value = idVenta;

            param[1] = new SqlParameter("@Descuento", SqlDbType.Int);
            param[1].Value = Descuento;

            param[2] = new SqlParameter("@idAtaud", SqlDbType.Int);
            param[2].Value = idAtaud;



            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_InsertarDetalleAtaud_General";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }
        public void VentaReserva(int idVenta,int descuento,int idEstandar, int cantidad)
        {

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@IdVenta", SqlDbType.NVarChar);
            param[0].Value = idVenta;

            param[1] = new SqlParameter("@Descuento", SqlDbType.Int);
            param[1].Value = descuento;

            param[2] = new SqlParameter("@IdEstandar", SqlDbType.Int);
            param[2].Value = idEstandar;

            param[3] = new SqlParameter("@cantidad", SqlDbType.Int);
            param[3].Value = cantidad;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_InsertarDetalleServcios_General";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }

        //Precedimiento para mostrar los ataudes sin retirar en venta futura

        public DataTable Mostra_SinRetirar_VentaFutura(string filtro)
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@filtro", SqlDbType.NVarChar);
            param[0].Value = filtro;

          


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Mostrar_Vendidos";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);



            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public DataTable Mostra_SinRetirar_Reservacion(string filtro)
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@filtro", SqlDbType.NVarChar);
            param[0].Value = filtro;




            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Mostrar_Reservados";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);



            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        //Cancelacion de ataudes
        public void Cancelacion_Futuro(int idAtaud)
        {

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            
            param[0] = new SqlParameter("@idAtaud", SqlDbType.Int);
            param[0].Value = idAtaud;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Cancelar_Futuros";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }
        public void Cancelacion_Reservado(int idAtaud)
        {

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];


            param[0] = new SqlParameter("@idAtaud", SqlDbType.Int);
            param[0].Value = idAtaud;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Cancelar_Reservados";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }



        //FACTURACIONES
        public DataTable Mostra_Stock_Facturacion_VD(string filtro)
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@filtro", SqlDbType.NVarChar);
            param[0].Value = filtro;

           

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_MostrarFacturas_Vendidos";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);



            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public DataTable Mostra_Stock_Facturacion_VF(string filtro)
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@filtro", SqlDbType.NVarChar);
            param[0].Value = filtro;



            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_MostrarFacturas_VentasFuturas";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);



            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public DataTable Mostra_Stock_Facturacion_R(string filtro)
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@filtro", SqlDbType.NVarChar);
            param[0].Value = filtro;



            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_MostrarFacturas_Reservados";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);



            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        //Cambios de estado

        public void VentaDirectas_Estandares(int idAtaud)
        {

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];


            param[0] = new SqlParameter("@idAtaud", SqlDbType.Int);
            param[0].Value = idAtaud;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_ActualizarVendido_EstadoEstandar";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }

        public void VentaDirectas_Futuras(int idAtaud)
        {

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];


            param[0] = new SqlParameter("@idAtaud", SqlDbType.Int);
            param[0].Value = idAtaud;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_ActualizarVentaFutura_EstadoEstandar";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }

        public void VentaDirectas_Reservas(int idAtaud)
        {

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];


            param[0] = new SqlParameter("@idAtaud", SqlDbType.Int);
            param[0].Value = idAtaud;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_ActualizarVentaReserva_EstadoEstandar";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }

        public DataTable Mostra_IdsAtaudes(int id)
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.NVarChar);
            param[0].Value = id;



            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_ListarIdsAtaudes";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);



            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public DataTable Mostra_AtaudesReservados(int id)
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.NVarChar);
            param[0].Value = id;



            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_ListarAtaudesPorVenta";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);



            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public DataTable Mostra_ServiciosReservados(int id)
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.NVarChar);
            param[0].Value = id;



            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_ListarAServiciosPorVenta";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);



            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public DataTable Mostra_Todas_Ventas(string filtro)
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@filtro", SqlDbType.NVarChar);
            param[0].Value = filtro;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Mostrar_TodasVentas";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);



            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public DataTable Mostra_SubTotal_Ataudes(int id)
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.NVarChar);
            param[0].Value = id;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_SubTotal_Ataudes";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);



            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public DataTable Mostra_SubTotal_Servicios(int id)
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.NVarChar);
            param[0].Value = id;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_SubTotal_Servicios";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);



            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        //----------------------- Procedimientos para actualizar ------------------

        public DataTable Actualizar_Cliente(int id)
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.NVarChar);
            param[0].Value = id;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Actualizacion_Ventas_Cliente";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);



            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public DataTable Actualizar_Vendedor(int id)
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.NVarChar);
            param[0].Value = id;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Actualizacion_Ventas_Vendedor";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);



            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public DataTable Actualizar_Info(int id)
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.NVarChar);
            param[0].Value = id;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Actualizacion_Ventas_Descripciones";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);



            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public DataTable Actualizar_Ataudes(int id)
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.NVarChar);
            param[0].Value = id;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Actualizacion_Ventas_Ataudes";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);



            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public DataTable Actualizar_Servicios(int id)
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.NVarChar);
            param[0].Value = id;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Actualizacion_Ventas_Servicios";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);



            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public void Actualizar_Disponible(int id)
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.NVarChar);
            param[0].Value = id;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Actualizar_Ventas_Anular";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }

//-----------------------DIRECTAMENTE PARA EL BOTON ACTUALIZAR------------------------
        public void Actualizar_Delete(int id)
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Actualizar_Ventas_Borrar_detalles";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }

        public void Actualizar_Detalles(int id,string descripcion, string noRecibo)
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@descripcion", SqlDbType.NVarChar);
            param[1].Value = descripcion;

            param[2] = new SqlParameter("@NoRecibo", SqlDbType.NVarChar);
            param[2].Value = noRecibo;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Actualizar_Ventas_General";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }
        public void Actualizar_Monto(int id, float monto)
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@Monto", SqlDbType.Float);
            param[1].Value = monto;

            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Actualizar_Ventas_Monto";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }

        public void Actualizar_Estado(int id)
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

           

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Ventas_estado";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }

        public string Obtener_Estado(int id)
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.NVarChar);
            param[0].Value = id;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Ventas_VerficarEstado";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);



            sqlData.Fill(dtResultado);

            return dtResultado.Rows[0][0].ToString();
        }
    }
}
