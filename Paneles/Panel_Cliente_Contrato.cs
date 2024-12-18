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
        private const int pageSize = 40;

        private List<Clientes> allClientes = new List<Clientes>();
        DataUtilities dataUtilities = new DataUtilities();
        DataTable dynamicDataTable = new DataTable();

        public Panel_Cliente_Contrato(string panel)
        {
            InitializeComponent();
            
            this.panel = panel;
            UIUtilities.PersonalizarDataGridView(DgvCliente);

            // Obtiene todos los registros de la tabla Sucursal
            DataTable dtResponseSucursales = dataUtilities.GetAllRecords("Sucursal");

            // Filtra las filas donde el campo Estado sea "Activo"
            var filterRowSucursales = from row in dtResponseSucursales.AsEnumerable()
                                      where Convert.ToString(row.Field<string>("Estado")) == "Activo"
                                      select row;

            if (filterRowSucursales.Any())
            {
                // Crea un DataTable para los datos filtrados
                DataTable dataCmbSucursal = new DataTable();
                dataCmbSucursal = filterRowSucursales.CopyToDataTable();

                // Crea una nueva fila para "Mostrar Todo"
                DataRow newRow = dataCmbSucursal.NewRow();
                newRow["IdSucursal"] = "0";
                newRow["NombreSucursal"] = "Mostrar Todo";
                newRow["Estado"] = "Activo"; // Puedes mantener el estado "Activo" para esta fila

                // Inserta la nueva fila en la posición 0
                dataCmbSucursal.Rows.InsertAt(newRow, 0);

                // Configura el DataSource del combo box
                CmbSucursal.ValueMember = "IdSucursal";
                CmbSucursal.DisplayMember = "NombreSucursal";
                CmbSucursal.DataSource = dataCmbSucursal;

                CmbSucursal.SelectedValue = Utilidades.SucursalId;

                if (CmbBuscarPor.Items.Count == 0)
                {
                    CmbBuscarPor.Items.Add("ID");
                    CmbBuscarPor.Items.Add("Nombre");
                    CmbBuscarPor.Items.Add("Cédula");
                }

                CmbBuscarPor.SelectedIndex = 1;
            }

            FiltrarClientes();
        }

        private void txtFiltro__TextChanged(object sender, EventArgs e)
        {
            FiltrarClientes();
        }

        public void FiltrarClientes()
        {
            if(dynamicDataTable.Columns.Count == 0)
            {
                dynamicDataTable.Columns.Add("Id", typeof(string));
                dynamicDataTable.Columns.Add("Nombre del Cliente", typeof(string));
                dynamicDataTable.Columns.Add("Cédula", typeof(string));
                dynamicDataTable.Columns.Add("Estado", typeof(string));
                dynamicDataTable.Columns.Add("Dirección", typeof(string));
                dynamicDataTable.Columns.Add("Pais", typeof(string));
                dynamicDataTable.Columns.Add("Departamento", typeof(string));
                dynamicDataTable.Columns.Add("Fecha de Nacimiento", typeof(string));
                dynamicDataTable.Columns.Add("Telefono Convencional", typeof(string));
                dynamicDataTable.Columns.Add("Celular", typeof(string));
                dynamicDataTable.Columns.Add("Edad", typeof(string));
                dynamicDataTable.Columns.Add("Profesión", typeof(string));
                dynamicDataTable.Columns.Add("Sexo", typeof(string));
            }

            dynamicDataTable.Rows.Clear();

            dataUtilities.SetParameter("@FiltroPor", CmbBuscarPor.SelectedIndex);
            dataUtilities.SetParameter("@FiltroValor", txtFiltro.Texts);
            dataUtilities.SetParameter("@IdSucursal", CmbSucursal.SelectedValue);
            dataUtilities.SetParameter("@PageNumber", 10);
            dataUtilities.SetParameter("@PageSize", pageSize);

            DataTable dtRespuesta = new DataTable();
            dtRespuesta = dataUtilities.ExecuteStoredProcedure("sp_ObtenerClientesFiltrados");

            // Para obtener el número total de páginas
            totalPages = (int)Math.Ceiling((double)dtRespuesta.Rows.Count / pageSize);
            UpdatePagination(this); // Actualiza la paginación en el formulario
        }

        public void UpdatePagination(Panel_Cliente_Contrato frm)
        {
            dataUtilities.SetParameter("@FiltroPor", CmbBuscarPor.SelectedIndex);
            dataUtilities.SetParameter("@FiltroValor", txtFiltro.Texts);
            dataUtilities.SetParameter("@IdSucursal", CmbSucursal.SelectedValue);
            dataUtilities.SetParameter("@PageNumber", currentPage);
            dataUtilities.SetParameter("@PageSize", pageSize);

            DataTable dtRespuesta = new DataTable();
            dtRespuesta = dataUtilities.ExecuteStoredProcedure("sp_ObtenerClientesFiltrados");

            foreach (DataRow item in dtRespuesta.Rows)
            {
                string idCliente = Convert.ToString(item["IdCliente"]);
                string nombreCliente = $"{Convert.ToString(item["Pnombre"])} {Convert.ToString(item["Snombre"])} {Convert.ToString(item["Papellido"])} {Convert.ToString(item["Sapellido"])}";
                string cedula = Convert.ToString(item["Cedula"]);
                string estado = Convert.ToString(item["Estado"]) == null || Convert.ToString(item["Estado"]) == "0" ? "Bloqueado" : "Activo";
                string direccion = Convert.ToString(item["Direccion"]) == null || Convert.ToString(item["Direccion"]).Trim() == "" ? "Desconocido" : Convert.ToString(item["Direccion"]);
                string pais = Convert.ToString(item["Pais"]) == null ? "Desconocido" : Convert.ToString(item["Pais"]);
                string departamento = Convert.ToString(item["Departamento"]) == null ? "Desconocido" : Convert.ToString(item["Departamento"]);
                string fechaNac = Convert.ToString(item["FechaNac"]);
                string telefono = Convert.ToString(item["Telefono"]) == null || Convert.ToString(item["Telefono"]).Trim() == "" || double.TryParse(Convert.ToString(item["Telefono"]).Trim(), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double valorNumericoTel) == false ? "Desconocido" : valorNumericoTel.ToString();
                string celular = Convert.ToString(item["Celular"]) == null || Convert.ToString(item["Celular"]).Trim() == "" || double.TryParse(Convert.ToString(item["Celular"]).Trim(), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double valorNumerico) == false ? "Desconocido" : valorNumerico.ToString();
                string edad = Convert.ToString(item["Edad"]) == "0" ? "Desconocido" : Convert.ToString(item["Edad"]);
                string profesion = Convert.ToString(item["Profesion"]) == null || Convert.ToString(item["Profesion"]).Trim() == "" ? "Desconocido" : Convert.ToString(item["Profesion"]);
                // string estadoCivil = Convert.ToString(item["EstadoCivil"]);
                string sexo = Convert.ToString(item["Sexo"]);

                dynamicDataTable.Rows.Add(idCliente, nombreCliente, cedula, estado, direccion, pais, departamento,
                                          fechaNac, telefono, celular, edad, profesion, sexo);
            }

            frm.DgvCliente.DataSource = dynamicDataTable;
            frm.DgvCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Actualizar la interfaz de usuario con la página actual y el total de páginas
            totalPages = (int)Math.Ceiling((double)dtRespuesta.Rows.Count / pageSize); // Si no se obtiene el total de páginas desde la consulta, lo calculamos aquí
            frm.TxtPaginaNo.Text = currentPage.ToString();
            frm.TxtPaginaDe.Text = totalPages.ToString();
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
                pnlVenta.vMOrdenes.auxClienteId = DgvCliente.SelectedRows[0].Cells[0].Value.ToString();

                DataTable dtResponse = dataUtilities.getRecordByPrimaryKey("Clientes", DgvCliente.SelectedRows[0].Cells[0].Value.ToString());

                if (Convert.ToString(dtResponse.Rows[0]["NoRuc"]) != "")
                {
                    pnlVenta.ChkRetencionAlcaldia.Visible = true;
                    pnlVenta.ChkRetencionDgi.Visible = true;
                }
                else
                {
                    pnlVenta.ChkRetencionAlcaldia.Visible = false;
                    pnlVenta.ChkRetencionDgi.Visible = false;
                }

                dataUtilities.SetColumns("ClienteId", pnlVenta.vMOrdenes.auxClienteId);
                dataUtilities.UpdateRecordByPrimaryKey("Ordenes",pnlVenta.vMOrdenes.OrdenAux);

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
               UpdatePagination(this);
            }
        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                UpdatePagination(this);
            }
        }

        private void CmbBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

