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

namespace NeoCobranza.Paneles
{
    public partial class PnlAgregarVencimientosProveedores : Form
    {
        public string auxIdProducto, auxIdAlmacen;
        private DataUtilities dataUtilities = new DataUtilities();
        public PnlAgregarVencimientosProveedores(string auxIdProd,string auxIdAlm,string Cantidad)
        {
            InitializeComponent();
            this.auxIdAlmacen = auxIdAlm;
            this.auxIdProducto = auxIdProd;
            TxtCantidad.Text = Cantidad;
            TxtFaltante.Text = Cantidad;
            TxtCantidadDescontar.Text = "1";

            DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

            BtnCambioEstado.Text = "Seleccionar";
            BtnCambioEstado.Name = "...";
            BtnCambioEstado.UseColumnTextForButtonValue = true;
            BtnCambioEstado.DefaultCellStyle.ForeColor = Color.Blue;
            DgvProveedor.Columns.Add(BtnCambioEstado);

            DataGridViewButtonColumn BtnCambioQuitar = new DataGridViewButtonColumn();

            BtnCambioQuitar.Text = "Quitar";
            BtnCambioQuitar.Name = "...";
            BtnCambioQuitar.UseColumnTextForButtonValue = true;
            BtnCambioQuitar.DefaultCellStyle.ForeColor = Color.Blue;
            DgvDescontado.Columns.Add(BtnCambioQuitar);

            filtrarProveedores();
        }

        private void PnlAgregarVencimientosProveedores_Load(object sender, EventArgs e)
        {
            UIUtilities.PersonalizarDataGridViewPequeños(DgvProveedor);
            UIUtilities.PersonalizarDataGridViewPequeños(DgvDescontado);
            filtrarProveedores();
            DgvProveedor.Columns[1].Visible = false;
            DgvProveedor.Columns[2].Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DgvProveedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvDescontado.Columns.Count == 1)
            {
                DgvDescontado.Columns.Add("RelAlmacenProveedorProductoId", "RelAlmacenProveedorProductoId");
                DgvDescontado.Columns.Add("CompraId", "CompraId");
                DgvDescontado.Columns.Add("PROVEEDOR", "PROVEEDOR");
                DgvDescontado.Columns.Add("CANTIDAD", "CANTIDAD");
                DgvDescontado.Columns.Add("COMPRA", "COMPRA");
                DgvDescontado.Columns.Add("VENCIMIENTO", "VENCIMIENTO");

                DgvDescontado.Columns[1].Visible = false;
                DgvDescontado.Columns[2].Visible = false;
            }

            // Verificamos que se haya hecho clic en una fila válida (se ignoran encabezados).
            if (e.RowIndex < 0)
                return;

