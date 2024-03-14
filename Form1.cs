using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeoCobranza.Clases;
using NeoCobranza.ControlActualizaciones;
using NeoCobranza.Data;
using NeoCobranza.ModelObjectCobranza;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles;
using NeoCobranza.ViewModels;

namespace NeoCobranza
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Habilita el KeyPreview para que el formulario maneje los eventos de teclado
            this.KeyPreview = true;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            Acceder();
        }

        private void ChkMostrarContra_CheckedChanged(object sender, EventArgs e)
        {
            TxtPass.PasswordChar = ChkMostrarContra.Checked ? '\0' : '●';
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Acceder()
        {
            if (TxtPass.Text == "" && TxtPass.Text == "")
            {
                MessageBox.Show("Campos vacios", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (TxtPass.Text == "")
            {
                MessageBox.Show("Digite el usuario", "Atención",
                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TxtPass.Text == "")
            {
                MessageBox.Show("Digite la contraseña", "Atención",
                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Conexion con = new Conexion("123456", "sa");

            Clases.Usuario usuario = new Clases.Usuario(con);

            if (con.connect.State == ConnectionState.Open)
            {
                using (NeoCobranzaContext db = new NeoCobranzaContext())
                {
                    ModelsCobranza.Usuario user = db.Usuario.Where(p => p.Pass.Trim() == TxtPass.Text.Trim() && p.Nombre.Trim() == TxtUser.Text.Trim()).FirstOrDefault();
                    if (user != null)
                    {
                        Utilidades.RolUsuario = user.Rol;
                        Utilidades.IdUsuario = user.IdUsuarios.ToString();
                        Utilidades.SucursalId = user.SucursalId.ToString();

                        if (user.Estado == "Inhabilitado")
                        {
                            MessageBox.Show("Su usuario ha sido bloqueado. Pongase en contacto con el administrador.", "Alerta");
                            return;
                        }
                        AuditoriaModel.AgregarAuditoria(user.Nombre, "Inicio", "Usuario", "Acceso", "Normal");

                        VariablesEntorno.idUsuarioSesion = user.IdUsuarios;
                        VariablesEntorno.RoleSesion = user.Rol;
                        VariablesEntorno.UserNameSesion = user.Nombre;

                        MessageBox.Show("Acceso realizado.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        PnlPrincipal pnlPrincipal = new PnlPrincipal(TxtUser.Text, con);
                        AddOwnedForm(pnlPrincipal);
                        pnlPrincipal.Show();

                        //Limpia
                        TxtPass.Text = "";
                        TxtPass.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Error en las credenciales", "Alerta");
                    }
                }
            }
            else
            {
                MessageBox.Show("Error de servidor", "Error");
            }
        }

        private void TxtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Acceder();
            }
        }

        private void TxtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Acceder();
            }
        }

        private void ChkMostrarContra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Acceder();
            }
        }

        private void LblVersion_Click(object sender, EventArgs e)
        {

        }
    }
}

