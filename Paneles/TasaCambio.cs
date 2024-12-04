using NeoCobranza.ModelsCobranza;
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
    public partial class TasaCambio : Form
    {
        DataUtilities dataUtilities = new DataUtilities();
        private bool boolExiste = false;
        public TasaCambio()
        {
            InitializeComponent();

            DataTable dtResponse = dataUtilities.GetAllRecords("TasaCambio");

            if (dtResponse.Rows.Count > 0)
            {
                boolExiste = true;
                LblTasaActual.Text = $"La tasa de cambio actual es: {Convert.ToString(dtResponse.Rows[0]["Tasa"])} (NIO)";
            }
            else
            {
                LblTasaActual.Text = $"No hay tasa de cambio registradas.";
            }

        }

        private void TxtTasaCambio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter presionado es un número o un punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                // Si no es un número ni un punto decimal, cancelar el evento de pulsación de tecla
                e.Handled = true;
            }

            // Verificar si el carácter presionado es un punto
            if (e.KeyChar == '.')
            {
                // Si hay un punto ya presente o es el primer carácter, cancelar el evento de pulsación de tecla
                if ((sender as TextBox).Text.Contains('.') || (sender as TextBox).Text.Length == 0)
                {
                    e.Handled = true;
                }
            }

            // Limitar a cuatro decimales
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text.Contains('.'))
            {
                int index = textBox.Text.IndexOf('.');
                if (textBox.Text.Substring(index).Length > 4 && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {

            if (TxtTasaCambio.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe digitar una tasa.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double prueba = 0;

            if (double.TryParse(TxtTasaCambio.Text.Trim(), out prueba) == false)
            {
                MessageBox.Show("Debe digitar una tasa valida.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!boolExiste)
            {
                dataUtilities.SetColumns("Tasa", TxtTasaCambio.Text.Trim());
                dataUtilities.SetColumns("FechaCambio", DateTime.Now);
                dataUtilities.InsertRecord("TasaCambio");

                LblTasaActual.Text = $"La tasa de cambio actual es: {TxtTasaCambio.Text.Trim()} (NIO)";

                MessageBox.Show("Se ha agregado la tasa al sistema.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                dataUtilities.SetColumns("Tasa", TxtTasaCambio.Text.Trim());
                dataUtilities.SetColumns("FechaCambio", DateTime.Now);
                dataUtilities.UpdateRecordByPrimaryKey("TasaCambio",1);

                LblTasaActual.Text = $"La tasa de cambio actual es: {TxtTasaCambio.Text.Trim()} (NIO)";

                MessageBox.Show("Se ha actualizado la tasa en el sistema.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

             
        }

        private void TasaCambio_Load(object sender, EventArgs e)
        {
            UIUtilities.EstablecerFondo(this);
            UIUtilities.ConfigurarBotonCrear(BtnGuardar);
            UIUtilities.ConfigurarTituloPantalla(TbTitulo, PnlTitulo);
        }
    }
}
