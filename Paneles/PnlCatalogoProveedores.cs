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
    public partial class PnlCatalogoProveedores : Form
    {
        //Variable de conexion

        public Conexion conexion;

        //Variables propias

        public Proveedor proveedor;

        public PnlCatalogoProveedores(Conexion conexion)
        {
            InitializeComponent();

            this.conexion = conexion;
            this.proveedor = new Proveedor(conexion);

            dgvCatalogoClientes.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvCatalogoClientes.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);

            dgvCatalogoClientes.DataSource = proveedor.Mostra_Proveedores(txtFiltrar.Texts);
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFiltrar__TextChanged(object sender, EventArgs e)
        {
            dgvCatalogoClientes.DataSource = proveedor.Mostra_Proveedores(txtFiltrar.Texts);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Auditorias auditorias = new Auditorias(conexion);
            //Insertar en auditorias
            auditorias.Insertar(conexion.usuario, "Boton Creacion", dgvCatalogoClientes.Rows[0].Cells[0].Value.ToString(), "Proveedor");



            PnlAgregarProveedor pnlAgregarProveedor = new PnlAgregarProveedor(conexion);
            pnlAgregarProveedor.Show();

            

        }

        private void Actualiza()
        {
            dgvCatalogoClientes.DataSource = proveedor.Mostra_Proveedores(txtFiltrar.Texts);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogoClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ningun proveedor para actualziar");
                return;
            }

            Auditorias auditorias = new Auditorias(conexion);
            //Insertar en auditorias
            auditorias.Insertar(conexion.usuario, "Boton de Actualizacion", dgvCatalogoClientes.SelectedRows[0].Cells[0].Value.ToString(), "Proveedor");



            PnlActualizarProveedor pnlActualizarProveedor = new PnlActualizarProveedor(conexion);

            pnlActualizarProveedor.Show();

            pnlActualizarProveedor.txtId.Text = dgvCatalogoClientes.SelectedRows[0].Cells["IdProveedor"].Value.ToString();
            pnlActualizarProveedor.txtNombre.Text= dgvCatalogoClientes.SelectedRows[0].Cells["NombreEmpresa"].Value.ToString();
            pnlActualizarProveedor.txtTelefono.Text = dgvCatalogoClientes.SelectedRows[0].Cells["NoTelefono"].Value.ToString();
            pnlActualizarProveedor.txtNoRuc.Text = dgvCatalogoClientes.SelectedRows[0].Cells["NoRuc"].Value.ToString();
            pnlActualizarProveedor.txtEmail.Text = dgvCatalogoClientes.SelectedRows[0].Cells["Correo"].Value.ToString();
            pnlActualizarProveedor.txtDireccion.Text = dgvCatalogoClientes.SelectedRows[0].Cells["Direccion"].Value.ToString();
        }

        private void PnlCatalogoProveedores_Load(object sender, EventArgs e)
        {
            dgvCatalogoClientes.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
        }

        private void especialButton2_Click(object sender, EventArgs e)
        {
            dgvCatalogoClientes.DataSource = proveedor.Mostra_Proveedores(txtFiltrar.Texts);
        }
    }
}
