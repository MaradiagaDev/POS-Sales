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

namespace NeoCobranza.Paneles_Contrato
{
    public partial class PnlActualizarPago : Form
    {
        private Conexion conexion;
        private Contrato contrato;
        private int idpublico;
        private int idContrato;

        private string DolaresValor;
        private string noCuotasValor;
        
        public PnlActualizarPago(Conexion conexion,int idFactura,float montoDolar,int noCuotas,string observaciones, int idContrato)
        {
            InitializeComponent();

            this.contrato = new Contrato(conexion);
            this.conexion = conexion;
            this.idpublico = idFactura;
            this.idContrato = idContrato;

            txtRecibo.Text = idFactura.ToString();
            txtDolares.Text = montoDolar.ToString();
            txtCuotas.Text = noCuotas.ToString();
            txtObservaciones.Text = observaciones.ToString();

            DolaresValor = montoDolar.ToString();
            noCuotasValor = noCuotas.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            //Verficar que haya un monto o que sea valido
            if (txtCordobas.Text == "0" && txtDolares.Text == "0")
            {
                MessageBox.Show("No ha digitado ningun monto", "Error");
                return;

            }
            else if (txtCordobas.Text == "" && txtDolares.Text == "")
            {
                MessageBox.Show("No ha digitado ningun monto", "Error");
                return;

            }
            else if (txtCordobas.Text == "0" && txtDolares.Text == "")
            {
                MessageBox.Show("No ha digitado ningun monto", "Error");
                return;

            }
            else if (txtCordobas.Text == "" && txtDolares.Text == "0")
            {
                MessageBox.Show("No ha digitado ningun monto", "Error");
                return;

            }

            if (txtCordobas.Text == "")
            {
                txtCordobas.Text = "0";
            }
            if (txtDolares.Text == "")
            {
                txtDolares.Text = "0";
            }
            //Verificar que sea valido
            float prueba;
            if (float.TryParse(txtDolares.Text, out prueba) == false || float.TryParse(txtCordobas.Text, out prueba) == false)
            {
                MessageBox.Show("Los monton tienen un digito incorrecto", "Error");
                return;
            }

            if (txtCuotas.Text == "0" || txtCuotas.Text == "")
            {
                MessageBox.Show("Las cuotas no pueden ser 0", "Error");
                return;
            }

            //Actualizar la cuota
            CTasaCambio cTasa = new CTasaCambio(conexion);

            float cordoba, dolar;

            cordoba = float.Parse(txtCordobas.Text) + (float.Parse(cTasa.MostrarTasa()) * float.Parse(txtDolares.Text));
            dolar = float.Parse(txtDolares.Text) + (float.Parse(txtCordobas.Text) / float.Parse(cTasa.MostrarTasa()));

            contrato.Contrato_Insertar_Historial("Actualizacion de cuota","Id cuota: "+idpublico.ToString()+" Monto anterior : $ "+DolaresValor+" NoCuotas anterior: "+ noCuotasValor,conexion.usuario,idContrato);

            contrato.Contrato_Actualizar_Cuota_Existente(idpublico,cordoba,dolar,int.Parse(txtCuotas.Text),txtObservaciones.Text);

            //Actualizar los valores
            //Valores del controato
            contrato.Contrato_Actualizar_Valores(idpublico,idContrato, 0,dolar,cordoba);

            MessageBox.Show("Cuota actualizada con exito","Correcto");

            this.Close();

        }

        private void PnlActualizarPago_Load(object sender, EventArgs e)
        {

        }
    }
}
