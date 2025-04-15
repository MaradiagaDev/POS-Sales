using NeoCobranza.Data;
using NeoCobranza.DataController;
using NeoCobranza.Paneles_Venta;
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

        public VMCatalogoCliente vMCatalogoCliente = new VMCatalogoCliente();
        public PnlCatalogoClientes frmPnlCatalogoCliente;
        public string auxIdCliente;
        public PnlVentas auxfrmVenta;
        public bool auxProvicional=false;
        public PanelModificarCliente(PnlCatalogoClientes frm,string key,PnlVentas venta)
        {
            InitializeComponent();
            this.frmPnlCatalogoCliente = frm;
            auxIdCliente = key;
            this.auxfrmVenta = venta;

            if (!Utilidades.PermisosLevel(3, 76))
            {
                BtnConfigurarAcceso.Visible = false;
            }
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

        private void BtnConfigurarAcceso_Click(object sender, EventArgs e)
        {
            if(vMCatalogoCliente.auxKeyUsuario == "Crear")
            {
                DialogResult result = MessageBox.Show("¿Deseas guardar los datos del cliente para continuar con esta acción?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    auxProvicional = true;
                    vMCatalogoCliente.FuncionesCrearModificarCliente(this);

                    if (String.IsNullOrEmpty(vMCatalogoCliente.auxId))
                    {
                        auxProvicional = false;
                        return;
                    }
                }
                else
                {
                    auxProvicional = false;
                    return;
                }
            }

            PnlAsociacionCliente frm = new PnlAsociacionCliente(vMCatalogoCliente.auxId);
            frm.ShowDialog();

            auxProvicional = false;
        }
    }
}
