﻿using NeoCobranza.Clases;
using NeoCobranza.Data;
using NeoCobranza.DataController;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles;
using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NeoCobranza.Paneles_Venta
{
    public partial class PnlVentas : Form
    {
        public PnlVendedores pnlVendedores;
        public VMOrdenes vMOrdenes = new VMOrdenes();
        public string auxOpc = "";
        DataUtilities dataUtilities = new DataUtilities();
        public PnlPrincipal auxPnlPrincipal;
        public string auxClienteCreacion = "0";
        public string auxSucursal = "";
        private System.Threading.Timer codigoBarraTimer;

        //Constructor
        public PnlVentas(string opc, PnlPrincipal pnlPrincipal, string sucursal, decimal ordenId = 0, string mesaAux = "-", string clienteId = "0")
        {
            this.auxSucursal = sucursal;
            InitializeComponent();
            this.DoubleBuffered = true;
            auxOpc = opc;
            vMOrdenes.OrdenAux = ordenId;
            this.Enter += new EventHandler(Form1_Enter);
            //UIUtilities.PersonalizarDataGridView(dgvCatalogoOrdenes);
            //UIUtilities.PersonalizarDataGridView(DgvProductos);
            UIUtilities.PersonalizarDataGridView(DgvItemsOrden);
            this.auxPnlPrincipal = pnlPrincipal;
            vMOrdenes.MesaAux = mesaAux;
            auxClienteCreacion = clienteId;

            if (mesaAux != "-")
            {
                LblOrdenMesa.Visible = true;
                LblTituloSala.Visible = true;
            }

            codigoBarraTimer = new System.Threading.Timer(CodigoBarraTimer_Callback, null, Timeout.Infinite, Timeout.Infinite);
        }


        private void Form1_Enter(object sender, EventArgs e)
        {
            // Cuando el formulario recibe el foco, establecer el foco en el TextBox deseado
            TxtCodigoProducto.Focus();
        }

        private void PnlVentas_Load(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 32))
            {
                ChkPropina.Enabled = false;
            }

            this.TxtCodigoProducto.LostFocus += new System.EventHandler(textBox_LostFocus);
            vMOrdenes.InitModuloOrdenes(this, auxOpc, "");
        }

        private void textBox_LostFocus(object sender, EventArgs e)
        {
            //if (TCMain.SelectedIndex == 0)
            //{
            //    ((System.Windows.Forms.TextBox)sender).Focus();
            //}
        }

        private void BtnCliente_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 30))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Panel_Cliente_Contrato panelCliente = new Panel_Cliente_Contrato("Venta");
            AddOwnedForm(panelCliente);
            panelCliente.ShowDialog();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            vMOrdenes.ConfigUI(this, "Menu");
        }

        private void BtnAgregarPro_Click(object sender, EventArgs e)
        {
            //vMOrdenes.ConfigUI(this, "Productos");
            auxPnlPrincipal.AbrirProductos(vMOrdenes.OrdenAux, auxSucursal, "Productos", ChkRetencionDgi.Checked, ChkRetencionAlcaldia.Checked, TxtDescuento.Text);
        }

        private void BtnAgregarServicio_Click(object sender, EventArgs e)
        {
            auxPnlPrincipal.AbrirProductos(vMOrdenes.OrdenAux, auxSucursal, "Servicios", ChkRetencionDgi.Checked, ChkRetencionAlcaldia.Checked, TxtDescuento.Text);
        }

        private void BtnPagarOrden_Click(object sender, EventArgs e)
        {
            PnlPago frm = new PnlPago(this, auxSucursal);
            frm.ShowDialog();

            if (LblProcesoPago.Text == "Totalmente Pagado")
            {
                vMOrdenes.InitModuloOrdenes(this, "OrdenRapida", vMOrdenes.OrdenAux.ToString());
            }
        }

        //private void BtnBuscar_Click(object sender, EventArgs e)
        //{
        //    vMOrdenes.FuncionesPrincipales(this);
        //}

        //private void CmbTipoServicio_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    vMOrdenes.FuncionesPrincipales(this);
        //}

        private void TxtCantidadProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, la tecla de retroceso y el punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                // Si no es un número, un punto decimal ni una tecla de control, ignorar la entrada
                e.Handled = true;
            }

            // Verificar si ya hay un punto decimal en el texto
            if (e.KeyChar == '.' && ((sender as System.Windows.Forms.TextBox)?.Text.IndexOf('.') > -1))
            {
                // Si ya hay un punto decimal, ignorar la entrada
                e.Handled = true;
            }
        }

        //private void DgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == 5)
        //    {
        //        if (vMOrdenes.auxSubModulo == "Productos")
        //        {
        //            object cellValue = DgvProductos.Rows[e.RowIndex].Cells[0].Value;
        //            PnlDisponibilidad disponibilidad = new PnlDisponibilidad(cellValue.ToString());
        //            disponibilidad.ShowDialog();
        //        }
        //        else
        //        {
        //            MessageBox.Show("No se puede revisar la disponibilidad en servicios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }

        //    }

        //    if (e.ColumnIndex == 4)
        //    {
        //        int Prueba;
        //        if (int.TryParse(TxtCantidadProducto.Text.Trim(), out Prueba) == false || TxtCantidadProducto.Text.Trim() == "0"
        //            || TxtCantidadProducto.Text.Trim() == "00" || TxtCantidadProducto.Text.Trim() == "000" || TxtCantidadProducto.Text.Trim() == "0000")
        //        {
        //            MessageBox.Show("Debe agregar una cantidad valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            TxtCantidadProducto.Text = "1";
        //            return;
        //        }

        //        object cellValue = DgvProductos.Rows[e.RowIndex].Cells[0].Value;

        //        vMOrdenes.AgregarProductosOrden(this, cellValue.ToString(), TxtCantidadProducto.Text.Trim(), "Increase");
        //    }
        //}

        private void ChkRetencionDgi_Click(object sender, EventArgs e)
        {
            vMOrdenes.CalcularTotales(this, TxtDescuento.Text);
        }

        private void ChkRetencionAlcaldia_Click(object sender, EventArgs e)
        {
            vMOrdenes.CalcularTotales(this, TxtDescuento.Text);
        }


        private void LblIdClientes_TextChanged(object sender, EventArgs e)
        {
            if (LblNombreClientes.Text.Trim() != "-")
            {
                var informativeMessageBox = new InformativeMessageBox($"El Cliente se ha cambiado correctamente.", "Cambio de Cliente", 3000); // 3000 milisegundos = 3 segundos
                informativeMessageBox.Show();
            }
        }

        private void DgvItemsOrden_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (LblProcesoPago.Text != "Totalmente Pagado")
            {

                //Agregar
                if (DgvItemsOrden.Columns[e.ColumnIndex].Name == "Agregar")
                {
                    int Prueba;
                    if (int.TryParse(TxtCantidadItems.Text.Trim(), out Prueba) == false || TxtCantidadItems.Text.Trim() == "0"
                        || TxtCantidadItems.Text.Trim() == "00" || TxtCantidadItems.Text.Trim() == "000" || TxtCantidadItems.Text.Trim() == "0000")
                    {
                        MessageBox.Show("Debe agregar una cantidad valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtCantidadItems.Text = "1";
                        return;
                    }

                    object cellValue = DgvItemsOrden.Rows[e.RowIndex].Cells["Id Producto"].Value;

                    vMOrdenes.AgregarProductosOrden(this, cellValue.ToString(), TxtCantidadItems.Text.Trim(), "Increase");
                }

                //Quitar
                if (DgvItemsOrden.Columns[e.ColumnIndex].Name == "Quitar")
                {
                    int Prueba;
                    if (int.TryParse(TxtCantidadItems.Text.Trim(), out Prueba) == false || TxtCantidadItems.Text.Trim() == "0"
                        || TxtCantidadItems.Text.Trim() == "00" || TxtCantidadItems.Text.Trim() == "000" || TxtCantidadItems.Text.Trim() == "0000")
                    {
                        MessageBox.Show("Debe agregar una cantidad valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtCantidadItems.Text = "1";
                        return;
                    }

                    if (decimal.Parse(TxtTotalPagado.Text) != 0)
                    {
                        MessageBox.Show("No puede quitar productos si ya ha agrego pagos a la orden.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    object cellValue = DgvItemsOrden.Rows[e.RowIndex].Cells["Id Producto"].Value;

                    vMOrdenes.AgregarProductosOrden(this, cellValue.ToString(), TxtCantidadItems.Text.Trim(), "Decrease");
                }


                //Quitar
                if (DgvItemsOrden.Columns[e.ColumnIndex].Name == "Todo")
                {
                    DialogResult result = MessageBox.Show("¿Estás seguro que deseas hacer esta acción?", "Quitar Producto Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                    if (result == DialogResult.Yes)
                    {

                        int Prueba;
                        if (int.TryParse(TxtCantidadItems.Text.Trim(), out Prueba) == false || TxtCantidadItems.Text.Trim() == "0"
                            || TxtCantidadItems.Text.Trim() == "00" || TxtCantidadItems.Text.Trim() == "000" || TxtCantidadItems.Text.Trim() == "0000")
                        {
                            MessageBox.Show("Debe agregar una cantidad valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            TxtCantidadItems.Text = "1";
                            return;
                        }

                        if (decimal.Parse(TxtTotalPagado.Text) != 0)
                        {
                            MessageBox.Show("No puede quitar productos si ya ha agrego pagos a la orden.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }


                        object cellValue = DgvItemsOrden.Rows[e.RowIndex].Cells["Id Producto"].Value;
                        object cellValueCantidad = DgvItemsOrden.Rows[e.RowIndex].Cells["Cantidad"].Value;

                        vMOrdenes.AgregarProductosOrden(this, cellValue.ToString(), cellValueCantidad.ToString(), "Decrease");
                    }
                }

            }
            else
            {
                MessageBox.Show("No se pueden agregar productos/servicios a la orden si ya fue pagada.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TxtCantidadItems_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, la tecla de retroceso y el punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                // Si no es un número, un punto decimal ni una tecla de control, ignorar la entrada
                e.Handled = true;
            }

            // Verificar si ya hay un punto decimal en el texto
            if (e.KeyChar == '.' && ((sender as System.Windows.Forms.TextBox)?.Text.IndexOf('.') > -1))
            {
                // Si ya hay un punto decimal, ignorar la entrada
                e.Handled = true;
            }
        }

        private void BtnVolverFormasPago_Click(object sender, EventArgs e)
        {
            vMOrdenes.ConfigUI(this, "Menu");
        }

        private void BtnEfectivo_Click(object sender, EventArgs e)
        {
            vMOrdenes.ConfigUI(this, "Efectivo");
        }

        private void BtnVolverEfectivo_Click(object sender, EventArgs e)
        {
            vMOrdenes.ConfigUI(this, "Pagar");
        }

        //private void BtnEfectivoUno_Click(object sender, EventArgs e)
        //{
        //    System.Windows.Forms.Button clickedButton = (System.Windows.Forms.Button)sender;

        //    if (clickedButton.Text == ".")
        //    {
        //        // Verifica si ya existe un punto en el texto
        //        if (TxtCantidadAbonadaEfectivo.Text.Contains("."))
        //        {
        //            // Si ya existe un punto, no se hace nada
        //            return;
        //        }
        //    }
        //    else if (TxtCantidadAbonadaEfectivo.Text.Contains("."))
        //    {
        //        // Si ya hay un punto decimal en el texto, se verifica la cantidad de dígitos después del punto
        //        int index = TxtCantidadAbonadaEfectivo.Text.IndexOf(".");
        //        string decimals = TxtCantidadAbonadaEfectivo.Text.Substring(index + 1);
        //        if (decimals.Length >= 2)
        //        {
        //            // Si ya hay dos dígitos después del punto, no se agrega más
        //            return;
        //        }
        //    }

        //    // Agrega el texto del botón al final del texto en el TextBox
        //    TxtCantidadAbonadaEfectivo.Text += clickedButton.Text;
        //}

        //private void BtnEfectivoDos_Click(object sender, EventArgs e)
        //{
        //    BotonesCalc(sender);
        //}

        //private void BtnEfectivoTres_Click(object sender, EventArgs e)
        //{
        //    BotonesCalc(sender);
        //}

        //private void BtnEfectivoCuatro_Click(object sender, EventArgs e)
        //{
        //    BotonesCalc(sender);
        //}

        //private void BtnEfectivoCinco_Click(object sender, EventArgs e)
        //{
        //    BotonesCalc(sender);
        //}

        //private void BtnEfectivoSeis_Click(object sender, EventArgs e)
        //{
        //    BotonesCalc(sender);
        //}

        //private void BtnEfectivoSiete_Click(object sender, EventArgs e)
        //{
        //    BotonesCalc(sender);
        //}

        //private void BtnEfectivoOcho_Click(object sender, EventArgs e)
        //{
        //    BotonesCalc(sender);
        //}

        //private void BtnEfectivoNueve_Click(object sender, EventArgs e)
        //{
        //    BotonesCalc(sender);
        //}

        //private void BtnEfectivoPunto_Click(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(TxtCantidadAbonadaEfectivo.Text))
        //    {
        //        if (TxtCantidadAbonadaEfectivo.Text.Contains("."))
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            BotonesCalc(sender);
        //        }
        //    }
        //}

        //private void BtnEfectivoCero_Click(object sender, EventArgs e)
        //{
        //    BotonesCalc(sender);
        //}

        //private void BtnEfectivoBorrar_Click(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(TxtCantidadAbonadaEfectivo.Text))
        //    {
        //        TxtCantidadAbonadaEfectivo.Text = TxtCantidadAbonadaEfectivo.Text.Substring(0, TxtCantidadAbonadaEfectivo.Text.Length - 1);
        //        TxtCantidadAbonadaEfectivo.SelectionStart = TxtCantidadAbonadaEfectivo.Text.Length;

        //        if (TxtCantidadAbonadaEfectivo.Text.Trim() == "")
        //        {
        //            TxtCantidadAbonadaEfectivo.Text = "0";
        //        }

        //        if (double.Parse(TxtCantidadAbonadaEfectivo.Text) > double.Parse(TxtTotalEfectivo.Text))
        //        {
        //            TxtDiferenciaEfectivo.Text = (Math.Round(double.Parse(TxtCantidadAbonadaEfectivo.Text) - double.Parse(TxtTotalEfectivo.Text), 2)).ToString();
        //        }
        //        else
        //        {
        //            TxtDiferenciaEfectivo.Text = "0";
        //        }
        //    }
        //}

        //private void BotonesCalc(object sender)
        //{
        //    System.Windows.Forms.Button clickedButton = (System.Windows.Forms.Button)sender;

        //    if (clickedButton.Text == ".")
        //    {
        //        // Verifica si ya existe un punto en el texto
        //        if (TxtCantidadAbonadaEfectivo.Text.Contains("."))
        //        {
        //            // Si ya existe un punto, no se hace nada
        //            return;
        //        }
        //    }
        //    else if (TxtCantidadAbonadaEfectivo.Text.Contains("."))
        //    {
        //        // Si ya hay un punto decimal en el texto, se verifica la cantidad de dígitos después del punto
        //        int index = TxtCantidadAbonadaEfectivo.Text.IndexOf(".");
        //        string decimals = TxtCantidadAbonadaEfectivo.Text.Substring(index + 1);
        //        if (decimals.Length >= 2)
        //        {
        //            // Si ya hay dos dígitos después del punto, no se agrega más
        //            return;
        //        }
        //    }

        //    // Agrega el texto del botón al final del texto en el TextBox
        //    TxtCantidadAbonadaEfectivo.Text += clickedButton.Text;

        //    if (double.Parse(TxtCantidadAbonadaEfectivo.Text) > double.Parse(TxtTotalEfectivo.Text))
        //    {
        //        TxtDiferenciaEfectivo.Text = (Math.Round(double.Parse(TxtCantidadAbonadaEfectivo.Text) - double.Parse(TxtTotalEfectivo.Text), 2)).ToString();
        //    }
        //    else
        //    {
        //        TxtDiferenciaEfectivo.Text = "0";
        //    }
        //}

        //private void BotonesCalcCredito(Object sender)
        //{
        //    System.Windows.Forms.Button clickedButton = (System.Windows.Forms.Button)sender;

        //    if (clickedButton.Text == ".")
        //    {
        //        // Verifica si ya existe un punto en el texto
        //        if (TxtCantidadAbonadaCredito.Text.Contains("."))
        //        {
        //            // Si ya existe un punto, no se hace nada
        //            return;
        //        }
        //    }
        //    else if (TxtCantidadAbonadaCredito.Text.Contains("."))
        //    {
        //        // Si ya hay un punto decimal en el texto, se verifica la cantidad de dígitos después del punto
        //        int index = TxtCantidadAbonadaCredito.Text.IndexOf(".");
        //        string decimals = TxtCantidadAbonadaCredito.Text.Substring(index + 1);
        //        if (decimals.Length >= 2)
        //        {
        //            // Si ya hay dos dígitos después del punto, no se agrega más
        //            return;
        //        }
        //    }

        //    // Agrega el texto del botón al final del texto en el TextBox
        //    TxtCantidadAbonadaCredito.Text += clickedButton.Text;

        //}

        //private void BotonesCalcCheque(Object sender)
        //{
        //    System.Windows.Forms.Button clickedButton = (System.Windows.Forms.Button)sender;

        //    if (clickedButton.Text == ".")
        //    {
        //        // Verifica si ya existe un punto en el texto
        //        if (TxtCantidadAbonadaCheque.Text.Contains("."))
        //        {
        //            // Si ya existe un punto, no se hace nada
        //            return;
        //        }
        //    }
        //    else if (TxtCantidadAbonadaCheque.Text.Contains("."))
        //    {
        //        // Si ya hay un punto decimal en el texto, se verifica la cantidad de dígitos después del punto
        //        int index = TxtCantidadAbonadaCheque.Text.IndexOf(".");
        //        string decimals = TxtCantidadAbonadaCheque.Text.Substring(index + 1);
        //        if (decimals.Length >= 2)
        //        {
        //            // Si ya hay dos dígitos después del punto, no se agrega más
        //            return;
        //        }
        //    }

        //    // Agrega el texto del botón al final del texto en el TextBox
        //    TxtCantidadAbonadaCheque.Text += clickedButton.Text;

        //}

        //private void BtnPagarEfectivo_Click(object sender, EventArgs e)
        //{
        //    if (TxtDiferenciaEfectivo.Text != "0")
        //    {
        //        MessageBox.Show($"Debe dar {TxtDiferenciaEfectivo.Text} (NIO) de Cambio.", "Cambio o Diferencia", MessageBoxButtons.OK,
        //            MessageBoxIcon.Information);
        //    }

        //    if (decimal.Parse(TxtCantidadAbonadaEfectivo.Text) == 0)
        //    {
        //        MessageBox.Show("Debe digitar la cantidad abonada.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }


        //    using (NeoCobranzaContext db = new NeoCobranzaContext())
        //    {
        //        Pagos pago = new Pagos()
        //        {
        //            OrdenId = int.Parse(LblNoOrden.Text),
        //            FormaPago = "Efectivo",
        //            Pagado = decimal.Parse(TxtCantidadAbonadaEfectivo.Text),
        //            Cambio = decimal.Parse(TxtDiferenciaEfectivo.Text),
        //            BancoId = 0,
        //            Estado = "Activo",
        //            Total = decimal.Parse(TxtCantidadAbonadaEfectivo.Text) - decimal.Parse(TxtDiferenciaEfectivo.Text)
        //        };

        //        db.Add(pago);
        //        db.SaveChanges();

        //        Ordenes orden = db.Ordenes.Where(s => s.OrdenId == int.Parse(LblNoOrden.Text)).FirstOrDefault();

        //        if (decimal.Parse(TxtTotalPagado.Text) == 0)
        //        {
        //            orden.PagoProceso = "Con Pagos";
        //            LblProcesoPago.Text = "Con Pagos";
        //            orden.Pagado = decimal.Parse(TxtTotalPagado.Text) + (decimal.Parse(TxtCantidadAbonadaEfectivo.Text) - decimal.Parse(TxtDiferenciaEfectivo.Text));

        //            ChkRetencionAlcaldia.Enabled = false;
        //            ChkRetencionDgi.Enabled = false;

        //            db.Update(orden);
        //            db.SaveChanges();
        //        }

        //        TxtTotalPagado.Text = (decimal.Parse(TxtTotalPagado.Text) + (decimal.Parse(TxtCantidadAbonadaEfectivo.Text) - decimal.Parse(TxtDiferenciaEfectivo.Text))).ToString();

        //        if (decimal.Parse(TxtTotalPagado.Text) == decimal.Parse(TxtTotalCordoba.Text))
        //        {
        //            orden.OrdenProceso = "Orden Cerrada";
        //            orden.PagoProceso = "Totalmente Pagada";

        //            db.Update(orden);
        //            db.SaveChanges();

        //            this.Close();
        //            MessageBox.Show("Orden pagada correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        else
        //        {
        //            TCMain.SelectedIndex = 0;

        //            MessageBox.Show("Pago Realizado.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //}

        private void BtnNotaOrden_Click(object sender, EventArgs e)
        {
            AgregarNotaOrden nota = new AgregarNotaOrden(LblNoOrden.Text, auxSucursal);
            nota.ShowDialog();
        }

        private void BtnCancelarOrden_Click(object sender, EventArgs e)
        {
            PnlCancelarOrden pnlCancelarOrden = new PnlCancelarOrden(LblNoOrden.Text, this, auxSucursal);
            pnlCancelarOrden.ShowDialog();
        }

        private void BtnListaOrdenes_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 28))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            auxPnlPrincipal.AbrirListaVentas();
        }

        private void BtnVoverLista_Click(object sender, EventArgs e)
        {
            vMOrdenes.ConfigUI(this, "Menu");
        }

        private void CodigoBarraTimer_Callback(object state)
        {
            this.Invoke((MethodInvoker)delegate
            {
                FuncionCodigoBarra();
            });

        }

        private bool ignoreTextChanged = false;
        public string auxIdProducto = "0";
        public int auxCantidad = 0;
        private void FuncionCodigoBarra()
        {
            //int prueba = 0;
            //if (ChkAutomatico.Checked)
            //{
            //    if (TxtCodigoProducto.Text.Length > 0 && int.TryParse(TxtCantidadItems.Text, out prueba) == true && prueba != 0)
            //    {
            //        DataTable dtResponse = dataUtilities.getRecordByColumn("ProductosServicios", "Codigo", TxtCodigoProducto.Text.Trim());


            //        if (dtResponse.Rows.Count > 0)
            //        {
            //            vMOrdenes.AgregarProductosOrden(this, Convert.ToString(dtResponse.Rows[0]["ProductoId"]), TxtCantidadItems.Text, "Increase");
            //            TxtCodigoProducto.Text = string.Empty;
            //            TxtCodigoProducto.Focus();
            //        }
            //    }
            //}

            if (ignoreTextChanged || string.IsNullOrWhiteSpace(TxtCodigoProducto.Text))
                return;

            PnlAgregarProductosOrden frm = new PnlAgregarProductosOrden(this);
            frm.ShowDialog();

            if (auxIdProducto != "0" && auxCantidad != 0)
            {
                vMOrdenes.AgregarProductosOrden(this, Convert.ToString(auxIdProducto), auxCantidad.ToString(), "Increase");
                TxtCodigoProducto.Text = string.Empty;
                TxtCodigoProducto.Focus();
            }

            auxIdProducto = "0";
            auxCantidad = 0;

            TxtCodigoProducto.Text = string.Empty;
        }

        private void TxtCodigoProducto_TextChanged(object sender, EventArgs e)
        {
            codigoBarraTimer.Change(500, Timeout.Infinite);
        }

        private void BtnBuscarCodigo_Click(object sender, EventArgs e)
        {
            FuncionCodigoBarra();
        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void dgvCatalogo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 0)
            //{
            //    vMOrdenes.OrdenAux = int.Parse(dgvCatalogoOrdenes.Rows[e.RowIndex].Cells[2].Value.ToString());
            //    vMOrdenes.InitModuloOrdenes(this, "OrdenRapida", "");
            //}
            //else if (e.ColumnIndex == 1)
            //{
            //    PnlCancelarOrden pnlCancelarOrden = new PnlCancelarOrden(dgvCatalogoOrdenes.Rows[e.RowIndex].Cells[2].Value.ToString(), this);
            //    pnlCancelarOrden.ShowDialog();
            //}
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            TxtCodigoProducto.Focus();
        }

        private void PnlVentas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') // El caracter '\r' representa el retorno de carro (Enter)
            {
                // Mover el foco al campo de texto deseado
                TxtCodigoProducto.Focus();
            }
        }

        private void especialButton11_Click(object sender, EventArgs e)
        {
            vMOrdenes.ConfigUI(this, "Credito");
        }

        //private void BtnCreditoUno_Click(object sender, EventArgs e)
        //{
        //    BotonesCalcCredito(sender);
        //}

        //private void BtnCreditoDos_Click(object sender, EventArgs e)
        //{
        //    BotonesCalcCredito(sender);
        //}

        //private void BtnCreditoTres_Click(object sender, EventArgs e)
        //{
        //    BotonesCalcCredito(sender);
        //}

        //private void BtnCreditoCuatro_Click(object sender, EventArgs e)
        //{
        //    BotonesCalcCredito(sender);
        //}

        //private void BtnCreditoCinco_Click(object sender, EventArgs e)
        //{
        //    BotonesCalcCredito(sender);
        //}

        //private void BtnCreditoSeis_Click(object sender, EventArgs e)
        //{
        //    BotonesCalcCredito(sender);
        //}

        //private void BtnCreditoSiete_Click(object sender, EventArgs e)
        //{
        //    BotonesCalcCredito(sender);
        //}

        //private void BtnCreditoOcho_Click(object sender, EventArgs e)
        //{
        //    BotonesCalcCredito(sender);
        //}

        //private void BtnCreditoNueve_Click(object sender, EventArgs e)
        //{
        //    BotonesCalcCredito(sender);
        //}

        //private void BtnCreditoPunto_Click(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(TxtCantidadAbonadaCredito.Text))
        //    {
        //        if (TxtCantidadAbonadaCredito.Text.Contains("."))
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            BotonesCalcCredito(sender);
        //        }
        //    }
        //}

        //private void BtnCreditoCero_Click(object sender, EventArgs e)
        //{
        //    BotonesCalcCredito(sender);
        //}

        //private void BtnCreditoBorrar_Click(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(TxtCantidadAbonadaCredito.Text))
        //    {
        //        TxtCantidadAbonadaCredito.Text = TxtCantidadAbonadaCredito.Text.Substring(0, TxtCantidadAbonadaCredito.Text.Length - 1);
        //        TxtCantidadAbonadaCredito.SelectionStart = TxtCantidadAbonadaCredito.Text.Length;

        //        if (TxtCantidadAbonadaCredito.Text.Trim() == "")
        //        {
        //            TxtCantidadAbonadaCredito.Text = "0";
        //        }
        //    }
        //}

        //private void BtnVolverCredito_Click(object sender, EventArgs e)
        //{
        //    vMOrdenes.ConfigUI(this, "Pagar");
        //}

        //private void BtnPagarCredito_Click(object sender, EventArgs e)
        //{
        //    //Validaciones
        //    //Validar que lo pagado no sea mayor al faltante
        //    if (decimal.Parse(TxtFaltanteCredito.Text) < decimal.Parse(TxtCantidadAbonadaCredito.Text))
        //    {
        //        MessageBox.Show("El monto abonado no puede ser mayor al faltante", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }


        //    if (decimal.Parse(TxtCantidadAbonadaCredito.Text) == 0)
        //    {
        //        MessageBox.Show("Debe digitar la cantidad abonada.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    using (NeoCobranzaContext db = new NeoCobranzaContext())
        //    {
        //        Pagos pago = new Pagos()
        //        {
        //            OrdenId = int.Parse(LblNoOrden.Text),
        //            FormaPago = "Tarjeta",
        //            Pagado = decimal.Parse(TxtCantidadAbonadaCredito.Text),
        //            Cambio = 0,
        //            BancoId = int.Parse(CmbBanco.SelectedValue.ToString()),
        //            Estado = "Activo",
        //            Total = decimal.Parse(TxtCantidadAbonadaCredito.Text)
        //        };

        //        db.Add(pago);
        //        db.SaveChanges();

        //        Ordenes orden = db.Ordenes.Where(s => s.OrdenId == int.Parse(LblNoOrden.Text)).FirstOrDefault();

        //        if (decimal.Parse(TxtTotalPagado.Text) == 0)
        //        {
        //            orden.PagoProceso = "Con Pagos";
        //            LblProcesoPago.Text = "Con Pagos";
        //            orden.Pagado = decimal.Parse(TxtTotalPagado.Text) + decimal.Parse(TxtCantidadAbonadaCredito.Text);

        //            ChkRetencionAlcaldia.Enabled = false;
        //            ChkRetencionDgi.Enabled = false;

        //            db.Update(orden);
        //            db.SaveChanges();
        //        }

        //        TxtTotalPagado.Text = (decimal.Parse(TxtTotalPagado.Text) + decimal.Parse(TxtCantidadAbonadaCredito.Text)).ToString();

        //        if (decimal.Parse(TxtTotalPagado.Text) == decimal.Parse(TxtTotalCordoba.Text))
        //        {
        //            orden.OrdenProceso = "Orden Cerrada";
        //            orden.PagoProceso = "Totalmente Pagada";

        //            db.Update(orden);
        //            db.SaveChanges();
        //            this.Close();
        //            MessageBox.Show("Orden pagada correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        else
        //        {
        //            TCMain.SelectedIndex = 0;

        //            MessageBox.Show("Pago Realizado.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //}

        private void ChkRetencionDgi_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BtnGestionSalas_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 29))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            auxPnlPrincipal.AbrirMesas();
        }

        private void especialButton12_Click(object sender, EventArgs e)
        {
            vMOrdenes.ConfigUI(this, "Cheque");
        }

        private void especialButton17_Click(object sender, EventArgs e)
        {
            vMOrdenes.ConfigUI(this, "Pagar");
        }

        private void especialButton4_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 10))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(TxtTotalCordoba.Text, out var total))
            {
                MessageBox.Show("El total no es valido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(TxtActualizarDescuento.Text, out var descuento))
            {
                MessageBox.Show("El descuento no es valido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (total < descuento)
            {
                MessageBox.Show("El descuento no puede ser mayor al total.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            vMOrdenes.CalcularTotales(this, TxtActualizarDescuento.Text);
        }

        private void BtnCredito_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 8))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PnlVentasCredito frm = new PnlVentasCredito(this);
            frm.ShowDialog();
        }

        private void TxtActualizarDescuento_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtActualizarDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, la tecla de retroceso y el punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                // Si no es un número, un punto decimal ni una tecla de control, ignorar la entrada
                e.Handled = true;
            }

            // Verificar si ya hay un punto decimal en el texto
            if (e.KeyChar == '.' && ((sender as System.Windows.Forms.TextBox)?.Text.IndexOf('.') > -1))
            {
                // Si ya hay un punto decimal, ignorar la entrada
                e.Handled = true;
            }
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 12))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DgvItemsOrden.RowCount > 0)
            {
                DataTable dtConfigFacturacion = dataUtilities.getRecordByColumn("ConfigFacturacion", "SucursalId", Utilidades.SucursalId);
                PnlPago frmPago = new PnlPago(this, auxSucursal);
                frmPago.bit58mm = Convert.ToBoolean(dtConfigFacturacion.Rows[0]["Bit58mm"]);
                frmPago.bit80mm = Convert.ToBoolean(dtConfigFacturacion.Rows[0]["Bit80mm"]);


                frmPago.PrintPDF(true);
            }
            else
            {
                MessageBox.Show("Debe agregar items a la venta para poder generar la proforma.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void TxtBuscarProductos__TextChanged(object sender, EventArgs e)
        {
            //vMOrdenes.FuncionesPrincipales(this);
        }

        private void especialButton3_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 12))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DgvItemsOrden.RowCount > 0)
            {
                PnlPago frmPago = new PnlPago(this, auxSucursal);
                frmPago.PrintPDFA4();
            }
            else
            {
                MessageBox.Show("Debe agregar items a la venta para poder generar la proforma.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TxtCantidadProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void ChkPropina_CheckedChanged(object sender, EventArgs e)
        {
            dataUtilities.SetColumns("BitPropina", ChkPropina.Checked);
            dataUtilities.UpdateRecordByPrimaryKey("Ordenes", vMOrdenes.OrdenAux);
        }

        private void BtnDesvincular_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 7))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dataUtilities.SetColumns("SalaMesa", "-");
            dataUtilities.UpdateRecordByPrimaryKey("Ordenes", vMOrdenes.OrdenAux);
            vMOrdenes.InitModuloOrdenes(this, auxOpc, "");
        }

        private void ChkRetencionAlcaldia_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChkPropina_Click(object sender, EventArgs e)
        {
            vMOrdenes.CalcularTotales(this, TxtDescuento.Text);
        }

        private void BtnImprimirIndividual_Click(object sender, EventArgs e)
        {
            PnlImprimeTicketsDetalle frm = new PnlImprimeTicketsDetalle(vMOrdenes.OrdenAux.ToString(), auxSucursal);
            frm.ShowDialog();
        }

        private void BtnAddClientes_Click(object sender, EventArgs e)
        {
            string idCliente = vMOrdenes.auxClienteId == "" ? "0" : vMOrdenes.auxClienteId;
            PanelModificarCliente frm = new PanelModificarCliente(null, idCliente, this);
            frm.vMCatalogoCliente.auxKeyUsuario = (vMOrdenes.auxClienteId == "0" || vMOrdenes.auxClienteId == "") ? "Crear" : "Modificar";
            frm.ShowDialog();
        }

        private void BtnComanda_Click(object sender, EventArgs e)
        {
            PnlComandaVenta frm = new PnlComandaVenta(vMOrdenes.OrdenAux.ToString(), auxSucursal);
            frm.ShowDialog();
        }
    }
}
