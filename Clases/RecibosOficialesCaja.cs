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
    public class RecibosOficialesCaja
    {

        //Variable de conexion

        public Conexion conexion;
        public RecibosOficialesCaja(Conexion conexion)
        {
            //Inicializacion de las variables

            this.conexion = conexion;   
        }

        //Mostrar conceptos para el autocompletado
        public DataTable Mostrar_Conceptos()
        {
            DataTable dtResultado = new DataTable("Concepto");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

           

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_AutoCompletado_Concepto";
            cmd.Connection = conexion.connect;
  

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public AutoCompleteStringCollection AutoCompletarConceptos()
        {
            DataTable dt = Mostrar_Conceptos();

            AutoCompleteStringCollection resultado = new AutoCompleteStringCollection();

            foreach(DataRow row in dt.Rows)
            {
                resultado.Add(Convert.ToString(row["Descripcion"]));
            }

            return resultado;
        }

        //Mostrar conceptos para el autocompletado de clientes
        public DataTable Mostrar_Clientes()
        {
            DataTable dtResultado = new DataTable("Clientes");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();



            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Nuevo_AutoCompletar_Clientes";
            cmd.Connection = conexion.connect;


            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public AutoCompleteStringCollection AutoCompletarRecibimosDe()
        {
            DataTable dt = Mostrar_Clientes();

            AutoCompleteStringCollection resultado = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                resultado.Add(Convert.ToString(row["nombres"]));
            }

            return resultado;
        }

        //Mostrar para el consecutivo de los recibos
        public string Caja_Consecutivo()
        {
            DataTable dtResultado = new DataTable("Concepto");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();



            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CAJA_Mostrar_NoFactura";
            cmd.Connection = conexion.connect;


            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado.Rows[0][0].ToString();
        }
        //Verificar que el cliente insertado ya existe

        public void Caja_VerificarCliente(string Nombre)
        {
            DataTable dtResultado = new DataTable("Obte");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@nombre", SqlDbType.NVarChar);
            param[0].Value = Nombre;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CAJA_Revisar_Cliente";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);


            if (dtResultado.Rows.Count == 0)
            {
                
            }
            else
            {
                MessageBox.Show("Cliente agregado","Correcto");
            }


        }
        //Insertar el recibo oficial de caja

        public void Caja_ReciboOficial(
            int idCliente,
            float montoD,
            float montoC,
            float faltante,
            double retencion,
            string NoMinuta,
            string bancoMinuta,
            string bancoCheque,
            string noCheque,
            string tipoPago,
            string descripcion,
            string recibimos,
            string idReferencial,
            int idtasa,
            string usuario,
            double retencionDgi,
            string enletras,
            string concepto,
            float chequeDolar,
            float chequeCordoba,
            float minutadolar,
            float minutacordoba,
            double total)
        {
            DataTable dtResultado = new DataTable("Obte");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[23];

            param[0] = new SqlParameter("@IdCliente", SqlDbType.Int);
            param[0].Value = idCliente;

            param[1] = new SqlParameter("@MontoD", SqlDbType.Float);
            param[1].Value = montoD;

            param[2] = new SqlParameter("@MontoC", SqlDbType.Float);
            param[2].Value = montoC;

            param[3] = new SqlParameter("@faltanteF", SqlDbType.Float);
            param[3].Value = faltante;

            param[4] = new SqlParameter("@Retencion", SqlDbType.Float);
            param[4].Value = retencion;

            param[5] = new SqlParameter("@NoMinuta", SqlDbType.NVarChar);
            param[5].Value = NoMinuta;

            param[6] = new SqlParameter("@Banco1", SqlDbType.NVarChar);
            param[6].Value = bancoMinuta;

            param[7] = new SqlParameter("@Banco2", SqlDbType.NVarChar);
            param[7].Value = bancoCheque;

            param[8] = new SqlParameter("@NoCheque", SqlDbType.NVarChar);
            param[8].Value = noCheque;

            param[9] = new SqlParameter("@TipoPago", SqlDbType.NVarChar);
            param[9].Value = tipoPago;

            param[10] = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
            param[10].Value = descripcion;

            param[11] = new SqlParameter("@Recibimos", SqlDbType.NVarChar);
            param[11].Value = recibimos;

            param[12] = new SqlParameter("@idReferencial", SqlDbType.NVarChar);
            param[12].Value = idReferencial;

            param[13] = new SqlParameter("@idTasa", SqlDbType.Int);
            param[13].Value = idtasa;

            param[14] = new SqlParameter("@usuario", SqlDbType.NVarChar);
            param[14].Value = usuario;

            param[15] = new SqlParameter("@Dgi", SqlDbType.Float);
            param[15].Value = retencionDgi;

            param[16] = new SqlParameter("@Enletras", SqlDbType.NVarChar);
            param[16].Value = enletras;

            param[17] = new SqlParameter("@concepto", SqlDbType.NVarChar);
            param[17].Value =concepto;

            //Prametros para lo nuevo en montos

            //Cheque

            param[18] = new SqlParameter("@CCordoba", SqlDbType.NVarChar);
            param[18].Value = chequeCordoba;

            param[19] = new SqlParameter("@CDolar", SqlDbType.NVarChar);
            param[19].Value = chequeDolar;

            //Minuta
            param[20] = new SqlParameter("@MCordoba", SqlDbType.NVarChar);
            param[20].Value = minutacordoba;

            param[21] = new SqlParameter("@MDolar", SqlDbType.NVarChar);
            param[21].Value = minutadolar;

            param[22] = new SqlParameter("@total", SqlDbType.NVarChar);
            param[22].Value = total;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Caja_Insertar_ReciboOficial";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            

            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("Recibo no insertado ", "Error");
            }
            else
            {
                MessageBox.Show("Recibo oficial agregado con exito", "Correcto");
            }


        }

        public int Caja_ObtenerCliente(string Nombre)
        {
            DataTable dtResultado = new DataTable("Obte");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@nombre", SqlDbType.NVarChar);
            param[0].Value = Nombre;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Caja_IdNombre";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);


            return int.Parse( dtResultado.Rows[0][0].ToString());


        }


        public DataTable Caja_Historial(string filtro)
        {
            DataTable dtResultado = new DataTable("Concepto");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@filtro", SqlDbType.NVarChar);
            param[0].Value = filtro;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Caja_ListarRecibos";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public void Caja_CambiarEstado(int id)
        {
            DataTable dtResultado = new DataTable("Concepto");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@idRecibo", SqlDbType.Int);
            param[0].Value = id;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Caja_Anular";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }

        public DataTable Caja_InfoGeneral(int id)
        {
            DataTable dtResultado = new DataTable("Concepto");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Caja_Actualizacion_InfoGeneral";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public DataTable Caja_OtrosPagos(int id)
        {
            DataTable dtResultado = new DataTable("Concepto");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Caja_OtrosPagos";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public DataTable Caja_InfoPago(int id)
        {
            DataTable dtResultado = new DataTable("Concepto");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Caja_Actualizacion_Pago";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public DataTable Caja_Cliente(int id)
        {
            DataTable dtResultado = new DataTable("Concepto");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Caja_Actualizacion_Cliente";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public void Caja_ReciboOficialActualizacion(
           int idCliente,
           float montoD,
           float montoC,
           float faltante,
           double retencion,
           string NoMinuta,
           string bancoMinuta,
           string bancoCheque,
           string noCheque,
           string tipoPago,
           string descripcion,
           string recibimos,
           string idReferencial,
           int idtasa,
           string usuario,
           double retencionDgi,
           string enletras,
           string concepto,
           int Recibo,
           float chequeDolar,
            float chequeCordoba,
            float minutadolar,
            float minutacordoba,
            double total)
        {
            DataTable dtResultado = new DataTable("Obte");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[24];

            param[0] = new SqlParameter("@IdCliente", SqlDbType.Int);
            param[0].Value = idCliente;

            param[1] = new SqlParameter("@MontoD", SqlDbType.Float);
            param[1].Value = montoD;

            param[2] = new SqlParameter("@MontoC", SqlDbType.Float);
            param[2].Value = montoC;

            param[3] = new SqlParameter("@faltanteF", SqlDbType.Float);
            param[3].Value = faltante;

            param[4] = new SqlParameter("@Retencion", SqlDbType.Float);
            param[4].Value = retencion;

            param[5] = new SqlParameter("@NoMinuta", SqlDbType.NVarChar);
            param[5].Value = NoMinuta;

            param[6] = new SqlParameter("@Banco1", SqlDbType.NVarChar);
            param[6].Value = bancoMinuta;

            param[7] = new SqlParameter("@Banco2", SqlDbType.NVarChar);
            param[7].Value = bancoCheque;

            param[8] = new SqlParameter("@NoCheque", SqlDbType.NVarChar);
            param[8].Value = noCheque;

            param[9] = new SqlParameter("@TipoPago", SqlDbType.NVarChar);
            param[9].Value = tipoPago;

            param[10] = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
            param[10].Value = descripcion;

            param[11] = new SqlParameter("@Recibimos", SqlDbType.NVarChar);
            param[11].Value = recibimos;

            param[12] = new SqlParameter("@idReferencial", SqlDbType.NVarChar);
            param[12].Value = idReferencial;

            param[13] = new SqlParameter("@idTasa", SqlDbType.Int);
            param[13].Value = idtasa;

            param[14] = new SqlParameter("@usuario", SqlDbType.NVarChar);
            param[14].Value = usuario;

            param[15] = new SqlParameter("@Dgi", SqlDbType.Float);
            param[15].Value = retencionDgi;

            param[16] = new SqlParameter("@Enletras", SqlDbType.NVarChar);
            param[16].Value = enletras;

            param[17] = new SqlParameter("@concepto", SqlDbType.NVarChar);
            param[17].Value = concepto;

            param[18] = new SqlParameter("@idRecibo", SqlDbType.Int);
            param[18].Value = Recibo;

            //Prametros para lo nuevo en montos

            //Cheque

            param[19] = new SqlParameter("@CCordoba", SqlDbType.NVarChar);
            param[19].Value = chequeCordoba;

            param[20] = new SqlParameter("@CDolar", SqlDbType.NVarChar);
            param[20].Value = chequeDolar;

            //Minuta
            param[21] = new SqlParameter("@MCordoba", SqlDbType.NVarChar);
            param[21].Value = minutacordoba;

            param[22] = new SqlParameter("@MDolar", SqlDbType.NVarChar);
            param[22].Value = minutadolar;

            param[23] = new SqlParameter("@total", SqlDbType.NVarChar);
            param[23].Value = total;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Caja_Actualizar_ReciboOficial";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);



            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("Recibo no insertado ", "Error");
            }
            else
            {
                MessageBox.Show("Recibo oficial actualizado con exito", "Correcto");
            }


        }

        public void Caja_VerificarConcepto(string concepto)
        {
            DataTable dtResultado = new DataTable("Obte");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@entrada", SqlDbType.NVarChar);
            param[0].Value = concepto;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Caja_Concepto";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);


            if (dtResultado.Rows.Count == 0)
            {

            }
            else
            {
                MessageBox.Show("Concepto nuevo agregado", "Correcto");
            }


        }
    }
}
