using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.PnlInventario
{
    public partial class Pnl_InformeInventario : Form
    {
        public Pnl_InformeInventario()
        {
            InitializeComponent();
        }

        private void Pnl_InformeInventario_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'data_Inventario.Reporteria_ReservadoModeloxUbicacion' Puede moverla o quitarla según sea necesario.
            this.reporteria_ReservadoModeloxUbicacionTableAdapter.Fill(this.data_Inventario.Reporteria_ReservadoModeloxUbicacion);
            // TODO: esta línea de código carga datos en la tabla 'data_Inventario.Reporteria_ReservadoxUbicacion' Puede moverla o quitarla según sea necesario.
            this.reporteria_ReservadoxUbicacionTableAdapter.Fill(this.data_Inventario.Reporteria_ReservadoxUbicacion);
            // TODO: esta línea de código carga datos en la tabla 'data_Inventario.Reporteria_DisponiblesxUbicacion' Puede moverla o quitarla según sea necesario.
            this.reporteria_DisponiblesxUbicacionTableAdapter.Fill(this.data_Inventario.Reporteria_DisponiblesxUbicacion);
            // TODO: esta línea de código carga datos en la tabla 'data_Inventario.Nuevo_listar_SinInventario' Puede moverla o quitarla según sea necesario.
            this.nuevo_listar_SinInventarioTableAdapter.Fill(this.data_Inventario.Nuevo_listar_SinInventario);
            // TODO: esta línea de código carga datos en la tabla 'data_Inventario.Reporte_Inventario_Disponibles' Puede moverla o quitarla según sea necesario.
            this.reporte_Inventario_DisponiblesTableAdapter.Fill(this.data_Inventario.Reporte_Inventario_Disponibles);
            // TODO: esta línea de código carga datos en la tabla 'data_Inventario.Reporte_Inventario' Puede moverla o quitarla según sea necesario.
            this.reporte_InventarioTableAdapter.Fill(this.data_Inventario.Reporte_Inventario);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
