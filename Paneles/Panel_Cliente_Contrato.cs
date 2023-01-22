using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeoCobranza.Data;
using NeoCobranza.DataController;
using NeoCobranza.Paneles_Venta;

namespace NeoCobranza.Paneles
{
    public partial class Panel_Cliente_Contrato : Form
    {
        Conexion conexion;
        CCliente cliente;
        string panel;
        public Panel_Cliente_Contrato(Conexion conexion, string panel)
        {


            InitializeComponent();
            this.conexion = conexion;
            cliente = new CCliente(conexion);
            DgvCliente.DataSource = cliente.MostrarCliente(txtFiltro.Texts);

            //Estilo del data
            DgvCliente.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            DgvCliente.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);

            this.panel = panel;
        }

        private void txtFiltro__TextChanged(object sender, EventArgs e)
        {
            DgvCliente.DataSource = cliente.MostrarCliente(txtFiltro.Texts);
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {

            if (panel == "Proforma")
            {
                if (DgvCliente.SelectedRows.Count == 0)
                {
                    MessageBox.Show("No has seleccionado ningun registro", "ERROR");
                    return;
                }
                if (DgvCliente.SelectedRows[0].Cells["PNombre"].Value == null)
                {
                    MessageBox.Show("No has seleccionado ningun registro", "ERROR");
                    return;
                }

                PnlProforma pnlProforma = Owner as PnlProforma;
                pnlProforma.lblNombreCliente.Text = DgvCliente.SelectedRows[0].Cells["PNombre"].Value.ToString()
                    + " " + DgvCliente.SelectedRows[0].Cells["SNombre"].Value.ToString() + " " +
                    DgvCliente.SelectedRows[0].Cells["PApellido"].Value.ToString() + " " +
                    DgvCliente.SelectedRows[0].Cells["SApellido"].Value.ToString();

                pnlProforma.lblEstadoCliente.Text = "Cliente Seleccionado";
                pnlProforma.lblEstadoCliente.ForeColor = Color.Green;
                pnlProforma.lblIdCliente.Text = DgvCliente.SelectedRows[0].Cells["IdCliente"].Value.ToString();
                this.Hide();
            }
            if(panel == "Contrato")
            {
                if (DgvCliente.SelectedRows.Count == 0)
                {
                    MessageBox.Show("No has seleccionado ningun registro", "ERROR");
                    return;
                }
                if (DgvCliente.SelectedRows[0].Cells["PNombre"].Value == null)
                {
                    MessageBox.Show("No has seleccionado ningun registro", "ERROR");
                    return;
                }

                PnlContrato pnlProforma = Owner as PnlContrato;
                pnlProforma.lblNombreCliente.Text = DgvCliente.SelectedRows[0].Cells["PNombre"].Value.ToString()
                    + " " + DgvCliente.SelectedRows[0].Cells["SNombre"].Value.ToString() + " " +
                    DgvCliente.SelectedRows[0].Cells["PApellido"].Value.ToString() + " " +
                    DgvCliente.SelectedRows[0].Cells["SApellido"].Value.ToString();

                pnlProforma.lblEstadoCliente.Text = "Cliente Seleccionado";
                pnlProforma.lblEstadoCliente.ForeColor = Color.Green;
                pnlProforma.lblIdCliente.Text = DgvCliente.SelectedRows[0].Cells["IdCliente"].Value.ToString();
                this.Hide();

            }
            if(panel == "ContratoProforma")
            {


                if (DgvCliente.SelectedRows.Count == 0)
                {
                    MessageBox.Show("No has seleccionado ningun registro", "ERROR");
                    return;
                }
                if (DgvCliente.SelectedRows[0].Cells["PNombre"].Value == null)
                {
                    MessageBox.Show("No has seleccionado ningun registro", "ERROR");
                    return;
                }
                PnlProformaContrato pnlProformaContrato= Owner as PnlProformaContrato;
                pnlProformaContrato.lblNombreCliente.Text = DgvCliente.SelectedRows[0].Cells["PNombre"].Value.ToString()
                    + " " + DgvCliente.SelectedRows[0].Cells["SNombre"].Value.ToString() + " " +
                    DgvCliente.SelectedRows[0].Cells["PApellido"].Value.ToString() + " " +
                    DgvCliente.SelectedRows[0].Cells["SApellido"].Value.ToString();

                pnlProformaContrato.lblEstadoCliente.Text = "Cliente Seleccionado";
                pnlProformaContrato.lblEstadoCliente.ForeColor = Color.Green;
                pnlProformaContrato.lblIdCliente.Text = DgvCliente.SelectedRows[0].Cells["IdCliente"].Value.ToString();
                this.Hide();


            }
            if (panel == "Venta")
            {


                if (DgvCliente.SelectedRows.Count == 0)
                {
                    MessageBox.Show("No has seleccionado ningun registro", "ERROR");
                    return;
                }
                if (DgvCliente.SelectedRows[0].Cells["PNombre"].Value == null)
                {
                    MessageBox.Show("No has seleccionado ningun registro", "ERROR");
                    return;
                }
                PnlVentas pnlProformaContrato = Owner as PnlVentas;
                pnlProformaContrato.lblNombreCliente.Text = DgvCliente.SelectedRows[0].Cells["PNombre"].Value.ToString()
                    + " " + DgvCliente.SelectedRows[0].Cells["SNombre"].Value.ToString() + " " +
                    DgvCliente.SelectedRows[0].Cells["PApellido"].Value.ToString() + " " +
                    DgvCliente.SelectedRows[0].Cells["SApellido"].Value.ToString();

                pnlProformaContrato.lblEstadoCliente.Text = "Cliente Seleccionado";
                pnlProformaContrato.lblEstadoCliente.ForeColor = Color.Green;
                pnlProformaContrato.lblIdCliente.Text = DgvCliente.SelectedRows[0].Cells["IdCliente"].Value.ToString();
                this.Hide();


            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Panel_Cliente_Contrato_Load(object sender, EventArgs e)
        {
            DgvCliente.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
        }
    }
}
