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
    public partial class AgregarBancos : Form
    {
        string auxKey = "";
        string auxOpc = "";
        DataUtilities dataUtilities = new DataUtilities();

        public AgregarBancos(string opc, string key)
        {
            InitializeComponent();
            auxKey = key; auxOpc = opc;
        }

        private void AgregarBancos_Load(object sender, EventArgs e)
        {
            if (auxOpc == "Crear")
            {
                LblDynamico.Text = "Crear Banco";
                btnAgregar.Text = "Guardar";
            }
            else
            {
                DataTable dtResponse = dataUtilities.getRecordByPrimaryKey("Bancos", auxKey);

                TxtBanco.Text = Convert.ToString(dtResponse.Rows[0][0]);

                LblDynamico.Text = $"Modificar Banco con ID: {auxKey}";
                btnAgregar.Text = "Modificar";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (TxtBanco.Text.Trim() == "")
            {
                MessageBox.Show("Debe digitar el Banco.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (auxOpc == "Crear")
            {
                dataUtilities.SetColumns("Banco", TxtBanco.Text.Trim());
                dataUtilities.SetColumns("Estado", "Activo");

                dataUtilities.InsertRecord("Bancos");
            }
            else
            {
                dataUtilities.SetColumns("Banco", TxtBanco.Text.Trim());
                dataUtilities.UpdateRecordByPrimaryKey("Bancos", auxKey);
            }

            this.Close();

        }
    }
}
