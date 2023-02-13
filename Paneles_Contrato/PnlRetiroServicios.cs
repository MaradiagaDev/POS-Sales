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

namespace NeoCobranza.Paneles_Contrato
{
    public partial class PnlRetiroServicios : Form
    {
        private Conexion conexion;
        private Contrato contrato;
        private CTasaCambio cTasa;
        public PnlRetiroServicios(Conexion conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
            this.contrato = new Contrato(conexion);
            this.cTasa = new CTasaCambio(conexion);

            //Vista
            dgvStock.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9);
            dgvStock.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9);

            dgvBeneficiarios.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9);
            dgvBeneficiarios.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9);

            dgvAtaudes.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9);
            dgvAtaudes.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9);

            dgvFactura.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9);
            dgvFactura.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9);

            //Filtrar general
            dgvStock.DataSource = contrato.Retirados_Listar_Todos(txtFiltro.Texts);

            //Ataudes


            dgvAtaudes.DataSource = contrato.Retirados_Listar_ataudes(cmbCategoria.Text);
        }

        private void txtFiltroId__TextChanged(object sender, EventArgs e)
        {
            if (txtFiltroId.Texts == "")
            {
                return;
            }
            int opc;
            if (int.TryParse(txtFiltroId.Texts, out opc) == false)
            {
                return;
            }
            dgvStock.DataSource = contrato.Retirados_Listar_Todos_PorID(int.Parse(txtFiltroId.Texts));
        }

        private void txtFiltro__TextChanged(object sender, EventArgs e)
        {
            dgvStock.DataSource = contrato.Retirados_Listar_Todos(txtFiltro.Texts);
        }

        private void dgvStock_SelectionChanged(object sender, EventArgs e)
        {

            
            if (dgvStock.SelectedRows.Count == 0)
            {

                

                txtSaldo.Text = "x";
                txtExtra.Text = "x";
                txtSaldoAcum.Text = "x";
                txtEstadoB.Text = "x";
                txtEstadoRetiro.Text = "x";
                txtFallecimiento.Text = "x";
                txtMontoNominalB.Text = "x";
                txtNombreServicio.Text = "x";
                label15.Text = "x";
                label22.Text = "x";
                try
                {
                    dgvBeneficiarios.DataSource = contrato.Contrato_Listar_Beneficiarios(0);
                    cmbServicios.DataSource = contrato.Contrato_ServiciosInfo(0);
                    TxtCantidadS.Maximum = 0;
                
                    cmbCategoria.DataSource = contrato.Retirados_Listar_Estandares(1000000000);

                    dgvAtaudes.DataSource = contrato.Retirados_Listar_ataudes("");
                }
                catch (Exception)
                {

                }

                return;

            }
            //Cambio del saldo
            try
            {


                txtSaldo.Text = contrato.Retiros_Valor_Contrato(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));
            } catch (Exception ex)
            {

            }
            //Servicios

            dgvBeneficiarios.DataSource = contrato.Contrato_Listar_Beneficiarios(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));
            try
            {


                cmbServicios.DataSource = contrato.Contrato_ServiciosInfo(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));
                TxtCantidadS.Maximum = int.Parse(contrato.Contrato_ServiciosInfo_Cantidad(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()), cmbServicios.Text).Rows[0][5].ToString());
               
            }
            catch (Exception)
            {

            }
            try
            {


                TxtCantidadS.Maximum = int.Parse(contrato.Contrato_ServiciosInfo_Cantidad(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()), cmbServicios.Text).Rows[0][5].ToString());
                float monto = float.Parse(contrato.Contrato_ServiciosInfo_Cantidad(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()), cmbServicios.Text).Rows[0][2].ToString());
                int year = int.Parse(contrato.Contrato_Listar_Beneficiarios_individual(int.Parse(dgvBeneficiarios.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][3].ToString());

                if (year == 1)
                {
                    label15.Text = (monto).ToString();
                }
                else if (year == 2)
                {
                    label15.Text = (monto * 1.1).ToString();
                }
                else if (year == 3)
                {
                    label15.Text = (monto * 1.2).ToString();
                }
                else if (year == 4)
                {
                    label15.Text = (monto * 1.25).ToString();
                }
                else if (year == 5)
                {
                    label15.Text = (monto * 1.3).ToString();
                }
                else if (year == 6)
                {
                    label15.Text = (monto * 1.3).ToString();
                }
                else if (year == 7)
                {
                    label15.Text = (monto * 1.3).ToString();
                }

                label22.Text = contrato.Contrato_ServiciosInfo_Cantidad(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()), cmbServicios.Text).Rows[0][5].ToString();
            }
            catch (Exception)
            {

            }

            if (cmbServicios.Text == "")
            {
                label15.Text = "x";
                label22.Text = "x";
            }
        }

        private void dgvBeneficiarios_SelectionChanged(object sender, EventArgs e)
        {
            //Verificar que haya un beneficiario seleccionado
            if (dgvBeneficiarios.SelectedRows.Count == 0)
            {
                txtEstadoB.Text = "x";
                txtNombreServicio.Text = "x";
                txtFallecimiento.Text = "x";
                txtMontoNominalB.Text = "x";
            }
            if (dgvBeneficiarios.SelectedRows.Count > 0)
            {
                if (contrato.Contrato_Listar_Beneficiarios_individual(int.Parse(dgvBeneficiarios.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][0].ToString() == "")
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

                txtFallecimiento.Text = contrato.Contrato_Listar_Beneficiarios_individual(int.Parse(dgvBeneficiarios.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][0].ToString();


                int year = int.Parse(contrato.Contrato_Listar_Beneficiarios_individual(int.Parse(dgvBeneficiarios.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][3].ToString());

                float monto = float.Parse(contrato.Contrato_Listar_Beneficiarios_individual(int.Parse(dgvBeneficiarios.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][2].ToString());

                if (year == 1)
                {
                    txtMontoNominalB.Text = (monto).ToString();
                }
                else if (year == 2)
                {
                    txtMontoNominalB.Text = (monto * 1.1).ToString();
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

                cmbCategoria.DataSource = contrato.Retirados_Listar_Estandares(float.Parse(txtMontoNominalB.Text));
                Cambio();
            }


        }

        private void LLenarCampos()
        {

        }

        private void PnlRetiroServicios_Load(object sender, EventArgs e)
        {

        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

            Cambio();
        }


        private void Cambio ()
        {

            dgvAtaudes.DataSource = contrato.Retirados_Listar_ataudes(cmbCategoria.Text);

            if (cmbCategoria.Text == txtNombreServicio.Text)
            {
                txtExtra.Text = "0";
            }
            else
            {

                if (dgvAtaudes.RowCount == 0)
                {
                    txtExtra.Text = "Modelo sin Stock";
                }
                else
                {
                    txtExtra.Text = (float.Parse(dgvAtaudes.SelectedRows[0].Cells[4].Value.ToString()) - float.Parse(txtMontoNominalB.Text)).ToString();

                }
            }

            try
            {


                if (float.Parse(txtMontoNominalB.Text) > float.Parse(txtSaldo.Text))
                {
                    txtEstadoRetiro.Text = "Saldo insuficiente";
                    txtEstadoRetiro.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {

            }
            try
            {


                if (float.Parse(txtMontoNominalB.Text) < float.Parse(txtSaldo.Text))
                {
                    txtEstadoRetiro.Text = "Saldo suficiente para retirar";
                    txtEstadoRetiro.ForeColor = Color.Green;
                }
            }
            catch (Exception)
            {

            }

            if (txtEstadoB.Text == "Retirado")
            {
                txtEstadoRetiro.Text = "Servicio retirado";
                txtEstadoRetiro.ForeColor = Color.Red;
            }




        }
        private void btnRetiro_Click(object sender, EventArgs e)
        {
            //Verificar que haya algo en la factura
            if(dgvFactura.Rows.Count == 0)
            {
                MessageBox.Show("No hay nada seleccionado","Error");
                return;
            }

            //Crear factura

            contrato.Retiro_RealizarFactura(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()), int.Parse(cTasa.MostrarIdTasa()),conexion.usuario);

            //Hacemos un for para hacer los cambios individuales

            for (int i =0; i < dgvFactura.Rows.Count; i++)
            {
                //Ver si es ataud o servicio


                //----------

                if (dgvFactura.Rows[i].Cells[3].Value.ToString() == "Ataud")
                {
                    //Si es ataud

                    //Actualizacion del historial
                    contrato.Contrato_Insertar_Historial("Retiro de ataud", "Modelo: " + dgvFactura.Rows[i].Cells[4].Value.ToString() + " Tipo: " + dgvFactura.Rows[i].Cells[3].Value.ToString() + " NoSerie: " + dgvFactura.Rows[i].Cells[1].Value.ToString(), conexion.usuario, int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));

                    //cambiar el estado del ataud
                    contrato.Retiro_CambioEstadoAtaud(int.Parse(dgvFactura.Rows[i].Cells[1].Value.ToString()));


                    //cambiar tabla beneficiario
                    contrato.Retiro_Beneficiario(int.Parse(dgvFactura.Rows[i].Cells[0].Value.ToString()),contrato.Retiros_NoSeriexIdAtaud(int.Parse(dgvFactura.Rows[i].Cells[1].Value.ToString())));


                    //Insertar detalle en la factua

                    contrato.Retiro_FacturaDetalles(int.Parse(contrato.Retiros_UltimoRetiroId()), int.Parse(dgvFactura.Rows[i].Cells[0].Value.ToString()), int.Parse(dgvFactura.Rows[i].Cells[1].Value.ToString()),"Ataud", float.Parse(dgvFactura.Rows[i].Cells[6].Value.ToString()));



                }
                else if(dgvFactura.Rows[i].Cells[3].Value.ToString() == "Servicio")
                {
                    //SI es servicio

                    //Actualizacion del historial
                    contrato.Contrato_Insertar_Historial("Retiro de servicios", "Servicio: " + dgvFactura.Rows[i].Cells[4].Value.ToString() + " Tipo: " + dgvFactura.Rows[i].Cells[3].Value.ToString() + " NoSerie: " + dgvFactura.Rows[i].Cells[1].Value.ToString(), conexion.usuario, int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));

                    //Cambiar tabla de servicios
                    contrato.Retiro_Servicios(int.Parse(dgvFactura.Rows[i].Cells[0].Value.ToString()), int.Parse(dgvFactura.Rows[i].Cells[2].Value.ToString()));

                    //Insertar en el detalle de la factura
                    contrato.Retiro_FacturaDetalles(int.Parse(contrato.Retiros_UltimoRetiroId()), int.Parse(dgvFactura.Rows[i].Cells[0].Value.ToString()), 0, "Ataud", 0);



                }


              

           

                

            }





            //Primero ingresar el monto acumulado (Valores del contrato)
            contrato.Contrato_Insertar_Valores(contrato.Retiros_UltimoRetiroId(), 0, float.Parse(txtSaldoAcum.Text), int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()), "FACTURA CONTRATO", cTasa.MostrarTasa());




            //Verificar que no este retirado
            contrato.Retiro_Vefiricar(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));

            MessageBox.Show("Factura realizada","Correcto");

            //Limpiar tabla de facturas
            dgvFactura.Rows.Clear();


            //Filtrar general
            dgvStock.DataSource = contrato.Retirados_Listar_Todos(txtFiltro.Texts);



        }

        private void cmbServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                label22.Text = contrato.Contrato_ServiciosInfo_Cantidad(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()), cmbServicios.Text).Rows[0][5].ToString();
                TxtCantidadS.Maximum = int.Parse(contrato.Contrato_ServiciosInfo_Cantidad(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()), cmbServicios.Text).Rows[0][5].ToString());
               float monto = float.Parse( contrato.Contrato_ServiciosInfo_Cantidad(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()), cmbServicios.Text).Rows[0][2].ToString());
                int year = int.Parse(contrato.Contrato_Listar_Beneficiarios_individual(int.Parse(dgvBeneficiarios.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][3].ToString());

                if (year == 1)
                {
                    label15.Text = (monto).ToString();
                }
                else if (year == 2)
                {
                    label15.Text = (monto * 1.1).ToString();
                }
                else if (year == 3)
                {
                    label15.Text = (monto * 1.2).ToString();
                }
                else if (year == 4)
                {
                    label15.Text = (monto * 1.25).ToString();
                }
                else if (year == 5)
                {
                    label15.Text = (monto * 1.3).ToString();
                }
                else if (year == 6)
                {
                    label15.Text = (monto * 1.3).ToString();
                }
                else if (year == 7)
                {
                    label15.Text = (monto * 1.3).ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        private void BtnCliente_Click(object sender, EventArgs e)
        {
            //Verificar que hay un servicio seleccionado y que la cantidad sea mayor a cero
            if(cmbServicios.Text == "")
            {
                MessageBox.Show("No hay ningun servicio seleccionado");
                return;
            }
            if (TxtCantidadS.Value ==0)
            {
                MessageBox.Show("La cantidad no puede ser cero");
                return;
            }
            //Verificar que el servicio no se haya agregado antes
            for (int i = 0; i < dgvFactura.Rows.Count; i++)
            {

                if (dgvFactura.Rows[i].Cells[4].Value.ToString() == cmbServicios.Text)
                {
                    MessageBox.Show("No se puede agregar dos veces el mismo servicio");
                    return;
                }

            }
            //Verificar el saldo

            float SaldoA = 0;
            float Monto = 0;
            float Saldo = 0;
            if (txtSaldoAcum.Text != "x")
            {
                SaldoA = float.Parse(txtSaldoAcum.Text);
            }

            if (label15.Text != "x")
            {
                Monto = float.Parse(label15.Text) *int.Parse(TxtCantidadS.Value.ToString());
            }

            if (txtSaldo.Text != "x")
            {

                Saldo = float.Parse(txtSaldo.Text);
            }


            if ((SaldoA + Monto) > Saldo)
            {
                MessageBox.Show("Saldo insuficiente", "Error");
                return;
            }
            else
            {
                txtSaldoAcum.Text = (SaldoA + Monto).ToString();

            }




            //Agregar a la tabla

            dgvFactura.Rows.Add(contrato.Contrato_ServiciosInfo(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())).Rows[cmbServicios.SelectedIndex][0].ToString(),
                "-",TxtCantidadS.Value.ToString(),"Servicio",cmbServicios.Text,label15.Text,"-");
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {

            //Verificaciones
            if (txtEstadoB.Text == "Retirado" )
            {

                MessageBox.Show("El servicio ya fue retirado ", "Error");
                return;
            }
            if (dgvAtaudes.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ningun ataud", "Error");
                return;
            }
            if (dgvBeneficiarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay un beneficiario seleccionado", "Error");
                return;
            }
            if (dgvStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay un contrato seleccionado", "Error");
                return;
            }
            //Verificar que el idAtaud y el id beneficiario no se hayan agregado ya a la tabla

            for (int i = 0; i < dgvFactura.Rows.Count; i++)
            {

                if (dgvFactura.Rows[i].Cells[0].Value.ToString() == dgvBeneficiarios.SelectedRows[0].Cells[0].Value.ToString() && dgvFactura.Rows[i].Cells[3].Value.ToString() =="Ataud")
                {
                    MessageBox.Show("No se puede agregar dos veces el mismo beneficiario");
                    return;
                }
                if (dgvFactura.Rows[i].Cells[1].Value.ToString() == dgvAtaudes.SelectedRows[0].Cells[0].Value.ToString())
                {
                    MessageBox.Show("No se puede agregar dos veces el mismo ataud");
                    return;
                }

            }
            float SaldoA = 0;
            float Monto = 0;
            float Saldo = 0;
            if (txtSaldoAcum.Text != "x")
            {
                SaldoA = float.Parse(txtSaldoAcum.Text);
            }

            if (txtMontoNominalB.Text != "x")
            {
                 Monto = float.Parse(txtMontoNominalB.Text);
            }

            if (txtSaldo.Text != "x")
            {

                 Saldo = float.Parse(txtSaldo.Text);
            }


           

            //Verificacion de saldo
            if ((SaldoA + Monto) > Saldo)
            {
                MessageBox.Show("Saldo insuficiente", "Error");
                return;
            }
            else
            {
                txtSaldoAcum.Text = (SaldoA+ Monto).ToString();

            }



            //Agregar a la tabla

            //verificacion saldo
            float monto;

            if (cmbCategoria.Text == txtNombreServicio.Text)
            {
                monto = 0;
            }
            else
            {

                monto = float.Parse(dgvAtaudes.SelectedRows[0].Cells[4].Value.ToString()) - float.Parse(txtMontoNominalB.Text);
            }

            dgvFactura.Rows.Add(dgvBeneficiarios.SelectedRows[0].Cells[0].Value.ToString(),
                dgvAtaudes.SelectedRows[0].Cells[0].Value.ToString(),
                "1",
                "Ataud",
                 txtNombreServicio.Text,
                txtMontoNominalB.Text,
              monto.ToString()
                );




        }

        private void dgvStock_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            //Verificacion de que haya una fila seleccionada

            if (dgvStock.Rows.Count == 0)
            {
                MessageBox.Show("No hay fila seleccionada", "Error");
                return;
            }

            PnlGeneralContrato pnlGeneral = new PnlGeneralContrato(conexion, dgvStock.SelectedRows[0].Cells[0].Value.ToString());

            PnlPrincipal pnlPrincipal = Owner as PnlPrincipal;
            pnlGeneral.TopLevel = false;
            pnlPrincipal.PnlCentral.Controls.Add(pnlGeneral);



            pnlGeneral.Show();

            this.Close();
        }
    }
}
