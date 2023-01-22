using NeoCobranza.Clases;
using NeoCobranza.Data;
using NeoCobranza.DataController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles_Auditorias
{
    
    public partial class PnlPrincipalAuditorias : Form
    {
        public CAuditoria cAuditoria;
        public Conexion conexion;
        public Auditorias auditorias;
        public PnlPrincipalAuditorias(Conexion conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
            this.cAuditoria = new CAuditoria(conexion);

            auditorias = new Auditorias(conexion);

            //Estilo
            dgvHistorial.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvHistorial.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);

            dgvHistorial.DataSource = auditorias.Mostra_Filtroauditoria(txtFiltro.Texts);
        }

        private void ComprobarParaCalculos()
        {
           


        }

        private void BtnGenerarReporte_Click(object sender, EventArgs e)
        {
            ComprobarParaCalculos();


            //
            
        }

        private void cmbTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComprobarParaCalculos();
        }

        private void BtnCrear_CheckedChanged(object sender, EventArgs e)
        {
            ComprobarParaCalculos();
        }

        private void btnActualizacion_CheckedChanged(object sender, EventArgs e)
        {
            ComprobarParaCalculos();
        }

        private void lblFecha_ValueChanged(object sender, EventArgs e)
        {
            ComprobarParaCalculos();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ComprobarParaCalculos();
        }

        private void txtFiltro__TextChanged(object sender, EventArgs e)
        {
            ComprobarParaCalculos();
        }

        private void cmbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComprobarParaCalculos();
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFiltro__TextChanged_1(object sender, EventArgs e)
        {
            dgvHistorial.DataSource = auditorias.Mostra_Filtroauditoria(txtFiltro.Texts.ToString());
        }
    }
}
