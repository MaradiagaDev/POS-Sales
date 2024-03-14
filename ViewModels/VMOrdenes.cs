using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles;
using NeoCobranza.Paneles_Venta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NeoCobranza.ViewModels
{
    public class VMOrdenes
    {
        public DataTable dynamicDataTable = new DataTable();
        public DataTable dynamicDataTableProductos = new DataTable();
        public string auxSubModulo;
        public string auxAccion;

        public void InitModuloOrdenes(PnlVentas frm, string opc, string key)
        {

            frm.TCMain.Appearance = TabAppearance.FlatButtons;
            frm.TCMain.SizeMode = TabSizeMode.Fixed;
            frm.TCMain.ItemSize = new System.Drawing.Size(1, 1);

            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                
                switch (opc)
                {
                    case "OrdenRapida":
                        
                        frm.LblEstadoOrden.Text = "Orden Abierta";
                        frm.LblFechaGeneracion.Text = DateTime.Now.ToString();

                        frm.LblProcesoPago.Text = "Sin Pagos";

                        frm.BtnPagarOrden.Enabled = false;

                        frm.ChkRetencionDgi.Visible = false;
                        frm.ChkRetencionAlcaldia.Visible = false;

                        dynamicDataTable.Columns.Add("Id", typeof(string));
                        dynamicDataTable.Columns.Add("Producto", typeof(string));
                        dynamicDataTable.Columns.Add("Cantidad", typeof(string));
                        dynamicDataTable.Columns.Add("Precio Unitario", typeof(string));
                        dynamicDataTable.Columns.Add("SubTotal", typeof(string));

                        DataGridViewButtonColumn buttonColumnAdd = new DataGridViewButtonColumn();
                        buttonColumnAdd.HeaderText = "...";
                        buttonColumnAdd.Text = " Agregar ";
                        buttonColumnAdd.UseColumnTextForButtonValue = true;

                        DataGridViewButtonColumn buttonColumnDelete = new DataGridViewButtonColumn();
                        buttonColumnDelete.HeaderText = "...";
                        buttonColumnDelete.Text = " Quitar ";
                        buttonColumnDelete.UseColumnTextForButtonValue = true;

                        DataGridViewButtonColumn buttonColumnDeleteAll = new DataGridViewButtonColumn();
                        buttonColumnDeleteAll.HeaderText = "...";
                        buttonColumnDeleteAll.Text = " Quitar Todo ";
                        buttonColumnDeleteAll.UseColumnTextForButtonValue = true;


                        Usuario usuario = db.Usuario.Where(s => s.IdUsuarios.ToString() == Utilidades.IdUsuario).FirstOrDefault();
                        frm.LblIdVendedor.Text = usuario.IdUsuarios.ToString();
                        frm.LblNombreVendedor.Text = usuario.PrimerNombre + " " + usuario.PrimerApellido;

                        auxSubModulo = "Orden";
                        auxAccion = "Crear";

                        frm.DgvItemsOrden.DataSource = dynamicDataTable;
                        frm.DgvItemsOrden.Columns.Add(buttonColumnAdd);
                        frm.DgvItemsOrden.Columns.Add(buttonColumnDelete);
                        frm.DgvItemsOrden.Columns.Add(buttonColumnDeleteAll);

                        //Agregar al Cliente Mostrador
                        Clientes cliente = db.Clientes.Where(c => c.IdCliente == 1).FirstOrDefault();
                        if(cliente != null)
                        {
                            frm.LblNombreClientes.Text = cliente.Pnombre + " " + cliente.Snombre + " " + cliente.Papellido + " " + cliente.Sapellido;
                            frm.lblEstadoCliente.Text = "Cliente Seleccionado";
                            frm.lblEstadoCliente.ForeColor = Color.Green;
                            frm.LblIdClientes.Text = cliente.IdCliente.ToString();
                        }
                        else
                        {
                            MessageBox.Show("El CLIENTE MOSTRADOR no ha sido agregado.", "Atención", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }

                        var informativeMessageBox = new InformativeMessageBox($"Orden Creada Correctamente.", "Orden Creada", 3000); // 3000 milisegundos = 3 segundos
                        informativeMessageBox.Show();

                        break;

                    case "Salas":
                        frm.llbTitulo.Text = "Gestión de Salas";
                        frm.TCMain.SelectedIndex = 7;

                        var salas = db.Salas.Where(s => s.SucursalId == int.Parse(Utilidades.SucursalId)).ToList();

                        int botonTop = 2;

                        foreach ( var s in salas)
                        {
                            // Crear un nuevo botón
                            System.Windows.Forms.Button botonSala = new System.Windows.Forms.Button();

                            // Configurar propiedades del botón
                            botonSala.Text = s.NombreSala; // Suponiendo que cada sala tiene un nombre
                            botonSala.Tag = s.SalaId; // Almacenar la sala en el Tag del botón para referencia posterior
                            botonSala.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                            botonSala.Click += (sender, e) => SalaClick(s.SalaId, frm);

                            // Configurar colores
                            botonSala.BackColor = SystemColors.MenuHighlight;
                            botonSala.Font = new Font("Century Gothic", 15, FontStyle.Bold);
                            botonSala.ForeColor = Color.White;
                            int botonWidth = frm.PnlListaSalas.ClientSize.Width; // Ancho del panel contenedor
                            botonSala.Width = botonWidth; // Establecer el ancho del botón
                            botonSala.Height = 45;

                            // Establecer la posición vertical del botón
                            botonSala.Top = botonTop;

                            // Actualizar la posición vertical para el siguiente botón
                            botonTop += botonSala.Height;

                            // Agregar el botón al panel
                            frm.PnlListaSalas.Controls.Add(botonSala);
                        }

                        break;
                }
            }
        }

        private void SalaClick(int SalaId, PnlVentas frm)
        {
            // Restaurar color azul a todas las salas
            foreach (Control control in frm.PnlListaSalas.Controls)
            {
                if (control is System.Windows.Forms.Button)
                {
                    control.BackColor = SystemColors.MenuHighlight;

                    if ((int)control.Tag == SalaId)
                    {
                        control.BackColor = System.Drawing.Color.Green;

                        using(NeoCobranzaContext db = new NeoCobranzaContext())
                        {
                            var sala = db.Salas.Where(s => s.SalaId == SalaId).FirstOrDefault();

                            frm.LblSalaTitulo.Text = sala.NombreSala;
                            frm.LblCantidadMesas.Text = sala.NoMesas.ToString();


                            frm.PnlMesasEnSala.Controls.Clear();
                            //Ahora colocar los botones por cada sala


                            // Crear un panel principal para contener los botones de las mesas
                            Panel panelPrincipal = new Panel();
                            panelPrincipal.Dock = DockStyle.Fill;
                            panelPrincipal.AutoScroll = true;

                            // Agregar el panel principal al panel de mesas en sala
                            frm.PnlMesasEnSala.Controls.Add(panelPrincipal);

                            // Calcular el ancho máximo del panel contenedor de mesas
                            int panelWidth = panelPrincipal.ClientSize.Width;
                            int botonWidth = 150; // Ancho fijo para cada botón
                            int filaActual = 0;
                            int columnaActual = 0;

                            for (int i = 1; i <= sala.NoMesas; i++)
                            {
                                System.Windows.Forms.Button botonSala = new System.Windows.Forms.Button();

                                // Configurar propiedades del botón
                                botonSala.Text = $"Mesa - {i.ToString()}";
                                botonSala.Tag = i;
                                botonSala.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                                botonSala.BackColor = Color.ForestGreen;
                                botonSala.Font = new Font("Century Gothic", 15, FontStyle.Bold);
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
        }

        public void ConfigUI(PnlVentas frm, string opc)
        {
            switch (opc)
            {
                case "Productos":
                    frm.TCMain.SelectedIndex = 2;
                    frm.llbTitulo.Text = "Agregar Producto a la Orden";

                    auxSubModulo = "Productos";
                    auxAccion = "Buscar";

                    using (NeoCobranzaContext db = new NeoCobranzaContext())
                    {
                        //Tipos Servicios
                        List<TipoServicios> listTipoServicios = new List<TipoServicios>();

                        TipoServicios tipoServicios = new TipoServicios()
                        {
                            Descripcion = "Mostrar Todas",
                            Estado = "Activo",
                            TipoServicionId = 0
                        };

                        listTipoServicios.Add(tipoServicios);

                        List<TipoServicios> listBdTipo = db.TipoServicios.Where(s => s.Estado == "Activo").OrderByDescending(s => s.TipoServicionId).ToList();
                        listTipoServicios.AddRange(listBdTipo);

                        dynamicDataTableProductos = new DataTable();
                        frm.DgvProductos.Columns.Clear();

                        if (dynamicDataTableProductos.Columns.Count < 3)
                        {
                            dynamicDataTableProductos.Columns.Add("Id", typeof(string));
                            dynamicDataTableProductos.Columns.Add("Producto", typeof(string));
                            dynamicDataTableProductos.Columns.Add("Cantidad", typeof(string));
                            dynamicDataTableProductos.Columns.Add("Precio Unitario (NIO)", typeof(string));
                            dynamicDataTableProductos.Columns.Add($"Precio Unitario $ ({Utilidades.Tasa})", typeof(string));

                            frm.DgvProductos.DataSource = dynamicDataTableProductos;

                            // Agregar una columna de botón
                            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                            buttonColumn.HeaderText = "...";
                            buttonColumn.Text = "Agregar a Venta";
                            buttonColumn.UseColumnTextForButtonValue = true;
                            frm.DgvProductos.Columns.Add(buttonColumn);

                            DataGridViewButtonColumn buttonColumnDisponibilidad = new DataGridViewButtonColumn();
                            buttonColumnDisponibilidad.HeaderText = "...";
                            buttonColumnDisponibilidad.Text = "Disponibilidad";
                            buttonColumnDisponibilidad.UseColumnTextForButtonValue = true;
                            frm.DgvProductos.Columns.Add(buttonColumnDisponibilidad);
                        }

                        frm.CmbTipoServicio.ValueMember = "TipoServicionId";
                        frm.CmbTipoServicio.DisplayMember = "Descripcion";
                        frm.CmbTipoServicio.DataSource = listTipoServicios;                       
                    }

                    FuncionesPrincipales(frm);

                    break;
                case "Servicios":
                    frm.TCMain.SelectedIndex = 2;
                    frm.llbTitulo.Text = "Agregar Servicios a la Orden";

                    auxSubModulo = "Servicios";
                    auxAccion = "Buscar";

                    using (NeoCobranzaContext db = new NeoCobranzaContext())
                    {
                        //Tipos Servicios
                        List<TipoServicios> listTipoServicios = new List<TipoServicios>();

                        TipoServicios tipoServicios = new TipoServicios()
                        {
                            Descripcion = "Mostrar Todas",
                            Estado = "Activo",
                            TipoServicionId = 0
                        };

                        listTipoServicios.Add(tipoServicios);
                        List<TipoServicios> listBdTipo = db.TipoServicios.Where(s => s.Estado == "Activo").OrderByDescending(s => s.TipoServicionId).ToList();
                        listTipoServicios.AddRange(listBdTipo);

                        dynamicDataTableProductos = new DataTable();
                        frm.DgvProductos.Columns.Clear();

                        if (dynamicDataTableProductos.Columns.Count < 3)
                        {
                            dynamicDataTableProductos.Columns.Add("Id", typeof(string));
                            dynamicDataTableProductos.Columns.Add("Servicios", typeof(string));
                            dynamicDataTableProductos.Columns.Add("Cantidad", typeof(string));
                            dynamicDataTableProductos.Columns.Add("Precio Unitario (NIO)", typeof(string));
                            dynamicDataTableProductos.Columns.Add($"Precio Unitario $ ({Utilidades.Tasa})", typeof(string));

                            frm.DgvProductos.DataSource = dynamicDataTableProductos;

                            // Agregar una columna de botón
                            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                            buttonColumn.HeaderText = "...";
                            buttonColumn.Text = "Agregar a Venta";
                            buttonColumn.UseColumnTextForButtonValue = true;
                            frm.DgvProductos.Columns.Add(buttonColumn);

                            DataGridViewButtonColumn buttonColumnDisponibilidad = new DataGridViewButtonColumn();
                            buttonColumnDisponibilidad.HeaderText = "...";
                            buttonColumnDisponibilidad.Text = "Disponibilidad";
                            buttonColumnDisponibilidad.UseColumnTextForButtonValue = true;
                            frm.DgvProductos.Columns.Add(buttonColumnDisponibilidad);
                        }

                        frm.CmbTipoServicio.ValueMember = "TipoServicionId";
                        frm.CmbTipoServicio.DisplayMember = "Descripcion";
                        frm.CmbTipoServicio.DataSource = listTipoServicios;
                    }

                    FuncionesPrincipales(frm);
                    break;
                case "Pagar":
                    frm.TCMain.SelectedIndex = 3;
                    frm.llbTitulo.Text = "Formas de Pago";
                    break;
                case "Efectivo":
                    frm.TCMain.SelectedIndex = 4;
                    frm.llbTitulo.Text = "Pago en Efectivo";
                    frm.TxtTotalEfectivo.Text = frm.TxtTotalCordoba.Text;
                    frm.TxtPagadoEfectivo.Text = frm.TxtTotalPagado.Text;
                    frm.TxtFaltanteEfectivo.Text = (double.Parse(frm.TxtTotalEfectivo.Text) - double.Parse(frm.TxtTotalPagado.Text)).ToString();
                    frm.TxtCantidadAbonadaEfectivo.Text = "0";
                    frm.TxtDiferenciaEfectivo.Text="0";
                    break;
                case "Menu":
                    frm.TCMain.SelectedIndex = 0;
                    frm.llbTitulo.Text = "Crear Orden";
                    break;
                case "Lista":
                    frm.TCMain.SelectedIndex = 1;
                    frm.llbTitulo.Text = "Lista Ordenes";
                    break;
            }
        }

        public void FuncionesPrincipales(PnlVentas frm)
        {
            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                switch (auxSubModulo)
                {
                    case "Productos":

                        if(auxAccion == "Buscar")
                        {
                            if(frm.CmbTipoServicio == null || frm.CmbTipoServicio.Items.Count == 0)
                            {
                                return;
                            }

                            dynamicDataTableProductos.Rows.Clear();

                            if (frm.CmbTipoServicio.SelectedValue.ToString() == "0")
                            {
                                var serviciosProductos = db.ServiciosEstadares.Where(s => s.Estado == "Activo" && s.MontoVd != 0 && s.NombreEstandar.Contains(frm.TxtBuscarProductos.Texts) && s.ClasificacionProducto == 0).ToList();

                                foreach (var item in serviciosProductos)
                                {
                                    dynamicDataTableProductos.Rows.Add(item.IdEstandar, item.NombreEstandar, 0, item.MontoVd, Math.Round((double.Parse(item.MontoVd.ToString()) / double.Parse(Utilidades.Tasa)), 2).ToString());
                                }

                            }
                            else
                            {
                                TipoServicios objTipo = frm.CmbTipoServicio.SelectedItem as TipoServicios;
                                List<ServiciosEstadares> serviciosProductos = db.ServiciosEstadares.Where(s => s.ClasificacionTipo == objTipo.TipoServicionId && s.Estado == "Activo" && s.MontoVd != 0 && s.NombreEstandar.Contains(frm.TxtBuscarProductos.Texts) && s.ClasificacionProducto == 0).ToList();

                                foreach (var item in serviciosProductos)
                                {
                                    dynamicDataTableProductos.Rows.Add(item.IdEstandar, item.NombreEstandar, 0, item.MontoVd, Math.Round(( double.Parse(item.MontoVd.ToString()) / double.Parse(Utilidades.Tasa)),2).ToString());
                                }

                            }

                        }
                        break;

                    case "Servicios":
                        if (auxAccion == "Buscar")
                        {
                            if (frm.CmbTipoServicio == null || frm.CmbTipoServicio.Items.Count == 0)
                            {
                                return;
                            }

                            dynamicDataTableProductos.Rows.Clear();

                            if (frm.CmbTipoServicio.SelectedValue.ToString() == "0")
                            {
                                var serviciosProductos = db.ServiciosEstadares.Where(s => s.Estado == "Activo" && s.MontoVd != 0 && s.NombreEstandar.Contains(frm.TxtBuscarProductos.Texts) && s.ClasificacionProducto == 1).ToList();

                                foreach (var item in serviciosProductos)
                                {
                                    dynamicDataTableProductos.Rows.Add(item.IdEstandar, item.NombreEstandar, 0, item.MontoVd, Math.Round((double.Parse(item.MontoVd.ToString()) / double.Parse(Utilidades.Tasa)), 2).ToString());
                                }

                            }
                            else
                            {
                                TipoServicios objTipo = frm.CmbTipoServicio.SelectedItem as TipoServicios;
                                List<ServiciosEstadares> serviciosProductos = db.ServiciosEstadares.Where(s => s.ClasificacionTipo == objTipo.TipoServicionId && s.Estado == "Activo" && s.MontoVd != 0 && s.NombreEstandar.Contains(frm.TxtBuscarProductos.Texts) && s.ClasificacionProducto == 1).ToList();

                                foreach (var item in serviciosProductos)
                                {
                                    dynamicDataTableProductos.Rows.Add(item.IdEstandar, item.NombreEstandar, 0, item.MontoVd, Math.Round((double.Parse(item.MontoVd.ToString()) / double.Parse(Utilidades.Tasa)), 2).ToString());
                                }

                            }

                        }
                        break;
                }
            }
        }

        public void AgregarProductosOrden(PnlVentas frm, string idProd, string Cantidad,string opc)
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext()) 
            {
                if (idProd != "")
                {
                    ServiciosEstadares servicios = db.ServiciosEstadares.Where(s => s.IdEstandar == int.Parse(idProd)).FirstOrDefault();
                    bool existe = false;

                    if (dynamicDataTable.Rows.Count != 0)
                    {
                        for (int i = 0; i < dynamicDataTable.Rows.Count; i++)
                        {
                            DataRow item = dynamicDataTable.Rows[i];

                            if (item[0].ToString().Trim() == idProd)
                            {
                                existe = true;
                                if (opc == "Aumentar")
                                {
                                    item[2] = (int.Parse(item[2].ToString()) + int.Parse(Cantidad)).ToString();
                                    item[4] = double.Parse(item[4].ToString()) + (int.Parse(Cantidad) * servicios.MontoVd);
                                }
                                else
                                {
                                    int nuevaCantidad = int.Parse(item[2].ToString()) - int.Parse(Cantidad);
                                    double nuevoMonto = double.Parse(item[4].ToString()) - (int.Parse(Cantidad) * double.Parse(servicios.MontoVd.ToString()));

                                    if (nuevaCantidad > 0)
                                    {
                                        item[2] = nuevaCantidad.ToString();
                                        item[4] = nuevoMonto;
                                    }
                                    else
                                    {
                                        dynamicDataTable.Rows.RemoveAt(i);
                                        i--; // Decrementamos el índice para ajustarnos a la eliminación del elemento
                                    }
                                }
                            }
                        }

                        if (!existe)
                        {
                            dynamicDataTable.Rows.Add(servicios.IdEstandar, servicios.NombreEstandar, Cantidad, servicios.MontoVd, int.Parse(Cantidad) * servicios.MontoVd);
                        }
                    }
                    else
                    {
                        dynamicDataTable.Rows.Add(servicios.IdEstandar, servicios.NombreEstandar, Cantidad, servicios.MontoVd, int.Parse(Cantidad) * servicios.MontoVd);
                    }
                }
              
                //Calculos de totales
                double SubTotal = 0;
                foreach (DataRow row in dynamicDataTable.Rows)
                {
                    SubTotal = SubTotal + double.Parse(row[4].ToString());
                }

                double tasaIVA = 15; 

                double montoIVA = SubTotal - (SubTotal / (1 + (tasaIVA / 100)));

                frm.TxtSubTotal.Text = (Math.Round(SubTotal - montoIVA,2)).ToString();
                frm.TxtIVA.Text = Math.Round(montoIVA,2).ToString();
                frm.TxtTotalCordoba.Text = Math.Round(SubTotal,2).ToString();
                frm.TxtTotalDolar.Text = (Math.Round(SubTotal/double.Parse(Utilidades.Tasa),2)).ToString();

                if(frm.ChkRetencionAlcaldia.Checked )
                {
                    double RetencionAlcaldia = Math.Round(double.Parse(frm.TxtSubTotal.Text.Trim()) * 0.01,2);
                    frm.TxtRetencionAlcaldia.Text = RetencionAlcaldia.ToString();
                    frm.TxtTotalCordoba.Text = (double.Parse(frm.TxtTotalCordoba.Text) - RetencionAlcaldia).ToString();
                    frm.TxtTotalDolar.Text = (Math.Round(double.Parse(frm.TxtTotalCordoba.Text) / double.Parse(Utilidades.Tasa), 2)).ToString();
                }

                if(frm.ChkRetencionDgi.Checked )
                {
                    double RetencionDgi = Math.Round(double.Parse(frm.TxtSubTotal.Text.Trim()) * 0.02,2);
                    frm.TxtRetencionDGI.Text = RetencionDgi.ToString();
                    frm.TxtTotalCordoba.Text = (double.Parse(frm.TxtTotalCordoba.Text) - RetencionDgi).ToString();
                    frm.TxtTotalDolar.Text = (Math.Round(double.Parse(frm.TxtTotalCordoba.Text) / double.Parse(Utilidades.Tasa), 2)).ToString();
                }

                if(frm.TxtTotalCordoba.Text.Trim() != "0") 
                { 
                  frm.BtnPagarOrden.Enabled = true;
                }
                else
                {
                  frm.BtnPagarOrden.Enabled = false;
                }
            }
        }
    }
}
