using NeoCobranza.Clases;
using NeoCobranza.Data;
using NeoCobranza.DataController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles_Caja
{


    public partial class PnlReciboOficialCaja : Form
    {
        //Variable de conexion

        public Conexion conexion;

        //Variable de tasa cambio

        public CTasaCambio cTasa;

        //Variable utilizada para todos los procedimiento que tienen que ver con los recibos oficiales de caja

        public RecibosOficialesCaja recibosOficialesCaja;



        //Constructor de creacion
        public PnlReciboOficialCaja(Conexion conexion)
        {
            InitializeComponent();

            BtnActualizar.Enabled = false;
            //Inicializador

            this.conexion = conexion;

            cTasa = new CTasaCambio(conexion);



            //Llenar la tasa de cambio
            txtCambio.Text = cTasa.MostrarTasa();


            //Fecha
            txtFecha.Text= DateTime.UtcNow.ToString("MM/dd/yyyy");

            //Recibos oficiales

            recibosOficialesCaja = new RecibosOficialesCaja(conexion);


            //LLenar Conceptos
            cmbConcepto.DataSource = recibosOficialesCaja.Mostrar_Conceptos();

            cmbConcepto.DisplayMember = "Descripcion";
            cmbConcepto.ValueMember = "IdConcepto";

            //Autocompletado

            cmbConcepto.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbConcepto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbConcepto.AutoCompleteCustomSource = recibosOficialesCaja.AutoCompletarConceptos();

            //Autocompletado de clientes
            txtRecibimos.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtRecibimos.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtRecibimos.AutoCompleteCustomSource = recibosOficialesCaja.AutoCompletarRecibimosDe()
                ;

            txtACuentaDe.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtACuentaDe.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtACuentaDe.AutoCompleteCustomSource = recibosOficialesCaja.AutoCompletarRecibimosDe();

            ColocarConsecutivo();
            

        }
        public int idpublico;
        //Constructor de actualizacion
        public PnlReciboOficialCaja(Conexion conexion,int id)
        {
            InitializeComponent();
            //Variables a utilizar

            btnAgregar.Enabled = false;

            this.idpublico = id;

            this.conexion = conexion;

            cTasa = new CTasaCambio(conexion);

            recibosOficialesCaja = new RecibosOficialesCaja(conexion);
            //Informacion general

            lblConsecutivo.Text = id.ToString();

            txtFecha.Text = recibosOficialesCaja.Caja_InfoGeneral(id).Rows[0][1].ToString();
            txtCambio.Text = recibosOficialesCaja.Caja_InfoGeneral(id).Rows[0][0].ToString();

            txtFiscalia.Text = recibosOficialesCaja.Caja_InfoGeneral(id).Rows[0][2].ToString();

            txtIdReferencial.Text = recibosOficialesCaja.Caja_InfoGeneral(id).Rows[0][3].ToString();

            txtDescripcion.Text = recibosOficialesCaja.Caja_InfoGeneral(id).Rows[0][4].ToString();

            if(recibosOficialesCaja.Caja_InfoGeneral(id).Rows[0][5].ToString() == "" || recibosOficialesCaja.Caja_InfoGeneral(id).Rows[0][5].ToString()=="0" || recibosOficialesCaja.Caja_InfoGeneral(id).Rows[0][5].ToString() == null)
            {

            }
            else
            {
                rbtnRetencion1.Checked = true;

            }


            try
            {
                if (recibosOficialesCaja.Caja_InfoGeneral(id).Rows[0][6].ToString() == "" || recibosOficialesCaja.Caja_InfoGeneral(id).Rows[0][6].ToString() == "0" || recibosOficialesCaja.Caja_InfoGeneral(id).Rows[0][6].ToString() == null)
                {

                }
                else
                {
                    rbtnRetencion2.Checked = true;

                }
            }catch(Exception ex)
            {

            }

            //LLenado de info de pago

            txtSuma.Text = recibosOficialesCaja.Caja_InfoPago(id).Rows[0][0].ToString();
            txtDolares.Text = recibosOficialesCaja.Caja_InfoPago(id).Rows[0][1].ToString();


            txtNoCheque.Text = recibosOficialesCaja.Caja_InfoPago(id).Rows[0][2].ToString();

            txtNoReferencia.Text = recibosOficialesCaja.Caja_InfoPago(id).Rows[0][5].ToString();

            cmbConcepto.Text = recibosOficialesCaja.Caja_Cliente(id).Rows[0][2].ToString(); 

            cmbBancoCheque.Text = recibosOficialesCaja.Caja_InfoPago(id).Rows[0][4].ToString();

            cmbBancoMinulta.Text = recibosOficialesCaja.Caja_InfoPago(id).Rows[0][3].ToString();

            cmbConcepto.Text = recibosOficialesCaja.Caja_Cliente(id).Rows[0][2].ToString();

            txtAnterior.Text = "Anterior: "+recibosOficialesCaja.Caja_Cliente(id).Rows[0][2].ToString();

            //LLenado de la informacion de los cheques y las minutas

            txtCordobaCheque.Text = recibosOficialesCaja.Caja_OtrosPagos(id).Rows[0][0].ToString();
            txtDolarCheque.Text = recibosOficialesCaja.Caja_OtrosPagos(id).Rows[0][1].ToString();

            txtCordobaMinuta.Text = recibosOficialesCaja.Caja_OtrosPagos(id).Rows[0][2].ToString();
            txtDolarMinuta.Text = recibosOficialesCaja.Caja_OtrosPagos(id).Rows[0][3].ToString();
            //Informacion del cliente

            txtACuentaDe.Text= recibosOficialesCaja.Caja_Cliente(id).Rows[0][1].ToString();
            txtRecibimos.Text = recibosOficialesCaja.Caja_Cliente(id).Rows[0][0].ToString();

            //Auto completado-------------------------------------------------------------------

            //LLenar Conceptos
            cmbConcepto.DataSource = recibosOficialesCaja.Mostrar_Conceptos();

            cmbConcepto.DisplayMember = "Descripcion";
            cmbConcepto.ValueMember = "IdConcepto";

            //Autocompletado

            cmbConcepto.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbConcepto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbConcepto.AutoCompleteCustomSource = recibosOficialesCaja.AutoCompletarConceptos();

            //Autocompletado de clientes
            txtRecibimos.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtRecibimos.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtRecibimos.AutoCompleteCustomSource = recibosOficialesCaja.AutoCompletarRecibimosDe()
                ;

            txtACuentaDe.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtACuentaDe.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtACuentaDe.AutoCompleteCustomSource = recibosOficialesCaja.AutoCompletarRecibimosDe();


        }


        private void ColocarConsecutivo()
        {
            lblConsecutivo.Text = (int.Parse(recibosOficialesCaja.Caja_Consecutivo())+1).ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            EnLetras();
        }

        private void txtDolares_TextChanged(object sender, EventArgs e)
        {
            EnLetras();
        }

        private void txtSuma_KeyPress(object sender, KeyPressEventArgs e)
        {
           
             if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                
                e.Handled = true;
            }
            
        }

        private void txtDolares_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        
        }

        private void cmbConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
           
            //Verificaciones obligatorias
            Verificaciones();
            //Variables para calculo de las retenciones

            double retencion =0;
            double retencionDgi = 0;
            string tipoPago = "";

            //Calculo del total para la retencion
            double montoTotalCordoba = Math.Round(double.Parse(txtCordobaMinuta.Text) + double.Parse(txtCordobaCheque.Text) + double.Parse(txtSuma.Text) + ((double.Parse(cTasa.MostrarTasa()) * (double.Parse(txtDolares.Text)))) + ((double.Parse(cTasa.MostrarTasa()) * (double.Parse(txtDolarCheque.Text)))) + ((double.Parse(cTasa.MostrarTasa()) * (double.Parse(txtDolarMinuta.Text)))), 2);

            //Calcular la retencion
            if (rbtnRetencion1.Checked == true)
                retencion = Math.Round(montoTotalCordoba * 0.01,2);
            if (rbtnRetencion2.Checked == true)
                retencionDgi = Math.Round( montoTotalCordoba * 0.02,2);

            MessageBox.Show(montoTotalCordoba.ToString(),"MontoTotal");
            MessageBox.Show(retencion.ToString(), "Retencion");

            //Agregar cliente que  no existe

            recibosOficialesCaja.Caja_VerificarCliente(txtRecibimos.Text);
            recibosOficialesCaja.Caja_VerificarCliente(txtACuentaDe.Text);


            //Verificar el concepto
            recibosOficialesCaja.Caja_VerificarConcepto(cmbConcepto.Text);

            //Insertado del recibo de caja

            recibosOficialesCaja.Caja_ReciboOficial(recibosOficialesCaja.Caja_ObtenerCliente(txtRecibimos.Text),
                float.Parse(txtDolares.Text),
                float.Parse(txtSuma.Text),
                float.Parse(txtFiscalia.Text),
                retencion,
                txtNoReferencia.Text,
                cmbBancoMinulta.Text,
                cmbBancoCheque.Text,
                txtNoCheque.Text,
                tipoPago,
                txtDescripcion.Text,
                txtACuentaDe.Text,
                txtIdReferencial.Text,
                int.Parse(cTasa.MostrarIdTasa()),
                conexion.usuario,
                retencionDgi,
                label6.Text,
                cmbConcepto.Text, 
                float.Parse(txtDolarCheque.Text),
                float.Parse(txtCordobaCheque.Text),
                float.Parse(txtDolarMinuta.Text),
                float.Parse(txtCordobaMinuta.Text),
                montoTotalCordoba
                ) ;

            this.Close();
        }

        private void Verificaciones()
        {
            double prueba;
            if (txtDolarMinuta.Text == "" || double.TryParse(txtDolarMinuta.Text, out prueba) == false)
            {
                txtDolarMinuta.Text = "0";
            }

            if (txtCordobaMinuta.Text == "" || double.TryParse(txtCordobaMinuta.Text, out prueba) == false)
            {
                txtCordobaMinuta.Text = "0";
            }

            if (txtDolarCheque.Text == "" || double.TryParse(txtDolarCheque.Text, out prueba) == false)
            {
                txtDolarCheque.Text = "0";
            }

            if (txtCordobaCheque.Text == "" || double.TryParse(txtCordobaCheque.Text, out prueba) == false)
            {
                txtCordobaCheque.Text = "0";
            }

            //Ahora el del normal

            if (txtDolares.Text == "" || double.TryParse(txtDolares.Text, out prueba) == false)
            {
                txtDolares.Text = "0";
            }

            if (txtSuma.Text == "" || double.TryParse(txtSuma.Text, out prueba) == false)
            {
                txtDolares.Text = "0";
            }

            if (txtFiscalia.Text == "" || double.TryParse(txtFiscalia.Text, out prueba) == false)
            {
                txtFiscalia.Text = "0";
            }

            //


            if (cmbConcepto.Text == "")
            {
                MessageBox.Show("No ha digitado el concepto de ingresos", "Error");
                return;
            }
            else if (txtRecibimos.Text=="")
            {
                MessageBox.Show("No ha digitado de quien se recibe el dinero", "Error");
                return;

            }else if (txtACuentaDe.Text == "")
            {
                MessageBox.Show("No ha digitado a cuenta de quien se recibe le dinero", "Error");
                return;
            }
            else if(txtSuma.Text == "0" && txtDolares.Text == "0" && txtDolarCheque.Text =="0" && txtCordobaCheque.Text =="0" && txtDolarMinuta.Text == "0" && txtCordobaMinuta.Text =="0" )
            {
                MessageBox.Show("No se ha digitado ningun monto", "Error");
                return;
            }
             
            
        }

        private void txtFiscalia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }

        private void rbtnRetencion2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            

            //Verificaciones obligatorias
            Verificaciones();
            //Variables para calculo de las retenciones

            double retencion = 0;
            double retencionDgi = 0;
            string tipoPago = "";

            //Calculo del total para la retencion
            double montoTotalCordoba = Math.Round(double.Parse(txtCordobaMinuta.Text)+double.Parse(txtCordobaCheque.Text)+double.Parse(txtSuma.Text) + ((double.Parse(cTasa.MostrarTasa()) * (double.Parse(txtDolares.Text))))+ ((double.Parse(cTasa.MostrarTasa()) * (double.Parse(txtDolarCheque.Text))))+ ((double.Parse(cTasa.MostrarTasa()) * (double.Parse(txtDolarMinuta.Text)))), 2);

            //Calcular la retencion
            if (rbtnRetencion1.Checked == true)
                retencion = Math.Round(montoTotalCordoba * 0.01, 2);
            if (rbtnRetencion2.Checked == true)
                retencionDgi = Math.Round(montoTotalCordoba * 0.02, 2);

            MessageBox.Show(montoTotalCordoba.ToString(), "MontoTotal");
            MessageBox.Show(retencion.ToString(), "Retencion");

            //Agregar cliente que  no existe

            recibosOficialesCaja.Caja_VerificarCliente(txtRecibimos.Text);
            recibosOficialesCaja.Caja_VerificarCliente(txtACuentaDe.Text);

            recibosOficialesCaja.Caja_VerificarConcepto(cmbConcepto.Text);
            //Insertado del recibo de caja

            recibosOficialesCaja.Caja_ReciboOficialActualizacion(recibosOficialesCaja.Caja_ObtenerCliente(txtRecibimos.Text),
                float.Parse(txtDolares.Text),
                float.Parse(txtSuma.Text),
                float.Parse(txtFiscalia.Text),
                retencion,
                txtNoReferencia.Text,
                cmbBancoMinulta.Text,
                cmbBancoCheque.Text,
                txtNoCheque.Text,
                tipoPago,
                txtDescripcion.Text,
                txtACuentaDe.Text,
                txtIdReferencial.Text,
                int.Parse(cTasa.MostrarIdTasa()),
                conexion.usuario,
                retencionDgi,
                label6.Text,
                cmbConcepto.Text,
                idpublico,
                  float.Parse(txtDolarCheque.Text),
                float.Parse(txtCordobaCheque.Text),
                float.Parse(txtDolarMinuta.Text),
                float.Parse(txtCordobaMinuta.Text),
                montoTotalCordoba);
            this.Close();
        }

        private void txtCordobaMinuta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }

        private void txtDolarMinuta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }

        private void txtCordobaCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }

        private void txtDolarCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            EnLetras();

        }

        private void EnLetras()
        {
            double monto, prueba = 0;
            NumerosLetras numeros = new NumerosLetras();
            //Verificaciones

            if (double.TryParse(txtSuma.Text, out prueba) == false || double.TryParse(txtDolares.Text, out prueba) == false || double.TryParse(txtCordobaCheque.Text, out prueba) == false || double.TryParse(txtDolarCheque.Text, out prueba) == false || double.TryParse(txtCordobaMinuta.Text, out prueba) == false || double.TryParse(txtDolarMinuta.Text, out prueba) == false)
            {
                
                return;
            }

            monto = double.Parse(txtSuma.Text) + double.Parse(txtCordobaMinuta.Text) + double.Parse(txtCordobaCheque.Text);

            monto = monto + ((double.Parse(txtDolares.Text) + double.Parse(txtDolarCheque.Text) + double.Parse(txtDolarMinuta.Text)) * double.Parse(txtCambio.Text));

            label6.Text = numeros.enletras(monto.ToString());
        }

        private void txtCordobaCheque_TextChanged(object sender, EventArgs e)
        {
            EnLetras();
        }

        private void txtDolarCheque_TextChanged(object sender, EventArgs e)
        {
            EnLetras();
        }

        private void txtCordobaMinuta_TextChanged(object sender, EventArgs e)
        {
            EnLetras();
        }

        private void txtDolarMinuta_TextChanged(object sender, EventArgs e)
        {
            EnLetras();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
