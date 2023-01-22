using NeoCobranza.Clases;
using NeoCobranza.Data;
using NeoCobranza.Paneles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles_Colectores
{
    public partial class PnlColector : Form
    {
        public Conexion conexion;
        public Colector colector;
        public string tipo;
        public PnlColector(Conexion conexion,string tipo)
        {
            InitializeComponent();
            //Incializar la clase de conexion
            this.conexion = conexion;
            this.colector = new Colector(conexion);
            this.tipo = tipo;
            //Estilo del data
            DgvColector.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            DgvColector.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);

            //LLenar el data
            DgvColector.DataSource = colector.Colector_listar(txtFiltro.Texts);

        }

        private void DgvColector_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtFiltro__TextChanged(object sender, EventArgs e)
        {
            //LLenar el data
            DgvColector.DataSource = colector.Colector_listar(txtFiltro.Texts);
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            if (tipo == "Primera")
            {


                if (DgvColector.SelectedRows[0].Cells[0].Value == null)
                {
                    MessageBox.Show("No has seleccionado ningun registro", "ERROR");
                    return;
                }
                if (DgvColector.SelectedRows.Count == 0)
                {
                    MessageBox.Show("No has seleccionado ningun registro", "ERROR");
                    return;
                }
                //Si todo salio bien

                PnlPagoCuotas pnlPagoCuotas = Owner as PnlPagoCuotas;

                pnlPagoCuotas.txtNombre.Text = DgvColector.SelectedRows[0].Cells[1].Value.ToString();
                pnlPagoCuotas.txtIdColector.Text = DgvColector.SelectedRows[0].Cells[0].Value.ToString();

                this.Close();

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
