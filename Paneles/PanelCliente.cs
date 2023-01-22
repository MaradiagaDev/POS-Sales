using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeoCobranza.Data;
using NeoCobranza.DataController;
namespace NeoCobranza.Paneles
{
    public partial class PanelCliente : Form
    {
        public Conexion conexion;
        public CGeneral cGeneral;
        public CCliente cCliente;
        public bool isnumber;
        public string panel;
        public PnlCatalogoClientes pnlCatalogoClientes;
        public PanelCliente(Conexion conexion,string panel)
        {
            InitializeComponent();
            this.conexion = conexion;
            cGeneral = new CGeneral(conexion);
            cCliente = new CCliente(conexion);
            
            this.panel = panel;
        }
        #region Actualizar Cliente desde el catalogo
        public PanelCliente(Conexion conexion,DataGridView dgvCatalogoClientes, string panel)
        {
            InitializeComponent();
            this.conexion = conexion;
            this.panel =  panel;
            cGeneral = new CGeneral(conexion);
            cCliente = new CCliente(conexion);
            cmbDepartamento.DataSource = cGeneral.MostrarDepartamentos();
            cmbDepartamento.ValueMember = "NombreDepartamento";
            
            if (panel == "Actualizar")
            {
                CargarCampos( dgvCatalogoClientes);
                MessageBox.Show("Debug");
            }
        }
        private void CargarCampos( DataGridView dgvCatalogoClientes)
        {
            mtxtTelefono.Text = dgvCatalogoClientes.SelectedRows[0].Cells["Telefono"].Value.ToString();
            mtxtCelular.Text = dgvCatalogoClientes.SelectedRows[0].Cells["Celular"].Value.ToString();
            mtxtEmail.Text = dgvCatalogoClientes.SelectedRows[0].Cells["Email"].Value.ToString();
            mtxtCedula.Text = dgvCatalogoClientes.SelectedRows[0].Cells["Cedula"].Value.ToString();
            if (dgvCatalogoClientes.SelectedRows[0].Cells["Sexo"].Value.ToString() == "Masculino")
            {
                rbtnMasculino.Checked = true;
                rbtnMasculino.Enabled = false;
                rbtnFemenino.Enabled = false;


            }
            else if(dgvCatalogoClientes.SelectedRows[0].Cells["Sexo"].Value.ToString() == "Femenino")
            {
                rbtnFemenino.Checked = true;
                rbtnFemenino.Enabled = false;
                rbtnMasculino.Enabled = false;
            }
            if(dgvCatalogoClientes.SelectedRows[0].Cells["Estado Civil"].Value.ToString() == "Casado")
            {
                rbtnCasado.Checked = true;
            }else if (dgvCatalogoClientes.SelectedRows[0].Cells["Estado Civil"].Value.ToString() == "Soltero")
            {
                rbtnSoltero.Checked = true;
            }
            DateTime fechaNac = DateTime.Parse(dgvCatalogoClientes.SelectedRows[0].Cells["FechaNac"].Value.ToString());
            lblFecha.Value = fechaNac;
            txtDireccion.Texts = dgvCatalogoClientes.SelectedRows[0].Cells["Direccion"].Value.ToString();
            cmbDepartamento.Text = dgvCatalogoClientes.SelectedRows[0].Cells["NombreDepartamento"].Value.ToString();
        }
        #endregion
        private void PanelCliente_Load(object sender, EventArgs e)
        {
        


        }

        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            this.Hide();
            bool abierto = true;
            

        }
        

