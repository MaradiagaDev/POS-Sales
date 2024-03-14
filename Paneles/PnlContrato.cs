using NeoCobranza.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeoCobranza.DataController;
using NeoCobranza.Poo;
using System.Security.Policy;
using NeoCobranza.Clases_de_Contrato;
using NeoCobranza.Clases;
using System.Threading;
using NeoCobranza.Paneles_Contrato;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace NeoCobranza.Paneles
{

    public partial class PnlContrato : Form
    {
        public  Conexion conexion;
        
        public Panel_Cliente_Contrato panelCliente;
        public CGeneral cGeneral;
        public PnlVendedores pnlVendedores;
        public PnlBeneficiario pnlBeneficiario;
        public CContrato cContrato;
        public ProformaContrato proformaContrato;

        public CTasaCambio cTasa;
        
        public PnlContrato(Conexion conexion)
        {
            InitializeComponent();

            cContrato= new CContrato(conexion);
            cTasa= new CTasaCambio(conexion);   
            this.conexion = conexion;
            pnlVendedores = new PnlVendedores(conexion,"Contrato");
            AddOwnedForm(pnlVendedores);
            
            panelCliente = new Panel_Cliente_Contrato("Contrato");
            AddOwnedForm(panelCliente);
            cGeneral = new CGeneral(conexion);

            proformaContrato = new ProformaContrato(conexion);
           
            cmbFirma.DataSource = cGeneral.MostrarFirmas();
            cmbFirma.ValueMember = "Nombres";

            dgvBenficiarios.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvBenficiarios.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);

            cmbServicios.DataSource = proformaContrato.Listar_Servicios();
            cmbServicios.ValueMember = "NombreEstandar";

        }



        private void BtnCliente_Click(object sender, EventArgs e)
        {
            AddOwnedForm(panelCliente);


            panelCliente.Show();
            
        }
   

        private void PnlContrato_ControlRemoved(object sender, ControlEventArgs e)
        {
            
        }

        private void PnlContrato_Load(object sender, EventArgs e)
        {

        }

        private void PnlContrato_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void PanelCenter_VisibleChanged(object sender, EventArgs e)
        {
         
            
        }

        private void especialButton3_Click(object sender, EventArgs e)
        {
        }

        private void especialButton2_Click(object sender, EventArgs e)
        {

            
            
            pnlVendedores.Show();
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            if(dgvBenficiarios.Rows.Count == 7)
            {
                
                    MessageBox.Show("El limite de beneficiarios es 7", "ERROR");
                    return;
                
            }
            pnlBeneficiario = new PnlBeneficiario(conexion);

            this.AddOwnedForm(pnlBeneficiario);

            pnlBeneficiario.Show();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void lblEstadoCliente_TextChanged(object sender, EventArgs e)
        {
           lblIdCliente.Text= cGeneral.BuscarIdCliente(lblNombreCliente.Text);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            //Verificaciones
            // VERIFICAR QUE YA SE HAYA GENERADO UNA CUOTA
            if (lblCuotas.Text == "x" || lblCuotaCordoba.Text == "x" || lblCuotaDolar.Text == "x")
            {
                MessageBox.Show("Digite una cuota valida", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
            ////VERIFICAR QUE LOS DATOS NO SE HAYAN CAMBIADO DESPUES DE GENERAR UNA CUOTA
            //int cantidadBeneficiarios = dgvBenficiarios.Rows.Count;



            //if (cantidadBeneficiarios == 1 && int.Parse(cmbCancelacion.Text) > 3)
            //{
            //    MessageBox.Show("Si solo hay un beneficiario el plazo maximo es para 3 años2", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    lblCuotaCordoba.Text = "x";
            //    lblCuotaDolar.Text = "x";
            //    lblCuotas.Text = "x";
            //    return;
            //}

            //if (cantidadBeneficiarios == 2 && int.Parse(cmbCancelacion.Text) > 5)
            //{
            //    MessageBox.Show("Para dos beneficiarios el plazo maximo es de 5 años", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    lblCuotaCordoba.Text = "x";
            //    lblCuotaDolar.Text = "x";
            //    lblCuotas.Text = "x";
            //    return;
            //}

            //if (cantidadBeneficiarios == 3 && int.Parse(cmbCancelacion.Text) > 6)
            //{
            //    MessageBox.Show("Para tres beneficiarios el plazo maximo es de 6 años", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    lblCuotaCordoba.Text = "x";
            //    lblCuotaDolar.Text = "x";
            //    lblCuotas.Text = "x";
            //    return;
            //}

            //PRUEBA DE ESTO
           

            verificar();

            DialogResult Result;
            Result =MessageBox.Show("¿Esta seguro de crear el contrato ?", "Advertencia de creacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
          

            if (Result == DialogResult.Yes)
            {
                //valor nominal total
                float[] nominales = new float[dgvBenficiarios.Rows.Count + dgvServicios.Rows.Count];
                for (int i = 0; i < dgvBenficiarios.Rows.Count ; i++)
                {
                    nominales[i] = float.Parse(dgvBenficiarios.Rows[i].Cells[12].Value.ToString());

                    
                }
                //valor nominal total servicios
                float[] nominalesS = new float[ dgvServicios.Rows.Count];
                for (int i = 0; i < dgvServicios.Rows.Count; i++)
                {
                    nominalesS[i] = float.Parse(dgvServicios.Rows[i].Cells[2].Value.ToString())* int.Parse(dgvServicios.Rows[i].Cells[1].Value.ToString());

                }


                double total = nominales.Sum() + nominalesS.Sum();
                double final =0;

                if (int.Parse(cmbCancelacion.Text) == 1)
                {
                    final = (total);
                }
                else if (int.Parse(cmbCancelacion.Text) == 2)
                {
                    final = (total * 1.1);
                }
                else if (int.Parse(cmbCancelacion.Text) == 3)
                {
                    final = (total * 1.2);
                }
                else if (int.Parse(cmbCancelacion.Text) == 4)
                {
                    final = (total * 1.25);
                }
                else if (int.Parse(cmbCancelacion.Text) == 5)
                {
                    final = (total * 1.3);
                }
                else if (int.Parse(cmbCancelacion.Text) == 6)
                {
                    final = (total * 1.3);
                }
                else if (int.Parse(cmbCancelacion.Text) == 7)
                {
                    final = (total * 1.3);
                }

                //Crear el contrato

                Contrato contrato = new Contrato(conexion);

                Calculos();

                string modalidad ="";
                if (rbtnMensual.Checked)
                {
                    modalidad = "Mensual";
                }
                if (rbtnQuincenal.Checked)
                {
                    modalidad = "Quincenal";
                }
                if (rbtnTrimestral.Checked)
                {
                    modalidad = "Trimestral";
                }

                //Creacion de contrato
                contrato.Contrato_Agregar(int.Parse(cmbCancelacion.Text), int.Parse(lblCuotas.Text),  float.Parse(final.ToString()), float.Parse(lblCuotaDolar.Text), txtObservaciones.Text, int.Parse(cContrato.MostrarIdFirma(cmbFirma.Text)), int.Parse(cTasa.MostrarIdTasa()), int.Parse(lblIdColector.Text), modalidad);

                


                for (int i = 0; i < dgvBenficiarios.Rows.Count ; i++)
                {

                    //Se obtiene el preio
                    float monto = float.Parse(contrato.Contrato_Estandar_PrecioxID(int.Parse(cContrato.MostrarIdAtaud(dgvBenficiarios.Rows[i].Cells[11].Value.ToString()))));

                    int year = int.Parse(cmbCancelacion.Text);

                    //se calcula el interes
                    if (year == 1)
                    {
                        monto = monto;
                    }
                    else if (year == 2)
                    {
                        monto = (float)(monto * 1.1);
                    }
                    else if (year == 3)
                    {
                        monto = (float)(monto * 1.2);
                    }
                    else if (year == 4)
                    {
                        monto = (float)(monto * 1.25);
                    }
                    else if (year == 5)
                    {
                        monto = (float)(monto * 1.3);
                    }
                    else if (year == 6)
                    {
                        monto = (float)(monto * 1.3);
                    }
                    else if (year == 7)
                    {
                        monto = (float)(monto * 1.3);
                    }



                    cContrato.AgregarBeneficiario(
                      dgvBenficiarios.Rows[i].Cells[0].Value.ToString(),
                      dgvBenficiarios.Rows[i].Cells[1].Value.ToString(),
                      dgvBenficiarios.Rows[i].Cells[2].Value.ToString(),
                      dgvBenficiarios.Rows[i].Cells[3].Value.ToString(),
                      dgvBenficiarios.Rows[i].Cells[8].Value.ToString(),
                      dgvBenficiarios.Rows[i].Cells[7].Value.ToString(),
                      dgvBenficiarios.Rows[i].Cells[9].Value.ToString(),
                      dgvBenficiarios.Rows[i].Cells[6].Value.ToString(),
                      dgvBenficiarios.Rows[i].Cells[4].Value.ToString(),
                      int.Parse(cContrato.MostrarIdContrato()),
                      dgvBenficiarios.Rows[i].Cells[10].Value.ToString(),
                      int.Parse(cContrato.MostrarIdAtaud(dgvBenficiarios.Rows[i].Cells[11].Value.ToString())),
                      monto
                      ) ;
                   
                   
                   
                }
                //Agregar servicios
                for (int i = 0; i < dgvServicios.Rows.Count; i++)
                {
                    //Monto por servicios
                    //Se obtiene el preio
                    float monto = float.Parse(dgvServicios.Rows[i].Cells[2].Value.ToString());

                    int year = int.Parse(cmbCancelacion.Text);

                    //se calcula el interes
                    if (year == 1)
                    {
                        monto = monto;
                    }
                    else if (year == 2)
                    {
                        monto = (float)(monto * 1.1);
                    }
                    else if (year == 3)
                    {
                        monto = (float)(monto * 1.2);
                    }
                    else if (year == 4)
                    {
                        monto = (float)(monto * 1.25);
                    }
                    else if (year == 5)
                    {
                        monto = (float)(monto * 1.3);
                    }
                    else if (year == 6)
                    {
                        monto = (float)(monto * 1.3);
                    }
                    else if (year == 7)
                    {
                        monto = (float)(monto * 1.3);
                    }






                    contrato.Contrato_Servicios(int.Parse(cContrato.MostrarIdContrato()), int.Parse(dgvServicios.Rows[i].Cells[1].Value.ToString()), monto,"Activo" ,int.Parse(cContrato.MostrarIdAtaud(dgvServicios.Rows[i].Cells[0].Value.ToString()))
                    );


                }
                //asociar al contrato con el cliente

                cContrato.AgregarClienteContrato(int.Parse(lblIdCliente.Text), int.Parse(cContrato.MostrarIdContrato()));

                MessageBox.Show("Contrato creado con exito!");

                contrato.Contrato_Insertar_Historial("Apertura de contrato",cContrato.MostrarIdContrato(),conexion.usuario, int.Parse(cContrato.MostrarIdContrato()));
                
                //Generar el pago de la ultima cuota
                contrato.Contrato_PagoCuota(0,0,0,1, int.Parse(cContrato.MostrarIdContrato()),"");

                //Abrir el otro panel
                PnlPagoCuotas pnlGeneral = new PnlPagoCuotas(conexion, cContrato.MostrarIdContrato());

                PnlPrincipal pnlPrincipal = Owner as PnlPrincipal;
                pnlPrincipal.limpiar();
                pnlPrincipal.AddOwnedForm(pnlGeneral);

                pnlGeneral.TopLevel = false;
                pnlGeneral.Dock = DockStyle.Fill;
                pnlPrincipal.PnlCentral.Controls.Add(pnlGeneral);
                pnlPrincipal.Tag = pnlGeneral;


                pnlGeneral.Show();





                this.Close();

            }
            else
            {
               
                return; //Con este comando, dejamos lo que estuvieramos haciendo sin efecto
            }

        }

        private bool verificar()
        {
            if (lblEstadoCliente.Text == "Sin Registrar")
            {
                MessageBox.Show("Debe Registrar un cliente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            int i;
            if (int.TryParse(cmbCancelacion.Text, out i) == false)
            {

                MessageBox.Show("Seleccione la cantidad de años correcta", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;

            }

            if (lblIdColector.Text == ".")
            {
                MessageBox.Show("Aun no ha seleccionado al vendedor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (rbtnQuincenal.Checked == false && rbtnMensual.Checked == false && rbtnTrimestral.Checked == false)
            {
                MessageBox.Show("Seleccione la modalidad de pago", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (dgvBenficiarios.Rows.Count == 0 && dgvServicios.Rows.Count == 0)
            {
                MessageBox.Show("Digite un Beneficiario o un servicio", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (cmbFirma.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Seleccione una Firma de compañia", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cmbCancelacion.Text == "")
            {
                MessageBox.Show("Seleccione un año de cancelacion", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        
    }
        
        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            if (verificar() == false)
            {
                return;
            }
            try
            {


                Calculos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void BtnEliminarBeneficiario_Click(object sender, EventArgs e)
        {
            
            if (dgvBenficiarios.Rows.Count == 0)
            {
                MessageBox.Show("No hay beneficiarios seleccionados", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                dgvBenficiarios.Rows.Remove(dgvBenficiarios.CurrentRow);
            }
        }

        private void lblNombreCliente_TextChanged(object sender, EventArgs e)
        {
            lblIdCliente.Text = cGeneral.BuscarIdCliente(lblNombreCliente.Text);
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void limpiar()
        {
            //BORRADO DEL CLIENTE
            lblNombreCliente.Text = "";
            lblIdCliente.Text = "";
            lblEstadoCliente.Text = "";
            //BORRADO DEL VENDEDOR
            lblIdColector.Text = "";
            lblNombreColector.Text = "";

            ////RESETEADO DE COMBOBOX DE AGENCIA
            //cmbAgencia.SelectedIndex = 0;

            //RESETEADO DE COMBOBOX DE FIRMA COMPA
            cmbFirma.SelectedIndex = 0;

            //RESETEADO DE COMBOBOX DE A;OS
            cmbCancelacion.SelectedIndex = 0;

            
        }

        private void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Los contratos mixtos aun no estan dispibles","Actualizaciones");
            return;

            for (int i = 0; i < dgvServicios.Rows.Count; i++)
            {
                if (dgvServicios.Rows[i].Cells[0].Value.ToString() == cmbServicios.Text)
                {
                    MessageBox.Show("El Servicio ya pertenece a la proforma");
                    return;
                }
            }

            //Verificar

            if (proformaContrato.Obtener_Precio_Nombre(cmbServicios.SelectedValue.ToString()) == 0)
            {
                MessageBox.Show("El Servicio no tiene valor de contrato, Edite el precio en inventario para utilizar en contrato");
                return;
            }


            dgvServicios.Rows.Add(cmbServicios.Text, TxtCantidadS.Value.ToString(), proformaContrato.Obtener_Precio_Nombre(cmbServicios.SelectedValue.ToString()), "Servicio Agregado");
        }

        //Realizacion de calculos
        private void Calculos()
        {

            int cantidadBeneficiarios = dgvBenficiarios.Rows.Count;
           if(cantidadBeneficiarios ==0 && dgvServicios.Rows.Count > 0)
            {
                cantidadBeneficiarios = 1;
            }
            

            if (cantidadBeneficiarios == 1 && int.Parse(cmbCancelacion.Text) > 3)
            {
                MessageBox.Show("Si solo hay un beneficiario el plazo maximo es para 3 años1", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lblCuotaCordoba.Text = "x";
                lblCuotaDolar.Text = "x";
                lblCuotas.Text = "x";
                return;
            }

            if (cantidadBeneficiarios == 2 && int.Parse(cmbCancelacion.Text) > 5)
            {
                MessageBox.Show("Para dos beneficiarios el plazo maximo es de 5 años", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lblCuotaCordoba.Text = "x";
                lblCuotaDolar.Text = "x";
                lblCuotas.Text = "x";
                return;
            }

            if (cantidadBeneficiarios == 3 && int.Parse(cmbCancelacion.Text) > 6)
            {
                MessageBox.Show("Para tres beneficiarios el plazo maximo es de 6 años", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lblCuotaCordoba.Text = "x";
                lblCuotaDolar.Text = "x";
                lblCuotas.Text = "x";
                return;
            }
            
            CuotaCalculos calculos = new CuotaCalculos();

            //Realizacion de calculos


            float[] nominales = new float[7];
            int[] cantidad = new int[7];

            int tama = 0;

            for (int i = 0; i < dgvBenficiarios.Rows.Count; i++)
            {
                nominales[i] = float.Parse(dgvBenficiarios.Rows[i].Cells[12].Value.ToString());

            }

            if (dgvServicios.Rows.Count != 0)
            {
                for (int i = 0; i < dgvServicios.Rows.Count; i++)
                {
                    nominales[0] = nominales[0] + float.Parse(dgvServicios.Rows[i].Cells[2].Value.ToString()) * int.Parse(dgvServicios.Rows[i].Cells[1].Value.ToString());

                }


            }
            //Agregar los montos por servicios



            if (calculos.VerificarAños(cantidadBeneficiarios, int.Parse(cmbCancelacion.Text)) == false)
            {
                lblCuotaCordoba.Text = "x";
                lblCuotaDolar.Text = "x";
                return;
            }
            else
            {
                if (rbtnMensual.Checked)
                {
                    lblCuotas.Text = ((int.Parse(cmbCancelacion.Text) * 12)).ToString();
                    lblCuotaDolar.Text = Math.Round(calculos.CalculoCuota(int.Parse(cmbCancelacion.Text), nominales, cantidadBeneficiarios),2).ToString();
                    lblCuotaCordoba.Text = Math.Round(calculos.CalculoCuota(int.Parse(cmbCancelacion.Text), nominales, cantidadBeneficiarios) * float.Parse(cTasa.MostrarTasa()),2).ToString() + " C$";
                }
                if (rbtnQuincenal.Checked)
                {
                    lblCuotas.Text = (int.Parse(cmbCancelacion.Text) * 24).ToString();
                    lblCuotaDolar.Text = Math.Round(calculos.CalculoCuota(int.Parse(cmbCancelacion.Text), nominales, cantidadBeneficiarios) / 2,2).ToString();
                    lblCuotaCordoba.Text = Math.Round((calculos.CalculoCuota(int.Parse(cmbCancelacion.Text), nominales, cantidadBeneficiarios) * float.Parse(cTasa.MostrarTasa())) / 2,2).ToString() + " C$";
                }
                if (rbtnTrimestral.Checked)
                {
                    lblCuotas.Text = (int.Parse(cmbCancelacion.Text) * 4).ToString();
                    lblCuotaDolar.Text = Math.Round(calculos.CalculoCuota(int.Parse(cmbCancelacion.Text), nominales, cantidadBeneficiarios) * 3,2).ToString();
                    lblCuotaCordoba.Text = Math.Round((calculos.CalculoCuota(int.Parse(cmbCancelacion.Text), nominales, cantidadBeneficiarios) * float.Parse(cTasa.MostrarTasa())) * 3,2).ToString() + "C $";
                }
            }
        }

        private void especialButton3_Click_1(object sender, EventArgs e)
        {
            if (dgvServicios.Rows.Count == 0)
            {
                MessageBox.Show("No hay servicios seleccionados", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                dgvServicios.Rows.Remove(dgvServicios.CurrentRow);
            }
        }
    }
}
