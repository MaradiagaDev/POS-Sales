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
using System.Windows.Media.Animation;

namespace NeoCobranza.Paneles_Venta
{
    public partial class frmAgregarProductosServicios : Form
    {
        DataUtilities dataUtilities = new DataUtilities();
        public DataTable dynamicDataTableProductos = new DataTable();
        PnlPrincipal auxPnlPrincipal;
        decimal auxOrdenId;
        string auxOpc;
        bool auxDgi;
        bool auxAlcaldia;
        string auxDescuento;

        public frmAgregarProductosServicios(PnlPrincipal frmPrincipal, decimal ordenId, string opc,bool dgi, bool alcaldia, string descuento)
        {
            InitializeComponent();
            UIUtilities.PersonalizarDataGridView(DgvProductos);
            auxPnlPrincipal = frmPrincipal;
            auxOrdenId = ordenId;
            auxOpc = opc;
            auxDgi = dgi;
            auxAlcaldia = alcaldia;
            ConfigUI();
            auxDescuento = descuento;
        }

        private void ConfigUI()
        {
            switch (auxOpc)
            {
                case "Productos":
                    llbTitulo.Text = "Agregar Producto a la Orden";

                    if (dynamicDataTableProductos.Columns.Count < 3)
                    {
                        dynamicDataTableProductos.Columns.Add("Id", typeof(string));
                        dynamicDataTableProductos.Columns.Add("Producto", typeof(string));
                        dynamicDataTableProductos.Columns.Add("Precio Unitario (NIO)", typeof(string));
                        dynamicDataTableProductos.Columns.Add("Cantidad", typeof(string));
                        //dynamicDataTableProductos.Columns.Add($"Precio Unitario $ ({Utilidades.Tasa})", typeof(string));

                        DgvProductos.DataSource = dynamicDataTableProductos;

                        DgvProductos.Columns[0].Visible = false;

                        // Agregar una columna de botón
                        DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                        buttonColumn.HeaderText = "...";
                        buttonColumn.Text = "Agregar a Venta";
                        buttonColumn.UseColumnTextForButtonValue = true;
                        DgvProductos.Columns.Add(buttonColumn);

                        DataGridViewButtonColumn buttonColumnDisponibilidad = new DataGridViewButtonColumn();
                        buttonColumnDisponibilidad.HeaderText = "...";
                        buttonColumnDisponibilidad.Text = "Disponibilidad";
                        buttonColumnDisponibilidad.UseColumnTextForButtonValue = true;
                        DgvProductos.Columns.Add(buttonColumnDisponibilidad);
                    }

                    //Llenar los tipos de servicio

                    DataTable dtResponse = dataUtilities.GetAllRecords("Categorizacion");
                    var filterRow = from row in dtResponse.AsEnumerable() where Convert.ToString(row.Field<string>("Estado")) == "Activo" select row;

                    if (filterRow.Any())
                    {
                        DataTable dataCmbTipoServicio = new DataTable();
                        dataCmbTipoServicio = filterRow.CopyToDataTable();
                        DataRow newRow = dataCmbTipoServicio.NewRow();
                        newRow["CategorizacionId"] = "0";
                        newRow["Descripcion"] = "Mostrar Todo";
                        newRow["Estado"] = "Activo";

                        dataCmbTipoServicio.Rows.InsertAt(newRow, 0);

                        CmbTipoServicio.ValueMember = "CategorizacionId";
                        CmbTipoServicio.DisplayMember = "Descripcion";
                        CmbTipoServicio.DataSource = dataCmbTipoServicio;
                    }
                    break;
                case "Servicios":
                    llbTitulo.Text = "Agregar Servicios a la Orden";

                    if (dynamicDataTableProductos.Columns.Count < 3)
                    {
                        dynamicDataTableProductos.Columns.Add("Id", typeof(string));
                        dynamicDataTableProductos.Columns.Add("Servicios", typeof(string));
                        dynamicDataTableProductos.Columns.Add("Precio Unitario (NIO)", typeof(string));
                        dynamicDataTableProductos.Columns.Add("Cantidad", typeof(string));
                        //dynamicDataTableProductos.Columns.Add($"Precio Unitario $ ({Utilidades.Tasa})", typeof(string));

                        DgvProductos.DataSource = dynamicDataTableProductos;

                        DgvProductos.Columns[0].Visible = false;

                        // Agregar una columna de botón
                        DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                        buttonColumn.HeaderText = "...";
                        buttonColumn.Text = "Agregar a Venta";
                        buttonColumn.UseColumnTextForButtonValue = true;
                        DgvProductos.Columns.Add(buttonColumn);

                        DataGridViewButtonColumn buttonColumnDisponibilidad = new DataGridViewButtonColumn();
                        buttonColumnDisponibilidad.HeaderText = "...";
                        buttonColumnDisponibilidad.Text = "Disponibilidad";
                        buttonColumnDisponibilidad.UseColumnTextForButtonValue = true;
                        DgvProductos.Columns.Add(buttonColumnDisponibilidad);
                    }

                    //Llenar los tipos de servicio

                    DataTable dtResponseServicios = dataUtilities.GetAllRecords("Categorizacion");
                    var filterRowServicios = from row in dtResponseServicios.AsEnumerable() where Convert.ToString(row.Field<string>("Estado")) == "Activo" select row;

                    if (filterRowServicios.Any())
                    {
                        DataTable dataCmbTipoServicio = new DataTable();
                        dataCmbTipoServicio = filterRowServicios.CopyToDataTable();
                        DataRow newRow = dataCmbTipoServicio.NewRow();
                        newRow["CategorizacionId"] = "0";
                        newRow["Descripcion"] = "Mostrar Todo";
                        newRow["Estado"] = "Actio";

                        dataCmbTipoServicio.Rows.InsertAt(newRow, 0);

                        CmbTipoServicio.ValueMember = "CategorizacionId";
                        CmbTipoServicio.DisplayMember = "Descripcion";
                        CmbTipoServicio.DataSource = dataCmbTipoServicio;
                    }

                    break;
            }

            Buscar();
        }

