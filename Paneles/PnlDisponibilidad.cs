using NeoCobranza.ModelsCobranza;
using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles
{
    public partial class PnlDisponibilidad : Form
    {
        private string auxIdProducto;
        DataUtilities data = new DataUtilities();
        public PnlDisponibilidad(string IdProducto)
        {
            auxIdProducto = IdProducto;
            InitializeComponent();
        }

        public class DisponibilidaClass
        {
            public string Sucursal { get; set; }
            public int Cantidad { get; set; }   
        }

        private void PnlDisponibilidad_Load(object sender, EventArgs e)
        {
            try
            {
                UIUtilities.PersonalizarDataGridView(DgvProductos);

                data.SetParameter("@productoId", auxIdProducto);
                DataTable dataTable = data.ExecuteStoredProcedure("ListarProductosPorSucursales");

                DgvProductos.DataSource = dataTable;


                string nombreProducto = Convert.ToString(data.getRecordByPrimaryKey("ProductosServicios", Convert.ToString(auxIdProducto)).Rows[0]["NombreProducto"]);

                LblDynamico.Text = "Sucursales con existencias de producto: " + nombreProducto;

            }
            catch (Exception ex)
            {

            }
        }
    }
}
