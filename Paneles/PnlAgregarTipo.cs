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
    public partial class PnlAgregarTipo : Form
    {
        PnlCatologoTiposServicios frmPrincipal;
        string auxOpc;
        string auxId;
        DataUtilities dataUtilities = new DataUtilities();

        public PnlAgregarTipo(PnlCatologoTiposServicios frm, string opc, string id)
        {
            InitializeComponent();
            this.frmPrincipal = frm;
            this.auxId = id;
            this.auxOpc = opc;
        }

        private void PnlAgregarTipo_Load(object sender, EventArgs e)
        {
            if (this.auxOpc != "Crear")
            {
                using (NeoCobranzaContext db = new NeoCobranzaContext())
                {
                    this.btnAgregar.Text = "Actualizar";

                    DataTable dtRespuesta = dataUtilities.getRecordByPrimaryKey("Categorizacion", auxId);

                    if (dtRespuesta.Rows.Count > 0)
                    {
                        this.TxtNombreTipo.Text = Convert.ToString(dtRespuesta.Rows[0]["Descripcion"]);
                    }
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (TxtNombreTipo.Text.Trim().Length == 0)
            {
                MessageBox.Show("El nombre del tipo no puede estar en blanco.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TxtNombreTipo.Text.Trim().Length > 50)
            {
                MessageBox.Show("El nombre del tipo no puede tener más de 50 caracteres.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.auxOpc == "Crear")
            {
                dataUtilities.SetColumns("Descripcion", TxtNombreTipo.Text.Trim());
                dataUtilities.SetColumns("Estado", "Activo");

                dataUtilities.InsertRecord("Categorizacion");
            }
            else
            {
                dataUtilities.SetColumns("Descripcion", TxtNombreTipo.Text.Trim());
                dataUtilities.UpdateRecordByPrimaryKey("Categorizacion", auxId);
            }

            frmPrincipal.vMCatalogoTiposServicio.InitModuloPnlCatalogoServicio(frmPrincipal, "Buscar");
            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
