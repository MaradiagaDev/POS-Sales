using NeoCobranza.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace NeoCobranza.Clases_de_Contrato
{
    public class ProformaContrato
    {
        //Variables para las actualizaciones o consultas

        private int _idProforma;

        //Variables propias de la clase
        private int _year;
        private int _totaCuotas;
        private float _vNominal;
        private float _VCuota;
        private string _Observaciones;
        private int _idFirma;
        private int _tasaCambio;
        private int _idVendedor;
        private string _modalidad;
        //Conexion
        private Conexion _conexion;


        //Constructor Actualizacion u obtencion de datos
        public ProformaContrato(Conexion conexion)
        {
            
            this._conexion = conexion;
        }


        //Creacion
        public ProformaContrato(int year,
            int totaCuotas,
            float vNominal,
            float VCuota, 
            string Observaciones,
            int idFirma,
            int tasaCambio,
            int idVendedor,
            string modalidad,
            Conexion conexion)
        {

            this._year = year;
            this._totaCuotas = totaCuotas;
            this._vNominal = vNominal;
            this._VCuota = VCuota;
            this._Observaciones = Observaciones;
            this._idFirma = idFirma;
            this._tasaCambio = tasaCambio;
            this._idVendedor = idVendedor;
            this._modalidad = modalidad;

            this._conexion = conexion;

        }
       
        public void Insertar_Detalles(int IdAtaud, int cantidad, int idproforma)
        {

            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@IdContrato", SqlDbType.Int);
            param[0].Value = idproforma;
            param[1] = new SqlParameter("@IdAtaud", SqlDbType.Int);
            param[1].Value = IdAtaud;
            param[2] = new SqlParameter("@Cantidad", SqlDbType.Int);
            param[2].Value = cantidad;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Insertar_Detalles_Contratos";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();



            

        }

        // Funciones que se pueden realizar con una proforma de contrato
        public void Actualizar_Proforma(int year,int total,float vnominal,float vCuotas,string observaciones, string modalidad,int id)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[7];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@year", SqlDbType.Int);
            param[1].Value = year;
            
            param[2] = new SqlParameter("@TotalCuotas", SqlDbType.Int);
            param[2].Value = total;
            
            param[3] = new SqlParameter("@VNominal", SqlDbType.Float);
            param[3].Value = vnominal;
            
            param[4] = new SqlParameter("@VCuota", SqlDbType.Float);
            param[4].Value = vCuotas;
           
            param[5] = new SqlParameter("@Observaciones", SqlDbType.NVarChar);
            param[5].Value = observaciones;

            param[6] = new SqlParameter("@Modalidad", SqlDbType.NVarChar);
            param[6].Value = modalidad;


            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Actualizar_Proforma_Contrato";
                cmd.Connection = _conexion.connect;
                cmd.Parameters.AddRange(param);
                int i =cmd.ExecuteNonQuery();

                if (i == 0)
                {
                    MessageBox.Show("Sin cambios", "Actualizado Correctamente");
                }
                else
                {
                    MessageBox.Show("Actualizacion realizada", "Actualizado Correctamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Obtencion de datos
        public DataTable Obtener_Servicios(string tipo)
        {
            if (_idProforma == null)
            {
                MessageBox.Show("El ID no ha sido insertado");
                return null;
            }


            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = _idProforma;
            param[1] = new SqlParameter("@tipo", SqlDbType.NVarChar);
            param[1].Value = tipo;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Obtener_Servicios_Contrato";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);




            return dtResultado;


        }
        public void AgregarProforma()
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[9];
            //1
            param[0] = new SqlParameter("@year", SqlDbType.Int);
            param[0].Value = _year;
            //2
            param[1] = new SqlParameter("@TotalCuotas", SqlDbType.Int);
            param[1].Value = _totaCuotas;
            //3
            param[2] = new SqlParameter("@VNominal", SqlDbType.Float);
            param[2].Value = _vNominal;
            //4
            param[3] = new SqlParameter("@VCuota", SqlDbType.Float);
            param[3].Value = _VCuota;
            //5
            param[4] = new SqlParameter("@Observaciones", SqlDbType.NVarChar);
            param[4].Value = _Observaciones;
            //6
            param[5] = new SqlParameter("@idFirma", SqlDbType.Int);
            param[5].Value = _idFirma;
            //7

            param[6] = new SqlParameter("@idTasa", SqlDbType.Int);
            param[6].Value = _tasaCambio;
            //9
            param[7] = new SqlParameter("@idVendedor", SqlDbType.Int);
            param[7].Value = _idVendedor;
            //10
            param[8] = new SqlParameter("@Modalidad", SqlDbType.NVarChar);
            param[8].Value = _modalidad;


            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertarContratoProforma";
                cmd.Connection = _conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Contrato proforma agregado correctamente", "Agregado Correctamente");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Obtencion de datos
        
        public string Obtener_Descripcion(int idproforma)
        {

            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = idproforma;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Proforma_Descripcion_Cancelacion";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);




            return dtResultado.Rows[0][0].ToString();


        }
        public DataTable Obtener_Cliente()
        {
            if (_idProforma == null)
            {
                MessageBox.Show("El ID no ha sido insertado");
                return null;
            }


            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = _idProforma;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Obtener_Cliente_Contrato";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);




            return dtResultado;


        }

        public DataTable Obtener_Vendedor ()
        {
            if (_idProforma == null)
            {
                MessageBox.Show("El ID no ha sido insertado");
                return null;
            }


            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = _idProforma;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Obtener_Vendedor_Contrato";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);




            return dtResultado;
        }

        public DataTable Obtener_cancelacion()
        {
            if (_idProforma == null)
            {
                MessageBox.Show("El ID no ha sido insertado");
                return null;
            }


            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = _idProforma;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Obtener_year_Contrato";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);




            return dtResultado;
        }

        //NUEVO ORDEN PARA LA CLASE DE PROFORMA CONTRATO
        public DataTable Listar_Servicios()
        {

            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

        

            


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_CmbServicios_Estandates";
            cmd.Connection = _conexion.connect;
          
            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);




            return dtResultado;

        }
        public DataTable Obtener_Datos_Contrato(int id)
        {
           

            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
         

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_Informe_ContratoProforma";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);




            return dtResultado;


        }
        public DataTable Listar_Ataudes()
        {

            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_CmbAtaudes_Estandates";
            cmd.Connection = _conexion.connect;
            

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);




            return dtResultado;

        }

        public float Obtener_Precio_Nombre(string nombre)
        {
        
            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@nombre", SqlDbType.NVarChar);
            param[0].Value = nombre;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_MontoContrato_Categoria";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);



            return float.Parse(dtResultado.Rows[0]["MontoContrato"].ToString());
        }
        public int Obtener_UltimoID_Contrato()
        {

            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_UltimoId_Contrato";
            cmd.Connection = _conexion.connect;
            

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);



            return int.Parse(dtResultado.Rows[0]["IDContratoReal"].ToString());
        }

        public void BorrarDetalles(int id)
        {
            

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_BorrarDetalles_ProformaCont";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);


            cmd.ExecuteNonQuery();
        }

        //PROCEDIMIENTO DE AGILIZACION
        public DataTable Obtener_Ataudes_Actualizacion(int idProforma)
        {

            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = idProforma;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Proforma_Selecccion_Ataudes";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);


            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public DataTable Obtener_Servicios_Actualizacion(int idProforma)
        {

            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = idProforma;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Proforma_Selecccion_Servicios";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);


            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public string Obtener_Nombre_Actualizacion(int idProforma)
        {

            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = idProforma;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Proforma_Selecccion_Cliente";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);


            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado.Rows[0][0].ToString();
        }
        public string Obtener_id_Actualizacion(int idProforma)
        {

            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = idProforma;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Proforma_Selecccion_Cliente";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);


            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado.Rows[0][1].ToString();
        }

        public string Obtener_nombreVendedor_Actualizacion(int idProforma)
        {

            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = idProforma;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Proforma_Selecccion_Vendedor";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);


            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado.Rows[0][0].ToString();
        }
        public string Obtener_IDVendedor_Actualizacion(int idProforma)
        {

            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = idProforma;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Proforma_Selecccion_Vendedor";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);


            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado.Rows[0][1].ToString();
        }

        public string Obtener_Modalidad_Actualizacion(int idProforma)
        {

            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = idProforma;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Proforma_Selecccion_Modalidad";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);


            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado.Rows[0][0].ToString();
        }

        public string Obtener_Cancelacion_Actualizacion(int idProforma)
        {

            DataTable dtResultado = new DataTable("Obtener_Servicios");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = idProforma;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Proforma_Selecccion_Cancelacion";
            cmd.Connection = _conexion.connect;
            cmd.Parameters.AddRange(param);


            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado.Rows[0][0].ToString();
        }
    }
}
