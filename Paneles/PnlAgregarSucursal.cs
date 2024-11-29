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

namespace NeoCobranza.Paneles
{
    public partial class PnlAgregarSucursal : Form
    {
        PnlCatalogoSucursales auxFrmPrincipal;
        string auxOpc, auxId;
        DataUtilities dataUtilities = new DataUtilities();

        public PnlAgregarSucursal(PnlCatalogoSucursales frm, string opc, string id)
        {
            InitializeComponent();
            this.auxFrmPrincipal = frm;
            this.auxId = id;
            this.auxOpc = opc;
        }

        private void PnlAgregarSucursal_Load(object sender, EventArgs e)
        {
            if(auxOpc != "Crear") 
            {
                DataTable dtResponse = dataUtilities.getRecordByPrimaryKey("Sucursal", auxId);


                    TxtNombreSucursal.Text = Convert.ToString(dtResponse.Rows[0]["NombreSucursal"]);
                    TxtTelefono.Text = Convert.ToString(dtResponse.Rows[0]["Telefono"]);
                    TxtDireccion.Text = Convert.ToString(dtResponse.Rows[0]["Direccion"]);
                    TxtCorreo.Text = Convert.ToString(dtResponse.Rows[0]["Correo"]);

                    LblDynamico.Text = "Modificar Sucursal";
                    btnAgregar.Text = "Modificar";
                
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if(TxtNombreSucursal.Text.Trim().Length == 0)
            {
                MessageBox.Show("El nombre de la Sucursal no puede estar vacío.","Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TxtTelefono.Text.Trim().Length == 0)
            {
                MessageBox.Show("El telefono no puede estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            switch (this.auxOpc)
            {
                case "Crear":

                    string SucursalID = Guid.NewGuid().ToString();

                    dataUtilities.SetColumns("IdSucursal", SucursalID);
                    dataUtilities.SetColumns("NombreSucursal",TxtNombreSucursal.Text.Trim());
                    dataUtilities.SetColumns("Direccion", TxtDireccion.Text.Trim());
                    dataUtilities.SetColumns("Telefono", TxtTelefono.Text.Trim());
                    dataUtilities.SetColumns("Correo", TxtCorreo.Text.Trim());
                    dataUtilities.SetColumns("Estado", "Activo");
                    dataUtilities.SetColumns("FechaCreo",DateTime.Now.ToString());
                    dataUtilities.InsertRecord("Sucursal");

                    dataUtilities.SetColumns("SucursalId", SucursalID);
                    dataUtilities.SetColumns("Serie", TxtNombreSucursal.Text.Trim().Substring(0, 1));
                    dataUtilities.SetColumns("ConsecutivoFactura",1);
                    dataUtilities.SetColumns("RangoFactura", 99999);
                    dataUtilities.SetColumns("ConsecutivoOrden", 1);
                    dataUtilities.SetColumns("RangoOrden", 99999);
                    dataUtilities.InsertRecord("ConfigFacturacion");

                    
                    break;
                case "Modificar":
     
                    dataUtilities.SetColumns("NombreSucursal", TxtNombreSucursal.Text.Trim());
                    dataUtilities.SetColumns("Direccion", TxtDireccion.Text.Trim());
                    dataUtilities.SetColumns("Telefono", TxtTelefono.Text.Trim());
                    dataUtilities.SetColumns("Correo", TxtCorreo.Text.Trim());
                    dataUtilities.SetColumns("Estado", "Activo");
                    dataUtilities.SetColumns("FechaActualizo", DateTime.Now.ToString());
                    dataUtilities.UpdateRecordByPrimaryKey("Sucursal", auxId);
                    
                    break;
            }

            this.auxFrmPrincipal.vMCatalogoSucursales.InitModuloCatalogoSucursales(auxFrmPrincipal,"Buscar");
            this.Dispose();
        }

    }
}
