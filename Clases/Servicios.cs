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

    /*
     * Esta clase no interactua con el stock porque se planea hacer una clase compras
     * Por lo que esta se trata de temas generales en relacion con los servicios
     * 
     * 
     * 
     */
    public class Servicios
    {
        //VARIABLES DE CONEXION
        public Conexion _conexion;
        //VARIABLES PROPIAS
        private int _idServicio;
        private string _nombre;
        private string _descripcion;
        private string _estado;
        private string _disponibilidad;
        private float _precioDolar;
        private int _idImagen;

        //Constructor para consultas y actualizaciones
        public Servicios(Conexion conexion)
        {
            this._conexion = conexion;
        }
        //Constructor para actualizar
        public Servicios(Conexion conexion, int idServicio,string nombre,
            string descripcion,
            string estado,
            string disponibilidad,
            float precioDolar,
            int idImagen)
        {
            this._conexion = conexion;
            this._idServicio = idServicio;
            this._nombre = nombre;
            this._descripcion = descripcion;
            this._estado = estado;
            this._disponibilidad = disponibilidad;
            this._precioDolar = precioDolar;
            this._idImagen = idImagen;
           
        }
        //Constructor para Crear
        public Servicios(Conexion conexion, 
            string descripcion,
            string estado,
            string disponibilidad,
            float precioDolar,
            int idImagen)
        {
            this._conexion = conexion;
            this._descripcion = descripcion;
            this._estado = estado;
            this._disponibilidad = disponibilidad;
            this._precioDolar = precioDolar;
            this._idImagen = idImagen;

        }





        //Gets y sets

        public int IdServicio { get => _idServicio; set => _idServicio = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public string Disponibilidad { get => _disponibilidad; set => _disponibilidad = value; }
        public float PrecioDolar { get => _precioDolar; set => _precioDolar = value; }
        public int IdImagen { get => _idImagen; set => _idImagen = value; }



        //PROCEDIMIENTOS GENERALES-----------------------------------------------

        //Procedimiento que muestra el stock general
        public DataTable Mostra_Stock(string filtro)
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@filtro", SqlDbType.NVarChar);
            param[0].Value = filtro;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_VerStock_Servicio";
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

            sqlCommand.CommandText = "Nuevo_Mostrar_Nombre_Servicios";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }


        //Procedimiento que obtiene (UNICO) A PARTIR DEL NOMBRE

            public string Mostra_PrecioXNombre() {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@NombreServicio", SqlDbType.NVarChar);
            param[0].Value = _nombre;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Mostrar_PrecioXNombre_Servicios";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);




            return dtResultado.Rows[0]["PrecioDolar"].ToString();
        }

        //Consuta general(Con todos los campos)

        public DataTable Mostra_Todo(string filtro)
        {
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@filtro", SqlDbType.NVarChar);
            param[0].Value = filtro;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Mostrar_Todo_Servicio";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);




            return dtResultado;
        }

        //PROCEDIMIENTO DE INSERTAR

        public void Insertar_Servicio()
        {         

            

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[6];

            param[0] = new SqlParameter("@nombre", SqlDbType.NVarChar);
            param[0].Value = _nombre;

            param[1] = new SqlParameter("@descripcion", SqlDbType.NVarChar);
            param[1].Value = _descripcion;

            param[2] = new SqlParameter("@estado", SqlDbType.NVarChar);
            param[2].Value = _estado;

            param[3] = new SqlParameter("@disponibilidad", SqlDbType.NVarChar);
            param[3].Value = _disponibilidad;

            param[4] = new SqlParameter("@precioDolar", SqlDbType.Float);
            param[4].Value = _precioDolar;

            param[5] = new SqlParameter("@idImagen", SqlDbType.Int);
            param[5].Value = _idImagen;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Insertar_Servicio";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }

        //Procedimiento para actualizar Servicio

        public void Actualizar_Servicio()
        {



            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@idServicio", SqlDbType.Int);
            param[0].Value = _idServicio;

            param[1] = new SqlParameter("@nombre", SqlDbType.NVarChar);
            param[1].Value = _nombre;

            param[2] = new SqlParameter("@descripcion", SqlDbType.NVarChar);
            param[2].Value = _descripcion;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Actualizar_Servicio";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }

        //Actualizar imagen

        public void Actualizar_Imagen()
        {



            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@idServicio", SqlDbType.Int);
            param[0].Value = _idServicio;

            param[1] = new SqlParameter("@idImagen", SqlDbType.Int);
            param[1].Value = _idImagen;



            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Actualizar_Imagen_Servicio";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }

        //ACTUALIZAR ESTADO
        public void Actualizar_Estado()
        {

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@idServicio", SqlDbType.Int);
            param[0].Value = _idServicio;

            param[1] = new SqlParameter("@estado", SqlDbType.NVarChar);
            param[1].Value = _estado;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Estado_Servicios";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }


    }
}
