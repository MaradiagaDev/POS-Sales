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
        DateTime auxFechaInicio,auxFechaFin;
        PnlAgregarReservacion auxFrm;
        public class Habitacion
        {
            public string Nombre { get; set; }
            public decimal Costo { get; set; }
            public int Cantidad { get; set; }
            public string Descripcion { get; set; } // Descripción del conjunto
        }

        // Lista de conjuntos de habitaciones para probar con muchos items
    
        public PnlSeleccionarHabitaciones(DateTime inicio,DateTime fin, PnlAgregarReservacion frm)
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
                    BackColor = disponible == "Disponible" ? Color.LightGreen : Color.LightCoral,  // Verde disponible, Rojo ocupada
                    Text = $"\nCuarto {numeroHabitacion}\n{(disponible == "Disponible" ? disponible : "Ocupado")}",
                    TextImageRelation = TextImageRelation.ImageAboveText,
                    ImageAlign = ContentAlignment.MiddleCenter,
                    TextAlign = ContentAlignment.BottomCenter
                };

                btnHabitacion.Image = roomImage;

                // Evento para manejar la selección de la habitación
                btnHabitacion.Click += (sender, e) => seleccionarCuarto(idConjunto, numeroHabitacion,disponible);

                FLHabitaciones.Controls.Add(btnHabitacion);
            }

            //Cargar Costos
            datautilities.SetParameter("@HabitacionId", idConjunto);
            DataTable dtResponse = datautilities.ExecuteStoredProcedure("spObtenerPaquetesPorHabitacion");
            CmbCostosConjunto.DataSource = dtResponse;
            CmbCostosConjunto.DisplayMember = "NombreCompleto";
            CmbCostosConjunto.ValueMember = "PaqueteId";
        }

        private void seleccionarCuarto(string conjuntoId,int habitacion,string disponible)
        {
            if(disponible != "Disponible")
            {
                MessageBox.Show("La habitación no está disponible en el periodo seleccionado.","Atención",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Buscar datos
            DataRow dtResponse = datautilities.getRecordByPrimaryKey("Habitaciones", conjuntoId).Rows[0];

            string nombreHabitaciones,noHabitaciones,precio,costoReservación,nombrePaquete;

            nombreHabitaciones = Convert.ToString(dtResponse["Nombre"]);
            noHabitaciones = habitacion.ToString();


            if (Convert.ToString(CmbCostosConjunto.SelectedValue) == "0")
            {
                nombrePaquete = "Precio base";
                precio = Convert.ToString(dtResponse["decCosto"]);

                if (Convert.ToBoolean(dtResponse["bitPorcentaje"])) 
                {
                    decimal decPorcentaje = Convert.ToDecimal(dtResponse["decMonto"])/100; 
                    costoReservación = (Decimal.Round(Convert.ToDecimal(precio) * decPorcentaje,2)).ToString();
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

            auxFrm.dynamicDetalle.Rows.Add(nombreHabitaciones ,noHabitaciones,precio,costoReservación,nombrePaquete);

            this.Close();
        }

        private void PnlSeleccionarHabitaciones_Load(object sender, EventArgs e)
        {
            // Lógica adicional si es necesario
        }
    }
}
