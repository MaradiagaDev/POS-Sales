using NeoCobranza.Clases;
using NeoCobranza.Data;
using NeoCobranza.DataController;
using NeoCobranza.Paneles;
using NeoCobranza.Paneles_Venta.Informes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles_Venta
{
    public partial class PnlVentasFacturacion : Form
    {
        //Instanciar variables
        public Conexion conexion;

        public VentasDirectas directas;
       
        public PnlVentasFacturacion(Conexion conexion)
        {
            InitializeComponent();

            //Inicializacion de variables

            this.conexion = conexion;

            directas = new VentasDirectas(conexion);

            //llenado de los  dgv

            
                dgvStock.DataSource = directas.Mostra_Todas_Ventas(txtFiltro.Texts);
            //Estilo
            dgvStock.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvStock.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);



        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnRealizarVenta_Click(object sender, EventArgs e)
        {
            if (dgvStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ninguna venta","Error");
            }
            if (dgvStock.SelectedRows[0].Cells[2].Value.ToString() == "Anulado")
            {
                MessageBox.Show("No se puede facturar una venta anulada", "error");
                return;
            }
            PnlFacturaInforme pnlFacturaInforme = new PnlFacturaInforme(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()),conexion);
             pnlFacturaInforme.Show();
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {

            if (dgvStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ninguna factura", "Atencion");
                return;
            }

           /// PnlVentas pnlVentas = new PnlVentas(conexion, int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()),"Final");


            //LLamado al panel central
            PnlPrincipal pnlPrincipal = Owner as PnlPrincipal;
       //

            //Cerrado ocultado del panel de facturacion
            this.Hide();
        }
        private void Ccolor()
        {
            for (int i = 0; i < dgvStock.Rows.Count; i++)
            {
                if (dgvStock.Rows[i].Cells[2].Value.ToString() == "Sin Imprimir")
                {
                    dgvStock.Rows[i].DefaultCellStyle.BackColor = Color.YellowGreen;
                }
                else
                {
                    dgvStock.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }


            }
        }
        private void PnlVentasFacturacion_Load(object sender, EventArgs e)
        {
            Ccolor();
        }

        private void BtnAnular_Click(object sender, EventArgs e)
        {
            //Verificar que haya algo seleccionado

            if(dgvStock.SelectedRows.Count == 0)
            {

                MessageBox.Show("No ha seleccionado ninguna factura","Error");
                return;
            }

            //Procedimiento para anular(Solo se puede anular por si el stock se vuelve a colocar en venta)

            directas.Actualizar_Estado(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));

            for (int i = 0; i < directas.Actualizar_Ataudes(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())).Rows.Count; i++)
            {

                directas.Actualizar_Disponible(int.Parse(directas.Actualizar_Ataudes(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())).Rows[i][0].ToString()));
                    
            }



            //Actualizar

            dgvStock.DataSource = directas.Mostra_Todas_Ventas(txtFiltro.Texts);
            Ccolor();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Rpt_InformeGeneralCaja rpt_InformeGeneralCaja = new Rpt_InformeGeneralCaja(lblFechaInicio.Text,lblFechaFinal.Text,conexion);
            rpt_InformeGeneralCaja.Show();
        }
    }
}
