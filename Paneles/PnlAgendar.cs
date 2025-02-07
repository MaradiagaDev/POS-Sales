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
    public partial class PnlAgendar : Form
    {
        PnlAgenda auxFrmAgenda;
        string auxIdCliente;
        DataUtilities dataUtilities = new DataUtilities();

        public PnlAgendar(PnlAgenda frmAgenda, string NombreCliente, string IdCliente)
        {
            InitializeComponent();
            auxFrmAgenda = frmAgenda;
            auxIdCliente = IdCliente;
            TxtNombreCliente.Text = NombreCliente;

            DTInicio.Format = DateTimePickerFormat.Custom;
            DTInicio.CustomFormat = "HH:mm"; // Solo horas y minutos
            DTInicio.ShowUpDown = true;

            DTFin.Format = DateTimePickerFormat.Custom;
            DTFin.CustomFormat = "HH:mm"; // Solo horas y minutos
            DTFin.ShowUpDown = true;
        }

        private void BtnAgendar_Click(object sender, EventArgs e)
        {
            try
            {
                string horaInicio = DTInicio.Value.ToString("HH:mm:ss");
                string horaFin = DTFin.Value.ToString("HH:mm:ss");

                dataUtilities.SetParameter("@HoraInicio", horaInicio);
                dataUtilities.SetParameter("@HoraFin", horaFin);
                dataUtilities.SetParameter("@IdUsuario", auxFrmAgenda.CmbUsuarios.SelectedValue);
                dataUtilities.SetParameter("@IdSucursal", Utilidades.SucursalId);
                dataUtilities.SetParameter("@DiaCita", auxFrmAgenda.CalendarCitas.SelectionStart);
                dataUtilities.SetParameter("@IdCliente", Convert.ToInt32(auxIdCliente));
                dataUtilities.SetParameter("@TxtMotivo", TxtMotivo.Text);

                DataTable data = dataUtilities.ExecuteStoredProcedure("spAgendarCita");

                if (data.Rows[0][1].ToString() == "1")
                {
                    MessageBox.Show($"{data.Rows[0][0].ToString()}", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    auxFrmAgenda.ObtenerCitas();
                    this.Close();
                }
            }
            catch (Exception ex) 
            { 
                
            } 
        }
    }
}
