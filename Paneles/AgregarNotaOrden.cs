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
        private string auxSucursal;
        public AgregarNotaOrden(string key,string sucursal)
        {
            auxSucursal = sucursal;
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

            dataUtilities.SetParameter("@Orden", auxOrden);
            dataUtilities.SetParameter("@sucursal",auxSucursal);
            dataUtilities.SetParameter("@nota", TxtNotaOrden.Text);
            dataUtilities.ExecuteStoredProcedure("ActualizarNotaOrdenSucursal");

            this.Close();
        }
    }
}
