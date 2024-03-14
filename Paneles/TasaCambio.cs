using NeoCobranza.ModelsCobranza;
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
    public partial class TasaCambio : Form
    {
        public TasaCambio()
        {
            InitializeComponent();

            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                ModelsCobranza.TipoCambio ultimaTasa = db.TipoCambio
                            .OrderByDescending(tc => tc.IdTasaCambio) 
                            .FirstOrDefault();

                if (ultimaTasa != null)
                {
                    LblTasaActual.Text = $"La tasa de cambio actual es: {ultimaTasa.Tasa.ToString()} (NIO)";
                }
                else
                {
                    LblTasaActual.Text = $"No hay tasa de cambio registradas.";
                }
            }
        }

        private void TxtTasaCambio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter presionado es un número o un punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                // Si no es un número ni un punto decimal, cancelar el evento de pulsación de tecla
                e.Handled = true;
            }

            // Verificar si el carácter presionado es un punto
            if (e.KeyChar == ',')
            {
                // Si hay un punto ya presente o es el primer carácter, cancelar el evento de pulsación de tecla
                if ((sender as TextBox).Text.Contains(',') || (sender as TextBox).Text.Length == 0)
                {
                    e.Handled = true;
                }
            }

            // Limitar a cuatro decimales
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text.Contains(','))
            {
                int index = textBox.Text.IndexOf(',');
                if (textBox.Text.Substring(index).Length > 4 && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                if (TxtTasaCambio.Text.Trim().Length == 0) 
                {
                    MessageBox.Show("Debe digitar una tasa.","Atención",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double prueba = 0;

                if(double.TryParse(TxtTasaCambio.Text.Trim(), out prueba) == false)
                {
                    MessageBox.Show("Debe digitar una tasa valida.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ModelsCobranza.TipoCambio ultimaTasa = db.TipoCambio
                            .OrderByDescending(tc => tc.IdTasaCambio)
                            .FirstOrDefault();

                if(ultimaTasa != null)
                {
                    ultimaTasa.Tasa = double.Parse(TxtTasaCambio.Text.Trim());
                    ultimaTasa.FechaCambio = DateTime.Now;
                    db.Update(ultimaTasa);
                    db.SaveChanges();

                    if (ultimaTasa != null)
                    {
                        LblTasaActual.Text = $"La tasa de cambio actual es: {ultimaTasa.Tasa.ToString()} (NIO)";
                    }
                    else
                    {
                        LblTasaActual.Text = $"No hay tasa de cambio registradas.";
                    }

                    TxtTasaCambio.Text = string.Empty ;
                }
                else
                {
                    ultimaTasa = new TipoCambio();
                    ultimaTasa.Tasa = double.Parse(TxtTasaCambio.Text.Trim());
                    ultimaTasa.FechaCambio = DateTime.Now;

                    db.Add(ultimaTasa);
                    db.SaveChanges();

                    if (ultimaTasa != null)
                    {
                        LblTasaActual.Text = $"La tasa de cambio actual es: {ultimaTasa.Tasa.ToString()} (NIO)";
                    }
                    else
                    {
                        LblTasaActual.Text = $"No hay tasa de cambio registradas.";
                    }

                    TxtTasaCambio.Text = string.Empty;
                }
            }
        }
    }
}
