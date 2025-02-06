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
        private int currentPage = 1;
        private int totalPages = 1;
        private const int pageSize = 20;
        private bool EsCredito = false;
        private decimal colocado = 0;
        private decimal pagado = 0;
        private decimal restante = 0;
        private bool EsPagada = false;


        public frmBusquedasOrdenes(PnlPrincipal pnlPrincipal, string opc)
        {
            InitializeComponent();

            auxPnlPrincipal = pnlPrincipal;
            auxOpc = opc;

            ConfigUI();
        }

        private void ConfigUI()
        {
            DateTime fechaInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1);
            DateTime fechaFin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(1);

            // Asignar las fechas a los DateTimePicker
            DtInicio.Value = fechaInicio;
            DtFin.Value = fechaFin;

            UIUtilities.PersonalizarDataGridView(dgvCatalogoOrdenes);

            CmbBuscarPor.SelectedIndex = 0;
            CmbFiltrarFecha.SelectedIndex = 0;

            // Obtiene todos los registros de la tabla Sucursal
            DataTable dtResponseSucursales = dataUtilities.GetAllRecords("Sucursal");

            // Filtra las filas donde el campo Estado sea "Activo"
            var filterRowSucursales = from row in dtResponseSucursales.AsEnumerable()
                                      where Convert.ToString(row.Field<string>("Estado")) == "Activo"
                                      select row;
            // Configura el DataSource del combo box
            CmbSucursal.ValueMember = "IdSucursal";
            CmbSucursal.DisplayMember = "NombreSucursal";
            CmbSucursal.DataSource = filterRowSucursales.CopyToDataTable();

            CmbSucursal.SelectedValue = Utilidades.SucursalId;

            switch (auxOpc)
            {
                case "Lista":
                    EsCredito = false;
                    llbTitulo.Text = "Lista de Ventas Activas";
                    dynamicDataTableOrdenes.Columns.Clear();
                    dynamicDataTableOrdenes.Rows.Clear();
                    dgvCatalogoOrdenes.Columns.Clear();
                    dgvCatalogoOrdenes.DataSource = null;

                    if (dgvCatalogoOrdenes.Columns.Count == 0)
                    {
                        dynamicDataTableOrdenes.Columns.Add("No Orden", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Factura", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Cliente Id", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Cliente", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Fecha", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Estado Orden", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Estado Pago", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Total", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Pagado", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Restante", typeof(string));

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

                case "ListaCredito":
                    EsCredito = true;
                    llbTitulo.Text = "Cuentas Por Cobrar";

                    dynamicDataTableOrdenes.Columns.Clear();
                    dynamicDataTableOrdenes.Rows.Clear();
                    dgvCatalogoOrdenes.Columns.Clear();

                    if (dgvCatalogoOrdenes.Columns.Count == 0)
                    {
                        dynamicDataTableOrdenes.Columns.Add("No Orden", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Factura", typeof(string));
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
                    EsPagada = true;
                    llbTitulo.Text = "Lista de Ventas Pagadas";
                    dynamicDataTableOrdenes.Columns.Clear();
                    dynamicDataTableOrdenes.Rows.Clear();
                    dgvCatalogoOrdenes.Columns.Clear();
                    dgvCatalogoOrdenes.DataSource = null;

                    if (dgvCatalogoOrdenes.Columns.Count == 0)
                    {
                        dynamicDataTableOrdenes.Columns.Add("No Orden", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Factura", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Cliente Id", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Cliente", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Fecha", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Estado Orden", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Estado Pago", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Total", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Pagado", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Restante", typeof(string));

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
            }

            FuncionesPrincipales();
        }

        private void FuncionesPrincipales()
        {
            colocado = 0;
            pagado = 0;
            restante = 0;

            dynamicDataTableOrdenes.Rows.Clear();

            // Parámetros comunes
            dataUtilities.SetParameter("@idSucursal", CmbSucursal.SelectedValue);
            dataUtilities.SetParameter("@filtro", TxtFiltrar.Texts);
            dataUtilities.SetParameter("@startDate", DtInicio.Value.Date);
            dataUtilities.SetParameter("@endDate", DtFin.Value.Date);
            dataUtilities.SetParameter("@pageNumber", currentPage);
            dataUtilities.SetParameter("@pageSize", pageSize);
            dataUtilities.SetParameter("@bitEsCredito", EsCredito);
            dataUtilities.SetParameter("@bitEsPagada", EsPagada);
            dataUtilities.SetParameter("@OpcBuscador", CmbBuscarPor.SelectedIndex);
            dataUtilities.SetParameter("@OpcFecha", CmbFiltrarFecha.SelectedIndex);

            DataTable dtResponse = dataUtilities.ExecuteStoredProcedure("sp_ObtenerOrdenesCreditoPorSucursal");

            switch (auxOpc)
            {
                case "Lista":
                    foreach (DataRow orden in dtResponse.Rows)
                    {
                        dynamicDataTableOrdenes.Rows.Add(
                            Convert.ToString(orden["OrdenId"]),
                            Convert.ToString(orden["NoFactura"]),
                            Convert.ToString(orden["ClienteId"]),
                            Convert.ToString(orden["NombreCliente"]),
                            Convert.ToString(orden["FechaRealizacion"]),
                            Convert.ToString(orden["OrdenProceso"]),
                            Convert.ToString(orden["PagoProceso"]),
                            Convert.ToString(orden["TotalOrden"]),
                            Convert.ToString(orden["Pagado"]),
                            Convert.ToString(orden["RestantePago"])
                        );
                    }
                    break;

                case "ListaCredito":
                    

                    foreach (DataRow orden in dtResponse.Rows)
                    {
                        dynamicDataTableOrdenes.Rows.Add(
                            Convert.ToString(orden["OrdenId"]),
                            Convert.ToString(orden["NoFactura"]),
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
                            Convert.ToString(orden["FrecuenciaPagos"])
                        );
                    }
                    break;

                case "ListaPagadas":
                    foreach (DataRow orden in dtResponse.Rows)
                    {
                        dynamicDataTableOrdenes.Rows.Add(
                            Convert.ToString(orden["OrdenId"]),
                            Convert.ToString(orden["NoFactura"]),
                            Convert.ToString(orden["ClienteId"]),
                            Convert.ToString(orden["NombreCliente"]),
                            Convert.ToString(orden["FechaRealizacion"]),
                            Convert.ToString(orden["OrdenProceso"]),
                            Convert.ToString(orden["PagoProceso"]),
                            Convert.ToString(orden["TotalOrden"]),
                            Convert.ToString(orden["Pagado"]),
                            Convert.ToString(orden["RestantePago"])
                        );
                    }
                    break;

                default:
                    MessageBox.Show("Opción no válida.");
                    return;
            }

            if(dtResponse.Rows.Count > 0)
            {
                totalPages = dtResponse.Rows[dtResponse.Rows.Count-1]["TotalPages"] == null ? 0 : Convert.ToInt16(dtResponse.Rows[0]["TotalPages"]);
                colocado = dtResponse.Rows[dtResponse.Rows.Count - 1]["TotalSumaTotalOrden"] == null ? 0 : Convert.ToDecimal(dtResponse.Rows[0]["TotalSumaTotalOrden"]);
                pagado = dtResponse.Rows[dtResponse.Rows.Count - 1]["TotalSumaPagado"] == null ? 0 : Convert.ToDecimal(dtResponse.Rows[0]["TotalSumaPagado"]);
                restante = dtResponse.Rows[dtResponse.Rows.Count - 1]["TotalSumaRestante"] == null ? 0 : Convert.ToDecimal(dtResponse.Rows[0]["TotalSumaRestante"]);
            }

            // Llenar la tabla con los resultados de la consulta
            TxtColocado.Text = colocado.ToString() + "C$";
            TxtRecuperado.Text = pagado.ToString() + "C$";
            TxtRestante.Text = restante.ToString() + "C$";

            dgvCatalogoOrdenes.DataSource = dynamicDataTableOrdenes;

            // Actualizar información de paginación
            UpdatePaginationInfo();
        }
        private void UpdatePaginationInfo()
        {
            TxtPaginaNo.Text = currentPage.ToString();
            TxtPaginaDe.Text = totalPages.ToString();

            BtnAnterior.Enabled = currentPage > 1;
            BtnSiguiente.Enabled = currentPage < totalPages;
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

        private void especialButton2_Click(object sender, EventArgs e)
        {
            FuncionesPrincipales();
        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                FuncionesPrincipales();
            }
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                FuncionesPrincipales();
            }
        }
    }
}
