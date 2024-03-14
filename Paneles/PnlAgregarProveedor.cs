using NeoCobranza.Clases;
using NeoCobranza.Data;
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
    public partial class PnlAgregarProveedor : Form
    {
        VMCatalogoProveedores vMCatalogoProveedores = new VMCatalogoProveedores();

        public PnlAgregarProveedor(PnlCatalogoProveedores frm,string opc,string key)
        {
            InitializeComponent();
            vMCatalogoProveedores.InitModuloCrearProveedor(frm,this,opc,key);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            vMCatalogoProveedores.FuncionesPrincipalesClientes(this);
        }
    }
}
