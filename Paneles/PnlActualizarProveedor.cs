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
    public partial class PnlActualizarProveedor : Form
    {
        //variable de conexion
        public Conexion conexion;

        //Variable nueva a utilizar

        public Proveedor proveedor;
        public PnlActualizarProveedor(Conexion conexion)
        {
            InitializeComponent();

            this.conexion = conexion;
            this.proveedor = new Proveedor(conexion);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtNoRuc.Text == "" || txtTelefono.Text == "" || txtDireccion.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Hay campos de textos vacios");

                return;
            }

            proveedor.IdProveedor =int.Parse(txtId.Text);
            proveedor.NombreEmpresa = txtNombre.Text;
            proveedor.NoRuc = txtNoRuc.Text;
            proveedor.NoTelefono = txtTelefono.Text;
            proveedor.Direccion = txtDireccion.Text;
            proveedor.Correo = txtEmail.Text;

            proveedor.Actualizar_Proveedor();

            this.Close();

        }
    }
}
