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

namespace NeoCobranza.PanelesHoteles
{
    public partial class PnlInicioHoteles : Form
    {
        public PnlInicioHoteles()
        {
            InitializeComponent();
        }

        private void PnlInicioHoteles_Load(object sender, EventArgs e)
        {
            UIUtilities.PersonalizarDataGridView(DgvItemsOrden);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
