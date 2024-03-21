using NeoCobranza.Clases;
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
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NeoCobranza.Paneles_Venta
{
    public partial class PnlVentas : Form
    {
        public PnlVendedores pnlVendedores;
        VMOrdenes vMOrdenes = new VMOrdenes();
        public string auxOpc = "";

        //Constructor
        public PnlVentas(Conexion conexion,string opc)
        {
            InitializeComponent();
            pnlVendedores = new PnlVendedores(conexion,"Venta");
            AddOwnedForm(pnlVendedores);
            auxOpc = opc;

            this.Enter += new EventHandler(Form1_Enter);
        }


        private void Form1_Enter(object sender, EventArgs e)
        {
            // Cuando el formulario recibe el foco, establecer el foco en el TextBox deseado
            TxtCodigoProducto.Focus();
        }

        private void PnlVentas_Load(object sender, EventArgs e)
        {
            this.TxtCodigoProducto.LostFocus += new System.EventHandler(textBox_LostFocus);
            vMOrdenes.InitModuloOrdenes(this,auxOpc,"");
        }

        private void textBox_LostFocus(object sender, EventArgs e)
        {
            if(TCMain.SelectedIndex == 0)
            {
                ((System.Windows.Forms.TextBox)sender).Focus();
            }
        }

        private void BtnCliente_Click(object sender, EventArgs e)
        {
            Panel_Cliente_Contrato panelCliente = new Panel_Cliente_Contrato("Venta");
            AddOwnedForm(panelCliente);
            panelCliente.ShowDialog();

            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                Ordenes ordenes = db.Ordenes.Where(s => s.OrdenId == int.Parse(LblNoOrden.Text)).FirstOrDefault();
                ordenes.ClienteId = int.Parse(LblIdClientes.Text);

                db.Update(ordenes);
                db.SaveChanges();
            }
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            vMOrdenes.ConfigUI(this, "Menu");
        }

        private void BtnAgregarPro_Click(object sender, EventArgs e)
        {
            vMOrdenes.ConfigUI(this, "Productos");
        }

        private void BtnAgregarServicio_Click(object sender, EventArgs e)
        {
            vMOrdenes.ConfigUI(this, "Servicios");
        }

        private void BtnPagarOrden_Click(object sender, EventArgs e)
        {
            vMOrdenes.ConfigUI(this, "Pagar");
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            vMOrdenes.FuncionesPrincipales(this);
        }

        private void CmbTipoServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            vMOrdenes.FuncionesPrincipales(this);
        }

        private void TxtCantidadProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número ni la tecla de retroceso, ignorar la entrada de teclado
                e.Handled = true;
            }
        }

        private void DgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (vMOrdenes.auxSubModulo == "Productos")
                {
                    object cellValue = DgvProductos.Rows[e.RowIndex].Cells[0].Value;
                    PnlDisponibilidad disponibilidad = new PnlDisponibilidad(cellValue.ToString());
                    disponibilidad.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No se puede revisar la disponibilidad en servicios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
               
            }

            if (e.ColumnIndex == 5)
            {
                int Prueba;
                if(int.TryParse(TxtCantidadProducto.Text.Trim(), out Prueba) == false || TxtCantidadProducto.Text.Trim() == "0"
                    || TxtCantidadProducto.Text.Trim() == "00" || TxtCantidadProducto.Text.Trim() == "000" || TxtCantidadProducto.Text.Trim() == "0000")
                {
                    MessageBox.Show("Debe agregar una cantidad valida","Atención", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    TxtCantidadProducto.Text = "1";
                    return;
                }

                object cellValue = DgvProductos.Rows[e.RowIndex].Cells[0].Value;
                
                vMOrdenes.AgregarProductosOrden(this, cellValue.ToString(),TxtCantidadProducto.Text.Trim(),"Aumentar");

                var informativeMessageBox = new InformativeMessageBox($"Producto {DgvProductos.Rows[e.RowIndex].Cells[1].Value.ToString()} Agregado Correctamente a la Orden.", "Producto Agregado", 3000); // 3000 milisegundos = 3 segundos
                informativeMessageBox.Show();
            }
        }

        private void ChkRetencionDgi_Click(object sender, EventArgs e)
        {
            vMOrdenes.AgregarProductosOrden(this,"", "", "Aumentar");
        }

        private void ChkRetencionAlcaldia_Click(object sender, EventArgs e)
        {
            vMOrdenes.AgregarProductosOrden(this, "", "", "Aumentar");
        }


        private void LblIdClientes_TextChanged(object sender, EventArgs e)
        {
            if (LblIdClientes.Text.Trim() != "-")
            {
                var informativeMessageBox = new InformativeMessageBox($"El Cliente se ha cambiado correctamente.", "Cambio de Cliente", 3000); // 3000 milisegundos = 3 segundos
                informativeMessageBox.Show();
            }
        }

        private void DgvItemsOrden_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Agregar
            if (e.ColumnIndex == 7 )
            {
                int Prueba;
                if (int.TryParse(TxtCantidadItems.Text.Trim(), out Prueba) == false || TxtCantidadItems.Text.Trim() == "0"
                    || TxtCantidadItems.Text.Trim() == "00" || TxtCantidadItems.Text.Trim() == "000" || TxtCantidadItems.Text.Trim() == "0000")
                {
                    MessageBox.Show("Debe agregar una cantidad valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtCantidadProducto.Text = "1";
                    return;
                }

                object cellValue = DgvItemsOrden.Rows[e.RowIndex].Cells[2].Value;

                vMOrdenes.AgregarProductosOrden(this, cellValue.ToString(), TxtCantidadItems.Text.Trim(), "Aumentar");
            }
            else if ((e.ColumnIndex == 0 && LblOrdenMesa.Text == "-"))
            {
                int Prueba;
                if (int.TryParse(TxtCantidadItems.Text.Trim(), out Prueba) == false || TxtCantidadItems.Text.Trim() == "0"
                    || TxtCantidadItems.Text.Trim() == "00" || TxtCantidadItems.Text.Trim() == "000" || TxtCantidadItems.Text.Trim() == "0000")
                {
                    MessageBox.Show("Debe agregar una cantidad valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtCantidadProducto.Text = "1";
                    return;
                }

                object cellValue = DgvItemsOrden.Rows[e.RowIndex].Cells[5].Value;

                vMOrdenes.AgregarProductosOrden(this, cellValue.ToString(), TxtCantidadItems.Text.Trim(), "Aumentar");
            }

            //Quitar
            if (e.ColumnIndex == 8)
            {
                int Prueba;
                if (int.TryParse(TxtCantidadItems.Text.Trim(), out Prueba) == false || TxtCantidadItems.Text.Trim() == "0"
                    || TxtCantidadItems.Text.Trim() == "00" || TxtCantidadItems.Text.Trim() == "000" || TxtCantidadItems.Text.Trim() == "0000")
                {
                    MessageBox.Show("Debe agregar una cantidad valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtCantidadProducto.Text = "1";
                    return;
                }

                object cellValue = DgvItemsOrden.Rows[e.RowIndex].Cells[2].Value;

                vMOrdenes.AgregarProductosOrden(this, cellValue.ToString(), TxtCantidadItems.Text.Trim(), "Disminuir");
            }
            else if ((e.ColumnIndex == 1 && LblOrdenMesa.Text == "-"))
            {
                int Prueba;
                if (int.TryParse(TxtCantidadItems.Text.Trim(), out Prueba) == false || TxtCantidadItems.Text.Trim() == "0"
                    || TxtCantidadItems.Text.Trim() == "00" || TxtCantidadItems.Text.Trim() == "000" || TxtCantidadItems.Text.Trim() == "0000")
                {
                    MessageBox.Show("Debe agregar una cantidad valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtCantidadProducto.Text = "1";
                    return;
                }

                object cellValue = DgvItemsOrden.Rows[e.RowIndex].Cells[5].Value;

                vMOrdenes.AgregarProductosOrden(this, cellValue.ToString(), TxtCantidadItems.Text.Trim(), "Disminuir");
            }

            //Quitar
            if (e.ColumnIndex == 9 )
            {
                DialogResult result = MessageBox.Show("¿Estás seguro que deseas hacer esta acción?", "Quitar Producto Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                
                if (result == DialogResult.Yes)
                {

                    int Prueba;
                    if (int.TryParse(TxtCantidadItems.Text.Trim(), out Prueba) == false || TxtCantidadItems.Text.Trim() == "0"
                        || TxtCantidadItems.Text.Trim() == "00" || TxtCantidadItems.Text.Trim() == "000" || TxtCantidadItems.Text.Trim() == "0000")
                    {
                        MessageBox.Show("Debe agregar una cantidad valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtCantidadProducto.Text = "1";
                        return;
                    }

                    object cellValue = DgvItemsOrden.Rows[e.RowIndex].Cells[2].Value;
                    object cellValueCantidad = DgvItemsOrden.Rows[e.RowIndex].Cells[4].Value;

                    vMOrdenes.AgregarProductosOrden(this, cellValue.ToString(), cellValueCantidad.ToString(), "Disminuir");
                }
            }
            else if((e.ColumnIndex == 2 && LblOrdenMesa.Text == "-"))
            {
                DialogResult result = MessageBox.Show("¿Estás seguro que deseas hacer esta acción?", "Quitar Producto Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                if (result == DialogResult.Yes)
                {

                    int Prueba;
                    if (int.TryParse(TxtCantidadItems.Text.Trim(), out Prueba) == false || TxtCantidadItems.Text.Trim() == "0"
                        || TxtCantidadItems.Text.Trim() == "00" || TxtCantidadItems.Text.Trim() == "000" || TxtCantidadItems.Text.Trim() == "0000")
                    {
                        MessageBox.Show("Debe agregar una cantidad valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtCantidadProducto.Text = "1";
                        return;
                    }

                    object cellValue = DgvItemsOrden.Rows[e.RowIndex].Cells[5].Value;
                    object cellValueCantidad = DgvItemsOrden.Rows[e.RowIndex].Cells[7].Value;

                    vMOrdenes.AgregarProductosOrden(this, cellValue.ToString(), cellValueCantidad.ToString(), "Disminuir");
                }
            }

        }

        private void TxtCantidadItems_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número ni la tecla de retroceso, ignorar la entrada de teclado
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

        private void BtnEfectivoUno_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button clickedButton = (System.Windows.Forms.Button)sender;

            if (clickedButton.Text == ".")
            {
                // Verifica si ya existe un punto en el texto
                if (TxtCantidadAbonadaEfectivo.Text.Contains("."))
                {
                    // Si ya existe un punto, no se hace nada
                    return;
                }
            }
            else if (TxtCantidadAbonadaEfectivo.Text.Contains("."))
            {
                // Si ya hay un punto decimal en el texto, se verifica la cantidad de dígitos después del punto
                int index = TxtCantidadAbonadaEfectivo.Text.IndexOf(".");
                string decimals = TxtCantidadAbonadaEfectivo.Text.Substring(index + 1);
                if (decimals.Length >= 2)
                {
                    // Si ya hay dos dígitos después del punto, no se agrega más
                    return;
                }
            }

            // Agrega el texto del botón al final del texto en el TextBox
            TxtCantidadAbonadaEfectivo.Text += clickedButton.Text;
        }

        private void BtnEfectivoDos_Click(object sender, EventArgs e)
        {
            BotonesCalc(sender);
        }

        private void BtnEfectivoTres_Click(object sender, EventArgs e)
        {
            BotonesCalc(sender);
        }

        private void BtnEfectivoCuatro_Click(object sender, EventArgs e)
        {
            BotonesCalc(sender);
        }

        private void BtnEfectivoCinco_Click(object sender, EventArgs e)
        {
            BotonesCalc(sender);
        }

        private void BtnEfectivoSeis_Click(object sender, EventArgs e)
        {
            BotonesCalc(sender);
        }

        private void BtnEfectivoSiete_Click(object sender, EventArgs e)
        {
            BotonesCalc(sender);
        }

        private void BtnEfectivoOcho_Click(object sender, EventArgs e)
        {
            BotonesCalc(sender);
        }

        private void BtnEfectivoNueve_Click(object sender, EventArgs e)
        {
            BotonesCalc(sender);
        }

        private void BtnEfectivoPunto_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtCantidadAbonadaEfectivo.Text))
            {
                if (TxtCantidadAbonadaEfectivo.Text.Contains("."))
                {
                    return;
                }
                else
                {
                    BotonesCalc(sender);
                }
            }
        }

        private void BtnEfectivoCero_Click(object sender, EventArgs e)
        {
            BotonesCalc(sender);
        }

        private void BtnEfectivoBorrar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtCantidadAbonadaEfectivo.Text))
            {
                TxtCantidadAbonadaEfectivo.Text = TxtCantidadAbonadaEfectivo.Text.Substring(0, TxtCantidadAbonadaEfectivo.Text.Length - 1);
                TxtCantidadAbonadaEfectivo.SelectionStart = TxtCantidadAbonadaEfectivo.Text.Length;

                if(TxtCantidadAbonadaEfectivo.Text.Trim() == "")
                {
                    TxtCantidadAbonadaEfectivo.Text = "0";
                }

                if (double.Parse(TxtCantidadAbonadaEfectivo.Text) > double.Parse(TxtTotalEfectivo.Text))
                {
                    TxtDiferenciaEfectivo.Text = (Math.Round(double.Parse(TxtCantidadAbonadaEfectivo.Text) - double.Parse(TxtTotalEfectivo.Text), 2)).ToString();
                }
                else
                {
                    TxtDiferenciaEfectivo.Text = "0";
                }
            }
        }

        private void BotonesCalc(object sender)
        {
            System.Windows.Forms.Button clickedButton = (System.Windows.Forms.Button)sender;

            if (clickedButton.Text == ".")
            {
                // Verifica si ya existe un punto en el texto
                if (TxtCantidadAbonadaEfectivo.Text.Contains("."))
                {
                    // Si ya existe un punto, no se hace nada
                    return;
                }
            }
            else if (TxtCantidadAbonadaEfectivo.Text.Contains("."))
            {
                // Si ya hay un punto decimal en el texto, se verifica la cantidad de dígitos después del punto
                int index = TxtCantidadAbonadaEfectivo.Text.IndexOf(".");
                string decimals = TxtCantidadAbonadaEfectivo.Text.Substring(index + 1);
                if (decimals.Length >= 2)
                {
                    // Si ya hay dos dígitos después del punto, no se agrega más
                    return;
                }
            }

            // Agrega el texto del botón al final del texto en el TextBox
            TxtCantidadAbonadaEfectivo.Text += clickedButton.Text;

            if(double.Parse(TxtCantidadAbonadaEfectivo.Text) > double.Parse(TxtTotalEfectivo.Text))
            {
                TxtDiferenciaEfectivo.Text = (Math.Round(double.Parse(TxtCantidadAbonadaEfectivo.Text) - double.Parse(TxtTotalEfectivo.Text),2)).ToString();
            }
            else
            {
                TxtDiferenciaEfectivo.Text = "0";
            }
        }

        private void BtnPagarEfectivo_Click(object sender, EventArgs e)
        {
            if(TxtDiferenciaEfectivo.Text != "0")
            {
                MessageBox.Show($"Debe dar {TxtDiferenciaEfectivo.Text} (NIO) de Cambio.", "Cambio o Diferencia",MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void BtnNotaOrden_Click(object sender, EventArgs e)
        {
            AgregarNotaOrden nota = new AgregarNotaOrden(LblNoOrden.Text);
            nota.ShowDialog();
        }

        private void BtnCancelarOrden_Click(object sender, EventArgs e)
        {
            PnlCancelarOrden pnlCancelarOrden = new PnlCancelarOrden("");
            pnlCancelarOrden.ShowDialog();
        }

        private void BtnListaOrdenes_Click(object sender, EventArgs e)
        {
            vMOrdenes.ConfigUI(this, "Lista");
        }

        private void BtnVoverLista_Click(object sender, EventArgs e)
        {
            vMOrdenes.ConfigUI(this, "Menu");
        }

        private void TxtCodigoProducto_TextChanged(object sender, EventArgs e)
        {
            int prueba = 0;
            if(ChkAutomatico.Checked)
            {
                if(TxtCodigoProducto.Text.Length > 0 && int.TryParse(TxtCantidadItems.Text,out prueba) == true && prueba !=0)
                {
                    using(NeoCobranzaContext db = new NeoCobranzaContext())
                    {
                        var servicio = db.ServiciosEstadares.Where(s => s.Codigo == TxtCodigoProducto.Text.Trim()).FirstOrDefault();

                        if(servicio != null)
                        {
                            vMOrdenes.AgregarProductosOrden(this,servicio.IdEstandar.ToString(), TxtCantidadItems.Text, "Aumentar");
                            TxtCodigoProducto.Text = string.Empty;
                            TxtCodigoProducto.Focus();
                        }
                    }
                }
            }
        }

        private void BtnBuscarCodigo_Click(object sender, EventArgs e)
        {
            int prueba = 0;
            if (TxtCodigoProducto.Text.Length > 0 && int.TryParse(TxtCantidadItems.Text, out prueba) == true && prueba != 0)
            {
                using (NeoCobranzaContext db = new NeoCobranzaContext())
                {
                    var servicio = db.ServiciosEstadares.Where(s => s.Codigo == TxtCodigoProducto.Text.Trim()).FirstOrDefault();

                    if (servicio != null)
                    {
                        vMOrdenes.AgregarProductosOrden(this, servicio.IdEstandar.ToString(), TxtCantidadItems.Text, "Aumentar");
                        TxtCodigoProducto.Text = string.Empty;
                        TxtCodigoProducto.Focus();
                    }
                }
            }
        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void dgvCatalogo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex ==  8)
            {
                    vMOrdenes.OrdenAux = int.Parse(dgvCatalogoOrdenes.Rows[e.RowIndex].Cells[0].Value.ToString());
                    vMOrdenes.InitModuloOrdenes(this, "OrdenRapida", "");                
            }
            else if(e.ColumnIndex == 9)
            {
                PnlCancelarOrden pnlCancelarOrden = new PnlCancelarOrden("");
                pnlCancelarOrden.ShowDialog();
            }
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            TxtCodigoProducto.Focus();
        }

        private void PnlVentas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' && TCMain.SelectedIndex == 1) // El caracter '\r' representa el retorno de carro (Enter)
            {
                // Mover el foco al campo de texto deseado
                TxtCodigoProducto.Focus();
            }
        }
    }
}
