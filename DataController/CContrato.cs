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
    public class CContrato
    {
        public Conexion conexion;

        public CContrato(Conexion conexion)
        {
            this.conexion = conexion;   

        }
        public string PrecioServicioContrato(String filtro)
        {
            DataTable dtResultado = new DataTable("BuscarCliente");




            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "Mostrar_PrecioServicio";
            sqlCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter filtroDato = new SqlParameter();
            filtroDato.ParameterName = "@nombre";
            filtroDato.SqlDbType = SqlDbType.NVarChar;
            filtroDato.Size = 100;
            filtroDato.Value = filtro;

            sqlCommand.Parameters.Add(filtroDato);

            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

            sqlData.Fill(dtResultado);


            return dtResultado.Rows[0]["Monto"].ToString();
        }
        public void AgregarContrato(int year, int totaCuotas, float vNominal, float VCuota, string Observaciones, int idFirma, int idAgencia, int tasaCambio ,int idVendedor, string modalidad)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[10];
            //1
            param[0] = new SqlParameter("@year", SqlDbType.Int);
            param[0].Value = year;
            //2
            param[1] = new SqlParameter("@TotalCuotas", SqlDbType.Int);
            param[1].Value = totaCuotas;
            //3
            param[2] = new SqlParameter("@VNominal", SqlDbType.Float);
            param[2].Value = vNominal;
            //4
            param[3] = new SqlParameter("@VCuota", SqlDbType.Float);
            param[3].Value = VCuota;
            //5
            param[4] = new SqlParameter("@Observaciones", SqlDbType.NVarChar);
            param[4].Value = Observaciones;
            //6
            param[5] = new SqlParameter("@idFirma", SqlDbType.Int);
            param[5].Value = idFirma;
            //7
            param[6] = new SqlParameter("@idAgencia", SqlDbType.Int);
            param[6].Value = idAgencia;
            //8
            param[7] = new SqlParameter("@idTasa", SqlDbType.Int);
            param[7].Value = tasaCambio;
            //9
            param[8] = new SqlParameter("@idVendedor", SqlDbType.Int);
            param[8].Value = idVendedor;
            //10
            param[9] = new SqlParameter("@Modalidad", SqlDbType.NVarChar);
            param[9].Value = modalidad;
           
       
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertarContrato";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Contrato agregado correctamente", "Agregado Correctamente");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void AgregarContratoProforma(int year, int totaCuotas, float vNominal, float VCuota, string Observaciones, int idFirma, int tasaCambio, int idVendedor, string modalidad)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[9];
            //1
            param[0] = new SqlParameter("@year", SqlDbType.Int);
            param[0].Value = year;
            //2
            param[1] = new SqlParameter("@TotalCuotas", SqlDbType.Int);
            param[1].Value = totaCuotas;
            //3
            param[2] = new SqlParameter("@VNominal", SqlDbType.Float);
            param[2].Value = vNominal;
            //4
            param[3] = new SqlParameter("@VCuota", SqlDbType.Float);
            param[3].Value = VCuota;
            //5
            param[4] = new SqlParameter("@Observaciones", SqlDbType.NVarChar);
            param[4].Value = Observaciones;
            //6
            param[5] = new SqlParameter("@idFirma", SqlDbType.Int);
            param[5].Value = idFirma;
            //7
       
            param[6] = new SqlParameter("@idTasa", SqlDbType.Int);
            param[6].Value = tasaCambio;
            //9
            param[7] = new SqlParameter("@idVendedor", SqlDbType.Int);
            param[7].Value = idVendedor;
            //10
            param[8] = new SqlParameter("@Modalidad", SqlDbType.NVarChar);
            param[8].Value = modalidad;


            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertarContratoProforma";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Contrato proforma agregado correctamente", "Agregado Correctamente");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public string MostrarIdFirma( string nombre)
        {
            DataTable dtResultado = new DataTable("Firma");


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "Ver_idFirma";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter filtroDato = new SqlParameter();
            filtroDato.ParameterName = "@nombre";
            filtroDato.SqlDbType = SqlDbType.NVarChar;
            filtroDato.Size = 200;
            filtroDato.Value = nombre;

            sqlCommand.Parameters.Add(filtroDato);

            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

            sqlData.Fill(dtResultado);


            return dtResultado.Rows[0]["firma"].ToString();
        }
        public DataTable MostrarContratos(string filtro,string tipo)
        {
            DataTable dtResultado = new DataTable("Contratos");
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameter[] param = new SqlParameter[2];
            //1
            param[0] = new SqlParameter("@filtro", SqlDbType.NVarChar);
            param[0].Value = filtro;
            //2
            param[1] = new SqlParameter("@estado", SqlDbType.NVarChar);
            param[1].Value = tipo;



            
            sqlCommand.Parameters.AddRange(param);
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "FiltrarContrato";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            

            

            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

            sqlData.Fill(dtResultado);


            return dtResultado;
        }
        public string MostrarIdAtaud(string nombre)
        {
            DataTable dtResultado = new DataTable("Ataud");


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "BuscarAtaud";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter filtroDato = new SqlParameter();
            filtroDato.ParameterName = "@nombre";
            filtroDato.SqlDbType = SqlDbType.NVarChar;
            filtroDato.Size = 100;
            filtroDato.Value = nombre;

            sqlCommand.Parameters.Add(filtroDato);

            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

            sqlData.Fill(dtResultado);


            return dtResultado.Rows[0]["IdEstandar"].ToString();
        }
        public string MostrarIdContrato()
        {
            DataTable dtResultado = new DataTable("Contrato");


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "UltimoContrato";
            sqlCommand.CommandType = CommandType.StoredProcedure;

       

            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

            sqlData.Fill(dtResultado);


            return dtResultado.Rows[0]["id"].ToString();
        }
        public string MostrarIdGencia(string nombre)
        {
            DataTable dtResultado = new DataTable("Firma");


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "Ver_idAgencia";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter filtroDato = new SqlParameter();
            filtroDato.ParameterName = "@nombre";
            filtroDato.SqlDbType = SqlDbType.NVarChar;
            filtroDato.Size = 200;
            filtroDato.Value = nombre;

            sqlCommand.Parameters.Add(filtroDato);

            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

            sqlData.Fill(dtResultado);


            return dtResultado.Rows[0]["agencia"].ToString();
        }
        public void AgregarBeneficiario(
            string pNombre, 
            string sNombre, 
            string pApellido, 
            string sApellido, 
            string fechaNac,
            string observaciones, 
            string sexo, 
            string Direccion, 
            string cedula,
            int idContrato, 
            string idDepartamento,
            int idAtaud
            )
        {


            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[12];
            //1
            param[0] = new SqlParameter("@Pnombre", SqlDbType.NVarChar);
            param[0].Value = pNombre;
            //2
            param[1] = new SqlParameter("@Snombre", SqlDbType.NVarChar);
            param[1].Value = sNombre;
            //3
            param[2] = new SqlParameter("@Papellido", SqlDbType.NVarChar);
            param[2].Value = pApellido;
            //4
            param[3] = new SqlParameter("@Sapellido", SqlDbType.NVarChar);
            param[3].Value = sApellido;
            //5
            param[4] = new SqlParameter("@FechaNac", SqlDbType.Date);
            param[4].Value = fechaNac;
            //6
            param[5] = new SqlParameter("@Observaciones", SqlDbType.NVarChar);
            param[5].Value = observaciones;
            //7
            param[6] = new SqlParameter("@Sexo", SqlDbType.NVarChar);
            param[6].Value = sexo;
            //8
            param[7] = new SqlParameter("@Direccion", SqlDbType.NVarChar);
            param[7].Value = Direccion;
            //9
            param[8] = new SqlParameter("@Cedula", SqlDbType.NVarChar);
            param[8].Value =cedula;
            
           
            param[9] = new SqlParameter("@IdContrato", SqlDbType.Int);
            param[9].Value = idContrato;
            
            param[10] = new SqlParameter("@IdDepartamento", SqlDbType.NVarChar);
            param[10].Value = idDepartamento;

            param[11] = new SqlParameter("@IdAtaud", SqlDbType.Int);
            param[11].Value = idAtaud;


            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insertarBeneficiarios";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();

                
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }




        }
        public void AgregarBeneficiarioProforma(
           string pNombre,
           string sNombre,
           string pApellido,
           string sApellido,
           string observaciones,
           string sexo,
           string Direccion,
           string cedula,
           int idContrato,
           int idDepartamento,
           int idAtaud
           )
        {


            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[11];
            //1
            param[0] = new SqlParameter("@Pnombre", SqlDbType.NVarChar);
            param[0].Value = pNombre;
            //2
            param[1] = new SqlParameter("@Snombre", SqlDbType.NVarChar);
            param[1].Value = sNombre;
            //3
            param[2] = new SqlParameter("@Papellido", SqlDbType.NVarChar);
            param[2].Value = pApellido;
            //4
            param[3] = new SqlParameter("@Sapellido", SqlDbType.NVarChar);
            param[3].Value = sApellido;
            //5
            //6
            param[4] = new SqlParameter("@Observaciones", SqlDbType.NVarChar);
            param[4].Value = observaciones;
            //7
            param[5] = new SqlParameter("@Sexo", SqlDbType.NVarChar);
            param[5].Value = sexo;
            //8
            param[6] = new SqlParameter("@Direccion", SqlDbType.NVarChar);
            param[6].Value = Direccion;
            //9
            param[7] = new SqlParameter("@Cedula", SqlDbType.NVarChar);
            param[7].Value = cedula;


            param[8] = new SqlParameter("@IdContrato", SqlDbType.Int);
            param[8].Value = idContrato;

            param[9] = new SqlParameter("@IdDepartamento", SqlDbType.Int);
            param[9].Value = idDepartamento;

            param[10] = new SqlParameter("@IdAtaud", SqlDbType.Int);
            param[10].Value = idAtaud;


            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insertarBeneficiariosProforma";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }




        }

        public void AgregarClienteContrato( 
           int idCliente,
           int idContrato
           )
        {


            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[2];
            //1
            param[0] = new SqlParameter("@idCliente", SqlDbType.Int);
            param[0].Value = idCliente;
            //2
            param[1] = new SqlParameter("@idContrato", SqlDbType.Int);
            param[1].Value = idContrato;

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertarClienteContrato";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


    }
}
