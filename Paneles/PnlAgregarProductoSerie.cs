using NeoCobranza.ModelsCobranza;
using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles
{
    public partial class PnlAgregarProductoSerie : Form
    {
        string auxIdProducto;
        string auxIdAlmacen;

        DataUtilities dataUtilities = new DataUtilities();
        
        private class OrdenarPorClass
        {
            public int id { get; set; }
            public string opc { get; set; }
        }

        public PnlAgregarProductoSerie(string idProducto, string idAlmacen)
        {
            InitializeComponent();
            this.auxIdProducto = idProducto;
            this.auxIdAlmacen = idAlmacen;
        }

        private void PnlAgregarProductoSerie_Load(object sender, EventArgs e)
        {
            CmbTipoAjuste.SelectedIndex = 0;
            //Colocar la descripcion del producto y el almacen
            DataTable dtResponseProducto = dataUtilities.getRecordByPrimaryKey("ProductosServicios", auxIdProducto);
            DataTable dtResponseAlmacenes = dataUtilities.getRecordByPrimaryKey("Almacenes", auxIdAlmacen);

            string nombreProducto = Convert.ToString(dtResponseProducto.Rows[0]["NombreProducto"]);
            string nombreAlmacen = Convert.ToString(dtResponseAlmacenes.Rows[0]["NombreAlmacen"]);

            LblDinamico.Text = $"Ajuste del producto: {nombreProducto} en {nombreAlmacen}";
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void BtnGuardar_Click_1(object sender, EventArgs e)
        {
            if (TxtIdentificador.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe agregar un identificador a la merma.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtIdentificador.Focus();
                return;
            }

            if (TxtRazon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe agregar una razón o motivo a la merma.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtRazon.Focus();
                return;
            }

            int Cantidad = 0;

            if (int.TryParse(TxtCantidad.Text.Trim(), out Cantidad) == false || Cantidad == 0)
            {
                MessageBox.Show("Debe agregar una cantidad.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtCantidad.Focus();
                return;
            }

            // Validar que el almacen tenga lo necesario para eliminar esa cantidad de producto
            DataTable dtResponse = dataUtilities.GetAllRecords("RelAlmacenProducto");
            var filterRow = 
                from row in dtResponse.AsEnumerable() 
                where Convert.ToString(row.Field<string>("AlmacenId")) == auxIdAlmacen
                && Convert.ToString(row.Field<string>("ProductoId")) == auxIdProducto
                select row;

            dtResponse = filterRow.CopyToDataTable();

            decimal cantidadActual = Convert.ToDecimal(dtResponse.Rows[0]["Cantidad"]);

            if (CmbTipoAjuste.SelectedIndex == 0)
            {
                if (cantidadActual < Convert.ToDecimal(TxtCantidad.Text))
                {
                    MessageBox.Show("No hay suficiente inventario.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtCantidad.Focus();

                    return;
                }
            }

            DataTable dtResponseProducto = dataUtilities.getRecordByPrimaryKey("ProductosServicios", auxIdProducto);

            //Realizar la merma
            dataUtilities.SetColumns("Identificador",TxtIdentificador.Text.Trim());
            dataUtilities.SetColumns("Razon", TxtRazon.Text.Trim());
            dataUtilities.SetColumns("CantidadMermada",Convert.ToDecimal(TxtCantidad.Text.Trim()));
            dataUtilities.SetColumns("FechaRealizacion",DateTime.Now);
            dataUtilities.SetColumns("AlmacenId",auxIdAlmacen);
            dataUtilities.SetColumns("Usuario",Utilidades.Usuario);
            dataUtilities.SetColumns("BoolRevertida", false);
            dataUtilities.SetColumns("PrecioVenta", Convert.ToString(dtResponseProducto.Rows[0]["Precio"]));
            dataUtilities.SetColumns("ProductoId", Convert.ToString(dtResponseProducto.Rows[0]["ProductoId"]));
            dataUtilities.SetColumns("TipoMerma", CmbTipoAjuste.Text);

            dataUtilities.InsertRecord("Mermas");

            //Quitar la cantidad del almacen

            if(CmbTipoAjuste.SelectedIndex == 0)
            {
                dataUtilities.SetColumns("Cantidad", (cantidadActual - Convert.ToDecimal(TxtCantidad.Text)));
            }
            else
            {
                dataUtilities.SetColumns("Cantidad", (cantidadActual + Convert.ToDecimal(TxtCantidad.Text)));
            }
            
            dataUtilities.UpdateRecordByPrimaryKey("RelAlmacenProducto", Convert.ToDecimal(dtResponse.Rows[0]["RelAlmacenProductoId"]));

            MessageBox.Show("Ajuste realizado correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
