using NeoCobranza.Clases;
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

namespace NeoCobranza.ViewGestionUsuario
{
    public partial class PnlActUsuario : Form
    {
        DataTable DtSucursales = new DataTable();
        DataUtilities dataUtilities = new DataUtilities();
        string auxUsuarioId = "";
        public PnlActUsuario(string usuarioId)
        {
            InitializeComponent();

            try
            {
                auxUsuarioId = usuarioId;

                DtSucursales.Columns.Add("ID");
                DtSucursales.Columns.Add("Sucursal");

                DgvSucursales.DataSource = DtSucursales;
                DgvSucursales.Columns[0].Visible = false;

                UIUtilities.PersonalizarDataGridViewPequeños(DgvSucursales);

                //Llenado de data normal
                this.CmbRol.DisplayMember = "NombreRol";
                this.CmbRol.ValueMember = "IdRol";
                this.CmbRol.DataSource = dataUtilities.GetAllRecords("Roles"); this.CmbRol.DisplayMember = "NombreRol";
                this.CmbRol.ValueMember = "IdRol";
                this.CmbRol.DataSource = dataUtilities.GetAllRecords("Roles");

                this.CmbSucursales.DisplayMember = "NombreSucursal";
                this.CmbSucursales.ValueMember = "IdSucursal";
                this.CmbSucursales.DataSource = dataUtilities.GetAllRecords("vwSucursales");

                //Llenado de data usuario

                DataTable responseUsuario = dataUtilities.getRecordByPrimaryKey("Usuario", usuarioId);

                txtUsuario.Text = Convert.ToString(responseUsuario.Rows[0]["Usuario"]);

                //Llenado de empleado

                DataTable responseEmpleado = dataUtilities.getRecordByPrimaryKey("Empleado", Convert.ToString(responseUsuario.Rows[0]["IdEmpleado"]));

                txtNombre.Text = Convert.ToString(responseEmpleado.Rows[0]["Nombre"]);
                txtApellido.Text = Convert.ToString(responseEmpleado.Rows[0]["Apellido"]);
                CmbRol.SelectedItem = Convert.ToString(responseUsuario.Rows[0]["RolId"]);
                TxtCorreo.Text = Convert.ToString(responseEmpleado.Rows[0]["CorreoElectronico"]);
                TxtCargo.Text = Convert.ToString(responseEmpleado.Rows[0]["Cargo"]);
                TxtCelular.Text = Convert.ToString(responseEmpleado.Rows[0]["Telefono"]);
                TxtIdentificacion.Text = Convert.ToString(responseEmpleado.Rows[0]["Identificación"]);
                TxtDireccion.Text = Convert.ToString(responseEmpleado.Rows[0]["Direccion"]);

                //Obtener la data de sucursales

                DataTable responseSucursal = dataUtilities.getRecordByColumn("UsuarioSucursal", "IdUsuario", usuarioId);

                foreach (DataRow item in responseSucursal.Rows)
                {
                    DataTable dtResponseSucursal = dataUtilities.getRecordByPrimaryKey("Sucursal", item["IdSucursal"]);

                    DtSucursales.Rows.Add(Convert.ToString(dtResponseSucursal.Rows[0]["IdSucursal"]),
                        Convert.ToString(dtResponseSucursal.Rows[0]["NombreSucursal"]));
                }

                DgvSucursales.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CHKMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar.ToString() == "*")
            {
                txtPass.PasswordChar = '\0';
                txtPassConfirmar.PasswordChar = '\0';
            }
            else
            {
                txtPass.PasswordChar = '*';
                txtPassConfirmar.PasswordChar = '*';
            }
        }

        private void BtnUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                //Validaciones
                if (txtUsuario.Text.Trim() == string.Empty || txtNombre.Text.Trim() == string.Empty
                    || txtApellido.Text.Trim() == string.Empty || DtSucursales.Rows.Count == 0 || TxtCargo.Text == string.Empty)
                {
                    MessageBox.Show("Faltan datos obligatorios por llenar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if ((txtPass.Text != txtPassConfirmar.Text) || txtPass.Text.Trim().Length == 0)
                {
                    MessageBox.Show("No ha digitado la contraseña o no son iguales.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //agregar usuario
                dataUtilities.SetParameter("@IdUsuario", auxUsuarioId);
                dataUtilities.SetParameter("@Usuario", txtUsuario.Text);
                dataUtilities.SetParameter("@ClaveUsuario", txtPass.Text);
                dataUtilities.SetParameter("@EstadoUsuario", "Activo");
                dataUtilities.SetParameter("@RolId", CmbRol.SelectedValue);
                dataUtilities.SetParameter("@Nombre", txtNombre.Text);
                dataUtilities.SetParameter("@Apellido", txtApellido.Text);
                dataUtilities.SetParameter("@Direccion", TxtDireccion.Text);
                dataUtilities.SetParameter("@Telefono", TxtDireccion.Text);
                dataUtilities.SetParameter("@CorreoElectronico", TxtCorreo.Text);
                dataUtilities.SetParameter("@FechaContratacion", DtFechaContratacion.Value);
                dataUtilities.SetParameter("@Cargo", TxtCargo.Text);
                dataUtilities.SetParameter("@EstadoEmpleado", "Activo");
                dataUtilities.SetParameter("@Identificacion", TxtIdentificacion.Text);

                dataUtilities.ExecuteStoredProcedure("SP_ActualizarEmpleadoYUsuario");

                //Eliminar
                dataUtilities.DeleteRecordByColumn("UsuarioSucursal", "IdUsuario", auxUsuarioId);

                foreach (DataRow item in DtSucursales.Rows)
                {
                    dataUtilities.SetColumns("IdUsuario", auxUsuarioId);
                    dataUtilities.SetColumns("IdSucursal", item[0].ToString());
                    dataUtilities.InsertRecord("UsuarioSucursal");
                }

                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar el usuario.", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void PnlActUsuario_Load(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtPassConfirmar_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnAgregarSucursal_Click(object sender, EventArgs e)
        {
            foreach (DataRow item in DtSucursales.Rows)
            {
                if (item[0].ToString() == CmbSucursales.SelectedValue.ToString())
                {
                    MessageBox.Show("La sucursal ya ha sido agregada.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DtSucursales.Rows.Add(CmbSucursales.SelectedValue.ToString(), CmbSucursales.Text);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (DgvSucursales.SelectedRows.Count > 0)
            {
                DtSucursales.Rows.RemoveAt(DgvSucursales.SelectedRows[0].Index);
            }
        }
    }
    
}
