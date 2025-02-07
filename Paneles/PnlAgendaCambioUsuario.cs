using NeoCobranza.Paneles_Venta;
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
    public partial class PnlAgendaCambioUsuario : Form
    {
        PnlAgenda auxFrmAgenda;
        DataUtilities dataUtilities = new DataUtilities();
        public string UsuarioId = "0";
        public PnlAgendaCambioUsuario(PnlAgenda frm)
        {
            InitializeComponent();
            auxFrmAgenda = frm;

            DTInicio.Format = DateTimePickerFormat.Custom;
            DTInicio.CustomFormat = "HH:mm"; // Solo horas y minutos
            DTInicio.ShowUpDown = true;

            DTFin.Format = DateTimePickerFormat.Custom;
            DTFin.CustomFormat = "HH:mm"; // Solo horas y minutos
            DTFin.ShowUpDown = true;
        }

        private void PnlAgendaCambioUsuario_Load(object sender, EventArgs e)
        {
            dataUtilities.SetParameter("@IdSucursal", Utilidades.SucursalId);
            CmbUsuarios.DataSource = dataUtilities.ExecuteStoredProcedure("sp_ObtenerUsuariosPorSucursal");
            CmbUsuarios.DisplayMember = "UsuarioNombreCompleto";
            CmbUsuarios.ValueMember = "Usuario";
            CmbUsuarios.SelectedIndex = 0;

            CmbUsuarios.SelectedValue = auxFrmAgenda.CmbUsuarios.SelectedValue;
            TxtMotivo.Text = auxFrmAgenda.DgvItemsCitas.SelectedRows[0].Cells[5].Value.ToString();

            DateTime horaInicio;
            DateTime horaFin;

            // Intentamos parsear la hora de inicio
            if (DateTime.TryParse(auxFrmAgenda.DgvItemsCitas.SelectedRows[0].Cells[2].Value.ToString(), out horaInicio))
            {
                // Creamos un DateTime con una fecha base (por ejemplo, 1/1/2000) y la hora extraída
                DTInicio.Value = new DateTime(2000, 1, 1, horaInicio.Hour, horaInicio.Minute, 0);
            }
            else
            {
                MessageBox.Show("Error al convertir la hora de inicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Intentamos parsear la hora de fin
            if (DateTime.TryParse(auxFrmAgenda.DgvItemsCitas.SelectedRows[0].Cells[3].Value.ToString(), out horaFin))
            {
                DTFin.Value = new DateTime(2000, 1, 1, horaFin.Hour, horaFin.Minute, 0);
            }
            else
            {
                MessageBox.Show("Error al convertir la hora de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            TxtNombreCliente.Text = auxFrmAgenda.DgvItemsCitas.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void BtnCambiarCliente_Click(object sender, EventArgs e)
        {
            Panel_Cliente_Contrato panelCliente = new Panel_Cliente_Contrato("AgendaConfiguracion");
            AddOwnedForm(panelCliente);
            panelCliente.ShowDialog();
        }

        private void BtnAgendar_Click(object sender, EventArgs e)
        {
            string horaInicio = DTInicio.Value.ToString("HH:mm:ss");
            string horaFin = DTFin.Value.ToString("HH:mm:ss");

            dataUtilities.SetParameter("@IdCita", auxFrmAgenda.DgvItemsCitas.SelectedRows[0].Cells[0].Value.ToString());
            dataUtilities.SetParameter("@HoraInicio",horaInicio);
            dataUtilities.SetParameter("@HoraFin",horaFin);
            dataUtilities.SetParameter("@IdUsuario",CmbUsuarios.SelectedValue.ToString());
            dataUtilities.SetParameter("@IdCliente",this.UsuarioId);
            dataUtilities.SetParameter("@StrMotivoCumplida",TxtMotivo.Text);

            DataTable data = dataUtilities.ExecuteStoredProcedure("sp_ActualizarCita");

            if(data.Rows.Count > 0)
            {
                if (data.Rows[0][1].ToString() == "0")
                {
                    auxFrmAgenda.ObtenerCitas();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(data.Rows[0][0].ToString(), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
