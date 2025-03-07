using System;
using System.Data;
using System.Windows.Forms;
using NeoCobranza.PantallasInicio;
using NeoCobranza.ViewModels;

namespace NeoCobranza
{
    public partial class frmLogin : Form
    {
        private DataUtilities dataUtilities = new DataUtilities();

        public frmLogin()
        {
            InitializeComponent();
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

        private void Acceder()
        {
            try
            {
                //Validaciones
                if (string.IsNullOrWhiteSpace(TxtUser.Text) && string.IsNullOrWhiteSpace(TxtPass.Text))
                {
                    MessageBox.Show("Por favor, complete los campos de usuario y contraseña antes de continuar.",
                        "Validación de Entrada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(TxtUser.Text))
                {
                    MessageBox.Show("El campo de usuario está vacío. Por favor, ingrese un nombre de usuario válido.",
                        "Validación de Entrada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(TxtPass.Text))
                {
                    MessageBox.Show("El campo de contraseña está vacío. Por favor, ingrese su contraseña.",
                        "Validación de Entrada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                //Consulta a la base de datos

                dataUtilities.SetParameter("@UserName", TxtUser.Text.Trim());
                dataUtilities.SetParameter("@Password", TxtPass.Text.Trim());

                DataTable dtRespuesta = dataUtilities.ExecuteStoredProcedure("SP_LoginUser");

                string respuesta = dtRespuesta.Rows[0][0].ToString();

                if (respuesta != "Correcto")
                {
                    MessageBox.Show(respuesta,
                        "Validación de Entrada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
                Utilidades.IdUsuario = dtRespuesta.Rows[0][1].ToString();

                Utilidades.Usuario = TxtUser.Text.Trim();

                Utilidades.RolId =  dataUtilities.getRecordByPrimaryKey("Usuario",Utilidades.IdUsuario).Rows[0]["RolId"].ToString();
                Utilidades.Rol = dataUtilities.getRecordByPrimaryKey("Roles", Utilidades.RolId).Rows[0]["NombreRol"].ToString();

                this.Hide(); // Oculta la pantalla de login

                frmSeleccionSucursal frm = new frmSeleccionSucursal(Utilidades.IdUsuario);
                frm.ShowDialog(); // Muestra la pantalla de selección

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }

}

