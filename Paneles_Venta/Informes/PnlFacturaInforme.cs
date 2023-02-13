using Microsoft.Reporting.WinForms;
using NeoCobranza.Clases;
using NeoCobranza.Data;
using NeoCobranza.DataController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles_Venta.Informes
{
    public partial class PnlFacturaInforme : Form
    {
        public int id;
        public Conexion conexion;
        public CTasaCambio ctasa;
        public VentasDirectas ventas;

        public PnlFacturaInforme(int id,Conexion conexion)
        {
            InitializeComponent();
            this.id = id;   
            this.conexion = conexion;
            this.ctasa = new CTasaCambio(conexion);
            this.ventas = new VentasDirectas(conexion);
        }

        private void PnlFacturaInforme_Load(object sender, EventArgs e)
        {

            //Inicializador  de los parametros
            ReportParameter[] parameters = new ReportParameter[6];

            //Verificar si alguno de los dos esta vacio
            if (ventas.Mostra_SubTotal_Ataudes(id).Rows[0][0].ToString() == "")
            {
                parameters[0] = new ReportParameter("TipoCambio", ctasa.MostrarTasa());
                parameters[1] = new ReportParameter("Precio", ventas.Mostra_SubTotal_Servicios(id).Rows[0][0].ToString());
                parameters[2] = new ReportParameter("Nominal", ventas.Mostra_SubTotal_Servicios(id).Rows[0][1].ToString());
                parameters[3] = new ReportParameter("Descuento", ventas.Mostra_SubTotal_Servicios(id).Rows[0][2].ToString());
                parameters[4] = new ReportParameter("iva", ventas.Mostra_SubTotal_Servicios(id).Rows[0][3].ToString());
                parameters[5] = new ReportParameter("total", ventas.Mostra_SubTotal_Servicios(id).Rows[0][4].ToString());


            }
            if (ventas.Mostra_SubTotal_Servicios(id).Rows[0][1].ToString() == "")
            {
                parameters[0] = new ReportParameter("TipoCambio", ctasa.MostrarTasa());
                parameters[1] = new ReportParameter("Precio", ventas.Mostra_SubTotal_Ataudes(id).Rows[0][0].ToString());
                parameters[2] = new ReportParameter("Nominal", ventas.Mostra_SubTotal_Ataudes(id).Rows[0][1].ToString());
                parameters[3] = new ReportParameter("Descuento", ventas.Mostra_SubTotal_Ataudes(id).Rows[0][2].ToString());
                parameters[4] = new ReportParameter("iva", ventas.Mostra_SubTotal_Ataudes(id).Rows[0][3].ToString());
                parameters[5] = new ReportParameter("total", ventas.Mostra_SubTotal_Ataudes(id).Rows[0][4].ToString());


            }
            if (ventas.Mostra_SubTotal_Ataudes(id).Rows[0][0].ToString() != "" && ventas.Mostra_SubTotal_Servicios(id).Rows[0][1].ToString() != "")
            {
                parameters[0] = new ReportParameter("TipoCambio", ctasa.MostrarTasa());
                parameters[1] = new ReportParameter("Precio", (double.Parse(ventas.Mostra_SubTotal_Ataudes(id).Rows[0][0].ToString()) + double.Parse(ventas.Mostra_SubTotal_Servicios(id).Rows[0][0].ToString())).ToString());
                parameters[2] = new ReportParameter("Nominal", (double.Parse(ventas.Mostra_SubTotal_Ataudes(id).Rows[0][1].ToString()) + double.Parse(ventas.Mostra_SubTotal_Servicios(id).Rows[0][1].ToString())).ToString());
                parameters[3] = new ReportParameter("Descuento", (double.Parse(ventas.Mostra_SubTotal_Ataudes(id).Rows[0][2].ToString()) + double.Parse(ventas.Mostra_SubTotal_Servicios(id).Rows[0][2].ToString())).ToString());
                parameters[4] = new ReportParameter("iva", (double.Parse(ventas.Mostra_SubTotal_Ataudes(id).Rows[0][3].ToString()) + double.Parse(ventas.Mostra_SubTotal_Servicios(id).Rows[0][3].ToString())).ToString());
                parameters[5] = new ReportParameter("total", (double.Parse(ventas.Mostra_SubTotal_Ataudes(id).Rows[0][4].ToString()) + double.Parse(ventas.Mostra_SubTotal_Servicios(id).Rows[0][4].ToString())).ToString());


            }



            this.nuevo_ListarAtaudesPorVenta2TableAdapter.Connection = conexion.connect;
            this.nuevo_ListarAServiciosPorVenta2TableAdapter.Connection = conexion.connect;
            this.reporteria_VentasGeneral2TableAdapter.Connection = conexion.connect;

                // TODO: esta línea de código carga datos en la tabla 'data_Facturacion.Nuevo_ListarAtaudesPorVenta2' Puede moverla o quitarla según sea necesario.
                this.nuevo_ListarAtaudesPorVenta2TableAdapter.Fill(this.data_Facturacion.Nuevo_ListarAtaudesPorVenta2, id);
                // TODO: esta línea de código carga datos en la tabla 'data_Facturacion.Nuevo_ListarAServiciosPorVenta2' Puede moverla o quitarla según sea necesario.
                this.nuevo_ListarAServiciosPorVenta2TableAdapter.Fill(this.data_Facturacion.Nuevo_ListarAServiciosPorVenta2, id);
                // TODO: esta línea de código carga datos en la tabla 'data_Facturacion.Reporteria_VentasGeneral2' Puede moverla o quitarla según sea necesario.
                this.reporteria_VentasGeneral2TableAdapter.Fill(this.data_Facturacion.Reporteria_VentasGeneral2, id);

                this.reportViewer1.LocalReport.SetParameters(parameters);
                this.reportViewer1.RefreshReport();

           
        }
    }
}