        private void especialButton1_Click(object sender, EventArgs e)
        {
            PnlInsertarAgencia pnlAgen = new PnlInsertarAgencia();

            pnlAgen.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
             




            if (lblPn.Texts == "" || lblPA.Texts == ""|| mtxtCedula.Text == "")
            {
                MessageBox.Show("Aun hay campos de textos vacios", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lblPn.Focus();
                
                return;
            }
          
            else
            {
                int pase;
                

               

                if(rbtnCasado.Checked && rbtnMasculino.Checked)
                {
                    EjecutarCasadoMasculino();
                   
                }
                
            
                if(rbtnCasado.Checked && rbtnFemenino.Checked)
                {
                        EjecutarCasadoFemenino();
                   

                }

                if(rbtnSoltero.Checked && rbtnMasculino.Checked)
                {
                    EjecutarSolteroMasculino();
                   
                }

                if(rbtnSoltero.Checked && rbtnFemenino.Checked)
                {
                    EjecutarSolteroFemenino();
                   


                }
                if(rbtnCasado.Checked ==false &&rbtnSoltero.Checked ==false)
                    MessageBox.Show("Seleccione su estado civil", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (rbtnMasculino.Checked == false && rbtnFemenino.Checked == false)
                    MessageBox.Show("Seleccione su Sexo", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
             
             
            

        }
        #region Validaciones RadioButtons
        private void EjecutarCasadoMasculino()
        {
            string pais = "NICARAGUA";
            if (cmbPais.Text != "")
            {
                pais = cmbPais.Text;
            }
            PnlCatalogoClientes pnlCatalogo = Owner as PnlCatalogoClientes;


            if (mtxtTelefono.Text == "")
            {

                cCliente.AgregarCliente(lblPn.Texts, lblSN.Texts, lblPA.Texts, lblSA.Texts, 1, txtDireccion.Texts, 1, float.Parse(mtxtCelular.Texts), mtxtEmail.Text, "Casado", lblProfesion.Texts, lblFecha.Text, "Masculino", mtxtCedula.Text, this.cmbDepartamento.Text,pais,txtObservacion.Texts);

            }
            else
            {
                cCliente.AgregarCliente(lblPn.Texts, lblSN.Texts, lblPA.Texts, lblSA.Texts, 1, txtDireccion.Texts, float.Parse(mtxtTelefono.Text), float.Parse(mtxtCelular.Texts), mtxtEmail.Text, "Casado", lblProfesion.Texts, lblFecha.Text, "Masculino", mtxtCedula.Text, this.cmbDepartamento.Text, pais, txtObservacion.Texts);

            }





            limpiar();
            this.Hide();

        }
        private void EjecutarCasadoFemenino()
        {
            string pais = "NICARAGUA";
            if (cmbPais.Text != "")
            {
                pais = cmbPais.Text;
            }

            if (mtxtTelefono.Text == "")
            {
                cCliente.AgregarCliente(lblPn.Texts, lblSN.Texts, lblPA.Texts, lblSA.Texts, 1, txtDireccion.Texts, 1, float.Parse(mtxtCelular.Texts), mtxtEmail.Text, "Casado", lblProfesion.Texts, lblFecha.Text, "Femenino", mtxtCedula.Text, this.cmbDepartamento.Text, pais, txtObservacion.Texts);
            }
            else
            {
                cCliente.AgregarCliente(lblPn.Texts, lblSN.Texts, lblPA.Texts, lblSA.Texts, 1, txtDireccion.Texts, float.Parse(mtxtTelefono.Text), float.Parse(mtxtCelular.Texts), mtxtEmail.Text, "Casado", lblProfesion.Texts, lblFecha.Text, "Femenino", mtxtCedula.Text, this.cmbDepartamento.Text, pais, txtObservacion.Texts);

            }

            


            limpiar();
            this.Hide();

        }
        private void EjecutarSolteroMasculino()
        {
            string pais = "NICARAGUA";
           if(cmbPais.Text != "")
            {
                pais = cmbPais.Text;
            }

            PnlContrato pnlContrato = Owner as PnlContrato;

            if (mtxtTelefono.Text == "")
            {

                cCliente.AgregarCliente(lblPn.Texts, lblSN.Texts, lblPA.Texts, lblSA.Texts, 1, txtDireccion.Texts, 1, float.Parse(mtxtCelular.Texts), mtxtEmail.Text, "Soltero", lblProfesion.Texts, lblFecha.Text, "Masculino", mtxtCedula.Text, this.cmbDepartamento.Text, pais, txtObservacion.Texts);

            }
            else
            {
                cCliente.AgregarCliente(lblPn.Texts, lblSN.Texts, lblPA.Texts, lblSA.Texts, 1, txtDireccion.Texts, float.Parse(mtxtTelefono.Text), float.Parse(mtxtCelular.Texts), mtxtEmail.Text, "Soltero", lblProfesion.Texts, lblFecha.Text, "Masculino", mtxtCedula.Text, this.cmbDepartamento.Text, pais, txtObservacion.Texts);

            }

            limpiar();
            this.Hide();

        }
        private void EjecutarSolteroFemenino()
        {

            string pais = "NICARAGUA";
            if (cmbPais.Text != "")
            {
                pais = cmbPais.Text;
            }

            if (mtxtTelefono.Text == "")
            {

                cCliente.AgregarCliente(lblPn.Texts, lblSN.Texts, lblPA.Texts, lblSA.Texts, 1, txtDireccion.Texts, 1, float.Parse(mtxtCelular.Texts), mtxtEmail.Text, "Soltero", lblProfesion.Texts, lblFecha.Text, "Femenino", mtxtCedula.Text, this.cmbDepartamento.Text, pais, txtObservacion.Texts);
            }
            else
            {
                cCliente.AgregarCliente(lblPn.Texts, lblSN.Texts, lblPA.Texts, lblSA.Texts, 1, txtDireccion.Texts, float.Parse(mtxtTelefono.Text), float.Parse(mtxtCelular.Texts), mtxtEmail.Text, "Soltero", lblProfesion.Texts, lblFecha.Text, "Femenino", mtxtCedula.Text,this.cmbDepartamento.Text, pais, txtObservacion.Texts);


            }




            limpiar();
            this.Hide();

        }
        #endregion

        private void limpiar()
        {
            lblPn.clear();
            lblSN.clear();
            lblPA.clear();
            lblSA.clear();
            mtxtCedula.Clear();
            lblProfesion.clear();
            cmbDepartamento.Text="";
            mtxtEmail.Clear();
            mtxtCelular.clear();
            mtxtTelefono.Clear();
            txtDireccion.clear();
            
            

        }

        private void lblNumeroCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar>=32 && e.KeyChar<=47)|| (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros","Alerta",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void lblNumeroTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lblPn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #region GETS and Sets
        /* public NeoCobranza.Controladores.LoginUserControl TxtPrimerNombre
         {
             get { return lblPn; }
             set { lblPn.Texts = value; }
         }*/
        #endregion
    }
}
