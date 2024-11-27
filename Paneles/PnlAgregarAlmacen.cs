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
    public partial class PnlAgregarAlmacen : Form
    {
        private string auxId;
        private string auxAccion;
        private PnlCatalogoAlmacenes auxFrmPrincipal;
        private DataUtilities dataUtilities = new DataUtilities();
        public PnlAgregarAlmacen(PnlCatalogoAlmacenes frm, string opc, string id)
        {
            this.auxId = id;
            this.auxAccion = opc;
            this.auxFrmPrincipal = frm;

            InitializeComponent();
        }

        private void PnlAgregarAlmacen_Load(object sender, EventArgs e)
        {
            switch (auxAccion)
            {

                case "Crear":
                    LblDynamico.Text = "Crear Almacén";
                    btnAgregar.Text = "Guardar";
                    ChkAlmacenMostrador.Enabled = false;
                    break;
                case "Modificar":
                    LblDynamico.Text = "Actualizar Almacén";
                    btnAgregar.Text = "Actualizar";
                    ChkAlmacenMostrador.Enabled = false;
                    ChkAsignarSucursal.Enabled = false;

                    using (NeoCobranzaContext db = new NeoCobranzaContext())
                    {
                        DataTable dtRespuesta = dataUtilities.getRecordByPrimaryKey("Almacenes", auxId);
                        TxtNombre.Text = Convert.ToString(dtRespuesta.Rows[0]["NombreAlmacen"]);
                        ChkAsignarSucursal.Checked = Convert.ToString(dtRespuesta.Rows[0]["SucursalId"]) == "" ? false : true;
                        ChkAlmacenMostrador.Checked = Convert.ToBoolean(dtRespuesta.Rows[0]["EsMostrador"]);
                        TxtDireccion.Text = Convert.ToString(dtRespuesta.Rows[0]["Direccion"]);
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

            if (TxtNombre.Text.Trim().Length == 0)
            {
                MessageBox.Show("El nombre del Almacén no puede estár vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (auxAccion == "Crear")
            {
                if (ChkAsignarSucursal.Checked && ChkAlmacenMostrador.Checked)
                {

                    DataTable dtRespuesta = dataUtilities.getRecordByColumn("Almacenes", "SucursalId", Utilidades.SucursalId);

                    int countMostrador = 0;

                    foreach (DataRow item in dtRespuesta.Rows)
                    {
                        if (Convert.ToBoolean(item["EsMostrador"]) == true)
                        {
                            countMostrador++;
                        }
                    }

                    if (countMostrador == 1)
                    {
                        MessageBox.Show("La Sucursal ya tiene un Almacén mostrador asignado. Favor asigne un almacén normal.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string sucursalId = ChkAsignarSucursal.Checked == true ? Utilidades.SucursalId : "";
                string AlmacenId = Guid.NewGuid().ToString();

                //insertar registro

                dataUtilities.SetColumns("AlmacenId", AlmacenId);
                dataUtilities.SetColumns("NombreAlmacen", TxtNombre.Text.Trim());
                dataUtilities.SetColumns("EsMostrador", ChkAlmacenMostrador.Checked);
                dataUtilities.SetColumns("SucursalId", sucursalId);
                dataUtilities.SetColumns("Estatus", "Activo");
                dataUtilities.SetColumns("Direccion", TxtDireccion.Text.Trim());

                dataUtilities.InsertRecord("Almacenes");

                //agregar productos en la tabla relacional

                DataTable dtRespuestaProductos = dataUtilities.GetAllRecords("ProductosServicios");

                foreach (DataRow item in dtRespuestaProductos.Rows)
                {
                    //Insertar Registro

                    dataUtilities.SetColumns("AlmacenId", AlmacenId);
                    dataUtilities.SetColumns("ProductoId", Convert.ToString(item["ProductoId"]));
                    dataUtilities.SetColumns("Cantidad", 0);

                    dataUtilities.InsertRecord("RelAlmacenProducto");
                }
            }
            else
            {
                dataUtilities.SetColumns("Direccion", TxtDireccion.Text.Trim());
                dataUtilities.SetColumns("NombreAlmacen", TxtNombre.Text.Trim());
                dataUtilities.UpdateRecordByPrimaryKey("Almacenes", auxId);
            }

            auxFrmPrincipal.vMCatalogoAlmacenes.InitModuloCatalogoAlmacenes(auxFrmPrincipal, "Buscar");
            this.Dispose();
        }

        private void ChkAsignarSucursal_Click(object sender, EventArgs e)
        {
            if (ChkAsignarSucursal.Checked)
            {
                ChkAlmacenMostrador.Enabled = true;
            }
            else
            {
                ChkAlmacenMostrador.Enabled = false;
            }
        }
    }
}
