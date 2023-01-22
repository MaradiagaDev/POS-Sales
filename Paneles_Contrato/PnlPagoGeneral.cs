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
    public partial class PnlPagoGeneral : Form
    {

        //Clase de conexion
        private Conexion conexion;
        private Contrato contrato;
        public PnlPagoGeneral(Conexion conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
            this.contrato = new Contrato(conexion);
            //estilo
            dgvStock.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvStock.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            //LLenado del data
            dgvStock.DataSource= contrato.Contrato_ListarContratosPagando(txtFiltro.Texts);
            Ccolor();
            //Buscar el ultimo contrato


            try
            {
                txtRecibo.Text = contrato.Contrato_ListarUltimaFactura(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][0].ToString();
            }
            catch (Exception)
            {

            }
        }
        private void Ccolor()
        {
            for (int i = 0; i < dgvStock.Rows.Count; i++)
            {
                if (dgvStock.Rows[i].Cells[3].Value.ToString() == "Correcto")
                {
                    dgvStock.Rows[i].DefaultCellStyle.BackColor = Color.YellowGreen;
                }
                else if(dgvStock.Rows[i].Cells[3].Value.ToString() == "Dia de cobro")
                {
                    dgvStock.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (dgvStock.Rows[i].Cells[3].Value.ToString() == "Mora")
                {
                    dgvStock.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }


            }
        }
        private void PnlPagoGeneral_Load(object sender, EventArgs e)
        {
            Ccolor();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            //Verficar que haya algo seleccionado en el data

            if (dgvStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado el contrato", "Error");
                return;
            }
            //Verificar que haya una cuota
            if (txtRecibo.Text == "x")
            {
                MessageBox.Show("El sistema no genero cuota", "Error");
                return;
            }
            
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

            CTasaCambio cTasa = new CTasaCambio(conexion);

            float cordoba, dolar;

            cordoba = float.Parse(txtCordobas.Text) + (float.Parse(cTasa.MostrarTasa()) * float.Parse(txtDolares.Text));
            dolar = float.Parse(txtDolares.Text) + (float.Parse(txtCordobas.Text) / float.Parse(cTasa.MostrarTasa()));

            //Valores del controato
            contrato.Contrato_Insertar_Valores(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()), dolar, 0);

            //Verificar si cancela el contrato
            contrato.Contrato_Cancelado(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()), dolar);

            //Actualizar la cuota con el nuevo monto
            contrato.Contrato_ActualizarCuota(int.Parse(txtRecibo.Text), cordoba, dolar, int.Parse(txtCuotas.Text), txtObservaciones.Text, int.Parse(dgvStock.SelectedRows[0].Cells[13].Value.ToString()));
            //Generar una nueva cuota
            contrato.Contrato_PagoCuota2(0, 0, 0, int.Parse(dgvStock.SelectedRows[0].Cells[13].Value.ToString()), int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()), "", contrato.Contrato_ProximaCuota(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][0].ToString());
            //LLenado del data
            dgvStock.DataSource = contrato.Contrato_ListarContratosPagando(txtFiltro.Texts);
            Ccolor();
            txtCordobas.Text = "0";
            txtDolares.Text = "0";
            txtObservaciones.Text = "";
            txtCuotas.Text = "0";
        }

        private void dgvStock_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtRecibo.Text = contrato.Contrato_ListarUltimaFactura(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][0].ToString();
            }
            catch (Exception)
            {

            }
        }

        private void especialButton2_Click(object sender, EventArgs e)
        {
            if (dgvStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ningun contrato", "Error");
                return;
            }

            if (txtRecibo.Text == "x")
            {
                MessageBox.Show("No hay ningun recibo encontrado", "Error");
                return;
            }

            PnlReciboColector reciboColector = new PnlReciboColector(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));
            reciboColector.Show();
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            //Verficar que haya algo seleccionado en el data

            if (dgvStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado el contrato", "Error");
                return;
            }

            //Pasar a retirado los contratos
            contrato.Contrato_Retirar(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));

            //LLenado del data
            dgvStock.DataSource = contrato.Contrato_ListarContratosPagando(txtFiltro.Texts);
            Ccolor();
        }
    }
}
