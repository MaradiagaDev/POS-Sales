using NeoCobranza.Paneles;
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

namespace NeoCobranza.PantallasInicio
{
    public partial class frmSeleccionSucursal : Form
    {
        string vGlobIdUser = "";
        DataUtilities dataUtilities = new DataUtilities();

        public frmSeleccionSucursal(string vParIdUser)
        {
            try {
                InitializeComponent();
                this.vGlobIdUser = vParIdUser;

                //Obtener las sucursales
                dataUtilities.SetParameter("@IdUsuario", vParIdUser);

                //AGREGAR SUCURSALES AL COMBOBOX
                CmbSucursal.DisplayMember = "NombreSucursal";
                CmbSucursal.ValueMember = "IdSucursal";
                CmbSucursal.DataSource = dataUtilities.ExecuteStoredProcedure("SP_OBTENERSUCURSALESUSUARIO");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIngresarSucursal_Click(object sender, EventArgs e)
        {
            try{
                Utilidades.Sucursal = CmbSucursal.Text;
                Utilidades.SucursalId = CmbSucursal.SelectedValue.ToString();

                this.Close();

                PnlPrincipal frm = new PnlPrincipal();
                frm.Show();
            }
            catch
            (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
