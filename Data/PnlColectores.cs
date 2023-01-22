using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeoCobranza.DataController;
using NeoCobranza.Paneles;
namespace NeoCobranza.Data
{
    public partial class PnlColectores : Form
    {
        public Conexion conexion;
        public CColector cColector;
        public PnlColectores(Conexion conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
            cColector = new CColector(conexion);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void loginUserControl1__TextChanged(object sender, EventArgs e)
        {
            this.DgvColector.DataSource = cColector.BuscarColector(this.loginUserControl1.Texts);
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {

            PnlContrato pnlContrato = Owner as PnlContrato;


            // pnlContrato.dgvColector.Rows.Add(this.DgvColector.SelectedRows[0].Cells[0].Value +" "+ this.DgvColector.SelectedRows[0].Cells[1].Value + " "+this.DgvColector.SelectedRows[0].Cells[2].Value + " " + this.DgvColector.SelectedRows[0].Cells[3].Value, this.DgvColector.SelectedRows[0].Cells[4].Value);
            pnlContrato.lblNombreColector.Text = this.DgvColector.SelectedRows[0].Cells[0].Value + " " + this.DgvColector.SelectedRows[0].Cells[1].Value + " " + this.DgvColector.SelectedRows[0].Cells[2].Value + " " + this.DgvColector.SelectedRows[0].Cells[3].Value;
            pnlContrato.lblIdColector.Text = this.DgvColector.SelectedRows[0].Cells[4].Value.ToString();



            this.Hide();
        }
    }
}
