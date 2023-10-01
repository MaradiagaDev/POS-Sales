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
           
        }


            private void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (txtUser.Texts == "" && txtPassword.Texts == "")
            {
                MessageBox.Show("Campos vacios", "Alerta");

                return;
            }
            
            if (txtUser.Texts == "")
            {
               MessageBox.Show("Digite el usuario", "Alerta");
                return;
            }
                
            if (txtPassword.Texts == "")
            {
              MessageBox.Show("Digite la contraseña", "Alerta");
                return;
            }
                    
            Conexion con = new Conexion("123456","sa");

            Clases.Usuario usuario = new Clases.Usuario(con);

            if (con.connect.State == ConnectionState.Open)
            {
                using (NeoCobranzaContext db = new NeoCobranzaContext())
                {
                    ModelsCobranza.Usuario user = db.Usuario.Where(p => p.Pass.Trim() == txtPassword.Texts.Trim() &&  p.Nombre.Trim() == txtUser.Texts.Trim()).FirstOrDefault();
                 
                    //.Where(p => p.Pass == txtPassword.Texts).FirstOrDefault();

                    

                    if (user != null)
                    {

                        if (user.Estado == "Inhabilitado")
                        {
                            MessageBox.Show("Su usuario ha sido bloqueado. Pongase en contacto con el administrador.", "Alerta");
                            return;
                        }
                        AuditoriaModel.AgregarAuditoria(user.Nombre,"Inicio","Usuario","Acceso","Normal");

                        VariablesEntorno.idUsuarioSesion = user.IdUsuarios;
                        VariablesEntorno.RoleSesion = user.Rol;
                        VariablesEntorno.UserNameSesion = user.Nombre;

                        MessageBox.Show("Acceso realizado.", "Correcto");
                        this.Hide();
                        PnlPrincipal pnlPrincipal = new PnlPrincipal(txtUser.Texts, con);
                        AddOwnedForm(pnlPrincipal);
                        pnlPrincipal.Show();

                        //Limpia
                        txtPassword.clear();
                        txtUser.clear();
                    }
                    else
                    {
                        MessageBox.Show("Error en las credenciales", "Alerta");
                    }
                }
            }
            else
            {
             MessageBox.Show ("Error de servidor","Error");     
            }


                   

                   
            
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUser__TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(txtPassword.PasswordChar == true)
            {
                txtPassword.PasswordChar = false;
            }else if (txtPassword.PasswordChar == false)
            {
                txtPassword.PasswordChar = true;
            }
           
        }
    }
}

