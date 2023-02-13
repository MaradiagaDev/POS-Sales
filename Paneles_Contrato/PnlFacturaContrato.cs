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
    public partial class PnlFacturaContrato : Form
    {
        private Conexion conexion;
        private Contrato contrato;

        //Constructor normal
        public PnlFacturaContrato(Conexion conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
            this.contrato = new Contrato(conexion);

            dgvStock.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvStock.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);

            //Filtro
            dgvStock.DataSource = contrato.Facturas_Listar(txtFiltro.Texts);
        }

        //Contructor para realizar factura

        public PnlFacturaContrato(Conexion conexion,int id)
        {
            InitializeComponent();
            this.conexion = conexion;
            this.contrato = new Contrato(conexion);

            dgvStock.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvStock.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);


            //Filtro
            dgvStock.DataSource = contrato.Facturas_Listar_ID(id);
        }

        private void txtFiltroId__TextChanged(object sender, EventArgs e)
        {
            int prueba;
            if(txtFiltroId.Texts == "")
            {
                return;
            }else if( int.TryParse(txtFiltroId.Texts,out prueba) == false)
            {
                return;
            }

            //Filtro
            dgvStock.DataSource = contrato.Facturas_Listar_ID(int.Parse(txtFiltroId.Texts));

        }

        private void txtFiltro__TextChanged(object sender, EventArgs e)
        {
            //Filtro
            dgvStock.DataSource = contrato.Facturas_Listar(txtFiltro.Texts);
        }


        //Cambio de texto

    }
}
