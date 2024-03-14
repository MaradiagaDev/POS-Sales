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

namespace NeoCobranza.Paneles
{
    public partial class PnlAgregarSucursal : Form
    {
        PnlCatalogoSucursales auxFrmPrincipal;
        string auxOpc, auxId;

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
                using(NeoCobranzaContext db = new NeoCobranzaContext())
                {
                    Sucursales sucursal = db.Sucursales.Where(c => c.SucursalId == int.Parse(auxId)).FirstOrDefault();

                    TxtNombreSucursal.Text = sucursal.NombreSucursal;
                    TxtTelefono.Text = sucursal.Telefono;
                    TxtDireccion.Text = sucursal.Direccion;
                    TxtCorreo.Text = sucursal.Correo;

                    LblDynamico.Text = "Modificar Sucursal";
                    btnAgregar.Text = "Modificar";
                }
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
                    using(NeoCobranzaContext db = new NeoCobranzaContext())
                    {
                        Sucursales sucursal = new Sucursales() {
                            NombreSucursal = TxtNombreSucursal.Text.Trim(),
                            Telefono = TxtTelefono.Text.Trim(),
                            Correo = TxtCorreo.Text.Trim(),
                            Direccion = TxtDireccion.Text.Trim(),
                            Estado = "Activo"
                        };

                        db.Add(sucursal);
                        db.SaveChanges();

                        ModelsCobranza.ConfigFacturacion configFacturacion = new ModelsCobranza.ConfigFacturacion() 
                        { 
                            SucursalId = sucursal.SucursalId,
                            Serie = sucursal.NombreSucursal.Substring(0,1),
                            ConsecutivoFactura = 1,
                            RangoFactura = 999,
                            ConsecutivoOrden = 1,
                            RangoOrden = 999,
                        };

                        db.Add(configFacturacion);
                        db.SaveChanges();

                        ConfigInventario configInventario = new ConfigInventario()
                        {
                            SucursalId = sucursal.SucursalId,
                            InventarioNegativo = false,
                            SinInventario = false
                        };

                        db.Add(configInventario);
                        db.SaveChanges();
                    }
                    break;
                case "Modificar":
                    using (NeoCobranzaContext db = new NeoCobranzaContext())
                    {

                        Sucursales sucursal = db.Sucursales.Where(c => c.SucursalId == int.Parse(auxId)).FirstOrDefault();

                        sucursal.NombreSucursal = TxtNombreSucursal.Text.Trim();
                        sucursal.Telefono = TxtTelefono.Text.Trim();
                        sucursal.Correo = TxtCorreo.Text.Trim();
                        sucursal.Direccion = TxtDireccion.Text.Trim();

                        db.Update(sucursal);
                        db.SaveChanges();
                    }
                    break;
            }

            this.auxFrmPrincipal.vMCatalogoSucursales.InitModuloCatalogoSucursales(auxFrmPrincipal,"Buscar");
            this.Dispose();
        }

    }
}
