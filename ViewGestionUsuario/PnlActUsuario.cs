using NeoCobranza.ModelObjectCobranza;
using NeoCobranza.ModelsCobranza;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.ViewGestionUsuario
{
    public partial class PnlActUsuario : Form
    {
        private RolModel rolStatic = new RolModel();
        private Usuario usuario = new Usuario();
        public PnlActUsuario(Usuario usuario)
        {
            InitializeComponent();

            this.CmbRol.DisplayMember = "Rol";
            this.CmbRol.ValueMember = "RolId";
            this.CmbRol.DataSource = this.rolStatic.GetAll();
            this.usuario = usuario;

            txtUsuario.Text = usuario.Nombre;
            txtNombre.Text = usuario.PrimerNombre;
            txtApellido.Text = usuario.PrimerApellido;
            CmbRol.SelectedItem = usuario.Rol;
            txtPass.Text = usuario.Pass;
            txtPassConfirmar.Text = usuario.Pass;
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CHKMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar.ToString() == "*")
            {
                txtPass.PasswordChar = '\0';
                txtPassConfirmar.PasswordChar = '\0';
            }
            else
            {
                txtPass.PasswordChar = '*';
                txtPassConfirmar.PasswordChar = '*';
            }
        }

        private void BtnUsuario_Click(object sender, EventArgs e)
        {
            //Validar que el nombre de usuario no este ocupado
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                List<Usuario> list = db.Usuario.ToList();

                if (list.Count != 0)
                {
                    foreach (Usuario usu in list)
                    {
                        if (usu.Nombre.Trim() == txtUsuario.Text.Trim() && txtUsuario.Text.Trim() != this.usuario.Nombre.Trim())
                        {
                            MessageBox.Show($"El nombre de usuario ya fue ocupado. Por favor, seleccionar otro.", "Error",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }

            if (txtUsuario.Text == "")
            {
                MessageBox.Show($"Debe digitar un nombre de usuario.", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            else if (txtNombre.Text == "")
            {
                MessageBox.Show($"Debe digitar su primer nombre.", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else if (txtApellido.Text == "")
            {
                MessageBox.Show($"Debe digitar su primer apellido.", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            else if (txtPass.Text == "")
            {
                MessageBox.Show($"Debe digitar una contraseña.", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            else if (txtPassConfirmar.Text == "")
            {
                MessageBox.Show($"Debe validar su contraseña.", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            else if (txtPass.Text != txtPassConfirmar.Text)
            {
                MessageBox.Show($"Las contraseñas no son iguales", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            else if (CmbRol.Text == "")
            {
                MessageBox.Show($"Debe seleccionar un rol para el usuario.", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            UserModel us =  new UserModel();

            Usuario usuarioNuevo = new Usuario
            {
                IdUsuarios = this.usuario.IdUsuarios,
                Nombre =txtUsuario.Text,
                PrimerNombre =txtNombre.Text,
                PrimerApellido = txtApellido.Text,
                Pass =txtPass.Text,
                Estado = "Habilitado",
                Rol = CmbRol.SelectedValue.ToString()
            };


            AuditoriaModel.AgregarAuditoria(VariablesEntorno.UserNameSesion, "Seguridad", "Actualizar Usuario", "Todos", "Muy Alto");


            us.putUsuario(usuarioNuevo);
            this.Close();
        }

        private void PnlActUsuario_Load(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtPassConfirmar_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
    
}
