using NeoCobranza.Clases;
using NeoCobranza.Data;
using NeoCobranza.DataController;
using NeoCobranza.Paneles_Colectores;
using NeoCobranza.Paneles_Contrato;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles
{
    public partial class PnlPagoCuotas : Form
    {
        public Contrato contrato;
        public Colector colector;
        //Variable de conexion
        private Conexion conexion;
        public PnlPagoCuotas(Conexion conexion)
        {
            InitializeComponent();
           

            this.conexion = conexion;
            this.contrato = new Contrato(conexion);
            this.colector = new Colector(conexion);

            //estilo
            dgvStock.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvStock.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            //LLenado del dgv

            dgvStock.DataSource = contrato.Contrato_ListarPrimerasCuotas(txtFiltro.Texts);

            try
            {
                txtRecibo.Text = contrato.Contrato_ListarUltimaFactura(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][0].ToString();
                txtNombre.Text = colector.Colector_PorId(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][0].ToString();
                txtIdColector.Text = colector.Colector_PorId(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][1].ToString();
            }
            catch (Exception)
            {

            }
        }
        //Constructor

        public PnlPagoCuotas(Conexion conexion, string txtid)
        {
            InitializeComponent();


            this.conexion = conexion;
            this.contrato = new Contrato(conexion);
            this.colector = new Colector(conexion);

            //estilo
            dgvStock.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvStock.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            //LLenado del dgv

            dgvStock.DataSource = contrato.Contrato_ListarPrimerasCuotas_ID(int.Parse(txtid));

            try
            {
                txtRecibo.Text = contrato.Contrato_ListarUltimaFactura(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][0].ToString();
                txtNombre.Text = colector.Colector_PorId(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][0].ToString();
                txtIdColector.Text = colector.Colector_PorId(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][1].ToString();
            }
            catch (Exception)
            {

            }
        }

        private void txtCordobas_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCuotas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
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
            else
            {
                e.Handled = true;
            }
        }

        private void BtnVendedor_Click(object sender, EventArgs e)
        {
            PnlColector pnlColectores = new PnlColector(conexion,"Primera");

            this.AddOwnedForm(pnlColectores);

            pnlColectores.Show();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            //Verficar que haya algo seleccionado en el data

            if (dgvStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado el contrato","Error");
                return;
            }
            //Verificar que haya una cuota
            if(txtRecibo.Text == "x")
            {
                MessageBox.Show("El sistema no genero cuota", "Error");
                return;
            }
            //Verificar que se haya seleccionado un colector
            if (txtIdColector.Text == "x")
            {
                MessageBox.Show("No ha seleccionado un Colector", "Error");
                return;
            }

            //Verficar que haya un monto o que sea valido
            if(txtCordobas.Text == "0" && txtDolares.Text == "0")
            {
                MessageBox.Show("No ha digitado ningun monto", "Error");
                return;

            }
            else if(txtCordobas.Text == "" && txtDolares.Text == "")
            {
                MessageBox.Show("No ha digitado ningun monto", "Error");
                return;

            }
            else if(txtCordobas.Text == "0" && txtDolares.Text == "")
            {
                MessageBox.Show("No ha digitado ningun monto", "Error");
                return;

            }
            else if(txtCordobas.Text == "" && txtDolares.Text == "0")
            {
                MessageBox.Show("No ha digitado ningun monto", "Error");
                return;

            }

            if(txtCordobas.Text == "")
            {
                txtCordobas.Text = "0";
            }
            if(txtDolares.Text == "")
            {
                txtDolares.Text = "0";
            }
            //Verificar que sea valido
            float prueba;
            if(float.TryParse(txtDolares.Text, out prueba) == false || float.TryParse(txtCordobas.Text,out prueba) == false)
            {
                MessageBox.Show("Los monton tienen un digito incorrecto", "Error");
                return;
            }

            if(txtCuotas.Text == "0" || txtCuotas.Text == "")
            {
                MessageBox.Show("Las cuotas no pueden ser 0", "Error");
                return;
            }

            CTasaCambio cTasa = new CTasaCambio(conexion);

            float cordoba, dolar;

            cordoba = float.Parse(txtCordobas.Text) + (float.Parse(cTasa.MostrarTasa())*float.Parse(txtDolares.Text));
            dolar = float.Parse(txtDolares.Text) + ( float.Parse(txtCordobas.Text)/ float.Parse(cTasa.MostrarTasa()));

            //Historial de contrato
            contrato.Contrato_Insertar_Historial("Pago de apertura","Id: "+txtRecibo.Text+" Valor en dolares: "+dolar.ToString()+" NoCuotas: " + txtCuotas.Text, conexion.usuario, int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));

            //Valores del controato
            contrato.Contrato_Insertar_Valores(txtRecibo.Text,dolar,0, int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()),"RECIBO", cTasa.MostrarTasa());

            //Verificar si cancela el contrato
            contrato.Contrato_Cancelado(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()), dolar);

            //Actualizar la cuota con el nuevo monto
            contrato.Contrato_ActualizarCuota(int.Parse(txtRecibo.Text),cordoba,dolar,int.Parse(txtCuotas.Text),txtObservaciones.Text,int.Parse(txtIdColector.Text));
            //Actualizar el estado  y la modalidad del contrato
            contrato.Contrato_Actualizar_Pagando(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));
            //Generar una nueva cuota
            contrato.Contrato_PagoCuota2(0, 0, 0, int.Parse(txtIdColector.Text), int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()), "", contrato.Contrato_ProximaCuota(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][0].ToString());
            //Actualizar el data
            dgvStock.DataSource = contrato.Contrato_ListarPrimerasCuotas(txtFiltro.Texts);

            txtCordobas.Text = "0";
            txtDolares.Text = "0";
            txtIdColector.Text = "1";
            txtNombre.Text = "OFICINA CENTRAL";
            txtObservaciones.Text = "";
            txtCuotas.Text = "0";

        }

        private void dgvStock_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStock.SelectedRows.Count == 0)
            {
                txtRecibo.Text = "x";
            }
            try
            {
                txtRecibo.Text = contrato.Contrato_ListarUltimaFactura(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][0].ToString();
                txtNombre.Text = colector.Colector_PorId(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][0].ToString();
                txtIdColector.Text = colector.Colector_PorId(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][1].ToString();
            }
            catch (Exception)
            {

            }
        }

        private void PnlPagoCuotas_Load(object sender, EventArgs e)
        {
            try
            {
                txtRecibo.Text = contrato.Contrato_ListarUltimaFactura(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][0].ToString();
                txtNombre.Text = colector.Colector_PorId(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][0].ToString();
                txtIdColector.Text = colector.Colector_PorId(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][1].ToString();
            }
            catch (Exception)
            {

            }
        }

        private void especialButton2_Click(object sender, EventArgs e)
        {
            if (dgvStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ningun contrato","Error");
                return;
            }

            if(txtRecibo.Text == "x")
            {
                MessageBox.Show("No hay ningun recibo encontrado", "Error");
                return;
            }

            PnlReciboColector reciboColector = new PnlReciboColector(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()),conexion);
            reciboColector.Show();
        }

        private void dgvStock_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Verificacion de que haya una fila seleccionada

            if (dgvStock.Rows.Count == 0)
            {
                MessageBox.Show("No hay fila seleccionada", "Error");
                return;
            }
            try
            {



                PnlGeneralContrato pnlGeneral = new PnlGeneralContrato(conexion, dgvStock.SelectedRows[0].Cells[0].Value.ToString());

                PnlPrincipal pnlPrincipal = Owner as PnlPrincipal;
                pnlGeneral.TopLevel = false;
                pnlGeneral.Dock = DockStyle.Fill;
                pnlPrincipal.PnlCentral.Controls.Add(pnlGeneral);
                pnlPrincipal.PnlCentral.Tag = pnlGeneral;


                pnlGeneral.Show();

            }
            catch (Exception)
            {

            }
            this.Close();



        }

        private void txtFiltro__TextChanged_1(object sender, EventArgs e)
        {
            dgvStock.DataSource = contrato.Contrato_ListarPrimerasCuotas(txtFiltro.Texts);
        }

        private void txtFiltroId__TextChanged(object sender, EventArgs e)
        {
            if (txtFiltroId.Texts == "")
            {
                return;
            }
            int prueba;
            if(int.TryParse(txtFiltroId.Texts,out prueba)==false)
            {
                return;
            }

            dgvStock.DataSource = contrato.Contrato_ListarPrimerasCuotas_ID(int.Parse(txtFiltroId.Texts));
        }
    }
}
