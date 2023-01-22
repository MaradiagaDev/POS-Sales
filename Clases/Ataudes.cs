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
    /*
     * Esta clase no interactua con el stock porque se planea hacer una clase compras
     * Por lo que esta se trata de temas generales en relacion con los ataudes
     * 
     * 
     * 
     */
    public class Ataudes
    {
        //VARIABLE DE CONEXION
        private Conexion _conexion;

        //VARIABLES PROPIAS
        private int _idAtaud;
        private string _nombreModelo;
        private float _monto;
        private string _estado;
        private int _idImagen;
        private string _descripcion;
        private int _noExistencias;
        private int _idProveedor;
        private float _montoContrato;
        private string _noRemision;


        //Constructor para actualizaciones o consultas
        public Ataudes(Conexion conexion)
        {
            this._conexion = conexion;
        }
        //Constructor para actualizar
        public Ataudes(Conexion conexion, int idAtaud, string nombreModelo,
            float monto,
            string estado)
        {
            this._conexion = conexion;
            this._idAtaud = idAtaud;
            this._nombreModelo = nombreModelo;
            this._monto = monto;
            this._estado = estado;
            

        }


        //Constructor para actualizar
        public Ataudes(Conexion conexion, string nombreModelo,
            float monto,
            string estado)
        {
            this._conexion = conexion;
            this._nombreModelo = nombreModelo;
            this._monto = monto;
            this._estado = estado;
            
        }

        public int IdAtaud { get => _idAtaud; set => _idAtaud = value; }
        public string NombreModelo { get => _nombreModelo; set => _nombreModelo = value; }
        public float Monto { get => _monto; set => _monto = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public int IdImagen { get => _idImagen; set => _idImagen = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public int NoExistencias { get => _noExistencias; set => _noExistencias = value; }
        public int IdProveedor { get => _idProveedor; set => _idProveedor = value; }
        public float MontoContrato { get => _montoContrato; set => _montoContrato = value; }
        public string NoRemision { get => _noRemision; set => _noRemision = value; }

        //PROCEDIMIENTOS GENERALES-----------------------------------------------

        //Procedimiento que muestra el stock general
        public DataTable Mostra_Stock(string filtro,int IdCategoria)
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
            cmd.CommandText = "Nuevo_VerStock_Ataudes";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);



            sqlData.Fill(dtResultado);

            return dtResultado;
        }
        //Procedimiento que lista TODO(Solo nombres)
        public DataTable Mostrar_Todos_Nombres()
        {
            
                DataTable dtResultado = new DataTable("NombreServicio");


                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = _conexion.connect;

                sqlCommand.CommandText = "Nuevo_Mostrar_Nombre_Ataudes";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

                sqlData.Fill(dtResultado);

                return dtResultado;
            
        }
        //Procedimiento que obtiene (UNICO) A PARTIR DEL NOMBRE

        public string Mostra_PrecioXNombre()
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@NombreServicio", SqlDbType.NVarChar);
            param[0].Value = _nombreModelo;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Mostrar_PrecioXNombre_Ataudes";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);




            return dtResultado.Rows[0]["MontoVD"].ToString();
        }
        public string Mostra_Ultimo()
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();



            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_MostrarUltimo_Servicio";
            cmd.Connection = _conexion.connect;
        

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);




            return dtResultado.Rows[0]["IdAtaud"].ToString();
        }
        public DataTable Mostra_Todo(string filtro)
        {
            DataTable dtResultado = new DataTable("Obtener_Ataudes");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@filtro", SqlDbType.NVarChar);
            param[0].Value = filtro;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Mostrar_Todo_Ataudes";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);




            return dtResultado;
        }



        //PROCEDIMIENTO DE INSERTAR
        public void Insertar_Ataud(string color,string noSerie,int idEstandar,string noRemision)
        {

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@Color", SqlDbType.NVarChar);
            param[0].Value = color;

            param[1] = new SqlParameter("@NoSerie", SqlDbType.NVarChar);
            param[1].Value = noSerie;

            param[2] = new SqlParameter("@NoRemision", SqlDbType.NVarChar);
            param[2].Value = noRemision;

            param[3] = new SqlParameter("@IdEstandar", SqlDbType.Int);
            param[3].Value = idEstandar;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Insertar_Ataudes";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }
      

        public void Cambio_PrecioVenta()
        {

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@idAtaud", SqlDbType.Int);
            param[0].Value = _idAtaud;

            param[1] = new SqlParameter("@NuevoPrecio", SqlDbType.Float);
            param[1].Value = _monto;

            param[2] = new SqlParameter("@NuevoPrecioContrato", SqlDbType.Float);
            param[2].Value = _montoContrato;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_PrecioVenta_Ataudes";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }
        public void CambioeEstado_Categorias(int id)
        {

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_CambioEstado_Categoria";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }
        public void Actualizar_Categorias(int id,string nombre,string descripcion)
        {

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@nombre", SqlDbType.NVarChar);
            param[1].Value = nombre;

            param[2] = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
            param[2].Value = descripcion;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Actualizar_Categoria";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }


        public void Actualizar_Ataud()
        {



            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@idAtaud", SqlDbType.Int);
            param[0].Value = _idAtaud;

            param[1] = new SqlParameter("@nombreModelo", SqlDbType.NVarChar);
            param[1].Value = _nombreModelo;

            param[2] = new SqlParameter("@descripcion", SqlDbType.NVarChar);
            param[2].Value = _descripcion;



            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Actualizar_Ataudes";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }
        public void Actualizar_Estado(int idAtaud,string estado)
        {

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@idAtaud", SqlDbType.Int);
            param[0].Value = idAtaud;

            param[1] = new SqlParameter("@estado", SqlDbType.NVarChar);
            param[1].Value = estado;

            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Estado_Ataudes";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }

        //ACTUALIZAR IMAGEN
        public void Actualizar_Imagen()
        {
            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@idAtaud", SqlDbType.Int);
            param[0].Value = _idAtaud;

            param[1] = new SqlParameter("@idImagen", SqlDbType.Int);
            param[1].Value = _idImagen;



            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Actualizar_Imagen_Ataudes";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }
        /*
         * Categorias
         * Esto es para lo relacionado con el nuevo orden que se realizara
         * 
         */

        //SOLO VER NOMBRES PARA COMBOBOX
        public DataTable CmbCategorias()
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Nombre_Categoria";
            cmd.Connection = _conexion.connect;


            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        // SOLO PARA INSERTAR CATEGORIAS

        public void InsertarCategoria(string nombre,float montoVD,float montoCont,int idProveedor,string tipo, float mejora)
        {
            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[6];

            param[0] = new SqlParameter("@Nombre", SqlDbType.NVarChar);
            param[0].Value = nombre;

            param[1] = new SqlParameter("@MontoVD", SqlDbType.Float);
            param[1].Value = montoVD;

            param[2] = new SqlParameter("@MontoCon", SqlDbType.Float);
            param[2].Value = montoCont;

            param[3] = new SqlParameter("@IdProveedor", SqlDbType.Int);
            param[3].Value = idProveedor;

            param[4] = new SqlParameter("@Tipo", SqlDbType.NVarChar);
            param[4].Value = tipo;

            param[5] = new SqlParameter("@Mejora", SqlDbType.Float);
            param[5].Value = mejora;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Insertar_Categoria";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }
        //BUSCAR ID POR NOMBRE
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
            cmd.Connection = _conexion.connect;
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
        public string Mostra_TipoxNombre_Categoria(string nombre)
        {
            DataTable dtResultado = new DataTable("Obte");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@nombre", SqlDbType.NVarChar);
            param[0].Value = nombre;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Tipo_Categoria";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);


            if (dtResultado.Rows.Count == 0)
            {
                return "";
            }
            else
            {
                return dtResultado.Rows[0]["TipoServicio"].ToString();
            }


        }
        public string Verificar_Categoria(string nombre)
        {
            DataTable dtResultado = new DataTable("Obte");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@nombre", SqlDbType.NVarChar);
            param[0].Value = nombre;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Verificar_Categoria";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);


          
                return dtResultado.Rows[0]["respuesta"].ToString();
            


        }
        public DataTable Mostra_TipoTotal_Categoria(string filtro)
        {
            DataTable dtResultado = new DataTable("Obte");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@filtro", SqlDbType.NVarChar);
            param[0].Value = filtro;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_VerTodo_Categorias";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);


            
                return dtResultado;

        }
        public DataTable MostraTodo_Categoria(int idEstandar)
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@idEstandar", SqlDbType.NVarChar);
            param[0].Value = idEstandar;
            //Procedimiento
            SqlCommand cmd = new SqlCommand();



            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_ObtenerDatos_Categoria";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);




            return dtResultado;
        }
        public void ActualizarPrecios_Categorias(float montoVD, float montoCont,float mejora, int idEstandar)
        {
            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@idEstandar", SqlDbType.NVarChar);
            param[0].Value = idEstandar;

            param[1] = new SqlParameter("@MontoVD", SqlDbType.Float);
            param[1].Value = montoVD;

            param[2] = new SqlParameter("@MontoCon", SqlDbType.Float);
            param[2].Value = montoCont;

            param[3] = new SqlParameter("@Mejora", SqlDbType.Float);
            param[3].Value = mejora;




            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_ActualizarPrecios_Categoria";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }
        public void Traslado_Ataud(int idAtaud,string ubicacion,string remision)
        {
            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@Ubicacion", SqlDbType.NVarChar);
            param[0].Value = ubicacion;


            param[1] = new SqlParameter("@idAtaud", SqlDbType.Int);
            param[1].Value = idAtaud;

            param[2] = new SqlParameter("@remision", SqlDbType.NVarChar);
            param[2].Value = remision;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Traslado_Ataud";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }

        public void VentaAgencia_Ataud(int idAtaud)
        {
            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

         

            param[0] = new SqlParameter("@idAtaud", SqlDbType.Int);
            param[0].Value = idAtaud;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_VendidoAgencia_Ataud";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }
    }
}
