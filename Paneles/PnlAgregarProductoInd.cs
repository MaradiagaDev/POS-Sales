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
    public partial class PnlAgregarProductoInd : Form
    {
        int auxIdProducto;
        int auxIdAlmacen;

        public PnlAgregarProductoInd(int idProducto, int idAlmacen)
        {
            InitializeComponent();
            this.auxIdProducto = idProducto;
            this.auxIdAlmacen = idAlmacen;
        }

        private void PnlAgregarProductoInd_Load(object sender, EventArgs e)
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                ServiciosEstadares productos = db.ServiciosEstadares.Where(s => s.IdEstandar == this.auxIdProducto).FirstOrDefault();
                Almacenes almacenes = db.Almacenes.Where(s => s.AlmacenId == this.auxIdAlmacen).FirstOrDefault();

                LblDinamico.Text = "Producto: " + productos.NombreEstandar + "             Almacén: " + almacenes.NombreAlmacen;
            }
        }
    }
}
