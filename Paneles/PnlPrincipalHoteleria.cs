using NeoCobranza.Paneles_Venta;
using NeoCobranza.PanelesHoteles;
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
    public partial class PnlPrincipalHoteleria : Form
    {
        public PnlPrincipalHoteleria()
        {
            InitializeComponent();
            // Al iniciar, se selecciona el botón Home
            SetButtonSelected(BtnHome);

            PnlInicioHoteles directas = new PnlInicioHoteles();
            directas.TopLevel = false;
            directas.Dock = DockStyle.Fill;
            directas.TopLevel = false;
            PnlPrincipal.Controls.Add(directas);
            directas.Show();
        }

        private void SetButtonSelected(Button selectedButton)
        {
            // Se restablece el color normal a todos los botones
            BtnHome.BackColor = SystemColors.MenuHighlight;
            BtnReservacion.BackColor = SystemColors.MenuHighlight;
            BtnSalida.BackColor = SystemColors.MenuHighlight;
            BtnRecepcion.BackColor = SystemColors.MenuHighlight;

            // Se establece el color seleccionado en el botón que se pasó como parámetro
            selectedButton.BackColor = SystemColors.GrayText;
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            SetButtonSelected(BtnHome);

            if (PnlPrincipal.Controls.Count > 0)
            {
                PnlPrincipal.Controls.RemoveAt(0);
            }

            PnlInicioHoteles directas = new PnlInicioHoteles();
            directas.TopLevel = false;
            directas.Dock = DockStyle.Fill;
            directas.TopLevel = false;
            PnlPrincipal.Controls.Add(directas);
            directas.Show();
        }

        private void BtnReservacion_Click(object sender, EventArgs e)
        {
            SetButtonSelected(BtnReservacion);

            if (PnlPrincipal.Controls.Count > 0)
            {
                PnlPrincipal.Controls.RemoveAt(0);
            }

            PnlReservaHabitacion directas = new PnlReservaHabitacion();
            directas.TopLevel = false;
            directas.Dock = DockStyle.Fill;
            directas.TopLevel = false;
            PnlPrincipal.Controls.Add(directas);
            directas.Show();
        }

        private void BtnSalida_Click(object sender, EventArgs e)
        {
            SetButtonSelected(BtnSalida);

            if (PnlPrincipal.Controls.Count > 0)
            {
                PnlPrincipal.Controls.RemoveAt(0);
            }

            PnlInicioHoteles directas = new PnlInicioHoteles();
            directas.TopLevel = false;
            directas.Dock = DockStyle.Fill;
            directas.TopLevel = false;
            PnlPrincipal.Controls.Add(directas);
            directas.Show();
        }

        private void BtnRecepcion_Click(object sender, EventArgs e)
        {

            if (PnlPrincipal.Controls.Count > 0)
            {
                PnlPrincipal.Controls.RemoveAt(0);
            }            SetButtonSelected(BtnRecepcion);


            PnlInicioHoteles directas = new PnlInicioHoteles();
            directas.TopLevel = false;
            directas.Dock = DockStyle.Fill;
            directas.TopLevel = false;
            PnlPrincipal.Controls.Add(directas);
            directas.Show();
        }
    }
}
