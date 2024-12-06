using NeoCobranza.Clases;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles
{
    public partial class ComprasInventario : Form
    {
        string auxOpc;
        int auxKey = 0;
        DataTable dataBuscar = new DataTable();
        DataTable dataProducto = new DataTable();
        DataTable dataCompra = new DataTable();
        DataUtilities dataUtilities = new DataUtilities();

        public ComprasInventario()
        {
            InitializeComponent();
        }

        private void ComprasInventario_Load(object sender, EventArgs e)
        {
            UIUtilities.PersonalizarDataGridView(DgvCatalogo);
            UIUtilities.PersonalizarDataGridViewPequeños(DgvCompra);
            UIUtilities.PersonalizarDataGridViewPequeños(DgvProductos);
            UIUtilities.EstablecerFondo(this);
            UIUtilities.ConfigurarBotonBuscar(BtnBuscar);
            UIUtilities.ConfigurarBotonBuscar(BtnBuscarProducto);
            UIUtilities.ConfigurarTextBoxBuscar(TxtFiltroProducto);
            UIUtilities.ConfigurarTituloPantalla(TbTitulo, PnlTitulo);
            UIUtilities.ConfigurarComboBox(CmbAlmacen);
            UIUtilities.ConfigurarComboBox(CmbSucursales);

            TCMain.Appearance = TabAppearance.FlatButtons;
            TCMain.SizeMode = TabSizeMode.Fixed;
            TCMain.ItemSize = new System.Drawing.Size(1, 1);

            auxOpc = "Buscar";
            ConfigUI();
        }

        private void ConfigUI()
        {
            switch (auxOpc)
            {
                case "Buscar":
                    TbTitulo.Text = "Buscar Compras";
                    auxKey = 0;
                    TCMain.SelectedIndex = 0;

                    if (dataBuscar.Columns.Count == 0)
                    {
                        //Agregar Boton de Cambiar de estado
                        DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

                        BtnCambioEstado.Text = "  Ver Compra  ";
                        BtnCambioEstado.Name = "...";
                        BtnCambioEstado.UseColumnTextForButtonValue = true;
                        BtnCambioEstado.DefaultCellStyle.ForeColor = Color.Blue;
                        DgvCatalogo.Columns.Add(BtnCambioEstado);

                        // Definir las columnas
                        dataBuscar.Columns.Add("Compra ID", typeof(string));
                        dataBuscar.Columns.Add("CostoTotal", typeof(string));
                        dataBuscar.Columns.Add("Descripción", typeof(string));
                        dataBuscar.Columns.Add("Almacén", typeof(string));
                        dataBuscar.Columns.Add("Sucursal", typeof(string));
                        dataBuscar.Columns.Add("Fecha Creación", typeof(string));
                        dataBuscar.Columns.Add("Usuario", typeof(string));

                        DgvCatalogo.DataSource = dataBuscar;
                    }

                    // Obtiene todos los registros de la tabla Sucursal
                    DataTable dtResponseSucursales = dataUtilities.GetAllRecords("Sucursal");

                    // Filtra las filas donde el campo Estado sea "Activo"
                    var filterRowSucursales = from row in dtResponseSucursales.AsEnumerable()
                                              where Convert.ToString(row.Field<string>("Estado")) == "Activo"
                                              select row;

                    if (filterRowSucursales.Any())
                    {
                        DataTable dataCmbSucursal = new DataTable();
                        dataCmbSucursal = filterRowSucursales.CopyToDataTable();

                        DataRow newRow = dataCmbSucursal.NewRow();
                        newRow["IdSucursal"] = "0";
                        newRow["NombreSucursal"] = "Mostrar Todo";
                        newRow["Estado"] = "Activo";

                        dataCmbSucursal.Rows.InsertAt(newRow, 0);

                        CmbSucursales.ValueMember = "IdSucursal";
                        CmbSucursales.DisplayMember = "NombreSucursal";
                        CmbSucursales.DataSource = dataCmbSucursal;
                    }


                    FuncionesPrincipales();

                    break;

                case "Crear":
                    TxtIdProveedor.Text = "-";
                    TxtNombreProveedor.Text = "-";

                    TxtFiltroProducto.Enabled = false;
                    BtnBuscarProducto.Enabled = false;
                    DgvProductos.Enabled = false;

                    LblCantidad.Enabled = false;
                    TxtCantidad.Enabled = false;
                    LblPrecioVenta.Enabled = false;
                    TxtCosto.Enabled = false;
                    BtnAgregarProducto.Enabled = false;

                    CmbAlmacen.Enabled = true;
                    BtnAgregarCompra.Enabled = true;
                    TxtDescripcion.Enabled = true;

                    TxtCantidad.Text = "0";
                    TxtCosto.Text = "0";

                    dataCompra.Rows.Clear();
                    dataProducto.Rows.Clear();

                    TxtFiltroProducto.Text = "";
                    TxtDescripcion.Text = "";
                    TxtMontoTotal.Text = "0 (NIO)";

                    TCMain.SelectedIndex = 1;
                    TbTitulo.Text = "Crear Compra";
                    BtnAgregarCompra.Text = "Crear";

                    //Categoria Almacen
                    DataTable dtResponseAlmacenes = dataUtilities.GetAllRecords("Almacenes");

                    var filterRowAlmacenes = from row in dtResponseAlmacenes.AsEnumerable()
                                             where Convert.ToString(row.Field<string>("Estatus")) == "Activo"
                                             select row;

                    if (filterRowAlmacenes.Any())
                    {
                        DataTable dataCmbSucursal = new DataTable();
                        dataCmbSucursal = filterRowAlmacenes.CopyToDataTable();

                        CmbAlmacen.ValueMember = "AlmacenId";
                        CmbAlmacen.DisplayMember = "NombreAlmacen";
                        CmbAlmacen.DataSource = dataCmbSucursal;
                    }
                    //Categoria Almacen

                    DgvProductos.DataSource = dataProducto;

                    if (dataCompra.Columns.Count == 0)
                    {
                        DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

                        BtnCambioEstado.Text = "Quitar";
                        BtnCambioEstado.Name = "...";
                        BtnCambioEstado.UseColumnTextForButtonValue = true;
                        BtnCambioEstado.DefaultCellStyle.ForeColor = Color.Blue;
                        DgvCompra.Columns.Add(BtnCambioEstado);

                        dataCompra.Columns.Add("Id Producto", typeof(string));
                        dataCompra.Columns.Add("Id Proveedor", typeof(string));
                        dataCompra.Columns.Add("Producto", typeof(string));
                        dataCompra.Columns.Add("Sub Total (NIO)", typeof(string));
                        dataCompra.Columns.Add("Cantidad/U", typeof(string));

                        DgvCompra.DataSource = dataCompra;
                    }

                    if (auxKey != 0)
                    {
                        //ModelsCobranza.ComprasInventario compra = db.ComprasInventario.Where(s => s.CompraId == auxKey).FirstOrDefault();

                        //if (compra != null)
                        //{
                        //    TxtMontoTotal.Text = $"{compra.CostoTotal} (NIO)";

                        //    CmbAlmacen.SelectedValue = compra.AlmacenId;
                        //    TxtDescripcion.Text = compra.Descripcion;

                        //    var rels = db.LotesProducto.Where(s => s.CompraId == auxKey).ToList();

                        //    foreach (var rel in rels)
                        //    {
                        //        dataCompra.Rows.Add(rel.ProductoId, rel.ProveedorId, rel.Producto, rel.Expira, rel.CostoU, rel.Cantidad, rel.SubTotal);
                        //    }
                        //}

                        CmbAlmacen.Enabled = false;
                        BtnAgregarCompra.Enabled = false;
                        TxtDescripcion.Enabled = false;
                    }

                    break;
            }
        }

        private void BuscarProducto()
        {
            dataProducto.Rows.Clear();

            if (dataProducto.Columns.Count == 0)
            {
                dataProducto.Columns.Add("Id", typeof(string));
                dataProducto.Columns.Add("Producto", typeof(string));
                dataProducto.Columns.Add("Cantidad en Almacén", typeof(string));
                dataProducto.Columns.Add("Precio (NIO)", typeof(string));
            }

            if (TxtIdProveedor.Text.Trim() != "-")
            {
                dataUtilities.SetParameter("@AlmacenId", CmbAlmacen.SelectedValue);
                dataUtilities.SetParameter("@CategoriaId", 0);
                dataUtilities.SetParameter("@ProveedorId", TxtIdProveedor.Text);
                dataUtilities.SetParameter("@Filtro", TxtFiltroProducto.Text);

                DataTable dtResponse = dataUtilities.ExecuteStoredProcedure("sp_ObtenerCantidadProductoPorAlmacenYProveedor");

                foreach (DataRow item in dtResponse.Rows)
                {
                    dataProducto.Rows.Add(
                        Convert.ToString(item["ProductoId"]),
                        Convert.ToString(item["NombreProducto"]),
                        Convert.ToString(item["cantidad"]),
                        Convert.ToString(item["Precio"])
                        );
                }
            }
        }

        private void FuncionesPrincipales()
        {
            if (auxOpc == "Buscar")
            {
                dataBuscar.Rows.Clear();

                dataUtilities.SetParameter("@IdSucursal", CmbSucursales.SelectedValue);
                DataTable dtResponse = dataUtilities.ExecuteStoredProcedure("sp_GetComprasPorSucursal");

                foreach (DataRow item in dtResponse.Rows)
                {
                    dataBuscar.Rows.Add(Convert.ToString(item["CompraId"]),
                        Convert.ToString(item["Total"]),
                        Convert.ToString(item["Descripcion"]),
                        Convert.ToString(item["NombreAlmacen"]),
                        Convert.ToString(item["NombreSucursal"]),
                        Convert.ToString(item["Fecha"]),
                        Convert.ToString(item["Usuario"])
                        );
                }

            }
            else if (auxOpc == "Crear")
            {
                //using (NeoCobranzaContext db = new NeoCobranzaContext())
                //{
                //    ModelsCobranza.ComprasInventario NuevaCompra = new ModelsCobranza.ComprasInventario();

                //    NuevaCompra.AlmacenId = int.Parse(CmbAlmacen.SelectedValue.ToString());
                //    NuevaCompra.UsuarioId = int.Parse(Utilidades.IdUsuario);
                //    NuevaCompra.SucursalId = Utilidades.SucursalId;
                //    NuevaCompra.CostoTotal = decimal.Parse(Regex.Replace(TxtMontoTotal.Text.Trim(), @"[^0-9,]", ""));
                //    NuevaCompra.Descripcion = TxtDescripcion.Text;
                //    NuevaCompra.FechaAlta = DateTime.Now;

                //    db.Add(NuevaCompra);
                //    db.SaveChanges();

                //    int i = 1;

                //    foreach (DataRow item in dataCompra.Rows)
                //    {
                //        ServiciosEstadares servicio = db.ServiciosEstadares.Where(s => s.IdEstandar.ToString() == item[0].ToString()).FirstOrDefault();

                //        DateTime dateNueva = new DateTime();

                //        if (DateTime.TryParseExact(item[3].ToString(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
                //        {
                //            dateNueva = parsedDate;
                //        }

                //        LotesProducto lote = new LotesProducto()
                //        {
                //            LoteId = $"L{NuevaCompra.CompraId.ToString()}-C{i.ToString()}",
                //            CompraId = NuevaCompra.CompraId,
                //            Producto = servicio.NombreEstandar,
                //            ProductoId = servicio.IdEstandar,
                //            Cantidad = int.Parse(item[5].ToString()),
                //            FechaCreacion = DateTime.Now,
                //            FechaExpiracion = dateNueva,
                //            CantidadRestante = int.Parse(item[5].ToString()),
                //            CostoU = decimal.Parse(item[4].ToString()),
                //            SubTotal = decimal.Parse(item[6].ToString()),
                //            ProveedorId = int.Parse(item[1].ToString()),
                //            AlmacenId = int.Parse(CmbAlmacen.SelectedValue.ToString())
                //        };

                //        db.Add(lote);
                //        db.SaveChanges();

                //        Kardex kardexUltimo = db.Kardex.Where(s => s.ProductoId == servicio.IdEstandar
                //        && s.AlmacenId == int.Parse(CmbAlmacen.SelectedValue.ToString())).OrderByDescending(s => s.MovimientoId).FirstOrDefault();

                //        if (kardexUltimo != null)
                //        {
                //            Kardex kardex = new Kardex()
                //            {
                //                Fecha = DateTime.Now.Date,
                //                Operacion = "Compra",
                //                UnidadesEntrada = int.Parse(item[5].ToString()),
                //                CostoUnitarioEntrada = decimal.Parse(item[4].ToString()),
                //                TotalEntrada = decimal.Parse(item[6].ToString()),
                //                AlmacenId = int.Parse(CmbAlmacen.SelectedValue.ToString()),
                //                ProductoId = servicio.IdEstandar,
                //                UnidadesSaldo = int.Parse(item[5].ToString()) + kardexUltimo.UnidadesSaldo,
                //                CostoUnitarioSaldo = (kardexUltimo.CostoTotalSaldo + Convert.ToDecimal(item[6])) / (int.Parse(item[5].ToString()) + kardexUltimo.UnidadesSaldo),
                //                CostoTotalSaldo = kardexUltimo.CostoTotalSaldo + decimal.Parse(item[6].ToString()),
                //                IdDocumento = NuevaCompra.CompraId.ToString(),
                //                Lote = lote.LoteId
                //            };

                //            db.Add(kardex);
                //            db.SaveChanges();
                //        }
                //        else
                //        {
                //            Kardex kardex = new Kardex()
                //            {
                //                Fecha = DateTime.Now.Date,
                //                Operacion = "Compra",
                //                UnidadesEntrada = int.Parse(item[5].ToString()),
                //                CostoUnitarioEntrada = decimal.Parse(item[4].ToString()),
                //                TotalEntrada = decimal.Parse(item[6].ToString()),
                //                AlmacenId = int.Parse(CmbAlmacen.SelectedValue.ToString()),
                //                ProductoId = servicio.IdEstandar,
                //                UnidadesSaldo = int.Parse(item[5].ToString()),
                //                CostoUnitarioSaldo = decimal.Parse(item[4].ToString()),
                //                CostoTotalSaldo = decimal.Parse(item[6].ToString()),
                //                IdDocumento = NuevaCompra.CompraId.ToString(),
                //                Lote = lote.LoteId
                //            };

                //            db.Add(kardex);
                //            db.SaveChanges();
                //        }



                //        RelAlmacenProducto relAlmacenProducto = db.RelAlmacenProducto.Where(s => s.AlmacenId == int.Parse(CmbAlmacen.SelectedValue.ToString()) && s.ProductoId == servicio.IdEstandar).FirstOrDefault();
                //        relAlmacenProducto.Cantidad += int.Parse(item[5].ToString());

                //        Almacenes almacenes = db.Almacenes.Where(s => s.AlmacenId == NuevaCompra.AlmacenId).FirstOrDefault();
                //        Sucursales sucursal = db.Sucursales.Where(s => s.SucursalId == almacenes.SucursalId).FirstOrDefault();

                //        Inventario inventario = db.Inventario.Where(s => s.ProductoId == servicio.IdEstandar).FirstOrDefault();
                //        inventario.Cantidad += int.Parse(item[5].ToString());

                //        db.Update(inventario);
                //        db.Update(relAlmacenProducto);
                //        db.SaveChanges();

                //        i++;
                //    }


                //}

                MessageBox.Show("Compra creada correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                auxOpc = "Buscar";
                ConfigUI();
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            auxOpc = "Buscar";
            FuncionesPrincipales();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            auxOpc = "Crear";
            ConfigUI();
        }

        private void BtnBuscarProducto_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }

        private void CmbTipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarProducto();
        }

      
        private void TxtCosto_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TxtCantidad_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void TxtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, el punto decimal y la tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true; // Esto indica que el evento ha sido manejado, por lo que el carácter no será mostrado en el TextBox
            }
        }

        private void BtnAgregarCompra_Click(object sender, EventArgs e)
        {
            if (CmbAlmacen.Items.Count == 0)
            {

                MessageBox.Show("Debe agregar almacenes para poder realizar una compra.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataCompra.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar items a la compra para finalizar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FuncionesPrincipales();
        }

        private void BtnSeleccionarProveeder_Click(object sender, EventArgs e)
        {
            if (auxKey == 0)
            {
                PnlSeleccionarProveedor frm = new PnlSeleccionarProveedor();
                AddOwnedForm(frm);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se puede seleccionar un proveedor en la modificación.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void TxtIdProveedor_TextChanged(object sender, EventArgs e)
        {
            if (TxtIdProveedor.Text.Trim() != "-")
            {
                TxtFiltroProducto.Enabled = true;
                BtnBuscarProducto.Enabled = true;
                DgvProductos.Enabled = true;

                LblCantidad.Enabled = true;
                TxtCantidad.Enabled = true;
                LblPrecioVenta.Enabled = true;
                TxtCosto.Enabled = true;
                BtnAgregarProducto.Enabled = true;

                BuscarProducto();
            }
        }

        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (DgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un Producto para agregar a la compra.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataRow item in dataCompra.Rows)
            {
                if (item[0].ToString() == DgvProductos.SelectedRows[0].Cells[0].Value.ToString() && item[1].ToString() == TxtIdProveedor.Text.Trim())
                {
                    MessageBox.Show("El producto ya fue agregado a la compra con el mismo proveedor. Solo puede agregar el mismo producto con diferente proveedor.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            dataCompra.Rows.Add(DgvProductos.SelectedRows[0].Cells[0].Value.ToString(),
                TxtIdProveedor.Text.Trim(),
                DgvProductos.SelectedRows[0].Cells[1].Value.ToString(),
                Convert.ToDecimal(TxtCosto.Text),
                TxtCantidad.Text
                );

            TxtCosto.Text = "0";
            TxtCantidad.Text = "0";

            ContadorTotal();
        }

        private void ContadorTotal()
        {
            double total = 0;

            foreach (DataRow item in dataCompra.Rows)
            {
                total += double.Parse(Convert.ToString(item[3]));
            }

            TxtMontoTotal.Text = total.ToString() + " (NIO)";
        }

        private void DgvCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (auxKey == 0)
                {
                    dataCompra.Rows.RemoveAt(e.RowIndex);
                }
                else
                {
                    MessageBox.Show("No puede modificar los items de la compra una vez ha sido creada.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ContadorTotal();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            auxOpc = "Buscar";
            ConfigUI();
        }

        private void DgvCatalogo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                object cellValue = DgvCatalogo.Rows[e.RowIndex].Cells[1].Value;

                auxKey = int.Parse(cellValue.ToString());
                auxOpc = "Crear";
                ConfigUI();
            }
        }

        private void TCMain_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
