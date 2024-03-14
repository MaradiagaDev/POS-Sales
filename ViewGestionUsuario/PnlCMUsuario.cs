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
using System.Windows.Forms.VisualStyles;

namespace NeoCobranza.ViewGestionUsuario
{
    public partial class PnlCMUsuario : Form
    {
        private UserModel userStatic = new UserModel();
        private RolModel rolStatic = new RolModel();
        private string accion;
        private Usuario usuario;
        public PnlCMUsuario(string accion)
        {
            InitializeComponent();
            this.CmbRol.DisplayMember = "Rol";
            this.CmbRol.ValueMember = "RolId";
            this.CmbRol.DataSource = this.rolStatic.GetAll();
            this.accion = accion;

            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                var sucursales = db.Sucursales.Where(s => s.Estado == "Activo").ToList();
                this.CmbSucursal.DisplayMember = "NombreSucursal";
                this.CmbSucursal.ValueMember = "SucursalId";
                this.CmbSucursal.DataSource = sucursales;
            }
        }

        private void PnlCMUsuario_Load(object sender, EventArgs e)
        {

        }

        private void CHKMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if(TxtContraseña.PasswordChar == true)
            {
                TxtContraseña.PasswordChar = false;
                TxtContraseñaConfirmar.PasswordChar = false;
            }
            else
            {
                TxtContraseña.PasswordChar = true;
                TxtContraseñaConfirmar.PasswordChar = true;
            }
        }

        private void BtnCrearUsuario_Click(object sender, EventArgs e)
        {
            //Validar que el nombre de usuario no este ocupado
            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                  List<Usuario> list = db.Usuario.ToList();

                if(list.Count != 0)
                {
                    foreach(Usuario usu in list)
                    {
                        if(usu.Nombre.Trim() == TxtUsuario.Texts.Trim())
                        {
                            MessageBox.Show($"El nombre de usuario ya fue ocupado. Por favor, seleccionar otro.", "Atención",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Warning);
                            return;
                        }
                    }
                } 
            }

            //Validaciones
            if(CmbSucursal.Items.Count == 0)
            {
                MessageBox.Show($"No hay sucursales agregadas en el catalogo.", "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if(TxtUsuario.Texts == "")
            {
                MessageBox.Show($"Debe digitar un nombre de usuario.", "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    return;
            }else if(TxtNombre.Texts == "")
            {
                MessageBox.Show($"Debe digitar su primer nombre.", "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }else if(TxtApellido.Texts == "")
            {
                MessageBox.Show($"Debe digitar su primer apellido.", "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    return;
            }
            else if(TxtContraseña.Texts == "")
            {
                MessageBox.Show($"Debe digitar una contraseña.", "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    return;
            }
            else if(TxtContraseñaConfirmar.Texts == "")
            {
                MessageBox.Show($"Debe validar su contraseña.", "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            else if (TxtContraseña.Texts != TxtContraseñaConfirmar.Texts)
            {
                MessageBox.Show($"Las contraseñas no son iguales", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            else if(CmbRol.Text == "")
            {
                MessageBox.Show($"Debe seleccionar un rol para el usuario.", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Usuario usuario = new Usuario
            {
                Nombre = TxtUsuario.Texts,
                PrimerNombre = TxtNombre.Texts,
                PrimerApellido = TxtApellido.Texts,
                Rol = CmbRol.SelectedValue.ToString(),
                Pass = TxtContraseña.Texts,
                Estado = "Habilitado",
                SucursalId = int.Parse(CmbSucursal.SelectedValue.ToString())

            };
            AuditoriaModel.AgregarAuditoria(VariablesEntorno.UserNameSesion, "Seguridad", "Crear Usuario", "Todos", "Alto");
            this.userStatic.PostUser(usuario);

            this.Close();
        }
    }
}
