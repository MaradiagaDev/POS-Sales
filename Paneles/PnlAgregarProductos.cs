using NeoCobranza.ModelsCobranza;
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

namespace NeoCobranza.Paneles
{
    public partial class PnlAgregarProductos : Form
    {
        CatalogosInventario frmAuxPrincipal;
        public string auxOpc;
        public string auxId;
        public string auxModulo;
        public DataTable auxTablaDinamica = new DataTable();
        public DataTable auxTablaDinamicaProveedor = new DataTable();
        DataUtilities dataUtilities = new DataUtilities();

        //Nuevos Campos
        public bool bitTieneInventarioInicial = false;
        public decimal DecCantidad = 0;
        public decimal DecSubTotal = 0;
        public string strProveedor = "";
        public string strAlmacen = "";
        public string strProducto = "";

        private class TipoInventario
        {
            public string tipo { get; set; }

        }

        public PnlAgregarProductos(CatalogosInventario frm, string opc, string modulo, string id)
        {
            frmAuxPrincipal = frm;
            auxOpc = opc;
            auxId = id;
            auxModulo = modulo;

            InitializeComponent();
        }

        private void PnlAgregarProductos_Load(object sender, EventArgs e)
        {
            ConfigUI();
        }

        public void ConfigUI()
        {
            if (auxTablaDinamicaProveedor.Columns.Count == 0)
            {
                auxTablaDinamicaProveedor.Columns.Add("Id", typeof(string));
                auxTablaDinamicaProveedor.Columns.Add("Proveedor", typeof(string));

                //DgvProveedor.DataSource = auxTablaDinamicaProveedor;
            }

                //DataTable dtResponse = dataUtilities.GetAllRecords("Proveedores");
                //var filterRow = from row in dtResponse.AsEnumerable() where Convert.ToString(row.Field<string>("Estatus")) == "Activo" orderby row.Field<int>("IdProveedor") descending select row;

                //if (filterRow.Any() && auxModulo == "Productos")
                //{
                //    CmbProveedor.ValueMember = "IdProveedor";
                //    CmbProveedor.DisplayMember = "NombreEmpresa";
                //    CmbProveedor.DataSource = filterRow.CopyToDataTable();
                //}
                //else if (filterRow.Any() == false && auxModulo == "Productos")
                //{
                //    MessageBox.Show("Para agregar productos debe haber un proveedor ACTIVO.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    this.Close();
                //}
                //else
                //{
                //    PnlProveedores.Visible = false;
                //}

                DataTable dtResponseCategoria = dataUtilities.GetAllRecords("Categorizacion");

                //Categorizacion
                CmbTipoProducto.ValueMember = "CategorizacionId";
                CmbTipoProducto.DisplayMember = "Descripcion";
                CmbTipoProducto.DataSource = dtResponseCategoria;
            

            if (auxOpc != "Crear")
            {
                DataTable dtResponse = dataUtilities.getRecordByPrimaryKey("ProductosServicios", auxId);

                TxtNombre.Text = Convert.ToString(dtResponse.Rows[0]["NombreProducto"]);
                TxtDescripcion.Text = Convert.ToString(dtResponse.Rows[0]["Descripcion"]);
                TxtCodigo.Text = Convert.ToString(dtResponse.Rows[0]["Codigo"]);
                TxtPrecioVenta.Text = Convert.ToString(dtResponse.Rows[0]["Precio"]);
                CmbTipoProducto.SelectedValue = Convert.ToString(dtResponse.Rows[0]["CategoriaId"]);

                if(DBNull.Value != dtResponse.Rows[0]["BitVariable"])
                {
                    ChkPrecioVariable.Checked = Convert.ToBoolean(dtResponse.Rows[0]["BitVariable"]);
                }

                byte[] imagenBytes = dtResponse.Rows[0]["Img"] as byte[];

                if (imagenBytes != null)
                {
                    using (MemoryStream ms = new MemoryStream(imagenBytes))
                    {
                        PBImagenProducto.Image = Image.FromStream(ms);
                        PBImagenProducto.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }

                DataTable dtResponseRelacional = dataUtilities.getRecordByColumn("RelProveedoresProducto", "ProductoId", auxId);

                if (dtResponseRelacional.Rows.Count > 0)
                {
                    foreach (DataRow item in dtResponseRelacional.Rows)
                    {
                        DataTable dtProveedor = dataUtilities.getRecordByPrimaryKey("Proveedores", Convert.ToString(item["ProveedorId"]));

                        auxTablaDinamicaProveedor.Rows.Add(Convert.ToString(dtProveedor.Rows[0]["IdProveedor"]),
                            Convert.ToString(dtProveedor.Rows[0]["NombreEmpresa"]));
                    }
                }
            }

            if (auxModulo == "Productos")
            {
                LblNombreDinamico.Text = "Nombre del Producto";
                ChkPrecioVariable.Visible = false;
            }
            else if (auxModulo == "Servicios")
            {
                BtnInventarioInicial.Visible = false;
                LblNombreDinamico.Text = "Nombre del Servicio";
                //P/*nlProveedores.Visible = false;*/
                LblCodigo.Visible = false;
                TxtCodigo.Visible = false;
            }
            else if(auxModulo == "Adiciones")
            {
                TxtPrecioVenta.Visible = false;
                TxtPrecioVenta.Text = "0";

                label10.Visible = false;
                PBImagenProducto.Visible = false;
                BtnSeleccionarImagen.Visible = false;

                LblCodigo.Visible = false;
                TxtCodigo.Visible = false;

                BtnInventarioInicial.Visible = false;
                LblNombreDinamico.Text = "Nombre de la Adición";

                ChkPrecioVariable.Visible = false;
                TxtDescripcion.Visible = false;
                LblPrecioVenta.Visible= false;
                BtnAdiciones.Visible = false;
            }

            switch (auxOpc)
            {
                case "Crear":

                    if (auxModulo == "Productos")
                    {
                        LblDynamico.Text = "Crear Producto";
                        btnAgregar.Text = "Crear";
                    }
                    else if (auxModulo == "Servicios")
                    {
                        LblDynamico.Text = "Crear Servicio";
                        btnAgregar.Text = "Crear";

                    }
                    else if (auxModulo == "Adiciones")
                    {
                        LblDynamico.Text = "Crear Adición";
                        btnAgregar.Text = "Crear";

                    }

                    break;

                case "Modificar":

                    if (auxModulo == "Productos")
                    {
                        LblDynamico.Text = "Modificar Producto";
                        btnAgregar.Text = "Modificar";
                    }
                    else if (auxModulo == "Servicios")
                    {
                        LblDynamico.Text = "Modificar Servicios";
                        btnAgregar.Text = "Modificar";
                    }
                    else if (auxModulo == "Adiciones")
                    {
                        LblDynamico.Text = "Modificar Adición";
                        btnAgregar.Text = "Modificar";
                    }

                    break;
            }
        }

        //private void MostrarImagenEnPictureBox(byte[] imagenBytes, PictureBox pictureBox)
        //{
        //    try
        //    {
        //        using (MemoryStream ms = new MemoryStream(imagenBytes))
        //        {
        //            Image imagen = Image.FromStream(ms);
        //            pictureBox.Image = imagen;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        public void FuncionesPrincipales()
        {
            if (TxtNombre.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe agregar un nombre identificador.", "Atención",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtNombre.Focus();
                return;
            }

            //if (auxTablaDinamicaProveedor.Rows.Count == 0 && auxModulo == "Productos")
            //{
            //    MessageBox.Show("Debe agregar al menos un Proveedor.", "Atención",
            //   MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            if (!decimal.TryParse(TxtPrecioVenta.Text.Trim(), out decimal _disponible) )
            {

                MessageBox.Show("El monto de venta no es valido.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtPrecioVenta.Focus();
                return;
            }

            if (_disponible == 0 && ChkPrecioVariable.Checked == false && auxModulo != "Adiciones")
            {
                MessageBox.Show("El monto de venta está vacío.", "Atención",
                                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtPrecioVenta.Focus();
                return;
            }

            //Verificar los tipo servicios
            if (CmbTipoProducto.Items.Count == 0)
            {
                MessageBox.Show("Debe agregar un Tipo de Servicio/Producto en el Módulo del Catalogos.", "Atención",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtPrecioVenta.Focus();
                return;
            }


            if (auxOpc == "Crear")
            {

                if (TxtCodigo.Text.Trim().Length > 0)
                {
                    DataTable dtResponseCodigo = dataUtilities.GetAllRecords("ProductosServicios");
                    var filterRow = from row in dtResponseCodigo.AsEnumerable() where Convert.ToString(row.Field<string>("Codigo")) == TxtCodigo.Text.Trim() select row;

                    if (filterRow.Any())
                    {
                        MessageBox.Show("Ya existe un producto con ese codigo. Los codigos deben de ser individuales por producto.", "Atención",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                try
                {
                    string idProductoCrear = Guid.NewGuid().ToString().Substring(0,10);

                    strProducto = idProductoCrear;

                    dataUtilities.SetColumns("ProductoId", idProductoCrear);
                    dataUtilities.SetColumns("NombreProducto", TxtNombre.Text.Trim());
                    dataUtilities.SetColumns("ImagenId",0);
                    dataUtilities.SetColumns("Descripcion", TxtDescripcion.Text.Trim());
                    dataUtilities.SetColumns("Estado", "Activo");
                    dataUtilities.SetColumns("Precio", TxtPrecioVenta.Text.Trim());
                    dataUtilities.SetColumns("ClasificacionProducto", auxModulo);
                    dataUtilities.SetColumns("CategoriaId", Convert.ToInt32(CmbTipoProducto.SelectedValue.ToString()));
                    dataUtilities.SetColumns("Codigo", TxtCodigo.Text.Trim());
                    dataUtilities.SetColumns("BitVariable",ChkPrecioVariable.Checked);

                    if (PBImagenProducto.Image != null)
                    {
                        byte[] imagenBytes = ImageToByteArray(PBImagenProducto.Image);
                        dataUtilities.SetColumns("Img", imagenBytes);
                    }

                    dataUtilities.InsertRecord("ProductosServicios");

                    if (auxModulo == "Productos")
                    {
                        foreach (DataRow row in auxTablaDinamicaProveedor.Rows)
                        {
                            dataUtilities.SetColumns("ProveedorId", int.Parse(row[0].ToString()));
                            dataUtilities.SetColumns("ProductoId", idProductoCrear);

                            dataUtilities.InsertRecord("RelProveedoresProducto");
                        }

                        DataTable dtResponseAlmacenes = dataUtilities.GetAllRecords("Almacenes");

                        foreach (DataRow item in dtResponseAlmacenes.Rows)
                        {
                            dataUtilities.SetColumns("AlmacenId", Convert.ToString(item["AlmacenId"]));
                            dataUtilities.SetColumns("ProductoId", idProductoCrear);
                            dataUtilities.SetColumns("Cantidad", 0);

                            dataUtilities.InsertRecord("RelAlmacenProducto");
                        }
                    }

                    frmAuxPrincipal.vMCatalogosInventario.InitModuloCatalogosInventario(frmAuxPrincipal, auxModulo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se pudo crear el producto. Error: {ex.Message}", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    if (TxtCodigo.Text.Trim().Length > 0)
                    {
                        DataTable dtResponseCodigo = dataUtilities.GetAllRecords("ProductosServicios");
                        var filterRow = from row in dtResponseCodigo.AsEnumerable()
                                        where Convert.ToString(row.Field<string>("Codigo")) == TxtCodigo.Text.Trim() 
                                        && Convert.ToString(row.Field<string>("ProductoId")) != auxId
                                        select row;

                        if (filterRow.Any())
                        {
                            MessageBox.Show("Ya existe un producto con ese codigo. Los codigos deben de ser individuales por producto.", "Atención",
                                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    strProducto = auxId;

                    //Datos del servicio
                    dataUtilities.SetColumns("NombreProducto", TxtNombre.Text.Trim());
                    dataUtilities.SetColumns("ImagenId", 0);
                    dataUtilities.SetColumns("Descripcion", TxtDescripcion.Text.Trim());
                    dataUtilities.SetColumns("Estado", "Activo");
                    dataUtilities.SetColumns("Precio", TxtPrecioVenta.Text.Trim());
                    dataUtilities.SetColumns("ClasificacionProducto", auxModulo);
                    dataUtilities.SetColumns("CategoriaId", Convert.ToInt32(CmbTipoProducto.SelectedValue.ToString()));
                    dataUtilities.SetColumns("Codigo", TxtCodigo.Text.Trim());
                    dataUtilities.SetColumns("BitVariable", ChkPrecioVariable.Checked);

                    if (PBImagenProducto.Image != null)
                    {
                        byte[] imagenBytes = ImageToByteArray(PBImagenProducto.Image);
                        dataUtilities.SetColumns("Img", imagenBytes);
                    }

                    dataUtilities.UpdateRecordByPrimaryKey("ProductosServicios",auxId);


                    if (auxModulo == "Productos")
                    {

                        foreach (DataRow row in auxTablaDinamicaProveedor.Rows)
                        {
                            dataUtilities.SetColumns("ProveedorId", int.Parse(row[0].ToString()));
                            dataUtilities.SetColumns("ProductoId", auxId);

                            dataUtilities.InsertRecord("RelProveedoresProducto");
                        }
                    }

                    frmAuxPrincipal.vMCatalogosInventario.InitModuloCatalogosInventario(frmAuxPrincipal, auxModulo);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se pudo modificar el producto. Error: {ex.Message}", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            //Parte de Inventario Inicial
            try
            {
                if (bitTieneInventarioInicial)
                {
                    //agregar la compra
                    string idCompra = Guid.NewGuid().ToString();

                    dataUtilities.SetColumns("CompraId", idCompra);
                    dataUtilities.SetColumns("usuario", Utilidades.Usuario);
                    dataUtilities.SetColumns("AlmacenId", strAlmacen);
                    dataUtilities.SetColumns("SucursalId", Utilidades.SucursalId);
                    dataUtilities.SetColumns("Descripcion", $"COMPRA INICIAL {DateTime.Now}");
                    dataUtilities.SetColumns("CostoTotal", DecSubTotal);
                    dataUtilities.SetColumns("FechaAlta", DateTime.Now);

                    dataUtilities.InsertRecord("Compras");

                    //Detalle de la compra
                    string idLote = Guid.NewGuid().ToString();

                    dataUtilities.SetColumns("LoteId", idLote);
                    dataUtilities.SetColumns("ProductoId", strProducto);
                    dataUtilities.SetColumns("CompraId", idCompra);
                    dataUtilities.SetColumns("Cantidad", DecCantidad);
                    dataUtilities.SetColumns("FechaCreacion", DateTime.Now);
                    dataUtilities.SetColumns("AlmacenId", strAlmacen);
                    dataUtilities.SetColumns("ProveedorId", strProveedor);
                    dataUtilities.SetColumns("CostoU",   DecSubTotal/ DecCantidad);
                    dataUtilities.SetColumns("SubTotal", DecSubTotal);

                    dataUtilities.InsertRecord("CompraDetalles");

                    //Agregar cantidades
                    DataTable dtResponse = dataUtilities.GetAllRecords("RelAlmacenProducto");
                    var filterRow =
                        from row in dtResponse.AsEnumerable()
                        where Convert.ToString(row.Field<string>("AlmacenId")) == strAlmacen
                        && Convert.ToString(row.Field<string>("ProductoId")) == strProducto
                        select row;

                    dtResponse = filterRow.CopyToDataTable();

                    decimal idRelAlmacenProducto = Convert.ToDecimal(dtResponse.Rows[0]["RelAlmacenProductoId"]);
                    decimal cantidadActual = Convert.ToDecimal(dtResponse.Rows[0]["Cantidad"]);

                    //Actualizar la cantidad
                    decimal cantidadActualizada = cantidadActual + DecCantidad;

                    dataUtilities.SetColumns("Cantidad", cantidadActualizada);
                    dataUtilities.UpdateRecordByPrimaryKey("RelAlmacenProducto", idRelAlmacenProducto);

                }

                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo crear el producto. Error: {ex.Message}", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] ImageToByteArray(Image image)
        {
            if (image == null)
            {
                // Manejo de error: la imagen es nula
                return null;
            }

            // Obtener la ruta del directorio del ensamblado
            string directorioEnsamblado = AppDomain.CurrentDomain.BaseDirectory;

            // Crear una carpeta en el directorio del ensamblado si no existe
            string rutaCarpeta = Path.Combine(directorioEnsamblado, "ImagenesBD");
            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }

            // Guardar la imagen en la carpeta
            string nombreArchivo = "img.png";  // Cambia el nombre según tus necesidades
            string rutaImagen = Path.Combine(rutaCarpeta, nombreArchivo);

            // Intenta guardar la imagen
            try
            {
                image.Save(rutaImagen, System.Drawing.Imaging.ImageFormat.Png);
                return File.ReadAllBytes(rutaImagen);
            }
            catch (Exception ex)
            {
                // Manejo de error: muestra o registra la excepción
                Console.WriteLine($"Error al convertir la imagen a bytes: {ex.Message}");
                return null;
            }
        }



        //private void ChkDisponibleContrato_Click(object sender, EventArgs e)
        //{
        //    if (ChkDisponibleContrato.Checked)
        //    {
        //        LblPrecioContrato.Enabled = true;
        //        TxtPrecioContrato.Enabled = true;
        //        TxtPrecioContrato.Text = "";
        //        TxtPrecioContrato.Focus();
        //    }
        //    else
        //    {
        //        LblPrecioContrato.Enabled = false;
        //        TxtPrecioContrato.Enabled = false;
        //        TxtPrecioContrato.Text = "0";
        //    }
        //}

        //private void ChkDisponibleMejoras_Click(object sender, EventArgs e)
        //{
        //    if (ChkDisponibleMejoras.Checked)
        //    {
        //        LblPrecioMejora.Enabled = true;
        //        TxtPrecioMejora.Enabled = true;
        //        TxtPrecioMejora.Text = "";
        //        TxtPrecioMejora.Focus();
        //    }
        //    else
        //    {
        //        LblPrecioMejora.Enabled = false;
        //        TxtPrecioMejora.Enabled = false;
        //        TxtPrecioMejora.Text = "0";
        //    }
        //}

        //private void BtnAgregarSucursal_Click(object sender, EventArgs e)
        //{
        //    if (CmbSucursal.Items.Count > 0)
        //    {

        //        foreach (DataRow row in auxTablaDinamica.Rows)
        //        {
        //            if (row[0].ToString() == CmbSucursal.SelectedValue.ToString())
        //            {
        //                MessageBox.Show("La Sucursal seleccionada ya ha sido agregada.", "Atención",
        //                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                return;
        //            }
        //        }

        //        auxTablaDinamica.Rows.Add(CmbSucursal.SelectedValue.ToString(), CmbSucursal.Text);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Debe agregar una Sucursal en la sección de Catalogo para realizar esta acción.", "Atención",
        //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        //private void BtnQuitarSucursal_Click(object sender, EventArgs e)
        //{
        //    if (dgvSucursalesProductos.SelectedRows.Count > 0)
        //    {
        //        auxTablaDinamica.Rows.RemoveAt(dgvSucursalesProductos.SelectedRows[0].Index);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Debe seleccionar una Sucursal en la lista para quitarla.", "Atención",
        //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        //private void BtnSeleccionarImagen_Click(object sender, EventArgs e)
        //{
        //    ImgProducto.SizeMode = PictureBoxSizeMode.StretchImage;

        //    OpenFileDialog.Filter = "Imagenes JPG|*.jpg|Imagenes JPEG|*.jpeg";
        //    if (OpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        ImgProducto.Image = Image.FromFile(OpenFileDialog.FileName);

        //    }
        //}

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FuncionesPrincipales();
        }


        private void ImgProducto_Click(object sender, EventArgs e)
        {

        }

        //private void ChkDisponibleVentas_Click_1(object sender, EventArgs e)
        //{
        //    if (ChkDisponibleVentas.Checked)
        //    {
        //        LblPrecioVenta.Enabled = true;
        //        TxtPrecioVenta.Enabled = true;
        //        TxtPrecioVenta.Text = "";
        //        TxtPrecioVenta.Focus();
        //    }
        //    else
        //    {
        //        LblPrecioVenta.Enabled = false;
        //        TxtPrecioVenta.Enabled = false;
        //        TxtPrecioVenta.Text = "0";
        //    }
        //}

        private void TxtPrecioVenta_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }


        private void BtnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Seleccionar Imagen";
                openFileDialog.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Muestra la imagen en un PictureBox llamado "pbLogo"
                    PBImagenProducto.Image = Image.FromFile(openFileDialog.FileName);
                    PBImagenProducto.SizeMode = PictureBoxSizeMode.Zoom;

                    // Si necesitas guardar la ruta de la imagen
                    string rutaImagen = openFileDialog.FileName;
                }
            }
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            PnlConfigInventarioInicial frm = new PnlConfigInventarioInicial(this);
            frm.ShowDialog();
        }

        private void BtnAdiciones_Click(object sender, EventArgs e)
        {
            if (auxId != "")
            {
                PnlCatalogoAdiciones frm = new PnlCatalogoAdiciones(auxId);
                frm.ShowDialog();
            }
            else 
            {
                MessageBox.Show("Antes de agregar adiciones debe guardar el producto.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //private void BtnAgregarProveedor_Click(object sender, EventArgs e)
        //{
        //    if (CmbProveedor.Items.Count > 0)
        //    {

        //        foreach (DataRow row in auxTablaDinamicaProveedor.Rows)
        //        {
        //            if (row[0].ToString() == CmbProveedor.SelectedValue.ToString())
        //            {
        //                MessageBox.Show("El Proveedor seleccionado ya ha sido agregado.", "Atención",
        //                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                return;
        //            }
        //        }

        //        auxTablaDinamicaProveedor.Rows.Add(CmbProveedor.SelectedValue.ToString(), CmbProveedor.Text);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Debe agregar un Proveedor en la sección de Catalogo para realizar esta acción.", "Atención",
        //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        //private void BtnQuitarProveedor_Click(object sender, EventArgs e)
        //{
        //    if (DgvProveedor.SelectedRows.Count > 0)
        //    {
        //        auxTablaDinamicaProveedor.Rows.RemoveAt(DgvProveedor.SelectedRows[0].Index);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Debe seleccionar un Proveeedor en la lista para quitarlo.", "Atención",
        //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}
    }
}



//Imagenes imagen = db.Imagenes.Where(c => c.IdImagen == servicios.IdImagen).FirstOrDefault();
//if (imagen != null)
//{
//    if (imagen.Imagen != null)
//    {
//        MostrarImagenEnPictureBox(imagen.Imagen, ImgProducto);
//    }
//}

////Primero agregar la imagen

//int _idImg = Utilidades.IdImagenInicial;

//if (this.ImgProducto.Image != null)
//{
//    Imagenes img = new Imagenes()
//    {
//        Imagen = ImageToByteArray(ImgProducto.Image)
//    };

//    db.Add(img);
//    db.SaveChanges();

//    _idImg = img.IdImagen;
//}