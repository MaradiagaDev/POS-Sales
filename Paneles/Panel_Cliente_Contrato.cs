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
using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles_Contrato;
using NeoCobranza.Paneles_Venta;
using NeoCobranza.ViewModels;

namespace NeoCobranza.Paneles
{
    public partial class Panel_Cliente_Contrato : Form
    {
        CCliente cliente;
        string panel;
        public int currentPage = 1;
        public int totalPages = 0;
        private const int pageSize = 30;
        private List<Clientes> allClientes = new List<Clientes>();

        public Panel_Cliente_Contrato(string panel)
        {
            InitializeComponent();
            FiltrarClientes();
            this.panel = panel;
        }

        private void txtFiltro__TextChanged(object sender, EventArgs e)
        {
            FiltrarClientes();
        }

        public void FiltrarClientes()
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                var query = db.Clientes
                              .Where(s => s.Estado == 1)
                              .Where(item => (item.Pnombre + "" + item.Snombre + " " + item.Papellido + " " + item.Sapellido)
                                             .Contains(txtFiltro.Texts)
                                             || item.Celular.Contains(txtFiltro.Texts)
                                             || item.Cedula.Contains(txtFiltro.Texts))
                              .OrderByDescending(s => s.IdCliente);

                totalPages = (int)Math.Ceiling((double)query.Count() / pageSize);
                currentPage = 1;
                UpdatePagination(query);
            }
        }

        public void UpdatePagination(IQueryable<Clientes> query)
        {
            var pagedClientes = query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            DataTable dt = new DataTable();

            dt.Columns.Add("Id", typeof(string));
            dt.Columns.Add("Nombre Completo", typeof(string));
            dt.Columns.Add("Cédula", typeof(string));
            dt.Columns.Add("Celular", typeof(string));

            foreach (var item in pagedClientes)
            {
                var cedula = item.Cedula == null ? "" : item.Cedula;
                var celular = item.Celular == null ? "" : item.Celular;
                dt.Rows.Add(item.IdCliente, item.Pnombre + "" + item.Snombre + " " + item.Papellido + " " + item.Sapellido, cedula, celular);
            }

            DgvCliente.DataSource = dt;
            DgvCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Actualizar la interfaz de usuario con la página actual y el total de páginas
            TxtPaginaNo.Text = currentPage.ToString();
            TxtPaginaDe.Text = totalPages.ToString();
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            if (DgvCliente.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ningún registro", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (panel == "Proforma")
            {

                PnlProforma pnlProforma = Owner as PnlProforma;
                pnlProforma.lblNombreCliente.Text = DgvCliente.SelectedRows[0].Cells[1].Value.ToString();

                pnlProforma.lblEstadoCliente.Text = "Cliente Seleccionado";
                pnlProforma.lblEstadoCliente.ForeColor = Color.Green;
                pnlProforma.lblIdCliente.Text = DgvCliente.SelectedRows[0].Cells[0].Value.ToString();
                this.Hide();
            }
            if (panel == "Contrato")
            {

                PnlContrato pnlProforma = Owner as PnlContrato;
                pnlProforma.lblNombreCliente.Text = DgvCliente.SelectedRows[0].Cells[1].Value.ToString();

                pnlProforma.lblEstadoCliente.Text = "Cliente Seleccionado";
                pnlProforma.lblEstadoCliente.ForeColor = Color.Green;
                pnlProforma.lblIdCliente.Text = DgvCliente.SelectedRows[0].Cells[0].Value.ToString();
                this.Hide();

            }
            if (panel == "ContratoProforma")
            {

                PnlProformaContrato pnlProformaContrato = Owner as PnlProformaContrato;
                pnlProformaContrato.lblNombreCliente.Text = DgvCliente.SelectedRows[0].Cells[1].Value.ToString();

                pnlProformaContrato.lblEstadoCliente.Text = "Cliente Seleccionado";
                pnlProformaContrato.lblEstadoCliente.ForeColor = Color.Green;
                pnlProformaContrato.lblIdCliente.Text = DgvCliente.SelectedRows[0].Cells[0].Value.ToString();
                this.Hide();


            }
            if (panel == "Venta")
            {

                PnlVentas pnlVenta = Owner as PnlVentas;
                pnlVenta.LblNombreClientes.Text = DgvCliente.SelectedRows[0].Cells[1].Value.ToString();

                pnlVenta.lblEstadoCliente.Text = "Cliente Seleccionado";
                pnlVenta.lblEstadoCliente.ForeColor = Color.Green;
                pnlVenta.LblIdClientes.Text = DgvCliente.SelectedRows[0].Cells[0].Value.ToString();

                using (NeoCobranzaContext db = new NeoCobranzaContext())
                {
                    Clientes cliente = db.Clientes.Where(s => s.IdCliente.ToString() == DgvCliente.SelectedRows[0].Cells[0].Value.ToString()).FirstOrDefault();
                    if (cliente.NoRuc != null && cliente.NoRuc.Length == 14)
                    {
                        pnlVenta.ChkRetencionAlcaldia.Visible = true;
                        pnlVenta.ChkRetencionDgi.Visible = true;
                    }
                    else
                    {
                        pnlVenta.ChkRetencionAlcaldia.Visible = false;
                        pnlVenta.ChkRetencionDgi.Visible = false;
                    }
                }

                this.Close();


            }
            if (panel == "ActualizarContrato")
            {

                PnlGeneralContrato pnlProformaContrato = Owner as PnlGeneralContrato;
                pnlProformaContrato.lblNombreCliente.Text = DgvCliente.SelectedRows[0].Cells[1].Value.ToString();

                pnlProformaContrato.lblEstadoCliente.Text = "Cliente Seleccionado";
                pnlProformaContrato.lblEstadoCliente.ForeColor = Color.Green;
                pnlProformaContrato.lblIdCliente.Text = DgvCliente.SelectedRows[0].Cells[0].Value.ToString();
                this.Hide();



            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Panel_Cliente_Contrato_Load(object sender, EventArgs e)
        {
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                using (NeoCobranzaContext db = new NeoCobranzaContext())
                {
                    var query = db.Clientes
                                  .Where(s => s.Estado == 1)
                                  .Where(item => (item.Pnombre + "" + item.Snombre + " " + item.Papellido + " " + item.Sapellido)
                                                 .Contains(txtFiltro.Texts)
                                                 || item.Celular.Contains(txtFiltro.Texts)
                                                 || item.Cedula.Contains(txtFiltro.Texts))
                                  .OrderByDescending(s => s.IdCliente);
                    UpdatePagination(query);
                }
            }
        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                using (NeoCobranzaContext db = new NeoCobranzaContext())
                {
                    var query = db.Clientes
                                  .Where(s => s.Estado == 1)
                                  .Where(item => (item.Pnombre + "" + item.Snombre + " " + item.Papellido + " " + item.Sapellido)
                                                 .Contains(txtFiltro.Texts)
                                                 || item.Celular.Contains(txtFiltro.Texts)
                                                 || item.Cedula.Contains(txtFiltro.Texts))
                                  .OrderByDescending(s => s.IdCliente);
                    UpdatePagination(query);
                }
            }
        }
    }
}

