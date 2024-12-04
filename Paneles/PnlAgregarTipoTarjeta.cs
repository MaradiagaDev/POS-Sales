using NeoCobranza.Clases;
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
    public partial class PnlAgregarTipoTarjeta : Form
    {
        public DataTable auxTablaDinamica = new DataTable();
        string auxKey = "";
        string auxOpc = "";
        DataUtilities dataUtilities = new DataUtilities();

        public PnlAgregarTipoTarjeta(string opc, string key)
        {
            InitializeComponent();
            this.auxKey = key;
            auxOpc = opc;
        }

        private void PnlAgregarTipoTarjeta_Load(object sender, EventArgs e)
        {
            //if (auxTablaDinamica.Columns.Count == 0)
            //{
            //    auxTablaDinamica.Columns.Add("Id", typeof(string));
            //    auxTablaDinamica.Columns.Add("Banco", typeof(string));

            //    dgvSucursalesProductos.DataSource = auxTablaDinamica;
            //}

            DataTable dtResponse = dataUtilities.GetAllRecords("Bancos");

            CmbBancoTipo.ValueMember = "BancoId";
            CmbBancoTipo.DisplayMember = "Banco";
            CmbBancoTipo.DataSource = dtResponse;

            if (auxOpc == "Crear")
            {
                btnAgregar.Text = "Guardar";
                LblNombreDinamico.Text = "Crear Tipo Tarjeta";
            }
            else
            {
                btnAgregar.Text = "Modificar";
                LblNombreDinamico.Text = "Modificar Tipo Tarjeta";

                DataTable dtResponseTipoTarjeta = dataUtilities.getRecordByPrimaryKey("TipoTarjeta", auxKey);

                TxtNombre.Text = Convert.ToString(dtResponseTipoTarjeta.Rows[0]["NombreTipo"]);
                TxtPorcentajeAplicado.Text = Convert.ToString(dtResponseTipoTarjeta.Rows[0]["Porcentaje"]);
                CmbBancoTipo.SelectedValue = Convert.ToString(dtResponseTipoTarjeta.Rows[0]["BancoId"]);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAgregarBanco_Click(object sender, EventArgs e)
        {
            if (CmbBancos.Items.Count > 0)
            {
                foreach (DataRow row in auxTablaDinamica.Rows)
                {
                    if (row[0].ToString() == CmbBancos.SelectedValue.ToString())
                    {
                        MessageBox.Show("El Banco seleccionado ya ha sido agregado.", "Atención",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                auxTablaDinamica.Rows.Add(CmbBancos.SelectedValue.ToString(), CmbBancos.Text);
            }
            else
            {
                MessageBox.Show("Debe agregar un Banco en la sección de Catalogo para realizar esta acción.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnQuitarBanco_Click(object sender, EventArgs e)
        {
            if (dgvSucursalesProductos.SelectedRows.Count > 0)
            {
                auxTablaDinamica.Rows.RemoveAt(dgvSucursalesProductos.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Banco en la lista para quitarlo.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FuncionesPrincipales();
        }

        public void FuncionesPrincipales()
        {
            if (TxtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Debe digitar el Nombre de Tipo Tarjeta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CmbBancoTipo.Items.Count == 0)
            {
                MessageBox.Show("Debe agregar un banco en el catalogo para agregar un tipo de tarjeta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (auxOpc == "Crear")
            {
                double valorPorcenta = 0;
                if (double.TryParse(TxtPorcentajeAplicado.Text, out double porcentaje))
                {
                    valorPorcenta = porcentaje;
                }
                dataUtilities.SetColumns("NombreTipo", TxtNombre.Text);
                dataUtilities.SetColumns("Estado", "Activo");
                dataUtilities.SetColumns("BancoId", CmbBancoTipo.SelectedValue);
                dataUtilities.SetColumns("Porcentaje", porcentaje);

                dataUtilities.InsertRecord("TipoTarjeta");

            }
            else
            {
                double valorPorcenta = 0;
                if (double.TryParse(TxtPorcentajeAplicado.Text, out double porcentaje))
                {
                    valorPorcenta = porcentaje;
                }
                dataUtilities.SetColumns("NombreTipo", TxtNombre.Text);
                dataUtilities.SetColumns("BancoId", CmbBancoTipo.SelectedValue);
                dataUtilities.SetColumns("Porcentaje", valorPorcenta);

                dataUtilities.UpdateRecordByPrimaryKey("TipoTarjeta", auxKey);
            }

            this.Close();

        }

        private void TxtPorcentajeAplicado_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox == null) return;

            string input = textBox.Text;

            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^\d*\.?\d*$");

            if (!regex.IsMatch(input))
            {
                int cursorPosition = textBox.SelectionStart;
                textBox.Text = input.Remove(cursorPosition - 1, 1);
                textBox.SelectionStart = cursorPosition - 1;
            }
        }

    }
}
