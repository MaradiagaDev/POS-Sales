using NeoCobranza.ModelsCobranza;
using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles
{
    public partial class Promociones : Form
    {
        VMPromciones vMPromciones = new VMPromciones();

        public class FormasPagoClass
        {
            public int id { get; set;}
            public string opc { get; set; }
        }

        public Promociones()
        {
            InitializeComponent();
        }

        private void Promociones_Load(object sender, EventArgs e)
        {
            vMPromciones.InitModuloPromociones(this);
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            vMPromciones.ConfigUI(this, "Crear", "");
        }

        private void DgvPromociones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Agregar
            if (e.ColumnIndex == 0)
            {
                object cellValue = DgvPromociones.Rows[e.RowIndex].Cells[2].Value;
                vMPromciones.ConfigUI(this, "Modificar", cellValue.ToString());
            }

            //Quitar
            if (e.ColumnIndex == 1)
            {
                object cellValue = DgvPromociones.Rows[e.RowIndex].Cells[2].Value;
                vMPromciones.ConfigUI(this, "Modificar", cellValue.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            vMPromciones.ConfigUI(this, "Buscar", "");
        }

        private void CmbTipoPromocion_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                if (CmbTipoPromocion.Items.Count != 0)
                {
                    switch (CmbTipoPromocion.Text)
                    {
                        case "Por Producto":

                            LblCmbDinamico.Text = "Seleccione los Productos";

                            var listaProductos = db.ServiciosEstadares.Where(s => s.ClasificacionProducto == 0).ToList();
                            CmbDinamico.DataSource = listaProductos;
                            CmbDinamico.ValueMember = "IdEstandar";
                            CmbDinamico.DisplayMember = "NombreEstandar";
                            CmbDinamico.SelectedIndex = 0;

                            break;

                        case "Por Servicio":

                            LblCmbDinamico.Text = "Seleccione los Servicios";

                            var listaServicios = db.ServiciosEstadares.Where(s => s.ClasificacionProducto == 1).ToList();
                            CmbDinamico.DataSource = listaServicios;
                            CmbDinamico.ValueMember = "IdEstandar";
                            CmbDinamico.DisplayMember = "NombreEstandar";
                            CmbDinamico.SelectedIndex = 0;

                            break;

                        case "Por Forma de Pago":

                            LblCmbDinamico.Text = "Seleccione las Formas de Pago";

                            FormasPagoClass formaUno = new FormasPagoClass()
                            {
                                id = 1,
                                opc = "Efectivo"
                            };

                            FormasPagoClass formaDos = new FormasPagoClass()
                            {
                                id = 2,
                                opc = "Tarjetas"
                            };

                            var listaFormasPago = new List<FormasPagoClass>()
                            { formaUno, formaDos };

                            CmbDinamico.DataSource = listaFormasPago;
                            CmbDinamico.ValueMember = "id";
                            CmbDinamico.DisplayMember = "opc";
                            CmbDinamico.SelectedIndex = 0;

                            break;

                        case "Por Tipo Producto":

                            LblCmbDinamico.Text = "Seleccione el Tipo de Producto";

                            List<TipoServicios>  listaTipos = db.TipoServicios.ToList();

                            CmbDinamico.DataSource = listaTipos;
                            CmbDinamico.ValueMember = "TipoServicionId";
                            CmbDinamico.DisplayMember = "Descripcion";
                            CmbDinamico.SelectedIndex = 0;
                            break;

                        case "Por Tipo Tarjeta":

                            LblCmbDinamico.Text = "Seleccione el Tipo de Tarjeta";

                            List<TipoTarjeta> listaTiposTarjeta = db.TipoTarjeta.ToList();

                            CmbDinamico.DataSource = listaTiposTarjeta;
                            CmbDinamico.ValueMember = "TipoTarjetaId";
                            CmbDinamico.DisplayMember = "NombreTipo";
                            CmbDinamico.SelectedIndex = 0;
                            break;
                    }
                }
            }
        }
    }
}
