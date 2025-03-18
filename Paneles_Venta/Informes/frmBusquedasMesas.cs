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

namespace NeoCobranza.Paneles_Venta.Informes
{
    public partial class frmBusquedasMesas : Form
    {
        DataUtilities dataUtilities = new DataUtilities();
        PnlPrincipal auxPnlPrincipal = null;
        public frmBusquedasMesas(PnlPrincipal frm)
        {
            InitializeComponent();
            auxPnlPrincipal = frm;

            dataUtilities.SetParameter("@idSucursal", Utilidades.SucursalId);
            DataTable dtResponse = dataUtilities.ExecuteStoredProcedure("spSalas");

            int botonTop = 2;
            int primeraSalaId = 0;

            foreach (DataRow s in dtResponse.Rows)
            {
                // Crear un nuevo botón
                System.Windows.Forms.Button botonSala = new System.Windows.Forms.Button();

                // Configurar propiedades del botón
                botonSala.Text = Convert.ToString(s["NombreSala"]); // Suponiendo que cada sala tiene un nombre
                botonSala.Tag = Convert.ToInt32(s["SalaId"]); // Almacenar la sala en el Tag del botón para referencia posterior
                botonSala.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                botonSala.Click += (sender, e) => SalaClick(Convert.ToInt32(s["SalaId"]));

                // Configurar colores
                botonSala.BackColor = SystemColors.MenuHighlight;
                botonSala.Font = new Font("Century Gothic", 15, FontStyle.Regular);
                botonSala.ForeColor = Color.White;
                int botonWidth = PnlListaSalas.ClientSize.Width; // Ancho del panel contenedor
                botonSala.Width = botonWidth; // Establecer el ancho del botón
                botonSala.Height = 45;


                // Establecer la posición vertical del botón
                botonSala.Top = botonTop;

                // Actualizar la posición vertical para el siguiente botón
                botonTop += botonSala.Height;

                // Agregar el botón al panel
                PnlListaSalas.Controls.Add(botonSala);

                if (primeraSalaId == 0)
                {
                    primeraSalaId = Convert.ToInt32(s["SalaId"]);
                }
            }

            if (primeraSalaId != 0)
            {
                SalaClick(primeraSalaId);
            }
        }

