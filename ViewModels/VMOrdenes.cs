using NeoCobranza.Clases;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles;
using NeoCobranza.Paneles_Venta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.SqlServer;
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
        public DataTable dynamicDataTableOrdenes = new DataTable();
        public string auxSubModulo;
        public string auxAccion;

        //Nuevos
        public int OrdenAux = 0;
        public string MesaAux = "-";

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

                        frm.TCMain.SelectedIndex = 0;

                        frm.ChkAutomatico.Checked = true;
                        frm.TxtCodigoProducto.Focus();


                        frm.ChkRetencionAlcaldia.Enabled = true;
                        frm.ChkRetencionDgi.Enabled = true;

                        frm.LblEstadoOrden.Text = "Orden Abierta";
                        frm.LblFechaGeneracion.Text = DateTime.Now.ToString();

                        frm.LblProcesoPago.Text = "Sin Pagos";

                        frm.BtnPagarOrden.Enabled = false;

                        frm.ChkRetencionDgi.Visible = false;
                        frm.ChkRetencionAlcaldia.Visible = false;

                        if (dynamicDataTable.Columns.Count == 0)
                        {
                            dynamicDataTable.Columns.Add("Id Detalle", typeof(string));
                            dynamicDataTable.Columns.Add("Codigo", typeof(string));
                            dynamicDataTable.Columns.Add("Id Producto", typeof(string));
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

                            frm.DgvItemsOrden.DataSource = dynamicDataTable;
                            frm.DgvItemsOrden.Columns.Add(buttonColumnAdd);
                            frm.DgvItemsOrden.Columns.Add(buttonColumnDelete);
                            frm.DgvItemsOrden.Columns.Add(buttonColumnDeleteAll);

                        }

                        ModelsCobranza.Usuario usuario = db.Usuario.Where(s => s.IdUsuarios.ToString() == Utilidades.IdUsuario).FirstOrDefault();
                        frm.LblIdVendedor.Text = usuario.IdUsuarios.ToString();
                        frm.LblNombreVendedor.Text = usuario.PrimerNombre + " " + usuario.PrimerApellido;

                        auxSubModulo = "Orden";
                        auxAccion = "Crear";

                        //Agregar al Cliente Mostrador
                        Clientes cliente = db.Clientes.Where(c => c.IdCliente == 1).FirstOrDefault();
                        if (cliente != null)
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

                        Ordenes orden = new Ordenes();

                        //Crear la Orden
                        ModelsCobranza.ConfigFacturacion configFacturacion = db.ConfigFacturacion.Where(s => s.SucursalId == int.Parse(Utilidades.SucursalId)).FirstOrDefault();

                        if (configFacturacion != null)
                        {
                            if (OrdenAux == 0)
                            {
                                orden = new Ordenes()
                                {
                                    SucursalId = int.Parse(Utilidades.SucursalId),
                                    UsuarioId = int.Parse(Utilidades.IdUsuario),
                                    NoFactura = configFacturacion.ConsecutivoFactura,
                                    Serie = configFacturacion.Serie,
                                    SalaMesa = MesaAux,
                                    TotalOrden = 0,
                                    Descuento = 0,
                                    Iva = 0,
                                    RetencionAlcaldia = 0,
                                    RetencionDgi = 0,
                                    SubTotal = 0,
                                    Pagado = 0,
                                    RestantePago = 0,
                                    OrdenProceso = "Orden Abierta",
                                    PagoProceso = "Sin Pagos",
                                    MotivoCancelacion = "",
                                    FechaRealizacion = DateTime.Now,
                                    CambioDolar = decimal.Parse(Utilidades.Tasa),
                                    ClienteId = cliente == null ? 1 : cliente.IdCliente,
                                    CorteCaja = false,
                                    NotaOrden = ""
                                };

                                db.Add(orden);
                                db.SaveChanges();

                                OrdenAux = orden.OrdenId;

                                var ordenesDetalles = db.OrdenDetalle.Where(s => s.OrdenId == orden.OrdenId).ToList();

                                foreach (var item in ordenesDetalles)
                                {
                                    ServiciosEstadares servicios = db.ServiciosEstadares.Where(s => s.IdEstandar == item.ProductoId).FirstOrDefault();
                                    string codigo = servicios.Codigo == null ? string.Empty : servicios.Codigo;

                                    dynamicDataTable.Rows.Add(item.OrdenDetalleId, codigo, servicios.IdEstandar, servicios.NombreEstandar, item.Cantidad, servicios.MontoVd, item.Subtotal);
                                }
                            }
                            else
                            {
                                //Orden abierta
                                orden = db.Ordenes.Where(s => s.OrdenId == OrdenAux).FirstOrDefault();

                                if (orden.Pagado > 0)
                                {

                                    frm.ChkRetencionAlcaldia.Enabled = false;
                                    frm.ChkRetencionDgi.Enabled = false;
                                }

                                Clientes clienteOrden = db.Clientes.Where(s => s.IdCliente == orden.ClienteId).FirstOrDefault();
                                if (clienteOrden.NoRuc != null && clienteOrden.NoRuc.Length == 14)
                                {
                                    frm.ChkRetencionAlcaldia.Visible = true;
                                    frm.ChkRetencionDgi.Visible = true;
                                }
                                else
                                {
                                    frm.ChkRetencionAlcaldia.Visible = false;
                                    frm.ChkRetencionDgi.Visible = false;
                                }

                                frm.LblNombreClientes.Text = clienteOrden.Pnombre + " " + clienteOrden.Snombre + " " + clienteOrden.Papellido + " " + clienteOrden.Sapellido;
                                frm.lblEstadoCliente.Text = "Cliente Seleccionado";
                                frm.lblEstadoCliente.ForeColor = Color.Green;
                                frm.LblIdClientes.Text = clienteOrden.IdCliente.ToString();

                                if (orden.RetencionDgi != 0)
                                {
                                    frm.ChkRetencionDgi.Checked = true;
                                }
                                else
                                {
                                    frm.ChkRetencionDgi.Checked = false;
                                }

                                if (orden.RetencionAlcaldia != 0)
                                {
                                    frm.ChkRetencionAlcaldia.Checked = true;
                                }
                                else
                                {
                                    frm.ChkRetencionAlcaldia.Checked = false;
                                }

                                var ordenesDetalles = db.OrdenDetalle.Where(s => s.OrdenId == orden.OrdenId).ToList();

                                if (ordenesDetalles.Any())
                                {
                                    frm.BtnPagarOrden.Enabled = true;
                                }
                                else
                                {
                                    frm.BtnPagarOrden.Enabled = false;
                                }

                                dynamicDataTable.Rows.Clear();

                                foreach (var item in ordenesDetalles)
                                {
                                    ServiciosEstadares servicios = db.ServiciosEstadares.Where(s => s.IdEstandar == item.ProductoId).FirstOrDefault();
                                    string codigo = servicios.Codigo == null ? string.Empty : servicios.Codigo;

                                    dynamicDataTable.Rows.Add(item.OrdenDetalleId, codigo, servicios.IdEstandar, servicios.NombreEstandar, item.Cantidad, servicios.MontoVd, item.Subtotal);
                                }
                            }
                        }

                        frm.LblNoOrden.Text = orden.OrdenId.ToString();
                        frm.LblEstadoOrden.Text = orden.OrdenProceso.ToString();
                        frm.LblFechaGeneracion.Text = orden.FechaRealizacion.ToString();
                        frm.LblProcesoPago.Text = orden.PagoProceso.ToString();
                        frm.LblOrdenMesa.Text = orden.SalaMesa.ToString();

                        frm.TxtSubTotal.Text = orden.SubTotal.ToString();
                        frm.TxtIVA.Text = orden.Iva.ToString();
                        frm.TxtDescuento.Text = orden.Descuento.ToString();
                        frm.TxtRetencionDGI.Text = orden.RetencionDgi.ToString();
                        frm.TxtRetencionAlcaldia.Text = orden.RetencionAlcaldia.ToString();
                        frm.TxtTotalCordoba.Text = orden.TotalOrden.ToString();
                        decimal? decimalValue = orden.TotalOrden / orden.CambioDolar;
                        frm.TxtTotalDolar.Text = Math.Round(double.Parse(decimalValue.ToString()), 2).ToString();
                        frm.TxtTotalPagado.Text = orden.Pagado.ToString();

                        cliente = db.Clientes.Where(s => s.IdCliente == orden.ClienteId).FirstOrDefault();

                        if (cliente != null)
                        {
                            frm.LblNombreClientes.Text = cliente.Pnombre + " " + cliente.Snombre + " " + cliente.Papellido + " " + cliente.Sapellido;
                            frm.lblEstadoCliente.Text = "Cliente Seleccionado";
                            frm.lblEstadoCliente.ForeColor = Color.Green;
                            frm.LblIdClientes.Text = cliente.IdCliente.ToString();
                        }



                        var informativeMessageBox = new InformativeMessageBox($"Orden abierta Correctamente.", "Orden Creada", 3000); // 3000 milisegundos = 3 segundos
                        informativeMessageBox.Show();

                        break;

                    case "Salas":
                        frm.llbTitulo.Text = "Gestión de Salas";
                        frm.TCMain.SelectedIndex = 7;

                        var salas = db.Salas.Where(s => s.SucursalId == int.Parse(Utilidades.SucursalId)).ToList();

                        int botonTop = 2;

                        foreach (var s in salas)
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
                            botonSala.Font = new Font("Century Gothic", 15, FontStyle.Regular);
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
                    case "Listas":
                        ConfigUI(frm, "Lista");
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

                        using (NeoCobranzaContext db = new NeoCobranzaContext())
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

                                Ordenes orden = db.Ordenes.Where(s => s.SucursalId == sala.SucursalId && s.OrdenProceso == "Orden Abierta" && s.SalaMesa == $"{sala.NombreSala}-{i.ToString()}").FirstOrDefault();
                                if (orden != null)
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

                                botonSala.Click += (sender, e) => MesaClick($"{sala.NombreSala}-{mesaIndex.ToString()}", orden, frm);

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

        private void MesaClick(string MesaSala, Ordenes orden, PnlVentas frm)
        {
            MesaAux = MesaSala;
            if (orden != null)
            {
                OrdenAux = orden.OrdenId;
            }
            else
            {
                OrdenAux = 0;
            }

            InitModuloOrdenes(frm, "OrdenRapida", "");
        }

        public class FormaPagoClass
        {
            public string value { get; set; }
            public string desc { get; set; }
        }

        public void ConfigUI(PnlVentas frm, string opc)
        {
            frm.TxtCodigoProducto.Focus();
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
                    frm.TxtDiferenciaEfectivo.Text = "0";
                    break;
                case "Credito":
                    frm.TCMain.SelectedIndex = 5;
                    frm.llbTitulo.Text = "Pago con Tarjeta";
                    frm.TxtTotalOrdenCredito.Text = frm.TxtTotalCordoba.Text;
                    frm.TxtTotalPagadoCredito.Text = frm.TxtTotalPagado.Text;
                    frm.TxtFaltanteCredito.Text = (double.Parse(frm.TxtTotalOrdenCredito.Text) - double.Parse(frm.TxtTotalPagadoCredito.Text)).ToString();
                    frm.TxtCantidadAbonadaCredito.Text = "0";

                    using (NeoCobranzaContext db = new NeoCobranzaContext())
                    {
                        var Bancos = db.Bancos.Where(s => s.Estado == "Activo").ToList();
                        frm.CmbBanco.ValueMember = "BancoId";
                        frm.CmbBanco.DisplayMember = "Banco";
                        frm.CmbBanco.DataSource = Bancos;
                    }

                    break;
                case "Cheque":
                    frm.TCMain.SelectedIndex = 6;
                    frm.llbTitulo.Text = "Pago con Minuta o Checke";
                    frm.TxtTotalCheque.Text = frm.TxtTotalCordoba.Text;
                    frm.TxtPagadoCheque.Text = frm.TxtTotalPagado.Text;
                    frm.TxtFaltanteCheque.Text = (double.Parse(frm.TxtTotalCheque.Text) - double.Parse(frm.TxtPagadoCheque.Text)).ToString();
                    frm.TxtCantidadAbonadaCheque.Text = "0";

                    using (NeoCobranzaContext db = new NeoCobranzaContext())
                    {
                        var Bancos = db.Bancos.Where(s => s.Estado == "Activo").ToList();
                        frm.CmbBancoCheque.ValueMember = "BancoId";
                        frm.CmbBancoCheque.DisplayMember = "Banco";
                        frm.CmbBancoCheque.DataSource = Bancos;
                    }

                    List<FormaPagoClass> lista = new List<FormaPagoClass>();

                    FormaPagoClass formaUno = new FormaPagoClass()
                    {
                        value = "1",
                        desc = "Minuta"
                    };

                    FormaPagoClass formaDos = new FormaPagoClass()
                    {
                        value = "2",
                        desc = "Cheque"
                    };

                    lista.Add(formaUno);
                    lista.Add(formaDos);

                    frm.CmbTipoPago.ValueMember = "value";
                    frm.CmbTipoPago.DisplayMember = "desc";
                    frm.CmbTipoPago.DataSource = lista;


                    break;
                case "Menu":
                    frm.TCMain.SelectedIndex = 0;
                    frm.llbTitulo.Text = "Crear Orden";
                    frm.TxtCodigoProducto.Focus();
                    break;
                case "Lista":
                    frm.TCMain.SelectedIndex = 1;
                    frm.llbTitulo.Text = "Lista Ordenes";
                    auxSubModulo = "Lista";
                    auxAccion = "Buscar";



                    if (frm.dgvCatalogoOrdenes.Columns.Count == 0)
                    {
                        dynamicDataTableOrdenes.Columns.Add("No Orden", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Cliente Id", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Cliente", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Fecha", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Estado Orden", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Estado Pago", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Total", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Pagado", typeof(string));

                        DataGridViewButtonColumn buttonColumnSeleccionar = new DataGridViewButtonColumn();
                        buttonColumnSeleccionar.HeaderText = "...";
                        buttonColumnSeleccionar.Text = " Abrir Orden ";
                        buttonColumnSeleccionar.UseColumnTextForButtonValue = true;

                        frm.dgvCatalogoOrdenes.Columns.Add(buttonColumnSeleccionar);

                        DataGridViewButtonColumn buttonColumnCancelar = new DataGridViewButtonColumn();
                        buttonColumnCancelar.HeaderText = "...";
                        buttonColumnCancelar.Text = " Cancelar ";
                        buttonColumnCancelar.UseColumnTextForButtonValue = true;

                        frm.dgvCatalogoOrdenes.Columns.Add(buttonColumnCancelar);
                        frm.dgvCatalogoOrdenes.DataSource = dynamicDataTableOrdenes;
                    }
                    FuncionesPrincipales(frm);
                    break;
            }
        }



        public void FuncionesPrincipales(PnlVentas frm)
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                switch (auxSubModulo)
                {
                    case "Lista":

                        // Limpiar la tabla antes de cargar nuevos datos
                        dynamicDataTableOrdenes.Rows.Clear();

                        // Obtener el valor de SucursalId una vez para evitar múltiples conversiones de cadena a entero
                        int sucursalId = int.Parse(Utilidades.SucursalId);

                        // Consulta optimizada a la base de datos para obtener las órdenes que pueden ser traducidas a SQL
                        var ordenesQuery = db.Ordenes
                            .Where(s => s.SalaMesa.Length == 1 &&
                                        s.SucursalId == sucursalId &&
                                        s.OrdenProceso == "Orden Abierta")
                            .OrderByDescending(s => s.OrdenId);

                        // Obtener las órdenes que coinciden con el texto de filtrado utilizando LINQ to Objects
                        var ordenes = ordenesQuery.AsEnumerable()
                            .Where(s => s.OrdenId.ToString().Contains(frm.TxtFiltrar.Texts))
                            .ToList();

                        // Llenar la tabla con los resultados de la consulta
                        foreach (var orden in ordenes)
                        {
                            // Obtener el cliente correspondiente a la orden actual
                            Clientes cliente = db.Clientes.FirstOrDefault(c => c.IdCliente == orden.ClienteId);

                            // Agregar la fila a la tabla
                            dynamicDataTableOrdenes.Rows.Add(orden.OrdenId,
                                                             orden.ClienteId,
                                                             cliente != null ? $"{cliente.Pnombre} {cliente.Papellido}" : "Cliente no encontrado",
                                                             orden.FechaRealizacion,
                                                             orden.OrdenProceso,
                                                             orden.PagoProceso,
                                                             orden.TotalOrden,
                                                             orden.Pagado);
                        }


                        break;
                    case "Productos":

                        if (auxAccion == "Buscar")
                        {

                            Almacenes almacen = db.Almacenes.Where(s => s.SucursalId == int.Parse(Utilidades.SucursalId) && s.EsMostrador == true).FirstOrDefault();
                            List<RelAlmacenProducto> listaProds = db.RelAlmacenProducto.Where(s => s.AlmacenId == almacen.AlmacenId).ToList();
                            if (frm.CmbTipoServicio == null || frm.CmbTipoServicio.Items.Count == 0)
                            {
                                return;
                            }

                            dynamicDataTableProductos.Rows.Clear();

                            if (frm.CmbTipoServicio.SelectedValue.ToString() == "0")
                            {
                                var serviciosProductos = db.ServiciosEstadares.Where(s => s.Estado == "Activo" && s.MontoVd != 0 && s.NombreEstandar.Contains(frm.TxtBuscarProductos.Texts) && s.ClasificacionProducto == 0).ToList();

                                foreach (var item in serviciosProductos)
                                {
                                    int? cantidad = listaProds.Where(s => s.ProductoId == item.IdEstandar).FirstOrDefault().Cantidad;
                                    dynamicDataTableProductos.Rows.Add(item.IdEstandar, item.NombreEstandar, cantidad, item.MontoVd, Math.Round((double.Parse(item.MontoVd.ToString()) / double.Parse(Utilidades.Tasa)), 2).ToString());
                                }

                            }
                            else
                            {
                                TipoServicios objTipo = frm.CmbTipoServicio.SelectedItem as TipoServicios;
                                List<ServiciosEstadares> serviciosProductos = db.ServiciosEstadares.Where(s => s.ClasificacionTipo == objTipo.TipoServicionId && s.Estado == "Activo" && s.MontoVd != 0 && s.NombreEstandar.Contains(frm.TxtBuscarProductos.Texts) && s.ClasificacionProducto == 0).ToList();

                                foreach (var item in serviciosProductos)
                                {
                                    int? cantidad = listaProds.Where(s => s.ProductoId == item.IdEstandar).FirstOrDefault().Cantidad;
                                    dynamicDataTableProductos.Rows.Add(item.IdEstandar, item.NombreEstandar, cantidad, item.MontoVd, Math.Round((double.Parse(item.MontoVd.ToString()) / double.Parse(Utilidades.Tasa)), 2).ToString());
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

        public void AgregarProductosOrden(PnlVentas frm, string idProd, string Cantidad, string opc)
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

                            if (item[2].ToString().Trim() == idProd)
                            {
                                existe = true;
                                if (opc == "Aumentar")
                                {
                                    item[4] = (int.Parse(item[4].ToString()) + int.Parse(Cantidad)).ToString();
                                    item[6] = double.Parse(item[6].ToString()) + (int.Parse(Cantidad) * servicios.MontoVd);

                                    OrdenDetalle orden = db.OrdenDetalle.Where(s => s.OrdenDetalleId == int.Parse(item[0].ToString())).FirstOrDefault();

                                    orden.Cantidad = int.Parse(item[4].ToString()) + int.Parse(Cantidad);
                                    orden.Subtotal = decimal.Parse((double.Parse(item[6].ToString()) + (int.Parse(Cantidad) * servicios.MontoVd)).ToString());

                                    db.Update(orden);
                                    db.SaveChanges();

                                    //llamar a la funcion
                                    ActualizarTotales(int.Parse(frm.LblNoOrden.Text), orden.OrdenDetalleId, int.Parse(idProd), int.Parse(Cantidad), "Agregar");

                                    db.SaveChanges(true);
                                }
                                else
                                {
                                    int nuevaCantidad = int.Parse(item[4].ToString()) - int.Parse(Cantidad);
                                    double nuevoMonto = double.Parse(item[6].ToString()) - (int.Parse(Cantidad) * double.Parse(servicios.MontoVd.ToString()));

                                    OrdenDetalle orden = db.OrdenDetalle.Where(s => s.OrdenDetalleId == int.Parse(item[0].ToString())).FirstOrDefault();

                                    orden.Cantidad = int.Parse(item[4].ToString()) - int.Parse(Cantidad);
                                    orden.Subtotal = decimal.Parse((double.Parse(item[6].ToString()) + (int.Parse(Cantidad) * servicios.MontoVd)).ToString());

                                    db.Update(orden);
                                    db.SaveChanges();

                                    if (nuevaCantidad > 0)
                                    {
                                        item[4] = nuevaCantidad.ToString();
                                        item[6] = nuevoMonto;

                                        db.Update(orden);
                                        db.SaveChanges();

                                       //Llamar a la funcion
                                    }
                                    else
                                    {
                                        OrdenDetalle ordenRemover = db.OrdenDetalle.Where(s => s.OrdenDetalleId == int.Parse(item[0].ToString())).FirstOrDefault();
                                        db.Remove(ordenRemover);

                                       //LLamar a la funcion

                                        dynamicDataTable.Rows.RemoveAt(i);
                                        i--; 
                                    }

                                    ActualizarTotales(int.Parse(frm.LblNoOrden.Text), orden.OrdenDetalleId, int.Parse(idProd), int.Parse(Cantidad), "Quitar");
                                }
                            }
                        }

                        if (!existe)
                        {
                            OrdenDetalle ordenDetalle = new OrdenDetalle()
                            {
                                OrdenId = int.Parse(frm.LblNoOrden.Text),
                                ProductoId = servicios.IdEstandar,
                                Cantidad = int.Parse(Cantidad),
                                PrecioUnitario = decimal.Parse(servicios.MontoVd.ToString()),
                                Subtotal = decimal.Parse((int.Parse(Cantidad) * servicios.MontoVd).ToString())
                            };

                            db.Add(ordenDetalle);
                            db.SaveChanges();

                            //Llamar a la funcion
                            ActualizarTotales(int.Parse(frm.LblNoOrden.Text), ordenDetalle.OrdenDetalleId, int.Parse(idProd), int.Parse(Cantidad), "Agregar");

                            string codigo = servicios.Codigo == null ? string.Empty : servicios.Codigo;
                            dynamicDataTable.Rows.Add(ordenDetalle.OrdenDetalleId, codigo, servicios.IdEstandar, servicios.NombreEstandar, Cantidad, servicios.MontoVd, int.Parse(Cantidad) * servicios.MontoVd);
                        }
                    }
                    else
                    {
                        OrdenDetalle ordenDetalle = new OrdenDetalle()
                        {
                            OrdenId = int.Parse(frm.LblNoOrden.Text),
                            ProductoId = servicios.IdEstandar,
                            Cantidad = int.Parse(Cantidad),
                            PrecioUnitario = decimal.Parse(servicios.MontoVd.ToString()),
                            Subtotal = decimal.Parse((int.Parse(Cantidad) * servicios.MontoVd).ToString())
                        };

                        ActualizarTotales(int.Parse(frm.LblNoOrden.Text), ordenDetalle.OrdenDetalleId, int.Parse(idProd), int.Parse(Cantidad), "Agregar");

                        string codigo = servicios.Codigo == null ? string.Empty : servicios.Codigo;
                        dynamicDataTable.Rows.Add(ordenDetalle.OrdenDetalleId, codigo, servicios.IdEstandar, servicios.NombreEstandar, Cantidad, servicios.MontoVd, int.Parse(Cantidad) * servicios.MontoVd);
                    }
                }

                //Calculos de totales
                double SubTotal = 0;
                foreach (DataRow row in dynamicDataTable.Rows)
                {
                    SubTotal = SubTotal + double.Parse(row[6].ToString());
                }

                double tasaIVA = 15;

                double montoIVA = SubTotal - (SubTotal / (1 + (tasaIVA / 100)));

                frm.TxtSubTotal.Text = (Math.Round(SubTotal - montoIVA, 2)).ToString();
                frm.TxtIVA.Text = Math.Round(montoIVA, 2).ToString();
                frm.TxtTotalCordoba.Text = Math.Round(SubTotal, 2).ToString();
                frm.TxtTotalDolar.Text = (Math.Round(SubTotal / double.Parse(Utilidades.Tasa), 2)).ToString();

                if (frm.ChkRetencionAlcaldia.Checked)
                {
                    double RetencionAlcaldia = Math.Round(double.Parse(frm.TxtSubTotal.Text.Trim()) * 0.01, 2);
                    frm.TxtRetencionAlcaldia.Text = RetencionAlcaldia.ToString();
                    frm.TxtTotalCordoba.Text = (double.Parse(frm.TxtTotalCordoba.Text) - RetencionAlcaldia).ToString();
                    frm.TxtTotalDolar.Text = (Math.Round(double.Parse(frm.TxtTotalCordoba.Text) / double.Parse(Utilidades.Tasa), 2)).ToString();
                }
                else
                {
                    frm.TxtRetencionAlcaldia.Text = "0";
                }

                if (frm.ChkRetencionDgi.Checked)
                {
                    double RetencionDgi = Math.Round(double.Parse(frm.TxtSubTotal.Text.Trim()) * 0.02, 2);
                    frm.TxtRetencionDGI.Text = RetencionDgi.ToString();
                    frm.TxtTotalCordoba.Text = (double.Parse(frm.TxtTotalCordoba.Text) - RetencionDgi).ToString();
                    frm.TxtTotalDolar.Text = (Math.Round(double.Parse(frm.TxtTotalCordoba.Text) / double.Parse(Utilidades.Tasa), 2)).ToString();
                }
                else
                {
                    frm.TxtRetencionDGI.Text = "0";
                }

                Ordenes ordenes = db.Ordenes.Where(s => s.OrdenId == int.Parse(frm.LblNoOrden.Text)).FirstOrDefault();

                ordenes.SubTotal = decimal.Parse(frm.TxtSubTotal.Text);
                ordenes.Iva = decimal.Parse(frm.TxtIVA.Text);
                ordenes.Descuento = decimal.Parse(frm.TxtDescuento.Text);
                ordenes.RetencionAlcaldia = decimal.Parse(frm.TxtRetencionAlcaldia.Text);
                ordenes.RetencionDgi = decimal.Parse(frm.TxtRetencionDGI.Text);
                ordenes.TotalOrden = decimal.Parse(frm.TxtTotalCordoba.Text);

                db.Update(ordenes);
                db.SaveChanges();

                if (frm.TxtTotalCordoba.Text.Trim() != "0")
                {
                    frm.BtnPagarOrden.Enabled = true;
                }
                else
                {
                    frm.BtnPagarOrden.Enabled = false;
                }
            }
        }

        public void ActualizarTotales(int idOrden,int idOrdenDetalle, int idProducto,int cantidad,string accion)
        {
            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                Almacenes almacen = db.Almacenes.Where(s => s.SucursalId == int.Parse(Utilidades.SucursalId) && s.EsMostrador == true).FirstOrDefault();
                Inventario inventario = db.Inventario.Where(s => s.ProductoId == idProducto).FirstOrDefault();
                RelAlmacenProducto relAlmacenProducto = db.RelAlmacenProducto.Where(s => s.ProductoId == idProducto
                && s.AlmacenId == almacen.AlmacenId).FirstOrDefault();
                ServiciosEstadares producto = db.ServiciosEstadares.Where(s => s.IdEstandar == idProducto).FirstOrDefault();
                Kardex kardexUltimo = db.Kardex.Where(s => s.ProductoId == idProducto
                        && s.AlmacenId == almacen.AlmacenId ).OrderByDescending(s => s.MovimientoId).FirstOrDefault();

                switch (accion)
                {
                    case "Agregar":
                        //QUITAR DEL INVENTARIO  BIEN
                        inventario.Cantidad -= cantidad;
                        db.Update(inventario);

                        //QUITAR DEL RELINVENTARIO BIEN
                        relAlmacenProducto.Cantidad -= cantidad;
                        db.Update(relAlmacenProducto);

                        //LOTES BIEN
                        LotesProducto lotelista = new LotesProducto();
                        List<LotesProducto> lotesDisponibles = new List<LotesProducto>();

                        if (producto.ManejoInventario.Trim() == "PEPS")
                        {
                            lotesDisponibles = db.LotesProducto.Where(s => s.ProductoId == producto.IdEstandar &&
                           s.AlmacenId == almacen.AlmacenId && s.CantidadRestante > 0).OrderBy(s => s.FechaCreacion).ToList();
                        }
                        else if (producto.ManejoInventario.Trim() == "UEPS")
                        {
                            lotesDisponibles = db.LotesProducto.Where(s => s.ProductoId == producto.IdEstandar &&
                           s.AlmacenId == almacen.AlmacenId && s.CantidadRestante > 0).OrderByDescending(s => s.FechaCreacion).ToList();
                        }
                        else if (producto.ManejoInventario.Trim() == "PCPS" && producto.Expira == "Expira")
                        {
                            lotesDisponibles = db.LotesProducto.Where(s => s.ProductoId == producto.IdEstandar &&
                           s.AlmacenId == almacen.AlmacenId && s.CantidadRestante > 0).OrderBy(s => s.FechaExpiracion).ToList();
                        }
                        else
                        {
                            lotesDisponibles = db.LotesProducto.Where(s => s.ProductoId == producto.IdEstandar &&
                           s.AlmacenId == almacen.AlmacenId && s.CantidadRestante > 0).OrderBy(s => s.FechaCreacion).ToList();
                        }

                        int cantidadRestante = cantidad;

                        foreach (var item in lotesDisponibles)
                        {
                            if (cantidadRestante > 0)
                            {
                                OrdenDetalleLote ordenDetalleLote = db.OrdenDetalleLote.Where(s => s.LoteId  == item.LoteId && s.RelOrdenDetalleLote == idOrdenDetalle).FirstOrDefault();

                                if (ordenDetalleLote == null)
                                {
                                    ordenDetalleLote = new OrdenDetalleLote()
                                    {
                                        LoteId = item.LoteId,
                                        OrdenDetalleId = idOrdenDetalle
                                    };
                                }

                                if (item.CantidadRestante >= cantidadRestante)
                                {
                                    item.CantidadRestante -= cantidadRestante;
                                    ordenDetalleLote.Cantidad += cantidadRestante;
                                    cantidadRestante = 0;
                                    db.Update(item);
                                    db.SaveChanges();
                                }
                                else
                                {
                                    cantidadRestante -= int.Parse(item.CantidadRestante.ToString());
                                    ordenDetalleLote.Cantidad += cantidadRestante;
                                    item.CantidadRestante = 0;
                                    db.Update(item);
                                    db.SaveChanges();
                                   
                                }

                                db.Update(ordenDetalleLote); db.SaveChanges();
                                db.SaveChanges();
                            }
                        }

                        break;

                    case "Quitar":
                        // AGREGAR AL INVENTARIO
                        inventario.Cantidad += cantidad;
                        db.Update(inventario);

                        // AGREGAR AL RELINVENTARIO
                        relAlmacenProducto.Cantidad += cantidad;
                        db.Update(relAlmacenProducto);

                        // LOTES
                        LotesProducto lotelistaQuitar = new LotesProducto();
                        List<LotesProducto> lotesAsignados = new List<LotesProducto>();

                        // Obtenemos los lotes usados en la orden detalle
                        List<OrdenDetalleLote> ordenDetalleLotes = db.OrdenDetalleLote.Where(s => s.OrdenDetalleId == idOrdenDetalle).ToList();

                        int cantidadRestanteQuitar = cantidad;

                        foreach (var detalleLote in ordenDetalleLotes)
                        {
                            if (cantidadRestanteQuitar > 0)
                            {
                                var lote = db.LotesProducto.Where(s => s.LoteId == detalleLote.LoteId).FirstOrDefault();

                                if (lote != null)
                                {
                                    if (detalleLote.Cantidad <= cantidadRestanteQuitar)
                                    {
                                        lote.CantidadRestante += detalleLote.Cantidad;
                                        cantidadRestanteQuitar -= (int)detalleLote.Cantidad;
                                        detalleLote.Cantidad = 0;
                                    }
                                    else
                                    {
                                        lote.CantidadRestante += cantidadRestanteQuitar;
                                        detalleLote.Cantidad -= cantidadRestanteQuitar;
                                        cantidadRestanteQuitar = 0;
                                    }

                                    db.Update(lote);
                                    db.Update(detalleLote);
                                    db.SaveChanges();
                                }
                            }
                        }

                        break;
                }

                db.SaveChanges();
            }
        }

    }
}
