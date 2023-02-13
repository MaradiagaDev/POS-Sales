using NeoCobranza.Clases;
using NeoCobranza.Data;
using NeoCobranza.Paneles;
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
    public partial class PnlRetirado : Form
    {
        private Conexion conexion;
        private Contrato contrato;
        public PnlRetirado(Conexion conexion)
        {
            InitializeComponent();

            //Se pasa el owner
            PnlPrincipal pnlPrincipal = Owner as PnlPrincipal;

            this.conexion = conexion;

            this.contrato = new Contrato(conexion);

            dgvStock.DataSource = contrato.Contrato_Listar_Retirados(txtFiltro.Texts);

            //estilo
            dgvStock.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvStock.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);

            //Tooltip

            this.toolTip1.SetToolTip(this.txtFiltro,"Doble click para ver la informacion general del contrato");
        }

        private void txtFiltro__TextChanged(object sender, EventArgs e)
        {
            dgvStock.DataSource = contrato.Contrato_Listar_Retirados(txtFiltro.Texts);
        }

        private void PnlRetirado_Load(object sender, EventArgs e)
        {
            this.toolTip1.SetToolTip(this.txtFiltro, "Doble click para ver la informacion general del contrato");
        }

        private void dgvStock_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            //Verificacion de que haya una fila seleccionada

            if(dgvStock.Rows.Count == 0)
            {
                MessageBox.Show("No hay fila seleccionada","Error");
                return;
            }

            PnlGeneralContrato pnlGeneral = new PnlGeneralContrato(conexion, dgvStock.SelectedRows[0].Cells[0].Value.ToString());

            PnlPrincipal pnlPrincipal = Owner as PnlPrincipal;
            pnlGeneral.TopLevel = false;
            pnlGeneral.Dock = DockStyle.Fill;
            pnlPrincipal.PnlCentral.Controls.Add(pnlGeneral);
            pnlPrincipal.Tag = pnlGeneral;



            pnlGeneral.Show();

            this.Close();
        }

        private void txtFiltroId__TextChanged(object sender, EventArgs e)
        {
            //Comprobaciones
            if(txtFiltroId.Texts == "")
            {
                return;
            }
            int prueba;
            if(int.TryParse(txtFiltroId.Texts,out prueba) == false)
            {
                return;
            }

            dgvStock.DataSource = contrato.Contrato_Listar_Retirados_ID(int.Parse(txtFiltroId.Texts));
        }

        private void txtFiltro__TextChanged_1(object sender, EventArgs e)
        {
            dgvStock.DataSource = contrato.Contrato_Listar_Retirados(txtFiltro.Texts);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Verificaciones
            if(txtContratoIncial.Text == "")
            {
                
                txtContratoIncial.ForeColor = Color.Black;
                txtEstado.Text = "x";
                txtSaldoActual.Text = "x";

                txtContratoFinal.Text = "";
                txtContratoFinal.ForeColor = Color.Black;
                txtContratoFinal.Enabled = false;

                return;
            }
            int prueba;

            if(int.TryParse(txtContratoIncial.Text,out prueba)== false)
            {
                txtContratoIncial.ForeColor = Color.Red;
                txtEstado.Text = "Error en los digitos";
                txtSaldoActual.Text = "x";

                txtContratoFinal.Text = "";
                txtContratoFinal.ForeColor = Color.Black;
                txtContratoFinal.Enabled = false;

                return;


            }



             string mensaje = contrato.Contrato_Verificar_Traslado(int.Parse(txtContratoIncial.Text));

            if(mensaje == "Se puede retirar")
            {
                txtContratoIncial.ForeColor = Color.Green;
                txtContratoFinal.Enabled = true;
                txtEstado.Text = "Correcto";

                try
                {


                    txtSaldoActual.Text = contrato.Retiros_Valor_Contrato(int.Parse(txtContratoIncial.Text));
                }
                catch (Exception ex)
                {
                    txtSaldoActual.Text = "x";
                }

            }
            else if(mensaje == "No se puede retirar")
            {
                txtContratoIncial.ForeColor = Color.Red;
                txtEstado.Text = "No se puede trasladar";
                txtSaldoActual.Text = "x";

                txtContratoFinal.Text = "";
                txtContratoFinal.ForeColor = Color.Black;
                txtContratoFinal.Enabled = false;

            }
            else if(mensaje == "El contrato digitado no se encuentra en la base de datos")
            {
                txtContratoIncial.ForeColor = Color.Yellow;

                txtEstado.Text = "Contrato no encontrado";
                txtSaldoActual.Text = "x";

                txtContratoFinal.Text = "";
                txtContratoFinal.ForeColor = Color.Black;
                txtContratoFinal.Enabled = false;

            }
        }

        private void txtContratoFinal_TextChanged(object sender, EventArgs e)
        {

            //Verificaciones
            if (txtContratoFinal.Text == "")
            {

                txtContratoFinal.ForeColor = Color.Black;
                return;
            }
            int prueba;

            if (int.TryParse(txtContratoFinal.Text, out prueba) == false)
            {
                txtContratoFinal.ForeColor = Color.Red;
                txtEstado.Text = "Error en los digitos";
            
                return;
            }

            //Mensaje
            string mensaje = contrato.Contrato_Verificar_Traslado_Final(int.Parse(txtContratoFinal.Text));

            if (mensaje == "Se puede retirar")
            {
                txtContratoFinal.ForeColor = Color.Green;
                txtEstado.Text = "Todo listo para el traslado";

         

            }
            else if (mensaje == "No se puede retirar")
            {
                txtContratoFinal.ForeColor = Color.Red;
                txtEstado.Text = "No se puede trasladar al contrato final";
                

            }
            else if (mensaje == "El contrato digitado no se encuentra en la base de datos")
            {
                txtContratoFinal.ForeColor = Color.Yellow;

                txtEstado.Text = "Contrato final no encontrado";
                
            }
        }
    }
}