            // Se comprueba que se haya hecho clic en el botón (asumiendo que es una columna de botón)
            if (DgvProveedor.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                // Se obtienen los valores actuales del faltante
                decimal faltante;
                if (!Decimal.TryParse(TxtFaltante.Text, out faltante))
                {
                    MessageBox.Show("Cantidad faltante inválida.");
                    return;
                }
                if (faltante <= 0)
                {
                    MessageBox.Show("La cantidad a agregar ya superó la cantidad seleccionada.");
                    return;
                }

                // Se obtiene la fila en la que se hizo clic
                DataGridViewRow filaProveedor = DgvProveedor.Rows[e.RowIndex];

                // Se obtiene la cantidad disponible en la fila (la columna 'Cantidad')
                decimal cantidadDisponible = 0;
                if (filaProveedor.Cells["CANTIDAD"].Value != null)
                {
                    Decimal.TryParse(filaProveedor.Cells["CANTIDAD"].Value.ToString(), out cantidadDisponible);
                }

                if (cantidadDisponible <= 0)
                {
                    MessageBox.Show("No hay cantidad disponible en este proveedor.");
                    return;
                }

                // Se determina la cantidad a agregar: la mínima entre la cantidad disponible y el faltante.
                decimal cantidadAAgregar = (cantidadDisponible > faltante) ? faltante : cantidadDisponible;

                // Actualizar la cantidad en la grilla del proveedor
                filaProveedor.Cells["CANTIDAD"].Value = cantidadDisponible - cantidadAAgregar;

                // Agregar una nueva fila en DgvDescontado con la información correspondiente.
                // Se asume que DgvDescontado tiene las columnas: NombreProveedor, Cantidad, FechaCompra y FechaVencimiento.
                int indiceNuevaFila = DgvDescontado.Rows.Add();
                DataGridViewRow filaDescontado = DgvDescontado.Rows[indiceNuevaFila];
                filaDescontado.Cells["RelAlmacenProveedorProductoId"].Value = filaProveedor.Cells["RelAlmacenProveedorProductoId"].Value;
                filaDescontado.Cells["CompraId"].Value = filaProveedor.Cells["CompraId"].Value;
                filaDescontado.Cells["PROVEEDOR"].Value = filaProveedor.Cells["PROVEEDOR"].Value;
                filaDescontado.Cells["CANTIDAD"].Value = cantidadAAgregar;
                filaDescontado.Cells["COMPRA"].Value = filaProveedor.Cells["COMPRA"].Value;
                filaDescontado.Cells["VENCIMIENTO"].Value = filaProveedor.Cells["VENCIMIENTO"].Value;

                // Actualizar el valor del TextBox faltante
                decimal nuevoFaltante = faltante - cantidadAAgregar;
                TxtFaltante.Text = nuevoFaltante.ToString();

            }
        }

        private void TxtFiltro_TextChanged(object sender, EventArgs e)
        {
            filtrarProveedores();
        }

        private void filtrarProveedores()
        {
            dataUtilities.SetParameter("@filtro", TxtFiltro.Text);
            dataUtilities.SetParameter("@ProductoId", auxIdProducto);
            dataUtilities.SetParameter("@AlmacenId", auxIdAlmacen);
            DataTable dtResponse = dataUtilities.ExecuteStoredProcedure("dbo.sp_GetInventarioDetalle");
            DgvProveedor.DataSource = dtResponse;

            // Recorremos todas las filas del DataGridView para asignar el color de fondo según la fecha de vencimiento.
            foreach (DataGridViewRow row in DgvProveedor.Rows)
            {
                // Verificamos que la fila no sea la fila para insertar nuevos registros
                if (row.IsNewRow) continue;

                // Se extrae el valor de la celda "FechaVencimiento".
                var cellValue = row.Cells["VENCIMIENTO"].Value;
                if (cellValue != null && cellValue.ToString() != "-")
                {
                    DateTime fechaVencimiento;
                    // Se intenta convertir el valor a DateTime.
                    if (DateTime.TryParse(cellValue.ToString(), out fechaVencimiento))
                    {
                        DateTime hoy = DateTime.Today;
                        // Calculamos la diferencia en días
                        double diasDiferencia = (fechaVencimiento.Date - hoy).TotalDays;

                        // Si es fecha pasada, hoy o a 10 días o menos, se colorea de rojo oscuro
                        if (diasDiferencia <= 10)
                        {
                            row.DefaultCellStyle.BackColor = Color.DarkRed;
                            row.DefaultCellStyle.ForeColor = Color.White;
                        }
                        // Si está a más de 10 días y hasta 30 días, se colorea de amarillo oscuro
                        else if (diasDiferencia <= 30)
                        {
                            row.DefaultCellStyle.BackColor = Color.DarkGoldenrod;
                            // Se mantiene la fuente en negro (o el color por defecto)
                            row.DefaultCellStyle.ForeColor = Color.Black;
                        }
                        // Si es mayor a 30 días, se colorea de verde oscuro
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.DarkGreen;
                            row.DefaultCellStyle.ForeColor = Color.White;
                        }
                    }
                }
                else
                {
                    // Si no hay fecha de vencimiento (valor "-"), se puede asignar el estilo por defecto
                    row.DefaultCellStyle.BackColor = DgvProveedor.DefaultCellStyle.BackColor;
                    row.DefaultCellStyle.ForeColor = DgvProveedor.DefaultCellStyle.ForeColor;
                }
            }
        }


    }
}
