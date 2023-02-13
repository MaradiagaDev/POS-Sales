using NeoCobranza.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles_Venta.Informes
{
    public partial class Rpt_InformeGeneralCaja : Form
    {
        public string FechaI,FechaF;
        private Conexion conexion;
        public Rpt_InformeGeneralCaja(string fechaI,string fechaF,Conexion conexion)
        {
            InitializeComponent();
            this.FechaI = fechaI;
            this.FechaF = fechaF;
            this.conexion = conexion;

        }

        private void Rpt_InformeGeneralCaja_Load(object sender, EventArgs e)
        {
            //Conexion
            this.reporteria_Ventas_GeneralesTableAdapter.Connection = conexion.connect;

            // TODO: esta línea de código carga datos en la tabla 'data_Facturacion.Reporteria_Ventas_Generales' Puede moverla o quitarla según sea necesario.
            this.reporteria_Ventas_GeneralesTableAdapter.Fill(this.data_Facturacion.Reporteria_Ventas_Generales,FechaI,FechaF);

            this.reportViewer1.RefreshReport();
        }
    }
}
