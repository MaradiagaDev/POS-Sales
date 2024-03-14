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
    public partial class PnlAgregarAlmacen : Form
    {
        private string auxId;
        private string auxAccion;
        private PnlCatalogoAlmacenes auxFrmPrincipal;
        public PnlAgregarAlmacen(PnlCatalogoAlmacenes frm,string opc,string id)
        {
            this.auxId = id;
            this.auxAccion = opc;
            this.auxFrmPrincipal = frm;

            InitializeComponent();
        }

        private void PnlAgregarAlmacen_Load(object sender, EventArgs e)
        {

            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                List<Sucursales> list = db.Sucursales.Where(c => c.Estado == "Activo").ToList();

                CmbSucursal.ValueMember = "SucursalId";
                CmbSucursal.DisplayMember = "NombreSucursal";
                CmbSucursal.DataSource = list;
            }

            switch(auxAccion) 
            {

                case "Crear":
                    LblDynamico.Text = "Crear Almacén";
                    btnAgregar.Text = "Guardar";
                    break;
                case "Modificar":
                    LblDynamico.Text = "Actualizar Almacén";
                    btnAgregar.Text = "Actualizar";
                    ChkAsignarSucursal.Enabled = false;

                    using(NeoCobranzaContext db = new NeoCobranzaContext())
                    {
                        Almacenes almacen = db.Almacenes.Where( c => c.AlmacenId == int.Parse(auxId)).FirstOrDefault();
                        TxtNombre.Text = almacen.NombreAlmacen;
                        ChkAsignarSucursal.Checked = almacen.SucursalId != 0 ? true : false;
                        ChkAlmacenMostrador.Checked = (bool)almacen.EsMostrador;
                        CmbSucursal.SelectedValue = almacen.SucursalId != 0 ? almacen.SucursalId : CmbSucursal.SelectedValue;
                    }
                    break;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Verificaciones

            if(TxtNombre.Text.Trim().Length == 0)
            {
                MessageBox.Show("El nombre del Almacén no puede estár vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                if(auxAccion == "Crear")
                {
                    if (ChkAsignarSucursal.Checked)
                    {
                        if (CmbSucursal.Items.Count == 0)
                        {
                            MessageBox.Show("Debe agregar una sucursal en el catalogo antes de asignar almacenes a sucursales.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        List<Almacenes> list = db.Almacenes.Where(c => c.SucursalId == int.Parse(CmbSucursal.SelectedValue.ToString())).ToList();

                        if (list.Count == 2)
                        {
                            MessageBox.Show("Una Sucursal solo puede tener dos almacenes asignados.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (list.Count == 1)
                        {
                            if (list.Where(c => c.EsMostrador == true).Any() && ChkAlmacenMostrador.Checked)
                            {
                                MessageBox.Show("La Sucursal ya tiene un Almacén mostrador asignado. Favor asigne un almacén normal.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else if (!list.Where(c => c.EsMostrador == true).Any() && !ChkAlmacenMostrador.Checked)
                            {
                                MessageBox.Show("La Sucursal ya tiene un Almacén normal asignado. Favor asigne un Almacén mostrado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    Almacenes almacen = new Almacenes()
                    {
                        NombreAlmacen = TxtNombre.Text.Trim(),
                        EsMostrador = ChkAlmacenMostrador.Checked,
                        SucursalId = ChkAsignarSucursal.Checked == true ? int.Parse(CmbSucursal.SelectedValue.ToString()) : 0,
                        Estatus = "Activo"
                    };

                    db.Add(almacen);
                    db.SaveChanges();

                    List<ServiciosEstadares> servicios = db.ServiciosEstadares.Where(s => s.ClasificacionProducto == 0).ToList();

                    foreach(var item in servicios)
                    {
                        RelAlmacenProducto rel = new RelAlmacenProducto() {
                        AlmacenId = almacen.AlmacenId,
                        ProductoId = item.IdEstandar,
                        Cantidad = 0
                        };

                        db.Add(rel);
                    }

                    db.SaveChanges();
                }
                else
                {
                    Almacenes almacen = db.Almacenes.Where(c => c.AlmacenId == int.Parse(auxId)).FirstOrDefault();
                    almacen.NombreAlmacen = TxtNombre.Text.Trim();

                    db.Update(almacen);
                    db.SaveChanges();
                }
            }


            auxFrmPrincipal.vMCatalogoAlmacenes.InitModuloCatalogoAlmacenes(auxFrmPrincipal, "Buscar");
            this.Dispose();
        }

        private void ChkAsignarSucursal_Click(object sender, EventArgs e)
        {
            if (ChkAsignarSucursal.Checked)
            {
                CmbSucursal.Enabled = true;
                ChkAlmacenMostrador.Enabled = true;
                LblSucursal.Enabled = true;
            }
            else
            {
                CmbSucursal.Enabled = false;
                ChkAlmacenMostrador.Enabled = false;
                LblSucursal.Enabled = false;
            }
        }
    }
}
