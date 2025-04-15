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
    public partial class PnlAsociacionCliente : Form
    {
        DataUtilities dataUtilities = new DataUtilities();
        public string auxIdCliente = "";

        public PnlAsociacionCliente(string auxIdCliente)
        {
            InitializeComponent();
            //Agregar Boton de Cambiar de estado
            this.auxIdCliente = auxIdCliente;
            DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

            BtnCambioEstado.Text = "Asociar";
            BtnCambioEstado.Name = "...";
            BtnCambioEstado.UseColumnTextForButtonValue = true;
            BtnCambioEstado.DefaultCellStyle.ForeColor = Color.Blue;
            dgvVendedores.Columns.Add(BtnCambioEstado);

            DataGridViewButtonColumn BtnAsociar = new DataGridViewButtonColumn();
            BtnAsociar.Text = "Quitar";
            BtnAsociar.Name = "...";
            BtnAsociar.UseColumnTextForButtonValue = true;
            BtnAsociar.DefaultCellStyle.ForeColor = Color.Blue;
            DgvAsociados.Columns.Add(BtnAsociar);
            filtrarVendedores();
            filtrarAsociados();
        }

        private void filtrarVendedores()
        {
            dataUtilities.SetParameter("@NombreEmpleado", TxtFiltro.Text);
            dgvVendedores.DataSource = dataUtilities.ExecuteStoredProcedure("sp_FiltrarUsuariosAsociacion");
        }

        private void filtrarAsociados()
        {
            dataUtilities.SetParameter("@IdCliente", auxIdCliente);
            DgvAsociados.DataSource = dataUtilities.ExecuteStoredProcedure("spUsuariosAsociados");
        }

        private void PnlAsociacionCliente_Load(object sender, EventArgs e)
        {
            UIUtilities.PersonalizarDataGridViewPequeños(dgvVendedores);
            UIUtilities.PersonalizarDataGridViewPequeños(DgvAsociados);
            dgvVendedores.Columns[1].Visible = false;
            DgvAsociados.Columns[1].Visible = false;
        }

        private void TxtFiltro_TextChanged(object sender, EventArgs e)
        {
            filtrarVendedores();
        }

        private void dgvVendedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    object cellValue = dgvVendedores.Rows[e.RowIndex].Cells[1].Value;

                    //Verificar
                    dataUtilities.SetParameter("@IdCliente", auxIdCliente);
                    dataUtilities.SetParameter("@IdUsuario", cellValue.ToString());

                    DataRow row = dataUtilities.ExecuteStoredProcedure("spVerificarUsuariosAsociados").Rows[0];

                    if (Convert.ToString(row[0]) != "0")
                    {
                        MessageBox.Show("El vendedor ya fue asociado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    //Agregar
                    dataUtilities.SetColumns("UsuarioId", cellValue.ToString());
                    dataUtilities.SetColumns("ClienteId", auxIdCliente);
                    dataUtilities.InsertRecord("RelUsuarioCliente");

                    filtrarAsociados();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Ha ocurrido un error: {ex.Message}", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DgvAsociados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    object cellValue = DgvAsociados.Rows[e.RowIndex].Cells[1].Value;

                    dataUtilities.SetParameter("@usuarioId", cellValue.ToString());
                    dataUtilities.SetParameter("@clienteId", auxIdCliente);
                    dataUtilities.ExecuteStoredProcedure("spDeleteAsociaciones");

                    filtrarAsociados();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ha ocurrido un error: {ex.Message}", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
