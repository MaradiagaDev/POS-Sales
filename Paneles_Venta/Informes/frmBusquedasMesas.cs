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
            }
        }

        private void SalaClick(int SalaId)
        {
            // Restaurar color azul a todas las salas
            foreach (Control control in PnlListaSalas.Controls)
            {
                if (control is System.Windows.Forms.Button)
                {
                    control.BackColor = SystemColors.MenuHighlight;

                    if ((int)control.Tag == SalaId)
                    {
                        control.BackColor = System.Drawing.Color.Green;


                        DataTable dtSalas = dataUtilities.getRecordByPrimaryKey("Salas", SalaId);
                        DataRow itemSala = dtSalas.Rows[0];

                        LblSalaTitulo.Text = Convert.ToString(itemSala["NombreSala"]);
                        LblCantidadMesas.Text = Convert.ToString(itemSala["NoMesas"]);


                        PnlMesasEnSala.Controls.Clear();
                        //Ahora colocar los botones por cada sala


                        // Crear un panel principal para contener los botones de las mesas
                        Panel panelPrincipal = new Panel();
                        panelPrincipal.Dock = DockStyle.Fill;
                        panelPrincipal.AutoScroll = true;

                        // Agregar el panel principal al panel de mesas en sala
                        PnlMesasEnSala.Controls.Add(panelPrincipal);

                        // Calcular el ancho máximo del panel contenedor de mesas
                        int panelWidth = panelPrincipal.ClientSize.Width;
                        int botonWidth = 150; // Ancho fijo para cada botón
                        int filaActual = 0;
                        int columnaActual = 0;

                        for (int i = 1; i <= Convert.ToInt32(itemSala["NoMesas"]); i++)
                        {
                            System.Windows.Forms.Button botonSala = new System.Windows.Forms.Button();

                            // Configurar propiedades del botón
                            botonSala.Text = $"Mesa - {i.ToString()}";
                            botonSala.Tag = i;
                            botonSala.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                            botonSala.BackColor = Color.ForestGreen;


                            DataTable dtResponse = dataUtilities.GetAllRecords("Ordenes");
                            var filterRow =
                                from row in dtResponse.AsEnumerable()
                                where Convert.ToString(row.Field<string>("SucursalId")) == Utilidades.SucursalId
                                && Convert.ToString(row.Field<string>("OrdenProceso")) == "Orden Abierta"
                                && Convert.ToString(row.Field<string>("SalaMesa")) == $"{Convert.ToString(itemSala["NombreSala"])}-{i.ToString()}"
                                select row;

                            if (filterRow.Any())
                            {
                                botonSala.BackColor = Color.DarkRed;
                            }

                            botonSala.Font = new Font("Century Gothic", 15, FontStyle.Regular);
                            botonSala.ForeColor = Color.White;
                            botonSala.Height = 45;

                            // Calcular la posición horizontal del botón
                            int botonLeft = columnaActual * botonWidth;

                            // Calcular la posición vertical del botón
                            int botonTop = filaActual * botonSala.Height;

                            // Establecer el ancho y la posición horizontal del botón
                            botonSala.Width = botonWidth;
                            botonSala.Left = botonLeft;
                            botonSala.Top = botonTop;

                            int mesaIndex = i; // Capturar el valor actual de i en una variable local

                            if (filterRow.Any())
                            {
                                DataTable dataTable = filterRow.CopyToDataTable();
                                botonSala.Click += (sender, e) => MesaClick($"{Convert.ToString(itemSala["NombreSala"])}-{mesaIndex.ToString()}", dataTable);
                            }
                            else
                            {
                                DataTable dataTable = new DataTable();
                                botonSala.Click += (sender, e) => MesaClick($"{Convert.ToString(itemSala["NombreSala"])}-{mesaIndex.ToString()}", dataTable);
                            }



                            // Actualizar el índice de la columna actual
                            columnaActual++;

                            // Verificar si se ha llegado al límite de botones por fila
                            if (columnaActual >= 9)
                            {
                                // Reiniciar la columna actual
                                columnaActual = 0;
                                // Mover a la siguiente fila
                                filaActual++;
                            }

                            // Agregar el botón al panel principal
                            panelPrincipal.Controls.Add(botonSala);
                        }
                    }
                }
            }
        }

        private void MesaClick(string MesaSala, DataTable orden)
        {
            if (orden.Rows.Count > 0)
            {
                auxPnlPrincipal.AbrirVenta(Convert.ToDecimal(orden.Rows[0]["OrdenId"]), MesaSala);
            }
            else
            {
                auxPnlPrincipal.AbrirVenta(0, MesaSala);
            }
        }
    }
}
