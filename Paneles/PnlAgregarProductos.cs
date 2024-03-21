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

                DgvProveedor.DataSource = auxTablaDinamicaProveedor;
            }

            if (auxTablaDinamica.Columns.Count == 0)
            {
                auxTablaDinamica.Columns.Add("Id", typeof(string));
                auxTablaDinamica.Columns.Add("Sucursal", typeof(string));

                dgvSucursalesProductos.DataSource = auxTablaDinamica;
            }

            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                //Sucursales
                List<Sucursales> listSucursales = db.Sucursales.Where(c => c.Estado == "Activo").OrderByDescending(c => c.SucursalId).ToList();
                CmbSucursal.ValueMember = "SucursalId";
                CmbSucursal.DisplayMember = "NombreSucursal";
                CmbSucursal.DataSource = listSucursales;

                //Proveedor
                List<Proveedores> listProveedor = db.Proveedores.Where(c => c.Estatus == true).OrderBy(c => c.NombreEmpresa).ToList();
                CmbProveedor.ValueMember = "IdProveedor";
                CmbProveedor.DisplayMember = "NombreEmpresa";
                CmbProveedor.DataSource = listProveedor;

                //Tipo Producto
                List<TipoServicios> listTipos = db.TipoServicios.Where(c => c.Estado == "Activo").OrderByDescending(c => c.TipoServicionId).ToList();
                CmbTipoProducto.ValueMember = "TipoServicionId";
                CmbTipoProducto.DisplayMember = "Descripcion";
                CmbTipoProducto.DataSource = listTipos;

                //Tipo Inventario
                List<TipoInventario> listTiposInventario = new List<TipoInventario>();


                TipoInventario tipoUno = new TipoInventario()
                { tipo = "Expira" };

                TipoInventario tipoDos = new TipoInventario()
                { tipo = "No Expira" };

                listTiposInventario.Add(tipoUno);
                listTiposInventario.Add(tipoDos);

                CmbTipoInventario.ValueMember = "tipo";
                CmbTipoInventario.DisplayMember = "tipo";
                CmbTipoInventario.DataSource = listTiposInventario;

                TipoInventario tipoUnoManejo = new TipoInventario()
                { tipo = "PEPS" };

                TipoInventario tipoDosManejo = new TipoInventario()
                { tipo = "UEPS" };

                TipoInventario tipoTresManejo = new TipoInventario()
                { tipo = "PCPS" };

                List<TipoInventario> listTiposManejos = new List<TipoInventario>() { tipoUnoManejo, tipoDosManejo, tipoTresManejo };

                CmbManejoInventario.ValueMember = "tipo";
                CmbManejoInventario.DisplayMember = "tipo";
                CmbManejoInventario.DataSource = listTiposManejos;
            }

            if (auxOpc != "Crear")
            {
                using (NeoCobranzaContext db = new NeoCobranzaContext())
                {
                    ServiciosEstadares servicios = db.ServiciosEstadares.Where(c => c.IdEstandar == int.Parse(auxId)).FirstOrDefault();

                    TxtNombre.Text = servicios.NombreEstandar;
                    TxtDescripcion.Text = servicios.Descripcion;

                    ChkDisponibleVentas.Checked = servicios.MontoVd.ToString() == "0" ? false : true;
                    ChkDisponibleContrato.Checked = servicios.MontoContrato.ToString() == "0" ? false : true;
                    ChkDisponibleMejoras.Checked = servicios.MontoMejora.ToString() == "0" ? false : true;

                    TxtPrecioVenta.Enabled = servicios.MontoVd.ToString() == "0" ? false : true;
                    TxtPrecioContrato.Enabled = servicios.MontoContrato.ToString() == "0" ? false : true;
                    TxtPrecioMejora.Enabled = servicios.MontoMejora.ToString() == "0" ? false : true;

                    LblPrecioVenta.Enabled = servicios.MontoVd.ToString() == "0" ? false : true;
                    LblPrecioContrato.Enabled = servicios.MontoContrato.ToString() == "0" ? false : true;
                    LblPrecioMejora.Enabled = servicios.MontoMejora.ToString() == "0" ? false : true;

                    TxtCodigo.Text = servicios.Codigo == null ? "" : servicios.Codigo;

                    TxtPrecioVenta.Text = servicios.MontoVd.ToString();
                    TxtPrecioContrato.Text = servicios.MontoContrato.ToString();
                    TxtPrecioMejora.Text = servicios.MontoMejora.ToString();

                    if (servicios.ClasificacionInventario != null)
                    {
                        CmbTipoInventario.SelectedValue = servicios.ClasificacionInventario.ToString();
                    }

                    CmbTipoInventario.SelectedValue = servicios.Expira;
                    CmbManejoInventario.SelectedValue = servicios.ManejoInventario;

                    CmbTipoInventario.Enabled = false;
                    LblTipoInventario.Enabled = false;


                    Imagenes imagen = db.Imagenes.Where(c => c.IdImagen == servicios.IdImagen).FirstOrDefault();
                    if (imagen != null)
                    {
                        if (imagen.Imagen != null)
                        {
                            MostrarImagenEnPictureBox(imagen.Imagen, ImgProducto);
                        }
                    }

                    //Sucursales

                    List<RelProductoSucursales> listRel = db.RelProductoSucursales.Where(p => p.ProductoId == servicios.IdEstandar).ToList();

                    if (listRel.Count > 0)
                    {
                        foreach (var item in listRel)
                        {
                            Sucursales sucursales = db.Sucursales.Where(p => p.SucursalId == item.SucursalId).FirstOrDefault();

                            auxTablaDinamica.Rows.Add(sucursales.SucursalId.ToString(), sucursales.NombreSucursal);
                        }
                    }

                    //Proveedores

                    List<RelProveedorProducto> listRelProveedor = db.RelProveedorProducto.Where(s => s.ProductoId == servicios.IdEstandar).ToList();

                    if(listRelProveedor.Count > 0)
                    {
                        foreach(var item in listRelProveedor)
                        {
                            Proveedores proveedor = db.Proveedores.Where(s => s.IdProveedor == item.ProveedorId).FirstOrDefault();

                            auxTablaDinamicaProveedor.Rows.Add(proveedor.IdProveedor, proveedor.NombreEmpresa);
                        }
                    }
                }
            }


            if (auxModulo == "Productos")
            {
                LblNombreDinamico.Text = "Nombre del Producto";
            }
            else if (auxModulo == "Servicios")
            {
                LblNombreDinamico.Text = "Nombre del Servicio";
                CmbTipoInventario.Visible = false;
                LblTipoInventario.Visible = false;
                PnlProveedores.Visible = false;
                CmbManejoInventario.Visible = false;
                LblManejoInventario.Visible = false;
                LblCodigo.Visible = false;
                TxtCodigo.Visible = false;
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

                    break;
            }
        }

        private void MostrarImagenEnPictureBox(byte[] imagenBytes, PictureBox pictureBox)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(imagenBytes))
                {
                    Image imagen = Image.FromStream(ms);
                    pictureBox.Image = imagen;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FuncionesPrincipales()
        {
            if (TxtNombre.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe agregar un nombre identificador.", "Atención",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtNombre.Focus();
                return;
            }

            if (auxTablaDinamicaProveedor.Rows.Count == 0 && auxModulo == "Productos")
            {
                MessageBox.Show("Debe agregar al menos un Proveedor.", "Atención",
               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (auxTablaDinamica.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos una Sucursal.", "Atención",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Disponible en venta
            if (ChkDisponibleVentas.Checked)
            {
                decimal _disponible;

                if (TxtPrecioVenta.Text.Trim().Length == 0 || TxtPrecioVenta.Text.Trim() == "0" || TxtPrecioVenta.Text.Trim() == "00"
                    || TxtPrecioVenta.Text.Trim() == "000")
                {
                    MessageBox.Show("El monto de venta está vacío.", "Atención",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtPrecioVenta.Focus();
                    return;
                }

                if (!decimal.TryParse(TxtPrecioVenta.Text.Trim(), out _disponible))
                {
                    MessageBox.Show("El monto de venta no es valido.", "Atención",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtPrecioVenta.Focus();
                    return;
                }
            }

            //Disponible en contrato
            if (ChkDisponibleContrato.Checked)
            {
                decimal _disponible;

                if (TxtPrecioContrato.Text.Trim().Length == 0 || TxtPrecioContrato.Text.Trim() == "0" || TxtPrecioContrato.Text.Trim() == "00"
                    || TxtPrecioContrato.Text.Trim() == "000")
                {
                    MessageBox.Show("El monto de contrato está vacío.", "Atención",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtPrecioVenta.Focus();
                    return;
                }

                if (!decimal.TryParse(TxtPrecioContrato.Text.Trim(), out _disponible))
                {
                    MessageBox.Show("El monto de contrato no es valido.", "Atención",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtPrecioVenta.Focus();
                    return;
                }
            }

            //Disponible en mejora
            if (ChkDisponibleMejoras.Checked)
            {
                decimal _disponible;

                if (TxtPrecioMejora.Text.Trim().Length == 0 || TxtPrecioMejora.Text.Trim() == "0" || TxtPrecioMejora.Text.Trim() == "00"
                    || TxtPrecioMejora.Text.Trim() == "000")
                {
                    MessageBox.Show("El monto de mejora está vacío.", "Atención",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtPrecioVenta.Focus();
                    return;
                }

                if (!decimal.TryParse(TxtPrecioMejora.Text.Trim(), out _disponible))
                {
                    MessageBox.Show("El monto de mejora no es valido.", "Atención",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtPrecioVenta.Focus();
                    return;
                }
            }

            //Verificar los tipo servicios
            if (CmbTipoProducto.Items.Count == 0)
            {
                MessageBox.Show("Debe agregar un Tipo de Servicio/Producto en el Módulo del Catalogos.", "Atención",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtPrecioVenta.Focus();
                return;
            }

            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                if (auxOpc == "Crear")
                {

                    if (TxtCodigo.Text.Trim().Length > 0)
                    {
                        var VerificarCodigoCrear = db.ServiciosEstadares.Where(s => s.Codigo.Trim() == TxtCodigo.Text.Trim()).FirstOrDefault();

                        if(VerificarCodigoCrear != null)
                        {
                            MessageBox.Show("Ya existe un producto con ese codigo. Los codigos deben de ser individuales por producto.", "Atención",
                                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    try
                    {
                        //Primero agregar la imagen

                        int _idImg = Utilidades.IdImagenInicial;

                        if (this.ImgProducto.Image != null)
                        {
                            Imagenes img = new Imagenes()
                            {
                                Imagen = ImageToByteArray(ImgProducto.Image)
                            };

                            db.Add(img);
                            db.SaveChanges();

                            _idImg = img.IdImagen;
                        }

                        //Datos del servicio
                        ServiciosEstadares servicio = new ServiciosEstadares()
                        {
                            NombreEstandar = TxtNombre.Text.Trim(),
                            IdImagen = _idImg,
                            Descripcion = TxtDescripcion.Text.Trim(),
                            Estado = "Activo",
                            MontoVd = Double.Parse(TxtPrecioVenta.Text.Trim()),
                            MontoContrato = Double.Parse(TxtPrecioContrato.Text.Trim()),
                            MontoMejora = Double.Parse(TxtPrecioMejora.Text.Trim()),
                            ClasificacionTipo = int.Parse(CmbTipoProducto.SelectedValue.ToString()),
                            ClasificacionProducto = auxModulo == "Productos" ? 0 : 1,
                            ClasificacionInventario = CmbTipoInventario.Text.Trim(),
                            Expira = CmbTipoInventario.Text,
                            ManejoInventario = CmbManejoInventario.Text,
                            Codigo = TxtCodigo.Text.Trim(),
                        };

                        db.Add(servicio);
                        db.SaveChanges();

                        foreach (DataRow row in auxTablaDinamica.Rows)
                        {

                            RelProductoSucursales rel = new RelProductoSucursales()
                            {
                                RelProductoSucursalesId = Guid.NewGuid().ToString(),
                                ProductoId = servicio.IdEstandar,
                                SucursalId = int.Parse(row[0].ToString())
                            };

                            db.Add(rel);
                        }


                        if (auxModulo == "Productos")
                        {
                            foreach (DataRow row in auxTablaDinamicaProveedor.Rows)
                            {
                                RelProveedorProducto rel = new RelProveedorProducto()
                                {
                                    ProductoId = servicio.IdEstandar,
                                    ProveedorId = int.Parse(row[0].ToString())
                                };

                                db.Add(rel);
                            }

                            Inventario inventario = new Inventario()
                            {
                                ProductoId = servicio.IdEstandar,
                                Cantidad = 0,
                                StockMaximo = 100,
                                StockMinimo = 0
                            };

                            db.Add(inventario);

                            List<Almacenes> listAlmacenes = db.Almacenes.ToList();

                            foreach (var item in listAlmacenes)
                            {
                                RelAlmacenProducto almacenProducto = new RelAlmacenProducto()
                                {
                                    ProductoId = servicio.IdEstandar,
                                    Cantidad = 0,
                                    AlmacenId = item.AlmacenId
                                };

                                db.Add(almacenProducto);
                            }
                        }

                        db.SaveChanges();

                        frmAuxPrincipal.vMCatalogosInventario.InitModuloCatalogosInventario(frmAuxPrincipal, auxModulo);
                        this.Dispose();
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
                            var VerificarCodigoCrear = db.ServiciosEstadares.Where(s => s.Codigo.Trim() == TxtCodigo.Text.Trim()).ToList();

                            if (VerificarCodigoCrear.Count > 0)
                            {

                                if (VerificarCodigoCrear[0].IdEstandar != int.Parse(auxId) || VerificarCodigoCrear.Count>1)
                                {
                                    MessageBox.Show("Ya existe un producto con ese codigo. Los codigos deben de ser individuales por producto.", "Atención",
                                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }                           
                            }
                        }

                        //Primero agregar la imagen

                        int _idImg = Utilidades.IdImagenInicial;

                        if (this.ImgProducto.Image != null)
                        {
                            Imagenes img = new Imagenes()
                            {
                                Imagen = ImageToByteArray(ImgProducto.Image)
                            };

                            db.Add(img);
                            db.SaveChanges();

                            _idImg = img.IdImagen;
                        }

                        //Datos del servicio
                        ServiciosEstadares servicio = db.ServiciosEstadares.Where(c => c.IdEstandar == int.Parse(auxId)).FirstOrDefault();

                        servicio.NombreEstandar = TxtNombre.Text.Trim();
                        servicio.IdImagen = _idImg;
                        servicio.Descripcion = TxtDescripcion.Text.Trim();
                        servicio.MontoVd = Double.Parse(TxtPrecioVenta.Text.Trim());
                        servicio.MontoContrato = Double.Parse(TxtPrecioContrato.Text.Trim());
                        servicio.MontoMejora = Double.Parse(TxtPrecioMejora.Text.Trim());
                        servicio.ClasificacionTipo = int.Parse(CmbTipoProducto.SelectedValue.ToString());
                        servicio.Expira = CmbTipoInventario.Text.Trim();
                        servicio.ManejoInventario = CmbManejoInventario.Text.Trim();
                        servicio.Codigo = TxtCodigo.Text.Trim();

                        db.Update(servicio);
                        db.SaveChanges();

                        List<RelProductoSucursales> list = db.RelProductoSucursales.Where(p => p.ProductoId == servicio.IdEstandar).ToList();

                        foreach (var item in list)
                        {
                            db.Remove(item);
                        }

                        db.SaveChanges();

                        foreach (DataRow row in auxTablaDinamica.Rows)
                        {

                            RelProductoSucursales rel = new RelProductoSucursales()
                            {
                                RelProductoSucursalesId = Guid.NewGuid().ToString(),
                                ProductoId = servicio.IdEstandar,
                                SucursalId = int.Parse(row[0].ToString())
                            };

                            db.Add(rel);
                        }

                        db.SaveChanges();

                        if (auxModulo == "Productos")
                        {
                            var listaProveedorProducto = db.RelProveedorProducto.Where(p => p.ProductoId == servicio.IdEstandar).ToList();

                            foreach(var item in  listaProveedorProducto)
                            {
                                db.Remove(item);
                            }

                            db.SaveChanges();

                            foreach (DataRow row in auxTablaDinamicaProveedor.Rows)
                            {
                                RelProveedorProducto rel = new RelProveedorProducto()
                                {
                                    ProductoId = servicio.IdEstandar,
                                    ProveedorId = int.Parse(row[0].ToString())
                                };

                                db.Add(rel);
                            }

                            db.SaveChanges();
                        }

                            frmAuxPrincipal.vMCatalogosInventario.InitModuloCatalogosInventario(frmAuxPrincipal, auxModulo);
                        this.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"No se pudo modificar el producto. Error: {ex.Message}", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
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



        private void ChkDisponibleContrato_Click(object sender, EventArgs e)
        {
            if (ChkDisponibleContrato.Checked)
            {
                LblPrecioContrato.Enabled = true;
                TxtPrecioContrato.Enabled = true;
                TxtPrecioContrato.Text = "";
                TxtPrecioContrato.Focus();
            }
            else
            {
                LblPrecioContrato.Enabled = false;
                TxtPrecioContrato.Enabled = false;
                TxtPrecioContrato.Text = "0";
            }
        }

        private void ChkDisponibleMejoras_Click(object sender, EventArgs e)
        {
            if (ChkDisponibleMejoras.Checked)
            {
                LblPrecioMejora.Enabled = true;
                TxtPrecioMejora.Enabled = true;
                TxtPrecioMejora.Text = "";
                TxtPrecioMejora.Focus();
            }
            else
            {
                LblPrecioMejora.Enabled = false;
                TxtPrecioMejora.Enabled = false;
                TxtPrecioMejora.Text = "0";
            }
        }

        private void BtnAgregarSucursal_Click(object sender, EventArgs e)
        {
            if (CmbSucursal.Items.Count > 0)
            {

                foreach (DataRow row in auxTablaDinamica.Rows)
                {
                    if (row[0].ToString() == CmbSucursal.SelectedValue.ToString())
                    {
                        MessageBox.Show("La Sucursal seleccionada ya ha sido agregada.", "Atención",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                auxTablaDinamica.Rows.Add(CmbSucursal.SelectedValue.ToString(), CmbSucursal.Text);
            }
            else
            {
                MessageBox.Show("Debe agregar una Sucursal en la sección de Catalogo para realizar esta acción.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnQuitarSucursal_Click(object sender, EventArgs e)
        {
            if (dgvSucursalesProductos.SelectedRows.Count > 0)
            {
                auxTablaDinamica.Rows.RemoveAt(dgvSucursalesProductos.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Sucursal en la lista para quitarla.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            ImgProducto.SizeMode = PictureBoxSizeMode.StretchImage;

            OpenFileDialog.Filter = "Imagenes JPG|*.jpg|Imagenes JPEG|*.jpeg";
            if (OpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ImgProducto.Image = Image.FromFile(OpenFileDialog.FileName);

            }
        }

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

        private void ChkDisponibleVentas_Click_1(object sender, EventArgs e)
        {
            if (ChkDisponibleVentas.Checked)
            {
                LblPrecioVenta.Enabled = true;
                TxtPrecioVenta.Enabled = true;
                TxtPrecioVenta.Text = "";
                TxtPrecioVenta.Focus();
            }
            else
            {
                LblPrecioVenta.Enabled = false;
                TxtPrecioVenta.Enabled = false;
                TxtPrecioVenta.Text = "0";
            }
        }

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

        private void BtnAgregarProveedor_Click(object sender, EventArgs e)
        {
            if (CmbProveedor.Items.Count > 0)
            {

                foreach (DataRow row in auxTablaDinamicaProveedor.Rows)
                {
                    if (row[0].ToString() == CmbProveedor.SelectedValue.ToString())
                    {
                        MessageBox.Show("El Proveedor seleccionado ya ha sido agregado.", "Atención",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                auxTablaDinamicaProveedor.Rows.Add(CmbProveedor.SelectedValue.ToString(), CmbProveedor.Text);
            }
            else
            {
                MessageBox.Show("Debe agregar un Proveedor en la sección de Catalogo para realizar esta acción.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnQuitarProveedor_Click(object sender, EventArgs e)
        {
            if (DgvProveedor.SelectedRows.Count > 0)
            {
                auxTablaDinamicaProveedor.Rows.RemoveAt(DgvProveedor.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Proveeedor en la lista para quitarlo.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
