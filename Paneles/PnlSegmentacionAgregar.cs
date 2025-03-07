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
    public partial class PnlSegmentacionAgregar : Form
    {
        string auxId;
        string auxOpc;
        DataUtilities dataUtilities = new DataUtilities();
        public PnlSegmentacionAgregar(string id)
        {
            InitializeComponent();
            auxId = id;

           DataTable dtResponse = dataUtilities.getRecordByColumn("SegmentacionCliente", "Clave", auxId);

            if (dtResponse.Rows.Count > 0 )
            {
                auxOpc = "Modificar";

                TxtDescripcion.Text = Convert.ToString(dtResponse.Rows[0][1]);
            }
            else
            {
                auxOpc = "Crear";
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(TxtDescripcion.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Debe digitar la descripción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(auxOpc == "Crear")
            {
                dataUtilities.SetColumns("Descripcion", TxtDescripcion.Text);
                dataUtilities.SetColumns("Estado", "Activo");
                dataUtilities.SetColumns("SucursalId", Utilidades.SucursalId);
                dataUtilities.InsertRecord("SegmentacionCliente");
            }
            else
            {
                dataUtilities.SetColumns("Descripcion", TxtDescripcion.Text);
                dataUtilities.SetColumns("Estado", "Activo");
                dataUtilities.SetColumns("SucursalId", Utilidades.SucursalId);
                dataUtilities.UpdateRecordByPrimaryKey("SegmentacionCliente",auxId);
            }

            this.Close();
        }
    }
}
