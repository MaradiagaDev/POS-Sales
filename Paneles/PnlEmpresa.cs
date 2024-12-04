using NeoCobranza.ModelsCobranza;
using NeoCobranza.ViewModels;
using OfficeOpenXml.Drawing.Chart;
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
    public partial class PnlEmpresa : Form
    {
        int auxEmpresa = 0;
        DataUtilities dataUtilities = new DataUtilities();
        public PnlEmpresa()
        {
            InitializeComponent();
        }

        private void PnlEmpresa_Load(object sender, EventArgs e)
        {
            UIUtilities.EstablecerFondo(this);
            UIUtilities.ConfigurarBotonActualizar(BtnActualizar);
            UIUtilities.ConfigurarTituloPantalla(TbTitulo, PnlTitulo);

            DataTable dtResponse = dataUtilities.GetAllRecords("Empresa");

            if (dtResponse.Rows.Count > 0)
            {
                TxtNombreComercial.Text = Convert.ToString(dtResponse.Rows[0]["NombreComercial"]);
                TxtNombreEmpresa.Text = Convert.ToString(dtResponse.Rows[0]["NombreEmpresa"]);
                TxtTelefono.Text = Convert.ToString(dtResponse.Rows[0]["Telefono"]);
                TxtNoRuc.Text = Convert.ToString(dtResponse.Rows[0]["Ruc"]);
                TxtEmail.Text = Convert.ToString(dtResponse.Rows[0]["Email"]);

                auxEmpresa = Convert.ToInt32(dtResponse.Rows[0]["IdEmpresa"]);
            }

        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            //Validaciones
            if (TxtNombreEmpresa.Text.Trim().Length == 0)
            {
                MessageBox.Show("El nombre de la empresa no puede estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TxtNombreComercial.Text.Trim().Length == 0)
            {
                MessageBox.Show("El nombre comercial de la empresa no puede estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TxtTelefono.Text.Trim().Length == 0)
            {
                MessageBox.Show("El telefono no puede estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TxtNoRuc.Text.Trim().Length == 0)
            {
                MessageBox.Show("El No RUC no puede estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TxtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("El Email no puede estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                if (auxEmpresa == 0)
                {
                    dataUtilities.SetColumns("NombreComercial", TxtNombreComercial.Text);
                    dataUtilities.SetColumns("NombreEmpresa", TxtNombreEmpresa.Text);
                    dataUtilities.SetColumns("Telefono", TxtTelefono.Text);
                    dataUtilities.SetColumns("Ruc", TxtNoRuc.Text);
                    dataUtilities.SetColumns("Email", TxtEmail.Text);
                    dataUtilities.InsertRecord("Empresa");

                    MessageBox.Show("La empresa ha sido creada correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataUtilities.SetColumns("NombreComercial", TxtNombreComercial.Text);
                    dataUtilities.SetColumns("NombreEmpresa", TxtNombreEmpresa.Text);
                    dataUtilities.SetColumns("Telefono", TxtTelefono.Text);
                    dataUtilities.SetColumns("Ruc", TxtNoRuc.Text);
                    dataUtilities.SetColumns("Email", TxtEmail.Text);
                    dataUtilities.UpdateRecordByPrimaryKey("Empresa",auxEmpresa);

                    MessageBox.Show("La empresa ha sido actualizada correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }
        }
    }
}
