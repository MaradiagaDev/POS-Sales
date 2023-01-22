using NeoCobranza.Data;
using NeoCobranza.DataController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles_Auditorias
{
    public partial class CreacionUsuario : Form
    {
        public CCrearUsuario cCrearUsuario;
        public Conexion conexion;
        public CreacionUsuario(Conexion conexion)
        {
            InitializeComponent();
            this.conexion = conexion;   
            cCrearUsuario = new CCrearUsuario(conexion);    
        }

        

        private void BtnCrearUsuario_Click(object sender, EventArgs e)
        {
            if (txtContra.Texts == "" || txtUsuario.Texts == "")
            {
                MessageBox.Show("No pueden existir campos vacios", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpiar();
                return;
            }
            if (txtConfirmar.Texts != txtContra.Texts)
            {
                MessageBox.Show("las contraseñas no son iguales", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            cCrearUsuario.CrearLogin(txtUsuario.Texts,txtContra.Texts,cmbRol.Text);
            limpiar();
        }
        private void limpiar()
        {
            txtConfirmar.clear();
            txtContra.clear();
            txtUsuario.clear();
        }
    }
}
