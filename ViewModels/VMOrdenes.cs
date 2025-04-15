using NeoCobranza.Clases;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles;
using NeoCobranza.Paneles_Venta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.SqlServer;
using System.Drawing;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NeoCobranza.ViewModels
{
    public class VMOrdenes
    {
        DataUtilities dataUtilities = new DataUtilities();

        public DataTable dynamicDataTable = new DataTable();
        public DataTable dynamicDataTableProductos = new DataTable();
        public DataTable dynamicDataTableOrdenes = new DataTable();

        public string auxSubModulo;
        public string auxAccion;

        public string auxUsuarioId = "";
        public string auxClienteId = "0";

        //Nuevos
        public decimal OrdenAux = 0;
        public string MesaAux = "-";

        public void InitModuloOrdenes(PnlVentas frm, string opc, string key)
        {
            switch (opc)
            {
                case "OrdenRapida":

                    frm.llbTitulo.Text = "Ventas";

                    //frm.TCMain.SelectedIndex = 0;

                    frm.TxtCodigoProducto.Focus();
                    frm.ChkRetencionAlcaldia.Enabled = true;
                    frm.ChkRetencionDgi.Enabled = true;

                    frm.LblEstadoOrden.Text = "Orden Abierta";
                    frm.LblFechaGeneracion.Text = DateTime.Now.ToString();

                    frm.LblProcesoPago.Text = "Sin Pagos";

                    frm.BtnPagarOrden.Enabled = false;

                    frm.ChkRetencionDgi.Visible = false;
                    frm.ChkRetencionAlcaldia.Visible = false;

                    if (dynamicDataTable.Columns.Count == 0)
                    {
                        dynamicDataTable.Columns.Add("Id Detalle", typeof(string));
                        dynamicDataTable.Columns.Add("Codigo", typeof(string));
                        dynamicDataTable.Columns.Add("Id Producto", typeof(string));
                        dynamicDataTable.Columns.Add("Producto", typeof(string));
                        dynamicDataTable.Columns.Add("Cantidad", typeof(string));
                        dynamicDataTable.Columns.Add("Precio Unitario", typeof(string));
                        dynamicDataTable.Columns.Add("SubTotal", typeof(string));

                        DataGridViewButtonColumn buttonColumnAdd = new DataGridViewButtonColumn();
                        buttonColumnAdd.HeaderText = "...";
                        buttonColumnAdd.Text = " Agregar ";
                        buttonColumnAdd.UseColumnTextForButtonValue = true;
                        buttonColumnAdd.Name = "Agregar";

                        DataGridViewButtonColumn buttonColumnDelete = new DataGridViewButtonColumn();
                        buttonColumnDelete.HeaderText = "...";
                        buttonColumnDelete.Text = " Quitar ";
                        buttonColumnDelete.UseColumnTextForButtonValue = true;
                        buttonColumnDelete.Name = "Quitar";

                        DataGridViewButtonColumn buttonColumnDeleteAll = new DataGridViewButtonColumn();
                        buttonColumnDeleteAll.HeaderText = "...";
                        buttonColumnDeleteAll.Text = " Quitar Todo ";
                        buttonColumnDeleteAll.UseColumnTextForButtonValue = true;
                        buttonColumnDeleteAll.Name = "Todo";

                        frm.DgvItemsOrden.DataSource = dynamicDataTable;
                        frm.DgvItemsOrden.Columns.Add(buttonColumnAdd);
                        frm.DgvItemsOrden.Columns.Add(buttonColumnDelete);
                        frm.DgvItemsOrden.Columns.Add(buttonColumnDeleteAll);

                        frm.DgvItemsOrden.Columns[0].Visible = false;
                        frm.DgvItemsOrden.Columns[2].Visible = false;
                    }
                    //Generales
                    auxSubModulo = "Orden";
                    auxAccion = "Crear";

                    DataTable dtResponseClienteCreacion = dataUtilities.getRecordByPrimaryKey("Clientes", Convert.ToDecimal(frm.auxClienteCreacion));

                    if (dtResponseClienteCreacion.Rows.Count > 0)
                    {
                        DataRow rowResponseCliente = dtResponseClienteCreacion.Rows[0];

                        if (Convert.ToString(rowResponseCliente["NoRuc"]).Trim().Length > 0)
                        {
                            frm.ChkRetencionAlcaldia.Visible = true;
                            frm.ChkRetencionDgi.Visible = true;
                        }
                        else
                        {
                            frm.ChkRetencionAlcaldia.Visible = false;
                            frm.ChkRetencionDgi.Visible = false;
                        }

                        frm.LblNombreClientes.Text =
                            Convert.ToString(rowResponseCliente["PNombre"]) + " " +
                            Convert.ToString(rowResponseCliente["SNombre"]) + " " +
                            Convert.ToString(rowResponseCliente["PApellido"]) + " " +
                            Convert.ToString(rowResponseCliente["SAPellido"]);
                    }
                    else
                    {
                        frm.LblNombreClientes.Text = "CLIENTE MOSTRADOR";
                        auxClienteId = "";
                    }


                    //agregar el empleado
                    DataTable dtResponseUsuario = dataUtilities.getRecordByPrimaryKey("Usuario", Utilidades.IdUsuario);
                    DataTable dtResponseEmpleado = dataUtilities.getRecordByPrimaryKey("Empleado", Convert.ToString(dtResponseUsuario.Rows[0]["IdEmpleado"]));

                    frm.LblNombreVendedor.Text = Convert.ToString(dtResponseEmpleado.Rows[0]["Nombre"]) + " "
                        + Convert.ToString(dtResponseEmpleado.Rows[0]["Apellido"]);

                    //CREAR ORDEN
                    //OBTENER LA CONFIGURACION DE FACTURACION
                    DataTable dtConfigFacturacion = dataUtilities.getRecordByColumn("ConfigFacturacion", "SucursalId", Utilidades.SucursalId);

                    if (dtConfigFacturacion.Rows.Count == 0)
                    {
                        MessageBox.Show("Debe agregar una configuración de facturación para poder realizar ordenes.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        frm.Close();
                        return;
                    }

                    if (OrdenAux == 0)
                    {
                        if (MesaAux == "-")
                        {
                            frm.LblOrdenMesa.Visible = false;
                            frm.LblTituloSala.Visible = false;
                            frm.ChkPropina.Visible = false;
                            frm.BtnDesvincular.Visible = false;
                        }
                        else
                        {
                            frm.BtnCredito.Visible = false;
                        }

                        //Actualizar la configuración de facturacion

                        decimal NoOrden = Convert.ToDecimal(dtConfigFacturacion.Rows[0]["ConsecutivoOrden"]) + 1;

                        dataUtilities.SetColumns("ConsecutivoOrden", NoOrden);

                        dataUtilities.UpdateRecordByPrimaryKey(
                            "ConfigFacturacion",
                            Convert.ToString(dtConfigFacturacion.Rows[0]["ConfigFacturacionId"]));

                        //Obtener la tasa de cambio
                        DataTable tasaData = dataUtilities.GetAllRecords("vwTasa");

                        decimal tasaCambio = 0;

                        if (tasaData.Rows.Count > 0)
                        {
                            tasaCambio = decimal.Parse(tasaData.Rows[0][1].ToString());
                        }

                        auxClienteId = frm.auxClienteCreacion;

                        //Insertar la orden
                        dataUtilities.SetColumns("SucursalId", Utilidades.SucursalId);
                        dataUtilities.SetColumns("UsuarioId", Utilidades.Usuario);
                        dataUtilities.SetColumns("ClienteId", auxClienteId);
                        dataUtilities.SetColumns("NoFactura", "0");
                        dataUtilities.SetColumns("OrdenId", NoOrden);
                        dataUtilities.SetColumns("Serie", "-");
                        dataUtilities.SetColumns("SalaMesa", MesaAux);
                        dataUtilities.SetColumns("TotalOrden", 0);
                        dataUtilities.SetColumns("Descuento", 0);
                        dataUtilities.SetColumns("Iva", 0);
                        dataUtilities.SetColumns("RetencionDgi", 0);
                        dataUtilities.SetColumns("RetencionAlcaldia", 0);
                        dataUtilities.SetColumns("SubTotal", 0);
                        dataUtilities.SetColumns("OrdenProceso", "Orden Abierta");
                        dataUtilities.SetColumns("PagoProceso", "Sin Pagos");
                        dataUtilities.SetColumns("MotivoCancelacion", "");
                        dataUtilities.SetColumns("FechaRealizacion", DateTime.Now);
                        dataUtilities.SetColumns("CambioDolar", tasaCambio);
                        dataUtilities.SetColumns("CorteCaja", false);
                        dataUtilities.SetColumns("NotaOrden", "");
                        dataUtilities.SetColumns("Pagado", 0);
                        dataUtilities.SetColumns("RestantePago", 0);
                        dataUtilities.SetColumns("BitEsCredito", false);
                        dataUtilities.SetColumns("CantidadPagos", "");
                        dataUtilities.SetColumns("FrecuenciaPagos", "");
                        dataUtilities.SetColumns("MontoCredito", 0);
                        dataUtilities.SetColumns("FechaCredito", DateTime.Now);
                        dataUtilities.SetColumns("BitPropina", true);

                        dataUtilities.InsertRecord("Ordenes");

                        OrdenAux = NoOrden;

                        frm.LblNoOrden.Text = NoOrden.ToString();
                        frm.LblEstadoOrden.Text = "Orden Abierta";
                        frm.LblFechaGeneracion.Text = DateTime.Now.ToString();
                        frm.LblProcesoPago.Text = "Sin Pagos";
                        frm.LblOrdenMesa.Text = MesaAux;
                        frm.ChkPropina.Checked = true;

                        frm.TxtSubTotal.Text = "0";
                        frm.TxtIVA.Text = "0";
                        frm.TxtDescuento.Text = "0";
                        frm.TxtRetencionDGI.Text = "0";
                        frm.TxtRetencionAlcaldia.Text = "0";
                        frm.TxtTotalCordoba.Text = "0";
                        frm.TxtTotalDolar.Text = "0";
                        frm.TxtTotalPagado.Text = "0";

                    }
                    else
                    {
                        frm.BtnAgregarPro.Enabled = true;
                        frm.BtnAgregarServicio.Enabled = true;
                        frm.BtnPagarOrden.Enabled = true;
                        frm.BtnCancelarOrden.Enabled = true;
                        frm.TxtCodigoProducto.Enabled = true;
                        //Orden abierta
                        //Consultar Orden

                        dataUtilities.SetParameter("@Orden", OrdenAux);
                        dataUtilities.SetParameter("@sucursal", frm.auxSucursal);
                        DataTable dtResponseOrden = dataUtilities.ExecuteStoredProcedure("ObtenerOrdenSucursal");

                        DataRow orden = dtResponseOrden.Rows[0];

                        if (Convert.ToDecimal(orden["Pagado"]) > 0)
                        {

                            frm.ChkRetencionAlcaldia.Enabled = false;
                            frm.ChkRetencionDgi.Enabled = false;
                        }

                        DataTable dtResponseCliente = dataUtilities.getRecordByPrimaryKey("Clientes", Convert.ToDecimal(orden["ClienteId"]));
                        auxClienteId = Convert.ToString(orden["ClienteId"]);

                        if (dtResponseCliente.Rows.Count > 0)
                        {
                            DataRow rowResponseCliente = dtResponseCliente.Rows[0];

                            if (Convert.ToString(rowResponseCliente["NoRuc"]).Trim().Length > 0)
                            {
                                if (Utilidades.PermisosLevel(3, 31))
                                {
                                    frm.ChkRetencionAlcaldia.Visible = true;
                                    frm.ChkRetencionDgi.Visible = true;
                                }
                            }
                            else
                            {
                                frm.ChkRetencionAlcaldia.Visible = false;
                                frm.ChkRetencionDgi.Visible = false;
                            }

                            frm.LblNombreClientes.Text =
                                Convert.ToString(rowResponseCliente["PNombre"]) + " " +
                                Convert.ToString(rowResponseCliente["SNombre"]) + " " +
                                Convert.ToString(rowResponseCliente["PApellido"]) + " " +
                                Convert.ToString(rowResponseCliente["SAPellido"]);
                        }
                        else
                        {
                            frm.LblNombreClientes.Text = "CLIENTE MOSTRADOR";
                            auxClienteId = "";
                        }

                        if (Convert.ToDecimal(orden["RetencionDgi"]) != 0)
                        {
                            frm.ChkRetencionDgi.Checked = true;
                        }
                        else
                        {
                            frm.ChkRetencionDgi.Checked = false;
                        }

                        if (Convert.ToBoolean(orden["BitEsCredito"]))
                        {
                            frm.lblCredito.Visible = true;
                        }
                        else
                        {
                            frm.lblCredito.Visible = false;
                        }


                        frm.LblOrdenMesa.Visible = Convert.ToString(orden["SalaMesa"]) == "-" ? false : true;
                        frm.LblTituloSala.Visible = Convert.ToString(orden["SalaMesa"]) == "-" ? false : true;

                        if(frm.LblOrdenMesa.Visible == true)
                        {
                            frm.LblOrdenMesa.Text = Convert.ToString(orden["SalaMesa"]);
                            frm.BtnCredito.Visible = false;
                            MesaAux = Convert.ToString(orden["SalaMesa"]);
                            frm.ChkPropina.Visible = true;
                            frm.BtnDesvincular.Visible = true;
                        }
                        else
                        {
                            frm.BtnCredito.Visible = true;
                            frm.BtnDesvincular.Visible = false;
                            frm.ChkPropina.Visible = false;
                        }


                        if (Convert.ToDecimal(orden["RetencionAlcaldia"]) != 0)
                        {
                            frm.ChkRetencionAlcaldia.Checked = true;
                        }
                        else
                        {
                            frm.ChkRetencionAlcaldia.Checked = false;
                        }

                        dynamicDataTable.Rows.Clear();

                        DataTable dtDetalle = dataUtilities.getRecordByColumn("OrdenDetalle", "OrdenId", OrdenAux);

                        if (dtDetalle.Rows.Count > 0)
                        {
                            frm.BtnPagarOrden.Enabled = true;
                        }
                        else
                        {
                            frm.BtnPagarOrden.Enabled = false;
                        }

                        foreach (DataRow item in dtDetalle.Rows)
                        {
                            DataRow itemProducto = dataUtilities.getRecordByPrimaryKey("ProductosServicios", Convert.ToString(item["ProductoId"])).Rows[0];

                            dynamicDataTable.Rows.Add(
                                Convert.ToString(item["OrdenDetalleId"]),
                                Convert.ToString(itemProducto["Codigo"]),
                                Convert.ToString(itemProducto["ProductoId"]),
                                Convert.ToString(itemProducto["NombreProducto"]),
                                Convert.ToString(item["Cantidad"]),
                                Convert.ToString(itemProducto["Precio"]),
                                Convert.ToString(item["Subtotal"]));
                        }

                        //Obtener la tasa de cambio
                        DataTable tasaData = dataUtilities.GetAllRecords("vwTasa");

                        frm.LblNoOrden.Text = OrdenAux.ToString();
                        frm.LblEstadoOrden.Text = Convert.ToString(orden["OrdenProceso"]);
                        frm.LblFechaGeneracion.Text = Convert.ToString(orden["FechaRealizacion"]);
                        frm.LblProcesoPago.Text = Convert.ToString(orden["PagoProceso"]);
                        frm.LblOrdenMesa.Text = MesaAux;
                        frm.ChkPropina.Checked = orden["BitPropina"] != DBNull.Value && Convert.ToBoolean(orden["BitPropina"]);


                        frm.TxtSubTotal.Text = Convert.ToString(orden["SubTotal"]);
                        frm.TxtIVA.Text = Convert.ToString(orden["Iva"]);
                        frm.TxtDescuento.Text = Convert.ToString(orden["Descuento"]);
                        frm.TxtRetencionDGI.Text = Convert.ToString(orden["RetencionDgi"]);
                        frm.TxtRetencionAlcaldia.Text = Convert.ToString(orden["RetencionAlcaldia"]);
                        frm.TxtTotalCordoba.Text = Convert.ToString(orden["TotalOrden"]);
                        if (Convert.ToDecimal(orden["CambioDolar"]) != 0)
                        {
                            frm.TxtTotalDolar.Text = Math.Round(Convert.ToDecimal(orden["TotalOrden"]) / Convert.ToDecimal(orden["CambioDolar"]), 2).ToString();
                        }
                        else
                        {
                            frm.TxtTotalDolar.Text = "0";
                        }

                        frm.TxtTotalPagado.Text = Convert.ToString(orden["Pagado"]);

                        if (frm.LblProcesoPago.Text == "Totalmente Pagado")
                        {
                            frm.BtnAgregarPro.Enabled = false;
                            frm.BtnAgregarServicio.Enabled = false;
                            frm.TxtCodigoProducto.Enabled = false;
                            frm.BtnActualizarDescuento.Enabled = false;
                            frm.ChkRetencionAlcaldia.Enabled = false;
                            frm.ChkRetencionDgi.Enabled = false;
                        }
                        else
                        {
                            frm.BtnAgregarPro.Enabled = true;
                            frm.BtnAgregarServicio.Enabled = true;
                            frm.TxtCodigoProducto.Enabled = true;
                            frm.BtnActualizarDescuento.Enabled = true;
                            frm.ChkRetencionAlcaldia.Enabled = true;
                            frm.ChkRetencionDgi.Enabled = true;
                        }
                    }
                    break;
            }
        }

        private void MesaClick(string MesaSala, DataTable orden, PnlVentas frm)
        {
            frm.LblOrdenMesa.Visible = true;
            frm.LblTituloSala.Visible = true;

            MesaAux = MesaSala;
            if (orden.Rows.Count > 0)
            {
                OrdenAux = Convert.ToDecimal(orden.Rows[0]["OrdenId"]);
            }
            else
            {
                OrdenAux = 0;
            }

            InitModuloOrdenes(frm, "OrdenRapida", "");
        }

        public class FormaPagoClass
        {
            public string value { get; set; }
            public string desc { get; set; }
        }

        public void ConfigUI(PnlVentas frm, string opc)
        {
            frm.TxtCodigoProducto.Focus();
            switch (opc)
            {
                case "Productos":
                    //DATOS GENERALES DE LA PANTALLA
                    //frm.TCMain.SelectedIndex = 2;
                    frm.llbTitulo.Text = "Agregar Producto a la Orden";

                    auxSubModulo = "Productos";
                    auxAccion = "Buscar";

                    if (dynamicDataTableProductos.Columns.Count < 3)
                    {
                        dynamicDataTableProductos.Columns.Add("Id", typeof(string));
                        dynamicDataTableProductos.Columns.Add("Producto", typeof(string));
                        dynamicDataTableProductos.Columns.Add("Precio Unitario (NIO)", typeof(string));
                        dynamicDataTableProductos.Columns.Add("Cantidad", typeof(string));
                        //dynamicDataTableProductos.Columns.Add($"Precio Unitario $ ({Utilidades.Tasa})", typeof(string));

                        //frm.DgvProductos.DataSource = dynamicDataTableProductos;

                        //frm.DgvProductos.Columns[0].Visible = false;

                        // Agregar una columna de botón
                        DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                        buttonColumn.HeaderText = "...";
                        buttonColumn.Text = "Agregar a Venta";
                        buttonColumn.UseColumnTextForButtonValue = true;
                        //frm.DgvProductos.Columns.Add(buttonColumn);

                        DataGridViewButtonColumn buttonColumnDisponibilidad = new DataGridViewButtonColumn();
                        buttonColumnDisponibilidad.HeaderText = "...";
                        buttonColumnDisponibilidad.Text = "Disponibilidad";
                        buttonColumnDisponibilidad.UseColumnTextForButtonValue = true;
                        //frm.DgvProductos.Columns.Add(buttonColumnDisponibilidad);
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

                        //frm.CmbTipoServicio.ValueMember = "CategorizacionId";
                        //frm.CmbTipoServicio.DisplayMember = "Descripcion";
                        //frm.CmbTipoServicio.DataSource = dataCmbTipoServicio;
                    }

                    //FuncionesPrincipales(frm);
                    break;
                case "Servicios":
                    //DATOS GENERALES DE LA PANTALLA
                    //frm.TCMain.SelectedIndex = 2;
                    frm.llbTitulo.Text = "Agregar Servicios a la Orden";

                    auxSubModulo = "Servicios";
                    auxAccion = "Buscar";

                    if (dynamicDataTableProductos.Columns.Count < 3)
                    {
                        dynamicDataTableProductos.Columns.Add("Id", typeof(string));
                        dynamicDataTableProductos.Columns.Add("Servicios", typeof(string));
                        dynamicDataTableProductos.Columns.Add("Precio Unitario (NIO)", typeof(string));
                        dynamicDataTableProductos.Columns.Add("Cantidad", typeof(string));
                        //dynamicDataTableProductos.Columns.Add($"Precio Unitario $ ({Utilidades.Tasa})", typeof(string));

                        //frm.DgvProductos.DataSource = dynamicDataTableProductos;

                        //frm.DgvProductos.Columns[0].Visible = false;

                        // Agregar una columna de botón
                        DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                        buttonColumn.HeaderText = "...";
                        buttonColumn.Text = "Agregar a Venta";
                        buttonColumn.UseColumnTextForButtonValue = true;
                        //frm.DgvProductos.Columns.Add(buttonColumn);

                        DataGridViewButtonColumn buttonColumnDisponibilidad = new DataGridViewButtonColumn();
                        buttonColumnDisponibilidad.HeaderText = "...";
                        buttonColumnDisponibilidad.Text = "Disponibilidad";
                        buttonColumnDisponibilidad.UseColumnTextForButtonValue = true;
                        //frm.DgvProductos.Columns.Add(buttonColumnDisponibilidad);
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

                        //frm.CmbTipoServicio.ValueMember = "CategorizacionId";
                        //frm.CmbTipoServicio.DisplayMember = "Descripcion";
                        //frm.CmbTipoServicio.DataSource = dataCmbTipoServicio;
                    }

                    //FuncionesPrincipales(frm);
                    break;
                case "Menu":
                    //frm.TCMain.SelectedIndex = 0;
                    frm.llbTitulo.Text = "Crear Orden";
                    frm.TxtCodigoProducto.Focus();
                    break;
          
            }
        }

        public decimal TxtPrecioVariable = 0;

        public void AgregarProductosOrden(PnlVentas frm, string idProd, string Cantidad, string opc)
        {
            DataRow itemProductoAux = dataUtilities.getRecordByPrimaryKey("ProductosServicios", idProd).Rows[0];

            if (itemProductoAux["BitVariable"] != DBNull.Value)
            {
                if (Convert.ToBoolean(itemProductoAux["BitVariable"]) && opc == "Increase")
                {
                    PnlPrecioNuevo frmAux = new PnlPrecioNuevo(this,null);
                    frmAux.ShowDialog();

                    if(TxtPrecioVariable == 0)
                    {
                        MessageBox.Show("Debe digitar el precio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            auxSubModulo = Convert.ToString(itemProductoAux["ClasificacionProducto"]);

            if (auxSubModulo == "Productos")
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

                    if (Convert.ToString(dtReponseStock.Rows[0][0]) == "1" && opc == "Increase")
                    {
                        if (MessageBox.Show("El inventario es insuficiente. ¿Deseas continuar?",
                                     "Advertencia",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            //realizar operacion

                            dataUtilities.SetParameter("@OrderId", OrdenAux);
                            dataUtilities.SetParameter("@ProductId", idProd);
                            dataUtilities.SetParameter("@Quantity", Cantidad);
                            dataUtilities.SetParameter("@Action", opc);
                            dataUtilities.SetParameter("@WarehouseId", dtAlmacenMostrador.Rows[0]["AlmacenId"]);
                            dataUtilities.SetParameter("@Discount", 0);
                            dataUtilities.SetParameter("@SucursalId", frm.auxSucursal);

                            if(TxtPrecioVariable > 0)
                            {
                                dataUtilities.SetParameter("@Precio", TxtPrecioVariable);
                            }
                            
                            dataUtilities.SetParameter("@Total", 0);
                            dataUtilities.SetParameter("@Subtotal", 0);
                            dataUtilities.SetParameter("@IVA", 0);
                            dataUtilities.SetParameter("@HistorialId", SqlDbType.Int, ParameterDirection.Output);

                            PnlAgregarVencimientosProveedores frmaux = new PnlAgregarVencimientosProveedores(idProd, Convert.ToString(dtAlmacenMostrador.Rows[0]["AlmacenId"]), Cantidad);
                            frmaux.ShowDialog();

                            DataTable dtResponseTotales = dataUtilities.ExecuteStoredProcedure("sp_ManageOrderDetail");
                            string HistorialId = Convert.ToString(dataUtilities.GetParameterValue("@HistorialId"));
                            //COLOCAR PARTE DE ADICIONES

                            if (opc == "Increase")
                            {
                                //ADICIONES
                                dataUtilities.SetParameter("@ProductoId", idProd);
                                DataTable dtResponseAdiciones = dataUtilities.ExecuteStoredProcedure("spConsultarAdicionesProducto");

                                if (dtResponseAdiciones.Rows.Count > 0)
                                {
                                    PnlAdicionesVentas frmAdiciones = new PnlAdicionesVentas(idProd, HistorialId);
                                    frmAdiciones.ShowDialog();
                                }

                                //FIN ADICIONES

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

                        dataUtilities.SetParameter("@OrderId", OrdenAux);
                        dataUtilities.SetParameter("@ProductId", idProd);
                        dataUtilities.SetParameter("@Quantity", Cantidad);
                        dataUtilities.SetParameter("@Action", opc);
                        dataUtilities.SetParameter("@WarehouseId", dtAlmacenMostrador.Rows[0]["AlmacenId"]);
                        dataUtilities.SetParameter("@Discount", 0);
                        dataUtilities.SetParameter("@SucursalId", frm.auxSucursal);

                        if (TxtPrecioVariable > 0)
                        {
                            dataUtilities.SetParameter("@Precio", TxtPrecioVariable);
                        }
                        dataUtilities.SetParameter("@Total", 0);
                        dataUtilities.SetParameter("@Subtotal", 0);
                        dataUtilities.SetParameter("@IVA", 0);
                        dataUtilities.SetParameter("@HistorialId", SqlDbType.Int, ParameterDirection.Output);

                        PnlAgregarVencimientosProveedores frmaux = new PnlAgregarVencimientosProveedores(idProd, Convert.ToString(dtAlmacenMostrador.Rows[0]["AlmacenId"]), Cantidad);
                        frmaux.ShowDialog();

                        DataTable dtResponseTotales = dataUtilities.ExecuteStoredProcedure("sp_ManageOrderDetail");

                        string HistorialId = Convert.ToString(dataUtilities.GetParameterValue("@HistorialId"));

                        if (opc == "Increase")
                        {

                            //ADICIONES
                            dataUtilities.SetParameter("@ProductoId", idProd);
                            DataTable dtResponseAdiciones = dataUtilities.ExecuteStoredProcedure("spConsultarAdicionesProducto");

                            if (dtResponseAdiciones.Rows.Count > 0)
                            {
                                PnlAdicionesVentas frmAdiciones = new PnlAdicionesVentas(idProd, HistorialId);
                                frmAdiciones.ShowDialog();
                            }

                            //FIN ADICIONES

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

                        //FuncionesPrincipales(frm);
                    }
                }
            }
            else
            {
                dataUtilities.SetParameter("@OrderId", OrdenAux);
                dataUtilities.SetParameter("@ServiceId", idProd);
                dataUtilities.SetParameter("@Quantity", Cantidad);
                dataUtilities.SetParameter("@Action", opc);
                dataUtilities.SetParameter("@Discount", 0);
                dataUtilities.SetParameter("@Total", 0);
                dataUtilities.SetParameter("@SucursalId", frm.auxSucursal);
                if (TxtPrecioVariable > 0)
                {
                    dataUtilities.SetParameter("@Precio", TxtPrecioVariable);
                }
                dataUtilities.SetParameter("@Subtotal", 0);
                dataUtilities.SetParameter("@IVA", 0);
                dataUtilities.SetParameter("@HistorialId", SqlDbType.Int, ParameterDirection.Output);

                DataTable dtResponseTotales = dataUtilities.ExecuteStoredProcedure("sp_ManageOrderServiceDetail");

                //COLOCAR PARTE DE ADICIONES
                string HistorialId = Convert.ToString(dataUtilities.GetParameterValue("@HistorialId"));
                if (opc == "Increase")
                {
                    //ADICIONES
                    dataUtilities.SetParameter("@ProductoId", idProd);
                    DataTable dtResponseAdiciones = dataUtilities.ExecuteStoredProcedure("spConsultarAdicionesProducto");

                    if (dtResponseAdiciones.Rows.Count > 0)
                    {
                        PnlAdicionesVentas frmAdiciones = new PnlAdicionesVentas(idProd, HistorialId);
                        frmAdiciones.ShowDialog();
                    }

                    //FIN ADICIONES

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

            //Actualizar el detalle
            dynamicDataTable.Rows.Clear();

            DataTable dtDetalle = dataUtilities.getRecordByColumn("OrdenDetalle", "OrdenId", OrdenAux);

            if (dtDetalle.Rows.Count > 0)
            {
                frm.BtnPagarOrden.Enabled = true;
            }
            else
            {
                frm.BtnPagarOrden.Enabled = false;
            }

            foreach (DataRow item in dtDetalle.Rows)
            {
                DataRow itemProducto = dataUtilities.getRecordByPrimaryKey("ProductosServicios", Convert.ToString(item["ProductoId"])).Rows[0];

                dynamicDataTable.Rows.Add(
                    Convert.ToString(item["OrdenDetalleId"]),
                    Convert.ToString(itemProducto["Codigo"]),
                    Convert.ToString(itemProducto["ProductoId"]),
                    Convert.ToString(itemProducto["NombreProducto"]),
                    Convert.ToString(item["Cantidad"]),
                    Convert.ToString(itemProducto["Precio"]),
                    Convert.ToString(item["Subtotal"]));
            }

            CalcularTotales(frm, frm.TxtDescuento.Text);

            TxtPrecioVariable = 0;
        }

        public void CalcularTotales(PnlVentas frm, string descuento)
        {
            DataTable dtResponse = dataUtilities.getRecordByColumn("ConfigFacturacion", "SucursalId", Utilidades.SucursalId);

            dataUtilities.SetParameter("@IdOrden", OrdenAux);
            dataUtilities.SetParameter("@AplicaRetencionDgi", frm.ChkRetencionDgi.Checked);
            dataUtilities.SetParameter("@AplicaRetencionAlcaldia", frm.ChkRetencionAlcaldia.Checked);
            dataUtilities.SetParameter("@DescuentoAdicional", descuento);
            dataUtilities.SetParameter("@CalcularIVA", Convert.ToBoolean(dtResponse.Rows[0]["RetieneIvaBit"]));

            dataUtilities.ExecuteStoredProcedure("Sp_CalcularTotalesOrden");

            DataTable dtResponseOrden = dataUtilities.getRecordByPrimaryKey("Ordenes", OrdenAux);
            DataRow orden = dtResponseOrden.Rows[0];

            frm.TxtSubTotal.Text = Convert.ToString(orden["SubTotal"]);
            frm.TxtIVA.Text = Convert.ToString(orden["Iva"]);
            frm.TxtDescuento.Text = Convert.ToString(orden["Descuento"]);
            frm.TxtRetencionDGI.Text = Convert.ToString(orden["RetencionDgi"]);
            frm.TxtRetencionAlcaldia.Text = Convert.ToString(orden["RetencionAlcaldia"]);
            frm.TxtTotalCordoba.Text = Convert.ToString(orden["TotalOrden"]);
            if (Convert.ToDecimal(orden["CambioDolar"]) != 0)
            {
                frm.TxtTotalDolar.Text = Math.Round(Convert.ToDecimal(orden["TotalOrden"]) / Convert.ToDecimal(orden["CambioDolar"]), 2).ToString();
            }
            else
            {
                frm.TxtTotalDolar.Text = "0";
            }

            frm.TxtTotalPagado.Text = Convert.ToString(orden["Pagado"]);
        }
    }
}
