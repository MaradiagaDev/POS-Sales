using NeoCobranza.Clases;
using NeoCobranza.Data;
using NeoCobranza.DataController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace NeoCobranza.Paneles
{
    public partial class PnlCatalogoClientes : Form
    {
        public Conexion conexion;
        public CCliente cCliente;
        public PanelCliente panelCliente;
        public PanelModificarCliente panelModificarCliente;
        public PnlCatalogoClientes(Conexion conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
            cCliente = new CCliente(conexion);
            dgvCatalogoClientes.DataSource = cCliente.MostrarCliente(txtFiltrar.Texts);
            panelCliente = new PanelCliente(conexion, "Agregar");

            //Estilo del data
            dgvCatalogoClientes.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvCatalogoClientes.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);

        }




        private void txtFiltrar__TextChanged(object sender, EventArgs e)
        {
            dgvCatalogoClientes.DataSource= cCliente.MostrarCliente(txtFiltrar.Texts);


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Auditorias auditorias = new Auditorias(conexion);
            //Insertar en auditorias
            auditorias.Insertar(conexion.usuario, " Boton Creacion", dgvCatalogoClientes.Rows[0].Cells[0].Value.ToString(), "Clientes");


            panelCliente.Show();

            //Actualizar datos

            dgvCatalogoClientes.DataSource = cCliente.MostrarCliente(txtFiltrar.Texts);
        }
        public DataGridView DgvCatalogoCliente
        {
            get { return dgvCatalogoClientes; }
            set { dgvCatalogoClientes = value; }
        }
        private void LLenarPanel()
        {
            panelModificarCliente = new PanelModificarCliente(conexion, this.dgvCatalogoClientes, "Actualizar");
            panelModificarCliente.Show();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogoClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el cliente que quiere actualizar");
                return;

            }
            panelModificarCliente = new PanelModificarCliente(conexion, this.dgvCatalogoClientes, "Actualizar");
            
            panelModificarCliente.Show();
            
            cCliente.MostrarCliente("");

            Auditorias auditorias = new Auditorias(conexion);
            //Insertar en auditorias
            auditorias.Insertar(conexion.usuario, "Boton Actualizacion", dgvCatalogoClientes.SelectedRows[0].Cells[0].Value.ToString(), "Clientes");


            //Actualizar datos

            dgvCatalogoClientes.DataSource = cCliente.MostrarCliente(txtFiltrar.Texts);
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PnlCatalogoClientes_Load(object sender, EventArgs e)
        {
            dgvCatalogoClientes.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
        }

        private void especialButton2_Click(object sender, EventArgs e)
        {
            dgvCatalogoClientes.DataSource = cCliente.MostrarCliente(txtFiltrar.Texts);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
