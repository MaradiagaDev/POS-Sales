using iText.StyledXmlParser.Jsoup.Helper;
using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace NeoCobranza.Paneles
{
    public partial class PnlRespaldos : Form
    {
        DataUtilities dataUtilities = new DataUtilities();

        public PnlRespaldos()
        {
            InitializeComponent();
        }

        private void BtnExaminar_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Seleccione la carpeta donde se guardará el respaldo";
                fbd.RootFolder = Environment.SpecialFolder.MyComputer; // Permite ver todas las particiones
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    TxtRutaRespaldo.Text = fbd.SelectedPath;
                }
            }
        }



        private void BtnGenerarRespaldo_Click(object sender, EventArgs e)
        {
            if(TxtRutaRespaldo.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Debe seleccionar la ruta para generar el respaldo.","Atención",MessageBoxButtons.OK,MessageBoxIcon.Warning); 
                return;
            }

            dataUtilities.GenerarBackup(TxtRutaRespaldo.Text.Trim());

            this.Close();
        }

        private void PnlRespaldos_Load(object sender, EventArgs e)
        {
            DataTable dtResponse = dataUtilities.getRecordByColumn("ConfigFacturacion", "SucursalId", Utilidades.SucursalId);

            if (dtResponse.Rows.Count != 0)
            {
                TxtRutaRespaldo.Text = dtResponse.Rows[0]["DireccionRespaldo"] is DBNull
                ? ""
                : Convert.ToString(dtResponse.Rows[0]["DireccionRespaldo"]);

                ChkRespaldoAuto.Checked = dtResponse.Rows[0]["BitRespaldoCaja"] is DBNull
              ? false
              : Convert.ToBoolean(dtResponse.Rows[0]["BitRespaldoCaja"]);
            }
        }

        private void BtnGuardarConfiguracion_Click(object sender, EventArgs e)
        {
            DataTable dtResponse = dataUtilities.getRecordByColumn("ConfigFacturacion", "SucursalId", Utilidades.SucursalId);

            if (dtResponse.Rows.Count > 0)
            {
                dataUtilities.SetColumns("DireccionRespaldo", TxtRutaRespaldo.Text);
                dataUtilities.SetColumns("BitRespaldoCaja", ChkRespaldoAuto.Checked);

                dataUtilities.UpdateRecordByPrimaryKey("ConfigFacturacion", Convert.ToString(dtResponse.Rows[0][0]));

                this.Close();
            }
            else
            {
               MessageBox.Show("Debe agregar la configuración de facturación de la sucursal" +
                   " para poder configurar los respaldos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
