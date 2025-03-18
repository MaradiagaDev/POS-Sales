using NeoCobranza.Paneles;
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

namespace NeoCobranza.PanelesHoteles
{
    public partial class PnlCatalogoHabitaciones : Form
    {
        DataTable dtCatalogo = new DataTable();
        DataUtilities dataUtilities = new DataUtilities();

        public PnlCatalogoHabitaciones()
        {
            InitializeComponent();

            UIUtilities.PersonalizarDataGridView(dgvCatalogoClientes);
            UIUtilities.EstablecerFondo(this);
            UIUtilities.ConfigurarTextBoxBuscar(TxtFiltrar);
            UIUtilities.ConfigurarBotonCrear(btnAgregar);
            UIUtilities.ConfigurarBotonActualizar(btnActualizar);
            UIUtilities.ConfigurarTituloPantalla(TbTitulo, PnlTitulo);
            InicializarGrid();
            RefrescarHabitaciones();
        }

        private void InicializarGrid()
        {
            // Crear y configurar el DataTable (puedes agregar las columnas manualmente si lo deseas)
            dtCatalogo = new DataTable();
            dtCatalogo.Columns.Add("Clave", typeof(string));
            dtCatalogo.Columns.Add("Identificador", typeof(string));
            dtCatalogo.Columns.Add("Estado", typeof(string));
            dtCatalogo.Columns.Add("Descripción", typeof(string));
            dtCatalogo.Columns.Add("Costo x Habitación", typeof(string));
            dtCatalogo.Columns.Add("Cantidad de Habitaciones", typeof(string));
            dtCatalogo.Columns.Add("Cobro por Porcentaje", typeof(string));
            dtCatalogo.Columns.Add("Monto / Porcentaje", typeof(string));
            // ... agrega las demás columnas según corresponda

            // Asignar el DataSource del DataGridView solo una vez.
            dgvCatalogoClientes.DataSource = dtCatalogo;

            // Agregar la columna de botón personalizada
            DataGridViewButtonColumn btnCambioEstado = new DataGridViewButtonColumn
            {
                Text = "Bloquear",
                Name = "...",
                UseColumnTextForButtonValue = true,
                DefaultCellStyle = { ForeColor = System.Drawing.Color.Blue }
            };
            dgvCatalogoClientes.Columns.Add(btnCambioEstado);
        }

        private void RefrescarHabitaciones()
        {

            dtCatalogo.Rows.Clear();
            dataUtilities.SetParameter("@SucursalId", Utilidades.SucursalId);
            dataUtilities.SetParameter("@Filtrar", TxtFiltrar.Text);
            DataTable dtResponse = dataUtilities.ExecuteStoredProcedure("Sp_ObtenerHabitaciones");

            foreach(DataRow item in dtResponse.Rows)
            {
                dtCatalogo.Rows.Add(
                    Convert.ToString(item["Clave"]),
                    Convert.ToString(item["Identificador"]),
                     Convert.ToString(item["Estado"]),
                    Convert.ToString(item["Descripcion"]),
                    Convert.ToString(item["Costo"]),
                    Convert.ToString(item["NoHabitaciones"]),
                    Convert.ToString(item["Porcentaje"]),
                    Convert.ToString(item["decMonto"])
                    );
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            PnlDefinirHabitaciones frm = new PnlDefinirHabitaciones();
            frm.ShowDialog();
        }

        private void PnlCatalogoHabitaciones_Load(object sender, EventArgs e)
        {
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogoClientes.SelectedRows.Count > 0)
            {
                PnlDefinirHabitaciones frm = new PnlDefinirHabitaciones();
                frm.auxId = Convert.ToString(dgvCatalogoClientes.SelectedRows[0].Cells[1].Value);
                frm.ShowDialog();

                RefrescarHabitaciones();
            }
            else
            {
                MessageBox.Show("No hay ítems seleccionados", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TxtFiltrar_TextChanged(object sender, EventArgs e)
        {
            RefrescarHabitaciones();
        }

        private void dgvCatalogoClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && dgvCatalogoClientes.SelectedRows.Count > 0)
            {
                object cellValue = dgvCatalogoClientes.Rows[e.RowIndex].Cells[1].Value;

                if (dgvCatalogoClientes.Rows[e.RowIndex].Cells[3].Value.ToString() == "Activo")
                {
                    dataUtilities.SetColumns("Estado", "Bloqueado");
                    dataUtilities.UpdateRecordByPrimaryKey("Habitaciones", cellValue.ToString());
                }
                else
                {
                    dataUtilities.SetColumns("Estado", "Activo");
                    dataUtilities.UpdateRecordByPrimaryKey("Habitaciones", cellValue.ToString());
                }

                RefrescarHabitaciones();
            }
        }
    }
}
