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
        public PnlInformeEconomico(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void PnlInformeEconomico_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'neoCobranzaDataSet.Contrato_Ver_Valores' Puede moverla o quitarla según sea necesario.
            this.contrato_Ver_ValoresTableAdapter.Fill(this.neoCobranzaDataSet.Contrato_Ver_Valores,id);
            // TODO: esta línea de código carga datos en la tabla 'neoCobranzaDataSet1.Tasa2' Puede moverla o quitarla según sea necesario.
            this.tasa2TableAdapter.Fill(this.neoCobranzaDataSet1.Tasa2);
            // TODO: esta línea de código carga datos en la tabla 'neoCobranzaDataSet.Contrato_Informacion_Economica' Puede moverla o quitarla según sea necesario.
            this.contrato_Informacion_EconomicaTableAdapter.Fill(this.neoCobranzaDataSet.Contrato_Informacion_Economica,id);
            // TODO: esta línea de código carga datos en la tabla 'neoCobranzaDataSet.Contrato_Reporte_Datos_Generales' Puede moverla o quitarla según sea necesario.
            this.contrato_Reporte_Datos_GeneralesTableAdapter.Fill(this.neoCobranzaDataSet.Contrato_Reporte_Datos_Generales,id);
            // TODO: esta línea de código carga datos en la tabla 'neoCobranzaDataSet.Tasa' Puede moverla o quitarla según sea necesario.
            
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
