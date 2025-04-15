using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Wordprocessing;
using NeoCobranza.Data;
using NeoCobranza.DataController;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles_Contrato;
using NeoCobranza.Paneles_Venta;
using NeoCobranza.PanelesHoteles;
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
            DataTable dtResponseSegmentacion = dataUtilities.getRecordByColumn("SegmentacionCliente", "SucursalId", Utilidades.SucursalId);

            // Filtra las filas donde el campo Estado sea "Activo"
            var filterRowSeg = from row in dtResponseSegmentacion.AsEnumerable()
                               where Convert.ToString(row.Field<string>("Estado")) == "Activo"
                               select row;

            if (filterRowSeg.Any())
            {
                // Crea un DataTable para los datos filtrados
                DataTable dataCmbSucursal = new DataTable();
                dataCmbSucursal = filterRowSeg.CopyToDataTable();

                // Crea una nueva fila para "Mostrar Todo"
                DataRow newRow = dataCmbSucursal.NewRow();
                newRow["Clave"] = "0";
                newRow["Descripcion"] = "Sin Segmentación";

                // Inserta la nueva fila en la posición 0
                dataCmbSucursal.Rows.InsertAt(newRow, 0);

                // Configura el DataSource del combo box
                CmbSegmentacion.ValueMember = "Clave";
                CmbSegmentacion.DisplayMember = "Descripcion";
                CmbSegmentacion.DataSource = dataCmbSucursal;

                CmbSegmentacion.SelectedValue = "0";
            }

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
                    CmbBuscarPor.Items.Add("Código");
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
                dynamicDataTable.Columns.Add("RUC", typeof(string));
                dynamicDataTable.Columns.Add("Código", typeof(string));
                dynamicDataTable.Columns.Add("Segmentación", typeof(string));
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

            //string segmentacion = "0";

            //if (!string.IsNullOrEmpty(Convert.ToString(CmbSegmentacion.SelectedValue)))
            //{
            //    segmentacion = Convert.ToString(CmbSegmentacion.SelectedValue);
            //}

            //string sucursal = "0";

            //if (!string.IsNullOrEmpty(Convert.ToString(CmbSucursal.SelectedValue)))
            //{
            //    sucursal = Convert.ToString(CmbSucursal.SelectedValue);
            //}

            //dynamicDataTable.Rows.Clear();

            //dataUtilities.SetParameter("@FiltroPor", CmbBuscarPor.SelectedIndex);
            //dataUtilities.SetParameter("@FiltroValor", txtFiltro.Texts);
            //dataUtilities.SetParameter("@IdSucursal", sucursal);
            //dataUtilities.SetParameter("@SegmentacionId", segmentacion);
            //dataUtilities.SetParameter("@PageNumber", 1);
            //dataUtilities.SetParameter("@PageSize", pageSize);

            //DataTable dtRespuesta = new DataTable();
            //dtRespuesta = dataUtilities.ExecuteStoredProcedure("sp_ObtenerClientesFiltrados");

            //// Para obtener el número total de páginas
            //totalPages = (int)Math.Ceiling((double)dtRespuesta.Rows.Count / pageSize);
            UpdatePagination(this); // Actualiza la paginación en el formulario
        }

        public void UpdatePagination(Panel_Cliente_Contrato frm)
        {
            int pageNumber = 1;
            if (!int.TryParse(frm.TxtPaginaNo.Text, out pageNumber))
            {
                pageNumber = 1;
                frm.TxtPaginaNo.Text = "1";
            }

            // Definir el tamaño de página (por ejemplo, 20 registros por página)
            int pageSize = 20;

            // Este método se llamará desde los botones "Siguiente" y "Anterior"
            string segmentacion = "0";
            if (frm.CmbSegmentacion.SelectedValue != null)
            {
                segmentacion = frm.CmbSegmentacion.SelectedValue.ToString();
            }

            string sucursal = "0";
            if (frm.CmbSucursal.SelectedValue != null)
            {
                sucursal = frm.CmbSucursal.SelectedValue.ToString();
            }

            int filtroPor = frm.CmbBuscarPor.SelectedIndex;
            string filtroValor = frm.txtFiltro.Texts.Trim();

            dataUtilities.ClearParameters();

            if (!Utilidades.PermisosLevel(3, 75))
            {
                dataUtilities.SetParameter("@UsuarioId", Utilidades.IdUsuario);
            }
            else
            {
                dataUtilities.SetParameter("@UsuarioId", "0");
            }

            dataUtilities.SetParameter("@FiltroPor", filtroPor);
            dataUtilities.SetParameter("@FiltroValor", filtroValor);
            dataUtilities.SetParameter("@IdSucursal", sucursal);
            dataUtilities.SetParameter("@SegmentacionId", segmentacion);
            dataUtilities.SetParameter("@PageNumber", pageNumber);
            dataUtilities.SetParameter("@PageSize", pageSize);
            dataUtilities.SetParameter("@TotalPages", SqlDbType.Int, ParameterDirection.Output);

            DataTable dtDatos = dataUtilities.ExecuteStoredProcedure("sp_ObtenerClientesFiltrados");

            string totalRecords = Convert.ToString(dataUtilities.GetParameterValue("@TotalPages"));

            dynamicDataTable.Rows.Clear();
            foreach (DataRow row in dtDatos.Rows)
            {
                string idCliente = Convert.ToString(row["IdCliente"]);
                string nombreCliente = $"{Convert.ToString(row["Pnombre"])} {Convert.ToString(row["Snombre"])} {Convert.ToString(row["Papellido"])} {Convert.ToString(row["Sapellido"])}";
                string cedula = Convert.ToString(row["Cedula"]);
                string estado = (Convert.ToString(row["Estado"]) == "0" || string.IsNullOrEmpty(Convert.ToString(row["Estado"]))) ? "Bloqueado" : "Activo";
                string direccion = string.IsNullOrWhiteSpace(Convert.ToString(row["Direccion"])) ? "Desconocido" : Convert.ToString(row["Direccion"]);
                string pais = string.IsNullOrWhiteSpace(Convert.ToString(row["Pais"])) ? "Desconocido" : Convert.ToString(row["Pais"]);
                string departamento = string.IsNullOrWhiteSpace(Convert.ToString(row["Departamento"])) ? "Desconocido" : Convert.ToString(row["Departamento"]);
                string fechaNac = Convert.ToString(row["FechaNac"]);
                string telefono = string.IsNullOrWhiteSpace(Convert.ToString(row["Telefono"])) ? "Desconocido" : Convert.ToString(row["Telefono"]);
                string celular = string.IsNullOrWhiteSpace(Convert.ToString(row["Celular"])) ? "Desconocido" : Convert.ToString(row["Celular"]);
                string edad = (Convert.ToString(row["Edad"]) == "0") ? "Desconocido" : Convert.ToString(row["Edad"]);
                string profesion = string.IsNullOrWhiteSpace(Convert.ToString(row["Profesion"])) ? "Desconocido" : Convert.ToString(row["Profesion"]);
                string sexo = Convert.ToString(row["Sexo"]);
                string ruc = (row["NoRuc"] == DBNull.Value || string.IsNullOrWhiteSpace(Convert.ToString(row["NoRuc"]))) ? "" : Convert.ToString(row["NoRuc"]);
                string codigo = (row["Codigo"] == DBNull.Value || string.IsNullOrWhiteSpace(Convert.ToString(row["Codigo"]))) ? "" : Convert.ToString(row["Codigo"]);
                string descripcion = (row["SegmentacionId"] == DBNull.Value || Convert.ToString(row["SegmentacionId"]) == "0") ? "Sin Segmentar" : Convert.ToString(row["Descripcion"]);

                dynamicDataTable.Rows.Add(idCliente, nombreCliente, ruc, codigo, descripcion, cedula, estado,
                                            direccion, pais, departamento, fechaNac, telefono, celular,
                                            edad, profesion, sexo);
            }

            frm.DgvCliente.DataSource = dynamicDataTable;
            frm.DgvCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            frm.TxtPaginaDe.Text = totalRecords.ToString();
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
                pnlProforma.lblEstadoCliente.ForeColor = System.Drawing.Color.Green;
                pnlProforma.lblIdCliente.Text = DgvCliente.SelectedRows[0].Cells[0].Value.ToString();
                this.Hide();
            }
            if (panel == "Reserva")
            {

                PnlAgregarReservacion pnlProforma = Owner as PnlAgregarReservacion;
                pnlProforma.TxtNombreCliente.Text = DgvCliente.SelectedRows[0].Cells[1].Value.ToString();
                pnlProforma.auxIdCliente = DgvCliente.SelectedRows[0].Cells[0].Value.ToString();
                pnlProforma.TxtCelular.Text = DgvCliente.SelectedRows[0].Cells[12].Value.ToString();
                pnlProforma.TxtIdentificacion.Text = DgvCliente.SelectedRows[0].Cells[5].Value.ToString();
                this.Hide();

            }
            if (panel == "ContratoProforma")
            {

                PnlProformaContrato pnlProformaContrato = Owner as PnlProformaContrato;
                pnlProformaContrato.lblNombreCliente.Text = DgvCliente.SelectedRows[0].Cells[1].Value.ToString();

                pnlProformaContrato.lblEstadoCliente.Text = "Cliente Seleccionado";
                pnlProformaContrato.lblEstadoCliente.ForeColor = System.Drawing.Color.Green;
                pnlProformaContrato.lblIdCliente.Text = DgvCliente.SelectedRows[0].Cells[0].Value.ToString();
                this.Hide();


            }
            if (panel == "Venta")
            {
                //validar que el cliente ya tenga una orden
                dataUtilities.SetParameter("@idCliente", DgvCliente.SelectedRows[0].Cells[0].Value.ToString());
                DataTable dtResponseValidacion = dataUtilities.ExecuteStoredProcedure("sp_ObtenerOrdenesCliente");

                if (dtResponseValidacion.Rows.Count > 0)
                {
                    DialogResult result = MessageBox.Show($"El cliente ya tiene una orden activa / Orden No: {Convert.ToString(dtResponseValidacion.Rows[0]["OrdenId"])} ¿Desea continuar?", "Confirmación",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result != DialogResult.Yes)
                    {
                        this.Close();
                        return;
                    }
                }

                PnlVentas pnlVenta = Owner as PnlVentas;
                pnlVenta.LblNombreClientes.Text = DgvCliente.SelectedRows[0].Cells[1].Value.ToString();
                pnlVenta.vMOrdenes.auxClienteId = DgvCliente.SelectedRows[0].Cells[0].Value.ToString();

                DataTable dtResponse = dataUtilities.getRecordByPrimaryKey("Clientes", DgvCliente.SelectedRows[0].Cells[0].Value.ToString());

                if (Convert.ToString(dtResponse.Rows[0]["NoRuc"]) != "")
                {
                    if (Utilidades.PermisosLevel(3, 31))
                    {
                        pnlVenta.ChkRetencionAlcaldia.Visible = true;
                        pnlVenta.ChkRetencionDgi.Visible = true;
                    }
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
            if (panel == "Agenda")
            {
                //Obtener la agenda
                PnlAgenda pnlAgenda = Owner as PnlAgenda;

                //Obtener datos
                string nombreCliente = DgvCliente.SelectedRows[0].Cells[1].Value.ToString();
                string IdCliente = DgvCliente.SelectedRows[0].Cells[0].Value.ToString();

                //Abrir el Agendar
                PnlAgendar pnlAgendar = new PnlAgendar(pnlAgenda,nombreCliente,IdCliente);
                pnlAgendar.ShowDialog();

                this.Hide();
            }
            if(panel == "AgendaConfiguracion")
            {
                PnlAgendaCambioUsuario pnlAgendaCambioUsuario = Owner as PnlAgendaCambioUsuario;
                pnlAgendaCambioUsuario.TxtNombreCliente.Text = DgvCliente.SelectedRows[0].Cells[1].Value.ToString();
                pnlAgendaCambioUsuario.UsuarioId = DgvCliente.SelectedRows[0].Cells[0].Value.ToString();

                this.Close();
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
            if (int.TryParse(TxtPaginaNo.Text, out int currentPage) &&
                int.TryParse(TxtPaginaDe.Text, out int totalPages) &&
                currentPage < totalPages)
            {
                currentPage++;
                TxtPaginaNo.Text = currentPage.ToString();
                FiltrarClientes();
                ActualizarEstadoBotones();
            }
        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TxtPaginaNo.Text, out int currentPage) && currentPage > 1)
            {
                currentPage--;
                TxtPaginaNo.Text = currentPage.ToString();
                FiltrarClientes();
                ActualizarEstadoBotones();
            }
        }

        private void ActualizarEstadoBotones()
        {
            // Habilita o deshabilita según el número de página actual y el total de páginas
            if (int.TryParse(TxtPaginaNo.Text, out int currentPage) &&
                int.TryParse(TxtPaginaDe.Text, out int totalPages))
            {
                BtnAnterior.Enabled = currentPage > 1;
                BtnSiguiente.Enabled = currentPage < totalPages;
            }
        }

        private void CmbBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarClientes();
        }

        private void CmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarClientes();
        }

        private void CmbSegmentacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarClientes();
        }
    }
}

