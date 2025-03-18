using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NeoCobranza.PanelesHoteles
{
    public partial class PnlReservaHabitacion : Form
    {
        // Clase para representar una reserva. Se agregó la propiedad Estado.
        public class Reservation
        {
            public string Habitacion { get; set; }
            public string Descripcion { get; set; }
            public decimal Costo { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime FechaFin { get; set; }
            public string Estado { get; set; } // Ej: "Retrasado", "En Proceso", "Finalizado", "Próximo en llegar", "No se han ido"
            // Puedes agregar más propiedades si lo requieres.
        }

        // Variables para almacenar reservas y estado de orden
        private List<Reservation> allReservations;
        private List<Reservation> currentReservations;
        private bool isAscending = true;

        // Variable para la navegación de mes y año
        private DateTime currentDisplayDate;

        // Controles de la interfaz
        private Panel pnlTop;
        private FlowLayoutPanel flpReservations;
        private Button btnAgregarReserva;
        private Button btnOrdenar;
        private Button btnVerTodas;
        private Button btnHoy;
        private Button btnUltimaSemana;
        private Button btnUltimoMes;
        private FlowLayoutPanel pnlMonthNavigation;
        private Button btnPrev;
        private Button btnNext;
        private Label lblMonthYear;

        public PnlReservaHabitacion()
        {
            InitializeComponent();
            InitializeCustomControls();
        }

        private void InitializeCustomControls()
        {
            // --- Panel Superior: contiene botones de acción y la navegación de mes ---
            pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.DimGray
            };
            this.Controls.Add(pnlTop);

            // FlowLayoutPanel para los botones (alineados a la izquierda)
            FlowLayoutPanel flpTop = new FlowLayoutPanel
            {
                Dock = DockStyle.Left,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Padding = new Padding(10),
                BackColor = Color.DimGray,
                AutoSize = true
            };
            pnlTop.Controls.Add(flpTop);

            // Botón Agregar Reserva
            btnAgregarReserva = new Button
            {
                Text = "Agregar Reserva",
                Size = new Size(130, 50),
                Margin = new Padding(5),
                BackColor = Color.DarkGreen,
                ForeColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            btnAgregarReserva.Click += BtnAgregarReserva_Click;
            flpTop.Controls.Add(btnAgregarReserva);

            // Botón Ordenar
            btnOrdenar = new Button
            {
                Text = "Ordenar Ascendente",
                Size = new Size(130, 50),
                Margin = new Padding(5),
                BackColor = Color.DarkGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.System,
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            btnOrdenar.Click += BtnOrdenar_Click;
            flpTop.Controls.Add(btnOrdenar);

            // Botón Ver Todas
            btnVerTodas = new Button
            {
                Text = "Ver Todas",
                Size = new Size(100, 50),
                Margin = new Padding(5),
                BackColor = Color.DarkGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.System,
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            btnVerTodas.Click += BtnVerTodas_Click;
            flpTop.Controls.Add(btnVerTodas);

            // Botón HOY
            btnHoy = new Button
            {
                Text = "HOY",
                Size = new Size(100, 50),
                Margin = new Padding(5),
                BackColor = Color.DarkGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.System,
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            btnHoy.Click += BtnHoy_Click;
            flpTop.Controls.Add(btnHoy);

            // Botón Última Semana
            btnUltimaSemana = new Button
            {
                Text = "Última Semana",
                Size = new Size(120, 50),
                Margin = new Padding(5),
                BackColor = Color.DarkGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.System,
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            btnUltimaSemana.Click += BtnUltimaSemana_Click;
            flpTop.Controls.Add(btnUltimaSemana);

            // Botón Último Mes
            btnUltimoMes = new Button
            {
                Text = "Último Mes",
                Size = new Size(120, 50),
                Margin = new Padding(5),
                BackColor = Color.DarkGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.System,
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            btnUltimoMes.Click += BtnUltimoMes_Click;
            flpTop.Controls.Add(btnUltimoMes);

            // --- Panel de Navegación de Mes y Año ---
            pnlMonthNavigation = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                Width = 350,
                BackColor = Color.DimGray,
                Padding = new Padding(5)
            };
            pnlTop.Controls.Add(pnlMonthNavigation);

            // Botón para ir al mes anterior
            btnPrev = new Button
            {
                Text = "<",
                Size = new Size(80, 50),
                Margin = new Padding(5),
                BackColor = Color.DarkGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.System,
                Font = new Font("Arial", 20, FontStyle.Bold)
            };
            btnPrev.Click += BtnPrev_Click;
            pnlMonthNavigation.Controls.Add(btnPrev);

            // Etiqueta que muestra el mes y año actual (por ejemplo, "MAR 2025")
            lblMonthYear = new Label
            {
                Text = "", // Se actualizará en UpdateMonthYearLabel()
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(100, 50),
                Margin = new Padding(5),
                ForeColor = Color.White,
                Font = new Font("Arial", 15, FontStyle.Regular)
            };
            pnlMonthNavigation.Controls.Add(lblMonthYear);

            // Botón para ir al mes siguiente
            btnNext = new Button
            {
                Text = ">",
                Size = new Size(80, 50),
                Margin = new Padding(5),
                BackColor = Color.DarkGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.System,
                Font = new Font("Arial", 20, FontStyle.Bold)
            };
            btnNext.Click += BtnNext_Click;
            pnlMonthNavigation.Controls.Add(btnNext);

            // Inicializa la fecha de navegación al mes actual (primer día del mes)
            currentDisplayDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            UpdateMonthYearLabel();

            // --- Panel Principal: contiene la lista de reservas ---
            Panel pnlMain = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.WhiteSmoke
            };
            this.Controls.Add(pnlMain);
            pnlMain.BringToFront();

            // FlowLayoutPanel para mostrar las reservas
            flpReservations = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(10),
                BackColor = Color.WhiteSmoke
            };
            // Suscribir al evento Resize para ajustar el ancho de cada panel de reserva
            flpReservations.Resize += FlpReservations_Resize;
            pnlMain.Controls.Add(flpReservations);

            // Datos de prueba para reservas (con fechas y horas, y con diferentes estados)
            allReservations = new List<Reservation>
            {
                new Reservation { Habitacion = "Habitación 101", Descripcion = "Vista al mar", Costo = 120.50m, FechaInicio = new DateTime(2025, 3, 15, 14, 30, 0), FechaFin = new DateTime(2025, 3, 15, 16, 0, 0), Estado = "En Proceso" },
                new Reservation { Habitacion = "Habitación 102", Descripcion = "Suite Deluxe", Costo = 250.00m, FechaInicio = new DateTime(2025, 3, 15, 12, 0, 0), FechaFin = new DateTime(2025, 3, 15, 14, 0, 0), Estado = "Finalizado" },
                new Reservation { Habitacion = "Habitación 103", Descripcion = "Standard", Costo = 80.00m, FechaInicio = new DateTime(2025, 3, 17, 10, 0, 0), FechaFin = new DateTime(2025, 3, 17, 12, 0, 0), Estado = "Retrasado" },
                new Reservation { Habitacion = "Habitación 104", Descripcion = "Familiar", Costo = 150.00m, FechaInicio = new DateTime(2025, 3, 20, 9, 0, 0), FechaFin = new DateTime(2025, 3, 20, 11, 0, 0), Estado = "Próximo en llegar" },
                new Reservation { Habitacion = "Habitación 105", Descripcion = "Económica", Costo = 60.00m, FechaInicio = new DateTime(2025, 3, 20, 13, 0, 0), FechaFin = new DateTime(2025, 3, 20, 15, 0, 0), Estado = "No se han ido" }
            };

            // Por defecto se filtran las reservas del mes actual
            FilterReservationsByMonth();
        }

        // Actualiza la etiqueta de mes y año (ej: "MAR 2025")
        private void UpdateMonthYearLabel()
        {
            lblMonthYear.Text = currentDisplayDate.ToString("MMM yyyy").ToUpper();
        }

        /// <summary>
        /// Filtra las reservas según el mes y año seleccionados.
        /// </summary>
        private void FilterReservationsByMonth()
        {
            currentReservations = allReservations
                .Where(r => r.FechaInicio.Month == currentDisplayDate.Month &&
                            r.FechaInicio.Year == currentDisplayDate.Year)
                .ToList();
            RenderReservations(currentReservations);
        }

        /// <summary>
        /// Renderiza la lista de reservas agrupadas por FechaInicio.
        /// Se ha aumentado la altura de cada panel para mostrar la información adicional.
        /// </summary>
        private void RenderReservations(List<Reservation> reservationsToShow)
        {
            flpReservations.Controls.Clear();

            // Agrupar por FechaInicio (por día)
            var groupedReservations = reservationsToShow
                .GroupBy(r => r.FechaInicio.Date)
                .OrderBy(g => isAscending ? g.Key : g.Key, new DateComparer(isAscending))
                .ToList();

            foreach (var group in groupedReservations)
            {
                // Encabezado del grupo
                Label lblHeader = new Label
                {
                    Text = "Reservas para " + group.Key.ToShortDateString(),
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    AutoSize = true,
                    Margin = new Padding(10, 20, 10, 10)
                };
                flpReservations.Controls.Add(lblHeader);

                // Ordenar las reservas dentro del grupo por FechaFin (descendente)
                var reservationsInGroup = group.OrderByDescending(r => r.FechaFin).ToList();

                foreach (var res in reservationsInGroup)
                {
                    // Panel para cada reserva: se ajusta el ancho mediante el evento Resize y se aumenta la altura a 100
                    Panel pnlRes = new Panel
                    {
                        BorderStyle = BorderStyle.FixedSingle,
                        Height = 100,
                        Margin = new Padding(10, 5, 10, 5)
                    };

                    // Etiqueta con el nombre de la habitación
                    Label lblHabitacion = new Label
                    {
                        Text = res.Habitacion,
                        Location = new Point(10, 10),
                        AutoSize = true
                    };

                    // Etiqueta con la descripción
                    Label lblDescripcion = new Label
                    {
                        Text = res.Descripcion,
                        Location = new Point(10, 30),
                        AutoSize = true
                    };

                    // Etiqueta para el costo
                    Label lblCosto = new Label
                    {
                        Text = "Costo: $" + res.Costo.ToString("F2"),
                        Location = new Point(150, 10),
                        AutoSize = true
                    };

                    Label lblCantidadPersonas = new Label
                    {
                        Text = "Cantidad de Personas: 5" ,
                        Location = new Point(280, 10),
                        AutoSize = true
                    };

                    Label lblCliente = new Label
                    {
                        Text = "Cliente: Rolando José Maradiaga Zeledón",
                        Location = new Point(450, 10),
                        AutoSize = true
                    };

                    // Etiqueta para el rango de fechas, incluyendo horas
                    Label lblFechas = new Label
                    {
                        Text = $"Desde: {res.FechaInicio:dd/MM/yyyy HH:mm}  Hasta: {res.FechaFin:dd/MM/yyyy HH:mm}",
                        Location = new Point(150, 40),
                        AutoSize = true
                    };

                    // Etiqueta para el estado con el color según su valor
                    Label lblEstado = new Label
                    {
                        Text = "Estado: " + res.Estado,
                        Location = new Point(150, 70),
                        AutoSize = true,
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        ForeColor = GetColorForEstado(res.Estado)
                    };

                    // Botón "Ver Detalles" anclado a la derecha
                    Button btnDetalles = new Button
                    {
                        Text = "Ver Detalles",
                        Size = new Size(100, 25),
                        Anchor = AnchorStyles.Top | AnchorStyles.Right
                    };
                    // Posicionar el botón según el ancho actual del panel
                    btnDetalles.Location = new Point(pnlRes.Width - 110, 35);
                    btnDetalles.Click += (s, e) =>
                    {
                        MessageBox.Show($"Detalles de {res.Habitacion}\nDescripción: {res.Descripcion}\nCosto: ${res.Costo:F2}\n" +
                            $"Desde: {res.FechaInicio:dd/MM/yyyy HH:mm}\nHasta: {res.FechaFin:dd/MM/yyyy HH:mm}\nEstado: {res.Estado}",
                            "Detalle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    };

                    // Agregar controles al panel de reserva
                    pnlRes.Controls.Add(lblHabitacion);
                    pnlRes.Controls.Add(lblDescripcion);
                    pnlRes.Controls.Add(lblCosto);
                    pnlRes.Controls.Add(lblFechas);
                    pnlRes.Controls.Add(lblEstado);
                    pnlRes.Controls.Add(btnDetalles);
                    pnlRes.Controls.Add(lblCliente);
                    pnlRes.Controls.Add(lblCantidadPersonas);
                    flpReservations.Controls.Add(pnlRes);
                }
            }
        }

        // Evento para ajustar el ancho de cada panel de reserva al redimensionar el contenedor.
        private void FlpReservations_Resize(object sender, EventArgs e)
        {
            // Ajusta cada control de tipo Panel (nuestros paneles de reserva)
            foreach (Control ctrl in flpReservations.Controls)
            {
                if (ctrl is Panel)
                {
                    ctrl.Width = flpReservations.ClientSize.Width - 25;
                    // Reposiciona el botón "Ver Detalles" dentro del panel
                    foreach (Control subCtrl in ctrl.Controls)
                    {
                        if (subCtrl is Button && subCtrl.Text == "Ver Detalles")
                        {
                            subCtrl.Location = new Point(ctrl.Width - 110, subCtrl.Location.Y);
                        }
                    }
                }
            }
        }

        // Comparador para ordenar las fechas según isAscending
        public class DateComparer : IComparer<DateTime>
        {
            private bool ascending;
            public DateComparer(bool ascendingOrder)
            {
                ascending = ascendingOrder;
            }
            public int Compare(DateTime x, DateTime y)
            {
                return ascending ? DateTime.Compare(x, y) : DateTime.Compare(y, x);
            }
        }

        // --- Método auxiliar para obtener el color según el estado ---
        private Color GetColorForEstado(string estado)
        {
            switch (estado)
            {
                case "Retrasado":
                    return Color.Black;
                case "En Proceso":
                    return Color.Goldenrod;
                case "Finalizado":
                    return Color.SeaGreen;
                case "Próximo en llegar":
                    return Color.SteelBlue;
                case "No se han ido":
                    return Color.IndianRed;
                default:
                    return Color.Gray;
            }
        }

        // --- Eventos de botones y navegación de mes ---

        private void BtnAgregarReserva_Click(object sender, EventArgs e)
        {
           PnlAgregarReservacion frm = new PnlAgregarReservacion();
            frm.ShowDialog();
        }

        private void BtnOrdenar_Click(object sender, EventArgs e)
        {
            isAscending = !isAscending;
            btnOrdenar.Text = isAscending ? "Ordenar Ascendente" : "Ordenar Descendente";
            RenderReservations(currentReservations);
        }

        private void BtnVerTodas_Click(object sender, EventArgs e)
        {
            currentReservations = allReservations;
            RenderReservations(currentReservations);
        }

        private void BtnHoy_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            currentReservations = allReservations.Where(r => r.FechaInicio.Date <= today && r.FechaFin.Date >= today).ToList();
            RenderReservations(currentReservations);
        }

        private void BtnUltimaSemana_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime weekAgo = today.AddDays(-7);
            currentReservations = allReservations.Where(r => r.FechaInicio.Date >= weekAgo && r.FechaInicio.Date <= today).ToList();
            RenderReservations(currentReservations);
        }

        private void BtnUltimoMes_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime monthAgo = today.AddMonths(-1);
            currentReservations = allReservations.Where(r => r.FechaInicio.Date >= monthAgo && r.FechaInicio.Date <= today).ToList();
            RenderReservations(currentReservations);
        }

        // Navegación de mes: Botón Anterior
        private void BtnPrev_Click(object sender, EventArgs e)
        {
            currentDisplayDate = currentDisplayDate.AddMonths(-1);
            UpdateMonthYearLabel();
            FilterReservationsByMonth();
        }

        // Navegación de mes: Botón Siguiente
        private void BtnNext_Click(object sender, EventArgs e)
        {
            currentDisplayDate = currentDisplayDate.AddMonths(1);
            UpdateMonthYearLabel();
            FilterReservationsByMonth();
        }
    }
}
