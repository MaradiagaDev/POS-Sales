using NeoCobranza.Clases;
using NeoCobranza.Clases_de_Contrato;
using NeoCobranza.Data;
using NeoCobranza.DataController;
using NeoCobranza.Poo;
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

namespace NeoCobranza.Paneles
{
    public partial class PnlProformaContrato : Form
    {
        public Auditorias auditorias;
        public Conexion conexion;

        //Clases necesarias para crear la proforma
        public Panel_Cliente_Contrato panelCliente;
        public CGeneral cGeneral;
        public PnlInsertarAgencia pnlInsertarAgencia = new PnlInsertarAgencia();
        public PnlVendedores pnlVendedores;
    
        public CContrato cContrato;
        public CTasaCambio cTasa;

        public int countBeneficiario = 0;

        public ProformaContrato proformaContrato;

        public Servicios servicios;

        public int idPublico;
        public PnlProformaContrato(Conexion conexion, int idProforma)
        {
            InitializeComponent();

            //Estilo del data
            dgvBenficiarios.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvBenficiarios.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);

            //Estilo del data
            dgvServicios.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvServicios.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);


            this.idPublico = idProforma;
            this.proformaContrato= new ProformaContrato(conexion);
            this.cGeneral = new CGeneral(conexion);
            this.servicios = new Servicios(conexion);
            cContrato = new CContrato(conexion);
            cTasa = new CTasaCambio(conexion);
            this.conexion = conexion;
            LLenarCmb();

            auditorias = new Auditorias(conexion);

            LlenarClieneteVendedor(idPublico);


            LLenarAtaudes(idPublico);
            LlenarServicios(idPublico);



           

            //Deshabilitar botones

            BtnAdd.Visible= false;
            BtnCliente.Enabled= false;
            especialButton2.Enabled= false;
            cmbFirma.Enabled = false;

