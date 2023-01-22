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
    public partial class PnlVentas : Form
    {
        //Variable de Conexion
        public Conexion conexion;

        //Clase de procedimientos almacenados

        VentasDirectas ventas;

        CTasaCambio ctasa;

        //Paneles utilizados

        public PnlVendedores pnlVendedores;

        //Constructor
        public PnlVentas(Conexion conexion)
        {
            InitializeComponent();

            especialButton2.Enabled = false;
            //Inicializacion de las clases a utilizar
            this.conexion = conexion;   
            //Clase de ventas
            ventas = new VentasDirectas(conexion);
            ctasa = new CTasaCambio(conexion);
            //LLenado del Cmb
            cmbCategoria.DataSource = ventas.CmbCategorias();

            cmbServicios.DataSource = ventas.CmbCategoriasServicios();
            //LLenado de la tasa de cambio

            lblTasa.Text= ctasa.MostrarTasa();

            //Verificar que haya ataudes registrados en las categorias
            if(cmbCategoria.Items.Count == 0)
            {
                txtFiltro.Enabled = false;
                MessageBox.Show("No hay Categorias de ataudes registrados","Error");
                return;
            }
            else
            {
                dgvStock.DataSource = ventas.Mostra_Stock(txtFiltro.Texts,int.Parse(ventas.Mostra_idXNombre_Categoria(cmbCategoria.Text)));
            }


            //PnlVendedores
            pnlVendedores = new PnlVendedores(conexion, "Venta");
            AddOwnedForm(pnlVendedores);

            //Verificar que al entrar hay selecciones cargadas
            if (dgvStock.SelectedRows.Count == 0)
            {
                txtDescuento.Enabled = false;
            }
            else
            {

                lblNominal.Text = (double.Parse(dgvStock.SelectedRows[0].Cells[2].Value.ToString()) / 1.15).ToString();

                lblDescuento.Text = "0";

                lblIva.Text = (double.Parse(dgvStock.SelectedRows[0].Cells[2].Value.ToString()) - double.Parse(lblNominal.Text)).ToString();

                lblTotal.Text = dgvStock.SelectedRows[0].Cells[2].Value.ToString();

                txtDescuento.Enabled = true;
            }

        }

        //Constructor para actualizaciones

        public int idPublico ;

        public string tipo;
        public PnlVentas(Conexion conexion,int id,String tipo)
        {
            this.InitializeComponent();
            if (tipo == "Final")
            {
                txtMonto.Enabled = false;
            }

            BtnRealizarVenta.Enabled = false;
            especialButton1.Enabled = false;
            BtnReservar.Enabled = false;

            this.idPublico = id;
            this.tipo = tipo;
            //Inicializacion de las clases a utilizar
            this.conexion = conexion;
            //Clase de ventas
            ventas = new VentasDirectas(conexion);
            ctasa = new CTasaCambio(conexion);
            //LLenado del Cmb
            cmbCategoria.DataSource = ventas.CmbCategorias();

            cmbServicios.DataSource = ventas.CmbCategoriasServicios();
            //LLenado de la tasa de cambio

            lblTasa.Text = ctasa.MostrarTasa();

            //Verificar que haya ataudes registrados en las categorias
            if (cmbCategoria.Items.Count == 0)
            {
                txtFiltro.Enabled = false;
                MessageBox.Show("No hay Categorias de ataudes registrados", "Error");
                return;
            }
            else
            {
                dgvStock.DataSource = ventas.Mostra_Stock(txtFiltro.Texts, int.Parse(ventas.Mostra_idXNombre_Categoria(cmbCategoria.Text)));
            }


            //PnlVendedores
            pnlVendedores = new PnlVendedores(conexion, "Venta");
            AddOwnedForm(pnlVendedores);

            //Verificar que al entrar hay selecciones cargadas
            if (dgvStock.SelectedRows.Count == 0)
            {
                txtDescuento.Enabled = false;
            }
            else
            {

                lblNominal.Text = (double.Parse(dgvStock.SelectedRows[0].Cells[2].Value.ToString()) / 1.15).ToString();

                lblDescuento.Text = "0";

                lblIva.Text = (double.Parse(dgvStock.SelectedRows[0].Cells[2].Value.ToString()) - double.Parse(lblNominal.Text)).ToString();

                lblTotal.Text = dgvStock.SelectedRows[0].Cells[2].Value.ToString();

                txtDescuento.Enabled = true;
            }


            //--------------------- LLenado de los campos -----------------------------

            lblIdCliente.Text = ventas.Actualizar_Cliente(id).Rows[0][0].ToString();
            lblNombreCliente.Text = ventas.Actualizar_Cliente(id).Rows[0][1].ToString();

            lblEstadoCliente.Text = "Registrado en el sistema";
            lblEstadoCliente.ForeColor = Color.Green;

            BtnCliente.Enabled = false;

            //LLenado de los datos del vendedor

            lblIdColector.Text = ventas.Actualizar_Vendedor(id).Rows[0][0].ToString();
            lblNombreColector.Text = ventas.Actualizar_Vendedor(id).Rows[0][1].ToString();

            BtnVendedor.Enabled = false;

            //LLenado de las informaciones generales

            txtDescripcion.Text = ventas.Actualizar_Info(id).Rows[0][0].ToString();
            txtMonto.Text = ventas.Actualizar_Info(id).Rows[0][1].ToString();
            txtFactura.Text = ventas.Actualizar_Info(id).Rows[0][2].ToString();

            //Insertar ataudes

            for (int i = 0; i< ventas.Actualizar_Ataudes(id).Rows.Count; i++) {

                dgvAtaudes.Rows.Add(ventas.Actualizar_Ataudes(id).Rows[i][0].ToString(),
                    ventas.Actualizar_Ataudes(id).Rows[i][1].ToString(),
                    ventas.Actualizar_Ataudes(id).Rows[i][2].ToString(),
                    ventas.Actualizar_Ataudes(id).Rows[i][3].ToString(),
                    ventas.Actualizar_Ataudes(id).Rows[i][4].ToString());
            }

            //Insertar servicios

            for (int i = 0; i < ventas.Actualizar_Servicios(id).Rows.Count; i++)
            {
                dgvServicios.Rows.Add(ventas.Actualizar_Servicios(id).Rows[i][0].ToString(),
                                   ventas.Actualizar_Servicios(id).Rows[i][1].ToString(),
                                   ventas.Actualizar_Servicios(id).Rows[i][2].ToString(),
                                   ventas.Actualizar_Servicios(id).Rows[i][3].ToString(),
                                   ventas.Actualizar_Servicios(id).Rows[i][4].ToString());


            }

            RealizarCalculos();

        }

        private void limpiar()
        {
            txtFactura.Text = "";
            txtMonto.Text = "0";

            //Reinicio del los clientes
            lblEstadoCliente.Text = "Sin Registrar";
            lblEstadoCliente.ForeColor = Color.Red;

            lblNombreCliente.Text = ".";

            lblIdCliente.Text = ".";

            //Reinico de los vendedores

            lblNombreColector.Text = ".";
            lblIdColector.Text = ".";

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategoria.Items.Count == 0)
            {
                MessageBox.Show("No hay Categorias de ataudes registrados", "Error");
                return;
            }
            else
            {
                dgvStock.DataSource = ventas.Mostra_Stock(txtFiltro.Texts, int.Parse(ventas.Mostra_idXNombre_Categoria(cmbCategoria.Text)));
            }
            if (dgvStock.SelectedRows.Count == 0)
            {
                lblNominal.Text = "x";

                lblDescuento.Text = "x";

                lblIva.Text = "x";

                lblTotal.Text = "x";

                lblCordoba.Text = "x";

                txtDescuento.Text = "0";
            }

        }

        private void txtFiltro__TextChanged(object sender, EventArgs e)
        {
            dgvStock.DataSource = ventas.Mostra_Stock(txtFiltro.Texts, int.Parse(ventas.Mostra_idXNombre_Categoria(cmbCategoria.Text)));

        }

        private void BtnRealizarVenta_Click(object sender, EventArgs e)
        {
            //VERIFICAR Que algo este seleccionado en los dos
            if(dgvServicios.Rows.Count == 0 && dgvAtaudes.Rows.Count==0)
            {
                MessageBox.Show("No ha seleccionado nada para la venta", "Error");
                return;
            }

            //Verificar que se haya calculado algo

            if (lblTotalTotalDolar.Text == "")
            {
                MessageBox.Show("No ha seleccionado nada para la venta", "Error");
                return ;
            }
            //VERIFICAR QUE SE HAYA SELECCIONADO UN CLIENTE
            if (lblIdCliente.Text == ".")
            {
                MessageBox.Show("No ha seleccionado ningun Cliente", "Error");
                return;
            }
            //VERIFICAR QUE SE HAYA SELECCIONADO UN VENDEDOR
            if (lblIdColector.Text == ".")
            {
                MessageBox.Show("No ha seleccionado ningun Vendedor", "Error");
                return;
            }
            //VERIFICAR QUE SE HAYA DIGITADO ALGUNA FACTURA
            if (txtFactura.Text == "")
            {
                MessageBox.Show("No ha digitado el numero de factura", "Error");
                return;
            }
            //EN EL CASO DE HABER ALGUNA SELECCION


            //Procedimiento almacenado PARA LA VENTA GENERAL

           
            ventas.VentaDirecta(txtDescripcion.Text,int.Parse( lblIdCliente.Text),int.Parse( lblIdColector.Text), txtFactura.Text, "Venta Directa", "Sin Imprimir", 0);

            //LLenado de los detalles
            if(dgvAtaudes.Rows.Count != 0)
            {
                for (int i =0;i<dgvAtaudes.Rows.Count; i++)
                {
                    ventas.VentaFutura(int.Parse(ventas.Mostrar_Ultima_Venta()),int.Parse( dgvAtaudes.Rows[i].Cells[4].Value.ToString()),int.Parse( dgvAtaudes.Rows[i].Cells[0].Value.ToString()));

                    //Cambios de estado para los estandares

                    ventas.VentaDirectas_Estandares(int.Parse(dgvAtaudes.Rows[i].Cells[0].Value.ToString()));
                }
            }

            //LLenado de detalles de servicios
            if (dgvServicios.Rows.Count != 0)
            {
                for (int i = 0; i < dgvServicios.Rows.Count; i++)
                {
                    ventas.VentaReserva(int.Parse(ventas.Mostrar_Ultima_Venta()), int.Parse(dgvServicios.Rows[i].Cells[4].Value.ToString()), int.Parse(dgvServicios.Rows[i].Cells[0].Value.ToString()), int.Parse(dgvServicios.Rows[i].Cells[3].Value.ToString()));
                }
            }



            //Mostrar Mensaje
            MessageBox.Show("Venta realizada", "Correcto");

                //Actualizar el data
                dgvStock.DataSource = ventas.Mostra_Stock(txtFiltro.Texts, int.Parse(ventas.Mostra_idXNombre_Categoria(cmbCategoria.Text)));
            limpiar();

            this.Close();
        }

        private void BtnVendedor_Click(object sender, EventArgs e)
        {
            pnlVendedores.Show();
        }

        private void lblNombreCliente_Click(object sender, EventArgs e)
        {

        }

        private void BtnCliente_Click(object sender, EventArgs e)
        {
            Panel_Cliente_Contrato panelCliente = new Panel_Cliente_Contrato(conexion, "Venta");
            AddOwnedForm(panelCliente);
            panelCliente.Show();
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            //VERIFICAR Que algo este seleccionado en los dos
            if (dgvServicios.Rows.Count == 0 && dgvAtaudes.Rows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado nada para la venta", "Error");
                return;
            }

            //Verificar que se haya calculado algo

            if (lblTotalTotalDolar.Text == "")
            {
                MessageBox.Show("No ha seleccionado nada para la venta", "Error");
                return;
            }
            //VERIFICAR QUE SE HAYA SELECCIONADO UN CLIENTE
            if (lblIdCliente.Text == ".")
            {
                MessageBox.Show("No ha seleccionado ningun Cliente", "Error");
                return;
            }
            //VERIFICAR QUE SE HAYA SELECCIONADO UN VENDEDOR
            if (lblIdColector.Text == ".")
            {
                MessageBox.Show("No ha seleccionado ningun Vendedor", "Error");
                return;
            }
            //VERIFICAR QUE SE HAYA DIGITADO ALGUNA FACTURA
            if (txtFactura.Text == "")
            {
                MessageBox.Show("No ha digitado el numero de factura", "Error");
                return;
            }
            //VERIFICAR QUE SE HAYA DIGITADO UN MONTO DE RESERVA
            if (txtMonto.Text == "" || txtMonto.Text == "0")
            {
                MessageBox.Show("No ha digitado un monto inicial", "Error");
                return;
            }

            //VERIFICAR QUE SE HAYA DIGITADO UN MONTO DE RESERVA
            if (float.Parse(txtMonto.Text)> float.Parse(lblTotalTotalDolar.Text) )
            {
                MessageBox.Show("El monto no puede ser mayor al total", "Error");
                return;
            }
            if (float.Parse(txtMonto.Text)< (float.Parse(lblTotalTotalDolar.Text)/2))
            {
                MessageBox.Show("El monto no puede ser menor al 50 %", "Error");
                return;
            }


            //EN EL CASO DE HABER ALGUNA SELECCION

            //Procedimiento almacenado PARA LA VENTA GENERAL


            ventas.VentaDirecta(txtDescripcion.Text, int.Parse(lblIdCliente.Text), int.Parse(lblIdColector.Text), txtFactura.Text, "Venta Futura", "Sin Retirar",float.Parse( txtMonto.Text));

            //LLenado de los detalles
            if (dgvAtaudes.Rows.Count != 0)
            {
                for (int i = 0; i < dgvAtaudes.Rows.Count; i++)
                {
                    ventas.VentaFutura(int.Parse(ventas.Mostrar_Ultima_Venta()), int.Parse(dgvAtaudes.Rows[i].Cells[4].Value.ToString()), int.Parse(dgvAtaudes.Rows[i].Cells[0].Value.ToString()));

                    //Cambios de estado para los estandares

                    ventas.VentaDirectas_Futuras(int.Parse(dgvAtaudes.Rows[i].Cells[0].Value.ToString()));
                }
            }

            //LLenado de detalles de servicios
            if (dgvServicios.Rows.Count != 0)
            {
                for (int i = 0; i < dgvServicios.Rows.Count; i++)
                {
                    ventas.VentaReserva(int.Parse(ventas.Mostrar_Ultima_Venta()), int.Parse(dgvServicios.Rows[i].Cells[4].Value.ToString()), int.Parse(dgvServicios.Rows[i].Cells[0].Value.ToString()), int.Parse(dgvServicios.Rows[i].Cells[3].Value.ToString()));
                }
            }






            MessageBox.Show("Venta realizada", "Correcto");

            //Actualizar el data
            dgvStock.DataSource = ventas.Mostra_Stock(txtFiltro.Texts, int.Parse(ventas.Mostra_idXNombre_Categoria(cmbCategoria.Text)));

            limpiar();

            this.Close();
        }

        private void BtnReservar_Click(object sender, EventArgs e)
        {
            //VERIFICAR Que algo este seleccionado en los dos
            if (dgvServicios.Rows.Count == 0 && dgvAtaudes.Rows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado nada para la venta", "Error");
                return;
            }

            //Verificar que se haya calculado algo

            if (lblTotalTotalDolar.Text == "")
            {
                MessageBox.Show("No ha seleccionado nada para la venta", "Error");
                return;
            }
            //VERIFICAR QUE SE HAYA SELECCIONADO UN CLIENTE
            if (lblIdCliente.Text == ".")
            {
                MessageBox.Show("No ha seleccionado ningun Cliente", "Error");
                return;
            }
            //VERIFICAR QUE SE HAYA SELECCIONADO UN VENDEDOR
            if (lblIdColector.Text == ".")
            {
                MessageBox.Show("No ha seleccionado ningun Vendedor", "Error");
                return;
            }
            //VERIFICAR QUE SE HAYA DIGITADO ALGUNA FACTURA
            if (txtFactura.Text == "")
            {
                MessageBox.Show("No ha digitado el numero de factura", "Error");
                return;
            }
            //VERIFICAR QUE SE HAYA DIGITADO UN MONTO DE RESERVA
            if (txtMonto.Text == "" || txtMonto.Text == "0")
            {
                MessageBox.Show("No ha digitado un monto inicial", "Error");
                return;
            }

            if (float.Parse(txtMonto.Text) > float.Parse(lblTotalTotalDolar.Text))
            {
                MessageBox.Show("El monto no puede ser mayor al total", "Error");
                return;
            }
            if (float.Parse(txtMonto.Text) < 0)
            {
                MessageBox.Show("El monto no puede ser menor a 0 %", "Error");
                return;
            }


            ventas.VentaDirecta(txtDescripcion.Text, int.Parse(lblIdCliente.Text), int.Parse(lblIdColector.Text), txtFactura.Text, "Reservado", "Sin Retirar", float.Parse(txtMonto.Text));

            //LLenado de los detalles
            if (dgvAtaudes.Rows.Count != 0)
            {
                for (int i = 0; i < dgvAtaudes.Rows.Count; i++)
                {
                    ventas.VentaFutura(int.Parse(ventas.Mostrar_Ultima_Venta()), int.Parse(dgvAtaudes.Rows[i].Cells[4].Value.ToString()), int.Parse(dgvAtaudes.Rows[i].Cells[0].Value.ToString()));

                    //Cambios de estado para los estandares

                    ventas.VentaDirectas_Reservas(int.Parse(dgvAtaudes.Rows[i].Cells[0].Value.ToString()));
                }
            }

            //LLenado de detalles de servicios
            if (dgvServicios.Rows.Count != 0)
            {
                for (int i = 0; i < dgvServicios.Rows.Count; i++)
                {
                    ventas.VentaReserva(int.Parse(ventas.Mostrar_Ultima_Venta()), int.Parse(dgvServicios.Rows[i].Cells[4].Value.ToString()), int.Parse(dgvServicios.Rows[i].Cells[0].Value.ToString()), int.Parse(dgvServicios.Rows[i].Cells[3].Value.ToString()));
                }
            }







            //Mostrar Mensaje
            MessageBox.Show("Reservacion realizada", "Correcto");

            //Actualizar el data
            dgvStock.DataSource = ventas.Mostra_Stock(txtFiltro.Texts, int.Parse(ventas.Mostra_idXNombre_Categoria(cmbCategoria.Text)));

            limpiar();

            this.Close();
        }

        private void dgvStock_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvStock.SelectedRows.Count == 0)
            {
                txtDescuento.Enabled = false;
            }
            else
            {
                txtDescuento.Enabled = true;
            }
            
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            if (dgvStock.SelectedRows.Count == 0)
            {
                return;
            }
            
            if(txtDescuento.Text == "")
            {
                lblNominal.Text = "x";

                lblDescuento.Text = "x";

                lblIva.Text = "x";

                lblTotal.Text = "x";

                lblCordoba.Text = "x";


                return;
            }
            if (dgvStock.SelectedRows.Count == 0)
            {
                lblNominal.Text = "x";

                lblDescuento.Text = "x";

                lblIva.Text = "x";

                lblTotal.Text = "x";

                lblCordoba.Text = "x";
            }
            if (double.Parse(txtDescuento.Text) > 50)
            {
                MessageBox.Show("Los descuentos no pueden ser mayores al 50%", "Error");

                txtDescuento.Text = "50";
            }

            if (txtDescuento.Text == "0")
            {
                lblNominal.Text = (Math.Round( double.Parse(dgvStock.SelectedRows[0].Cells[2].Value.ToString()) / 1.15,2)).ToString();

                lblDescuento.Text = "0";

                lblIva.Text = (Math.Round(double.Parse(dgvStock.SelectedRows[0].Cells[2].Value.ToString()) - double.Parse(lblNominal.Text),2)).ToString();

                lblTotal.Text = dgvStock.SelectedRows[0].Cells[2].Value.ToString();

                lblCordoba.Text = Math.Round( double.Parse(lblTotal.Text) * double.Parse(lblTasa.Text),2).ToString();
            }
            else
            {
                lblNominal.Text = (Math.Round(double.Parse(dgvStock.SelectedRows[0].Cells[2].Value.ToString()) / 1.15,2)).ToString();

                lblDescuento.Text = (Math.Round(double.Parse(lblNominal.Text) * (double.Parse(txtDescuento.Text) / 100),2)).ToString();

                lblIva.Text = (Math.Round((double.Parse(lblNominal.Text) - double.Parse(lblDescuento.Text)) * 0.15,2)).ToString();

                lblTotal.Text = (Math.Round(double.Parse(lblNominal.Text) - double.Parse(lblDescuento.Text)+double.Parse(lblIva.Text),2)).ToString();

                lblCordoba.Text = Math.Round(double.Parse(lblTotal.Text) * double.Parse(lblTasa.Text), 2).ToString();
            }
        }

        private void PnlVentas_Load(object sender, EventArgs e)
        {

        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFactura_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSeleccionarAtaud_Click(object sender, EventArgs e)
        {
            //Verificar que haya seleccionada una fila en el stock

            if (dgvStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ningun ataud","Error");
                return;
            }

            //Verificar que haya algo en el descuento
            if (txtDescuento.Text == "")
            {
                txtDescuento.Text = "";
            }
            //Verificar que el ataud no se haya agregado antes
            if (dgvAtaudes.Rows.Count > 0)
            {

                for(int i =0; i< dgvAtaudes.Rows.Count; i++)
                {
                    if (dgvStock.SelectedRows[0].Cells[5].Value.ToString() == dgvAtaudes.Rows[i].Cells[3].Value.ToString())
                    {
                        MessageBox.Show("El ataud ya fue seleccionado", "Error");
                        return;
                    }
                }
                
            }

            //Agregar al dtagrid


            dgvAtaudes.Rows.Add(dgvStock.SelectedRows[0].Cells[0].Value.ToString(), dgvStock.SelectedRows[0].Cells[1].Value.ToString(), dgvStock.SelectedRows[0].Cells[2].Value.ToString(), dgvStock.SelectedRows[0].Cells[5].Value.ToString(),txtDescuento.Text);


            RealizarCalculos();
            txtDescuento.Text = "0";

            lblNominal.Text = "x";

            lblDescuento.Text = "x";

            lblIva.Text = "x";

            lblTotal.Text = "x";

            lblCordoba.Text = "x";
        }

        private void btnSeleccionarServicio_Click(object sender, EventArgs e)
        {
            //Verificar que la cantidad no sea cero

            if (txtCantidad.Text=="0")
            {
                MessageBox.Show("La cantidad de servicios no puede ser cero", "Error");
                return;
            }
            if (txtDescServicio.Text == "")
            {
                txtDescServicio.Text = "0";
            }
            for (int i = 0; i < dgvServicios.Rows.Count; i++)
            {
                if (cmbServicios.Text == dgvServicios.Rows[i].Cells[1].Value.ToString())
                {
                    MessageBox.Show("El Servicio ya fue seleccionado", "Error");
                    return;
                }
            }

            //Insertar en el data
            dgvServicios.Rows.Add(ventas.Mostra_idXNombre_Categoria(cmbServicios.Text),cmbServicios.Text,ventas.Mostra_PrecioXNombre(cmbServicios.Text),txtCantidad.Text,txtDescServicio.Text);

            RealizarCalculos();

            //Resetear todo\

            txtDescServicio.Text = "0";
            txtCantidad.Text = "1";
        }

        private void btnEliminarFilaAtaud_Click(object sender, EventArgs e)
        {
            if (ventas.Obtener_Estado(idPublico) == "Anulado")
            {
                MessageBox.Show("No se pueden modificar las ventas anuladas", "Error");
                return;
            }
            if (dgvAtaudes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una fila", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (dgvAtaudes.Rows.Count > 0)
                {

                    ventas.Actualizar_Disponible(int.Parse(dgvAtaudes.SelectedRows[0].Cells[0].Value.ToString()));
                    dgvAtaudes.Rows.Remove(dgvAtaudes.CurrentRow);
                    RealizarCalculos();
                    

                    

                    return;
                }
                MessageBox.Show("No hay ataudes Agregados", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void especialButton3_Click(object sender, EventArgs e)
        {
            if (ventas.Obtener_Estado(idPublico) == "Anulado")
            {
                MessageBox.Show("No se pueden modificar las ventas anuladas", "Error");
                return;
            }
            if (dgvServicios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una fila", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (dgvServicios.Rows.Count > 0)
                {
                    dgvServicios.Rows.Remove(dgvServicios.CurrentRow);
                    RealizarCalculos();
                    return;
                }
                MessageBox.Show("No hay Servicios Agregados", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void RealizarCalculos()
        {
            float suma=0;

            double descuento =0;

            //SUMAS DE NOMINALES
            for(int i = 0; i < dgvServicios.Rows.Count; i++)
            {
                suma = suma + (float.Parse(dgvServicios.Rows[i].Cells[2].Value.ToString())* float.Parse(dgvServicios.Rows[i].Cells[3].Value.ToString()));
            }

            for (int i = 0; i < dgvAtaudes.Rows.Count; i++)
            {
                suma = suma + float.Parse(dgvAtaudes.Rows[i].Cells[2].Value.ToString());
            }

            //SUMAS DE DESCUENTOS
            for (int i = 0; i < dgvServicios.Rows.Count; i++)
            {
                descuento = descuento + (((float.Parse(dgvServicios.Rows[i].Cells[2].Value.ToString())/1.15)*(float.Parse(dgvServicios.Rows[i].Cells[4].Value.ToString())/100)* float.Parse(dgvServicios.Rows[i].Cells[3].Value.ToString())));
            }

            for (int i = 0; i < dgvAtaudes.Rows.Count; i++)
            {
                descuento = descuento + ((float.Parse(dgvAtaudes.Rows[i].Cells[2].Value.ToString()) / 1.15) * (float.Parse(dgvAtaudes.Rows[i].Cells[4].Value.ToString()) / 100));
            }
            lblNominalTotal.Text=(Math.Round(suma/1.15,2)).ToString();    

            lblDescuentoTotal.Text = (Math.Round(descuento, 2)).ToString();

            lblIvaTotal.Text = (Math.Round((float.Parse(lblNominalTotal.Text) - float.Parse(lblDescuentoTotal.Text)) * 0.15,2)).ToString();

            lblTotalTotalDolar.Text = (Math.Round(float.Parse(lblNominalTotal.Text) - float.Parse(lblDescuentoTotal.Text) + float.Parse(lblIvaTotal.Text),2)).ToString();

            lblTotalTotalCordoba.Text = Math.Round(double.Parse(lblTotalTotalDolar.Text) * double.Parse(lblTasa.Text), 2).ToString();
        }

        private void txtDescServicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void especialButton2_Click(object sender, EventArgs e)
        {
            if(dgvAtaudes.Rows.Count==0 && dgvServicios.Rows.Count == 0)
            {
                MessageBox.Show("Tiene que seleccionar un servicio o ataud","Error");
                return;
            }
            if (txtFactura.Text == "")
            {
                MessageBox.Show("El numero de factura no puede estar en blanco","Error");
                return;
            }
            if (ventas.Obtener_Estado(idPublico) == "Anulado")
            {
                MessageBox.Show("No se pueden modificar las ventas anuladas", "Error");
                return;
            }

            

                ventas.Actualizar_Detalles(idPublico, txtDescripcion.Text, txtFactura.Text);

            //Verificar si es venta futura,reserva o normal

            if (tipo == "Final")
            {
                txtMonto.Text = "0";
            }
            else
            {
                if(tipo == "VF")
                {
                    if (float.Parse(txtMonto.Text) < 1)
                    {
                        MessageBox.Show("El monto no puede ser menor a 1", "Error");
                        return;
                    }
                    if (float.Parse(txtMonto.Text) > float.Parse(lblTotalTotalDolar.Text))
                    {
                        MessageBox.Show("El monto no puede ser mayor al total", "Error");
                        return;
                    }
                    if (float.Parse(txtMonto.Text) < (float.Parse(lblTotalTotalDolar.Text) / 2))
                    {
                        MessageBox.Show("El monto no puede ser menor al 50 %", "Error");
                        return;
                    }

                }
                if(tipo == "Reserva")
                {
                    if (float.Parse(txtMonto.Text) <1)
                    {
                        MessageBox.Show("El monto no puede ser menor a 1", "Error");
                        return;
                    }
                    if (float.Parse(txtMonto.Text) > float.Parse(lblTotalTotalDolar.Text))
                    {
                        MessageBox.Show("El monto no puede ser mayor al total", "Error");
                        return;
                    }
                    if (float.Parse(txtMonto.Text) > (float.Parse(lblTotalTotalDolar.Text) / 2))
                    {
                        MessageBox.Show("El monto no puede ser mayor al 50 %", "Error");
                        return;
                    }

                }
            }

            //Actualizar monto

            ventas.Actualizar_Monto(idPublico,float.Parse(txtMonto.Text));

                //Borrar detalles de la venta

                ventas.Actualizar_Delete(idPublico);

            //Insertar detalles nuevamente

            //LLenado de los detalles
            if (dgvAtaudes.Rows.Count != 0)
                {
                    for (int i = 0; i < dgvAtaudes.Rows.Count; i++)
                    {
                        ventas.VentaFutura(idPublico, int.Parse(dgvAtaudes.Rows[i].Cells[4].Value.ToString()), int.Parse(dgvAtaudes.Rows[i].Cells[0].Value.ToString()));

                        //Cambios de estado para los estandares

                        ventas.VentaDirectas_Estandares(int.Parse(dgvAtaudes.Rows[i].Cells[0].Value.ToString()));
                    }
                }

            //LLenado de detalles de servicios
            if (dgvServicios.Rows.Count != 0)
            {
                for (int i = 0; i < dgvServicios.Rows.Count; i++)
                {
                    ventas.VentaReserva(idPublico, int.Parse(dgvServicios.Rows[i].Cells[4].Value.ToString()), int.Parse(dgvServicios.Rows[i].Cells[0].Value.ToString()), int.Parse(dgvServicios.Rows[i].Cells[3].Value.ToString()));
                }
            }

            MessageBox.Show("Venta Actualizada con exito", "Correcto");

            this.Close();
        }

       
    }
}
