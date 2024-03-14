using NeoCobranza.ModelsCobranza;
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
    public partial class PnlConfigInventario : Form
    {
        VMConfigInventario vMConfigInventario;

        public PnlConfigInventario()
        {
            InitializeComponent();

            vMConfigInventario = new VMConfigInventario(this);
        }

        private void BtnRealizarConexiones_Click(object sender, EventArgs e)
        {
            vMConfigInventario.FuncionesPrincipales("Conexiones");
        }

        private void BtnBorrarInventario_Click(object sender, EventArgs e)
        {
            vMConfigInventario.FuncionesPrincipales("Borrar");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void PnlConfigInventario_Load(object sender, EventArgs e)
        {
            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                ConfigInventario configInventario = db.ConfigInventario.Where(s => s.SucursalId == int.Parse(Utilidades.SucursalId)).FirstOrDefault();

                if(configInventario != null)
                {
                    ChkInventario.Checked = (bool)configInventario.SinInventario;
                    ChkInventarioNegativo.Checked = (bool)configInventario.InventarioNegativo;
                }
            }
        }

        private void BtnGuardarInformacion_Click(object sender, EventArgs e)
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                ConfigInventario configInventario = db.ConfigInventario.Where(s => s.SucursalId == int.Parse(Utilidades.SucursalId)).FirstOrDefault();

                if (configInventario != null)
                {
                    configInventario.SinInventario = ChkInventario.Checked;
                    configInventario.InventarioNegativo = ChkInventarioNegativo.Checked;

                    db.Update(configInventario);
                    db.SaveChanges();

                    MessageBox.Show("Cambios guardados correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
