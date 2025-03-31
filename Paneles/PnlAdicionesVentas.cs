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
    public partial class PnlAdicionesVentas : Form
    {

        DataUtilities dataUtilities = new DataUtilities();
        private DataTable dtProductos;
        private const int AlturaLinea = 30;
        private const int MaxItemsVisibles = 10;
        private string auxProducto = "";
        private string auxOrdenDetalle = "";
        // Agregar un ToolTip para mostrar el nombre completo si es muy largo
        private ToolTip toolTipProducto = new ToolTip();

        public PnlAdicionesVentas(string idProducto,string ordenDetalleId)
        {
            auxProducto = idProducto;
            auxOrdenDetalle = ordenDetalleId;
            InitializeComponent();
            InicializarDataTable();
            CargarProductosEnFlow("");
        }

        private void InicializarDataTable()
        {
            dtProductos = new DataTable();
            dtProductos.Columns.Add("ID", typeof(string));
            dtProductos.Columns.Add("Nombre", typeof(string));

            dataUtilities.SetParameter("@ProductoId", auxProducto);
            DataTable dtResponse = dataUtilities.ExecuteStoredProcedure("spConsultarAdicionesProducto");

            foreach (DataRow row in dtResponse.Rows)
            {
                dtProductos.Rows.Add(
                    Convert.ToString(row["AdicionId"]),
                    Convert.ToString(row["AdicionNombre"]));
            }
        }

        private void CargarProductosEnFlow(string filtro)
        {
            FLAdiciones.Controls.Clear();

            var filasFiltradas = dtProductos.AsEnumerable()
                .Where(row => row.Field<string>("Nombre").IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0);

            foreach (var fila in filasFiltradas)
            {
                string idProducto = fila.Field<string>("ID");
                string nombreProducto = fila.Field<string>("Nombre");

                CheckBox chkProducto = new CheckBox();
                chkProducto.Text = nombreProducto;
                chkProducto.Tag = idProducto;
                chkProducto.Font = new Font("Microsoft Sans Serif", 12);
                chkProducto.Width = FLAdiciones.Width - 25; // Ajusta el ancho con un margen
                chkProducto.AutoEllipsis = true; // Muestra "..." si el texto es muy largo
                chkProducto.CheckedChanged += ChkProducto_CheckedChanged;

                // Agrega un ToolTip para mostrar el nombre completo al pasar el mouse
                toolTipProducto.SetToolTip(chkProducto, nombreProducto);

                FLAdiciones.Controls.Add(chkProducto);
            }

            int cantidadItems = FLAdiciones.Controls.Count;
            int itemsVisibles = cantidadItems > MaxItemsVisibles ? MaxItemsVisibles : cantidadItems;
            FLAdiciones.Height = itemsVisibles * AlturaLinea;
        }

        private void ChkProducto_CheckedChanged(object sender, EventArgs e)
        {
            //CheckBox chk = sender as CheckBox;
            //if (chk != null && chk.Tag != null)
            //{
            //    string idProducto = (string)chk.Tag;
            //    bool agregar = chk.Checked;
            //    AgregarQuitar(idProducto, agregar);
            //}
        }

        private void AgregarQuitar(string idProducto, bool agregar)
        {
            //if (agregar)
            //{
            //    dataUtilities.SetParameter("@ProductoId", auxProducto);
            //    dataUtilities.SetParameter("@AdicionId", idProducto);
            //    dataUtilities.SetParameter("@Accion", "AGREGAR");
            //    dataUtilities.ExecuteStoredProcedure("spGestionarAdicion");
            //}
            //else
            //{
            //    dataUtilities.SetParameter("@ProductoId", auxProducto);
            //    dataUtilities.SetParameter("@AdicionId", idProducto);
            //    dataUtilities.SetParameter("@Accion", "QUITAR");
            //    dataUtilities.ExecuteStoredProcedure("spGestionarAdicion");
            //}

            //InicializarDataTable();
        }
    }
}
