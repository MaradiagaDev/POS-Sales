using NeoCobranza.Clases;
using NeoCobranza.Data;
using NeoCobranza.Paneles;
using NeoCobranza.Paneles_Caja.Caja_Informe_Entrega;
using NeoCobranza.Paneles_Caja.Caja_Informe_Reporte;
using NeoCobranza.Paneles_Venta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles_Caja
{
    public partial class PnlHistorialRecibos : Form
    {

        //Instancia de la clase de conexion
        public Conexion conexion;

        //instancia de la clase a utilizar
        public RecibosOficialesCaja recibosOficiales;

        public PnlHistorialRecibos(Conexion conexion)
        {
            InitializeComponent();

            this.conexion = conexion;
            this.recibosOficiales = new RecibosOficialesCaja(conexion);
            //
            llenarDta();
            //Estilo del data
            dgvStock.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvStock.ColumnHeadersDefaultCellStyle.Font  = new Font("Microsoft Sans Serif", 11);

            



        }
        private void llenarDta()
        {

            //LLenado del data
            dgvStock.DataSource = recibosOficiales.Caja_Historial(txtFiltro.Texts);

            //Alternar el color de las filas

            for (int i =0;i< dgvStock.Rows.Count; i++)
            {
                if (dgvStock.Rows[i].Cells[5].Value.ToString() == "Activo")
                {
                    dgvStock.Rows[i].DefaultCellStyle.BackColor = Color.YellowGreen;
                }
                else
                {
                    dgvStock.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }


            }

            
        }
        private void dgvStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEstado_Click(object sender, EventArgs e)
        {
            //Verificar que haya un recibo seleccionado
            if (dgvStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ninguna fila","Error");
                return;
            }

            recibosOficiales.Caja_CambiarEstado(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));

            llenarDta();
        }

        private void PnlHistorialRecibos_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvStock.Rows.Count; i++)
            {
                if (dgvStock.Rows[i].Cells[5].Value.ToString() == "Activo")
                {
                    dgvStock.Rows[i].DefaultCellStyle.BackColor = Color.YellowGreen;
                }
                else
                {
                    dgvStock.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }


            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //Verificar que haya un recibo seleccionado
            if (dgvStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ninguna fila", "Error");
                return;
            }

            //LLamado al panel de recibos oficiales para su actualizacion

            PnlReciboOficialCaja pnlRecibo = new PnlReciboOficialCaja(conexion, int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));


            //LLamado al panel central
            PnlPrincipal pnlPrincipal = Owner as PnlPrincipal;
            pnlRecibo.TopLevel = false;
            pnlPrincipal.PnlCentral.Controls.Add(pnlRecibo);
            pnlRecibo.Show();

            //Cerrado ocultado del panel de historial de recibos
            this.Hide();


        }

        private void txtFiltro__TextChanged(object sender, EventArgs e)
        {
            llenarDta();
        }

        private void especialButton2_Click(object sender, EventArgs e)
        {
            //Verficiar que se haya seleccionado algo
            if (dgvStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ninguna fila", "Error");
                return;
            }
            if (dgvStock.SelectedRows[0].Cells[5].Value.ToString() == "Anulado")
            {

                MessageBox.Show("No se puede generar un recibo anulado","Error");
                return;
            }

            
            //Realizar el recibo

            PnlRecibo recibo = new PnlRecibo(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()),conexion);
            recibo.Show();


        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if(lblFechaInicio.Text == lblFechaFinal.Text)
            {
                MessageBox.Show("No ha digitado la fecha", "Error");
                return;
            }

            //Paneles.PnlGenerarInforme pnlInforme = new Paneles.PnlGenerarInforme(lblFechaInicio.Text,lblFechaFinal.Text,conexion);

            //pnlInforme.Show();
        }
    }
}
