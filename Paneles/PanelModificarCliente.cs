using NeoCobranza.Data;
using NeoCobranza.DataController;
using NeoCobranza.ViewModels;
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
    public partial class PanelModificarCliente : Form
    {

        VMCatalogoCliente vMCatalogoCliente = new VMCatalogoCliente();
        public PnlCatalogoClientes frmPnlCatalogoCliente;
        public string auxIdCliente;
        
        public PanelModificarCliente(PnlCatalogoClientes frm,string key)
        {
            InitializeComponent();
            this.frmPnlCatalogoCliente = frm;
            auxIdCliente = key;
        }

        private void PanelModificarCliente_Load(object sender, EventArgs e)
        {
            vMCatalogoCliente.InitModuloModificarClientes(this,auxIdCliente);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            vMCatalogoCliente.FuncionesCrearModificarCliente(this);
        }

    }
}
