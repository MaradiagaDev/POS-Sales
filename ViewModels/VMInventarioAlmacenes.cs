using DocumentFormat.OpenXml.Wordprocessing;
using iTextSharp.text.xml;
using NeoCobranza.Clases;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles;
using NeoCobranza.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NeoCobranza.ViewModels.VMInventarioGeneral;

namespace NeoCobranza.ViewModels
{
    public class VMInventarioAlmacenes
    {
        PnlInventarioAlmacenes auxFrm;
        public DataUtilities dataUtilities = new DataUtilities();
        public DataTable dynamicDataTableProductos = new DataTable();
        byte[] imagenBytes;

        public void InitModuloInventarioAlmacenes(PnlInventarioAlmacenes frm)
        {
            auxFrm = frm;

            DataTable dtResponseImg = dataUtilities.GetAllRecords("Empresa");

            if (dtResponseImg.Rows.Count > 0)
            {
                imagenBytes = dtResponseImg.Rows[0]["NoImagen"] as byte[];
            }

            if (dynamicDataTableProductos.Columns.Count < 3)
            {
                dynamicDataTableProductos.Columns.Add("Id", typeof(string));
                dynamicDataTableProductos.Columns.Add("Producto", typeof(string));
                dynamicDataTableProductos.Columns.Add("Precio Unitario (NIO)", typeof(string));
                dynamicDataTableProductos.Columns.Add("Cantidad", typeof(string));
                dynamicDataTableProductos.Columns.Add("Descripcion", typeof(string));
                dynamicDataTableProductos.Columns.Add("Img", typeof(byte[]));
            }

            //Agregar Boton de Cambiar de estado
            DataGridViewButtonColumn BtnRealizarMerma = new DataGridViewButtonColumn();

            //BtnRealizarMerma.Text = "Agregar Ajuste";
            //BtnRealizarMerma.Name = "...";
            //BtnRealizarMerma.UseColumnTextForButtonValue = true;
            //BtnRealizarMerma.DefaultCellStyle.ForeColor = Color.Blue;
            //frm.dgvCatalogo.Columns.Add(BtnRealizarMerma);

            DataTable dtResponse = dataUtilities.GetAllRecords("Categorizacion");
            var filterRow = from row in dtResponse.AsEnumerable() where Convert.ToString(row.Field<string>("Estado")) == "Activo" select row;

            if (filterRow.Any())
            {
                DataTable dataCmbTipoServicio = new DataTable();
                dataCmbTipoServicio = filterRow.CopyToDataTable();
                DataRow newRow = dataCmbTipoServicio.NewRow();
                newRow["CategorizacionId"] = "0";
                newRow["Descripcion"] = "Mostrar Todo";
                newRow["Estado"] = "Actio";

                dataCmbTipoServicio.Rows.InsertAt(newRow, 0);

                auxFrm.CmbBuscarPor.ValueMember = "CategorizacionId";
                auxFrm.CmbBuscarPor.DisplayMember = "Descripcion";
                auxFrm.CmbBuscarPor.DataSource = dataCmbTipoServicio;
            }

            //ALMACENES
            DataTable dtResponseAlmacenes = dataUtilities.GetAllRecords("Almacenes");
            var filterRowAlmacenes = from row in dtResponseAlmacenes.AsEnumerable() where Convert.ToString(row.Field<string>("Estatus")) == "Activo" select row;

            if (filterRowAlmacenes.Any())
            {
                DataTable dataCmbAlmacenes = new DataTable();
                dataCmbAlmacenes = filterRowAlmacenes.CopyToDataTable();
                DataRow newRow = dataCmbAlmacenes.NewRow();
                newRow[0] = "0";
                newRow[1] = "Mostrar Todo";
                newRow[2] = true;

                dataCmbAlmacenes.Rows.InsertAt(newRow, 0);

                auxFrm.CmbAlmacenes.ValueMember = "AlmacenId";
                auxFrm.CmbAlmacenes.DisplayMember = "NombreAlmacen";
                auxFrm.CmbAlmacenes.DataSource = dataCmbAlmacenes;
            }

            //OBTENER EL ALMACEN MOSTRADOR
            DataTable dtResponseMostrador = dataUtilities.GetAllRecords("Almacenes");
            var filterRowMostrador =
                from row in dtResponseMostrador.AsEnumerable()
                where Convert.ToBoolean(row.Field<bool>("EsMostrador")) == true
                && Convert.ToString(row.Field<string>("SucursalId")) == Utilidades.SucursalId
                select row;

            DataTable dtAlmacenMostrador = filterRowMostrador.CopyToDataTable();

            if(dtAlmacenMostrador.Rows.Count > 0)
            {
                auxFrm.CmbAlmacenes.SelectedValue = Convert.ToString(dtAlmacenMostrador.Rows[0]["AlmacenId"]);
            }

            BuscarInventario();
        }

