using NeoCobranza.ModelsCobranza;
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
            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                ServiciosEstadares producto = db.ServiciosEstadares.Where(s => s.IdEstandar == int.Parse(auxIdProducto)).FirstOrDefault();

                LblDynamico.Text = "Sucursales con existencias de producto: " + producto.NombreEstandar;

                List<DisponibilidaClass> listaDisponibilidad = new List<DisponibilidaClass>();
                List<Sucursales> sucursales = db.Sucursales.Where(s => s.Estado == "Activo").ToList();

                foreach(var item in sucursales)
                {
                    DisponibilidaClass claseDisponibilidad = new DisponibilidaClass();

                    claseDisponibilidad.Sucursal = item.NombreSucursal.ToString();
                    var almacenes = db.Almacenes.Where(s => s.SucursalId == item.SucursalId && s.Estatus == "Activo").ToList();

                    foreach(var itemAlmacen in almacenes)
                    {
                        var rel = db.RelAlmacenProducto.Where(s => s.ProductoId == int.Parse(auxIdProducto) && s.AlmacenId == itemAlmacen.AlmacenId).FirstOrDefault();
                        claseDisponibilidad.Cantidad += int.Parse(rel.Cantidad.ToString());
                    }

                    listaDisponibilidad.Add(claseDisponibilidad);
                }

                DataTable table = new DataTable();
                table.Columns.Add("Sucursal", typeof(string));
                table.Columns.Add("Cantidad", typeof(string));

                foreach(var item in listaDisponibilidad) 
                {
                  table.Rows.Add(item.Sucursal,item.Cantidad);
                }

                DgvProductos.DataSource = table;
            }
        }
    }
}
