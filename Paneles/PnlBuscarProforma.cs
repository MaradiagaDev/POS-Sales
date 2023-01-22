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
using NeoCobranza.Data;
using NeoCobranza.DataController;
using NeoCobranza.Clases;

namespace NeoCobranza.Paneles
{
    
    public partial class PnlBuscarProforma : Form
    {
        public Conexion conexion;
        public CBusquedaProformas cbusquedaProformas;
        public ProformaVenta proforma;
        public PnlBuscarProforma(Conexion conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
            this.proforma = new ProformaVenta(conexion);
            cbusquedaProformas = new CBusquedaProformas(conexion);
            DgvBusquedas.DataSource = cbusquedaProformas.BuscarProforma(txtFiltro.Texts);

            //Estilo
            DgvBusquedas.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            DgvBusquedas.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);

        }

        private void txtFiltro__TextChanged(object sender, EventArgs e)
        {
            DgvBusquedas.DataSource = cbusquedaProformas.BuscarProforma(txtFiltro.Texts);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            if(DgvBusquedas.SelectedRows.Count == 0 && DgvBusquedas.SelectedRows[0].ToString()==null)
            {
                MessageBox.Show("No ha seleccionado ninguna proforma","Atencion");
                return;
            }
            InformeReporteServiciosVD reporteProforma = new InformeReporteServiciosVD(int.Parse(DgvBusquedas.SelectedRows[0].Cells[0].Value.ToString()),conexion);
            
            
            reporteProforma.Show();
        }

        private void btnActualizarProforma_Click(object sender, EventArgs e)
        {
            if (DgvBusquedas.SelectedRows.Count == 0 )
            {
                MessageBox.Show("No ha seleccionado ninguna proforma", "Atencion");
                return;
            }

            int idProforma = int.Parse(DgvBusquedas.SelectedRows[0].Cells["Id"].Value.ToString());
            int idCliente = int.Parse(DgvBusquedas.SelectedRows[0].Cells["IdCliente"].Value.ToString());
            string nombreCliente= DgvBusquedas.SelectedRows[0].Cells["Nombres"].Value.ToString();

            PnlProforma pnlProforma = new PnlProforma(conexion, idProforma);


           
            PnlPrincipal pnlPrincipal = Owner as PnlPrincipal;
            pnlProforma.TopLevel = false;
            pnlPrincipal.PnlCentral.Controls.Add(pnlProforma);
            pnlProforma.Show();

            pnlProforma.llbTitulo.Text = "Actualizacion de proforma";
            this.Hide();

        }

       


        private void PnlBuscarProforma_Load(object sender, EventArgs e)
        {
            DgvBusquedas.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            DgvBusquedas.AllowUserToAddRows = false; //Codigo para quitar la ultima fila del datagrid de este panel
        }

        private void especialButton2_Click(object sender, EventArgs e)
        {

            if (DgvBusquedas.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ninguna proforma", "Atencion");
                return;
            }

            proforma.Delete(int.Parse(DgvBusquedas.SelectedRows[0].Cells[0].Value.ToString()));

            DgvBusquedas.DataSource = cbusquedaProformas.BuscarProforma(txtFiltro.Texts);
        }
    }
}
