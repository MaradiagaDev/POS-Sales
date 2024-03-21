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
    public partial class AgregarNotaOrden : Form
    {
        private string auxOrden;
        public AgregarNotaOrden(string key)
        {
            InitializeComponent();
            auxOrden = key;

            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                Ordenes orden = db.Ordenes.Where(s => s.OrdenId == int.Parse(key)).FirstOrDefault();
                if (orden != null)
                {
                    TxtNotaOrden.Text = orden.NotaOrden;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardarNota_Click(object sender, EventArgs e)
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                Ordenes orden = db.Ordenes.Where(s => s.OrdenId == int.Parse(auxOrden)).FirstOrDefault();
                if (orden != null)
                {
                    orden.NotaOrden = TxtNotaOrden.Text;
                    db.Update(orden);
                    db.SaveChanges();

                    this.Close();
                }
            }

            MessageBox.Show("La nota ha sido guardada.", "Correcto",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
