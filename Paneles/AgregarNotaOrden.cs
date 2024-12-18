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
    public partial class AgregarNotaOrden : Form
    {
        DataUtilities dataUtilities = new DataUtilities();
        private string auxOrden;
        public AgregarNotaOrden(string key)
        {
            InitializeComponent();

            DataTable dt = dataUtilities.getRecordByColumn("Ordenes", "OrdenId", key);
            auxOrden = Convert.ToString(dt.Rows[0][0]);

            if (dt.Rows.Count > 0)
            {
                TxtNotaOrden.Text = Convert.ToString(dt.Rows[0]["NotaOrden"]);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardarNota_Click(object sender, EventArgs e)
        {
            dataUtilities.SetColumns("NotaOrden",TxtNotaOrden.Text);
            dataUtilities.UpdateRecordByPrimaryKey("Ordenes", auxOrden);

            this.Close();
        }
    }
}
