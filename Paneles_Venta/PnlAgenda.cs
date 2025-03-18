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

namespace NeoCobranza.Paneles_Venta
{
    public partial class PnlAgenda : Form
    {
        DataUtilities dataUtilities = new DataUtilities();
        PnlPrincipal pnlPrincipal;
        public PnlAgenda(PnlPrincipal frm)
        {
            InitializeComponent();
            pnlPrincipal = frm;
        }

        private void PnlAgenda_Load(object sender, EventArgs e)
        {
            UIUtilities.PersonalizarDataGridView(DgvItemsCitas);

            //Cargar los usuarios
            dataUtilities.SetParameter("@IdSucursal", Utilidades.SucursalId);
            CmbUsuarios.DataSource = dataUtilities.ExecuteStoredProcedure("sp_ObtenerUsuariosPorSucursal");
            CmbUsuarios.DisplayMember = "UsuarioNombreCompleto";
            CmbUsuarios.ValueMember = "Usuario";
            CmbUsuarios.SelectedIndex = 0;

            //Obtener las citas
            ObtenerCitas();
        }

        public void ObtenerCitas()
        {
            try
            {
                if (CmbUsuarios.SelectedIndex >= 0)
                {
                    dataUtilities.SetParameter("@DiaCita", CalendarCitas.SelectionStart);
                    dataUtilities.SetParameter("@IdUsuario", CmbUsuarios.SelectedValue.ToString());
                    dataUtilities.SetParameter("@IdSucursal", Utilidades.SucursalId);

                    DgvItemsCitas.DataSource = dataUtilities.ExecuteStoredProcedure("sp_ObtenerCitas");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ah ocurrido un error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAgregarServicio_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 15))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Panel_Cliente_Contrato panelCliente = new Panel_Cliente_Contrato("Agenda");
            AddOwnedForm(panelCliente);
            panelCliente.ShowDialog();
        }

        private void BtnCancelarOrden_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 18))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DgvItemsCitas.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show(
             "¿Está seguro de cancelar la cita?",
             "Confirmación",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Question
            );

                // Evaluar la respuesta del usuario
                if (result == DialogResult.Yes)
                {

                    dataUtilities.SetColumns("BitCancelada", true);

                    dataUtilities.UpdateRecordByPrimaryKey("AgendaCitas", DgvItemsCitas.Rows[0].Cells[0].Value);

                    ObtenerCitas();
                }
            }
        }

        private void BtnCitaCumplida_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 17))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DgvItemsCitas.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show(
          "¿Está seguro dar la cita por cumplida?",
          "Confirmación",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Question
         );

                // Evaluar la respuesta del usuario
                if (result == DialogResult.Yes)
                {

                    dataUtilities.SetColumns("BitCitaCumplida", true);

                    dataUtilities.UpdateRecordByPrimaryKey("AgendaCitas", DgvItemsCitas.SelectedRows[0].Cells[0].Value);

                    ObtenerCitas();

                }
            }
        }

        private void CmbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObtenerCitas();
        }

        private void CalendarCitas_DateChanged(object sender, DateRangeEventArgs e)
        {
            ObtenerCitas();
        }

        private void BtnCambioUsuario_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 16))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DgvItemsCitas.SelectedRows.Count > 0)
            {
                PnlAgendaCambioUsuario frm = new PnlAgendaCambioUsuario(this);
                frm.ShowDialog();
            }

        }

        private void BtnPagarOrden_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 19))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (DgvItemsCitas.SelectedRows.Count > 0)
                {
                    DataTable dataCita = dataUtilities.getRecordByPrimaryKey("AgendaCitas", DgvItemsCitas.SelectedRows[0].Cells[0].Value);

                    if (string.IsNullOrEmpty(dataCita.Rows[0]["IdOrden"].ToString()))
                    {
                        //OBTENER LA CONFIGURACION DE FACTURACION
                        DataTable dtConfigFacturacion = dataUtilities.getRecordByColumn("ConfigFacturacion", "SucursalId", Utilidades.SucursalId);

                        if (dtConfigFacturacion.Rows.Count == 0)
                        {
                            MessageBox.Show("Debe agregar una configuración de facturación para poder realizar ordenes.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        decimal NoOrden = Convert.ToDecimal(dtConfigFacturacion.Rows[0]["ConsecutivoOrden"]) + 1;

                        dataUtilities.SetColumns("IdOrden", NoOrden);
                        dataUtilities.UpdateRecordByPrimaryKey("AgendaCitas", DgvItemsCitas.SelectedRows[0].Cells[0].Value);

                        pnlPrincipal.AbrirVenta(0, idCliente: dataCita.Rows[0]["IdCliente"].ToString(),sucursal:Utilidades.SucursalId);
                    }
                    else
                    {
                        pnlPrincipal.AbrirVenta(decimal.Parse(dataCita.Rows[0]["IdOrden"].ToString()), sucursal: Utilidades.SucursalId);
                    }
                }
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("Ah ocurrido un error al intentar abrir la venta.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
