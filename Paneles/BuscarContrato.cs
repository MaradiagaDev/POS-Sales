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

namespace NeoCobranza.Paneles
{
    public partial class BuscarContrato : Form
    {
        public Conexion conexion;
        public CContrato cContrato;
       
        public BuscarContrato(Conexion conexion)
        {
            InitializeComponent();
            cContrato = new CContrato(conexion);
            dagvContrato.DataSource = cContrato.MostrarContratos(txtFiltro.Texts, "Proforma");
            PnlPrincipal pnlPrincipal = Owner as PnlPrincipal;
            this.conexion= conexion;

            //Estilo
            dagvContrato.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dagvContrato.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);

        }

       
        private void txtFiltro__TextChanged(object sender, EventArgs e)
        {
            dagvContrato.DataSource = cContrato.MostrarContratos(txtFiltro.Texts, "Proforma");
        }

        private void btnGenerarProforma_Click(object sender, EventArgs e)
        {
            if (dagvContrato.SelectedRows.Count == 0 )
            {
                MessageBox.Show("No ha seleccionado ninguna proforma", "Atencion");
                return;
            }

            PanelFinal reporteProformaContrato = new PanelFinal(int.Parse(dagvContrato.SelectedRows[0].Cells[0].Value.ToString()),conexion);
            reporteProformaContrato.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizarProforma_Click(object sender, EventArgs e)
        {

            //Verificar que haya una row seleccionada
            if (dagvContrato.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ninguna proforma", "Atencion");
                return;
            }
               //Se llama al panel que queremos abrir

                PnlProformaContrato pnlProformaContrato = new PnlProformaContrato(conexion,
                    int.Parse(dagvContrato.SelectedRows[0].Cells[0].Value.ToString()));

                PnlPrincipal pnlPrincipal = Owner as PnlPrincipal;
                pnlProformaContrato.TopLevel = false;
                pnlProformaContrato.Dock = DockStyle.Fill;
                pnlPrincipal.PnlCentral.Controls.Add(pnlProformaContrato);
            pnlPrincipal.PnlCentral.Tag = pnlProformaContrato;




                pnlProformaContrato.Show();

             

                this.Hide();


            
        }

        private void BuscarContrato_Load(object sender, EventArgs e)
        {
            dagvContrato.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
        }

        private void especialButton2_Click(object sender, EventArgs e)
        {
            //Verificar que haya una row seleccionada
            if (dagvContrato.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ninguna proforma", "Atencion");
                return;
            }
            ProformaVenta proforma = new ProformaVenta(conexion);

            proforma.DeletePC(int.Parse(dagvContrato.SelectedRows[0].Cells[0].Value.ToString()));
        }
    }
}
