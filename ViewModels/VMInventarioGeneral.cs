using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles;
using NeoCobranza.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.ViewModels
{
    public class VMInventarioGeneral
    {

        public DataUtilities dataUtilities = new DataUtilities();
        public DataTable dynamicDataTableProductos = new DataTable();
        byte[] imagenBytes;

        public class MostrarInventarioGeneral
        {
            public string ID { get; set; }
            public string Producto { get; set; }
            public string Cantidad { get; set; }
            public string CantidadMinima { get; set; }
            public string CantidadMaxima { get; set; }

        }

        public PnlRevisionInventario auxFrm;

        public void InitPantallaRevision(PnlRevisionInventario frm)
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

                auxFrm.CmbBuscarPor.ValueMember = "CategorizacionId";
                auxFrm.CmbBuscarPor.DisplayMember = "Descripcion";
                auxFrm.CmbBuscarPor.DataSource = dataCmbTipoServicio;
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
                auxFrm.CmbSucursales.ValueMember = "IdSucursal";
                auxFrm.CmbSucursales.DisplayMember = "NombreSucursal";
                auxFrm.CmbSucursales.DataSource = dataCmbSucursal;
            }

            auxFrm.CmbSucursales.SelectedValue = Utilidades.SucursalId;

            BuscarInventario();
        }

        public void BuscarInventario()
        {
            // Validar y obtener el número de página actual.
            int pageNumber = 1;
            if (!int.TryParse(auxFrm.TxtPaginaNo.Text, out pageNumber))
            {
                pageNumber = 1;
                auxFrm.TxtPaginaNo.Text = "1";
            }

            // Definir el tamaño de página (por ejemplo, 20 registros por página)
            int pageSize = 20;

            // Limpiar parámetros previos
            dataUtilities.ClearParameters();

            // Configurar los parámetros para el SP, incluyendo paginación y parámetro de salida para el total de registros.
            dataUtilities.SetParameter("@IdSucursal", auxFrm.CmbSucursales.SelectedValue);
            dataUtilities.SetParameter("@CategoriaId", auxFrm.CmbBuscarPor.SelectedValue);
            dataUtilities.SetParameter("@Filtro", auxFrm.TxtFiltrar.Text);
            dataUtilities.SetParameter("@PageNumber", pageNumber);
            dataUtilities.SetParameter("@PageSize", pageSize);
            dataUtilities.SetParameter("@TotalRecords", SqlDbType.Int, ParameterDirection.Output);

            // Ejecutar el SP con paginación.
            DataTable Sp = dataUtilities.ExecuteStoredProcedure("sp_ObtenerCantidadProductoPorSucursalYCategoriaReportes");

            // Recuperar el total de registros y calcular el total de páginas.
            int totalRecords = Convert.ToInt32(dataUtilities.GetParameterValue("@TotalRecords"));
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            auxFrm.TxtPaginaDe.Text = totalPages.ToString();

            // Limpiar la tabla dinámica y agregar los registros obtenidos.
            dynamicDataTableProductos.Rows.Clear();
            foreach (DataRow row in Sp.Rows)
            {
                dynamicDataTableProductos.Rows.Add(
                    Convert.ToString(row[0]),
                    Convert.ToString(row[1]),
                    Convert.ToString(row[2]),
                    Convert.ToString(row[3]),
                    Convert.ToString(row[4]),
                    row[5]
                );
            }

            MostrarProductosEnTarjetas();
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
                lblPrecio.Text = "P/U: " + Convert.ToString(row["Precio Unitario (NIO)"]) + $" C$ / Cant: {row["Cantidad"]}";
                lblPrecio.AutoSize = true;
                lblPrecio.Location = new Point(10, 195);
                lblPrecio.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                panelProducto.Controls.Add(lblPrecio);

                auxFrm.flowLayoutPanelProductos.Controls.Add(panelProducto);
            }

        }
    }
}
