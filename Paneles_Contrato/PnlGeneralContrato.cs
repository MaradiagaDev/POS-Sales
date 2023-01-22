using NeoCobranza.Clases;
using NeoCobranza.Data;
using NeoCobranza.DataController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles_Contrato
{
    public partial class PnlGeneralContrato : Form
    {
        //Clase a utilizar
        private Contrato contrato;
        private Conexion conexion;
        private CTasaCambio tasa;


        public PnlGeneralContrato(Conexion conexion)
        {
            InitializeComponent();

            this.conexion = conexion;
            this.contrato = new Contrato(conexion);
            this.tasa = new CTasaCambio(conexion);
            //estilo
            dgvStock.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvStock.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);

            dgvBeneficiarios.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvBeneficiarios.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);

            dgvServicios.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvServicios.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);

            dgvEconomica.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvEconomica.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);


            dgvStock.DataSource = contrato.Contrato_Listar_Todos(txtFiltro.Texts);
        }

        private void dgvStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LLenarCampos()
        {
            txtIdContrato.Text = dgvStock.SelectedRows[0].Cells[0].Value.ToString();

            txtPropietario.Text = dgvStock.SelectedRows[0].Cells[1].Value.ToString();
            txtFechaA.Text = dgvStock.SelectedRows[0].Cells[8].Value.ToString();
            txtFechaC.Text = dgvStock.SelectedRows[0].Cells[9].Value.ToString();
            txtValorNominal.Text =Math.Round(double.Parse( dgvStock.SelectedRows[0].Cells[12].Value.ToString()),2).ToString();
            txtValorCuota.Text = Math.Round(float.Parse(dgvStock.SelectedRows[0].Cells[7].Value.ToString()),2).ToString();
            txtDescripcion.Text = dgvStock.SelectedRows[0].Cells[13].Value.ToString();
            txtEstado.Text = dgvStock.SelectedRows[0].Cells[14].Value.ToString();
            txtModalidad.Text = dgvStock.SelectedRows[0].Cells[2].Value.ToString();

            txtCuotasTotales.Text = dgvStock.SelectedRows[0].Cells[10].Value.ToString();
            txtSituacion.Text = dgvStock.SelectedRows[0].Cells[11].Value.ToString();

            txtAcum.Text = Math.Round(float.Parse( contrato.Contrato_Listar_Montos(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][1].ToString()),2).ToString();
            txtPagadas.Text = contrato.Contrato_Listar_Montos(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][0].ToString();

            dgvBeneficiarios.DataSource = contrato.Contrato_Listar_Beneficiarios(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));


            //INformacion de otros servicios

            dgvServicios.DataSource = contrato.Contrato_ServiciosInfo(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));
            
            //Informacion Economica

            dgvEconomica.DataSource = contrato.Contrato_ApartadoEconomico(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));

            //LLenar la informacion economica

            txtTotalAcumulado.Text = Math.Round(float.Parse(contrato.Contrato_Reporteria_Totales(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][0].ToString()),2).ToString();
            if (contrato.Contrato_Reporteria_Totales(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][1].ToString() != "")
            {
                txtTotalRetirado.Text = Math.Round(float.Parse(contrato.Contrato_Reporteria_Totales(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][1].ToString()),2).ToString();
            }
            else
            {
                txtTotalRetirado.Text = "0";
            }


            //Saldo disponible

            txtSaldoDisponible.Text = (Math.Round(float.Parse(txtTotalAcumulado.Text) - float.Parse(txtTotalRetirado.Text),2)).ToString();

            //Acumulado en cordobas

            txtAcumuladoCordoba.Text = Math.Round(float.Parse(txtTotalAcumulado.Text) * float.Parse(tasa.MostrarTasa()),2).ToString();
        }

        private void txtFiltro__TextChanged(object sender, EventArgs e)
        {
            dgvStock.DataSource = contrato.Contrato_Listar_Todos(txtFiltro.Texts);
        }

        private void dgvStock_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvStock.SelectedRows.Count > 0)
            {
                LLenarCampos();
            }
        }

        private void dgvBeneficiarios_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvBeneficiarios.SelectedRows.Count == 0)
            {
                txtEstadoB.Text = "x";
                txtNombreServicio.Text = "x";
                txtFallecimiento.Text = "x";
                txtMontoNominalB.Text = "x";
            }

            if(dgvBeneficiarios.SelectedRows.Count > 0)
            {
                if(contrato.Contrato_Listar_Beneficiarios_individual(int.Parse(dgvBeneficiarios.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][0].ToString() == "")
                {
                    txtEstadoB.ForeColor = Color.YellowGreen;
                    txtEstadoB.Text = "Sin retirar";
                }
                else
                {
                    txtEstadoB.ForeColor = Color.Red;
                    txtEstadoB.Text = "Retirado";
                }

                txtNombreServicio.Text = contrato.Contrato_Listar_Beneficiarios_individual(int.Parse(dgvBeneficiarios.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][1].ToString();

                txtFallecimiento.Text =contrato.Contrato_Listar_Beneficiarios_individual(int.Parse(dgvBeneficiarios.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][0].ToString();


                int year = int.Parse(contrato.Contrato_Listar_Beneficiarios_individual(int.Parse(dgvBeneficiarios.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][3].ToString());

                float monto = float.Parse(contrato.Contrato_Listar_Beneficiarios_individual(int.Parse(dgvBeneficiarios.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][2].ToString());

                if(year == 1)
                {
                    txtMontoNominalB.Text =(monto).ToString();
                }else if(year ==2)
                {
                    txtMontoNominalB.Text = (monto*1.1).ToString();
                }
                else if (year == 3)
                {
                    txtMontoNominalB.Text = (monto * 1.2).ToString();
                }
                else if (year == 4)
                {
                    txtMontoNominalB.Text = (monto * 1.25).ToString();
                }
                else if (year == 5)
                {
                    txtMontoNominalB.Text = (monto * 1.3).ToString();
                }
                else if (year == 6)
                {
                    txtMontoNominalB.Text = (monto * 1.3).ToString();
                }
                else if (year == 7)
                {
                    txtMontoNominalB.Text = (monto * 1.3).ToString();
                }

            
            }
        }

        private void especialButton2_Click(object sender, EventArgs e)
        {
            dgvBeneficiarios.DataSource = contrato.Contrato_Listar_Beneficiarios(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));
        }

        private void btnActualizarBeneficiario_Click(object sender, EventArgs e)
        {
            //Verificar que haya un beneficiario seleccionado
            if (dgvBeneficiarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay beneficiario seleccionado", "Error");
                return;
            }
            if(txtEstadoB.Text != "Sin retirar")
            {
                MessageBox.Show("No se puede actualizar un beneficiario que ya fallecio", "Error");
                return;
            }

            //Panel
            PnlActualizarBeneficiario actualizarBeneficiario = new PnlActualizarBeneficiario(conexion, int.Parse(dgvBeneficiarios.SelectedRows[0].Cells[0].Value.ToString()));

            AddOwnedForm(actualizarBeneficiario);

            actualizarBeneficiario.txtIdBeneficiario.Text = dgvBeneficiarios.SelectedRows[0].Cells[0].Value.ToString();


            actualizarBeneficiario.Show();
        }

        private void dgvServicios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvServicios.SelectedRows.Count == 0)
            {
                TxtEstadoServicio.Text = "x";
                txtMontoNominalServicio.Text = "x";
                txtNombreServiciosS.Text = "x";
                txtCantidadServicios.Text = "x";

            }

            try
            {
                if (dgvServicios.SelectedRows[0].Cells[1].Value.ToString() == "Activo")
                {
                    TxtEstadoServicio.Text = "Sin retirar";
                }
                else
                {
                    TxtEstadoServicio.Text = "Retirado";
                }

                txtNombreServiciosS.Text = dgvServicios.SelectedRows[0].Cells[3].Value.ToString();

                txtCantidadServicios.Text = contrato.Contrato_ApartadoServicio(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()), int.Parse(dgvServicios.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][5].ToString();
                float monto = float.Parse(dgvServicios.SelectedRows[0].Cells[2].Value.ToString());
                int year = int.Parse(contrato.Contrato_ApartadoServicio(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()), int.Parse(dgvServicios.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][4].ToString());
                if (year == 1)
                {
                    txtMontoNominalServicio.Text = (monto).ToString();
                }
                else if (year == 2)
                {
                    txtMontoNominalServicio.Text = (monto * 1.1).ToString();
                }
                else if (year == 3)
                {
                    txtMontoNominalServicio.Text = (monto * 1.2).ToString();
                }
                else if (year == 4)
                {
                    txtMontoNominalServicio.Text = (monto * 1.25).ToString();
                }
                else if (year == 5)
                {
                    txtMontoNominalServicio.Text = (monto * 1.3).ToString();
                }
                else if (year == 6)
                {
                    txtMontoNominalServicio.Text = (monto * 1.3).ToString();
                }
                else if (year == 7)
                {
                    txtMontoNominalServicio.Text = (monto * 1.3).ToString();
                }
            }
            catch (Exception ex)

            {
                
            }
        }

        private void BtnRefrescarGeneral_Click(object sender, EventArgs e)
        {
            LLenarCampos();
        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void especialButton3_Click(object sender, EventArgs e)
        {
            LLenarCampos();
        }

        private void BtnRecibo_Click(object sender, EventArgs e)
        {
            PnlInformeEconomico informeEconomico = new PnlInformeEconomico(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));
            informeEconomico.Show();
        }

        private void BtnActualizarPago_Click(object sender, EventArgs e)
        {
            //Verificar que haya algo seleccionada
            if(dgvEconomica.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay ninguna cuota seleccionada", "Error");
                return;
            }

            //Verificar que se a la cuota futura
            if ((dgvEconomica.SelectedRows[0].Index+1) == dgvEconomica.Rows.Count)
            {
                MessageBox.Show("No se puede actualizar la cuota futura","Error");
                return;
            }

            //LLamar al panel
            
            PnlActualizarPago pnlActualizarPago = new PnlActualizarPago(conexion,
                int.Parse(dgvEconomica.SelectedRows[0].Cells[0].Value.ToString()),
                float.Parse(dgvEconomica.SelectedRows[0].Cells[3].Value.ToString()),
                int.Parse(dgvEconomica.SelectedRows[0].Cells[4].Value.ToString()),
                dgvEconomica.SelectedRows[0].Cells[7].Value.ToString());

            pnlActualizarPago.Show();

        }
    }
    }

