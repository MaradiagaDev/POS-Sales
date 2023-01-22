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

namespace NeoCobranza.Paneles
{
    public partial class PnlAgregarProveedor : Form
    {
        //Clase de conexion
        public Conexion conexion;

        //Nueva clase utilizada
        public Proveedor proveedor;

        public PnlAgregarProveedor(Conexion conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
            this.proveedor = new Proveedor(conexion);
        }
        private void limpiar()
        {
            txtNombre.clear();
            txtNoRuc.Text="";
            txtTelefono.Text = "";
            txtDireccion.clear();
            txtEmail.Text = "";
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            this.Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Texts ==""|| txtNoRuc.Text=="" || txtTelefono.Text==""|| txtDireccion.Texts=="" || txtEmail.Text=="")
            {
                MessageBox.Show("Hay campos de textos vacios");

                return;
            }



            proveedor.NombreEmpresa=txtNombre.Texts;
            proveedor.NoRuc=txtNoRuc.Text;
            proveedor.NoTelefono = txtTelefono.Text;
            proveedor.Direccion=txtDireccion.Texts;
            proveedor.Correo = txtEmail.Text;

            proveedor.Insertar_Proveedor();

            limpiar();

            this.Hide();
        }
    }
}
