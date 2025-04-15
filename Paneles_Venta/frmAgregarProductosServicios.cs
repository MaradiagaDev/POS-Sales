using iTextSharp.text.xml;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles;
using NeoCobranza.Properties;
using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        byte[] imagenBytes;
        string AuxSucursal;

        public frmAgregarProductosServicios(PnlPrincipal frmPrincipal, decimal ordenId,string sucursal, string opc, bool dgi, bool alcaldia, string descuento)
        {
            AuxSucursal = sucursal.Trim();
            InitializeComponent();

            DataTable dtResponse = dataUtilities.GetAllRecords("Empresa");

            if (dtResponse.Rows.Count > 0)
            {
                imagenBytes = dtResponse.Rows[0]["NoImagen"] as byte[];
            }

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
                        dynamicDataTableProductos.Columns.Add("Descripcion", typeof(string));
                        dynamicDataTableProductos.Columns.Add("Img", typeof(byte[]));
                        //dynamicDataTableProductos.Columns.Add($"Precio Unitario $ ({Utilidades.Tasa})", typeof(string));

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

                    //parte de almacenes
                    CmbAlmacen.Visible = true;
                    LblAlmacen.Visible = true;
                    //OBTENER EL ALMACEN MOSTRADOR
                    DataTable dtResponseAlm = dataUtilities.GetAllRecords("Almacenes");
                    var filterRowAlm =
                        from row in dtResponseAlm.AsEnumerable()
                        where Convert.ToString(row.Field<string>("SucursalId")) == Utilidades.SucursalId
                        select row;

                    if (filterRowAlm.Any())
                    {
                        CmbAlmacen.ValueMember = "AlmacenId";
                        CmbAlmacen.DisplayMember = "NombreAlmacen";
                        CmbAlmacen.DataSource = filterRowAlm.CopyToDataTable();
                    }
                    else
                    {
                        MessageBox.Show("Debe agregar un almacén a la sucursal.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Close();
                    }

                    //OBTENER EL ALMACEN MOSTRADOR
                    DataTable dtResponseMostrador = dataUtilities.GetAllRecords("Almacenes");
                    var filterRowMostrador =
                        from row in dtResponseMostrador.AsEnumerable()
                        where Convert.ToBoolean(row.Field<bool>("EsMostrador")) == true
                        && Convert.ToString(row.Field<string>("SucursalId")) == Utilidades.SucursalId
                        select row;

                    if (filterRowMostrador.Any())
                    {
                        DataTable dtAlmacenMostrador = filterRowMostrador.CopyToDataTable();

                        CmbAlmacen.SelectedValue = Convert.ToString(dtAlmacenMostrador.Rows[0]["AlmacenId"]);
                    }


                    break;
                case "Servicios":
                    llbTitulo.Text = "Agregar Servicios a la Orden";

                    if (dynamicDataTableProductos.Columns.Count < 3)
                    {
                        dynamicDataTableProductos.Columns.Add("Id", typeof(string));
                        dynamicDataTableProductos.Columns.Add("Producto", typeof(string));
                        dynamicDataTableProductos.Columns.Add("Precio Unitario (NIO)", typeof(string));
                        dynamicDataTableProductos.Columns.Add("Descripcion", typeof(string));
                        dynamicDataTableProductos.Columns.Add("Img", typeof(byte[]));
                        //dynamicDataTableProductos.Columns.Add($"Precio Unitario $ ({Utilidades.Tasa})", typeof(string));
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

        // Método para mostrar los productos en forma de tarjetas en un FlowLayoutPanel
        private void MostrarProductosEnTarjetas()
        {
            flowLayoutPanelProductos.AutoScroll = true;

            // Limpia los controles anteriores
            flowLayoutPanelProductos.Controls.Clear();

            // Recorre cada fila del DataTable que contiene tus productos/servicios
            // Suponiendo que tu DataTable tiene una columna "ImagePath" o "Imagen" que contenga la ruta o el dato binario de la imagen
            foreach (DataRow row in dynamicDataTableProductos.Rows)
            {
                Panel panelProducto = new Panel();
                panelProducto.Width = 220;
                panelProducto.Height = 250; // Ajusta la altura según necesites
                panelProducto.BorderStyle = BorderStyle.FixedSingle;
                panelProducto.Margin = new Padding(10);

                // Botón de información (icono) en la esquina superior derecha
                Button btnInfo = new Button();
                btnInfo.Size = new Size(25, 25);
                // Ubicar el botón en la esquina superior derecha del panel (ajustando márgenes)
                btnInfo.Location = new Point(panelProducto.Width - btnInfo.Width - 5, 5);
                btnInfo.FlatStyle = FlatStyle.Flat;
                btnInfo.FlatAppearance.BorderSize = 0;
                btnInfo.BackColor = Color.Transparent;
                // Asigna la imagen de tu recurso (asegúrate de tenerla en Resources, por ejemplo, Resources.InfoIcon)
                btnInfo.Image = Resources.InfoIcon;

                // Cambia el cursor para indicar que es interactivo
                btnInfo.Cursor = Cursors.Hand;
                panelProducto.Controls.Add(btnInfo);

                // Configurar el ToolTip para el botón de información
                ToolTip infoToolTip = new ToolTip();
                infoToolTip.ToolTipTitle = "Descripción";
                // Puedes personalizar la demora y duración del ToolTip si lo deseas:
                infoToolTip.AutoPopDelay = 5000;
                infoToolTip.InitialDelay = 500;
                infoToolTip.ReshowDelay = 500;
                // Asigna el texto que se mostrará al pasar el mouse
                infoToolTip.SetToolTip(btnInfo, Convert.ToString(row["Descripcion"]));

                // Opcional: si deseas que el mensaje también se muestre al hacer click, puedes manejar el evento Click:
                btnInfo.Click += (s, e) =>
                {
                    // Por ejemplo, mostrar un pequeño label temporal o cualquier otra acción
                    Label lblInfo = new Label();
                    lblInfo.Text = Convert.ToString(row["Descripcion"]);
                    lblInfo.AutoSize = true;
                    lblInfo.BackColor = Color.LightYellow;
                    // Ubicar el label debajo del botón de info
                    lblInfo.Location = new Point(btnInfo.Left, btnInfo.Bottom + 2);
                    panelProducto.Controls.Add(lblInfo);

                    // Quitar el label después de unos segundos (por ejemplo, 3 segundos)
                    var t = new Timer();
                    t.Interval = 3000;
                    t.Tick += (s2, e2) =>
                    {
                        panelProducto.Controls.Remove(lblInfo);
                        t.Stop();
                    };
                    t.Start();
                };

                // PictureBox para la imagen
                PictureBox pbImagen = new PictureBox();
                pbImagen.Location = new Point(0, 10);
                pbImagen.Size = new Size(235, 120);
                pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
                byte[] imagenBytesProd = row["Img"] as byte[];

                if (imagenBytesProd != null)
                {
                    using (MemoryStream ms = new MemoryStream(imagenBytesProd))
                    {
                        pbImagen.Image = Image.FromStream(ms);
                        pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                else
                {
                    if (imagenBytes != null)
                    {
                        using (MemoryStream ms = new MemoryStream(imagenBytes))
                        {
                            pbImagen.Image = Image.FromStream(ms);
                            pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                    else
                    {
                        pbImagen.Image = Resources.ImgNoDisponible;
                        pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                panelProducto.Controls.Add(pbImagen);

                // Etiqueta para el nombre del producto con wrap
                Label lblNombre = new Label();
                lblNombre.Text = row["Producto"].ToString();
                lblNombre.Font = new Font(lblNombre.Font, FontStyle.Bold);
                lblNombre.AutoSize = false;                  // Desactiva el auto ajuste para controlar el tamaño
                lblNombre.Location = new Point(10, 140);
                lblNombre.Size = new Size(200, 40);            // Ajusta el ancho y la altura para permitir el wrap
                lblNombre.TextAlign = ContentAlignment.TopLeft;
                lblNombre.BackColor = Color.Transparent;
                panelProducto.Controls.Add(lblNombre);

                // Etiqueta para el precio unitario
                Label lblPrecio = new Label();
                if(auxOpc == "Productos")
                {
                    lblPrecio.Text = "P/U: " + Convert.ToString(row["Precio Unitario (NIO)"]) + $" C$ / Cant: {row["Cantidad"]}";
                }
                else
                {
                    lblPrecio.Text = "P/U: " + Convert.ToString(row["Precio Unitario (NIO)"]) + $" C$";
                }
                
                lblPrecio.AutoSize = true;
                lblPrecio.Location = new Point(10, 185);
                panelProducto.Controls.Add(lblPrecio);

                // Botón para agregar a la venta
                Button btnAgregar = new Button();
                btnAgregar.Text = "Agregar";
                btnAgregar.Size = new Size(100, 40); // Botón más grande
                btnAgregar.BackColor = Color.DarkGreen;
                btnAgregar.ForeColor = Color.White;
                btnAgregar.Font = new Font("Arial", 12, FontStyle.Bold); // Fuente más grande y en negrita
                btnAgregar.Location = new Point(120, 210);

                btnAgregar.Click += (s, e) =>
                {
                    AgregarProductosOrden(row["Id"].ToString(), TxtCantidadProducto.Text.Trim(), "Increase");
                };
                panelProducto.Controls.Add(btnAgregar);

                // Botón de disponibilidad, solo se muestra si es de tipo "Producto"
                if (auxOpc == "Productos")
                {
                    Button btnDisponibilidad = new Button();
                    btnDisponibilidad.Text = "Disponibilidad";
                    btnDisponibilidad.Size = new Size(100, 30);
                    btnDisponibilidad.Location = new Point(10, 210);
                    btnDisponibilidad.Click += (s, e) =>
                    {
                        PnlDisponibilidad disponibilidad = new PnlDisponibilidad(row["Id"].ToString());
                        disponibilidad.ShowDialog();
                    };
                    panelProducto.Controls.Add(btnDisponibilidad);
                }

                flowLayoutPanelProductos.Controls.Add(panelProducto);
            }

        }


        private void Buscar()
        {
            // Validar y obtener el número de página actual.
            int pageNumber = 1;
            if (!int.TryParse(TxtPaginaNo.Text, out pageNumber))
            {
                pageNumber = 1;
                TxtPaginaNo.Text = "1";
            }

            // Definir el tamaño de página (en este ejemplo se usan 20 registros por página)
            int pageSize = 20;

            switch (auxOpc)
            {
                case "Productos":
                    dynamicDataTableProductos.Rows.Clear();

                    if (CmbAlmacen.SelectedValue == null)
                    {
                        return;
                    }

                    // Limpiar parámetros previos y configurar los nuevos para la búsqueda de productos con paginación.
                    dataUtilities.ClearParameters();
                    dataUtilities.SetParameter("@AlmacenId", CmbAlmacen.SelectedValue);
                    dataUtilities.SetParameter("@CategoriaId", CmbTipoServicio.SelectedValue);
                    dataUtilities.SetParameter("@Filtro", TxtBuscarProductos.Texts);
                    dataUtilities.SetParameter("@PageNumber", pageNumber);
                    dataUtilities.SetParameter("@PageSize", pageSize);
                    // Configurar el parámetro de salida para el total de registros.
                    dataUtilities.SetParameter("@TotalRecords", System.Data.SqlDbType.Int, direction: System.Data.ParameterDirection.Output);

                    DataTable dtResponseSp1 = dataUtilities.ExecuteStoredProcedure("sp_ObtenerCantidadProductoPorAlmacen");

                    foreach (DataRow row in dtResponseSp1.Rows)
                    {
                        dynamicDataTableProductos.Rows.Add(
                            Convert.ToString(row["ID"]),
                            Convert.ToString(row["PRODUCTO"]),
                            Convert.ToString(row["PRECIO (NIO)"]),
                            Convert.ToString(row["EXISTENCIA"]),
                            Convert.ToString(row["Descripcion"]),
                            row["Img"]
                        );
                    }

                    // Recuperar el total de registros desde el parámetro de salida y actualizar el control de total de páginas.
                    int totalRecords = Convert.ToInt32(dataUtilities.GetParameterValue("@TotalRecords"));
                    int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                    TxtPaginaDe.Text = totalPages.ToString();

                    dataUtilities.ClearOutPutParameters();
                    break;

                case "Servicios":
                    dynamicDataTableProductos.Rows.Clear();

                    // Limpiar parámetros previos y configurar los nuevos para la búsqueda de servicios con paginación.
                    dataUtilities.SetParameter("@CategoriaId", CmbTipoServicio.SelectedValue);
                    dataUtilities.SetParameter("@Filtro", TxtBuscarProductos.Texts);
                    dataUtilities.SetParameter("@PageNumber", pageNumber);
                    dataUtilities.SetParameter("@PageSize", pageSize);
                    // Configurar el parámetro de salida para el total de registros.
                    dataUtilities.SetParameter("@TotalRecords", System.Data.SqlDbType.Int, direction: System.Data.ParameterDirection.Output);

                    DataTable dtResponseSp = dataUtilities.ExecuteStoredProcedure("sp_ObtenerServicios");

                    foreach (DataRow row in dtResponseSp.Rows)
                    {
                        dynamicDataTableProductos.Rows.Add(
                            Convert.ToString(row["ID"]),
                            Convert.ToString(row["SERVICIO"]),
                            Convert.ToString(row["PRECIO (NIO)"]),
                            Convert.ToString(row["Descripcion"]),
                            row["Img"]
                        );
                    }

                    // Recuperar el total de registros desde el parámetro de salida y actualizar el control de total de páginas.
                    int totalRecordsServicios = Convert.ToInt32(dataUtilities.GetParameterValue("@TotalRecords"));
                    int totalPagesServicios = (int)Math.Ceiling((double)totalRecordsServicios / pageSize);
                    TxtPaginaDe.Text = totalPagesServicios.ToString();
                    dataUtilities.ClearOutPutParameters();
                    break;
            }

            // Actualiza la vista de productos/servicios en tarjetas.
            MostrarProductosEnTarjetas();
        }



        private void TxtBuscarProductos__TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }


        public decimal TxtPrecioVariable = 0;
        public void AgregarProductosOrden(string idProd, string Cantidad, string opc)
        {
            DataRow itemProductoAux = dataUtilities.getRecordByPrimaryKey("ProductosServicios", idProd).Rows[0];

            if (itemProductoAux["BitVariable"] != DBNull.Value)
            {
                if (Convert.ToBoolean(itemProductoAux["BitVariable"]) && opc == "Increase")
                {
                    PnlPrecioNuevo frmAux = new PnlPrecioNuevo(null,this);
                    frmAux.ShowDialog();

                    if (TxtPrecioVariable == 0)
                    {
                        MessageBox.Show("Debe digitar el precio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            if (Convert.ToString(itemProductoAux["ClasificacionProducto"]) == "Productos")
            {


                //VERIFICAR EL STOCK
                dataUtilities.SetParameter("@ProductId", idProd);
                dataUtilities.SetParameter("@WarehouseId", CmbAlmacen.SelectedValue);
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
                        dataUtilities.SetParameter("@WarehouseId", CmbAlmacen.SelectedValue);
                        dataUtilities.SetParameter("@SucursalId", AuxSucursal);
                        if (TxtPrecioVariable > 0)
                        {
                            dataUtilities.SetParameter("@Precio", TxtPrecioVariable);
                        }
                        dataUtilities.SetParameter("@Discount", 0);
                        dataUtilities.SetParameter("@Total", 0);
                        dataUtilities.SetParameter("@Subtotal", 0);
                        dataUtilities.SetParameter("@IVA", 0);
                        dataUtilities.SetParameter("@HistorialId", SqlDbType.Int, ParameterDirection.Output);

                        PnlAgregarVencimientosProveedores frmaux = new PnlAgregarVencimientosProveedores(idProd, Convert.ToString(CmbAlmacen.SelectedValue), Cantidad);
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
                    dataUtilities.SetParameter("@WarehouseId", CmbAlmacen.SelectedValue);
                    dataUtilities.SetParameter("@SucursalId", AuxSucursal);
                    if (TxtPrecioVariable > 0)
                    {
                        dataUtilities.SetParameter("@Precio", TxtPrecioVariable);
                    }
                    dataUtilities.SetParameter("@Discount", 0);
                    dataUtilities.SetParameter("@Total", 0);
                    dataUtilities.SetParameter("@Subtotal", 0);
                    dataUtilities.SetParameter("@IVA", 0);
                    dataUtilities.SetParameter("@HistorialId", SqlDbType.Int, ParameterDirection.Output);

                    PnlAgregarVencimientosProveedores frmaux = new PnlAgregarVencimientosProveedores(idProd, Convert.ToString(CmbAlmacen.SelectedValue), Cantidad);
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
                dataUtilities.SetParameter("@SucursalId", AuxSucursal);
                if (TxtPrecioVariable > 0)
                {
                    dataUtilities.SetParameter("@Precio", TxtPrecioVariable);
                }
                dataUtilities.SetParameter("@Subtotal", 0);
                dataUtilities.SetParameter("@IVA", 0);
                dataUtilities.SetParameter("@HistorialId", SqlDbType.Int, ParameterDirection.Output);

                DataTable dtResponseTotales = dataUtilities.ExecuteStoredProcedure("sp_ManageOrderServiceDetail");
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

            CalcularTotales(auxDescuento);
        }

        public void CalcularTotales(string descuento)
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
            auxPnlPrincipal.AbrirVenta(auxOrdenId,AuxSucursal);
        }

        private void CmbTipoServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void CmbAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TxtPaginaNo.Text, out int currentPage) && currentPage > 1)
            {
                currentPage--;
                TxtPaginaNo.Text = currentPage.ToString();
                Buscar();
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
                Buscar();
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

    }
}
