using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeoCobranza.Clases;
using NeoCobranza.Data;
using NeoCobranza.Paneles;

namespace NeoCobranza
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            
        }
        private int cont=3;
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
            else
            {
                if (txtUser.Texts == "")
                {
                    MessageBox.Show("Digite el usuario", "Alerta");
                }
                else
                {
                    if (txtPassword.Texts == "")
                    {
                        MessageBox.Show("Digite la contraseña", "Alerta");
                    }
                    else
                    {
                        //
                        Conexion con = new Conexion(txtPassword.Texts,txtUser.Texts);

                        Usuario usuario = new Usuario(con);

                        if (con.connect.State == ConnectionState.Open)
                        {
                            
                            MessageBox.Show("Acceso al sistema", "Bienvenido");
                            
                            this.Hide();
                            PnlPrincipal pnlPrincipal = new PnlPrincipal(txtUser.Texts,con);
                            AddOwnedForm(pnlPrincipal);
                            pnlPrincipal.Show();
                            txtPassword.clear();
                            txtUser.clear();
                            
                           
                        }
                        else
                        {
                            --cont;
                            MessageBox.Show ("Error de usuario o contraseña", Convert.ToString(cont)+" Intentos restantes");
                            if (cont == 0)
                            {
                                btnLogin.Enabled = false;
                                Thread.Sleep(3000);
                                MessageBox.Show("Limite");
                                cont = 3;
                            }
                        }


                        //
                    }

                 }  
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

