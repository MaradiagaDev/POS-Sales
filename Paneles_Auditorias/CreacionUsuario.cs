using NeoCobranza.Data;
using NeoCobranza.DataController;
using NeoCobranza.ModelObjectCobranza;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.ViewGestionUsuario;
using NeoCobranza.ViewModels;
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
        DataUtilities dataUtilities = new DataUtilities();
        
        public CreacionUsuario()
        {
            InitializeComponent();
        }

        private void CreacionUsuario_Load(object sender, EventArgs e)
        {
            LlenarDataUser();
            UIUtilities.PersonalizarDataGridViewPequeños(DGVUser);
        }

        //LLenar Data
        private void LlenarDataUser()
        {
            if(CmbFiltro.SelectedIndex == 0)
            {
                dataUtilities.SetParameter("@IdUsuario", txtFiltroUsuario.Texts);
            }
            else if (CmbFiltro.SelectedIndex == 1)
            {
                dataUtilities.SetParameter("@Usuario", txtFiltroUsuario.Texts);
            }
            else if (CmbFiltro.SelectedIndex == 2)
            {
                dataUtilities.SetParameter("@NombreEmpleado", txtFiltroUsuario.Texts);
            }
            DGVUser.DataSource = dataUtilities.ExecuteStoredProcedure("sp_FiltrarUsuarios");

            DGVUser.Columns[0].Visible = false;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            LlenarDataUser();
        }

        private void BtnCambiarEstado_Click(object sender, EventArgs e)
        {
            if(DGVUser.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado a ningun usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DGVUser.SelectedRows[0].Cells[7].Value.ToString() == "Activo") 
            {
                dataUtilities.SetColumns("Estado", "Bloqueado");
                dataUtilities.UpdateRecordByPrimaryKey("Usuario", DGVUser.SelectedRows[0].Cells[0].Value);
            }
            else
            {
                dataUtilities.SetColumns("Estado", "Activo");
                dataUtilities.UpdateRecordByPrimaryKey("Usuario", DGVUser.SelectedRows[0].Cells[0].Value);
            }

            LlenarDataUser();
        }

        private void BtnCrearUsuario_Click(object sender, EventArgs e)
        {
            PnlCMUsuario pnl = new PnlCMUsuario();
            pnl.Show();

            LlenarDataUser();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (DGVUser.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado a ningun usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PnlActUsuario pnl = new PnlActUsuario(DGVUser.SelectedRows[0].Cells[0].Value.ToString());
            pnl.ShowDialog();
        }

        private void CmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDataUser();
        }
    }
}
