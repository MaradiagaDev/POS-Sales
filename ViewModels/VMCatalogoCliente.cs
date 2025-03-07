using DocumentFormat.OpenXml.Wordprocessing;
using iTextSharp.text.xml;
using Microsoft.EntityFrameworkCore;
using NeoCobranza.DataController;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.ViewModels
{
    internal class VMCatalogoCliente
    {

        DataTable dynamicDataTable = new DataTable();
        private DataUtilities dataUtilities = new DataUtilities();
        public string auxKeyUsuario;
        public string auxId;

        public int currentPage = 1;
        public int totalPages = 0;
        private const int pageSize = 40;
        private List<Clientes> allClientes = new List<Clientes>();

        public void InitModuloCatalogoClientes(PnlCatalogoClientes frm)
        {
            ConfigUI(frm, "Catalogo");
        }

        public void InitModuloModificarClientes(PanelModificarCliente frm, string key)
        {
            auxKeyUsuario = key != "Crear" ? "Modificar" : "Crear";
            frm.btnAgregar.Text = "Crear";
            frm.cmbDepartamento.SelectedIndex = 0;
            frm.cmbPais.SelectedIndex = 0;

            // Obtiene todos los registros de la tabla Sucursal
            DataTable dtResponseSucursales = dataUtilities.getRecordByColumn("SegmentacionCliente","SucursalId",Utilidades.SucursalId);

            // Filtra las filas donde el campo Estado sea "Activo"
            var filterRowSucursales = from row in dtResponseSucursales.AsEnumerable()
                                      where Convert.ToString(row.Field<string>("Estado")) == "Activo"
                                      select row;

            if (filterRowSucursales.Any())
            {
                // Crea un DataTable para los datos filtrados
                DataTable dataCmbSucursal = new DataTable();
                dataCmbSucursal = filterRowSucursales.CopyToDataTable();

                // Crea una nueva fila para "Mostrar Todo"
                DataRow newRow = dataCmbSucursal.NewRow();
                newRow["Clave"] = "0";
                newRow["Descripcion"] = "Sin Segmentación";

                // Inserta la nueva fila en la posición 0
                dataCmbSucursal.Rows.InsertAt(newRow, 0);

                // Configura el DataSource del combo box
                frm.CmbSegmentacion.ValueMember = "Clave";
                frm.CmbSegmentacion.DisplayMember = "Descripcion";
                frm.CmbSegmentacion.DataSource = dataCmbSucursal;

                frm.CmbSegmentacion.SelectedValue = "0";
            }


            if (key != "Crear")
            {
                frm.btnAgregar.Text = "Modificar";
                auxId = key;
                using (NeoCobranzaContext db = new NeoCobranzaContext())
                {
                    DataTable dtResponse = new DataTable();

                    dtResponse = dataUtilities.getRecordByPrimaryKey("Clientes", key);

                    if (dtResponse.Rows.Count > 0)
                    {
                        if (dtResponse.Rows[0]["SegmentacionId"] == DBNull.Value)
                        {
                            frm.CmbSegmentacion.SelectedValue = "0";
                        }
                        else
                        {
                            frm.CmbSegmentacion.SelectedValue = Convert.ToString(dtResponse.Rows[0]["SegmentacionId"]);
                        }

                        if (dtResponse.Rows[0]["Codigo"] == DBNull.Value)
                        {
                            frm.TxtCodigoUnico.Text = "";
                        }
                        else
                        {
                            frm.TxtCodigoUnico.Text = Convert.ToString(dtResponse.Rows[0]["Codigo"]);
                        }

                        frm.txtPrimerNombre.Text = Convert.ToString(dtResponse.Rows[0]["Pnombre"]);
                        frm.txtSegundoNombre.Text = Convert.ToString(dtResponse.Rows[0]["Snombre"]);
                        frm.txtPrimerApellido.Text = Convert.ToString(dtResponse.Rows[0]["Papellido"]);
                        frm.txtSegundoApellido.Text = Convert.ToString(dtResponse.Rows[0]["Sapellido"]);

                        frm.txtProfesion.Text = Convert.ToString(dtResponse.Rows[0]["Profesion"]);
                        frm.mtxtCedula.Text = Convert.ToString(dtResponse.Rows[0]["Cedula"]);
                        frm.mtxtCelular.Text = Convert.ToString(dtResponse.Rows[0]["Celular"]);
                        frm.mtxtTelefono.Text = Convert.ToString(dtResponse.Rows[0]["Telefono"]);
                        frm.TxtEmail.Text = Convert.ToString(dtResponse.Rows[0]["Email"]);
                        frm.cmbDepartamento.SelectedValue = Convert.ToString(dtResponse.Rows[0]["Departamento"]);
                        frm.cmbPais.SelectedValue = Convert.ToString(dtResponse.Rows[0]["Pais"]);
                        frm.txtObservacion.Text = Convert.ToString(dtResponse.Rows[0]["Observacion"]);
                        frm.txtDireccion.Text = Convert.ToString(dtResponse.Rows[0]["Direccion"]);

                        frm.dtpFechaNac.Value = Convert.ToDateTime(dtResponse.Rows[0]["FechaNac"]);
                        frm.TxtNoRuc.Text = Convert.ToString(dtResponse.Rows[0]["NoRuc"]);
                        frm.rbtnMasculino.Checked = Convert.ToString(dtResponse.Rows[0]["Sexo"]) == "Masculino" ? true : false;
                        frm.rbtnFemenino.Checked = Convert.ToString(dtResponse.Rows[0]["Sexo"]) == "Femenino" ? true : false;

                        frm.LblDynamicoCliente.Text = "Cliente a Modificar: " + Convert.ToString(dtResponse.Rows[0]["Pnombre"]) + " " +
                            Convert.ToString(dtResponse.Rows[0]["Snombre"]) + " " +
                            Convert.ToString(dtResponse.Rows[0]["Papellido"]) + " " + Convert.ToString(dtResponse.Rows[0]["Sapellido"]);
                    }
                }
            }
            else
            {
                frm.LblDynamicoCliente.Text = "Nuevo Cliente";
            }
        }

        public bool Validaciones(PanelModificarCliente frm)
        {
            if (frm.txtPrimerNombre.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe digitar el Primer Nombre.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (frm.txtPrimerApellido.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe digitar el Primer Apellido.", "Atención",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (frm.txtPrimerApellido.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe digitar el Primer Apellido.", "Atención",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (frm.mtxtCelular.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe digitar el Celular.", "Atención",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (frm.TxtNoRuc.Text.Trim().Length != 0 && frm.TxtNoRuc.Text.Trim().Length != 14)
            {
                MessageBox.Show("Si el cliente es natural puede dejar el espacio en blanco, pero al ser jurídico debe agregar los 14 dígitos exactos para que los campos de retenciones aparezcan en la pantalla de factura.", "Atención",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //Validacion de codigo Unico

            return true;

        }

        public void FuncionesCrearModificarCliente(PanelModificarCliente frm = null)
        {
            try
            {
                if (frm.TxtCodigoUnico.Text.Trim().Length > 0)
                {
                    string idCliente = "0";
                    if (!string.IsNullOrEmpty(auxId))
                    {
                        idCliente = auxId;
                    }


                    dataUtilities.SetParameter("@IdCliente", idCliente);
                    dataUtilities.SetParameter("@Codigo", frm.TxtCodigoUnico.Text.Trim());
                    DataTable dt = dataUtilities.ExecuteStoredProcedure("spVerificarCodigoCliente");

                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        MessageBox.Show("El código ya pertenece a otro cliente.", "Atención",
                                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                DateTime fechaSeleccionada = frm.dtpFechaNac.Value;
                int edad = DateTime.Today.Year - fechaSeleccionada.Year - (DateTime.Today < fechaSeleccionada.AddYears(DateTime.Today.Year - fechaSeleccionada.Year) ? 1 : 0);

                // Parámetros para creación o actualización
                dataUtilities.SetParameter("@IdCliente", string.IsNullOrEmpty(auxId) ? (object)DBNull.Value : int.Parse(auxId));
                dataUtilities.SetParameter("@PNombre", frm.txtPrimerNombre.Text.Trim());
                dataUtilities.SetParameter("@SNombre", frm.txtSegundoNombre.Text.Trim());
                dataUtilities.SetParameter("@PApellido", frm.txtPrimerApellido.Text.Trim());
                dataUtilities.SetParameter("@SAPellido", frm.txtSegundoApellido.Text.Trim());
                dataUtilities.SetParameter("@Estado", 1);
                dataUtilities.SetParameter("@Direccion", frm.txtDireccion.Text.Trim());
                dataUtilities.SetParameter("@Telefono", frm.mtxtTelefono.Text.Trim());
                dataUtilities.SetParameter("@Celular", frm.mtxtCelular.Text.Trim());
                dataUtilities.SetParameter("@Fax", "");
                dataUtilities.SetParameter("@Edad", edad);
                dataUtilities.SetParameter("@EstadoCivil", false? "Casado" : "Soltero");
                dataUtilities.SetParameter("@Profesion", frm.txtProfesion.Text.Trim());
                dataUtilities.SetParameter("@Sexo", frm.rbtnMasculino.Checked ? "Masculino" : "Femenino");
                dataUtilities.SetParameter("@Cedula", frm.mtxtCedula.Text.Trim());
                dataUtilities.SetParameter("@FechaNac", frm.dtpFechaNac.Value);
                dataUtilities.SetParameter("@Email", frm.TxtEmail.Text.Trim());
                dataUtilities.SetParameter("@Departamento", frm.cmbDepartamento.Text.Trim());
                dataUtilities.SetParameter("@Pais", frm.cmbPais.Text.Trim());
                dataUtilities.SetParameter("@Observacion", frm.txtObservacion.Text.Trim());
                dataUtilities.SetParameter("@NoRuc", frm.TxtNoRuc.Text.Trim());
                dataUtilities.SetParameter("@IdSucursal", Utilidades.SucursalId);
                dataUtilities.SetParameter("@SegmentacionId", frm.CmbSegmentacion.SelectedValue);
                dataUtilities.SetParameter("@Codigo", frm.TxtCodigoUnico.Text.Trim());

                MessageBox.Show(dataUtilities.ExecuteStoredProcedure("SP_CrearActualizarCliente").Rows[0][0].ToString(), "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConfigUI(frm.frmPnlCatalogoCliente, "Catalogo");
                frm.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message, "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!Validaciones(frm))
            {
                return;
            }

        }

        public void CambiarEstadoCliente(PnlCatalogoClientes frm, string id)
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                // Ejecutar el procedimiento almacenado para cambiar el estado del cliente
                var idCliente = int.Parse(id);

                dataUtilities.SetParameter("@IdCliente", idCliente);
                dataUtilities.ExecuteStoredProcedure("CambiarEstadoCliente");

                // Llamar la función para actualizar la vista después de cambiar el estado
                FuncionesPrincipales(frm, "Buscar");
            }
        }

        public void ConfigUI(PnlCatalogoClientes frm, string opc)
        {
            switch (opc)
            {
                case "Catalogo":

                    // Obtiene todos los registros de la tabla Sucursal
                    DataTable dtResponseSegmentacion = dataUtilities.getRecordByColumn("SegmentacionCliente", "SucursalId", Utilidades.SucursalId);

                    // Filtra las filas donde el campo Estado sea "Activo"
                    var filterRowSeg = from row in dtResponseSegmentacion.AsEnumerable()
                                              where Convert.ToString(row.Field<string>("Estado")) == "Activo"
                                              select row;

                    if (filterRowSeg.Any())
                    {
                        // Crea un DataTable para los datos filtrados
                        DataTable dataCmbSucursal = new DataTable();
                        dataCmbSucursal = filterRowSeg.CopyToDataTable();

                        // Crea una nueva fila para "Mostrar Todo"
                        DataRow newRow = dataCmbSucursal.NewRow();
                        newRow["Clave"] = "0";
                        newRow["Descripcion"] = "Sin Segmentación";

                        // Inserta la nueva fila en la posición 0
                        dataCmbSucursal.Rows.InsertAt(newRow, 0);

                        // Configura el DataSource del combo box
                        frm.CmbSegmentacion.ValueMember = "Clave";
                        frm.CmbSegmentacion.DisplayMember = "Descripcion";
                        frm.CmbSegmentacion.DataSource = dataCmbSucursal;

                        frm.CmbSegmentacion.SelectedValue = "0";
                    }

                    // Obtiene todos los registros de la tabla Sucursal
                    DataTable dtResponseSucursales = dataUtilities.GetAllRecords("Sucursal");

                    // Filtra las filas donde el campo Estado sea "Activo"
                    var filterRowSucursales = from row in dtResponseSucursales.AsEnumerable()
                                              where Convert.ToString(row.Field<string>("Estado")) == "Activo"
                                              select row;

                    if (filterRowSucursales.Any())
                    {
                        // Crea un DataTable para los datos filtrados
                        DataTable dataCmbSucursal = new DataTable();
                        dataCmbSucursal = filterRowSucursales.CopyToDataTable();

                        // Crea una nueva fila para "Mostrar Todo"
                        DataRow newRow = dataCmbSucursal.NewRow();
                        newRow["IdSucursal"] = "0";
                        newRow["NombreSucursal"] = "Mostrar Todo";
                        newRow["Estado"] = "Activo"; // Puedes mantener el estado "Activo" para esta fila

                        // Inserta la nueva fila en la posición 0
                        dataCmbSucursal.Rows.InsertAt(newRow, 0);

                        // Configura el DataSource del combo box
                        frm.CmbSucursal.ValueMember = "IdSucursal";
                        frm.CmbSucursal.DisplayMember = "NombreSucursal";
                        frm.CmbSucursal.DataSource = dataCmbSucursal;

                        frm.CmbSucursal.SelectedValue = Utilidades.SucursalId;
                    }

                    frm.dgvCatalogoClientes.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#ECECEC");

                    //Datatable
                    dynamicDataTable.Columns.Clear();
                    dynamicDataTable.Rows.Clear();
                    frm.dgvCatalogoClientes.Columns.Clear();

                    //Agregar Boton de Cambiar de estado
                    DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

                    BtnCambioEstado.Text = "Estado de Cuenta";
                    BtnCambioEstado.Name = "...";
                    BtnCambioEstado.UseColumnTextForButtonValue = true;
                    BtnCambioEstado.DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
                    frm.dgvCatalogoClientes.Columns.Add(BtnCambioEstado);

                    // Definir las columnas
                    dynamicDataTable.Columns.Add("Id", typeof(string));
                    dynamicDataTable.Columns.Add("Nombre del Cliente", typeof(string));
                    dynamicDataTable.Columns.Add("RUC", typeof(string));
                    dynamicDataTable.Columns.Add("Código", typeof(string));
                    dynamicDataTable.Columns.Add("Segmentación", typeof(string));
                    dynamicDataTable.Columns.Add("Cédula", typeof(string));
                    dynamicDataTable.Columns.Add("Estado", typeof(string));
                    dynamicDataTable.Columns.Add("Dirección", typeof(string));
                    dynamicDataTable.Columns.Add("Pais", typeof(string));
                    dynamicDataTable.Columns.Add("Departamento", typeof(string));
                    dynamicDataTable.Columns.Add("Fecha de Nacimiento", typeof(string));
                    dynamicDataTable.Columns.Add("Telefono Convencional", typeof(string));
                    dynamicDataTable.Columns.Add("Celular", typeof(string));
                    dynamicDataTable.Columns.Add("Edad", typeof(string));
                    dynamicDataTable.Columns.Add("Profesión", typeof(string));
                    dynamicDataTable.Columns.Add("Sexo", typeof(string));

                    if (frm.CmbBuscarPor.Items.Count == 0)
                    {
                        frm.CmbBuscarPor.Items.Add("ID");
                        frm.CmbBuscarPor.Items.Add("Nombre");
                        frm.CmbBuscarPor.Items.Add("Cédula");
                    }

                    frm.CmbBuscarPor.SelectedIndex = 1;

                    FuncionesPrincipales(frm, "Buscar");
                    break;
            }
        }



        public void FuncionesPrincipales(PnlCatalogoClientes frm, string opc)
        {

            switch (opc)
            {
                case "Buscar":
                    dynamicDataTable.Rows.Clear();
                    frm.dgvCatalogoClientes.DataSource = "";

                    int pageNumber = 1;
                    int pageSize = 10;
                    int totalPages = 0;

                    var filtroPor = frm.CmbBuscarPor.SelectedIndex;
                    var filtroValor = frm.TxtFiltrar.Text.Trim();; // Asumiendo que el ID de la sucursal se captura desde un campo de texto en el formulario

                    string segmentacion = "0";

                    if (!string.IsNullOrEmpty(Convert.ToString(frm.CmbSegmentacion.SelectedValue)))
                    {
                        segmentacion = Convert.ToString(frm.CmbSegmentacion.SelectedValue);
                    }

                    string sucursal = "0";

                    if (!string.IsNullOrEmpty(Convert.ToString(frm.CmbSucursal.SelectedValue)))
                    {
                        sucursal = Convert.ToString(frm.CmbSucursal.SelectedValue);
                    }


                    dataUtilities.SetParameter("@FiltroPor", filtroPor);
                    dataUtilities.SetParameter("@FiltroValor", filtroValor);
                    dataUtilities.SetParameter("@IdSucursal", sucursal);
                    dataUtilities.SetParameter("@SegmentacionId", segmentacion);
                    dataUtilities.SetParameter("@PageNumber", pageNumber);
                    dataUtilities.SetParameter("@PageSize", pageSize);
                    
                    DataTable dtRespuesta = new DataTable();
                    dtRespuesta = dataUtilities.ExecuteStoredProcedure("sp_ObtenerClientesFiltrados");

                    // Para obtener el número total de páginas
                    totalPages = (int)Math.Ceiling((double)dtRespuesta.Rows.Count / pageSize);
                    UpdatePagination(frm); // Actualiza la paginación en el formulario

                    break;

            }
        }

        public void UpdatePagination(PnlCatalogoClientes frm)
        {
            string segmentacion = "0";

            if (!string.IsNullOrEmpty(Convert.ToString(frm.CmbSegmentacion.SelectedValue)))
            {
                segmentacion = Convert.ToString(frm.CmbSegmentacion.SelectedValue);
            }

            string sucursal = "0";

            if (!string.IsNullOrEmpty(Convert.ToString(frm.CmbSucursal.SelectedValue)))
            {
                sucursal = Convert.ToString(frm.CmbSucursal.SelectedValue);
            }

            var filtroPor = frm.CmbBuscarPor.SelectedIndex;
            var filtroValor = frm.TxtFiltrar.Text.Trim(); ; // Asumiendo que el ID de la sucursal se captura desde un campo de texto en el formulario

            dataUtilities.SetParameter("@FiltroPor", filtroPor);
            dataUtilities.SetParameter("@FiltroValor", filtroValor);
            dataUtilities.SetParameter("@IdSucursal", sucursal);
            dataUtilities.SetParameter("@SegmentacionId", segmentacion);
            dataUtilities.SetParameter("@PageNumber", currentPage);
            dataUtilities.SetParameter("@PageSize", pageSize);

            DataTable dtRespuesta = new DataTable();
            dtRespuesta = dataUtilities.ExecuteStoredProcedure("sp_ObtenerClientesFiltrados");

            foreach (DataRow item in dtRespuesta.Rows)
            {
                string idCliente = Convert.ToString(item["IdCliente"]);
                string nombreCliente = $"{Convert.ToString(item["Pnombre"])} {Convert.ToString(item["Snombre"])} {Convert.ToString(item["Papellido"])} {Convert.ToString(item["Sapellido"])}";
                string cedula = Convert.ToString(item["Cedula"]);
                string estado = Convert.ToString(item["Estado"]) == null || Convert.ToString(item["Estado"]) == "0" ? "Bloqueado" : "Activo";
                string direccion = Convert.ToString(item["Direccion"]) == null || Convert.ToString(item["Direccion"]).Trim() == "" ? "Desconocido" : Convert.ToString(item["Direccion"]);
                string pais = Convert.ToString(item["Pais"]) == null ? "Desconocido" : Convert.ToString(item["Pais"]);
                string departamento = Convert.ToString(item["Departamento"]) == null ? "Desconocido" : Convert.ToString(item["Departamento"]);
                string fechaNac = Convert.ToString(item["FechaNac"]);
                string telefono = Convert.ToString(item["Telefono"]) == null || Convert.ToString(item["Telefono"]).Trim() == "" || double.TryParse(Convert.ToString(item["Telefono"]).Trim(), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double valorNumericoTel) == false ? "Desconocido" : valorNumericoTel.ToString();
                string celular = Convert.ToString(item["Celular"]) == null || Convert.ToString(item["Celular"]).Trim() == "" || double.TryParse(Convert.ToString(item["Celular"]).Trim(), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double valorNumerico) == false ? "Desconocido" : valorNumerico.ToString();
                string edad = Convert.ToString(item["Edad"]) == "0" ? "Desconocido" : Convert.ToString(item["Edad"]);
                string profesion = Convert.ToString(item["Profesion"]) == null || Convert.ToString(item["Profesion"]).Trim() == "" ? "Desconocido" : Convert.ToString(item["Profesion"]);
               // string estadoCivil = Convert.ToString(item["EstadoCivil"]);
                string sexo = Convert.ToString(item["Sexo"]);
                string Ruc = item["NoRuc"] == DBNull.Value || Convert.ToString(item["NoRuc"]) == "" ? "" : Convert.ToString(item["NoRuc"]);
                string Codigo = item["Codigo"] == DBNull.Value || Convert.ToString(item["Codigo"]) == "" ? "" : Convert.ToString(item["Codigo"]);
                string descripcion = item["SegmentacionId"] == DBNull.Value || Convert.ToString(item["SegmentacionId"]) == "0" ? "Sin Segmentar" : Convert.ToString(item["Descripcion"]);

                dynamicDataTable.Rows.Add(idCliente, nombreCliente,Ruc,Codigo,descripcion, cedula, estado, direccion, pais, departamento,
                                          fechaNac, telefono, celular, edad, profesion, sexo);
            }

            frm.dgvCatalogoClientes.DataSource = dynamicDataTable;
            frm.dgvCatalogoClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Actualizar la interfaz de usuario con la página actual y el total de páginas
            totalPages = (int)Math.Ceiling((double)dtRespuesta.Rows.Count / pageSize); // Si no se obtiene el total de páginas desde la consulta, lo calculamos aquí
            frm.TxtPaginaNo.Text = currentPage.ToString();
            frm.TxtPaginaDe.Text = totalPages.ToString();
        }

    }
}

