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
        DataUtilities dataUtilities = new DataUtilities();

        public DataTable dynamicDataTable = new DataTable();
        public DataTable dynamicDataTableProductos = new DataTable();
        public DataTable dynamicDataTableOrdenes = new DataTable();

        public string auxSubModulo;
        public string auxAccion;

        public string auxUsuarioId = "";
        public string auxClienteId = "0";

        //Nuevos
        public decimal OrdenAux = 0;
        public string MesaAux = "-";

        public void InitModuloOrdenes(PnlVentas frm, string opc, string key)
        {

            frm.TCMain.Appearance = TabAppearance.FlatButtons;
            frm.TCMain.SizeMode = TabSizeMode.Fixed;
            frm.TCMain.ItemSize = new System.Drawing.Size(1, 1);

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

                        frm.DgvItemsOrden.Columns[0].Visible = false;
                        frm.DgvItemsOrden.Columns[2].Visible = false;
                    }
                    //Generales
                    auxSubModulo = "Orden";
                    auxAccion = "Crear";

                    //Cliente
                    frm.LblNombreClientes.Text = "CLIENTE MOSTRADOR";
                    auxClienteId = "0";

                    //agregar el empleado
                    DataTable dtResponseUsuario = dataUtilities.getRecordByPrimaryKey("Usuario", Utilidades.IdUsuario);
                    DataTable dtResponseEmpleado = dataUtilities.getRecordByPrimaryKey("Empleado", Convert.ToString(dtResponseUsuario.Rows[0]["IdEmpleado"]));

                    frm.LblNombreVendedor.Text = Convert.ToString(dtResponseEmpleado.Rows[0]["Nombre"]) + " "
                        + Convert.ToString(dtResponseEmpleado.Rows[0]["Apellido"]);

                    //CREAR ORDEN
                    //OBTENER LA CONFIGURACION DE FACTURACION
                    DataTable dtConfigFacturacion = dataUtilities.getRecordByColumn("ConfigFacturacion", "SucursalId", Utilidades.SucursalId);

                    if (dtConfigFacturacion.Rows.Count == 0)
                    {
                        MessageBox.Show("Debe agregar una configuración de facturación para poder realizar ordenes.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        frm.Close();
                    }

                    if (OrdenAux == 0)
                    {
                        if (MesaAux == "-") {
                            frm.LblOrdenMesa.Visible = false;
                            frm.LblTituloSala.Visible = false;
                        }

                        //Actualizar la configuración de facturacion

                        decimal NoFactura = Convert.ToDecimal(dtConfigFacturacion.Rows[0]["ConsecutivoFactura"]) + 1;
                        decimal NoOrden = Convert.ToDecimal(dtConfigFacturacion.Rows[0]["ConsecutivoOrden"]) + 1;

                        dataUtilities.SetColumns("ConsecutivoFactura", NoFactura);
                        dataUtilities.SetColumns("ConsecutivoOrden", NoOrden);

                        dataUtilities.UpdateRecordByPrimaryKey(
                            "ConfigFacturacion",
                            Convert.ToString(dtConfigFacturacion.Rows[0]["ConfigFacturacionId"]));

                        //Insertar la orden
                        dataUtilities.SetColumns("SucursalId", Utilidades.SucursalId);
                        dataUtilities.SetColumns("UsuarioId", Utilidades.Usuario);
                        dataUtilities.SetColumns("ClienteId", auxClienteId);
                        dataUtilities.SetColumns("NoFactura", NoFactura);
                        dataUtilities.SetColumns("OrdenId", NoOrden);
                        dataUtilities.SetColumns("Serie", Convert.ToString(dtConfigFacturacion.Rows[0]["Serie"]));
                        dataUtilities.SetColumns("SalaMesa", MesaAux);
                        dataUtilities.SetColumns("TotalOrden", 0);
                        dataUtilities.SetColumns("Descuento", 0);
                        dataUtilities.SetColumns("Iva", 0);
                        dataUtilities.SetColumns("RetencionDgi", 0);
                        dataUtilities.SetColumns("RetencionAlcaldia", 0);
                        dataUtilities.SetColumns("SubTotal", 0);
                        dataUtilities.SetColumns("OrdenProceso", "Orden Abierta");
                        dataUtilities.SetColumns("PagoProceso", "Sin Pagos");
                        dataUtilities.SetColumns("MotivoCancelacion", "");
                        dataUtilities.SetColumns("FechaRealizacion", DateTime.Now);
                        dataUtilities.SetColumns("CambioDolar", decimal.Parse(Utilidades.Tasa));
                        dataUtilities.SetColumns("CorteCaja", false);
                        dataUtilities.SetColumns("NotaOrden", "");
                        dataUtilities.SetColumns("Pagado", 0);
                        dataUtilities.SetColumns("RestantePago", 0);
                        dataUtilities.SetColumns("BitEsCredito", false);
                        dataUtilities.SetColumns("CantidadPagos", "");
                        dataUtilities.SetColumns("FrecuenciaPagos", "");
                        dataUtilities.SetColumns("MontoCredito", 0);
                        dataUtilities.SetColumns("FechaCredito", DateTime.Now);

                        dataUtilities.InsertRecord("Ordenes");

                        OrdenAux = NoOrden;

                        frm.LblNoOrden.Text = NoOrden.ToString();
                        frm.LblEstadoOrden.Text = "Orden Abierta";
                        frm.LblFechaGeneracion.Text = DateTime.Now.ToString();
                        frm.LblProcesoPago.Text = "Sin Pagos";
                        frm.LblOrdenMesa.Text = MesaAux;

                        frm.TxtSubTotal.Text = "0";
                        frm.TxtIVA.Text = "0";
                        frm.TxtDescuento.Text = "0";
                        frm.TxtRetencionDGI.Text = "0";
                        frm.TxtRetencionAlcaldia.Text = "0";
                        frm.TxtTotalCordoba.Text = "0";
                        frm.TxtTotalDolar.Text = "0";
                        frm.TxtTotalPagado.Text = "0";

                        //var informativeMessageBoxe = new InformativeMessageBox($"Orden creada correctamente.", "Orden Creada", 3000); // 3000 milisegundos = 3 segundos
                        //informativeMessageBoxe.Show();
                    }
                    else
                    {
                        //Orden abierta
                        //Consultar Orden
                        DataTable dtResponseOrden = dataUtilities.getRecordByPrimaryKey("Ordenes", OrdenAux);

                        DataRow orden = dtResponseOrden.Rows[0];

                        if (Convert.ToDecimal(orden["Pagado"]) > 0)
                        {

                            frm.ChkRetencionAlcaldia.Enabled = false;
                            frm.ChkRetencionDgi.Enabled = false;
                        }

                        DataTable dtResponseCliente = dataUtilities.getRecordByPrimaryKey("Clientes", Convert.ToDecimal(orden["ClienteId"]));

                        if (dtResponseCliente.Rows.Count > 0)
                        {
                            DataRow rowResponseCliente = dtResponseCliente.Rows[0];

                            if (Convert.ToString(rowResponseCliente["NoRuc"]).Trim().Length > 0)
                            {
                                frm.ChkRetencionAlcaldia.Visible = true;
                                frm.ChkRetencionDgi.Visible = true;
                            }
                            else
                            {
                                frm.ChkRetencionAlcaldia.Visible = false;
                                frm.ChkRetencionDgi.Visible = false;
                            }

                            frm.LblNombreClientes.Text =
                                Convert.ToString(rowResponseCliente["PNombre"]) + " " +
                                Convert.ToString(rowResponseCliente["SNombre"]) + " " +
                                Convert.ToString(rowResponseCliente["PApellido"]) + " " +
                                Convert.ToString(rowResponseCliente["SAPellido"]);
                        }
                        else
                        {
                            frm.LblNombreClientes.Text = "CLIENTE MOSTRADOR";
                            auxClienteId = "";
                        }

                        if (Convert.ToDecimal(orden["RetencionDgi"]) != 0)
                        {
                            frm.ChkRetencionDgi.Checked = true;
                        }
                        else
                        {
                            frm.ChkRetencionDgi.Checked = false;
                        }

                        if (Convert.ToBoolean(orden["BitEsCredito"]))
                        {
                            frm.lblCredito.Visible = true;
                        }
                        else
                        {
                            frm.lblCredito.Visible = false;
                        }
                        

                        frm.LblOrdenMesa.Visible = Convert.ToString(orden["SalaMesa"]) == "-" ? false : true;
                        frm.LblTituloSala.Visible = Convert.ToString(orden["SalaMesa"]) == "-" ? false : true;

                        if (Convert.ToDecimal(orden["RetencionAlcaldia"]) != 0)
                        {
                            frm.ChkRetencionAlcaldia.Checked = true;
                        }
                        else
                        {
                            frm.ChkRetencionAlcaldia.Checked = false;
                        }

                        dynamicDataTable.Rows.Clear();

                        DataTable dtDetalle = dataUtilities.getRecordByColumn("OrdenDetalle", "OrdenId", OrdenAux);

                        if (dtDetalle.Rows.Count > 0)
                        {
                            frm.BtnPagarOrden.Enabled = true;
                        }
                        else
                        {
                            frm.BtnPagarOrden.Enabled = false;
                        }

                        foreach (DataRow item in dtDetalle.Rows)
                        {
                            DataRow itemProducto = dataUtilities.getRecordByPrimaryKey("ProductosServicios", Convert.ToString(item["ProductoId"])).Rows[0];

                            dynamicDataTable.Rows.Add(
                                Convert.ToString(item["OrdenDetalleId"]),
                                Convert.ToString(itemProducto["Codigo"]),
                                Convert.ToString(itemProducto["ProductoId"]),
                                Convert.ToString(itemProducto["NombreProducto"]),
                                Convert.ToString(item["Cantidad"]),
                                Convert.ToString(itemProducto["Precio"]),
                                Convert.ToString(item["Subtotal"]));
                        }

                        frm.LblNoOrden.Text = OrdenAux.ToString();
                        frm.LblEstadoOrden.Text = Convert.ToString(orden["OrdenProceso"]);
                        frm.LblFechaGeneracion.Text = Convert.ToString(orden["FechaRealizacion"]);
                        frm.LblProcesoPago.Text = Convert.ToString(orden["PagoProceso"]);
                        frm.LblOrdenMesa.Text = MesaAux;

                        frm.TxtSubTotal.Text = Convert.ToString(orden["SubTotal"]);
                        frm.TxtIVA.Text = Convert.ToString(orden["Iva"]);
                        frm.TxtDescuento.Text = Convert.ToString(orden["Descuento"]);
                        frm.TxtRetencionDGI.Text = Convert.ToString(orden["RetencionDgi"]);
                        frm.TxtRetencionAlcaldia.Text = Convert.ToString(orden["RetencionAlcaldia"]);
                        frm.TxtTotalCordoba.Text = Convert.ToString(orden["TotalOrden"]);
                        frm.TxtTotalDolar.Text = Math.Round(Convert.ToDecimal(orden["TotalOrden"]) / Convert.ToDecimal(Utilidades.Tasa),2).ToString();
                        frm.TxtTotalPagado.Text = Convert.ToString(orden["Pagado"]);
                    }

                    //var informativeMessageBox = new InformativeMessageBox($"Orden abierta correctamente.", "Orden Abierta", 3000); // 3000 milisegundos = 3 segundos
                    //informativeMessageBox.Show();
                    break;
                case "Salas":
                    frm.llbTitulo.Text = "Gestión de Salas";
                    frm.TCMain.SelectedIndex = 7;

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
                        botonSala.Click += (sender, e) => SalaClick(Convert.ToInt32(s["SalaId"]), frm);

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
                case "ListaCredito":
                    ConfigUI(frm, "ListaCredito");
                    break;
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


                        DataTable dtSalas = dataUtilities.getRecordByPrimaryKey("Salas", SalaId);
                        DataRow itemSala = dtSalas.Rows[0];

                        frm.LblSalaTitulo.Text = Convert.ToString(itemSala["NombreSala"]);
                        frm.LblCantidadMesas.Text = Convert.ToString(itemSala["NoMesas"]);


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
                                botonSala.Click += (sender, e) => MesaClick($"{Convert.ToString(itemSala["NombreSala"])}-{mesaIndex.ToString()}", dataTable, frm);
                            }
                            else
                            {
                                DataTable dataTable = new DataTable();
                                botonSala.Click += (sender, e) => MesaClick($"{Convert.ToString(itemSala["NombreSala"])}-{mesaIndex.ToString()}", dataTable, frm);
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

        private void MesaClick(string MesaSala, DataTable orden, PnlVentas frm)
        {
            frm.LblOrdenMesa.Visible = true;
            frm.LblTituloSala.Visible = true;

            MesaAux = MesaSala;
            if (orden.Rows.Count > 0)
            {
                OrdenAux = Convert.ToDecimal(orden.Rows[0]["OrdenId"]);
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
                    //DATOS GENERALES DE LA PANTALLA
                    frm.TCMain.SelectedIndex = 2;
                    frm.llbTitulo.Text = "Agregar Producto a la Orden";

                    auxSubModulo = "Productos";
                    auxAccion = "Buscar";

                    if (dynamicDataTableProductos.Columns.Count < 3)
                    {
                        dynamicDataTableProductos.Columns.Add("Id", typeof(string));
                        dynamicDataTableProductos.Columns.Add("Producto", typeof(string));
                        dynamicDataTableProductos.Columns.Add("Precio Unitario (NIO)", typeof(string));
                        dynamicDataTableProductos.Columns.Add("Cantidad", typeof(string));
                        //dynamicDataTableProductos.Columns.Add($"Precio Unitario $ ({Utilidades.Tasa})", typeof(string));

                        frm.DgvProductos.DataSource = dynamicDataTableProductos;

                        frm.DgvProductos.Columns[0].Visible = false;

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

                    //Llenar los tipos de servicio

                    DataTable dtResponse = dataUtilities.GetAllRecords("Categorizacion");
                    var filterRow = from row in dtResponse.AsEnumerable() where Convert.ToString(row.Field<string>("Estado")) == "Activo" select row;

                    if (filterRow.Any())
                    {
                        DataTable dataCmbTipoServicio = new DataTable();
                        dataCmbTipoServicio = filterRow.CopyToDataTable();
                        DataRow newRow = dataCmbTipoServicio.NewRow();
                        newRow["CategorizacionId"] = "0";
                        newRow["Descripcion"] = "Mostrar Todo";
                        newRow["Estado"] = "Activo";

                        dataCmbTipoServicio.Rows.InsertAt(newRow, 0);

                        frm.CmbTipoServicio.ValueMember = "CategorizacionId";
                        frm.CmbTipoServicio.DisplayMember = "Descripcion";
                        frm.CmbTipoServicio.DataSource = dataCmbTipoServicio;
                    }

                    FuncionesPrincipales(frm);
                    break;
                case "Servicios":
                    //DATOS GENERALES DE LA PANTALLA
                    frm.TCMain.SelectedIndex = 2;
                    frm.llbTitulo.Text = "Agregar Servicios a la Orden";

                    auxSubModulo = "Servicios";
                    auxAccion = "Buscar";

                    if (dynamicDataTableProductos.Columns.Count < 3)
                    {
                        dynamicDataTableProductos.Columns.Add("Id", typeof(string));
                        dynamicDataTableProductos.Columns.Add("Servicios", typeof(string));
                        dynamicDataTableProductos.Columns.Add("Precio Unitario (NIO)", typeof(string));
                        dynamicDataTableProductos.Columns.Add("Cantidad", typeof(string));
                        //dynamicDataTableProductos.Columns.Add($"Precio Unitario $ ({Utilidades.Tasa})", typeof(string));

                        frm.DgvProductos.DataSource = dynamicDataTableProductos;

                        frm.DgvProductos.Columns[0].Visible = false;

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

                    //Llenar los tipos de servicio

                    DataTable dtResponseServicios = dataUtilities.GetAllRecords("Categorizacion");
                    var filterRowServicios = from row in dtResponseServicios.AsEnumerable() where Convert.ToString(row.Field<string>("Estado")) == "Activo" select row;

                    if (filterRowServicios.Any())
                    {
                        DataTable dataCmbTipoServicio = new DataTable();
                        dataCmbTipoServicio = filterRowServicios.CopyToDataTable();
                        DataRow newRow = dataCmbTipoServicio.NewRow();
                        newRow["CategorizacionId"] = "0";
                        newRow["Descripcion"] = "Mostrar Todo";
                        newRow["Estado"] = "Actio";

                        dataCmbTipoServicio.Rows.InsertAt(newRow, 0);

                        frm.CmbTipoServicio.ValueMember = "CategorizacionId";
                        frm.CmbTipoServicio.DisplayMember = "Descripcion";
                        frm.CmbTipoServicio.DataSource = dataCmbTipoServicio;
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

                    dynamicDataTableOrdenes.Columns.Clear();
                    dynamicDataTableOrdenes.Rows.Clear();
                    frm.dgvCatalogoOrdenes.Columns.Clear();
                    frm.dgvCatalogoOrdenes.DataSource = null;

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
                case "ListaCredito":
                    frm.TCMain.SelectedIndex = 1;
                    frm.llbTitulo.Text = "Cuentas Por Cobrar";
                    auxSubModulo = "ListaCredito";
                    auxAccion = "Buscar";

                    dynamicDataTableOrdenes.Columns.Clear();
                    dynamicDataTableOrdenes.Rows.Clear();
                    frm.dgvCatalogoOrdenes.Columns.Clear();

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
                        dynamicDataTableOrdenes.Columns.Add("Restante", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Fecha del Próximo Pago", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Cantidad de Pagos", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Frecuencia de Pago", typeof(string));
                        

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

            switch (auxSubModulo)
            {
                case "ListaCredito":
                    dynamicDataTableOrdenes.Rows.Clear();
                    dataUtilities.SetParameter("@idSucursal", Utilidades.SucursalId);
                    dataUtilities.SetParameter("@filtro", frm.TxtFiltrar.Texts);
                    DataTable dtResponseSucCredito = dataUtilities.ExecuteStoredProcedure("sp_ObtenerOrdenesCreditoPorSucursal");

                    // Llenar la tabla con los resultados de la consulta
                    foreach (DataRow orden in dtResponseSucCredito.Rows)
                    {
                        dynamicDataTableOrdenes.Rows.Add(Convert.ToString(orden["OrdenId"]),
                                                         Convert.ToString(orden["ClienteId"]),
                                                         Convert.ToString(orden["NombreCliente"]),
                                                        Convert.ToString(orden["FechaRealizacion"]),
                                                         Convert.ToString(orden["OrdenProceso"]),
                                                         Convert.ToString(orden["PagoProceso"]),
                                                         Convert.ToString(orden["TotalOrden"]),
                                                         Convert.ToString(orden["Pagado"]),
                                                         Convert.ToString(orden["RestantePago"]),
                                                         Convert.ToString(orden["FechaCredito"]),
                                                         Convert.ToString(orden["CantidadPagos"]),
                                                         Convert.ToString(orden["FrecuenciaPagos"]));
 
                    }
                    
                    break;
                case "Lista":
                    dynamicDataTableOrdenes.Rows.Clear();
                    dataUtilities.SetParameter("@idSucursal", Utilidades.SucursalId);
                    dataUtilities.SetParameter("@filtro", frm.TxtFiltrar.Texts);
                    DataTable dtResponseSuc = dataUtilities.ExecuteStoredProcedure("sp_ObtenerOrdenesPorSucursal");

                    // Llenar la tabla con los resultados de la consulta
                    foreach (DataRow orden in dtResponseSuc.Rows)
                    {
                        dynamicDataTableOrdenes.Rows.Add(Convert.ToString(orden["OrdenId"]),
                                                         Convert.ToString(orden["ClienteId"]),
                                                         Convert.ToString(orden["NombreCliente"]),
                                                        Convert.ToString(orden["FechaRealizacion"]),
                                                         Convert.ToString(orden["OrdenProceso"]),
                                                         Convert.ToString(orden["PagoProceso"]),
                                                         Convert.ToString(orden["TotalOrden"]),
                                                         Convert.ToString(orden["Pagado"]));
                    }

                    break;
                case "Productos":

                    if (auxAccion == "Buscar")
                    {
                        dynamicDataTableProductos.Rows.Clear();

                        //OBTENER EL ALMACEN MOSTRADOR
                        DataTable dtResponse = dataUtilities.GetAllRecords("Almacenes");
                        var filterRow =
                            from row in dtResponse.AsEnumerable()
                            where Convert.ToBoolean(row.Field<bool>("EsMostrador")) == true
                            && Convert.ToString(row.Field<string>("SucursalId")) == Utilidades.SucursalId
                            select row;

                        if (filterRow.Any())
                        {
                            DataTable dtAlmacenMostrador = filterRow.CopyToDataTable();

                            //REALIZAR EL FILTRADO
                            dataUtilities.SetParameter("@AlmacenId", Convert.ToString(dtAlmacenMostrador.Rows[0]["AlmacenId"]));
                            dataUtilities.SetParameter("@CategoriaId", frm.CmbTipoServicio.SelectedValue);
                            dataUtilities.SetParameter("@Filtro", frm.TxtFiltrar.Text);
                            DataTable dtResponseSp = dataUtilities.ExecuteStoredProcedure("sp_ObtenerCantidadProductoPorAlmacen");

                            foreach (DataRow row in dtResponseSp.Rows)
                            {
                                dynamicDataTableProductos.Rows.Add(Convert.ToString(row["ID"]),
                                    Convert.ToString(row["PRODUCTO"]), Convert.ToString(row[2]), Convert.ToString(row[3]));
                            }
                        }
                        else
                        {
                            MessageBox.Show("Debe agregar un almacén mostrador.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            frm.Close();
                        }
                    }
                    break;
                case "Servicios":
                    if (auxAccion == "Buscar")
                    {
                        dynamicDataTableProductos.Rows.Clear();

                        dataUtilities.SetParameter("@CategoriaId", frm.CmbTipoServicio.SelectedValue);
                        dataUtilities.SetParameter("@Filtro", frm.TxtFiltrar.Text);
                        DataTable dtResponseSp = dataUtilities.ExecuteStoredProcedure("sp_ObtenerServicios");

                        foreach (DataRow row in dtResponseSp.Rows)
                        {
                            dynamicDataTableProductos.Rows.Add(Convert.ToString(row["ID"]),
                                Convert.ToString(row["SERVICIO"]), Convert.ToString(row[2]));
                        }
                    }
                    break;

            }
        }

        public void AgregarProductosOrden(PnlVentas frm, string idProd, string Cantidad, string opc)
        {
            DataRow itemProductoAux = dataUtilities.getRecordByPrimaryKey("ProductosServicios", idProd).Rows[0];

            auxSubModulo = Convert.ToString(itemProductoAux["ClasificacionProducto"]);

            if (auxSubModulo == "Productos")
            {
                //OBTENER EL ALMACEN MOSTRADOR
                DataTable dtResponse = dataUtilities.GetAllRecords("Almacenes");
                var filterRow =
                    from row in dtResponse.AsEnumerable()
                    where Convert.ToBoolean(row.Field<bool>("EsMostrador")) == true
                    && Convert.ToString(row.Field<string>("SucursalId")) == Utilidades.SucursalId
                    select row;

                if (filterRow.Any())
                {
                    DataTable dtAlmacenMostrador = filterRow.CopyToDataTable();

                    //VERIFICAR EL STOCK
                    dataUtilities.SetParameter("@ProductId", idProd);
                    dataUtilities.SetParameter("@WarehouseId", dtAlmacenMostrador.Rows[0]["AlmacenId"]);
                    dataUtilities.SetParameter("@Quantity", Cantidad);

                    DataTable dtReponseStock = dataUtilities.ExecuteStoredProcedure("sp_CheckInventory");

                    if (Convert.ToString(dtReponseStock.Rows[0][0]) == "1")
                    {
                        if (MessageBox.Show("El inventario es insuficiente. ¿Deseas continuar?",
                                     "Advertencia",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            //realizar operacion

                            dataUtilities.SetParameter("@OrderId", OrdenAux);
                            dataUtilities.SetParameter("@ProductId", idProd);
                            dataUtilities.SetParameter("@Quantity", Cantidad);
                            dataUtilities.SetParameter("@Action", opc);
                            dataUtilities.SetParameter("@WarehouseId", dtAlmacenMostrador.Rows[0]["AlmacenId"]);
                            dataUtilities.SetParameter("@Discount", 0);
                            dataUtilities.SetParameter("@Total", 0);
                            dataUtilities.SetParameter("@Subtotal", 0);
                            dataUtilities.SetParameter("@IVA", 0);

                            DataTable dtResponseTotales = dataUtilities.ExecuteStoredProcedure("sp_ManageOrderDetail");
                      
                            if (opc == "Increase")
                            {
                                var informativeMessageBox = new InformativeMessageBox($"Producto Agregado Correctamente a la Orden.",
                                    "Producto Agregado", 3000);
                                informativeMessageBox.Show();
                            }
                            else
                            {
                                var informativeMessageBox = new InformativeMessageBox($"Producto Restado Correctamente de la Orden.",
                                   "Producto Restado", 3000);
                                informativeMessageBox.Show();
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        //realizar operacion

                        dataUtilities.SetParameter("@OrderId", OrdenAux);
                        dataUtilities.SetParameter("@ProductId", idProd);
                        dataUtilities.SetParameter("@Quantity", Cantidad);
                        dataUtilities.SetParameter("@Action", opc);
                        dataUtilities.SetParameter("@WarehouseId", dtAlmacenMostrador.Rows[0]["AlmacenId"]);
                        dataUtilities.SetParameter("@Discount", 0);
                        dataUtilities.SetParameter("@Total", 0);
                        dataUtilities.SetParameter("@Subtotal", 0);
                        dataUtilities.SetParameter("@IVA", 0);

                        DataTable dtResponseTotales = dataUtilities.ExecuteStoredProcedure("sp_ManageOrderDetail");

                        if (opc == "Increase")
                        {
                            var informativeMessageBox = new InformativeMessageBox($"Producto Agregado Correctamente a la Orden.",
                                "Producto Agregado", 3000);
                            informativeMessageBox.Show();
                        }
                        else
                        {
                            var informativeMessageBox = new InformativeMessageBox($"Producto Restado Correctamente de la Orden.",
                               "Producto Restado", 3000);
                            informativeMessageBox.Show();
                        }

                        FuncionesPrincipales(frm);
                    }
                }
            }
            else
            {
                //FALTAN LOS SERVICIOS
                dataUtilities.SetParameter("@OrderId", OrdenAux);
                dataUtilities.SetParameter("@ServiceId", idProd);
                dataUtilities.SetParameter("@Quantity", Cantidad);
                dataUtilities.SetParameter("@Action", opc);
                dataUtilities.SetParameter("@Discount", 0);
                dataUtilities.SetParameter("@Total", 0);
                dataUtilities.SetParameter("@Subtotal", 0);
                dataUtilities.SetParameter("@IVA", 0);

                DataTable dtResponseTotales = dataUtilities.ExecuteStoredProcedure("sp_ManageOrderServiceDetail");

                FuncionesPrincipales(frm);

                if(frm.TCMain.SelectedIndex != 0)
                {
                    //if (opc == "Increase")
                    //{
                    //    var informativeMessageBox = new InformativeMessageBox($"Servicio Agregado Correctamente a la Orden.",
                    //        "Servicio Agregado", 3000);
                    //    informativeMessageBox.Show();
                    //}
                    //else
                    //{
                    //    var informativeMessageBox = new InformativeMessageBox($"Servicio Restado Correctamente de la Orden.",
                    //       "Servicio Restado", 3000);
                    //    informativeMessageBox.Show();
                    //}
                }
            }

            //Actualizar el detalle
            dynamicDataTable.Rows.Clear();

            DataTable dtDetalle = dataUtilities.getRecordByColumn("OrdenDetalle", "OrdenId", OrdenAux);

            if (dtDetalle.Rows.Count > 0)
            {
                frm.BtnPagarOrden.Enabled = true;
            }
            else
            {
                frm.BtnPagarOrden.Enabled = false;
            }

            foreach (DataRow item in dtDetalle.Rows)
            {
                DataRow itemProducto = dataUtilities.getRecordByPrimaryKey("ProductosServicios", Convert.ToString(item["ProductoId"])).Rows[0];

                dynamicDataTable.Rows.Add(
                    Convert.ToString(item["OrdenDetalleId"]),
                    Convert.ToString(itemProducto["Codigo"]),
                    Convert.ToString(itemProducto["ProductoId"]),
                    Convert.ToString(itemProducto["NombreProducto"]),
                    Convert.ToString(item["Cantidad"]),
                    Convert.ToString(itemProducto["Precio"]),
                    Convert.ToString(item["Subtotal"]));
            }

            CalcularTotales(frm,frm.TxtDescuento.Text);
        }

        public void CalcularTotales(PnlVentas frm,string descuento)
        {
            DataTable dtResponse = dataUtilities.getRecordByColumn("ConfigFacturacion", "SucursalId", Utilidades.SucursalId);

            dataUtilities.SetParameter("@IdOrden",OrdenAux);
            dataUtilities.SetParameter("@AplicaRetencionDgi",frm.ChkRetencionDgi.Checked);
            dataUtilities.SetParameter("@AplicaRetencionAlcaldia",frm.ChkRetencionAlcaldia.Checked);
            dataUtilities.SetParameter("@DescuentoAdicional", descuento);
            dataUtilities.SetParameter("@CalcularIVA", Convert.ToBoolean(dtResponse.Rows[0]["RetieneIvaBit"]));

            dataUtilities.ExecuteStoredProcedure("Sp_CalcularTotalesOrden");

            DataTable dtResponseOrden = dataUtilities.getRecordByPrimaryKey("Ordenes", OrdenAux);
            DataRow orden = dtResponseOrden.Rows[0];

            frm.TxtSubTotal.Text = Convert.ToString(orden["SubTotal"]);
            frm.TxtIVA.Text = Convert.ToString(orden["Iva"]);
            frm.TxtDescuento.Text = Convert.ToString(orden["Descuento"]);
            frm.TxtRetencionDGI.Text = Convert.ToString(orden["RetencionDgi"]);
            frm.TxtRetencionAlcaldia.Text = Convert.ToString(orden["RetencionAlcaldia"]);
            frm.TxtTotalCordoba.Text = Convert.ToString(orden["TotalOrden"]);
            frm.TxtTotalDolar.Text = Math.Round(Convert.ToDecimal(orden["TotalOrden"]) / Convert.ToDecimal(Utilidades.Tasa),2).ToString();
            frm.TxtTotalPagado.Text = Convert.ToString(orden["Pagado"]);
        }
    }
}
