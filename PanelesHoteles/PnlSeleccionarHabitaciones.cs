using C1.Schedule;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using NeoCobranza.Properties;
using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace NeoCobranza.PanelesHoteles
{
    public partial class PnlSeleccionarHabitaciones : Form
    {
        DataUtilities datautilities = new DataUtilities();
        DateTime auxFechaInicio, auxFechaFin;
        PnlAgregarReservacion auxFrm;

        public class Habitacion
        {
            public string Nombre { get; set; }
            public decimal Costo { get; set; }
            public int Cantidad { get; set; }
            public string Descripcion { get; set; } // Descripción del conjunto
        }

        // Lista de conjuntos de habitaciones para probar con muchos items

        public PnlSeleccionarHabitaciones(DateTime inicio, DateTime fin, PnlAgregarReservacion frm)
        {
            auxFechaInicio = inicio;
            auxFechaFin = fin;
            auxFrm = frm;
            InitializeComponent();
            CargarConjuntos();
        }

        private void CargarConjuntos()
        {
            // Limpiamos los controles anteriores
            FLConjunto.Controls.Clear();

            datautilities.SetParameter("@sucursalId", Utilidades.SucursalId);

            // Ejecutar el procedimiento almacenado
            DataTable dtResponse = datautilities.ExecuteStoredProcedure("splistadoHabitacionesPorSucursal");

            foreach (DataRow conjunto in dtResponse.Rows)
            {
                string nombreConjunto = Convert.ToString(conjunto["Nombre"]);
                string idConjunto = Convert.ToString(conjunto["HabitacionId"]);

                Button btnConjunto = new Button
                {
                    Text = $"{nombreConjunto}",
                    Width = 220,
                    Height = 90,
                    Margin = new Padding(5),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.LightBlue,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                // Al hacer clic, se cargan las habitaciones correspondientes a este conjunto
                btnConjunto.Click += (sender, e) => CargarHabitaciones(idConjunto);

                FLConjunto.Controls.Add(btnConjunto);
            }

            if(dtResponse.Rows.Count > 0)
            {
                CargarHabitaciones(Convert.ToString(dtResponse.Rows[0]["HabitacionId"]));
            }
        }

        private void CargarHabitaciones(string idConjunto)
        {
            FLHabitaciones.Controls.Clear(); // Limpiamos el panel de habitaciones

            // Obtener la información de disponibilidad de habitaciones para este conjunto
            datautilities.SetParameter("@FechaIngreso", auxFechaInicio);
            datautilities.SetParameter("@FechaSalida", auxFechaFin);
            datautilities.SetParameter("@HabitacionId", idConjunto);
            DataTable dtHabitaciones = datautilities.ExecuteStoredProcedure("spObtenerHabitacionesDisponibles");

            Image roomImage;
            try
            {
                roomImage = Resources.Rooms;
            }
            catch
            {
                roomImage = new Bitmap(64, 64);
                using (Graphics g = Graphics.FromImage(roomImage))
                {
                    g.Clear(Color.Gray);
                    g.DrawRectangle(Pens.Black, 0, 0, 63, 63);
                }
            }

            foreach (DataRow habitacion in dtHabitaciones.Rows)
            {
                int numeroHabitacion = Convert.ToInt32(habitacion["NoHabitacion"]);
                string disponible = Convert.ToString(habitacion["Estado"]);

                Button btnHabitacion = new Button
                {
                    Width = 100,
                    Height = 120,
                    Margin = new Padding(5),
                    FlatStyle = FlatStyle.Flat,
                    // Si la habitación está disponible, se pinta de verde; si no, de rojo.
                    BackColor = disponible == "Disponible" ? Color.LightGreen : Color.LightCoral,
                    Text = $"\nCuarto {numeroHabitacion}\n{(disponible == "Disponible" ? disponible : "Ocupado")}",
                    TextImageRelation = TextImageRelation.ImageAboveText,
                    ImageAlign = ContentAlignment.MiddleCenter,
                    TextAlign = ContentAlignment.BottomCenter,
                    Image = roomImage
                };

                // Verificar si ya fue seleccionada (recorriendo el DataTable)
                bool yaSeleccionada = false;
                foreach (DataRow row in auxFrm.dynamicDetalle.Rows)
                {
                    if (row[0] != null && row[3] != null &&
                        row[0].ToString() == idConjunto && row[3].ToString() == numeroHabitacion.ToString())
                    {
                        yaSeleccionada = true;
                        break;
                    }
                }
                if (yaSeleccionada)
                {
                    // Coloreamos el botón de naranja si ya está seleccionado
                    btnHabitacion.BackColor = Color.Orange;
                }

                // Al hacer clic, se llama a seleccionarCuarto pasando el botón (sender)
                btnHabitacion.Click += (sender, e) => seleccionarCuarto((Button)sender, idConjunto, numeroHabitacion, disponible);

                FLHabitaciones.Controls.Add(btnHabitacion);
            }

            // Cargar Costos
            datautilities.SetParameter("@HabitacionId", idConjunto);
            DataTable dtResponse = datautilities.ExecuteStoredProcedure("spObtenerPaquetesPorHabitacion");
            CmbCostosConjunto.DataSource = dtResponse;
            CmbCostosConjunto.DisplayMember = "NombrePaquete";
            CmbCostosConjunto.ValueMember = "PaqueteId";
        }

        private void seleccionarCuarto(Button btn, string conjuntoId, int habitacion, string disponible)
        {
            // Si la habitación ya está pintada de naranja, significa que ya fue seleccionada
            if (btn.BackColor == Color.Orange)
            {
                MessageBox.Show("La habitación ya forma parte de la reservación.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (disponible != "Disponible")
            {
                MessageBox.Show("La habitación no está disponible en el periodo seleccionado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar nuevamente en el DataTable por si se cambió la selección en otro lado
            foreach (DataRow row in auxFrm.dynamicDetalle.Rows)
            {
                if (row[0] != null && row[3] != null &&
                    row[0].ToString() == conjuntoId && row[3].ToString() == habitacion.ToString())
                {
                    // Colorear el botón de naranja y mostrar mensaje
                    btn.BackColor = Color.Orange;
                    MessageBox.Show("La habitación ya forma parte de la reservación.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            // Buscar datos de la habitación
            DataRow dtResponse = datautilities.getRecordByPrimaryKey("Habitaciones", conjuntoId).Rows[0];

            string nombreHabitaciones, noHabitaciones, precio, costoReservación, nombrePaquete;

            nombreHabitaciones = Convert.ToString(dtResponse["Nombre"]);
            noHabitaciones = habitacion.ToString();

            if (Convert.ToString(CmbCostosConjunto.SelectedValue) == "0")
            {
                nombrePaquete = "Precio base";
                precio = Convert.ToString(dtResponse["decCosto"]);

                if (Convert.ToBoolean(dtResponse["bitPorcentaje"]))
                {
                    decimal decPorcentaje = Convert.ToDecimal(dtResponse["decMonto"]) / 100;
                    costoReservación = (Decimal.Round(Convert.ToDecimal(precio) * decPorcentaje, 2)).ToString();
                }
                else
                {
                    costoReservación = Convert.ToString(dtResponse["decMonto"]);
                }
            }
            else
            {
                DataRow dtResponsePaquete = datautilities.getRecordByPrimaryKey("PaquetesHabitaciones", CmbCostosConjunto.SelectedValue).Rows[0];
                precio = Convert.ToString(dtResponsePaquete["Precio"]);
                nombrePaquete = Convert.ToString(dtResponsePaquete["NombrePaquete"]);

                if (Convert.ToBoolean(dtResponse["bitPorcentaje"]))
                {
                    decimal decPorcentaje = Convert.ToDecimal(dtResponse["decMonto"]) / 100;
                    costoReservación = (Decimal.Round(Convert.ToDecimal(precio) * decPorcentaje, 2)).ToString();
                }
                else
                {
                    costoReservación = Convert.ToString(dtResponse["decMonto"]);
                }
            }

            //Calcular segun la cantidad de dias
            precio = (Convert.ToDecimal(precio) * auxFrm.auxCantidadDias).ToString();
            costoReservación = (Convert.ToDecimal(costoReservación) * auxFrm.auxCantidadDias).ToString();

            // Agregar la habitación a la tabla de detalle
            auxFrm.dynamicDetalle.Rows.Add(conjuntoId, Convert.ToString(CmbCostosConjunto.SelectedValue), nombreHabitaciones, noHabitaciones, precio, costoReservación, nombrePaquete);
            auxFrm.ActualizarDatosItems();
            this.Close();
        }


        private void PnlSeleccionarHabitaciones_Load(object sender, EventArgs e)
        {
            // Lógica adicional si es necesario
        }
    }
}