            //Cambiar el check

            
            if (proformaContrato.Obtener_Modalidad_Actualizacion(idPublico) == "Mensual")
            {
                rbtnMensual.Checked = true;

            }
            else
            {
                if (proformaContrato.Obtener_Modalidad_Actualizacion(idPublico) == "Quincenal")
                {
                    rbtnQuincenal.Checked = true;

                }
                else
                {
                    if (proformaContrato.Obtener_Modalidad_Actualizacion(idPublico) == "Trimestral")
                    {
                        rbtnTrimestral.Checked = true;

                    }
                }
            }

           

        }

        //Funciones para la agilizacion

        private void LLenarAtaudes(int idProforma)
        {

            //AGREGAR ATAUDES
            for (int i = 0; i < proformaContrato.Obtener_Ataudes_Actualizacion(idPublico).Rows.Count; i++) {
                dgvBenficiarios.Rows.Add(proformaContrato.Obtener_Ataudes_Actualizacion(idPublico).Rows[i][0],
                    proformaContrato.Obtener_Ataudes_Actualizacion(idPublico).Rows[i][1],
                    proformaContrato.Obtener_Ataudes_Actualizacion(idPublico).Rows[i][2],
                    "Ataud Agregado");
            }

            //Llenar a;os

            cmbCancelacion.Text = proformaContrato.Obtener_Cancelacion_Actualizacion(idPublico);

        }

        private void LlenarServicios(int idProforma)
        {

            
            Thread.Sleep(200);
            //AGREGAR SERVICIOS
            for (int i = 0; i < proformaContrato.Obtener_Servicios_Actualizacion(idPublico).Rows.Count; i++)
            {
                dgvServicios.Rows.Add(proformaContrato.Obtener_Servicios_Actualizacion(idPublico).Rows[0][0],
                    proformaContrato.Obtener_Servicios_Actualizacion(idPublico).Rows[0][1],
                    proformaContrato.Obtener_Servicios_Actualizacion(idPublico).Rows[0][2],
                    "Servicio Agregado");
            }
            //LLENAR LA DESCRIPCION
            txtObservaciones.Text = proformaContrato.Obtener_Descripcion(idProforma);

           // Calculos();

        }

        //LLENAR CMB
        private void LLenarCmb()
        {
            //LLenado de los servicios
            cmbAtaudes.DataSource = proformaContrato.Listar_Ataudes();
            cmbAtaudes.ValueMember = "NombreEstandar";

            cmbServicios.DataSource = proformaContrato.Listar_Servicios();
            cmbServicios.ValueMember = "NombreEstandar";

            //Llenar firma
            cmbFirma.DataSource = cGeneral.MostrarFirmas();
            cmbFirma.ValueMember = "Nombres";
        }
        //LLENAR CLIENTE Y VENDEDOR

        private void LlenarClieneteVendedor(int idProforma)
        {


            //LLENAR CLIENTE 
            lblNombreCliente.Text = proformaContrato.Obtener_Nombre_Actualizacion(idPublico);
            lblIdCliente.Text = proformaContrato.Obtener_id_Actualizacion(idPublico);
            lblEstadoCliente.Text = "Agregado en el sistema";
            lblEstadoCliente.ForeColor = Color.Green;



            //LLenar vendedor

            lblNombreColector.Text = proformaContrato.Obtener_nombreVendedor_Actualizacion(idPublico);
            lblIdColector.Text = proformaContrato.Obtener_IDVendedor_Actualizacion(idPublico);

        }



        //CONSTRUCTOR PARA CREACION DE PROFORMA
        public PnlProformaContrato(Conexion conexion)
        {


            //Utilizacion de la clase
            this.proformaContrato = new ProformaContrato(conexion);

            InitializeComponent();
            //Variable de conexion
            this.conexion = conexion;
            //Desactivacion del boton de actualizar
            btnActualizar.Visible = false;

            auditorias = new Auditorias(conexion);
            //Variable para la utilizacion del la tasa
            cTasa = new CTasaCambio(conexion);
            
            //para el panel de vendedores
            pnlVendedores = new PnlVendedores(conexion, "ContratoProforma");
            AddOwnedForm(pnlVendedores);

            //Para el panel de cliente
            panelCliente = new Panel_Cliente_Contrato(conexion, "ContratoProforma");
            AddOwnedForm(panelCliente);
            cGeneral = new CGeneral(conexion);
            
            //Clase que ya no se va a utilizar
            
            cContrato = new CContrato(conexion);
         
            cmbFirma.DataSource = cGeneral.MostrarFirmas();
            cmbFirma.ValueMember = "Nombres";



            cmbAtaudes.DataSource = proformaContrato.Listar_Ataudes();
            cmbAtaudes.ValueMember = "NombreEstandar";

            cmbServicios.DataSource = proformaContrato.Listar_Servicios();
            cmbServicios.ValueMember = "NombreEstandar";


            //Estilo del data
            dgvBenficiarios.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvBenficiarios.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);

            //Estilo del data
            dgvServicios.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvServicios.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);


        }

        private void BtnCliente_Click(object sender, EventArgs e)
        {
            AddOwnedForm(panelCliente);

            try
            {
                panelCliente.Show();
            }catch(Exception ex)
            {

            }
        }

        private void especialButton2_Click(object sender, EventArgs e)
        {
            pnlVendedores.Show();
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvBenficiarios.Rows.Count; i++)
            {
                if (dgvBenficiarios.Rows[i].Cells[0].Value.ToString() == cmbAtaudes.Text)
                {
                    MessageBox.Show("El Ataud ya pertenece a la proforma");
                    return;
                }
            }

            if (countBeneficiario == 7)
            {
                MessageBox.Show("Maximo de servicios alcanzados", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Revisa la cantidad soportada de beneficiarios que es 7
            if((countBeneficiario+ int.Parse(txtCantidad.Value.ToString()) > 7)){
                MessageBox.Show("Esa cantidad sobre pasaria la cantidad soportada de Beneficiarios (7)", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (proformaContrato.Obtener_Precio_Nombre(cmbAtaudes.SelectedValue.ToString())==0)
            {
                MessageBox.Show("El servicio no esta disponible para ventas de contrato. Si quisiera habilitarlo tiene que aumentar su precio en contrato", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Agrega a la tabla
           
             dgvBenficiarios.Rows.Add(cmbAtaudes.Text, txtCantidad.Value.ToString(), proformaContrato.Obtener_Precio_Nombre(cmbAtaudes.SelectedValue.ToString()), "Ataud Agregado");

            countBeneficiario = countBeneficiario + int.Parse(txtCantidad.Value.ToString());
            txtCantidad.Value = 1;


        }

        private void BtnEliminarBeneficiario_Click(object sender, EventArgs e)
        {
            if (dgvBenficiarios.Rows.Count==0)
            {
                MessageBox.Show("No hay beneficiarios seleccionados", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                countBeneficiario = countBeneficiario-int.Parse(dgvBenficiarios.SelectedRows[0].Cells[1].Value.ToString());
                dgvBenficiarios.Rows.Remove(dgvBenficiarios.CurrentRow);
            }
        }

        private void dgvBenficiarios_SizeChanged(object sender, EventArgs e)
        {

        }
        private void Calculos()
        {
            int cantidadBeneficiarios=0;
            for (int i = 0; i < dgvBenficiarios.Rows.Count; i++)
            {
                cantidadBeneficiarios=cantidadBeneficiarios+int.Parse(dgvBenficiarios.Rows[i].Cells[1].Value.ToString());
            }
            cantidadBeneficiarios = 7;

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
                nominales[i] = float.Parse(dgvBenficiarios.Rows[i].Cells[2].Value.ToString())* int.Parse(dgvBenficiarios.Rows[i].Cells[1].Value.ToString());
                
            }

            if(dgvServicios.Rows.Count != 0)
            {
                for (int i = 0; i < dgvServicios.Rows.Count; i++)
                {
                    nominales[0] = nominales[0]+ float.Parse(dgvServicios.Rows[i].Cells[2].Value.ToString()) * int.Parse(dgvServicios.Rows[i].Cells[1].Value.ToString());

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
                    lblCuotas.Text = (( int.Parse(cmbCancelacion.Text) * 12)).ToString();
                    lblCuotaDolar.Text = Math.Round(calculos.CalculoCuota(int.Parse(cmbCancelacion.Text), nominales,cantidadBeneficiarios),2).ToString();
                    lblCuotaCordoba.Text = Math.Round(calculos.CalculoCuota(int.Parse(cmbCancelacion.Text), nominales,cantidadBeneficiarios) * float.Parse(cTasa.MostrarTasa()),2).ToString() + " C$";
                }
                if (rbtnQuincenal.Checked)
                {
                    lblCuotas.Text = (int.Parse(cmbCancelacion.Text) * 24).ToString();
                    lblCuotaDolar.Text = Math.Round(calculos.CalculoCuota(int.Parse(cmbCancelacion.Text), nominales,cantidadBeneficiarios) / 2,2).ToString();
                    lblCuotaCordoba.Text = Math.Ceiling((calculos.CalculoCuota(int.Parse(cmbCancelacion.Text), nominales ,cantidadBeneficiarios) * float.Parse(cTasa.MostrarTasa())) / 2).ToString() + " C$";
                }
                if (rbtnTrimestral.Checked)
                {
                    lblCuotas.Text = (int.Parse(cmbCancelacion.Text) * 4).ToString();
                    lblCuotaDolar.Text = Math.Round(calculos.CalculoCuota(int.Parse(cmbCancelacion.Text),nominales, cantidadBeneficiarios) * 3,2).ToString();
                    lblCuotaCordoba.Text = Math.Round((calculos.CalculoCuota(int.Parse(cmbCancelacion.Text), nominales ,cantidadBeneficiarios) * float.Parse(cTasa.MostrarTasa())) * 3,2).ToString() + "C $";
                }
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
            if(int.TryParse(cmbCancelacion.Text,out i)==false)
            {

                MessageBox.Show("Seleccione la cantiedad de años correcta", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (dgvBenficiarios.Rows.Count == 0 && dgvServicios.Rows.Count==0)
            {
                MessageBox.Show("Digite un Beneficiario o un servicio", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (cmbFirma.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Seleccione una Firma de compañia", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
          
            if (cmbCancelacion.Text == "Seleccione un año")
            {
                MessageBox.Show("Seleccione un año de cancelacion", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
           
            return true;
        }
        private void dgvBenficiarios_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
    
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            


            int x;
            if (int.TryParse(cmbCancelacion.Text, out x) == false)
            {

                MessageBox.Show("Seleccione la cantiedad de años correcta", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
           if(verificar())
            {
                Calculos();
            }
            
        }

        private void dgvBenficiarios_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgvBenficiarios.Rows.Count == 0)
            {
                lblCuotaCordoba.Text = "0";
                lblCuotaDolar.Text = "0"
;
                lblCuotas.Text = "0";
            }
            
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // VERIFICAR QUE YA SE HAYA GENERADO UNA CUOTA
            if (lblCuotas.Text == "x" || lblCuotaCordoba.Text == "x" || lblCuotaDolar.Text == "x")
            {
                MessageBox.Show("Digite una cuota valida", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
            //VERIFICAR QUE LOS DATOS NO SE HAYAN CAMBIADO DESPUES DE GENERAR UNA CUOTA
            int cantidadBeneficiarios = dgvBenficiarios.Rows.Count;
            

            /*
            if (cantidadBeneficiarios == 1 && int.Parse(cmbCancelacion.Text) > 3)
            {
                MessageBox.Show("Si solo hay un beneficiario el plazo maximo es para 3 años2", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            */
            //AGREGAR A LA BASE DE DATOS

            DialogResult Result;
            Result = MessageBox.Show("¿Esta seguro de crear el contrato ?", "Advertencia de creacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);


            if (Result == DialogResult.Yes)
            {
                //variables para calculo de los valores
                float[] nominales = new float[dgvBenficiarios.Rows.Count];


                

                //Agregar los montos por servicios

                for (int i = 0; i < dgvBenficiarios.Rows.Count; i++)
                {
                    nominales[i] = float.Parse(dgvBenficiarios.Rows[i].Cells[2].Value.ToString()) * int.Parse(dgvBenficiarios.Rows[i].Cells[1].Value.ToString());

                }

                if (dgvServicios.Rows.Count != 0)
                {
                    for (int i = 0; i < dgvServicios.Rows.Count; i++)
                    {
                        nominales[0] = nominales[0] + float.Parse(dgvServicios.Rows[i].Cells[2].Value.ToString()) * int.Parse(dgvServicios.Rows[i].Cells[1].Value.ToString());

                    }


                }





                //Crear el contrato

                Calculos();

                if (rbtnMensual.Checked)
                {
                    cContrato.AgregarContratoProforma(int.Parse(cmbCancelacion.Text), int.Parse(lblCuotas.Text), float.Parse(nominales.Sum().ToString()), float.Parse(lblCuotaDolar.Text), txtObservaciones.Text,int.Parse( cContrato.MostrarIdFirma(cmbFirma.Text)), int.Parse(cTasa.MostrarIdTasa()), int.Parse(lblIdColector.Text), "Mensual");
                }
                if (rbtnQuincenal.Checked)
                {
                    cContrato.AgregarContratoProforma(int.Parse(cmbCancelacion.Text), int.Parse(lblCuotas.Text), float.Parse(nominales.Sum().ToString()), float.Parse(lblCuotaDolar.Text), txtObservaciones.Text, int.Parse(cContrato.MostrarIdFirma(cmbFirma.Text)), int.Parse(cTasa.MostrarIdTasa()), int.Parse(lblIdColector.Text), "Quincenal");
                }
                if (rbtnTrimestral.Checked)
                {
                    cContrato.AgregarContratoProforma(int.Parse(cmbCancelacion.Text), int.Parse(lblCuotas.Text), float.Parse(nominales.Sum().ToString()), float.Parse(lblCuotaDolar.Text), txtObservaciones.Text, int.Parse( cContrato.MostrarIdFirma(cmbFirma.Text)), int.Parse(cTasa.MostrarIdTasa()), int.Parse(lblIdColector.Text), "Trimestral");
                }



                //LUGAR DONDE SE AGREGAN A LOS BENEFICIARIOS
                proformaContrato = new ProformaContrato(conexion);

                for (int i = 0; i < dgvBenficiarios.Rows.Count; i++)
                {



                    proformaContrato.Insertar_Detalles(int.Parse(cContrato.MostrarIdAtaud(dgvBenficiarios.Rows[i].Cells[0].Value.ToString())),
                      int.Parse( dgvBenficiarios.Rows[i].Cells[1].Value.ToString()),proformaContrato.Obtener_UltimoID_Contrato());
                    
                      

                }
                for (int i = 0; i < dgvServicios.Rows.Count; i++)
                {



                    proformaContrato.Insertar_Detalles(int.Parse(cContrato.MostrarIdAtaud(dgvServicios.Rows[i].Cells[0].Value.ToString())),
                      int.Parse(dgvServicios.Rows[i].Cells[1].Value.ToString()), proformaContrato.Obtener_UltimoID_Contrato());



                }

                cContrato.AgregarClienteContrato(int.Parse(lblIdCliente.Text), int.Parse(cContrato.MostrarIdContrato()));

                MessageBox.Show("Contrato creado con exito!");

                auditorias.Insertar(conexion.usuario, "Creacion: Proforma Contrato", cContrato.MostrarIdContrato(),"Proforma Contrato");

                this.Close();

                 





    }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            for(int i=0; i<dgvServicios.Rows.Count; i++)
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

        private void btnEliminarServicios_Click(object sender, EventArgs e)
        {
            if (dgvServicios.Rows.Count == 0)
            {
                MessageBox.Show("No hay Servicios seleccionados", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                
                dgvServicios.Rows.Remove(dgvServicios.CurrentRow);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //Verificar que almenos uno de los dos datas tenga datos
            if (dgvBenficiarios.Rows.Count==0 && dgvServicios.Rows.Count==0)
            {
                MessageBox.Show("Digite al menos un beneficiario o un servicio");
                return;
            }


            if (verificar())
            {
                Calculos();
            }
            else
            {
                return;
            }
            //variables para calculo de los valores
            float[] nominales = new float[dgvBenficiarios.Rows.Count];


            //Obtener la cantidad de beneficiarios

            //Agregar los montos por servicios

            for (int i = 0; i < dgvBenficiarios.Rows.Count; i++)
            {
                nominales[i] = float.Parse(dgvBenficiarios.Rows[i].Cells[2].Value.ToString()) * int.Parse(dgvBenficiarios.Rows[i].Cells[1].Value.ToString());

            }

            if (dgvServicios.Rows.Count != 0)
            {
                for (int i = 0; i < dgvServicios.Rows.Count; i++)
                {
                    nominales[0] = nominales[0] + float.Parse(dgvServicios.Rows[i].Cells[2].Value.ToString()) * int.Parse(dgvServicios.Rows[i].Cells[1].Value.ToString());

                }


            }

            if (rbtnMensual.Checked)
            {
                proformaContrato.Actualizar_Proforma(int.Parse(cmbCancelacion.Text), int.Parse(lblCuotas.Text), float.Parse(nominales.Sum().ToString()), float.Parse(lblCuotaDolar.Text), txtObservaciones.Text, "Mensual",idPublico);
            }
            if (rbtnQuincenal.Checked)
            {
                proformaContrato.Actualizar_Proforma(int.Parse(cmbCancelacion.Text), int.Parse(lblCuotas.Text), float.Parse(nominales.Sum().ToString()), float.Parse(lblCuotaDolar.Text), txtObservaciones.Text, "Quincenal",idPublico);
            }
            if (rbtnTrimestral.Checked)
            {
                proformaContrato.Actualizar_Proforma(int.Parse(cmbCancelacion.Text), int.Parse(lblCuotas.Text), float.Parse(nominales.Sum().ToString()), float.Parse(lblCuotaDolar.Text), txtObservaciones.Text, "Trimestral",idPublico);
            }
            //Borrar detalles

            proformaContrato.BorrarDetalles(idPublico);

            //Volvemos agregar los detalles
            //LUGAR DONDE SE AGREGAN A LOS BENEFICIARIOS
            

            for (int i = 0; i < dgvBenficiarios.Rows.Count; i++)
            {



                proformaContrato.Insertar_Detalles(int.Parse(cContrato.MostrarIdAtaud(dgvBenficiarios.Rows[i].Cells[0].Value.ToString())),
                  int.Parse(dgvBenficiarios.Rows[i].Cells[1].Value.ToString()), idPublico);



            }
            for (int i = 0; i < dgvServicios.Rows.Count; i++)
            {



                proformaContrato.Insertar_Detalles(int.Parse(cContrato.MostrarIdAtaud(dgvServicios.Rows[i].Cells[0].Value.ToString())),
                  int.Parse(dgvServicios.Rows[i].Cells[1].Value.ToString()), idPublico);



            }

            auditorias.Insertar(conexion.ObtenerUsuari(), "Actualizacion: Proforma Contrato", idPublico.ToString(),"Proforma Contrato");
            MessageBox.Show("Contrato actualizado con exito!");

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            LLenarAtaudes(idPublico);
            LlenarServicios(idPublico);
            
        }

        private void PnlProformaContrato_Load(object sender, EventArgs e)
        {
            dgvBenficiarios.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dgvServicios.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
        }
    }
}
