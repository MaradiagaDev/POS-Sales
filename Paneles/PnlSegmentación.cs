using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
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
    public partial class PnlSegmentación : Form
    {
        DataUtilities dataUtilities = new DataUtilities();
        public PnlSegmentación()
        {
            InitializeComponent();
        }

        private void PnlSegmentación_Load(object sender, EventArgs e)
        {
            UIUtilities.PersonalizarDataGridView(dgvCatalogoClientes);
            UIUtilities.EstablecerFondo(this);
            UIUtilities.ConfigurarBotonCrear(btnAgregar);
            UIUtilities.ConfigurarBotonActualizar(btnActualizar);
            UIUtilities.ConfigurarTituloPantalla(TbTitulo, PnlTitulo);
            InicializarGrid();
            Buscar();
        }

        // Declarar el DataTable como variable de clase para mantener la referencia.
        private DataTable dtCatalogoClientes;

        private void InicializarGrid()
        {
            // Crear y configurar el DataTable (puedes agregar las columnas manualmente si lo deseas)
            dtCatalogoClientes = new DataTable();
            dtCatalogoClientes.Columns.Add("Clave", typeof(string));
            dtCatalogoClientes.Columns.Add("Descripción", typeof(string));
            dtCatalogoClientes.Columns.Add("Sucursal", typeof(string));
            dtCatalogoClientes.Columns.Add("Estado", typeof(string));
            // ... agrega las demás columnas según corresponda

            // Asignar el DataSource del DataGridView solo una vez.
            dgvCatalogoClientes.DataSource = dtCatalogoClientes;

            // Agregar la columna de botón personalizada
            DataGridViewButtonColumn btnCambioEstado = new DataGridViewButtonColumn
            {
                Text = "Bloquear",
                Name = "BtnCambioEstado",
                UseColumnTextForButtonValue = true,
                DefaultCellStyle = { ForeColor = System.Drawing.Color.Blue }
            };
            dgvCatalogoClientes.Columns.Add(btnCambioEstado);
        }

        private void Buscar()
        {
            // Obtener los datos del procedimiento almacenado.
            dataUtilities.SetParameter("@sucursalId", Utilidades.SucursalId);
            DataTable dtResponse = dataUtilities.ExecuteStoredProcedure("spViewSegmentacion");

            // Limpiar el DataTable intermedio (manteniendo la estructura de columnas)
            dtCatalogoClientes.Clear();

            // Importar las filas del DataTable obtenido.
            foreach (DataRow row in dtResponse.Rows)
            {
                dtCatalogoClientes.Rows.Add(row[0], row[1], row[2], row[3]);
            }

            // El DataGridView se actualizará automáticamente al cambiar el contenido del DataTable.
        }


        private void dgvCatalogoClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 48))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (e.ColumnIndex == 0 && dgvCatalogoClientes.SelectedRows.Count > 0)
            {
                object cellValue = dgvCatalogoClientes.Rows[e.RowIndex].Cells[1].Value;

                if(dgvCatalogoClientes.Rows[e.RowIndex].Cells[4].Value.ToString() == "Activo")
                {
                    dataUtilities.SetColumns("Estado", "Bloqueado");
                    dataUtilities.UpdateRecordByPrimaryKey("SegmentacionCliente", cellValue.ToString());
                }
                else
                {
                    dataUtilities.SetColumns("Estado", "Activo");
                    dataUtilities.UpdateRecordByPrimaryKey("SegmentacionCliente", cellValue.ToString());
                }

                Buscar();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 47))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvCatalogoClientes.SelectedRows.Count > 0)
            {
                PnlSegmentacionAgregar frm = new PnlSegmentacionAgregar(Convert.ToString(dgvCatalogoClientes.SelectedRows[0].Cells[1].Value));
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay ítems seleccionados", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Buscar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 46))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PnlSegmentacionAgregar frm = new PnlSegmentacionAgregar("");
            frm.ShowDialog();
            Buscar();
        }
    }
}
