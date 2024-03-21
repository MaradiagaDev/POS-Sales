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
    public partial class ConsultaPrecio : Form
    {
        public DataTable auxDatatable = new DataTable();
        public ConsultaPrecio()
        {
            InitializeComponent();
        }

        private void dgvCatalogo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ConsultaPrecio_Load(object sender, EventArgs e)
        {
            dgvCatalogo.EnableHeadersVisualStyles = false;
            dgvCatalogo.ColumnHeadersDefaultCellStyle.BackColor = Color.CadetBlue;
            dgvCatalogo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCatalogo.RowsDefaultCellStyle.Font = new Font("Century Gothic", 9);
            dgvCatalogo.RowsDefaultCellStyle.BackColor = Color.White;

            TxtCodigoBarras.Focus();

            // Definir las columnas
            auxDatatable.Columns.Add("Id", typeof(string));
            auxDatatable.Columns.Add("Producto", typeof(string));
            auxDatatable.Columns.Add("Tipo", typeof(string));
            auxDatatable.Columns.Add("Precio(IVA INCLUIDO) (NIO)", typeof(string));

            dgvCatalogo.DataSource = auxDatatable;

            BuscarBoton();
        }

        private void BuscarBoton()
        {
            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                var serviciosProductos = db.ServiciosEstadares.Where(s => s.Estado == "Activo" && s.MontoVd != 0 && s.NombreEstandar.Contains(TxtFiltrar.Texts)).ToList();

                auxDatatable.Rows.Clear();

                foreach(var item in serviciosProductos)
                {
                    string tipo = item.ClasificacionProducto == 0 ? "Producto" : "Servicio";
                    auxDatatable.Rows.Add(item.IdEstandar,item.NombreEstandar, tipo, item.MontoVd );
                }
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            BuscarBoton();
        }

        private void TxtCodigoBarras_TextChanged(object sender, EventArgs e)
        {
            using(NeoCobranzaContext db = new NeoCobranzaContext()) 
            {
                var serviciosProductos = db.ServiciosEstadares.Where(s => s.Codigo == TxtCodigoBarras.Text.Trim()).FirstOrDefault();
              
                if (serviciosProductos != null && TxtCodigoBarras.Text.Trim() != "")
                {
                    auxDatatable.Rows.Clear();
                    string tipo = serviciosProductos.ClasificacionProducto == 0 ? "Producto" : "Servicio";
                    auxDatatable.Rows.Add(serviciosProductos.IdEstandar, serviciosProductos.NombreEstandar, tipo, serviciosProductos.MontoVd);

                    TxtCodigoBarras.Text = string.Empty;
                    TxtCodigoBarras.Focus();
                }
            }
        }
    }
}
