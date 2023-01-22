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
    //Cadena de conexion
    public class Proveedor
    {
        //Cadena de conexion
        private Conexion _conexion;

        //Variables propias de la clase

        private int _idProveedor;
        private string _nombreEmpresa;
        private string _noTelefono;
        private string _noRuc;
        private string _correo;
        private string _direccion;



        public Proveedor(Conexion conexion)
        {
            this._conexion = conexion;
        }

        public int IdProveedor { get => _idProveedor; set => _idProveedor = value; }
        public string NombreEmpresa { get => _nombreEmpresa; set => _nombreEmpresa = value; }
        public string NoTelefono { get => _noTelefono; set => _noTelefono = value; }
        public string NoRuc { get => _noRuc; set => _noRuc = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }



        //PROCEDIMIENTOS GENERALES-----------------------------------------------

        //Procedimiento que muestra a todos los proveedores
        public DataTable Mostra_Proveedores(string filtro)
        {
            DataTable dtResultado = new DataTable("Proveedores");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@filtro", SqlDbType.NVarChar);
            param[0].Value = filtro;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Listar_Proveedores";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        //PROCEDIMIENTO DE INSERTAR
        public void Insertar_Proveedor()
        {

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[5];

            param[0] = new SqlParameter("@nombreEmpresa", SqlDbType.NVarChar);
            param[0].Value = _nombreEmpresa;

            param[1] = new SqlParameter("@noTelefono", SqlDbType.NVarChar);
            param[1].Value = _noTelefono;

            param[2] = new SqlParameter("@NoRuc", SqlDbType.NVarChar);
            param[2].Value = _noRuc;

            param[3] = new SqlParameter("@correo", SqlDbType.NVarChar);
            param[3].Value = _correo;

            param[4] = new SqlParameter("@Direccion", SqlDbType.NVarChar);
            param[4].Value = _direccion;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Insertar_Proveedor";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }

        //PROCEDIMIENTO DE INSERTAR
        public void Actualizar_Proveedor()
        {

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[6];

            param[0] = new SqlParameter("@idProveedor", SqlDbType.Int);
            param[0].Value = _idProveedor;

            param[1] = new SqlParameter("@nombreEmpresa", SqlDbType.NVarChar);
            param[1].Value = _nombreEmpresa;

            param[2] = new SqlParameter("@noTelefono", SqlDbType.NVarChar);
            param[2].Value = _noTelefono;

            param[3] = new SqlParameter("@NoRuc", SqlDbType.NVarChar);
            param[3].Value = _noRuc;

            param[4] = new SqlParameter("@correo", SqlDbType.NVarChar);
            param[4].Value = _correo;

            param[5] = new SqlParameter("@Direccion", SqlDbType.NVarChar);
            param[5].Value = _direccion;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Actualizar_Proveedor";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }
    }
}
