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
    public partial class PnlHistorialCierresCaja : Form
    {
        public PnlHistorialCierresCaja()
        {
            InitializeComponent();
        }

        private void PnlHistorialCierresCaja_Load(object sender, EventArgs e)
        {
            UIUtilities.PersonalizarDataGridViewPequeños(dgvGeneral);
            DataUtilities dataUtilities = new DataUtilities();
            dataUtilities.SetParameter("@SucursalId", Utilidades.SucursalId);
            dgvGeneral.DataSource = dataUtilities.ExecuteStoredProcedure("spCierresHistorial");
        }
        
    }
}
