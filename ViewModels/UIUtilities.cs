using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.ViewModels
{
    public static class UIUtilities
    {
        public static void EstablecerFondo(Form formulario)
        {
            // Fondo en gradiente
            formulario.BackColor = Color.WhiteSmoke; // Color base para fondo claro
            formulario.BackgroundImage = GenerarGradiente();
            formulario.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private static Bitmap GenerarGradiente()
        {
            Bitmap bmp = new Bitmap(800, 600); // Dimensiones iniciales
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Gradiente lineal de gris claro (#f0f0f0) a azul pastel (#b3d9ff)
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(0, bmp.Height),
                    Color.FromArgb(240, 240, 240), // Gris claro
                    Color.FromArgb(179, 217, 255))) // Azul pastel
                {
                    g.FillRectangle(brush, 0, 0, bmp.Width, bmp.Height);
                }
            }
            return bmp;
        }

        public static void PersonalizarDataGridView(DataGridView dgv)
        {
            // Deshabilitar estilos visuales predeterminados
            dgv.EnableHeadersVisualStyles = false;

            // Configuración de encabezados
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue; // Azul suave
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;    // Texto blanco
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold); // Fuente moderna y clara
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centrado

            // Configuración de filas
            dgv.RowsDefaultCellStyle.Font = new Font("Segoe UI", 12); // Tamaño de letra más grande
            dgv.RowsDefaultCellStyle.BackColor = Color.White;         // Fondo blanco para filas
            dgv.RowsDefaultCellStyle.ForeColor = Color.Black;         // Texto negro para contraste
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue; // Fondo alterno azul claro
            dgv.RowsDefaultCellStyle.SelectionBackColor = Color.LightSteelBlue; // Fondo de selección suave
            dgv.RowsDefaultCellStyle.SelectionForeColor = Color.Black;         // Texto negro al seleccionar

            // Bordes y diseño general
            dgv.GridColor = Color.LightGray;                         // Color de las líneas de la cuadrícula
            dgv.BorderStyle = BorderStyle.Fixed3D;                   // Bordes del control
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single; // Bordes de celda

            // Ajuste automático al contenido
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Ajustar columnas al contenido
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;       // Ajustar filas al contenido

            // Otras configuraciones opcionales
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;    // Selección completa de fila
            dgv.MultiSelect = false;                                        // Deshabilitar selección múltiple
        }

        public static void PersonalizarDataGridViewPequeños(DataGridView dgv)
        {
            // Deshabilitar estilos visuales predeterminados
            dgv.EnableHeadersVisualStyles = false;

            // Configuración de encabezados
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue; // Azul suave
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;    // Texto blanco
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold); // Fuente moderna y clara
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centrado

            // Configuración de filas
            dgv.RowsDefaultCellStyle.Font = new Font("Segoe UI", 12,FontStyle.Bold); // Tamaño de letra más grande
            dgv.RowsDefaultCellStyle.BackColor = Color.White;         // Fondo blanco para filas
            dgv.RowsDefaultCellStyle.ForeColor = Color.Black;         // Texto negro para contraste
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue; // Fondo alterno azul claro
            dgv.RowsDefaultCellStyle.SelectionBackColor = Color.LightSteelBlue; // Fondo de selección suave
            dgv.RowsDefaultCellStyle.SelectionForeColor = Color.Black;         // Texto negro al seleccionar

            // Bordes y diseño general
            dgv.GridColor = Color.LightGray;                         // Color de las líneas de la cuadrícula
            dgv.BorderStyle = BorderStyle.Fixed3D;                   // Bordes del control
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single; // Bordes de celda

            // Ajuste automático al contenido
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Ajustar columnas al contenido
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;       // Ajustar filas al contenido

            // Otras configuraciones opcionales
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;    // Selección completa de fila
            dgv.MultiSelect = false;                                        // Deshabilitar selección múltiple
        }

        //Configuracion de botones
        public static void ConfigurarBotonBuscar(Button boton)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 1;
            boton.FlatAppearance.BorderColor = Color.SteelBlue;
            boton.BackColor = Color.SteelBlue;
            boton.ForeColor = Color.White;
            boton.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            boton.Text = "Buscar"; // Icono para hacerlo más atractivo
            boton.ImageAlign = ContentAlignment.MiddleLeft; // Icono alineado a la izquierda
            boton.TextAlign = ContentAlignment.MiddleCenter; // Texto centrado

            AplicarEfectosHover(boton, Color.SteelBlue);
        }

        private static void AplicarEfectosHover(Button boton, Color colorBase)
        {
            Color colorHover = ControlPaint.Light(colorBase); // Color para hover
            Color colorClick = ControlPaint.Dark(colorBase);  // Color para clic

            boton.MouseEnter += (s, e) => boton.BackColor = colorHover;
            boton.MouseLeave += (s, e) => boton.BackColor = colorBase;
            boton.MouseDown += (s, e) => boton.BackColor = colorClick;
            boton.MouseUp += (s, e) => boton.BackColor = colorHover;
        }

        public static void ConfigurarTextBoxBuscar(TextBox textBox)
        {
            // Estilo base
            textBox.BorderStyle = BorderStyle.FixedSingle; // Borde simple y profesional
            textBox.Font = new Font("Segoe UI", 14, FontStyle.Regular); // Fuente moderna y legible
            textBox.ForeColor = Color.Black; // Texto negro para buena legibilidad
            textBox.BackColor = Color.White; // Fondo blanco para claridad

            // Efectos visuales
            textBox.Enter += (s, e) => textBox.BackColor = Color.AliceBlue; // Fondo azul claro al enfocar
            textBox.Leave += (s, e) => textBox.BackColor = Color.White; // Restaurar el fondo al perder el enfoque

            // Efectos al pasar el mouse
            textBox.MouseEnter += (s, e) => textBox.BackColor = ControlPaint.Light(textBox.BackColor, 0.9f);
            textBox.MouseLeave += (s, e) =>
            {
                if (!textBox.Focused)
                    textBox.BackColor = Color.White; // Restaurar fondo solo si no está enfocado
            };
        }

        public static void ConfigurarComboBox(ComboBox comboBox)
        {
            // Establecer el estilo del ComboBox
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.Font = new Font("Segoe UI", 14, FontStyle.Regular); // Fuente moderna y legible
            comboBox.ForeColor = Color.Black; // Color de texto estándar
            comboBox.BackColor = Color.White; // Fondo blanco para claridad

            // Efectos visuales cuando el ComboBox recibe o pierde el enfoque
            comboBox.Enter += (s, e) =>
            {
                comboBox.BackColor = Color.AliceBlue; // Fondo azul claro cuando se enfoca
            };

            comboBox.Leave += (s, e) =>
            {
                comboBox.BackColor = Color.White; // Restaurar el fondo blanco cuando pierde el enfoque
            };

            // Efectos de Mouse (hover)
            comboBox.MouseEnter += (s, e) =>
            {
                comboBox.BackColor = ControlPaint.Light(comboBox.BackColor, 0.9f); // Cambiar el color al pasar el mouse
            };

            comboBox.MouseLeave += (s, e) =>
            {
                if (!comboBox.Focused)
                    comboBox.BackColor = Color.White; // Restaurar el color si no está enfocado
            };
        }

        public static void ConfigurarBotonCrear(Button boton)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 1;
            boton.FlatAppearance.BorderColor = Color.SeaGreen; // Color de borde
            boton.BackColor = Color.SeaGreen; // Fondo verde para "Crear"
            boton.ForeColor = Color.White; // Texto blanco para contraste
            boton.Font = new Font("Segoe UI", 13, FontStyle.Bold); // Fuente moderna y gruesa
            boton.Text = "Crear";
            AplicarEfectosHover(boton, Color.SeaGreen, Color.DarkGreen); // Efectos al pasar el mouse
        }

        public static void ConfigurarBotonActualizar(Button boton)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 1;
            boton.FlatAppearance.BorderColor = Color.DodgerBlue; // Color de borde
            boton.BackColor = Color.DodgerBlue; // Fondo azul para "Actualizar"
            boton.ForeColor = Color.White; // Texto blanco para contraste
            boton.Font = new Font("Segoe UI", 13, FontStyle.Bold); // Fuente moderna y gruesa
            boton.Text = "Actualizar";
            AplicarEfectosHover(boton, Color.DodgerBlue, Color.MediumBlue); // Efectos al pasar el mouse
        }
        public static void ConfigurarBotonAnterior(Button boton)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 1;
            boton.FlatAppearance.BorderColor = Color.OrangeRed; // Color de borde
            boton.BackColor = Color.OrangeRed; // Fondo rojo anaranjado para "Anterior"
            boton.ForeColor = Color.White; // Texto blanco para contraste
            boton.Font = new Font("Segoe UI", 13, FontStyle.Bold); // Fuente moderna y gruesa
            boton.Text = "Anterior";
            AplicarEfectosHover(boton, Color.OrangeRed, Color.DarkRed); // Efectos al pasar el mouse
        }

        public static void ConfigurarBotonSiguiente(Button boton)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 1;
            boton.FlatAppearance.BorderColor = Color.SeaGreen; // Color de borde
            boton.BackColor = Color.SeaGreen; // Fondo verde para "Siguiente"
            boton.ForeColor = Color.White; // Texto blanco para contraste
            boton.Font = new Font("Segoe UI", 13, FontStyle.Bold); // Fuente moderna y gruesa
            boton.Text = "Siguiente";
            AplicarEfectosHover(boton, Color.SeaGreen, Color.DarkGreen); // Efectos al pasar el mouse
        }
        public static void ConfigurarBotonCambiarEstado(Button boton)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 1;
            boton.FlatAppearance.BorderColor = Color.Goldenrod; // Color de borde dorado
            boton.BackColor = Color.Goldenrod; // Fondo dorado para "Cambiar Estado"
            boton.ForeColor = Color.White; // Texto blanco para contraste
            boton.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Fuente moderna y gruesa
            boton.Text = "Cambiar Estado";
            AplicarEfectosHover(boton, Color.Goldenrod, Color.DarkGoldenrod); // Efectos al pasar el mouse
        }

        public static void ConfigurarTituloPantalla(Label lblTitulo, Panel panelTitulo)
        {
            // Configurar el panel de título
            panelTitulo.BackColor = Color.Transparent; // Fondo transparente para que se vea el gradiente
            panelTitulo.BackgroundImage = CrearDegradadoFondoTitulos(); // Asignamos un fondo degradado
            panelTitulo.BackgroundImageLayout = ImageLayout.Stretch; // Aseguramos que el fondo se estire a todo el panel
            panelTitulo.BorderStyle = BorderStyle.None; // Sin borde predeterminado para el panel

            // Configurar el label con el título
            lblTitulo.Font = new Font("Segoe UI", 18, FontStyle.Bold); // Fuente moderna y elegante
            lblTitulo.ForeColor = Color.White; // Texto blanco para buen contraste
            lblTitulo.AutoSize = true; // El tamaño del label se ajusta al texto
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft; // Alineación del texto a la izquierda
            lblTitulo.Location = new Point(20, panelTitulo.Height / 2 - 15); // Centrar el título verticalmente

            // Añadir sombra al texto para hacerlo más elegante
            lblTitulo.Text = lblTitulo.Text; // Añadir el texto de nuevo
        }

        // Función para crear el fondo degradado
        private static Image CrearDegradadoFondo()
        {
            int width = 400; // Ancho del fondo
            int height = 60; // Alto del fondo
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Crear un fondo degradado de arriba hacia abajo
                using (LinearGradientBrush brush = new LinearGradientBrush(
                        new Rectangle(0, 0, width, height),
                        Color.FromArgb(0, 123, 255), // Azul claro
                        Color.FromArgb(0, 76, 153), // Azul oscuro
                        90f))
                {
                    g.FillRectangle(brush, new Rectangle(0, 0, width, height));
                }
            }
            return bmp;
        }


        // Función para crear el fondo degradado
        private static Image CrearDegradadoFondoTitulos()
        {
            int width = 400; // Ancho del fondo
            int height = 60; // Alto del fondo
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Crear un fondo degradado de arriba hacia abajo
                using (LinearGradientBrush brush = new LinearGradientBrush(
                        new Rectangle(0, 0, width, height),
                        Color.FromArgb(0, 123, 255), // Azul claro
                        Color.FromArgb(0, 76, 153), // Azul oscuro
                        90f))
                {
                    g.FillRectangle(brush, new Rectangle(0, 0, width, height));
                }
            }
            return bmp;
        }


        private static void AplicarEfectosHover(Button boton, Color colorBase, Color colorHover)
        {
            boton.MouseEnter += (s, e) => boton.BackColor = ControlPaint.Light(colorBase, 0.8f); // Efecto hover
            boton.MouseLeave += (s, e) => boton.BackColor = colorBase; // Restaurar color original
            boton.MouseDown += (s, e) => boton.BackColor = colorHover; // Efecto cuando se presiona el botón
            boton.MouseUp += (s, e) => boton.BackColor = ControlPaint.Light(colorBase, 0.8f); // Restaurar al dejar de presionar
        }

        //UI Menu Principal
        private static void MostrarHora(Label lblHora)
        {
            lblHora.Font = new Font("Segoe UI", 14, FontStyle.Regular); // Fuente moderna y clara
            lblHora.ForeColor = Color.White; // Texto blanco para contraste
            lblHora.TextAlign = ContentAlignment.MiddleCenter; // Centrar el texto
            lblHora.AutoSize = false; // Para controlar el tamaño exacto del Label
            lblHora.Dock = DockStyle.Right; // Ubicarlo a la derecha del panel
            lblHora.Padding = new Padding(0, 10, 20, 0); // Separación agradable

            // Actualizar la hora cada segundo
            Timer timer = new Timer { Interval = 1000 }; // Intervalo de 1 segundo
            timer.Tick += (s, e) =>
            {
                lblHora.Text = DateTime.Now.ToString("hh:mm:ss tt"); // Formato 12 horas
            };
            timer.Start();
        }

        private static void ConfigurarTituloSistema(Label lblTitulo)
        {
            lblTitulo.Font = new Font("Segoe UI", 15, FontStyle.Bold); // Fuente moderna y elegante
            lblTitulo.ForeColor = Color.White; // Texto blanco
            lblTitulo.BackColor = Color.Transparent; // Fondo transparente para un diseño limpio
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft; // Alinear a la izquierda
            lblTitulo.Dock = DockStyle.Left; // Ubicar a la izquierda
            lblTitulo.Padding = new Padding(20, 10, 0, 0); // Espaciado para una mejor apariencia
        }

        public static void ConfigurarPanelPrincipal(Panel panelTitulo, Label lblTitulo, Label lblHora)
        {
            // Configurar el panel de fondo con un color fijo
            panelTitulo.BackColor = Color.FromArgb(44, 62, 80); // Azul grisáceo elegante
            panelTitulo.Height = 40; // Altura del panel
            panelTitulo.Padding = new Padding(0); // Sin margen extra

            // Añadir los elementos al panel
            ConfigurarTituloSistema(lblTitulo);
            MostrarHora(lblHora);

            panelTitulo.Controls.Add(lblTitulo);
            panelTitulo.Controls.Add(lblHora);
        }
    }
}
