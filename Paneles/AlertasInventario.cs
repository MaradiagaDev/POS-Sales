using NeoCobranza.Clases;
using NeoCobranza.ModelsCobranza;
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
    public partial class AlertasInventario : Form
    {
        DataTable data = new DataTable();
        public AlertasInventario()
        {
            InitializeComponent();
        }

        private void AlertasInventario_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn BtnSeleccionar = new DataGridViewButtonColumn();

            BtnSeleccionar.Text = "  Seleccionar  ";
            BtnSeleccionar.Name = "...";
            BtnSeleccionar.UseColumnTextForButtonValue = true;
            BtnSeleccionar.DefaultCellStyle.ForeColor = Color.Blue;
            dgvCatalogo.Columns.Add(BtnSeleccionar);

            // Definir las columnas
            data.Columns.Add("Id", typeof(string));
            data.Columns.Add("Producto", typeof(string));
            data.Columns.Add("Cantidad Maxima", typeof(string));
            data.Columns.Add("Cantidad Minima", typeof(string));

            dgvCatalogo.DataSource = data;

            BuscarProducto();
        }

        public void BuscarProducto()
        {
            data.Rows.Clear();
            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                var servicios = db.ServiciosEstadares.Where(s => s.Estado == "Activo" && s.ClasificacionProducto == 0 && s.NombreEstandar.Contains(TxtFiltrar.Texts)).ToList();

                foreach(var servicio in servicios)
                {
                    var inventario = db.Inventario.Where(s => s.ProductoId == servicio.IdEstandar).FirstOrDefault();

                    data.Rows.Add(servicio.IdEstandar,servicio.NombreEstandar,inventario.StockMaximo, inventario.StockMinimo);
                }
            }
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }

        private void dgvCatalogo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                object cellValue = dgvCatalogo.Rows[e.RowIndex].Cells[1].Value;

                using (NeoCobranzaContext db = new NeoCobranzaContext())
                {
                    TxtIdProducto.Enabled = true;
                    TxtProducto.Enabled = true;
                    TxtCantidadMaxima.Enabled = true;
                    TxtCantidadMinima.Enabled = true;

                    LblIdProducto.Enabled = true;
                    LblProducto.Enabled = true;
                    LblCantidadMaxima.Enabled = true;
                    LblCantidadMinima.Enabled = true;

                    ServiciosEstadares servicios = db.ServiciosEstadares.Where(s => s.IdEstandar == int.Parse(cellValue.ToString())).FirstOrDefault();

                    var inventario = db.Inventario.Where(s => s.ProductoId == servicios.IdEstandar).FirstOrDefault();

                    TxtIdProducto.Text = servicios.IdEstandar.ToString();
                    TxtProducto.Text = servicios.NombreEstandar;
                    TxtCantidadMaxima.Text = inventario.StockMaximo.ToString();
                    TxtCantidadMinima.Text = inventario.StockMinimo.ToString();

                }
            }
        }

        private void TxtCantidadMinima_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada no es un dígito ni la tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un dígito ni la tecla de retroceso, marcar el evento como manejado
                e.Handled = true;
            }
        }

        private void TxtCantidadMaxima_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada no es un dígito ni la tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un dígito ni la tecla de retroceso, marcar el evento como manejado
                e.Handled = true;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int prueba = 0;
            if(int.TryParse(TxtCantidadMaxima.Text.Trim(), out prueba) == false)
            {
                MessageBox.Show("La cantidad maxima no es valida","Atención",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (int.TryParse(TxtCantidadMinima.Text.Trim(), out prueba) == false)
            {
                MessageBox.Show("La cantidad minima no es valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(int.Parse(TxtCantidadMaxima.Text) <= int.Parse(TxtCantidadMinima.Text))
            {
                MessageBox.Show("La cantidad maxima no puede ser menor o igual a la minima.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                var inventario = db.Inventario.Where(s => s.ProductoId == int.Parse(TxtIdProducto.Text)).FirstOrDefault();

                inventario.StockMaximo = int.Parse(TxtCantidadMaxima.Text.Trim());
                inventario.StockMinimo = int.Parse(TxtCantidadMinima.Text.Trim());
                db.Update(inventario);
                db.SaveChanges();

                BuscarProducto();

                MessageBox.Show("Cambio de Configuración realizado","Atención",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
