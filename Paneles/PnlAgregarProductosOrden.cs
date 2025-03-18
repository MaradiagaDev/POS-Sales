using NeoCobranza.Clases;
using NeoCobranza.Paneles_Venta;
using NeoCobranza.ViewModels;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace NeoCobranza.Paneles
{
    public partial class PnlAgregarProductosOrden : Form
    {
        PnlVentas auxFrm;
        string auxIdAlmacen;
        string auxIdProducto = "0";
        DataUtilities dataUtilities = new DataUtilities();

        // DataTable para almacenar los datos retornados del SP
        DataTable dynamicDataTableProductos = new DataTable();

        // Variables para paginación
        int currentPage = 1;
        int pageSize = 10;
        int totalRecords = 0;

        // Variable para almacenar la imagen por defecto
        private byte[] imagenDefault;

        public PnlAgregarProductosOrden(PnlVentas frm)
        {
            InitializeComponent();
            auxFrm = frm;
        }

        private void PnlAgregarProductosOrden_Load(object sender, EventArgs e)
        {

            // Personalizar DataGridView
            UIUtilities.PersonalizarDataGridViewPequeñosPlus(DgvItemsOrden);

            // Obtener el Almacén Mostrador
            DataTable dtResponse = dataUtilities.GetAllRecords("Almacenes");
            var filterRow = from row in dtResponse.AsEnumerable()
                            where row.Field<bool>("EsMostrador") == true
                                  && row.Field<string>("SucursalId") == Utilidades.SucursalId
                            select row;
            if (filterRow.Any())
            {
                DataTable dtAlmacenMostrador = filterRow.CopyToDataTable();
                TxtAlmacen.Text = Convert.ToString(dtAlmacenMostrador.Rows[0]["NombreAlmacen"]);
                auxIdAlmacen = Convert.ToString(dtAlmacenMostrador.Rows[0]["AlmacenId"]);
            }

            // Obtener la imagen por defecto de la empresa
            DataTable dtEmpresa = dataUtilities.GetAllRecords("Empresa");
            if (dtEmpresa.Rows.Count > 0)
            {
                imagenDefault = dtEmpresa.Rows[0]["NoImagen"] as byte[];
            }

            // Configurar las columnas del DataTable
            dynamicDataTableProductos = new DataTable();
            dynamicDataTableProductos.Columns.Add("Id", typeof(string));
            dynamicDataTableProductos.Columns.Add("Producto", typeof(string));
            dynamicDataTableProductos.Columns.Add("Precio", typeof(decimal));
            dynamicDataTableProductos.Columns.Add("Existencia", typeof(int));
            dynamicDataTableProductos.Columns.Add("Descripcion", typeof(string));
            dynamicDataTableProductos.Columns.Add("Img", typeof(byte[])); // Se usará para cargar la imagen, pero se ocultará en el grid

            // Asignar el DataTable al DataGridView
            DgvItemsOrden.DataSource = dynamicDataTableProductos;

            // Agregar la columna de botón de selección (si no existe)
            if (!DgvItemsOrden.Columns.Contains("Seleccionar"))
            {
                DataGridViewButtonColumn btnSelect = new DataGridViewButtonColumn();
                btnSelect.Name = "Seleccionar";
                btnSelect.HeaderText = "";
                btnSelect.Text = "Seleccionar";
                btnSelect.UseColumnTextForButtonValue = true;
                DgvItemsOrden.Columns.Insert(0, btnSelect);
            }
            // Ocultar la columna que contiene la imagen
            if (DgvItemsOrden.Columns.Contains("Img"))
                DgvItemsOrden.Columns["Img"].Visible = false;

            // Esconder la columna del Id del producto
            if (DgvItemsOrden.Columns.Contains("Id"))
                DgvItemsOrden.Columns["Id"].Visible = false;

            // Ocultar la columna de descripción
            if (DgvItemsOrden.Columns.Contains("Descripcion"))
                DgvItemsOrden.Columns["Descripcion"].Visible = false;

            // Asociar el evento para el clic en la celda (botón)
            DgvItemsOrden.CellContentClick += DgvItemsOrden_CellContentClick;

            // Copiar el código del producto desde el formulario padre
            TxtCodigoProducto.Text = auxFrm.TxtCodigoProducto.Text;

            // Realizar la primera búsqueda
            Buscar();
        }

        private void Buscar()
        {
            // Configurar los parámetros de entrada para el SP
            dataUtilities.SetParameter("@AlmacenId", auxIdAlmacen);
            dataUtilities.SetParameter("@CategoriaId", "0");
            dataUtilities.SetParameter("@Filtro", TxtCodigoProducto.Text);
            dataUtilities.SetParameter("@PageNumber", currentPage.ToString());
            dataUtilities.SetParameter("@PageSize", pageSize.ToString());

            // Configurar el parámetro de salida para el total de registros.
            dataUtilities.SetParameter("@TotalRecords", System.Data.SqlDbType.Int, direction: System.Data.ParameterDirection.Output);

            // Ejecutar el SP
            DataTable dtResponse = dataUtilities.ExecuteStoredProcedure("sp_ObtenerProductosServiciosOrden");

            // Limpiar el DataTable antes de llenarlo
            dynamicDataTableProductos.Rows.Clear();

            // Recorrer el DataTable retornado y llenar el dynamicDataTableProductos
            foreach (DataRow row in dtResponse.Rows)
            {
                dynamicDataTableProductos.Rows.Add(
                    Convert.ToString(row["ID"]),
                    Convert.ToString(row["PRODUCTO"]),
                    Convert.ToDecimal(row["PRECIO (NIO)"]),
                    Convert.ToInt32(row["EXISTENCIA"]),
                    Convert.ToString(row["Descripcion"]),
                    row["Img"]
                );
            }

            // Recuperar el total de registros desde el parámetro de salida y asignarlo a la variable global
            totalRecords = Convert.ToInt32(dataUtilities.GetParameterValue("@TotalRecords"));
            int totalPages = (totalRecords > 0) ? (int)Math.Ceiling((double)totalRecords / pageSize) : 1;
            TxtPaginaDe.Text = totalPages.ToString();

            // Actualizar la página actual en el TextBox correspondiente
            TxtPaginaNo.Text = currentPage.ToString();

            // Limpiar los parámetros de salida para la siguiente llamada
            dataUtilities.ClearOutPutParameters();

            // Seleccionar por defecto el primer registro, si existe
            if (dynamicDataTableProductos.Rows.Count > 0)
            {
                DgvItemsOrden.ClearSelection();
                DgvItemsOrden.Rows[0].Selected = true;
                SeleccionarProducto(0);
            }
        }

        // Evento del DataGridView para detectar el clic en el botón de la columna "Seleccionar"
        private void DgvItemsOrden_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validar que se hizo clic en el botón y que la fila es válida
            if (e.RowIndex >= 0 && DgvItemsOrden.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                SeleccionarProducto(e.RowIndex);
            }
        }

        // Método para procesar la selección del producto
        private void SeleccionarProducto(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= DgvItemsOrden.Rows.Count)
                return;

            DataGridViewRow selectedRow = DgvItemsOrden.Rows[rowIndex];

            auxIdProducto = Convert.ToString(selectedRow.Cells[1].Value);

            // Recuperar los valores necesarios de la fila (incluida la imagen oculta)
            string productoNombre = Convert.ToString(selectedRow.Cells["Producto"].Value);
            string precio = Convert.ToString(selectedRow.Cells["Precio"].Value);
            string existencia = Convert.ToString(selectedRow.Cells["Existencia"].Value);
            byte[] imgData = selectedRow.Cells["Img"].Value as byte[];

            // Hacer visible el panel de producto y llenar los controles
            PnlProducto.Visible = true;
            TxtNombre.Text = productoNombre;
            TxtPrecio.Text =  "PRECIO: "+precio+" C$";
            TxtCantidad.Text = "EXISTENCIA: "+existencia+" U";

            // Cargar la imagen en el PictureBox: si no hay imagen, usar la imagen por defecto
            if (imgData != null && imgData.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(imgData))
                {
                    PBProducto.Image = Image.FromStream(ms);
                    PBProducto.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            else if (imagenDefault != null && imagenDefault.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(imagenDefault))
                {
                    PBProducto.Image = Image.FromStream(ms);
                    PBProducto.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            else
            {
                PBProducto.Image = null;
            }
        }

        // Evento para el botón "Anterior" de paginación
        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                Buscar();
            }
        }

        // Evento para el botón "Siguiente" de paginación
        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            int totalPages = (totalRecords > 0) ? (int)Math.Ceiling((double)totalRecords / pageSize) : 1;
            if (currentPage < totalPages)
            {
                currentPage++;
                Buscar();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            auxFrm.auxIdProducto = "0";
            auxFrm.auxCantidad = 0;
            this.Close();
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            auxFrm.auxIdProducto = "0";
            auxFrm.auxCantidad = 0;
            this.Close();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            int pCantidad = 0;
            if(int.TryParse(TxtCantidadAgregar.Text, out pCantidad))
            {
                if(pCantidad == 0)
                {
                    MessageBox.Show("La cantidad debe ser mayor a cero.","Atención",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    auxFrm.auxCantidad = pCantidad;

                    if(auxIdProducto == "0")
                    {
                        MessageBox.Show("No ha seleccionado un producto para agregar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        auxFrm.auxIdProducto = auxIdProducto;
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("La cantidad digitada no es valida.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void TxtCodigoProducto_TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void DgvItemsOrden_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
