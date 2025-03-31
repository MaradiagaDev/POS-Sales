using System;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using NeoCobranza.ViewModels;

namespace NeoCobranza.Paneles
{
    public partial class PnlCatalogoAdiciones : Form
    {
        DataUtilities dataUtilities = new DataUtilities();
        private DataTable dtProductos;
        private const int AlturaLinea = 30;
        private const int MaxItemsVisibles = 10;
        private string auxProducto = "";
        // Agregar un ToolTip para mostrar el nombre completo si es muy largo
        private ToolTip toolTipProducto = new ToolTip();

        public PnlCatalogoAdiciones(string idProducto)
        {
            auxProducto = idProducto;
            InitializeComponent();
            FLAdiciones.AutoScroll = true;
            InicializarDataTable();
            CargarProductosEnFlow("");
            TxtFiltro.TextChanged += TxtFiltro_TextChanged;
        }

        private void InicializarDataTable()
        {
            dtProductos = new DataTable();
            dtProductos.Columns.Add("ID", typeof(string));
            dtProductos.Columns.Add("Nombre", typeof(string));
            dtProductos.Columns.Add("Chk", typeof(bool));

            dataUtilities.SetParameter("@ProductoId", auxProducto);
            DataTable dtResponse = dataUtilities.ExecuteStoredProcedure("spConsultarAdiciones");

            foreach(DataRow row in dtResponse.Rows)
            {
                dtProductos.Rows.Add(
                    Convert.ToString(row["AdicionId"]), 
                    Convert.ToString(row["AdicionNombre"]),
                    Convert.ToBoolean(row["Asociada"]));
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
                bool chk = fila.Field<bool>("Chk");

                CheckBox chkProducto = new CheckBox();
                chkProducto.Text = nombreProducto;
                chkProducto.Tag = idProducto;
                chkProducto.Font = new Font("Microsoft Sans Serif", 12);
                chkProducto.Width = FLAdiciones.Width - 25; // Ajusta el ancho con un margen
                chkProducto.AutoEllipsis = true; // Muestra "..." si el texto es muy largo
                chkProducto.Checked = chk;
                chkProducto.CheckedChanged += ChkProducto_CheckedChanged;

                // Agrega un ToolTip para mostrar el nombre completo al pasar el mouse
                toolTipProducto.SetToolTip(chkProducto, nombreProducto);

                FLAdiciones.Controls.Add(chkProducto);
            }

            int cantidadItems = FLAdiciones.Controls.Count;
            int itemsVisibles = cantidadItems > MaxItemsVisibles ? MaxItemsVisibles : cantidadItems;
            FLAdiciones.Height = itemsVisibles * AlturaLinea;
        }

        private void TxtFiltro_TextChanged(object sender, EventArgs e)
        {
            string filtro = TxtFiltro.Text;
            CargarProductosEnFlow(filtro);
        }

        private void ChkProducto_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            if (chk != null && chk.Tag != null)
            {
                string idProducto = (string)chk.Tag;
                bool agregar = chk.Checked;
                AgregarQuitar(idProducto, agregar);
            }
        }

        private void AgregarQuitar(string idProducto, bool agregar)
        {
            if (agregar)
            {
                dataUtilities.SetParameter("@ProductoId", auxProducto);
                dataUtilities.SetParameter("@AdicionId", idProducto);
                dataUtilities.SetParameter("@Accion", "AGREGAR");
                dataUtilities.ExecuteStoredProcedure("spGestionarAdicion");
            }
            else
            {
                dataUtilities.SetParameter("@ProductoId", auxProducto);
                dataUtilities.SetParameter("@AdicionId", idProducto);
                dataUtilities.SetParameter("@Accion", "QUITAR");
                dataUtilities.ExecuteStoredProcedure("spGestionarAdicion");
            }

            InicializarDataTable();
        }
    }
}
