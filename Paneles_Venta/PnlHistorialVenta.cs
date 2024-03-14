using NeoCobranza.Clases;
using NeoCobranza.Data;
using NeoCobranza.DataController;
using NeoCobranza.Paneles;
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
    public partial class PnlHistorialVenta : Form
    {

        //Variable de conexion
        public Conexion conexion;
        //Variable de ventas
        public VentasDirectas ventas;

        //Variable de cambio de dolar

        public CTasaCambio cTasa;


        public PnlHistorialVenta(Conexion conexion)
        {
            InitializeComponent();

            //Incializacion de conexion

            this.conexion = conexion;

            //Incializacion del objeto

            this.ventas = new VentasDirectas(conexion);

            this.cTasa = new CTasaCambio(conexion);
            //Llenado del dataTable

            dgvStock.DataSource = ventas.Mostra_SinRetirar_VentaFutura(txtFiltro.Texts);

            //Estilo
            dgvStock.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvStock.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);


        }

        private void txtFiltro__TextChanged(object sender, EventArgs e)
        {
            if (rbntFuturos.Checked == true)
            {
                dgvStock.DataSource = ventas.Mostra_SinRetirar_VentaFutura(txtFiltro.Texts);
            }
            if (rbtnReservados.Checked == true)
            {
                dgvStock.DataSource = ventas.Mostra_SinRetirar_Reservacion(txtFiltro.Texts);
            }

        }

        private void rbntFuturos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbntFuturos.Checked == true)
            {
                dgvStock.DataSource = ventas.Mostra_SinRetirar_VentaFutura(txtFiltro.Texts);
            }
            if (rbtnReservados.Checked == true)
            {
                dgvStock.DataSource = ventas.Mostra_SinRetirar_Reservacion(txtFiltro.Texts);
            }
        }

        private void rbtnReservados_CheckedChanged(object sender, EventArgs e)
        {
            if (rbntFuturos.Checked == true)
            {
                dgvStock.DataSource = ventas.Mostra_SinRetirar_VentaFutura(txtFiltro.Texts);
            }
            if (rbtnReservados.Checked == true)
            {
                dgvStock.DataSource = ventas.Mostra_SinRetirar_Reservacion(txtFiltro.Texts);
            }
        }

        private void BtnRetiro_Click(object sender, EventArgs e)
        {
            if (dgvStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ninguna venta","Error");
                return;
            }

            //

            for (int i = 0; i < ventas.Mostra_IdsAtaudes(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())).Rows.Count; i++)
            {


                ventas.VentaDirectas_Estandares(int.Parse(ventas.Mostra_IdsAtaudes(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())).Rows[i][0].ToString()));
            }

            MessageBox.Show("Venta cancelada","Correcto");

            //Reincio del data
            dgvStock.DataSource = ventas.Mostra_SinRetirar_Reservacion(txtFiltro.Texts);
            



        }

        private void dgvStock_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStock.SelectedRows.Count == 0)
            {
                dgvAtaudes.DataSource = null;

                DgvServcios.DataSource = null;


                lblTotalDolar.Text = "x";

                lblAnticipoDolar.Text = "x";

                lblPagoDolar.Text = "x";

                lblTotalCordoba.Text = "x";

                lblAnticipoCordoba.Text = "x";

                lblPagoCordoba.Text = "x";

                return;
            }
            else
            {

                DgvServcios.DataSource= ventas.Mostra_ServiciosReservados(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));
                dgvAtaudes.DataSource = ventas.Mostra_AtaudesReservados(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));

                RealizarCalculos();
            }

        }

        private void PnlHistorialVenta_Load(object sender, EventArgs e)
        {
            dgvStock.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
        }

        private void RealizarCalculos()
        {
            float suma = 0;

            double descuento = 0;

            //SUMAS DE NOMINALES
            for (int i = 0; i < DgvServcios.Rows.Count; i++)
            {
                suma = suma + (float.Parse(DgvServcios.Rows[i].Cells[3].Value.ToString()) * float.Parse(DgvServcios.Rows[i].Cells[1].Value.ToString()));
            }

            for (int i = 0; i < dgvAtaudes.Rows.Count; i++)
            {
                suma = suma + float.Parse(dgvAtaudes.Rows[i].Cells[3].Value.ToString());
            }

            //SUMAS DE DESCUENTOS
            for (int i = 0; i < DgvServcios.Rows.Count; i++)
            {
                descuento = descuento + ((float.Parse(DgvServcios.Rows[i].Cells[1].Value.ToString()) / 1.15) * (float.Parse(DgvServcios.Rows[i].Cells[2].Value.ToString()) / 100)* float.Parse(DgvServcios.Rows[i].Cells[3].Value.ToString()));
            }

            for (int i = 0; i < dgvAtaudes.Rows.Count; i++)
            {
                descuento = descuento + ((float.Parse(dgvAtaudes.Rows[i].Cells[3].Value.ToString()) / 1.15) * (float.Parse(dgvAtaudes.Rows[i].Cells[4].Value.ToString()) / 100));
            }
            double nominal = (Math.Round(suma / 1.15, 2));

            double descuentoC = (Math.Round(descuento, 2));

            double iva = (Math.Round((nominal - descuentoC) * 0.15, 2));

            lblTotalDolar.Text = (Math.Round(nominal - descuentoC + iva, 2)).ToString();

            lblAnticipoDolar.Text = dgvStock.SelectedRows[0].Cells[5].Value.ToString();

            lblPagoDolar.Text = (float.Parse(lblTotalDolar.Text) - float.Parse(lblAnticipoDolar.Text)).ToString();

            lblTotalCordoba.Text = Math.Round(float.Parse(lblTotalDolar.Text)*float.Parse(cTasa.MostrarTasa()), 2).ToString();

            lblPagoCordoba.Text = Math.Round(float.Parse(lblPagoDolar.Text) * float.Parse(cTasa.MostrarTasa()), 2).ToString();

            lblAnticipoCordoba.Text = Math.Round(float.Parse(lblAnticipoDolar.Text) * float.Parse(cTasa.MostrarTasa()), 2).ToString();
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {

            if (dgvStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ninguna factura", "Atencion");
                return;
            }

            string tipo = "";

            if (rbtnReservados.Checked)
            {
                tipo = "Reserva";
            }
            else
            {
                tipo = "VF";
            }
           



            //PnlVentas pnlVentas = new PnlVentas(conexion, int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()), tipo);

            
            //LLamado al panel central
            PnlPrincipal pnlPrincipal = Owner as PnlPrincipal;
            //pnlVentas.TopLevel = false;
            //pnlPrincipal.PnlCentral.Controls.Add(pnlVentas);
            //pnlVentas.Show();

            //Cerrado ocultado del panel de facturacion
            this.Hide();

        }
    }
}