        private void Buscar()
        {
            switch (auxOpc)
            {
                case "Productos":
                    dynamicDataTableProductos.Rows.Clear();

                    //OBTENER EL ALMACEN MOSTRADOR
                    DataTable dtResponse = dataUtilities.GetAllRecords("Almacenes");
                    var filterRow =
                        from row in dtResponse.AsEnumerable()
                        where Convert.ToBoolean(row.Field<bool>("EsMostrador")) == true
                        && Convert.ToString(row.Field<string>("SucursalId")) == Utilidades.SucursalId
                        select row;

                    if (filterRow.Any())
                    {
                        DataTable dtAlmacenMostrador = filterRow.CopyToDataTable();

                        //REALIZAR EL FILTRADO
                        dataUtilities.SetParameter("@AlmacenId", Convert.ToString(dtAlmacenMostrador.Rows[0]["AlmacenId"]));
                        dataUtilities.SetParameter("@CategoriaId", CmbTipoServicio.SelectedValue);
                        dataUtilities.SetParameter("@Filtro", TxtBuscarProductos.Texts);
                        DataTable dtResponseSp1 = dataUtilities.ExecuteStoredProcedure("sp_ObtenerCantidadProductoPorAlmacen");

                        foreach (DataRow row in dtResponseSp1.Rows)
                        {
                            dynamicDataTableProductos.Rows.Add(Convert.ToString(row["ID"]),
                                Convert.ToString(row["PRODUCTO"]), Convert.ToString(row[2]), Convert.ToString(row[3]));
                        }

                        DgvProductos.DataSource = dynamicDataTableProductos;
                    }
                    else
                    {
                        MessageBox.Show("Debe agregar un almacén mostrador.", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Close();
                    }
                    break;
                case "Servicios":
                    dynamicDataTableProductos.Rows.Clear();

                    dataUtilities.SetParameter("@CategoriaId", CmbTipoServicio.SelectedValue);
                    dataUtilities.SetParameter("@Filtro", TxtBuscarProductos.Texts);
                    DataTable dtResponseSp = dataUtilities.ExecuteStoredProcedure("sp_ObtenerServicios");

                    foreach (DataRow row in dtResponseSp.Rows)
                    {
                        dynamicDataTableProductos.Rows.Add(Convert.ToString(row["ID"]),
                            Convert.ToString(row["SERVICIO"]), Convert.ToString(row[2]));
                    }
                    break;
            }
        }

        private void TxtBuscarProductos__TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void DgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (auxOpc == "Productos")
                {
                    object cellValue = DgvProductos.Rows[e.RowIndex].Cells[2].Value;
                    PnlDisponibilidad disponibilidad = new PnlDisponibilidad(cellValue.ToString());
                    disponibilidad.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No se puede revisar la disponibilidad en servicios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

            if (e.ColumnIndex == 0)
            {
                int Prueba;
                if (int.TryParse(TxtCantidadProducto.Text.Trim(), out Prueba) == false || TxtCantidadProducto.Text.Trim() == "0"
                    || TxtCantidadProducto.Text.Trim() == "00" || TxtCantidadProducto.Text.Trim() == "000" || TxtCantidadProducto.Text.Trim() == "0000")
                {
                    MessageBox.Show("Debe agregar una cantidad valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtCantidadProducto.Text = "1";
                    return;
                }

                object cellValue = DgvProductos.Rows[e.RowIndex].Cells[2].Value;

                AgregarProductosOrden(cellValue.ToString(), TxtCantidadProducto.Text.Trim(), "Increase");
            }
        }

        public void AgregarProductosOrden(string idProd, string Cantidad, string opc)
        {
            DataRow itemProductoAux = dataUtilities.getRecordByPrimaryKey("ProductosServicios", idProd).Rows[0];

            if (Convert.ToString(itemProductoAux["ClasificacionProducto"]) == "Productos")
            {
                //OBTENER EL ALMACEN MOSTRADOR
                DataTable dtResponse = dataUtilities.GetAllRecords("Almacenes");
                var filterRow =
                    from row in dtResponse.AsEnumerable()
                    where Convert.ToBoolean(row.Field<bool>("EsMostrador")) == true
                    && Convert.ToString(row.Field<string>("SucursalId")) == Utilidades.SucursalId
                    select row;

                if (filterRow.Any())
                {
                    DataTable dtAlmacenMostrador = filterRow.CopyToDataTable();

                    //VERIFICAR EL STOCK
                    dataUtilities.SetParameter("@ProductId", idProd);
                    dataUtilities.SetParameter("@WarehouseId", dtAlmacenMostrador.Rows[0]["AlmacenId"]);
                    dataUtilities.SetParameter("@Quantity", Cantidad);

                    DataTable dtReponseStock = dataUtilities.ExecuteStoredProcedure("sp_CheckInventory");

                    if (Convert.ToString(dtReponseStock.Rows[0][0]) == "1")
                    {
                        if (MessageBox.Show("El inventario es insuficiente. ¿Deseas continuar?",
                                     "Advertencia",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            //realizar operacion

                            dataUtilities.SetParameter("@OrderId", auxOrdenId);
                            dataUtilities.SetParameter("@ProductId", idProd);
                            dataUtilities.SetParameter("@Quantity", Cantidad);
                            dataUtilities.SetParameter("@Action", opc);
                            dataUtilities.SetParameter("@WarehouseId", dtAlmacenMostrador.Rows[0]["AlmacenId"]);
                            dataUtilities.SetParameter("@Discount", 0);
                            dataUtilities.SetParameter("@Total", 0);
                            dataUtilities.SetParameter("@Subtotal", 0);
                            dataUtilities.SetParameter("@IVA", 0);

                            DataTable dtResponseTotales = dataUtilities.ExecuteStoredProcedure("sp_ManageOrderDetail");

                            if (opc == "Increase")
                            {
                                var informativeMessageBox = new InformativeMessageBox($"Producto Agregado Correctamente a la Orden.",
                                    "Producto Agregado", 3000);
                                informativeMessageBox.Show();
                            }
                            else
                            {
                                var informativeMessageBox = new InformativeMessageBox($"Producto Restado Correctamente de la Orden.",
                                   "Producto Restado", 3000);
                                informativeMessageBox.Show();
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        //realizar operacion

                        dataUtilities.SetParameter("@OrderId", auxOrdenId);
                        dataUtilities.SetParameter("@ProductId", idProd);
                        dataUtilities.SetParameter("@Quantity", Cantidad);
                        dataUtilities.SetParameter("@Action", opc);
                        dataUtilities.SetParameter("@WarehouseId", dtAlmacenMostrador.Rows[0]["AlmacenId"]);
                        dataUtilities.SetParameter("@Discount", 0);
                        dataUtilities.SetParameter("@Total", 0);
                        dataUtilities.SetParameter("@Subtotal", 0);
                        dataUtilities.SetParameter("@IVA", 0);

                        DataTable dtResponseTotales = dataUtilities.ExecuteStoredProcedure("sp_ManageOrderDetail");

                        if (opc == "Increase")
                        {
                            var informativeMessageBox = new InformativeMessageBox($"Producto Agregado Correctamente a la Orden.",
                                "Producto Agregado", 3000);
                            informativeMessageBox.Show();
                        }
                        else
                        {
                            var informativeMessageBox = new InformativeMessageBox($"Producto Restado Correctamente de la Orden.",
                               "Producto Restado", 3000);
                            informativeMessageBox.Show();
                        }
                    }
                }
            }
            else
            {
                //FALTAN LOS SERVICIOS
                dataUtilities.SetParameter("@OrderId", auxOrdenId);
                dataUtilities.SetParameter("@ServiceId", idProd);
                dataUtilities.SetParameter("@Quantity", Cantidad);
                dataUtilities.SetParameter("@Action", opc);
                dataUtilities.SetParameter("@Discount", 0);
                dataUtilities.SetParameter("@Total", 0);
                dataUtilities.SetParameter("@Subtotal", 0);
                dataUtilities.SetParameter("@IVA", 0);

                DataTable dtResponseTotales = dataUtilities.ExecuteStoredProcedure("sp_ManageOrderServiceDetail");


                if (opc == "Increase")
                {
                    var informativeMessageBox = new InformativeMessageBox($"Servicio Agregado Correctamente a la Orden.",
                        "Servicio Agregado", 3000);
                    informativeMessageBox.Show();
                }
                else
                {
                    var informativeMessageBox = new InformativeMessageBox($"Servicio Restado Correctamente de la Orden.",
                       "Servicio Restado", 3000);
                    informativeMessageBox.Show();
                }

            }

            CalcularTotales(auxDescuento);
        }

        public void CalcularTotales( string descuento)
        {
            DataTable dtResponse = dataUtilities.getRecordByColumn("ConfigFacturacion", "SucursalId", Utilidades.SucursalId);

            dataUtilities.SetParameter("@IdOrden", auxOrdenId);
            dataUtilities.SetParameter("@AplicaRetencionDgi", auxDgi);
            dataUtilities.SetParameter("@AplicaRetencionAlcaldia", auxAlcaldia);
            dataUtilities.SetParameter("@DescuentoAdicional", descuento);
            dataUtilities.SetParameter("@CalcularIVA", Convert.ToBoolean(dtResponse.Rows[0]["RetieneIvaBit"]));

            dataUtilities.ExecuteStoredProcedure("Sp_CalcularTotalesOrden");

            DataTable dtResponseOrden = dataUtilities.getRecordByPrimaryKey("Ordenes", auxOrdenId);
            DataRow orden = dtResponseOrden.Rows[0];

        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            auxPnlPrincipal.AbrirVenta(auxOrdenId);
        }
    }
}
