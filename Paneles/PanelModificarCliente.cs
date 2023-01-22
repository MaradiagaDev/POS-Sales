using NeoCobranza.Data;
using NeoCobranza.DataController;
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
        public Conexion conexion;
        public string panel;
        public PnlCatalogoClientes pnlCatalogoClientes;
        public CGeneral cGeneral;
        public CCliente cCliente;
        public PanelModificarCliente(Conexion conexion, DataGridView dgvCatalogoClientes, string panel)
        {
            InitializeComponent();
            this.conexion = conexion;
            this.panel = panel;
            cGeneral = new CGeneral(conexion);
            cCliente = new CCliente(conexion);
         

            if (panel == "Actualizar")
            {
                CargarCampos(dgvCatalogoClientes);
                
            }
        }
        private void CargarCampos(DataGridView dgvCatalogoClientes)
        {
            try
            {
                mtxtTelefono.Text = dgvCatalogoClientes.SelectedRows[0].Cells["Telefono"].Value.ToString();
                mtxtCelular.Text = dgvCatalogoClientes.SelectedRows[0].Cells["Celular"].Value.ToString();
                mtxtEmail.Text = dgvCatalogoClientes.SelectedRows[0].Cells["Email"].Value.ToString();
                mtxtCedula.Text = dgvCatalogoClientes.SelectedRows[0].Cells["Cedula"].Value.ToString();
                lblId.Text = dgvCatalogoClientes.SelectedRows[0].Cells["IdCliente"].Value.ToString();
                txtPrimerNombre.Text = dgvCatalogoClientes.SelectedRows[0].Cells["PNombre"].Value.ToString();
                txtSegundoNombre.Text = dgvCatalogoClientes.SelectedRows[0].Cells["SNombre"].Value.ToString();
                txtPrimerApellido.Text = dgvCatalogoClientes.SelectedRows[0].Cells["PApellido"].Value.ToString();
                txtSegundoApellido.Text = dgvCatalogoClientes.SelectedRows[0].Cells["SApellido"].Value.ToString();
                txtProfesion.Text = dgvCatalogoClientes.SelectedRows[0].Cells["Profesion"].Value.ToString();
                cmbDepartamento.Text= dgvCatalogoClientes.SelectedRows[0].Cells["Departamento"].Value.ToString();
                cmbPais.Text = dgvCatalogoClientes.SelectedRows[0].Cells["pais"].Value.ToString();
                txtObservacion.Text = dgvCatalogoClientes.SelectedRows[0].Cells["observacion"].Value.ToString();
            }
            catch(Exception ex)
            {

            }
            if (dgvCatalogoClientes.SelectedRows[0].Cells["Sexo"].Value.ToString() == "Masculino")
            {
                rbtnMasculino.Checked = true;
                rbtnMasculino.Enabled = false;
                rbtnFemenino.Enabled = false;


            }
            else if (dgvCatalogoClientes.SelectedRows[0].Cells["Sexo"].Value.ToString() == "Femenino")
            {
                rbtnFemenino.Checked = true;
                rbtnFemenino.Enabled = false;
                rbtnMasculino.Enabled = false;
            }
            if (dgvCatalogoClientes.SelectedRows[0].Cells["Estado Civil"].Value.ToString() == "Casado")
            {
                rbtnCasado.Checked = true;
            }
            else if (dgvCatalogoClientes.SelectedRows[0].Cells["Estado Civil"].Value.ToString() == "Soltero")
            {
                rbtnSoltero.Checked = true;
            }
            DateTime fechaNac = DateTime.Parse(dgvCatalogoClientes.SelectedRows[0].Cells["FechaNac"].Value.ToString());
            dtpFechaNac.Value = fechaNac;
            txtDireccion.Text = dgvCatalogoClientes.SelectedRows[0].Cells["Direccion"].Value.ToString();
            cmbDepartamento.Text = dgvCatalogoClientes.SelectedRows[0].Cells["Departamento"].Value.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string estadoCivil = "";
            string sexo = "";
            if (txtPrimerNombre.Text == "" ||  
                
                  
                mtxtCelular.Text == "" || txtPrimerApellido.Text == "" || 
                 mtxtCedula.Text == "")
            {
                MessageBox.Show("Aun hay campos de textos vacios", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrimerNombre.Focus();

                return;
            }
            else
            {
                

                if (cmbDepartamento.Text == "Sin Registro")
                {
                    MessageBox.Show("Seleccione un departamento", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string pais = "NICARAGUA";

                if(cmbPais.Text != "")
                {
                    pais = cmbPais.Text;
                }

                #region Validaciones Radiobuttons

                if (rbtnCasado.Checked == false && rbtnSoltero.Checked == false)
                    MessageBox.Show("Seleccione su estado civil", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (rbtnMasculino.Checked == false && rbtnFemenino.Checked == false)
                    MessageBox.Show("Seleccione su Sexo", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if(rbtnCasado.Checked == true)
                {
                    estadoCivil = rbtnCasado.Text;
                }
                else if(rbtnSoltero.Checked == true){
                    estadoCivil = rbtnSoltero.Text;
                }

                if (rbtnMasculino.Checked == true)
                {
                    sexo = rbtnMasculino.Text;
                }
                else if (rbtnFemenino.Checked == true)
                {
                    sexo = rbtnFemenino.Text;
                }
                #endregion
                if(sexo != "" && estadoCivil != "")
                {
                    cCliente.ActualizarCliente(int.Parse(lblId.Text), txtPrimerNombre.Text,
                        txtSegundoNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text, 1, txtDireccion.Text,
                        float.Parse(mtxtTelefono.Text), float.Parse(mtxtCelular.Text), mtxtEmail.Text, estadoCivil,
                        txtProfesion.Text, dtpFechaNac.Value.ToString(), sexo, mtxtCedula.Text,
                        this.cmbDepartamento.Text,pais,txtObservacion.Text);
                    
                }
                this.Close();
            }
        }
        
        
                
        
    }
}
