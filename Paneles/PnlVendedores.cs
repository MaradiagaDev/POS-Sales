using NeoCobranza.Data;
using NeoCobranza.DataController;
using NeoCobranza.Paneles_Contrato;
using NeoCobranza.Paneles_Venta;
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
    public partial class PnlVendedores : Form
    {
        public CVendedor cVendedor;
        public Conexion conexion;
        public string panel;
        public PnlVendedores(Conexion conexion, string panel)
        {
            InitializeComponent();
            cVendedor = new CVendedor(conexion);

            this.DgvVendedor.DataSource = cVendedor.MostrarVendedor(txtFiltro.Texts);
            this.panel = panel;
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            if (DgvVendedor.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ningún registro", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (panel == "Contrato")
            {
                PnlContrato pnlContrato = Owner as PnlContrato;

                // pnlContrato.dgvColector.Rows.Add(this.DgvColector.SelectedRows[0].Cells[0].Value +" "+ this.DgvColector.SelectedRows[0].Cells[1].Value + " "+this.DgvColector.SelectedRows[0].Cells[2].Value + " " + this.DgvColector.SelectedRows[0].Cells[3].Value, this.DgvColector.SelectedRows[0].Cells[4].Value);
                pnlContrato.lblNombreColector.Text = this.DgvVendedor.SelectedRows[0].Cells[1].Value.ToString();
                pnlContrato.lblIdColector.Text = this.DgvVendedor.SelectedRows[0].Cells[0].Value.ToString();

                this.Hide();

            }
            if (panel == "ContratoProforma")
            {

                PnlProformaContrato pnlProformaContrato = Owner as PnlProformaContrato;

                // pnlContrato.dgvColector.Rows.Add(this.DgvColector.SelectedRows[0].Cells[0].Value +" "+ this.DgvColector.SelectedRows[0].Cells[1].Value + " "+this.DgvColector.SelectedRows[0].Cells[2].Value + " " + this.DgvColector.SelectedRows[0].Cells[3].Value, this.DgvColector.SelectedRows[0].Cells[4].Value);
                pnlProformaContrato.lblNombreColector.Text = this.DgvVendedor.SelectedRows[0].Cells[1].Value.ToString();
                pnlProformaContrato.lblIdColector.Text = this.DgvVendedor.SelectedRows[0].Cells[0].Value.ToString();

                this.Hide();


            }
            if (panel == "VentaProforma")
            {
                PnlProforma pnlProformaContrato = Owner as PnlProforma;

                // pnlContrato.dgvColector.Rows.Add(this.DgvColector.SelectedRows[0].Cells[0].Value +" "+ this.DgvColector.SelectedRows[0].Cells[1].Value + " "+this.DgvColector.SelectedRows[0].Cells[2].Value + " " + this.DgvColector.SelectedRows[0].Cells[3].Value, this.DgvColector.SelectedRows[0].Cells[4].Value);
                pnlProformaContrato.lblNombreColector.Text = this.DgvVendedor.SelectedRows[0].Cells[1].Value.ToString();
                pnlProformaContrato.lblIdColector.Text = this.DgvVendedor.SelectedRows[0].Cells[0].Value.ToString();

                this.Hide();
            }
            if (panel == "Venta")
            {
                PnlVentas pnlVentas = Owner as PnlVentas;

                // pnlContrato.dgvColector.Rows.Add(this.DgvColector.SelectedRows[0].Cells[0].Value +" "+ this.DgvColector.SelectedRows[0].Cells[1].Value + " "+this.DgvColector.SelectedRows[0].Cells[2].Value + " " + this.DgvColector.SelectedRows[0].Cells[3].Value, this.DgvColector.SelectedRows[0].Cells[4].Value);
                pnlVentas.LblNombreVendedor.Text = this.DgvVendedor.SelectedRows[0].Cells[1].Value.ToString();
                pnlVentas.LblIdVendedor.Text = this.DgvVendedor.SelectedRows[0].Cells[0].Value.ToString();

                this.Hide();
            }
            if (panel == "ActualizarContrato")
            {
                PnlGeneralContrato pnlProformaContrato = Owner as PnlGeneralContrato;

                // pnlContrato.dgvColector.Rows.Add(this.DgvColector.SelectedRows[0].Cells[0].Value +" "+ this.DgvColector.SelectedRows[0].Cells[1].Value + " "+this.DgvColector.SelectedRows[0].Cells[2].Value + " " + this.DgvColector.SelectedRows[0].Cells[3].Value, this.DgvColector.SelectedRows[0].Cells[4].Value);
                pnlProformaContrato.LblNombreColector.Text = this.DgvVendedor.SelectedRows[0].Cells[1].Value.ToString();
                pnlProformaContrato.txtIdColector.Text = this.DgvVendedor.SelectedRows[0].Cells[0].Value.ToString();

                this.Hide();
            }


        }

        private void loginUserControl1__TextChanged(object sender, EventArgs e)
        {
            this.DgvVendedor.DataSource = cVendedor.MostrarVendedor(txtFiltro.Texts);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void PnlVendedores_Load(object sender, EventArgs e)
        {
        }
    }
}
