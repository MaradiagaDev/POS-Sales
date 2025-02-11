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
    public partial class PnlGenerarInforme : Form
    {
        DataUtilities dataUtilities = new DataUtilities();

        string auxInforme = "";

        public PnlGenerarInforme(string informe)
        {
            InitializeComponent();
            auxInforme = informe;
        }

        private void PnlGenerarInforme_Load(object sender, EventArgs e)
        {
            DateTime fechaInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1);
            DateTime fechaFin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(1);

            DtInicial.Value = fechaInicio;
            DtFinal.Value = fechaFin;

            DataTable dtResponseSucursales = dataUtilities.GetAllRecords("Sucursal");

            // Filtra las filas donde el campo Estado sea "Activo"
            var filterRowSucursales = from row in dtResponseSucursales.AsEnumerable()
                                      where Convert.ToString(row.Field<string>("Estado")) == "Activo"
                                      select row;
            // Configura el DataSource del combo box
            CmbSucursal.ValueMember = "IdSucursal";
            CmbSucursal.DisplayMember = "NombreSucursal";
            CmbSucursal.DataSource = filterRowSucursales.CopyToDataTable();

            CmbSucursal.SelectedValue = Utilidades.SucursalId;
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            switch (auxInforme)
            {
                case "ReporteVentas":
                    {
                        UtilidadesInformes.CargarInformeVentas(Convert.ToString(CmbSucursal.SelectedValue),DtInicial.Value,DtFinal.Value);
                        break;
                    }
            }
        }
    }
}
