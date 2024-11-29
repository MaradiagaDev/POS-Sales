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
    public partial class AgregarMotivoCancelacion : Form
    {
        string auxKey = "";
        string auxOpc = "";
        DataUtilities dataUtilities = new DataUtilities();
        public AgregarMotivoCancelacion(string opc, string key)
        {
            InitializeComponent();
            auxKey = key;
            auxOpc = opc;
        }

        private void AgregarMotivoCancelacion_Load(object sender, EventArgs e)
        {
            if (auxOpc == "Crear")
            {
                LblDynamico.Text = "Crear Motivo Cancelación";
                btnAgregar.Text = "Guardar";
            }
            else
            {
                DataTable dtResponse = dataUtilities.getRecordByPrimaryKey("MotivosCancelacion", auxKey);
                TxtMotivoCancelacion.Text = Convert.ToString(dtResponse.Rows[0]["Motivo"]);

                LblDynamico.Text = $"Modificar Motivo Cancelación con ID: {auxKey}";
                btnAgregar.Text = "Modificar";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (TxtMotivoCancelacion.Text.Trim() == "")
            {
                MessageBox.Show("Debe digitar el motivo de cancelación.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (auxOpc == "Crear")
            {
                dataUtilities.SetColumns("Motivo", TxtMotivoCancelacion.Text.Trim());
                dataUtilities.SetColumns("Estado", "Activo");

                dataUtilities.InsertRecord("MotivosCancelacion");

            }
            else
            {
                dataUtilities.SetColumns("Motivo", TxtMotivoCancelacion.Text.Trim());
                dataUtilities.UpdateRecordByPrimaryKey("MotivosCancelacion", auxKey);
            }

            this.Close();
        }
    }
}
