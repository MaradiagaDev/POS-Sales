using NeoCobranza.Data;
using NeoCobranza.DataController;
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
    public partial class PnlTasaCambio : Form
    {
        Conexion conexion;
        CTasaCambio cTasaCambio;
        
        public PnlTasaCambio(Conexion conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
            cTasaCambio = new CTasaCambio(conexion);

            lblTasa.Text = cTasaCambio.MostrarTasa()+ " C$";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (txtTasa.Texts == "")
            {
                MessageBox.Show("La tasa no puede ir vacia", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            double pase;
            if (double.TryParse(txtTasa.Texts, out pase) == false )
            {
                txtTasa.Texts = "";
                MessageBox.Show("El campo de Tasa solo acepta numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            cTasaCambio.AgregarTasa(double.Parse(txtTasa.Texts));
            this.Close();
        }
    }
}
