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

         

            if(auxInforme == "Limites")
            {
                LblSucursal.Text = "Almacén";
                DataTable dtResponseAlmacenes = dataUtilities.GetAllRecords("Almacenes");

                // Filtra las filas donde el campo Estado sea "Activo"
                var filterRowAlmacenes = from row in dtResponseAlmacenes.AsEnumerable()
                                          where Convert.ToString(row.Field<string>("Estatus")) == "Activo"
                                          select row;
                // Configura el DataSource del combo box

                CmbSucursal.ValueMember = "AlmacenId";
                CmbSucursal.DisplayMember = "NombreAlmacen";
                CmbSucursal.DataSource = filterRowAlmacenes.CopyToDataTable();
                CmbSucursal.SelectedIndex = 0;

                DtInicial.Visible = false;
                DtFinal.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
            }
            else if(auxInforme == "Ajustes")
            {
                LblSucursal.Text = "Almacén";
                DataTable dtResponseAlmacenes = dataUtilities.GetAllRecords("Almacenes");

                // Filtra las filas donde el campo Estado sea "Activo"
                var filterRowAlmacenes = from row in dtResponseAlmacenes.AsEnumerable()
                                         where Convert.ToString(row.Field<string>("Estatus")) == "Activo"
                                         select row;
                // Configura el DataSource del combo box

                CmbSucursal.ValueMember = "AlmacenId";
                CmbSucursal.DisplayMember = "NombreAlmacen";
                CmbSucursal.DataSource = filterRowAlmacenes.CopyToDataTable();
                CmbSucursal.SelectedIndex = 0;
            }
            else
            {
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
                case "CuentasCobrar":
                    {
                        UtilidadesInformes.CargarInformeVentasCredito(Convert.ToString(CmbSucursal.SelectedValue),DtInicial.Value,DtFinal.Value);
                        break;
                    }
                case "Asistencias":
                    {
                        UtilidadesInformes.CargarInformeAsistencia(Convert.ToString(CmbSucursal.SelectedValue), DtInicial.Value, DtFinal.Value);
                        break;
                    }
                case "Anuladas":
                    {
                        UtilidadesInformes.CargarInformeVentasAnuladas(Convert.ToString(CmbSucursal.SelectedValue), DtInicial.Value, DtFinal.Value);
                        break;
                    }
                case "Productos":
                    {
                        UtilidadesInformes.CargarInformeProductos(Convert.ToString(CmbSucursal.SelectedValue), DtInicial.Value, DtFinal.Value);
                        break;
                    }
                case "Limites":
                    {
                        UtilidadesInformes.CargarInformeLimites(Convert.ToString(CmbSucursal.SelectedValue));
                        break;
                    }
                case "Cortes":
                    {
                        UtilidadesInformes.CargarInformeCortes(Convert.ToString(CmbSucursal.SelectedValue), DtInicial.Value, DtFinal.Value);
                        break;
                    }
                case "Compras":
                    {
                        UtilidadesInformes.CargarInformeCompras(Convert.ToString(CmbSucursal.SelectedValue), DtInicial.Value, DtFinal.Value);
                        break;
                    }
                case "Ajustes":
                    UtilidadesInformes.CargarInformeAjustes(Convert.ToString(CmbSucursal.SelectedValue), DtInicial.Value, DtFinal.Value);
                    break;
            }

            this.Close();
        }
    }
}
