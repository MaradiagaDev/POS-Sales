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

namespace NeoCobranza.Paneles_Contrato
{
    public partial class PnlInformeEconomico : Form
    {
        private int id;
        private Conexion conexion;
        public PnlInformeEconomico(int id,Conexion conexion)
        {
            InitializeComponent();
            this.id = id;
            this.conexion = conexion;
        }

        private void PnlInformeEconomico_Load(object sender, EventArgs e)
        {
           
            //Pasamos Conexion
            this.contrato_Reporte_Datos_GeneralesTableAdapter.Connection = conexion.connect;
            this.contrato_OtrosServiciosTableAdapter.Connection = conexion.connect;
            this.contrato_Beneficiario_ReporteTableAdapter.Connection = conexion.connect;
            this.contrato_Ver_ValoresTableAdapter.Connection = conexion.connect;
            this.contrato_Ver_CuotasTableAdapter.Connection = conexion.connect;
            this.contrato_ColectorTableAdapter.Connection = conexion.connect;
            this.tasa2TableAdapter.Connection = conexion.connect;
            this.contrato_ValorCuotaTableAdapter.Connection = conexion.connect;

            // TODO: esta línea de código carga datos en la tabla 'neoCobranzaDataSet.Contrato_Reporte_Datos_Generales' Puede moverla o quitarla según sea necesario.
            this.contrato_Reporte_Datos_GeneralesTableAdapter.Fill(this.neoCobranzaDataSet.Contrato_Reporte_Datos_Generales,id);
            // TODO: esta línea de código carga datos en la tabla 'nuevoServi_Contrato.Contrato_OtrosServicios' Puede moverla o quitarla según sea necesario.
            this.contrato_OtrosServiciosTableAdapter.Fill(this.nuevoServi_Contrato.Contrato_OtrosServicios, id);
            // TODO: esta línea de código carga datos en la tabla 'nuevoServi_Contrato.Contrato_Beneficiario_Reporte' Puede moverla o quitarla según sea necesario.
            this.contrato_Beneficiario_ReporteTableAdapter.Fill(this.nuevoServi_Contrato.Contrato_Beneficiario_Reporte, id);
            // TODO: esta línea de código carga datos en la tabla 'nuevoServi_Contrato.Contrato_Ver_Valores' Puede moverla o quitarla según sea necesario.
            this.contrato_Ver_ValoresTableAdapter.Fill(this.nuevoServi_Contrato.Contrato_Ver_Valores, id);
            // TODO: esta línea de código carga datos en la tabla 'nuevoServi_Contrato.Contrato_Ver_Cuotas' Puede moverla o quitarla según sea necesario.
            this.contrato_Ver_CuotasTableAdapter.Fill(this.nuevoServi_Contrato.Contrato_Ver_Cuotas, id);
            // TODO: esta línea de código carga datos en la tabla 'nuevoServi_Contrato.Contrato_Colector' Puede moverla o quitarla según sea necesario.
            this.contrato_ColectorTableAdapter.Fill(this.nuevoServi_Contrato.Contrato_Colector, id);
            // TODO: esta línea de código carga datos en la tabla 'neoCobranzaDataSet.Tasa2' Puede moverla o quitarla según sea necesario.
            this.tasa2TableAdapter.Fill(this.neoCobranzaDataSet.Tasa2);
            // TODO: esta línea de código carga datos en la tabla 'nuevoServi_Contrato.Contrato_ValorCuota' Puede moverla o quitarla según sea necesario.
            this.contrato_ValorCuotaTableAdapter.Fill(this.nuevoServi_Contrato.Contrato_ValorCuota,id);

            this.reportViewer1.RefreshReport();
        }
    }
}
