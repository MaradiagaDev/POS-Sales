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
    public partial class AgregarNotaOrden : Form
    {
        public AgregarNotaOrden(string key)
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardarNota_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La nota ha sido guardada.", "Correcto",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
