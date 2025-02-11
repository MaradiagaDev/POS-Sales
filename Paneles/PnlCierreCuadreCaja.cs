using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles
{
    public partial class PnlCierreCuadreCaja : Form
    {
        DataUtilities dataUtilities = new DataUtilities();
        int IndexSelected = 0;
        decimal tasa = 0;
        public PnlCierreCuadreCaja()
        {
            InitializeComponent();

            UIUtilities.PersonalizarDataGridViewPequeños(dgvGeneral);
            // Actualiza el estilo visual del botón seleccionado
            SetSelectedButton(BtnListaVentas);

            // Cargar datos ordenes
            dataUtilities.SetParameter("@sucursalId", Utilidades.SucursalId);
            dgvGeneral.DataSource = dataUtilities.ExecuteStoredProcedure("vwCierresCajaPagosOrdenes");

            //Calcular los totales
            CalcularTotales();

            DataTable tasaData = dataUtilities.GetAllRecords("vwTasa");

            if (tasaData.Rows.Count > 0)
            {
                tasa = decimal.Parse(tasaData.Rows[0][1].ToString());
            }
        }

        private void CalcularTotales()
        {
            dataUtilities.SetParameter("@sucursalId", Utilidades.SucursalId);
            DataTable data = dataUtilities.ExecuteStoredProcedure("spCierresCajaTotales");

            decimal ventas, ingresos,gastos,totalCaja,calculado,diferencia;

            ventas = Convert.ToDecimal(data.Rows[0]["TotalEfectivoOrdenes"].ToString());
            ingresos = Convert.ToDecimal(data.Rows[0]["TotalIngresos"].ToString());
            gastos = Convert.ToDecimal(data.Rows[0]["TotalGastos"].ToString());

            totalCaja = ventas + ingresos - gastos;
            calculado = Decimal.Parse(TxtCalculoEnCaja.Text);
            diferencia = totalCaja - calculado;

            TxtVentas.Text = ventas.ToString();
            TxtIngresos.Text = ingresos.ToString();
            TxtGasto.Text = gastos.ToString();
            TxtTarjeta.Text = data.Rows[0]["TotalTarjetaOrdenes"].ToString();
            TxtTotalEnCaja.Text = totalCaja.ToString();
            TxtDiferencia.Text = diferencia.ToString();

            RecalcularCaja();
        }

        private void ResetButtonStyles()
        {
            // Establece el color de fondo por defecto (por ejemplo, el color de control del sistema)
            Color defaultColor = SystemColors.Control;

            BtnListaVentas.BackColor = defaultColor;
            BtnListaGastos.BackColor = defaultColor;
            BtnListaIngresos.BackColor = defaultColor;
        }
        private void SetSelectedButton(Button selectedButton)
        {
            // Primero, resetear estilos en todos los botones
            ResetButtonStyles();

            // Luego, establecer el color de fondo del botón seleccionado a un azul claro
            selectedButton.BackColor = Color.LightBlue; // Puedes ajustar este color a tu preferencia
        }


        private void BtnListaVentas_Click(object sender, EventArgs e)
        {
            dgvGeneral.Columns.Clear();
            IndexSelected = 0;

            // Actualiza el estilo visual del botón seleccionado
            SetSelectedButton(BtnListaVentas);

            // Cargar datos ordenes
            dataUtilities.SetParameter("@sucursalId", Utilidades.SucursalId);
            dgvGeneral.DataSource = dataUtilities.ExecuteStoredProcedure("vwCierresCajaPagosOrdenes");

            ActualizarBotonesEnGrid();
        }

        private void BtnListaGastos_Click(object sender, EventArgs e)
        {
            dgvGeneral.Columns.Clear();
            IndexSelected = 1;
            // Actualiza el estilo visual del botón seleccionado
            SetSelectedButton(BtnListaGastos);

            // Cargar datos gastos
            dataUtilities.SetParameter("@sucursalId", Utilidades.SucursalId);
            dataUtilities.SetParameter("@bitIngreso", false);
            dgvGeneral.DataSource = dataUtilities.ExecuteStoredProcedure("vwCierresCajaGastos");

            ActualizarBotonesEnGrid();
        }

        private void BtnListaIngresos_Click(object sender, EventArgs e)
        {
            dgvGeneral.Columns.Clear();
            IndexSelected = 2;

            // Actualiza el estilo visual del botón seleccionado
            SetSelectedButton(BtnListaIngresos);

            // Cargar datos ingresos
            dataUtilities.SetParameter("@sucursalId", Utilidades.SucursalId);
            dataUtilities.SetParameter("@bitIngreso", true);
            dgvGeneral.DataSource = dataUtilities.ExecuteStoredProcedure("vwCierresCajaGastos");

            ActualizarBotonesEnGrid();
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            PnlIngresosPagosCaja frm = new PnlIngresosPagosCaja();
            frm.ShowDialog();

            if(IndexSelected == 1)
            {
                // Cargar datos gastos
                dataUtilities.SetParameter("@sucursalId", Utilidades.SucursalId);
                dataUtilities.SetParameter("@bitIngreso", false);
                dgvGeneral.DataSource = dataUtilities.ExecuteStoredProcedure("vwCierresCajaGastos");
            }
            else if(IndexSelected == 2)
            {
                // Cargar datos ingresos
                dataUtilities.SetParameter("@sucursalId", Utilidades.SucursalId);
                dataUtilities.SetParameter("@bitIngreso", true);
                dgvGeneral.DataSource = dataUtilities.ExecuteStoredProcedure("vwCierresCajaGastos");
            }

            CalcularTotales();
        }
        private void ActualizarBotonesEnGrid()
        {
            if (IndexSelected == 1 || IndexSelected == 2)
            {
                    DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                    btnEliminar.Name = "btnEliminar";
                    btnEliminar.HeaderText = "Eliminar";
                    btnEliminar.Text = "Eliminar";
                    btnEliminar.UseColumnTextForButtonValue = true;
                    dgvGeneral.Columns.Add(btnEliminar);
                
                    DataGridViewButtonColumn btnGenerar = new DataGridViewButtonColumn();
                    btnGenerar.Name = "btnGenerarComprobante";
                    btnGenerar.HeaderText = "Generar Comprobante";
                    btnGenerar.Text = "Generar Comprobante";
                    btnGenerar.UseColumnTextForButtonValue = true;
                    dgvGeneral.Columns.Add(btnGenerar);  
            }
        }

        private void Txt1000_TextChanged(object sender, EventArgs e)
        {
            RecalcularCaja();
        }

        private void Txt500_TextChanged(object sender, EventArgs e)
        {
            RecalcularCaja();
        }

        private void Txt200_TextChanged(object sender, EventArgs e)
        {
            RecalcularCaja();
        }

        private void txt100_TextChanged(object sender, EventArgs e)
        {
            RecalcularCaja();
        }

        private void txt50_TextChanged(object sender, EventArgs e)
        {
            RecalcularCaja();
        }

        private void txt20_TextChanged(object sender, EventArgs e)
        {
            RecalcularCaja();
        }

        private void txt10_TextChanged(object sender, EventArgs e)
        {
            RecalcularCaja();
        }

        private void txt5_TextChanged(object sender, EventArgs e)
        {
            RecalcularCaja();
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {
            RecalcularCaja();
        }

        private void txt05_TextChanged(object sender, EventArgs e)
        {
            RecalcularCaja();
        }

        private void txt025_TextChanged(object sender, EventArgs e)
        {
            RecalcularCaja();
        }

        private void txt01_TextChanged(object sender, EventArgs e)
        {
            RecalcularCaja();
        }

        private void txt100D_TextChanged(object sender, EventArgs e)
        {
            RecalcularCaja();
        }

        private void txt50D_TextChanged(object sender, EventArgs e)
        {
            RecalcularCaja();
        }

        private void txt20D_TextChanged(object sender, EventArgs e)
        {
            RecalcularCaja();
        }

        private void txt10D_TextChanged(object sender, EventArgs e)
        {
            RecalcularCaja();
        }

        private void txt5D_TextChanged(object sender, EventArgs e)
        {
            RecalcularCaja();
        }

        private void txt1D_TextChanged(object sender, EventArgs e)
        {
            RecalcularCaja();
        }

        private void RecalcularCaja()
        {
            decimal total = 0m;

            // Ayuda a convertir el texto a entero (0 si es vacío o no válido)
            int ParseInt(TextBox txt)
            {
                return int.TryParse(txt.Text, out int valor) ? valor : 0;
            }

            // Para cada TextBox de córdobas
            total += ParseInt(Txt1000) * 1000m;
            total += ParseInt(Txt500) * 500m;
            total += ParseInt(Txt200) * 200m;
            total += ParseInt(txt100) * 100m;
            total += ParseInt(txt50) * 50m;
            total += ParseInt(txt20) * 20m;
            total += ParseInt(txt10) * 10m;
            total += ParseInt(txt5) * 5m;
            total += ParseInt(txt1) * 1m;
            total += ParseInt(txt05) * 0.5m;
            total += ParseInt(txt025) * 0.25m;
            total += ParseInt(txt01) * 0.1m;

            // Para cada TextBox en dólares (se convierten a córdobas multiplicando por la tasa)
            total += ParseInt(txt100D) * 100m * tasa;
            total += ParseInt(txt50D) * 50m * tasa;
            total += ParseInt(txt20D) * 20m * tasa;
            total += ParseInt(txt10D) * 10m * tasa;
            total += ParseInt(txt5D) * 5m * tasa;
            total += ParseInt(txt1D) * 1m * tasa;

            // Actualiza el TextBox que muestra el total calculado en caja
            TxtCalculoEnCaja.Text = total.ToString("N2");

            // Si hay un total declarado en caja, se calcula la diferencia
            if (decimal.TryParse(TxtTotalEnCaja.Text, out decimal totalCaja))
            {
                decimal diferencia = totalCaja - total;
                TxtDiferencia.Text = diferencia.ToString("N2");
            }
            else
            {
                // En caso de que no se haya ingresado el total de caja, limpiar la diferencia
                TxtDiferencia.Text = "";
            }
        }

        private void dgvGeneral_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ( dgvGeneral.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                DialogResult resultado = MessageBox.Show("¿Desea continuar con la acción?",
                                           "Confirmación",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);

                // Evalúa la respuesta del usuario
                if (resultado == DialogResult.Yes)
                {
                    dataUtilities.DeleteRecordByColumn("PagosIngresoGasto", "IngresoGastoId", dgvGeneral.Rows[e.RowIndex].Cells[0].Value);
                    CalcularTotales();

                    if (IndexSelected == 1)
                    {
                        // Cargar datos gastos
                        dataUtilities.SetParameter("@sucursalId", Utilidades.SucursalId);
                        dataUtilities.SetParameter("@bitIngreso", false);
                        dgvGeneral.DataSource = dataUtilities.ExecuteStoredProcedure("vwCierresCajaGastos");
                    }
                    else if (IndexSelected == 2)
                    {
                        // Cargar datos ingresos
                        dataUtilities.SetParameter("@sucursalId", Utilidades.SucursalId);
                        dataUtilities.SetParameter("@bitIngreso", true);
                        dgvGeneral.DataSource = dataUtilities.ExecuteStoredProcedure("vwCierresCajaGastos");
                    }
                }
            }

            if (dgvGeneral.Columns[e.ColumnIndex].Name == "btnGenerarComprobante")
            {
                if(IndexSelected == 0)
                {
                    PdfPrintPageEventHandler.PagoId = Convert.ToString(dgvGeneral.Rows[e.RowIndex].Cells[0].Value);
                    PdfPrintPageEventHandler.EsVenta = true;
                    PdfPrintPageEventHandler.PrintPDFRecibo(false);
                }
                else if(IndexSelected == 1)
                {
                    PdfPrintPageEventHandler.PagoId = Convert.ToString(dgvGeneral.Rows[e.RowIndex].Cells[0].Value);
                    PdfPrintPageEventHandler.EsVenta = false;
                    PdfPrintPageEventHandler.PrintPDFRecibo(true);
                }
                else if (IndexSelected == 2)
                {
                    PdfPrintPageEventHandler.PagoId = Convert.ToString(dgvGeneral.Rows[e.RowIndex].Cells[0].Value);
                    PdfPrintPageEventHandler.EsVenta = false;
                    PdfPrintPageEventHandler.PrintPDFRecibo(false);
                }
            }
        }

        // Método auxiliar para validar solo números enteros
        private void PermitirSoloEnteros(KeyPressEventArgs e)
        {
            // Permite dígitos y teclas de control (Backspace, etc.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void Txt1000_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirSoloEnteros(e);
        }

        private void Txt500_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirSoloEnteros(e);
        }

        private void Txt200_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirSoloEnteros(e);
        }

        private void txt100_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirSoloEnteros(e);
        }

        private void txt50_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirSoloEnteros(e);
        }

        private void txt20_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirSoloEnteros(e);
        }

        private void txt10_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirSoloEnteros(e);
        }

        private void txt5_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirSoloEnteros(e);
        }

        private void txt1_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirSoloEnteros(e);
        }

        private void txt05_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirSoloEnteros(e);
        }

        private void txt025_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirSoloEnteros(e);
        }

        private void txt01_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirSoloEnteros(e);
        }

        private void txt100D_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirSoloEnteros(e);
        }

        private void txt50D_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirSoloEnteros(e);
        }

        private void txt20D_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirSoloEnteros(e);
        }

        private void txt10D_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirSoloEnteros(e);
        }

        private void txt5D_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirSoloEnteros(e);
        }

        private void txt1D_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirSoloEnteros(e);
        }

        private void BtnPagarEfectivo_Click(object sender, EventArgs e)
        {
            decimal diferencia = Convert.ToDecimal(TxtDiferencia.Text);

            if(diferencia != 0) 
            {
                DialogResult resultado = MessageBox.Show("Aún hay diferencia en el efectivo, ¿Desea continuar?",
                                           "Confirmación",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);

                // Evalúa la respuesta del usuario
                if (resultado == DialogResult.Yes)
                {
                    dataUtilities.SetColumns("FechaCierre",DateTime.Now);
                    dataUtilities.SetColumns("Usuario",Utilidades.Usuario);
                    dataUtilities.SetColumns("Diferencia",TxtDiferencia.Text);
                    dataUtilities.SetColumns("Ventas",TxtVentas.Text);
                    dataUtilities.SetColumns("Ingresos", TxtIngresos.Text);
                    dataUtilities.SetColumns("Gastos",TxtGasto.Text);
                    dataUtilities.SetColumns("Tarjeta",TxtTarjeta.Text);
                    dataUtilities.SetColumns("Total",TxtTotalEnCaja.Text);
                    dataUtilities.SetColumns("Calculo",TxtCalculoEnCaja.Text);
                    dataUtilities.SetColumns("SucursalId", Utilidades.SucursalId);

                    dataUtilities.InsertRecord("CierreCaja");

                    //pasar los datos a cierre de caja
                    dataUtilities.SetParameter("@sucursalId", Utilidades.SucursalId);
                    dataUtilities.ExecuteStoredProcedure("spCierresCajaRealizar");

                    MessageBox.Show("Cierre de caja realizado correctamente.","Correcto",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    if(IndexSelected == 0)
                    {
                        // Cargar datos ordenes
                        dataUtilities.SetParameter("@sucursalId", Utilidades.SucursalId);
                        dgvGeneral.DataSource = dataUtilities.ExecuteStoredProcedure("vwCierresCajaPagosOrdenes");
                    }
                    else if (IndexSelected == 1)
                    {
                        // Cargar datos gastos
                        dataUtilities.SetParameter("@sucursalId", Utilidades.SucursalId);
                        dataUtilities.SetParameter("@bitIngreso", false);
                        dgvGeneral.DataSource = dataUtilities.ExecuteStoredProcedure("vwCierresCajaGastos");
                    }
                    else if (IndexSelected == 2)
                    {
                        // Cargar datos ingresos
                        dataUtilities.SetParameter("@sucursalId", Utilidades.SucursalId);
                        dataUtilities.SetParameter("@bitIngreso", true);
                        dgvGeneral.DataSource = dataUtilities.ExecuteStoredProcedure("vwCierresCajaGastos");
                    }

                    // Para cada TextBox de córdobas
                    Txt1000.Text = string.Empty;
                    Txt500.Text = string.Empty;
                    Txt200.Text = string.Empty;
                    txt100.Text = string.Empty;
                    txt50.Text = string.Empty;
                    txt20.Text = string.Empty;
                    txt10.Text = string.Empty;
                    txt5.Text = string.Empty;
                    txt1.Text = string.Empty;
                    txt05.Text = string.Empty;
                    txt025.Text = string.Empty;
                    txt01.Text = string.Empty;

                    // Para cada TextBox en dólares (se convierten a córdobas multiplicando por la tasa)
                    txt100D.Text = string.Empty;
                    txt50D.Text = string.Empty;
                    txt20D.Text = string.Empty;
                    txt10D.Text = string.Empty;
                    txt5D.Text = string.Empty;
                    txt1D.Text = string.Empty;

                    CalcularTotales();
                }
            }
        }

        private void BtnRegistrarGastos_Click(object sender, EventArgs e)
        {
            PnlHistorialCierresCaja frm = new PnlHistorialCierresCaja();
            frm.ShowDialog();
        }
    }
}
