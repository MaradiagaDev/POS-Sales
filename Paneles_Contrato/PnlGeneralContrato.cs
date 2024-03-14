using NeoCobranza.Clases;
using NeoCobranza.Data;
using NeoCobranza.DataController;
using NeoCobranza.Paneles;
using NeoCobranza.Paneles_Colectores;
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

             dgvModificaciones.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvModificaciones.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);


            dgvStock.DataSource = contrato.Contrato_Listar_Todos(txtFiltro.Texts);

           
        }

        //Constructor para Doble click
        public PnlGeneralContrato(Conexion conexion, string id)
        {
            InitializeComponent();

            this.conexion = conexion;
            this.contrato = new Contrato(conexion);
            this.tasa = new CTasaCambio(conexion);


            //estilo
            dgvStock.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            dgvStock.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);

            dgvBeneficiarios.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            dgvBeneficiarios.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);

            dgvServicios.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            dgvServicios.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);

            dgvEconomica.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            dgvEconomica.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);

            dgvModificaciones.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            dgvModificaciones.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);

            dgvActivos.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            dgvActivos.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);

            dgvStock.DataSource = contrato.Contrato_Listar_Todos_PorID(int.Parse(id));


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

            dgvModificaciones.DataSource = contrato.Contrato_Filtrar_Modificaciones(txtFiltroModificaciones.Texts, int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));

            //INformacion de otros servicios

            dgvServicios.DataSource = contrato.Contrato_ServiciosInfo(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));
            
            //Informacion Economica

            dgvEconomica.DataSource = contrato.Contrato_ApartadoEconomico(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));

            //LLenar la informacion economica

            txtTotalAcumulado.Text = Math.Round(float.Parse(contrato.Contrato_Reporteria_Totales(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][0].ToString()),2).ToString();

            //REVALORIZACION ------

            try
            {


                lblSaldoActual.Text = contrato.Retiros_Valor_Contrato(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));
            }
            catch (Exception ex)
            {
                lblSaldoActual.Text = "0";
            }






            //Obtener los beneficiarios activos en la revalorizacion

            dgvActivos.DataSource = contrato.Beneficiario_Mostrar_Activos(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));

            float prueba;
            if(float.TryParse(contrato.Retiros_Retirado_Contrato(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString())),out prueba) == false)
            {
                return;
            }
            else
            {
                txtTotalRetirado.Text = Math.Round(float.Parse(contrato.Retiros_Retirado_Contrato(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()))), 2).ToString();

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
            else
            {
                //limpiar en caso de que no haya un contrato seleccionado
                txtPropietario.Text = "x";
                txtFechaA.Text = "x";
                txtFechaC.Text = "x";
                txtValorCuota.Text = "x";
                txtValorNominal.Text = "x";
                txtEstado.Text = "x";
                txtModalidad.Text = "x";
                txtAcum.Text = "x";
                txtPagadas.Text = "x";
                txtCuotasTotales.Text = "x";
                txtSituacion.Text = "x";
                txtDescripcion.Text = "";

                //Panel de beneficiarios

                dgvBeneficiarios.DataSource = contrato.Contrato_Listar_Beneficiarios(0);

                txtEstadoB.Text = "x";
                txtFallecimiento.Text = "x";
                txtNombreServicio.Text = "x";
                txtMontoNominalB.Text = "x";

                //Panel de otros servicios

                dgvServicios.DataSource = contrato.Contrato_ServiciosInfo(0);

                TxtEstadoServicio.Text = "x";
                txtNombreServiciosS.Text = "x";
                txtMontoNominalServicio.Text = "x";
                txtCantidadServicios.Text = "x";

                //Panel informacion economica

                dgvEconomica.DataSource = contrato.Contrato_ApartadoEconomico(0);

                txtIdContrato.Text = "x";
                txtAcumuladoCordoba.Text = "x";
                txtTotalAcumulado.Text = "x";
                txtSaldoDisponible.Text = "x";
                txtTotalRetirado.Text = "x";

                //Historial de modificaciones



                dgvModificaciones.DataSource = contrato.Contrato_Filtrar_Modificaciones(txtFiltroModificaciones.Texts, 0);

                dgvActivos.DataSource = contrato.Beneficiario_Mostrar_Activos(0);

                dgvRetirados.Rows.Clear();

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

                    txtMontoNominalB.Text =(monto).ToString();
               

            
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
            PnlActualizarBeneficiario actualizarBeneficiario = new PnlActualizarBeneficiario(conexion, int.Parse(dgvBeneficiarios.SelectedRows[0].Cells[0].Value.ToString()), int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));

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
                if (dgvServicios.SelectedRows[0].Cells[4].Value.ToString() == dgvServicios.SelectedRows[0].Cells[5].Value.ToString())
                {
                    TxtEstadoServicio.Text = "Retirado";
                }
                else
                {
                    TxtEstadoServicio.Text = "Sin retirar";
                }

                txtNombreServiciosS.Text = dgvServicios.SelectedRows[0].Cells[3].Value.ToString();

                txtCantidadServicios.Text = contrato.Contrato_ApartadoServicio(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()), int.Parse(dgvServicios.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][5].ToString();
                float monto = float.Parse(dgvServicios.SelectedRows[0].Cells[2].Value.ToString());
                int year = int.Parse(contrato.Contrato_ApartadoServicio(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()), int.Parse(dgvServicios.SelectedRows[0].Cells[0].Value.ToString())).Rows[0][4].ToString());
               
                
                    txtMontoNominalServicio.Text = (monto).ToString();
                
            }
            catch (Exception ex)

            {
                
            }
        }

        private void BtnRefrescarGeneral_Click(object sender, EventArgs e)
        {
            dgvStock.DataSource = contrato.Contrato_Listar_Todos(txtFiltro.Texts);
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
            if (dgvStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay contrato seleccionado", "Error");
                return;
            }

            contrato.Contrato_Insertar_Historial("Se genero el estado economico del contrato", "GENERACION DE ESTADO ECONOMICO", conexion.usuario, int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));

            PnlInformeEconomico informeEconomico = new PnlInformeEconomico(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()),conexion);
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
                dgvEconomica.SelectedRows[0].Cells[7].Value.ToString(),
                int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));

            pnlActualizarPago.Show();

        }

        private void BtnCliente_Click(object sender, EventArgs e)
        {
            Panel_Cliente_Contrato panelCliente = new Panel_Cliente_Contrato("ActualizarContrato");
            AddOwnedForm(panelCliente);
            panelCliente.Show();
        }

        private void btnColector_Click(object sender, EventArgs e)
        {
            //PnlVendedores
            PnlColector pnlVendedores = new PnlColector(conexion, "ActualizarContrato");
            AddOwnedForm(pnlVendedores);
            pnlVendedores.Show();

          

        }

        private void BtnActualizarPropietario_Click(object sender, EventArgs e)
        {
            if(lblNombreCliente.Text == ".")
            {
                MessageBox.Show("No ha seleccionado un cliente","Error");
                return;
            }
            if (dgvStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado un contrato", "Error");
                return;
            }
            contrato.Contrato_Insertar_Historial("Cambio de propietario","Propietario anterior: " + txtPropietario.Text, conexion.usuario, int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));
            contrato.Contrato_Actualizar_Propietario(int.Parse(lblIdCliente.Text), int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));

            lblNombreCliente.Text = ".";
            lblIdCliente.Text = ".";
            lblEstadoCliente.Text = "Sin Registrar";
            lblEstadoCliente.ForeColor = Color.Red;

        }

        private void BtnActualizarColector_Click(object sender, EventArgs e)
        {
            if (LblNombreColector.Text == ".")
            {
                MessageBox.Show("No ha seleccionado un colector", "Error");
                return;
            }
            if (dgvStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado un contrato", "Error");
                return;
            }

            contrato.Contrato_Insertar_Historial("Actualizar colector","Colector anterior: " + dgvStock.SelectedRows[0].Cells[16].Value.ToString(), conexion.usuario, int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));

            contrato.Contrato_Actualizar_Colector(int.Parse(txtIdColector.Text), int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));

            LblNombreColector.Text = ".";
            txtIdColector.Text = ".";
        }

        private void BtnActualizarDescripcion_Click(object sender, EventArgs e)
        {
            if (txtActualizarDescripcion.Text == "")
            {
                MessageBox.Show("La descripcion esta en blanco", "Error");
                return;
            }
            if (dgvStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado un contrato", "Error");
                return;
            }

            contrato.Contrato_Insertar_Historial("Actualizacion de descripcion", "Descripcion anterior: " + txtDescripcion.Text, conexion.usuario, int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));

            contrato.Contrato_Actualizar_Descripcion(txtActualizarDescripcion.Text, int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));

        }

        private void txtFiltroModificaciones__TextChanged(object sender, EventArgs e)
        {
            dgvModificaciones.DataSource = contrato.Contrato_Filtrar_Modificaciones(txtFiltroModificaciones.Texts, int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay contrato seleccionado","Error");
                return;
            }

            contrato.Contrato_Insertar_Historial("Se genero el contrato","GENERACION DE CONTRATO", conexion.usuario, int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));

        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            LLenarCampos();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            dgvModificaciones.DataSource = contrato.Contrato_Filtrar_Modificaciones_Fecha(lblFecha.Text, lblFechaF.Text, int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));

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
            dgvStock.DataSource = contrato.Contrato_Listar_Todos_PorID(int.Parse(txtFiltroId.Texts));
        }

        private void BtnSeleccionarRetirado_Click(object sender, EventArgs e)
        {
            //Verificar que el panel de activos tenga algo seleccionado

            if (dgvActivos.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay ningun beneficiario seleccionado","Error");
                return;
            }

            //Verificar que el dato no sea agregado con anterioridad


            for(int i=0; i<dgvRetirados.SelectedRows.Count; i++)
            {
                if (dgvActivos.SelectedRows[0].Cells[0].Value.ToString() == dgvRetirados.SelectedRows[0].Cells[0].Value.ToString())
                {
                    MessageBox.Show("El beneficiario ya ha sido agregado", "Error");
                    return;
                }
            }
            //agregar a la tabla

            dgvRetirados.Rows.Add(dgvActivos.SelectedRows[0].Cells[0].Value.ToString(), dgvActivos.SelectedRows[0].Cells[1].Value.ToString());
        }

        private void dgvRetirados_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if(lblSaldoActual.Text == "0")
            {
                return;
            }
            else
            {
        }

                lblDividido.Text = (float.Parse(lblSaldoActual.Text) / dgvRetirados.Rows.Count).ToString();
            }
        private void BtnEliminarRev_Click(object sender, EventArgs e)
        {
            if(dgvRetirados.SelectedRows.Count == 0)
            {
                return;
            }
            else
            {
                dgvRetirados.Rows.Remove(dgvRetirados.CurrentRow);

                if(dgvRetirados.Rows.Count == 0)
                {
                    lblDividido.Text = "0";
                }
                else
                {
                    lblDividido.Text = (float.Parse(lblSaldoActual.Text) / dgvRetirados.Rows.Count).ToString();
                }
               


            }
        }

        private void especialButton4_Click(object sender, EventArgs e)
        {
            if(lblDividido.Text =="0" || lblDividido.Text == "x")
            {
                MessageBox.Show("El monto no es valido","Error");
                return;
            }
            
            else
            {
                //Variable de confirmacion 

                bool estado= false;

                //Iteracion de los beneficiarios actuales

                for(int i = 0; i< dgvActivos.Rows.Count; i++)
                {
                    estado = false;

                    //Iteracion de los beneficiarios a retirar

                    for (int x = 0; x < dgvRetirados.Rows.Count;x++)
                    {
                        //Verificar que exista un beneficiario activo en los revalorizados
                       

                        if (dgvActivos.Rows[i].Cells[0].Value.ToString() == dgvRetirados.Rows[x].Cells[0].Value.ToString()) 
                        {

                            estado=true;


                        }

                    }

                    //Confirmar si estaba en la lista

                    if(estado == true)
                    {
                        

                        contrato.Revalorizacion_Beneficiario(int.Parse(dgvActivos.Rows[i].Cells[0].Value.ToString()),float.Parse(lblDividido.Text));

                    }
                    else
                    {

                        contrato.Revalorizacion_Desactivar(int.Parse(dgvActivos.Rows[i].Cells[0].Value.ToString()));

                    }
                }

                //Revalorizacion final

                contrato.Revalorizacion_Contrato(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));

                MessageBox.Show("Contrato revalorizado","Correcto");
            }

        }
    }
    }

