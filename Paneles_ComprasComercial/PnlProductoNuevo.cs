using NeoCobranza.Clases;
using NeoCobranza.Data;
using NeoCobranza.Paneles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles_ComprasComercial
{
    public partial class PnlProductoNuevo : Form
    {
        //variable de conexion
        public Conexion conexion;

        public PnlSeleccionarProveedor pnlSeleccionar;

        
        public PnlProductoNuevo(Conexion conexion)
        {
            InitializeComponent();
            this.conexion = conexion;

            pnlSeleccionar = new PnlSeleccionarProveedor(conexion);

            AddOwnedForm(pnlSeleccionar);
        }

        private void PnlNuevaCompra_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnProveedor_Click(object sender, EventArgs e)
        {
            pnlSeleccionar.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtEstadoProveedor_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void txtIdProveedor_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void txtNombreProveedor_Click(object sender, EventArgs e)
        {

        }
    }
}
