using NeoCobranza.ModelObjectCobranza;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.ViewModels;
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
        DataUtilities dataUtilities = new DataUtilities();
        string accion, usuarioId = "";


        public PnlCMUsuario()
        {
            InitializeComponent();
            this.CmbRol.DisplayMember = "NombreRol";
            this.CmbRol.ValueMember = "IdRol";
            this.CmbRol.DataSource = dataUtilities.GetAllRecords("Roles");

            this.CmbSucursales.DisplayMember = "NombreSucursal";
            this.CmbSucursales.ValueMember = "IdSucursal";
            this.CmbSucursales.DataSource = dataUtilities.GetAllRecords("vwSucursales");
        }

        private void PnlCMUsuario_Load(object sender, EventArgs e)
        {
            DtSucursales.Columns.Add("ID");
            DtSucursales.Columns.Add("Sucursal");

            DgvSucursales.DataSource = DtSucursales;
            DgvSucursales.Columns[0].Visible = false;

            UIUtilities.PersonalizarDataGridViewPequeños(DgvSucursales);
        }

        private void CHKMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (TxtContraseña.PasswordChar == true)
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
            if(TxtUsuario.Texts.Trim() == string.Empty || TxtNombre.Texts.Trim() == string.Empty
                ||TxtApellido.Texts.Trim() == string.Empty || DtSucursales.Rows.Count == 0 || TxtUsuario.Texts == string.Empty)
            {
                MessageBox.Show("Faltan datos obligatorios por llenar","Atención",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            if(dataUtilities.getRecordByColumn("Usuario","Usuario", TxtUsuario.Texts.Trim()).Rows.Count > 0)
            {
                MessageBox.Show("El usuario ya existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if((TxtContraseña.Texts == TxtContraseñaConfirmar.Texts) || TxtContraseña.Texts.Trim().Length > 0)
            {
                MessageBox.Show("No ha digitado la contraseña o no son iguales.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Agregar usuario
            dataUtilities.SetParameter("@IdEmpleado",Guid.NewGuid().ToString());
            dataUtilities.SetParameter("@Nombre",TxtNombre.Texts);
            dataUtilities.SetParameter("@Apellido",TxtApellido.Texts);
            dataUtilities.SetParameter("@Direccion",TxtDireccion.Texts);
            dataUtilities.SetParameter("@Telefono",TxtCelular.Texts);
            dataUtilities.SetParameter("@CorreoElectronico",TxtCorreo.Texts);
            dataUtilities.SetParameter("@FechaContratacion",DtFechaContratacion.Value);
            dataUtilities.SetParameter("@Cargo",TxtCargo.Texts);
            dataUtilities.SetParameter("@EstadoEmpleado","Activo");
            dataUtilities.SetParameter("@Identificacion",TxtIdentificacion.Texts);
            dataUtilities.SetParameter("@IdUsuario", Guid.NewGuid().ToString());
            dataUtilities.SetParameter("@Usuario",TxtUsuario.Texts);
            dataUtilities.SetParameter("@ClaveUsuario",TxtContraseña.Texts);
            dataUtilities.SetParameter("@EstadoUsuario", "Activo");
            dataUtilities.SetParameter("@RolId",CmbRol.SelectedValue);

            dataUtilities.ExecuteStoredProcedure("SP_AgregarEmpleadoYUsuario");

            this.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        DataTable DtSucursales = new DataTable();

        private void BtnAgregarSucursal_Click(object sender, EventArgs e)
        {
            foreach (DataRow item in DtSucursales.Rows)
            {
                if (item[0].ToString() == CmbSucursales.SelectedValue.ToString())
                {
                    MessageBox.Show("La sucursal ya ha sido agregada.","Atención",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
            }

            DtSucursales.Rows.Add(CmbSucursales.SelectedValue.ToString(),CmbSucursales.Text);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(DgvSucursales.SelectedRows.Count > 0)
            {
                DtSucursales.Rows.RemoveAt(DgvSucursales.SelectedRows[0].Index);
            }
        }

        private void loginUserControl2__TextChanged(object sender, EventArgs e)
        {

        }
    }
}
