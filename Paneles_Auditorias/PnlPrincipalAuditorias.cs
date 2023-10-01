using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using NeoCobranza.Clases;
using NeoCobranza.Data;
using NeoCobranza.DataController;
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

namespace NeoCobranza.Paneles_Auditorias
{
    
    public partial class PnlPrincipalAuditorias : Form
    {
        public CAuditoria cAuditoria;
        public Conexion conexion;
        public Auditorias auditorias;
        public PnlPrincipalAuditorias(Conexion conexion)
        {
            InitializeComponent();
 
        }

        private void PnlPrincipalAuditorias_Load(object sender, EventArgs e)
        {
            //Auditoria
            AuditoriaModel.AgregarAuditoria(VariablesEntorno.UserNameSesion, "Seguridad", "Todos", "Acceso Auditoria", "Normal");

            //Llenado de los usuarios
            using (NeoCobranzaContext db = new NeoCobranzaContext()) 
            {
                List<ModelsCobranza.Usuario> ListaUsuarios = db.Usuario.ToList();
                CmbUsuarios.DisplayMember = "Nombre";
                CmbUsuarios.ValueMember = "Nombre";
                CmbUsuarios.DataSource = ListaUsuarios;
            }
            //Mostrado de todos
            MostrarRegistros();
        }
        private void MostrarRegistros()
        {
           DGVAuditoria.DataSource = AuditoriaModel.GetAll();
        }

        private void BtnTodos_Click(object sender, EventArgs e)
        {
            MostrarRegistros();
        }

        private void BtnBuscarUser_Click(object sender, EventArgs e)
        {
            DGVAuditoria.DataSource = AuditoriaModel.GetFAll(DtInicio.Text,DtFinal.Text, CmbSector.Text,CmbUsuarios.Text,txtFiltroUsuario.Texts);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            MostrarRegistros();
        }
    }
}
