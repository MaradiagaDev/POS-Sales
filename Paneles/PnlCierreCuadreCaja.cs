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
    public partial class PnlCierreCuadreCaja : Form
    {
        DataUtilities dataUtilities = new DataUtilities();
        public PnlCierreCuadreCaja()
        {
            InitializeComponent();

            UIUtilities.PersonalizarDataGridViewPequeños(dgvListasOrdenes);
            UIUtilities.PersonalizarDataGridViewPequeños(dgvListaGastos);
            UIUtilities.PersonalizarDataGridViewPequeños(dgvListaIngresos);

            //Cargar datos ordenes
            dataUtilities.SetParameter("@sucursalId", Utilidades.SucursalId);
            dgvListasOrdenes.DataSource = dataUtilities.ExecuteStoredProcedure("vwCierresCajaPagosOrdenes");

            //Cargar datos gastos
            dataUtilities.SetParameter("@sucursalId", Utilidades.SucursalId);
            dataUtilities.SetParameter("@bitIngreso", false);
            dgvListaGastos.DataSource = dataUtilities.ExecuteStoredProcedure("vwCierresCajaGastos");

            //Cargar datos Ingresos
            dataUtilities.SetParameter("@sucursalId", Utilidades.SucursalId);
            dataUtilities.SetParameter("@bitIngreso", true);
            dgvListaIngresos.DataSource = dataUtilities.ExecuteStoredProcedure("vwCierresCajaGastos");

            //Cargar datos individuales
        }


    }
}
