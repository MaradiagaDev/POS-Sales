using NeoCobranza.Data;
using NeoCobranza.DataController;
using NeoCobranza.ModelObjectCobranza;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.ViewGestionUsuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace NeoCobranza.Paneles_Auditorias
{
    public partial class CreacionUsuario : Form
    {
        private UserModel userStatic = new UserModel();
        private RolModel rolStatic = new RolModel();
        private bool apertura;
        
        public CreacionUsuario(Conexion conexion)
        {
            InitializeComponent();
              
        }

        private void CreacionUsuario_Load(object sender, EventArgs e)
        {
            AuditoriaModel.AgregarAuditoria(VariablesEntorno.UserNameSesion, "Seguridad", "Gestion Usuario", "Acceso Gestion User", "Normal");
            LlenarDataUser();
        }

        //LLenar Data
        private void LlenarDataUser()
        {
            foreach(Usuario user in this.userStatic.GetAll()){
                DGVUser.Rows.Add(user.IdUsuarios, user.Nombre,user.PrimerNombre, user.PrimerApellido,this.rolStatic.GetById(int.Parse(user.Rol)),user.Estado);
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            DGVUser.Rows.Clear();
            if(CmbFiltro.Text == "ID")
            {
                foreach (Usuario user in this.userStatic.GetById(txtFiltroUsuario.Texts))
                {
                    DGVUser.Rows.Add(user.IdUsuarios, user.Nombre, user.PrimerNombre, user.PrimerApellido, this.rolStatic.GetById(int.Parse(user.Rol)), user.Estado);
                }
            }else if(CmbFiltro.Text == "USER" || CmbFiltro.Text == "" )
            {
                foreach (Usuario user in this.userStatic.GetByUser(txtFiltroUsuario.Texts))
                {
                    DGVUser.Rows.Add(user.IdUsuarios, user.Nombre, user.PrimerNombre, user.PrimerApellido, this.rolStatic.GetById(int.Parse(user.Rol)), user.Estado);
                }
            }
            else if (CmbFiltro.Text == "NOMBRE")
            {
                foreach (Usuario user in this.userStatic.GetByPNombre(txtFiltroUsuario.Texts))
                {
                    DGVUser.Rows.Add(user.IdUsuarios, user.Nombre, user.PrimerNombre, user.PrimerApellido, this.rolStatic.GetById(int.Parse(user.Rol)), user.Estado);
                }
            }
            else if (CmbFiltro.Text == "APELLIDO")
            {
                foreach (Usuario user in this.userStatic.GetByPApellido(txtFiltroUsuario.Texts))
                {
                    DGVUser.Rows.Add(user.IdUsuarios, user.Nombre, user.PrimerNombre, user.PrimerApellido, this.rolStatic.GetById(int.Parse(user.Rol)), user.Estado);
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DGVUser.Rows.Clear();
            txtFiltroUsuario.clear();
            LlenarDataUser();
        }

        private void BtnCambiarEstado_Click(object sender, EventArgs e)
        {
            if(DGVUser.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado a ningun usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AuditoriaModel.AgregarAuditoria(VariablesEntorno.UserNameSesion, "Seguridad", "Inhabilitar Usuario", "Estado", "Medio");

            this.userStatic.PutEstado(int.Parse(DGVUser.SelectedRows[0].Cells[0].Value.ToString()));

            DGVUser.Rows.Clear();
            txtFiltroUsuario.clear();
            LlenarDataUser();

        }

        private void BtnCrearUsuario_Click(object sender, EventArgs e)
        {
            
            PnlCMUsuario pnl = new PnlCMUsuario("Crear");
            pnl.Show();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (DGVUser.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado a ningun usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Usuario usuario;
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                usuario = db.Usuario.Where(p => p.IdUsuarios.ToString() == DGVUser.SelectedRows[0].Cells[0].Value.ToString()).FirstOrDefault();
            }
            PnlActUsuario pnl = new PnlActUsuario(usuario);
            pnl.Show();
        }
    }
}
