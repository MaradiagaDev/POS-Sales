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

namespace NeoCobranza.Paneles
{
    
    public partial class PnlProforma : Form
    {
        public Conexion conexion;
        public CProforma cProforma;
        public CTasaCambio tasaCambio;
        public CGeneral cGeneral;
        public PnlVendedores pnlVendedores;
        public Auditorias auditorias;

        //Unica clase a utilizar
        public ProformaVenta proformaVenta;

        public int id;
        public PnlProforma(Conexion conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
            //Incializacion de la clase de proforma venta
            proformaVenta = new ProformaVenta(conexion);
            auditorias = new Auditorias(conexion);

            //Estilo del data
            DgvBusquedas.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            DgvBusquedas.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);

            //Estilo del data
            DgvServicios.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            DgvServicios.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);


            cProforma = new CProforma(conexion);
            tasaCambio = new CTasaCambio(conexion);
            cGeneral = new CGeneral(conexion);
            btnActualizar.Hide();
            pnlVendedores = new PnlVendedores(conexion, "VentaProforma");
            AddOwnedForm(pnlVendedores);
        }
        public int idPublico;

        //Actualizar panel
        public PnlProforma(Conexion conexion, int idProforma)
        {
            InitializeComponent();
            //variable de conexion
            this.conexion = conexion;
            //Incializacion de la clase de proforma venta
            proformaVenta = new ProformaVenta(conexion);

            tasaCambio = new CTasaCambio(conexion);
            auditorias = new Auditorias(conexion);
            //Llenado de la variable publica
            this.idPublico = idProforma;

            //Estilo del data
            DgvBusquedas.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            DgvBusquedas.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);

            //Estilo del data
            DgvServicios.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            DgvServicios.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);


            //LLenar datos del data de servicios
            try
            {
                for (int i = 0; i < proformaVenta.ProcediemientoReporte(idProforma).Rows.Count; i++)
                {

                    DgvServicios.Rows.Add(proformaVenta.ProcediemientoReporte(idProforma).Rows[i][0].ToString(),
                            proformaVenta.ProcediemientoReporte(idProforma).Rows[i][1].ToString(),
                            proformaVenta.ProcediemientoReporte(idProforma).Rows[i][2].ToString(),
                            double.Parse(proformaVenta.ProcediemientoReporte(idProforma).Rows[i][2].ToString()) * double.Parse(tasaCambio.MostrarTasa()),
                            proformaVenta.ProcediemientoReporte(idProforma).Rows[i][5].ToString(),
                            SubtotalDolar(double.Parse(proformaVenta.ProcediemientoReporte(idProforma).Rows[i][2].ToString()), int.Parse(proformaVenta.ProcediemientoReporte(idProforma).Rows[i][5].ToString())),
                            SubtotalDolar(double.Parse(proformaVenta.ProcediemientoReporte(idProforma).Rows[i][2].ToString()), int.Parse(proformaVenta.ProcediemientoReporte(idProforma).Rows[i][5].ToString())) * double.Parse(tasaCambio.MostrarTasa()),
                            IvaDolar(double.Parse(proformaVenta.ProcediemientoReporte(idProforma).Rows[i][2].ToString()), int.Parse(proformaVenta.ProcediemientoReporte(idProforma).Rows[i][5].ToString()), double.Parse(proformaVenta.ProcediemientoReporte(idProforma).Rows[i][4].ToString()) / 100),
                            double.Parse(tasaCambio.MostrarTasa()) * IvaDolar(double.Parse(proformaVenta.ProcediemientoReporte(idProforma).Rows[i][2].ToString()), int.Parse(proformaVenta.ProcediemientoReporte(idProforma).Rows[i][5].ToString()),
                            double.Parse(proformaVenta.ProcediemientoReporte(idProforma).Rows[i][4].ToString()) / 100),
                            proformaVenta.ProcediemientoReporte(idProforma).Rows[i][3].ToString(),
                            DescuentoCalculos(double.Parse(proformaVenta.ProcediemientoReporte(idProforma).Rows[i][2].ToString()), int.Parse(proformaVenta.ProcediemientoReporte(idProforma).Rows[i][5].ToString()), (double.Parse(proformaVenta.ProcediemientoReporte(idProforma).Rows[i][3].ToString()) / 100)));
                    txtCantidad.Text = "1";
                    lblDescuentoN.Text = "0";
                }

                //Realizacion de los calculos

                Realizarcalculos();

                //Obtener datos del cliente

                lblNombreCliente.Text = proformaVenta.Procediemiento_Cliente(idProforma).Rows[0][0].ToString();
                lblIdCliente.Text = proformaVenta.Procediemiento_Cliente(idProforma).Rows[0][1].ToString();
                lblEstadoCliente.ForeColor = Color.Green;
                lblEstadoCliente.Text = "Registrado";

                //Registrar datos del Vendedor
                lblNombreColector.Text = proformaVenta.Procediemiento_Vendedor(idProforma).Rows[0][0].ToString();
                lblIdColector.Text = proformaVenta.Procediemiento_Vendedor(idProforma).Rows[0][1].ToString();

                //Obtener la descripcion
                txtObservaciones.Text = proformaVenta.Procediemiento_Descripcion(idProforma).Rows[0][0].ToString();

                //Deshabilitar boton
                BtnAgregarProforma.Visible = false;

                BtnCliente.Enabled = false;
                BtnVendd.Enabled = false;

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        #region ModificarProforma
        private void cargarLabels(int idCliente, string nombre)
        {
            lblIdCliente.Text = idCliente.ToString();
            lblNombreCliente.Text = nombre;
            lblEstadoCliente.Text = "Seleccionado";
            lblEstadoCliente.ForeColor = Color.Green;
        }
        


        #endregion 
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnAtaud.Checked)
                DgvBusquedas.DataSource = proformaVenta.Listar_Ataudes(txtfiltro.Texts);
            txtCantidad.Text = "1";
        }

        private void rbntServicios_CheckedChanged(object sender, EventArgs e)
        {
            if (rbntServicios.Checked)
                DgvBusquedas.DataSource = proformaVenta.Listar_Servicios(txtfiltro.Texts);
            txtCantidad.Text = "1";
        }

        private void txtfiltro__TextChanged(object sender, EventArgs e)
        {
            if (rbntServicios.Checked)
                DgvBusquedas.DataSource = proformaVenta.Listar_Servicios(txtfiltro.Texts);
            if (rbtnAtaud.Checked)
                DgvBusquedas.DataSource = proformaVenta.Listar_Ataudes(txtfiltro.Texts);
            txtCantidad.Text = "1";

            

            


        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            for (int i=0;i<DgvServicios.RowCount;i++)
            {
                if (DgvBusquedas.SelectedRows[0].Cells["Nombre"].Value.ToString() == DgvServicios.Rows[i].Cells["Servicio"].Value.ToString())
                {
                    MessageBox.Show("Servicio repetido en la proforma", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if(DgvServicios.Rows.Count== 8)
            {
                MessageBox.Show("Maximo de servicios alcanzado", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txtCantidad.Text == "")
            {
                MessageBox.Show("Digite la cantidad deseada", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txtCantidad.Text == "0" || txtCantidad.Text == "00")
            {
                txtCantidad.Text = "1";
                MessageBox.Show("Cantidad erronea", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            int pase;
            if (int.TryParse(txtCantidad.Text, out pase) == false)
            {
                txtCantidad.Text = "";

                MessageBox.Show("El campo de cantidad solo acepta numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (DgvBusquedas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un Ataud o Servicio", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (DgvBusquedas.SelectedRows[0].Cells[1].Value.ToString() == "Sala velatoria A" && int.Parse(txtCantidad.Text) > 1 || DgvBusquedas.SelectedRows[0].Cells[1].Value.ToString() == "Sala velatoria B" && int.Parse(txtCantidad.Text) > 1 || DgvBusquedas.SelectedRows[0].Cells[1].Value.ToString() == "Sala velatoria a Domicilio" && int.Parse(txtCantidad.Text) > 1)
            {
                MessageBox.Show("Solo se puede pagar una sala velatoria", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCantidad.Text = "1";
            }
            if (rbntServicios.Checked || rbtnAtaud.Checked)
            {
                // DgvServicios.Rows.Add(DgvBusquedas.SelectedRows[0].Cells[0].Value.ToString(), DgvBusquedas.SelectedRows[0].Cells[1].Value.ToString(), DgvBusquedas.SelectedRows[0].Cells[5].Value.ToString(), (double.Parse(DgvBusquedas.SelectedRows[0].Cells[5].Value.ToString()) * double.Parse(tasaCambio.MostrarTasa())).ToString(), txtCantidad.Text, (double.Parse(DgvBusquedas.SelectedRows[0].Cells[5].Value.ToString())) * int.Parse(txtCantidad.Text), double.Parse(tasaCambio.MostrarTasa())*IvaDolar(double.Parse(DgvBusquedas.SelectedRows[0].Cells[5].Value.ToString()), int.Parse(txtCantidad.Text), double.Parse(lblDescuentoN.Text)), IvaDolar(double.Parse(DgvBusquedas.SelectedRows[0].Cells[5].Value.ToString()),int.Parse(txtCantidad.Text), double.Parse(lblDescuentoN.Text) / 100, ((double.Parse(DgvBusquedas.SelectedRows[0].Cells[5].Value.ToString())) * double.Parse(tasaCambio.MostrarTasa())) * 0.15) * int.Parse(txtCantidad.Text), lblDescuentoN.Text, (((double.Parse(lblDescuentoN.Text) / 100) * double.Parse(DgvBusquedas.SelectedRows[0].Cells[5].Value.ToString())) * double.Parse(txtCantidad.Text)).ToString());
                DgvServicios.Rows.Add(DgvBusquedas.SelectedRows[0].Cells[0].Value.ToString(),
                    DgvBusquedas.SelectedRows[0].Cells[1].Value.ToString(),
                    DgvBusquedas.SelectedRows[0].Cells[2].Value.ToString(),
                    double.Parse(DgvBusquedas.SelectedRows[0].Cells[2].Value.ToString()) * double.Parse(tasaCambio.MostrarTasa()),
                    txtCantidad.Text,
                    SubtotalDolar(double.Parse(DgvBusquedas.SelectedRows[0].Cells[2].Value.ToString()), int.Parse(txtCantidad.Text)),
                    SubtotalDolar(double.Parse(DgvBusquedas.SelectedRows[0].Cells[2].Value.ToString()), int.Parse(txtCantidad.Text)) * double.Parse(tasaCambio.MostrarTasa()),
                    IvaDolar(double.Parse(DgvBusquedas.SelectedRows[0].Cells[2].Value.ToString()), int.Parse(txtCantidad.Text), double.Parse(lblDescuentoN.Text) / 100),
                    double.Parse(tasaCambio.MostrarTasa()) * IvaDolar(double.Parse(DgvBusquedas.SelectedRows[0].Cells[2].Value.ToString()), int.Parse(txtCantidad.Text),
                    double.Parse(lblDescuentoN.Text) / 100),
                    lblDescuentoN.Text,
                    DescuentoCalculos(double.Parse(DgvBusquedas.SelectedRows[0].Cells[2].Value.ToString()), int.Parse(txtCantidad.Text), (double.Parse(lblDescuentoN.Text) / 100)));
                txtCantidad.Text = "1";
                lblDescuentoN.Text = "0";
            }

            //
            if (DgvServicios.Rows.Count ==0)
            {
                MessageBox.Show("Seleccione un servicio o un ataud", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            else
            {
                Realizarcalculos();
          
            }









        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCliente_Click(object sender, EventArgs e)
        {

            Panel_Cliente_Contrato panelCliente = new Panel_Cliente_Contrato(conexion,"Proforma");
            AddOwnedForm(panelCliente);
            panelCliente.Show();

        }

        private void lblNombreCliente_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void BtnAgregarProforma_Click(object sender, EventArgs e)
        {

            //Verificar que se haya agregado un cliente
            if (lblIdCliente.Text == ".")
            {
                MessageBox.Show("Seleccione un cliente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {

                //Verificar que hayan servicios y se hayan realizado los calculos
                if (lblTotalC.Text == "0")
                {
                    MessageBox.Show("Agregue al menos un servicio", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }



            }

            //Verificar que se encuentre un vendedor
            if (lblIdColector.Text == ".")
            {
                MessageBox.Show("Aun no ha seleccionado al vendedor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Agregar proforma
            proformaVenta.Insertar_Proforma_Venta(txtObservaciones.Text, int.Parse(tasaCambio.MostrarIdTasa()), int.Parse(lblIdCliente.Text), int.Parse(lblIdColector.Text),float.Parse(lblSubTotalD.Text),float.Parse(lblDescuentoD.Text),float.Parse(lblIvaD.Text),float.Parse(lblTotalD.Text));
           
            //Agregar detalles de la proforma
            for (int i = 0; i < DgvServicios.Rows.Count ; i++)
            {
                proformaVenta.Insertar_Detalles(int.Parse(DgvServicios.Rows[i].Cells[4].Value.ToString()),
                    float.Parse(DgvServicios.Rows[i].Cells[5].Value.ToString()),
                    float.Parse(DgvServicios.Rows[i].Cells[7].Value.ToString()),
                    DgvServicios.Rows[i].Cells[9].Value.ToString(),
                    float.Parse(DgvServicios.Rows[i].Cells[10].Value.ToString()),
                    proformaVenta.Id_Ultima(),
                    int.Parse(DgvServicios.Rows[i].Cells[0].Value.ToString()));
            }
            MessageBox.Show("Proforma Creada Correctamente", "Accion completada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            auditorias.Insertar(conexion.usuario,"Creacion", proformaVenta.Id_Ultima().ToString(),"Proforma Venta");


            this.Close();
        }

        private void BtnEliminarServicio_Click(object sender, EventArgs e)
        {
            if (DgvServicios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una fila", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (DgvServicios.Rows.Count > 0 )
                {
                    DgvServicios.Rows.Remove(DgvServicios.CurrentRow);
                    Realizarcalculos();
                    return;
                }
                MessageBox.Show("No hay Servicios Agregados", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            if (DgvServicios.Rows.Count <= 1)
            {
                MessageBox.Show("Seleccione un servicio o un ataud", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);



                return;
            }
            else
            {
                
            }
        }

        private void Realizarcalculos()
        {
            if (DgvServicios.Rows.Count  ==0)
            {
                MessageBox.Show("Seleccione un servicio o un ataud", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                lblSubtotalC.Text = "0";
                lblSubTotalD.Text = "0";
                lblIvaC.Text = "0";
                lblIvaD.Text = "0";
                lblDescuentoC.Text = "0";
                lblDescuentoD.Text="0";
                lblTotalC.Text = "0";
                lblTotalD.Text= "0";


            }
            //Creacion de variables con el tama del data grid view

            double[] sumSubtotalC = new double[DgvServicios.Rows.Count];
            double[] sumIva = new double[DgvServicios.Rows.Count];
            double[] DescD = new double[DgvServicios.Rows.Count ];

            //LLenado con el data grid view
            for (int i = 0; i < DgvServicios.Rows.Count; i++)
            {
                sumSubtotalC[i] = Math.Round((double.Parse(DgvServicios.Rows[i].Cells[6].Value.ToString())), 2);
                sumIva[i] = Math.Round((double.Parse(DgvServicios.Rows[i].Cells[8].Value.ToString())), 2);
                DescD[i] = Math.Round((double.Parse(DgvServicios.Rows[i].Cells[10].Value.ToString())), 2);


            }


            lblSubtotalC.Text = (sumSubtotalC.Sum()).ToString();
            lblIvaC.Text = (sumIva.Sum()).ToString();
            lblDescuentoD.Text = (DescD.Sum()).ToString();
            lblDescuentoC.Text = ((DescD.Sum()) * double.Parse(tasaCambio.MostrarTasa())).ToString();

            lblTotalC.Text = Math.Round(((double.Parse(lblSubtotalC.Text)-double.Parse(lblDescuentoC.Text) )+ double.Parse(lblIvaC.Text)), 2).ToString();

            lblSubTotalD.Text = Math.Round((double.Parse(lblSubtotalC.Text)) / double.Parse(tasaCambio.MostrarTasa())).ToString(); /// double.Parse(tasaCambio.MostrarTasa())), 2).ToString();
            lblIvaD.Text = Math.Round((double.Parse(lblIvaC.Text) / double.Parse(tasaCambio.MostrarTasa())), 2).ToString();
            lblTotalD.Text = Math.Round((double.Parse(lblTotalC.Text) / double.Parse(tasaCambio.MostrarTasa())), 2).ToString();
            //

        }
        private double IvaDolar(double precio, int cantidad,double descuento)
        {
            double total = 0;

            total = ((((precio/1.15))*(1-descuento))*(0.15))*cantidad;

            return Math.Round(total,2);
        }
        private double SubtotalDolar(double precio, int cantidad)
        {
            double total = 0;

            total = (precio/1.15)*cantidad;

            return Math.Round(total,2);
        }
        private double DescuentoCalculos(double precio, int cantidad, double descuento)
        {

            double total = ((precio/1.15)*(descuento));

            return Math.Round(total,2);

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //Verificar que haya almenos un servicio

            if (DgvServicios.Rows.Count == 0)
            {
                MessageBox.Show("Digite al menos un servicio", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //Actualizar descripcion
            proformaVenta.Procedimiento_Proforma(idPublico, int.Parse(tasaCambio.MostrarIdTasa()), float.Parse(lblSubTotalD.Text),
                float.Parse(lblDescuentoD.Text),float.Parse(lblIvaD.Text),float.Parse(lblTotalD.Text));

            //Actualizar Descripcion

            proformaVenta.Actualizar_Descripcion(idPublico,txtObservaciones.Text);

            //Eliminamos los registros de detalles viejos
            proformaVenta.EliminarDetalles(idPublico);

            //Agregamos los detalles nuevos


            for (int i = 0; i < DgvServicios.Rows.Count; i++)
            {
                proformaVenta.Insertar_Detalles(int.Parse(DgvServicios.Rows[i].Cells[4].Value.ToString()),
                    float.Parse(DgvServicios.Rows[i].Cells[5].Value.ToString()),
                    float.Parse(DgvServicios.Rows[i].Cells[7].Value.ToString()),
                    DgvServicios.Rows[i].Cells[9].Value.ToString(),
                    float.Parse(DgvServicios.Rows[i].Cells[10].Value.ToString()),
                    idPublico,
                    int.Parse(DgvServicios.Rows[i].Cells[0].Value.ToString()));
            }

            MessageBox.Show("Proformas Actulizada con exito", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            auditorias.Insertar(conexion.usuario, "Actualizacion: Proforma de Ventas", idPublico.ToString(),"Proforma Venta");

            this.Close();

        }

        private void especialButton2_Click(object sender, EventArgs e)
        {
            pnlVendedores.Show();
        }

        private void PnlProforma_Load(object sender, EventArgs e)
        {
            DgvBusquedas.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            DgvServicios.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
        }
    }
}
