using NeoCobranza.Clases;
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
    public partial class PnlRetirado : Form
    {
        private Conexion conexion;
        private Contrato contrato;
        public PnlRetirado(Conexion conexion)
        {
            InitializeComponent();

            this.conexion = conexion;

            this.contrato = new Contrato(conexion);

            dgvStock.DataSource = contrato.Contrato_Listar_Retirados(txtFiltro.Texts);

            //estilo
            dgvStock.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvStock.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);


        }

        private void txtFiltro__TextChanged(object sender, EventArgs e)
        {
            dgvStock.DataSource = contrato.Contrato_Listar_Retirados(txtFiltro.Texts);
        }
    }
}
