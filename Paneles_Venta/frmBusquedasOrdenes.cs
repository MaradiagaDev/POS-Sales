using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles;
using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles_Venta
{
    public partial class frmBusquedasOrdenes : Form
    {
        DataUtilities dataUtilities = new DataUtilities();
        PnlPrincipal auxPnlPrincipal = null;
        string auxOpc = "";
        public DataTable dynamicDataTableOrdenes = new DataTable();


        public frmBusquedasOrdenes(PnlPrincipal pnlPrincipal,string opc)
        {
            InitializeComponent();

            auxPnlPrincipal = pnlPrincipal;
            auxOpc = opc;

            ConfigUI();
        }

        private void ConfigUI()
        {
            UIUtilities.PersonalizarDataGridView(dgvCatalogoOrdenes);

            switch (auxOpc)
            {
                case "Lista":
                    llbTitulo.Text = "Lista Ordenes";
                    dynamicDataTableOrdenes.Columns.Clear();
                    dynamicDataTableOrdenes.Rows.Clear();
                    dgvCatalogoOrdenes.Columns.Clear();
                    dgvCatalogoOrdenes.DataSource = null;

                    if (dgvCatalogoOrdenes.Columns.Count == 0)
                    {
                        dynamicDataTableOrdenes.Columns.Add("No Orden", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Cliente Id", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Cliente", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Fecha", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Estado Orden", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Estado Pago", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Total", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Pagado", typeof(string));

                        DataGridViewButtonColumn buttonColumnSeleccionar = new DataGridViewButtonColumn();
                        buttonColumnSeleccionar.HeaderText = "...";
                        buttonColumnSeleccionar.Text = " Abrir Orden ";
                        buttonColumnSeleccionar.UseColumnTextForButtonValue = true;

                        dgvCatalogoOrdenes.Columns.Add(buttonColumnSeleccionar);

                        DataGridViewButtonColumn buttonColumnCancelar = new DataGridViewButtonColumn();
                        buttonColumnCancelar.HeaderText = "...";
                        buttonColumnCancelar.Text = " Cancelar ";
                        buttonColumnCancelar.UseColumnTextForButtonValue = true;

                        dgvCatalogoOrdenes.Columns.Add(buttonColumnCancelar);
                        dgvCatalogoOrdenes.DataSource = dynamicDataTableOrdenes;
                    }
                    break;

                case "ListaCreadito":
                    llbTitulo.Text = "Cuentas Por Cobrar";

                    dynamicDataTableOrdenes.Columns.Clear();
                    dynamicDataTableOrdenes.Rows.Clear();
                    dgvCatalogoOrdenes.Columns.Clear();

                    if (dgvCatalogoOrdenes.Columns.Count == 0)
                    {
                        dynamicDataTableOrdenes.Columns.Add("No Orden", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Cliente Id", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Cliente", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Fecha", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Estado Orden", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Estado Pago", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Total", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Pagado", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Restante", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Fecha del Próximo Pago", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Cantidad de Pagos", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Frecuencia de Pago", typeof(string));

                        DataGridViewButtonColumn buttonColumnSeleccionar = new DataGridViewButtonColumn();
                        buttonColumnSeleccionar.HeaderText = "...";
                        buttonColumnSeleccionar.Text = " Abrir Orden ";
                        buttonColumnSeleccionar.UseColumnTextForButtonValue = true;

                        dgvCatalogoOrdenes.Columns.Add(buttonColumnSeleccionar);

                        DataGridViewButtonColumn buttonColumnCancelar = new DataGridViewButtonColumn();
                        buttonColumnCancelar.HeaderText = "...";
                        buttonColumnCancelar.Text = " Cancelar ";
                        buttonColumnCancelar.UseColumnTextForButtonValue = true;

                        dgvCatalogoOrdenes.Columns.Add(buttonColumnCancelar);
                        dgvCatalogoOrdenes.DataSource = dynamicDataTableOrdenes;
                    }

                    break;

                case "ListaPagadas":


                    break;
            }

            FuncionesPrincipales();
        }

        private void FuncionesPrincipales()
        {
            switch (auxOpc)
            {
                case "Lista":
                    dynamicDataTableOrdenes.Rows.Clear();
                    dataUtilities.SetParameter("@idSucursal", Utilidades.SucursalId);
                    dataUtilities.SetParameter("@filtro", TxtFiltrar.Texts);
                    DataTable dtResponseSuc = dataUtilities.ExecuteStoredProcedure("sp_ObtenerOrdenesPorSucursal");

                    // Llenar la tabla con los resultados de la consulta
                    foreach (DataRow orden in dtResponseSuc.Rows)
                    {
                        dynamicDataTableOrdenes.Rows.Add(Convert.ToString(orden["OrdenId"]),
                                                         Convert.ToString(orden["ClienteId"]),
                                                         Convert.ToString(orden["NombreCliente"]),
                                                        Convert.ToString(orden["FechaRealizacion"]),
                                                         Convert.ToString(orden["OrdenProceso"]),
                                                         Convert.ToString(orden["PagoProceso"]),
                                                         Convert.ToString(orden["TotalOrden"]),
                                                         Convert.ToString(orden["Pagado"]));
                    }

                    dgvCatalogoOrdenes.DataSource = dynamicDataTableOrdenes;
                    break;

                case "ListaCreadito":
                    dynamicDataTableOrdenes.Rows.Clear();
                    dataUtilities.SetParameter("@idSucursal", Utilidades.SucursalId);
                    dataUtilities.SetParameter("@filtro", TxtFiltrar.Texts);
                    DataTable dtResponseSucCredito = dataUtilities.ExecuteStoredProcedure("sp_ObtenerOrdenesCreditoPorSucursal");

                    // Llenar la tabla con los resultados de la consulta
                    foreach (DataRow orden in dtResponseSucCredito.Rows)
                    {
                        dynamicDataTableOrdenes.Rows.Add(Convert.ToString(orden["OrdenId"]),
                                                         Convert.ToString(orden["ClienteId"]),
                                                         Convert.ToString(orden["NombreCliente"]),
                                                        Convert.ToString(orden["FechaRealizacion"]),
                                                         Convert.ToString(orden["OrdenProceso"]),
                                                         Convert.ToString(orden["PagoProceso"]),
                                                         Convert.ToString(orden["TotalOrden"]),
                                                         Convert.ToString(orden["Pagado"]),
                                                         Convert.ToString(orden["RestantePago"]),
                                                         Convert.ToString(orden["FechaCredito"]),
                                                         Convert.ToString(orden["CantidadPagos"]),
                                                         Convert.ToString(orden["FrecuenciaPagos"]));

                    }

                    dgvCatalogoOrdenes.DataSource = dynamicDataTableOrdenes;
                    break;

                case "ListaPagadas":

                    break;
            }
        }

        private void dgvCatalogoOrdenes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                auxPnlPrincipal.AbrirVenta(Decimal.Parse(dgvCatalogoOrdenes.Rows[e.RowIndex].Cells[2].Value.ToString()));
            }
            else if (e.ColumnIndex == 1)
            {
                PnlCancelarOrden pnlCancelarOrden = new PnlCancelarOrden(dgvCatalogoOrdenes.Rows[e.RowIndex].Cells[2].Value.ToString(), null);
                pnlCancelarOrden.ShowDialog();
            }
        }
    }
}