        private void SalaClick(int salaId)
        {
            // Restaurar el color por defecto (azul) en todas las salas
            foreach (Control control in PnlListaSalas.Controls)
            {
                if (control is Button btnSala)
                {
                    btnSala.BackColor = SystemColors.MenuHighlight;

                    if ((int)btnSala.Tag == salaId)
                    {
                        // Resaltar la sala seleccionada
                        btnSala.BackColor = Color.Green;

                        DataTable dtSalas = dataUtilities.getRecordByPrimaryKey("Salas", salaId);
                        if (dtSalas.Rows.Count == 0)
                            return;

                        DataRow itemSala = dtSalas.Rows[0];
                        LblSalaTitulo.Text = Convert.ToString(itemSala["NombreSala"]);
                        LblCantidadMesas.Text = Convert.ToString(itemSala["NoMesas"]);

                        // Limpiar panel de mesas actual
                        PnlMesasEnSala.Controls.Clear();

                        // Crear un FlowLayoutPanel para ubicar automáticamente los botones de mesas
                        FlowLayoutPanel flpMesas = new FlowLayoutPanel
                        {
                            Dock = DockStyle.Fill,
                            AutoScroll = true,
                            WrapContents = true,
                            FlowDirection = FlowDirection.LeftToRight,
                            Padding = new Padding(5),
                            BackColor = Color.Transparent // Opcional: para que herede el fondo
                        };
                        PnlMesasEnSala.Controls.Add(flpMesas);

                        int totalMesas = Convert.ToInt32(itemSala["NoMesas"]);
                        DataTable dtOrdenes = dataUtilities.GetAllRecords("Ordenes");

                        for (int i = 1; i <= totalMesas; i++)
                        {
                            // Se crea el botón cuadrado y se le asignan las propiedades de imagen y texto
                            Button btnMesa = new Button
                            {
                                Text = $"Mesa - {i}\n{"Disponible"}", // Texto en dos líneas: título y sala
                                Tag = i,
                                Width = 150,
                                Height = 150,
                                Font = new Font("Century Gothic", 15, FontStyle.Regular),
                                ForeColor = Color.White,
                                BackColor = Color.ForestGreen,
                                Margin = new Padding(5),
                                Image = Properties.Resources.Mesa, // Asegúrate de agregar el GIF animado a tus recursos
                                ImageAlign = ContentAlignment.MiddleCenter,
                                TextAlign = ContentAlignment.BottomCenter,
                                TextImageRelation = TextImageRelation.ImageAboveText
                            };

                            // Identificador de la mesa en el formato "NombreSala-i"
                            string mesaIdentificador = $"{itemSala["NombreSala"]}-{i}";

                            // Filtrar órdenes activas para la mesa
                            var ordenesMesa = dtOrdenes.AsEnumerable().Where(row =>
                                row.Field<string>("SucursalId") == Utilidades.SucursalId &&
                                row.Field<string>("OrdenProceso") == "Orden Abierta" &&
                                row.Field<string>("SalaMesa") == mesaIdentificador);

                            DataTable dataTable;
                            if (ordenesMesa.Any())
                            {
                                btnMesa.Image = Properties.Resources.Cubiertos;
                                btnMesa.Text = Text = $"Mesa - {i}\n{"Ocupada"}";
                                btnMesa.BackColor = Color.DarkRed;
                                dataTable = ordenesMesa.CopyToDataTable();
                            }
                            else
                            {
                                dataTable = new DataTable();
                            }

                            // Capturar el valor actual de i en una variable local para el evento
                            int mesaIndex = i;
                            btnMesa.Click += (sender, e) => MesaClick(mesaIdentificador, dataTable);

                            // Agregar el botón al FlowLayoutPanel
                            flpMesas.Controls.Add(btnMesa);
                        }


                        //for (int i = 1; i <= totalMesas; i++)
                        //{
                        //    Button btnMesa = new Button
                        //    {
                        //        Text = $"Mesa - {i}",
                        //        Tag = i,
                        //        Width = 150,
                        //        Height = 45,
                        //        Font = new Font("Century Gothic", 15, FontStyle.Regular),
                        //        ForeColor = Color.White,
                        //        BackColor = Color.ForestGreen,
                        //        Margin = new Padding(5)
                        //    };

                        //    // Identificador de la mesa en el formato "NombreSala-i"
                        //    string mesaIdentificador = $"{itemSala["NombreSala"]}-{i}";

                        //    // Filtrar órdenes activas para la mesa
                        //    var ordenesMesa = dtOrdenes.AsEnumerable().Where(row =>
                        //        row.Field<string>("SucursalId") == Utilidades.SucursalId &&
                        //        row.Field<string>("OrdenProceso") == "Orden Abierta" &&
                        //        row.Field<string>("SalaMesa") == mesaIdentificador);

                        //    DataTable dataTable;
                        //    if (ordenesMesa.Any())
                        //    {
                        //        btnMesa.BackColor = Color.DarkRed;
                        //        dataTable = ordenesMesa.CopyToDataTable();
                        //    }
                        //    else
                        //    {
                        //        dataTable = new DataTable();
                        //    }

                        //    // Capturar el valor actual de i en una variable local para el evento
                        //    int mesaIndex = i;
                        //    btnMesa.Click += (sender, e) => MesaClick(mesaIdentificador, dataTable);

                        //    // Agregar el botón al FlowLayoutPanel
                        //    flpMesas.Controls.Add(btnMesa);
                        //}
                    }
                }
            }
        }

        private void MesaClick(string MesaSala, DataTable orden)
        {
            if (orden.Rows.Count > 0)
            {
                auxPnlPrincipal.AbrirVenta(Convert.ToDecimal(orden.Rows[0]["OrdenId"]),Utilidades.SucursalId, MesaSala);
            }
            else
            {
                auxPnlPrincipal.AbrirVenta(0, Utilidades.SucursalId, MesaSala);
            }
        }
    }
}
