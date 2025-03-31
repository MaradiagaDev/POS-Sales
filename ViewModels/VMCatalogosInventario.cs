using DocumentFormat.OpenXml.Spreadsheet;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles;
using NeoCobranza.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace NeoCobranza.ViewModels
{
    public class VMCatalogosInventario
    {
        DataUtilities dataUtilities = new DataUtilities();

        public string auxOpc;
        public string auxId;
        public CatalogosInventario auxFrm;
        DataTable dynamicDataTable = new DataTable();
        byte[] imagenBytes;

        public void InitModuloCatalogosInventario(CatalogosInventario frm, string opc)
        {
            DataTable dtResponse = dataUtilities.GetAllRecords("Empresa");

            if (dtResponse.Rows.Count > 0)
            {
                imagenBytes = dtResponse.Rows[0]["NoImagen"] as byte[];
            }

            this.auxOpc = opc;
            this.auxFrm = frm;

            switch (opc)
            {
                case "Productos":
                    frm.TbTitulo.Text = "Catalogo de Productos";
                    frm.btnAgregar.Text = "Agregar Producto";
                    frm.dgvCatalogo.Visible = false;
                    break;
                case "Servicios":
                    frm.TbTitulo.Text = "Catalogo de Servicios";
                    frm.btnAgregar.Text = "Agregar Servicio";
                    frm.dgvCatalogo.Visible = false;
                    break;
                case "Adiciones":
                    frm.TbTitulo.Text = "Catalogo de Adiciones";
                    frm.btnAgregar.Text = "Agregar Adiciones";
                    frm.flowLayoutPanelProductos.Visible = false;
                    break;
            }

            ConfigUI(frm);
        }

        public void ConfigUI(CatalogosInventario frm)
        {
            switch (auxOpc)
            {
                case "Productos":

                    if (dynamicDataTable.Columns.Count == 0)
                    {
                        //Agregar Boton de Cambiar de estado
                        DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

                        BtnCambioEstado.Text = "Cambiar Estado";
                        BtnCambioEstado.Name = "...";
                        BtnCambioEstado.UseColumnTextForButtonValue = true;
                        BtnCambioEstado.DefaultCellStyle.ForeColor = Color.Blue;
                        frm.dgvCatalogo.Columns.Add(BtnCambioEstado);

                        // Definir las columnas
                        dynamicDataTable.Columns.Add("Id", typeof(string));
                        dynamicDataTable.Columns.Add("Nombre del Producto", typeof(string));
                        dynamicDataTable.Columns.Add("Estado", typeof(string));
                        dynamicDataTable.Columns.Add("Precio", typeof(string));
                        dynamicDataTable.Columns.Add("Categoría", typeof(string));
                        dynamicDataTable.Columns.Add("Img", typeof(byte[]));
                        dynamicDataTable.Columns.Add("Desc", typeof(string));
                    }
                    break;

                case "Servicios":
                    if (dynamicDataTable.Columns.Count == 0)
                    {

                        //Agregar Boton de Cambiar de estado
                        DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

                        BtnCambioEstado.Text = "Cambiar Estado";
                        BtnCambioEstado.Name = "...";
                        BtnCambioEstado.UseColumnTextForButtonValue = true;
                        BtnCambioEstado.DefaultCellStyle.ForeColor = Color.Blue;
                        //frm.dgvCatalogo.Columns.Add(BtnCambioEstado);

                        // Definir las columnas
                        dynamicDataTable.Columns.Add("Id", typeof(string));
                        dynamicDataTable.Columns.Add("Nombre del Servicio", typeof(string));
                        dynamicDataTable.Columns.Add("Estado", typeof(string));
                        dynamicDataTable.Columns.Add("Precio", typeof(string));
                        dynamicDataTable.Columns.Add("Categoría", typeof(string));
                        dynamicDataTable.Columns.Add("Img", typeof(byte[]));
                        dynamicDataTable.Columns.Add("Desc", typeof(string));
                    }
                    break; 

                case "Adiciones":
                    if (dynamicDataTable.Columns.Count == 0)
                    {

                        //Agregar Boton de Cambiar de estado
                        DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

                        BtnCambioEstado.Text = "Cambiar Estado";
                        BtnCambioEstado.Name = "...";
                        BtnCambioEstado.UseColumnTextForButtonValue = true;
                        BtnCambioEstado.DefaultCellStyle.ForeColor = Color.Blue;
                        frm.dgvCatalogo.Columns.Add(BtnCambioEstado);

                        DataGridViewButtonColumn BtnModificar = new DataGridViewButtonColumn();

                        BtnModificar.Text = "Modificar";
                        BtnModificar.Name = "...";
                        BtnModificar.UseColumnTextForButtonValue = true;
                        BtnModificar.DefaultCellStyle.ForeColor = Color.Blue;
                        frm.dgvCatalogo.Columns.Add(BtnModificar);

                        // Definir las columnas
                        dynamicDataTable.Columns.Add("Id", typeof(string));
                        dynamicDataTable.Columns.Add("Nombre Adicioín", typeof(string));
                        dynamicDataTable.Columns.Add("Estado", typeof(string));
                        dynamicDataTable.Columns.Add("Precio", typeof(string));
                    }
                    break;
            }

            FuncionesPrincipales(frm, "Buscar");
        }

        public void FuncionesPrincipales(CatalogosInventario frm, string opc)
        {
            if (opc == "Bloquear")
            {
                DataTable dtRespuesta = dataUtilities.getRecordByPrimaryKey("ProductosServicios", auxId);
                string statusActual = Convert.ToString(dtRespuesta.Rows[0]["Estado"]) == "Activo" ? "Bloqueado" : "Activo";

                dataUtilities.SetColumns("Estado", statusActual);
                dataUtilities.UpdateRecordByPrimaryKey("ProductosServicios", auxId);

                FuncionesPrincipales(frm, "Buscar");
            }

            if (opc == "Buscar")
            {
                if(auxOpc != "Adiciones")
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

                    dynamicDataTable.Rows.Clear();

                    // Limpiar parámetros previos y configurar los nuevos para la búsqueda de productos con paginación.
                    dataUtilities.ClearParameters();
                    dataUtilities.SetParameter("@Tipo", auxOpc);
                    dataUtilities.SetParameter("@Filtro", auxFrm.TxtFiltrar.Text);
                    dataUtilities.SetParameter("@PageNumber", pageNumber);
                    dataUtilities.SetParameter("@PageSize", pageSize);
                    // Configurar el parámetro de salida para el total de registros.
                    dataUtilities.SetParameter("@TotalRecords", System.Data.SqlDbType.Int, direction: System.Data.ParameterDirection.Output);

                    DataTable dtResponse = dataUtilities.ExecuteStoredProcedure("sp_ObtenerProductosServicios");

                    foreach (DataRow row in dtResponse.Rows)
                    {
                        DataTable dtResponseCategoria = dataUtilities.getRecordByPrimaryKey("Categorizacion", Convert.ToString(row["CategoriaId"]));

                        dynamicDataTable.Rows.Add(Convert.ToString(row["ProductoId"]),
                            Convert.ToString(row["NombreProducto"]),
                            Convert.ToString(row["Estado"]),
                            Convert.ToString(row["Precio"]),
                            Convert.ToString(dtResponseCategoria.Rows[0]["Descripcion"]), row["Img"],
                            Convert.ToString(row["Descripcion"]));
                    }

                    // Recuperar el total de registros desde el parámetro de salida y actualizar el control de total de páginas.
                    int totalRecordsServicios = Convert.ToInt32(dataUtilities.GetParameterValue("@TotalRecords"));
                    int totalPagesServicios = (int)Math.Ceiling((double)totalRecordsServicios / pageSize);
                    auxFrm.TxtPaginaDe.Text = totalPagesServicios.ToString();
                    dataUtilities.ClearOutPutParameters();

                    MostrarProductosEnTarjetas();
                }
                else
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

                    dynamicDataTable.Rows.Clear();

                    // Limpiar parámetros previos y configurar los nuevos para la búsqueda de productos con paginación.
                    dataUtilities.ClearParameters();
                    dataUtilities.SetParameter("@Tipo", auxOpc);
                    dataUtilities.SetParameter("@Filtro", auxFrm.TxtFiltrar.Text);
                    dataUtilities.SetParameter("@PageNumber", pageNumber);
                    dataUtilities.SetParameter("@PageSize", pageSize);
                    // Configurar el parámetro de salida para el total de registros.
                    dataUtilities.SetParameter("@TotalRecords", System.Data.SqlDbType.Int, direction: System.Data.ParameterDirection.Output);

                    DataTable dtResponse = dataUtilities.ExecuteStoredProcedure("sp_ObtenerProductosServicios");

                    foreach (DataRow row in dtResponse.Rows)
                    {
                        DataTable dtResponseCategoria = dataUtilities.getRecordByPrimaryKey("Categorizacion", Convert.ToString(row["CategoriaId"]));

                        dynamicDataTable.Rows.Add(Convert.ToString(row["ProductoId"]),
                            Convert.ToString(row["NombreProducto"]),
                            Convert.ToString(row["Estado"]),
                            Convert.ToString(row["Precio"]));
                    }

                    // Recuperar el total de registros desde el parámetro de salida y actualizar el control de total de páginas.
                    int totalRecordsServicios = Convert.ToInt32(dataUtilities.GetParameterValue("@TotalRecords"));
                    int totalPagesServicios = (int)Math.Ceiling((double)totalRecordsServicios / pageSize);
                    auxFrm.TxtPaginaDe.Text = totalPagesServicios.ToString();
                    dataUtilities.ClearOutPutParameters();

                    frm.dgvCatalogo.DataSource = dynamicDataTable;
                }
            }
        }

        private void MostrarProductosEnTarjetas()
        {
            auxFrm.flowLayoutPanelProductos.AutoScroll = true;

            // Limpia los controles anteriores
            auxFrm.flowLayoutPanelProductos.Controls.Clear();

            foreach (DataRow row in dynamicDataTable.Rows)
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
                infoToolTip.SetToolTip(btnInfo, Convert.ToString(row[6]));

                // Opcional: si deseas que el mensaje también se muestre al hacer click, puedes manejar el evento Click:
                btnInfo.Click += (s, e) =>
                {
                    // Por ejemplo, mostrar un pequeño label temporal o cualquier otra acción
                    Label lblInfo = new Label();
                    lblInfo.Text = Convert.ToString(row[6]);
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
                lblNombre.Text = row[1].ToString();
                lblNombre.Font = new System.Drawing.Font(lblNombre.Font, FontStyle.Bold);
                lblNombre.AutoSize = false;                  // Desactiva el auto ajuste para controlar el tamaño
                lblNombre.Location = new Point(10, 140);
                lblNombre.Size = new Size(200, 40);            // Ajusta el ancho y la altura para permitir el wrap
                lblNombre.TextAlign = ContentAlignment.TopLeft;
                lblNombre.BackColor = Color.Transparent;
                panelProducto.Controls.Add(lblNombre);

                // Etiqueta para el precio unitario
                Label lblPrecio = new Label();

                lblPrecio.Text = "P/U: " + Convert.ToString(row[3]) + $" C$ / Estado: {row[2]}";

                lblPrecio.AutoSize = true;
                lblPrecio.Location = new Point(10, 185);
                panelProducto.Controls.Add(lblPrecio);

                // Botón de disponibilidad, solo se muestra si es de tipo "Producto"

                // Botón para agregar a la venta
                Button btnAgregar = new Button();
                btnAgregar.Text = "Bloquear";
                btnAgregar.Size = new Size(80, 30);
                btnAgregar.BackColor = Color.DarkRed;
                btnAgregar.ForeColor = Color.White;
                btnAgregar.Location = new Point(120, 210);
                btnAgregar.Click += (s, e) =>
                {

                    if (auxOpc == "Productos")
                    {
                        if (!Utilidades.PermisosLevel(3, 66))
                        {
                            MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        if (!Utilidades.PermisosLevel(3, 69))
                        {
                            MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    auxId = row[0].ToString();
                    FuncionesPrincipales(auxFrm, "Bloquear"); 
                };

                panelProducto.Controls.Add(btnAgregar);

                Button btnDisponibilidad = new Button();
                btnDisponibilidad.Text = "Modificar";
                btnDisponibilidad.Size = new Size(100, 30);
                btnDisponibilidad.Location = new Point(10, 210);
                btnDisponibilidad.BackColor = System.Drawing.Color.DarkGreen;
                btnDisponibilidad.ForeColor = Color.White;
                btnDisponibilidad.Click += (s, e) =>
                {

                    if (auxOpc == "Productos")
                    {
                        if (!Utilidades.PermisosLevel(3, 65))
                        {
                            MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        if (!Utilidades.PermisosLevel(3, 68))
                        {
                            MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }


                    PnlAgregarProductos frm = new PnlAgregarProductos(auxFrm, "Modificar", auxFrm.auxModulo, row[0].ToString());
                    frm.ShowDialog();
                };
                panelProducto.Controls.Add(btnDisponibilidad);


                auxFrm.flowLayoutPanelProductos.Controls.Add(panelProducto);
            }

        }

    }
}
