﻿using NeoCobranza.Clases;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles
{
    public partial class ComprasInventario : Form
    {
        string auxOpc;
        string auxKey = "";
        DataTable dataBuscar = new DataTable();
        DataTable dataProducto = new DataTable();
        DataTable dataCompra = new DataTable();
        DataUtilities dataUtilities = new DataUtilities();
        public decimal cantidad = 0,costo;

        public ComprasInventario()
        {
            InitializeComponent();
        }

        private void ComprasInventario_Load(object sender, EventArgs e)
        {
            UIUtilities.PersonalizarDataGridView(DgvCatalogo);
            UIUtilities.PersonalizarDataGridViewPequeños(DgvCompra);
            UIUtilities.PersonalizarDataGridViewPequeños(DgvProductos);
            UIUtilities.EstablecerFondo(this);
            UIUtilities.ConfigurarBotonBuscar(BtnBuscar);
            UIUtilities.ConfigurarTextBoxBuscar(TxtFiltroProducto);
            UIUtilities.ConfigurarTituloPantalla(TbTitulo, PnlTitulo);
            UIUtilities.ConfigurarComboBox(CmbAlmacen);
            UIUtilities.ConfigurarComboBox(CmbSucursales);

            TCMain.Appearance = TabAppearance.FlatButtons;
            TCMain.SizeMode = TabSizeMode.Fixed;
            TCMain.ItemSize = new System.Drawing.Size(1, 1);

            auxOpc = "Buscar";
            ConfigUI();
        }

        private void ConfigUI()
        {
            switch (auxOpc)
            {
                case "Buscar":
                    TbTitulo.Text = "Buscar Compras";
                    auxKey = "";
                    TCMain.SelectedIndex = 0;

                    if (dataBuscar.Columns.Count == 0)
                    {
                        //Agregar Boton de Cambiar de estado
                        DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

                        BtnCambioEstado.Text = "  Actualizar  ";
                        BtnCambioEstado.Name = "...";
                        BtnCambioEstado.UseColumnTextForButtonValue = true;
                        BtnCambioEstado.DefaultCellStyle.ForeColor = Color.Blue;
                        DgvCatalogo.Columns.Add(BtnCambioEstado);

                        //Agregar botón para imprimir baucher
                        DataGridViewButtonColumn BtnImprimir = new DataGridViewButtonColumn();

                        BtnImprimir.Text = "  imprimir  ";
                        BtnImprimir.Name = "...";
                        BtnImprimir.UseColumnTextForButtonValue = true;
                        BtnImprimir.DefaultCellStyle.ForeColor = Color.Blue;
                        //DgvCatalogo.Columns.Add(BtnImprimir);

                        //Agregar botón para revertir
                        DataGridViewButtonColumn BtnRevertir = new DataGridViewButtonColumn();

                        BtnRevertir.Text = "  Revertir  ";
                        BtnRevertir.Name = "...";
                        BtnRevertir.UseColumnTextForButtonValue = true;
                        BtnRevertir.DefaultCellStyle.ForeColor = Color.Blue;
                        DgvCatalogo.Columns.Add(BtnRevertir);

                        // Definir las columnas
                        dataBuscar.Columns.Add("Compra ID", typeof(string));
                        dataBuscar.Columns.Add("CostoTotal", typeof(string));
                        dataBuscar.Columns.Add("Descripción", typeof(string));
                        dataBuscar.Columns.Add("Almacén", typeof(string));
                        dataBuscar.Columns.Add("Sucursal", typeof(string));
                        dataBuscar.Columns.Add("Fecha Creación", typeof(string));
                        dataBuscar.Columns.Add("Usuario", typeof(string));
                        dataBuscar.Columns.Add("Usuario Revirtió", typeof(string));

                        DgvCatalogo.DataSource = dataBuscar;
                        //DgvCatalogo.Columns[0].Visible = false;
                    }

                    // Obtiene todos los registros de la tabla Sucursal
                    DataTable dtResponseSucursales = dataUtilities.GetAllRecords("Sucursal");

                    // Filtra las filas donde el campo Estado sea "Activo"
                    var filterRowSucursales = from row in dtResponseSucursales.AsEnumerable()
                                              where Convert.ToString(row.Field<string>("Estado")) == "Activo"
                                              select row;

                    if (filterRowSucursales.Any())
                    {
                        DataTable dataCmbSucursal = new DataTable();
                        dataCmbSucursal = filterRowSucursales.CopyToDataTable();

                        DataRow newRow = dataCmbSucursal.NewRow();
                        newRow["IdSucursal"] = "0";
                        newRow["NombreSucursal"] = "Mostrar Todo";
                        newRow["Estado"] = "Activo";

                        dataCmbSucursal.Rows.InsertAt(newRow, 0);

                        CmbSucursales.ValueMember = "IdSucursal";
                        CmbSucursales.DisplayMember = "NombreSucursal";
                        CmbSucursales.DataSource = dataCmbSucursal;
                    }


                    FuncionesPrincipales();

                    break;

                case "Crear":

                    TxtFiltroProducto.Enabled = true;
 
                    DgvProductos.Enabled = true;

                    //LblCantidad.Enabled = true;
                    //TxtCantidad.Enabled = true;
                    //LblPrecioVenta.Enabled = true;
                    //TxtCosto.Enabled = true;
                    BtnAgregarProducto.Enabled = true;

                    CmbAlmacen.Enabled = true;
                    BtnAgregarCompra.Enabled = true;
                    TxtDescripcion.Enabled = true;

                    //TxtCantidad.Text = "0";
                    //TxtCosto.Text = "0";

                    dataCompra.Rows.Clear();
                    dataProducto.Rows.Clear();

                    TxtFiltroProducto.Text = "";
                    TxtDescripcion.Text = "";
                    TxtMontoTotal.Text = "0 (NIO)";

                    TCMain.SelectedIndex = 1;
                    TbTitulo.Text = "Crear Compra";
                    BtnAgregarCompra.Text = "Crear";

                    //Categoria Almacen
                    DataTable dtResponseAlmacenes = dataUtilities.GetAllRecords("Almacenes");

                    var filterRowAlmacenes = from row in dtResponseAlmacenes.AsEnumerable()
                                             where Convert.ToString(row.Field<string>("Estatus")) == "Activo"
                                             select row;

                    if (filterRowAlmacenes.Any())
                    {
                        DataTable dataCmbSucursal = new DataTable();
                        dataCmbSucursal = filterRowAlmacenes.CopyToDataTable();

                        CmbAlmacen.ValueMember = "AlmacenId";
                        CmbAlmacen.DisplayMember = "NombreAlmacen";
                        CmbAlmacen.DataSource = dataCmbSucursal;
                    }
                    //Categoria Almacen

                    DgvProductos.DataSource = dataProducto;

                    if (dataCompra.Columns.Count == 0)
                    {
                        DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

                        BtnCambioEstado.Text = "Quitar";
                        BtnCambioEstado.Name = "...";
                        BtnCambioEstado.UseColumnTextForButtonValue = true;
                        BtnCambioEstado.DefaultCellStyle.ForeColor = Color.Blue;
                        DgvCompra.Columns.Add(BtnCambioEstado);

                        dataCompra.Columns.Add("Id Producto", typeof(string));
                        dataCompra.Columns.Add("Id Proveedor", typeof(string));
                        dataCompra.Columns.Add("Proveedor", typeof(string));
                        dataCompra.Columns.Add("Producto", typeof(string));
                        dataCompra.Columns.Add("Sub Total (NIO)", typeof(string));
                        dataCompra.Columns.Add("Cantidad/U", typeof(string));
                        dataCompra.Columns.Add("Vencimiento", typeof(string));

                        DgvCompra.DataSource = dataCompra;
                        DgvCompra.Columns[1].Visible = false;
                        DgvCompra.Columns[2].Visible = false;
                    }

                    BuscarProducto();

                    if (auxKey != "")
                    {
                        //Llenar datos de la compra
                        DataTable dtResponse = dataUtilities.getRecordByPrimaryKey("Compras", auxKey);

                        CmbAlmacen.SelectedValue = Convert.ToString(dtResponse.Rows[0]["AlmacenId"]);
                        TxtDescripcion.Text = Convert.ToString(dtResponse.Rows[0]["Descripcion"]);

                        //Llenar datos detalle
                        DataTable dtResponseDetalle = dataUtilities.getRecordByColumn("CompraDetalles", "CompraId", auxKey);

                        foreach (DataRow dr in dtResponseDetalle.Rows)
                        {
                            DataTable dtProducto = dataUtilities.getRecordByPrimaryKey("ProductosServicios", Convert.ToString(dr["ProductoId"]));
                            DataTable dtProveedor = dataUtilities.getRecordByPrimaryKey("Proveedores", Convert.ToString(dr["ProveedorId"]));

                            dataCompra.Rows.Add(
                                Convert.ToString(dr["ProductoId"]),
                                Convert.ToString(dr["ProveedorId"]),
                                Convert.ToString(dtProveedor.Rows[0]["NombreEmpresa"]),
                                Convert.ToString(dtProducto.Rows[0]["NombreProducto"]),
                                Convert.ToString(dr["SubTotal"]),
                                Convert.ToString(dr["Cantidad"])
                                );

                        }
                        ContadorTotal();

                        //llenar datos

                        CmbAlmacen.Enabled = false;
                        BtnAgregarCompra.Text = "Actualizar Compra";
                    }

                    break;
            }
        }

        private void BuscarProducto()
        {
            int pageNumber = 1;
            if (!int.TryParse(TxtPaginaNo.Text, out pageNumber))
            {
                pageNumber = 1;
                TxtPaginaNo.Text = "1";
            }

            // Definir el tamño de página (en este ejemplo se usan 20 registros por página)
            int pageSize = 20;

            dataProducto.Rows.Clear();

            if (dataProducto.Columns.Count == 0)
            {
                dataProducto.Columns.Add("Id", typeof(string));
                dataProducto.Columns.Add("Producto", typeof(string));
                dataProducto.Columns.Add("Cantidad en Almacén", typeof(string));
                dataProducto.Columns.Add("Precio (NIO)", typeof(string));

            }

            dataUtilities.SetParameter("@AlmacenId", CmbAlmacen.SelectedValue);
            dataUtilities.SetParameter("@CategoriaId", 0);
            dataUtilities.SetParameter("@Filtro", TxtFiltroProducto.Text);
            dataUtilities.SetParameter("@PageNumber", pageNumber);
            dataUtilities.SetParameter("@PageSize", pageSize);
            // Configurar el parámetro de salida para el total de registros.
            dataUtilities.SetParameter("@TotalRecords", System.Data.SqlDbType.Int, direction: System.Data.ParameterDirection.Output);

            DataTable dtResponse = dataUtilities.ExecuteStoredProcedure("sp_ObtenerCantidadProductoPorAlmacen");

            foreach (DataRow item in dtResponse.Rows)
            {
                dataProducto.Rows.Add(
                    Convert.ToString(item["ID"]),
                    Convert.ToString(item["PRODUCTO"]),
                    Convert.ToString(item["EXISTENCIA"]),
                    Convert.ToString(item["PRECIO (NIO)"])
                    );
            }

            // Recuperar el total de registros desde el parámetro de salida y actualizar el control de total de páginas.
            int totalRecords = Convert.ToInt32(dataUtilities.GetParameterValue("@TotalRecords"));
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            TxtPaginaDe.Text = totalPages.ToString();

            dataUtilities.ClearOutPutParameters();

            if (DgvProductos.ColumnCount != 0)
            {
                DgvProductos.Columns[0].Visible = false;
            }
        }

        private void FuncionesPrincipales()
        {
            if (auxOpc == "Buscar")
            {
                dataBuscar.Rows.Clear();

                int pageNumber = 1;
                if (!int.TryParse(TxtNoPagniaDos.Text, out pageNumber))
                {
                    pageNumber = 1;
                    TxtNoPagniaDos.Text = "1";
                }

                int pageSize = 15;

                dataUtilities.SetParameter("@IdSucursal", CmbSucursales.SelectedValue);
                dataUtilities.SetParameter("@PageNumber", pageNumber);
                dataUtilities.SetParameter("@PageSize", pageSize);
                dataUtilities.SetParameter("@TotalRecords", SqlDbType.Int, ParameterDirection.Output);

                // Ejecutar el SP
                DataTable dtResponse = dataUtilities.ExecuteStoredProcedure("sp_GetComprasPorSucursal");

                int totalRecords = Convert.ToInt32(dataUtilities.GetParameterValue("@TotalRecords"));
                int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                TxtDeDos.Text = totalPages.ToString();

                foreach (DataRow item in dtResponse.Rows)
                {
                    dataBuscar.Rows.Add(Convert.ToString(item["CompraId"]),
                        Convert.ToString(item["Total"]),
                        Convert.ToString(item["Descripcion"]),
                        Convert.ToString(item["NombreAlmacen"]),
                        Convert.ToString(item["NombreSucursal"]),
                        Convert.ToString(item["Fecha"]),
                        Convert.ToString(item["Usuario"]),
                        Convert.ToString(item["UsuarioRevirtio"])
                        );
                }

                DgvCatalogo.DataSource = dataBuscar;
                ActualizarEstadoBotonesDos();

            }
            else if (auxOpc == "Crear")
            {
                if (auxKey == "")
                {
                    //agregar la compra
                    string idCompra = Guid.NewGuid().ToString();

                    dataUtilities.SetColumns("CompraId", idCompra);
                    dataUtilities.SetColumns("usuario", Utilidades.Usuario);
                    dataUtilities.SetColumns("AlmacenId", CmbAlmacen.SelectedValue);
                    dataUtilities.SetColumns("SucursalId", Utilidades.SucursalId);
                    dataUtilities.SetColumns("Descripcion", TxtDescripcion.Text);
                    dataUtilities.SetColumns("CostoTotal", TxtMontoTotal.Text);
                    dataUtilities.SetColumns("FechaAlta", DateTime.Now);

                    dataUtilities.InsertRecord("Compras");

                    //agregar detalle de la compra

                    foreach (DataRow item in dataCompra.Rows)
                    {
                        string idLote = Guid.NewGuid().ToString();

                        dataUtilities.SetColumns("LoteId", idLote);
                        dataUtilities.SetColumns("ProductoId", Convert.ToString(item[0]));
                        dataUtilities.SetColumns("CompraId", idCompra);
                        dataUtilities.SetColumns("Cantidad", Convert.ToString(item[5]));
                        dataUtilities.SetColumns("FechaCreacion", DateTime.Now);
                        dataUtilities.SetColumns("AlmacenId", CmbAlmacen.SelectedValue);
                        dataUtilities.SetColumns("ProveedorId", Convert.ToString(item[1]));
                        dataUtilities.SetColumns("CostoU", (Convert.ToDecimal(item[4]) / Convert.ToDecimal(item[5])));
                        dataUtilities.SetColumns("SubTotal", Convert.ToString(item[4]));

                        dataUtilities.InsertRecord("CompraDetalles");

                        //agregar al rel la cantidad

                        DataTable dtResponse = dataUtilities.GetAllRecords("RelAlmacenProducto");
                        var filterRow =
                            from row in dtResponse.AsEnumerable()
                            where Convert.ToString(row.Field<string>("AlmacenId")) == Convert.ToString(CmbAlmacen.SelectedValue)
                            && Convert.ToString(row.Field<string>("ProductoId")) == Convert.ToString(item[0])
                            select row;

                        dtResponse = filterRow.CopyToDataTable();

                        decimal idRelAlmacenProducto = Convert.ToDecimal(dtResponse.Rows[0]["RelAlmacenProductoId"]);
                        decimal cantidadActual = Convert.ToDecimal(dtResponse.Rows[0]["Cantidad"]);

                        //Actualizar la cantidad
                        decimal cantidadActualizada = cantidadActual + Convert.ToDecimal(item[5]);

                        dataUtilities.SetColumns("Cantidad", cantidadActualizada);
                        dataUtilities.UpdateRecordByPrimaryKey("RelAlmacenProducto", idRelAlmacenProducto);

                        DataTable dtResponseProducto = dataUtilities.getRecordByPrimaryKey("ProductosServicios", Convert.ToString(item[0]));

                        if (!Convert.ToBoolean(dtResponseProducto.Rows[0]["bitInventarioSencillo"]))
                        {
                            //NUEVA PARTE DE SEPARACIÓN POR PROVEEDOR 
                            DataTable dtResponseProveedor = dataUtilities.GetAllRecords("DetalleAlmacenProveedor");
                            var filterRowProveedor =
                                from row in dtResponseProveedor.AsEnumerable()
                                where Convert.ToString(row.Field<decimal>("RelAlmacenProductoId")) == idRelAlmacenProducto.ToString()
                                && Convert.ToString(row.Field<decimal>("ProveedorId")) == Convert.ToString(item[1])
                                select row;

                            if (filterRowProveedor.Any())
                            {
                                dtResponseProveedor = filterRowProveedor.CopyToDataTable();

                                decimal idDetalleProveedor = Convert.ToDecimal(dtResponseProveedor.Rows[0]["RelAlmacenProductoProveedor"]);
                                decimal cantidadActualProveedor = Convert.ToDecimal(dtResponseProveedor.Rows[0]["Cantidad"]);

                                decimal cantidadActualizadaProveedor = cantidadActualProveedor + Convert.ToDecimal(item[5]);

                                dataUtilities.SetColumns("Cantidad", cantidadActualizadaProveedor);
                                dataUtilities.UpdateRecordByPrimaryKey("DetalleAlmacenProveedor", idDetalleProveedor);

                                //NUEVA PARTE DE FECHA DE CADUCIDAD
                                dataUtilities.SetColumns("RelAlmacenProveedorProductoId", idDetalleProveedor);
                                dataUtilities.SetColumns("Cantidad", Convert.ToDecimal(item[5]));
                                dataUtilities.SetColumns("FechaVencimiento", Convert.ToDateTime(item[6]));
                                dataUtilities.SetColumns("FechaAlta", DateTime.Now);
                                dataUtilities.SetColumns("CompraId", idCompra);
                                dataUtilities.InsertRecord("VencimientoProducto");
                            }

                            if (ChkCaja.Checked)
                            {
                                if (!Convert.ToBoolean(dtResponseProducto.Rows[0]["bitInventarioVencimiento"]))
                                {
                                    DataUtilities dataUtilities = new DataUtilities();
                                    dataUtilities.SetColumns("SucursaId", Utilidades.SucursalId);
                                    dataUtilities.SetColumns("Pagado", Regex.Replace(TxtMontoTotal.Text, "[^0-9.]", ""));
                                    dataUtilities.SetColumns("Total", 0);
                                    dataUtilities.SetColumns("Referencia", $"COMPRA INVENTARIO {DateTime.Now.ToShortDateString()}");
                                    dataUtilities.SetColumns("FechaPago", DateTime.Now);
                                    dataUtilities.SetColumns("BitEsIngreso", false);
                                    dataUtilities.SetColumns("BitCierreCaja", false);
                                    dataUtilities.SetColumns("CompraId", idCompra);
                                    dataUtilities.InsertRecord("PagosIngresoGasto");
                                }
                            }
                        }

                        auxKey = "";
                    }

                    MessageBox.Show("Compra creada correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    //compra general
                    dataUtilities.SetColumns("usuario", Utilidades.Usuario);
                    dataUtilities.SetColumns("Descripcion", TxtDescripcion.Text);
                    dataUtilities.SetColumns("CostoTotal", TxtMontoTotal.Text);

                    dataUtilities.UpdateRecordByPrimaryKey("Compras", auxKey);

                    //detalle
                    foreach (DataRow item in dataCompra.Rows)
                    {
                        //Verificar que el lote no exista en la compra ya
                        DataTable dtResponseDetalle = dataUtilities.GetAllRecords("CompraDetalles");
                        var filterRowDetalle =
                            from row in dtResponseDetalle.AsEnumerable()
                            where Convert.ToString(row.Field<string>("CompraId")) == auxKey
                            && Convert.ToString(row.Field<string>("ProductoId")) == Convert.ToString(item[0])
                            select row;

                        if (!filterRowDetalle.Any())
                        {

                            string idLote = Guid.NewGuid().ToString();

                            dataUtilities.SetColumns("LoteId", idLote);
                            dataUtilities.SetColumns("ProductoId", Convert.ToString(item[0]));
                            dataUtilities.SetColumns("CompraId", auxKey);
                            dataUtilities.SetColumns("Cantidad", Convert.ToString(item[5]));
                            dataUtilities.SetColumns("FechaCreacion", DateTime.Now);
                            dataUtilities.SetColumns("AlmacenId", CmbAlmacen.SelectedValue);
                            dataUtilities.SetColumns("ProveedorId", Convert.ToString(item[1]));
                            dataUtilities.SetColumns("CostoU", (Convert.ToDecimal(item[5]) / Convert.ToDecimal(item[5])));
                            dataUtilities.SetColumns("SubTotal", Convert.ToString(item[5]));

                            dataUtilities.InsertRecord("CompraDetalles");

                            //agregar al rel la cantidad

                            DataTable dtResponse = dataUtilities.GetAllRecords("RelAlmacenProducto");
                            var filterRow =
                                from row in dtResponse.AsEnumerable()
                                where Convert.ToString(row.Field<string>("AlmacenId")) == Convert.ToString(CmbAlmacen.SelectedValue)
                                && Convert.ToString(row.Field<string>("ProductoId")) == Convert.ToString(item[0])
                                select row;

                            dtResponse = filterRow.CopyToDataTable();

                            decimal idRelAlmacenProducto = Convert.ToDecimal(dtResponse.Rows[0]["RelAlmacenProductoId"]);
                            decimal cantidadActual = Convert.ToDecimal(dtResponse.Rows[0]["Cantidad"]);

                            //Actualizar la cantidad
                            decimal cantidadActualizada = cantidadActual + Convert.ToDecimal(item[5]);

                            dataUtilities.SetColumns("Cantidad", cantidadActualizada);
                            dataUtilities.UpdateRecordByPrimaryKey("RelAlmacenProducto", idRelAlmacenProducto);

                        }
                    }

                    MessageBox.Show("Compra actualizada correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                auxOpc = "Buscar";
                ConfigUI();
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            auxOpc = "Buscar";
            FuncionesPrincipales();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 37))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            auxOpc = "Crear";
            ConfigUI();
        }

        private void BtnBuscarProducto_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }

        private void CmbTipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarProducto();
        }


        private void TxtCosto_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != 8)
            {
                e.Handled = true; // Esto indica que el evento ha sido manejado, por lo que el carácter no será mostrado en el TextBox
            }
        }

        private void TxtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, el punto decimal y la tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != 8)
            {
                e.Handled = true; // Esto indica que el evento ha sido manejado, por lo que el carácter no será mostrado en el TextBox
            }
        }

        private void BtnAgregarCompra_Click(object sender, EventArgs e)
        {
            if (CmbAlmacen.Items.Count == 0)
            {
                MessageBox.Show("Debe agregar almacenes para poder realizar una compra.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataCompra.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar items a la compra para finalizar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FuncionesPrincipales();
        }

        private void BtnSeleccionarProveeder_Click(object sender, EventArgs e)
        {
            //PnlSeleccionarProveedor frm = new PnlSeleccionarProveedor();
            //AddOwnedForm(frm);
            //frm.ShowDialog();
        }

        public string proveedor = "0";
        public string NombreProveedor = "-";
        public string FechaVencimiento;
        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            

            if (DgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un Producto para agregar a la compra.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //LLamar a la nueva pantalla de proveedores
            PnlSeleccionarProveedor frm = new PnlSeleccionarProveedor(DgvProductos.SelectedRows[0].Cells[0].Value.ToString());
            AddOwnedForm(frm);
            frm.ShowDialog();


            foreach (DataRow item in dataCompra.Rows)
            {
                if (item[0].ToString() == DgvProductos.SelectedRows[0].Cells[0].Value.ToString() && item[1].ToString() == proveedor && proveedor != "0")
                {
                    MessageBox.Show("El producto ya fue agregado a la compra con el mismo proveedor. Solo puede agregar el mismo producto con diferente proveedor.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }



            if(cantidad > 0)
            {
                dataCompra.Rows.Add(DgvProductos.SelectedRows[0].Cells[0].Value.ToString(),
                proveedor,
                NombreProveedor,
                DgvProductos.SelectedRows[0].Cells[1].Value.ToString(),
                Convert.ToDecimal(costo),
                cantidad,
                FechaVencimiento
                );

                cantidad = 0;
                costo = 0;
            }

            proveedor = "0";
            NombreProveedor = "-";

            ContadorTotal();
        }

        private void ContadorTotal()
        {
            double total = 0;

            foreach (DataRow item in dataCompra.Rows)
            {
                total += double.Parse(Convert.ToString(item[4]));
            }

            TxtMontoTotal.Text = total.ToString() + " (NIO)";
        }

        private void DgvCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (auxKey == "")
                {
                    dataCompra.Rows.RemoveAt(e.RowIndex);
                }
                else
                {
                    //QUITAR ACTUALIZAR

                    //Verificar si hay el espacio suficiente para quitarlo
                    DataTable dtResponse = dataUtilities.GetAllRecords("RelAlmacenProducto");
                    var filterRow =
                        from row in dtResponse.AsEnumerable()
                        where Convert.ToString(row.Field<string>("AlmacenId")) == Convert.ToString(CmbAlmacen.SelectedValue)
                        && Convert.ToString(row.Field<string>("ProductoId")) == Convert.ToString(dataCompra.Rows[e.RowIndex][0])
                        select row;

                    dtResponse = filterRow.CopyToDataTable();

                    decimal idRelAlmacenProducto = Convert.ToDecimal(dtResponse.Rows[0]["RelAlmacenProductoId"]);
                    decimal cantidadActual = Convert.ToDecimal(dtResponse.Rows[0]["Cantidad"]);

                    if (cantidadActual < Convert.ToDecimal(dataCompra.Rows[e.RowIndex][5]))
                    {
                        MessageBox.Show("No hay suficiente espacio en almacén para revertir la cantidad de producto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    //Quitarlo del Inventario
                    DataTable dtResponseDetalle = dataUtilities.GetAllRecords("CompraDetalles");
                    var filterRowDetalle =
                        from row in dtResponseDetalle.AsEnumerable()
                        where Convert.ToString(row.Field<string>("CompraId")) == auxKey
                        && Convert.ToString(row.Field<string>("ProductoId")) == Convert.ToString(dataCompra.Rows[e.RowIndex][0])
                        select row;

                    dtResponseDetalle = filterRowDetalle.CopyToDataTable();

                    dataUtilities.DeleteRecordByColumn("CompraDetalles",
                        "LoteId",
                        Convert.ToString(dtResponseDetalle.Rows[0]["LoteId"]));

                    //Quitarlo del relAlmacen

                    dataUtilities.SetColumns("Cantidad", (cantidadActual - Convert.ToDecimal(dataCompra.Rows[e.RowIndex][5])));
                    dataUtilities.UpdateRecordByPrimaryKey("RelAlmacenProducto", idRelAlmacenProducto);


                    //NUEVA PARTE DE SEPARACIÓN POR PROVEEDOR 
                    DataTable dtResponseProveedor = dataUtilities.GetAllRecords("DetalleAlmacenProveedor");
                    var filterRowProveedor =
                        from row in dtResponseProveedor.AsEnumerable()
                        where Convert.ToString(row.Field<decimal>("RelAlmacenProductoId")) == idRelAlmacenProducto.ToString()
                        && Convert.ToString(row.Field<decimal>("ProveedorId")) == Convert.ToString(dataCompra.Rows[e.RowIndex][1])
                        select row;

                    if (filterRow.Any())
                    {
                        dtResponseProveedor = filterRowProveedor.CopyToDataTable();

                        decimal idDetalleProveedor = Convert.ToDecimal(dtResponseProveedor.Rows[0]["RelAlmacenProductoProveedor"]);
                        decimal cantidadActualProveedor = Convert.ToDecimal(dtResponseProveedor.Rows[0]["Cantidad"]);

                        decimal cantidadActualizadaProveedor = cantidadActualProveedor - Convert.ToDecimal(dataCompra.Rows[e.RowIndex][5]);

                        dataUtilities.SetColumns("Cantidad", cantidadActualizadaProveedor);
                        dataUtilities.UpdateRecordByPrimaryKey("DetalleAlmacenProveedor", idDetalleProveedor);


                        //NUEVA PARTE DE FECHA DE CADUCIDAD
                        dataUtilities.SetParameter("@IdDetalleProveedor", idDetalleProveedor);
                        dataUtilities.SetParameter("@CompraId", auxKey);
                        dataUtilities.ExecuteStoredProcedure("deleteProdVencimiento");
                    }

                    dataCompra.Rows.RemoveAt(e.RowIndex);
                }

                ContadorTotal();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            auxOpc = "Buscar";
            ConfigUI();
        }

        private void DgvCatalogo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            object cellValue = DgvCatalogo.Rows[e.RowIndex].Cells[2].Value;

            if (e.ColumnIndex == 0)
            {
                if (!Utilidades.PermisosLevel(3, 38))
                {
                    MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //ACTUALIZAR
                auxKey = Convert.ToString(cellValue);
                auxOpc = "Crear";
                ConfigUI();
            }
            if (e.ColumnIndex == 1)
            {
                if (!Utilidades.PermisosLevel(3, 39))
                {
                    MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //REVERTIR
                try
                {
                    object cellValueRevertir = DgvCatalogo.Rows[e.RowIndex].Cells[9].Value;

                    if (Convert.ToString(cellValueRevertir) != "")
                    {
                        MessageBox.Show("La compra ya fue revertida.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Confirmación del usuario para revertir
                    DialogResult result = MessageBox.Show("¿Estás seguro de que quieres revertir la compra?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        return; // Salir si el usuario selecciona "No"
                    }

                    dataUtilities.SetParameter("@CompraId", Convert.ToString(cellValue));
                    dataUtilities.SetParameter("@Usuario", Utilidades.Usuario);
                    DataTable dtResponse = dataUtilities.ExecuteStoredProcedure("RevertirCompra");


                    MessageBox.Show(Convert.ToString(dtResponse.Rows[0][0]), "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ha ocurrido un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TCMain_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CmbSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            auxOpc = "Buscar";
            FuncionesPrincipales();
        }

        private void LblCantidad_Click(object sender, EventArgs e)
        {

        }

        private void CmbAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarProducto();
        }

        private void TxtFiltroProducto_TextChanged(object sender, EventArgs e)
        {
            BuscarProducto();
        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TxtPaginaNo.Text, out int currentPage) && currentPage > 1)
            {
                currentPage--;
                TxtPaginaNo.Text = currentPage.ToString();
                BuscarProducto();
                ActualizarEstadoBotones();
            }
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            // Se compara con el total de páginas que se muestra en TxtPaginaDe
            if (int.TryParse(TxtPaginaNo.Text, out int currentPage) &&
                int.TryParse(TxtPaginaDe.Text, out int totalPages) &&
                currentPage < totalPages)
            {
                currentPage++;
                TxtPaginaNo.Text = currentPage.ToString();
                BuscarProducto();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TxtPaginaNo.Text, out int currentPage) && currentPage > 1)
            {
                currentPage--;
                TxtNoPagniaDos.Text = currentPage.ToString();
                auxOpc = "Buscar";
                FuncionesPrincipales();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TxtNoPagniaDos.Text, out int currentPage) &&
        int.TryParse(TxtDeDos.Text, out int totalPages) &&
        currentPage < totalPages)
            {
                currentPage++;
                TxtNoPagniaDos.Text = currentPage.ToString();
                auxOpc = "Buscar";
                FuncionesPrincipales();
            }

        }

        private void ActualizarEstadoBotonesDos()
        {
            if (int.TryParse(TxtNoPagniaDos.Text, out int currentPage) &&
                int.TryParse(TxtDeDos.Text, out int totalPages))
            {
                button1.Enabled = currentPage > 1;
                button2.Enabled = currentPage < totalPages;
            }
        }
    }
}