        public void BuscarInventario()
        {
            if (auxFrm.CmbAlmacenes.SelectedValue != null)
            {
                // Validar y obtener el número de página actual.
                int pageNumber = 1;
                if (!int.TryParse(auxFrm.TxtPaginaNo.Text, out pageNumber))
                {
                    pageNumber = 1;
                    auxFrm.TxtPaginaNo.Text = "1";
                }

                // Definir el tamaño de página (en este ejemplo se usan 20 registros por página)
                int pageSize = 20;

                dynamicDataTableProductos.Rows.Clear();

                // Limpiar parámetros previos y configurar los nuevos para la búsqueda de productos con paginación.
                dataUtilities.ClearParameters();
                dataUtilities.SetParameter("@AlmacenId", auxFrm.CmbAlmacenes.SelectedValue);
                dataUtilities.SetParameter("@CategoriaId", auxFrm.CmbBuscarPor.SelectedValue);
                dataUtilities.SetParameter("@Filtro", auxFrm.TxtFiltrar.Text);
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
                auxFrm.TxtPaginaDe.Text = totalPages.ToString();

                dataUtilities.ClearOutPutParameters();

                MostrarProductosEnTarjetas();
            }
        }

        private void MostrarProductosEnTarjetas()
        {
            auxFrm.flowLayoutPanelProductos.AutoScroll = true;

            // Limpia los controles anteriores
            auxFrm.flowLayoutPanelProductos.Controls.Clear();

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
                btnInfo.BackColor = System.Drawing.Color.Transparent;
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
                    lblInfo.BackColor = System.Drawing.Color.LightYellow;
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
                lblNombre.Font = new System.Drawing.Font(lblNombre.Font, FontStyle.Bold);
                lblNombre.AutoSize = false;                  // Desactiva el auto ajuste para controlar el tamaño
                lblNombre.Location = new Point(10, 140);
                lblNombre.Size = new Size(200, 40);            // Ajusta el ancho y la altura para permitir el wrap
                lblNombre.TextAlign = ContentAlignment.TopLeft;
                lblNombre.BackColor = System.Drawing.Color.Transparent;
                panelProducto.Controls.Add(lblNombre);

                // Etiqueta para el precio unitario
                Label lblPrecio = new Label();
                lblPrecio.Text = "P/U: " + Convert.ToString(row["Precio Unitario (NIO)"]) + $" C$ / Cant: {row["Cantidad"]}";
                lblPrecio.AutoSize = true;
                lblPrecio.Location = new Point(10, 185);
                lblPrecio.Font = new System.Drawing.Font("Segoe UI", 9.5F, FontStyle.Regular);
                panelProducto.Controls.Add(lblPrecio);

                // Botón para agregar a la venta
                Button btnAgregar = new Button();
                btnAgregar.Text = "Realizar Ajuste";
                btnAgregar.Size = new Size(150, 30);
                btnAgregar.BackColor = System.Drawing.Color.DarkGreen;
                btnAgregar.ForeColor = System.Drawing.Color.White;
                btnAgregar.Location = new Point(10, 210);
                btnAgregar.Click += (s, e) =>
                {
                    if (auxFrm.CmbAlmacenes.Text == "Mostrar Todo")
                    {
                        MessageBox.Show("Para hacer Ajuste de inventario tiene que seleccionar el almacén.", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!Utilidades.PermisosLevel(3, 41))
                    {
                        MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    PnlAgregarProductoSerie frmSerie = new PnlAgregarProductoSerie(row["Id"].ToString(), auxFrm.CmbAlmacenes.SelectedValue.ToString());
                    auxFrm.AddOwnedForm(frmSerie);
                    frmSerie.ShowDialog();
                    BuscarInventario();
                };
                panelProducto.Controls.Add(btnAgregar);

                auxFrm.flowLayoutPanelProductos.Controls.Add(panelProducto);
            }

        }
    }
}
