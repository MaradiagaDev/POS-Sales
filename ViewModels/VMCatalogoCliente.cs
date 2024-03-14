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
        public string auxKeyUsuario;
        public string auxId;

        public void InitModuloCatalogoClientes(PnlCatalogoClientes frm)
        {
            ConfigUI(frm, "Catalogo");
        }

        public void InitModuloModificarClientes(PanelModificarCliente frm, string key)
        {
            auxKeyUsuario = key != "Crear" ? "Modificar" : "Crear";
            frm.btnAgregar.Text = "Crear";
            if (key != "Crear")
            {
                frm.btnAgregar.Text = "Modificar";
                auxId = key;
                using (NeoCobranzaContext db = new NeoCobranzaContext())
                {
                    Clientes cliente =  db.Clientes.Where(c => c.IdCliente == int.Parse(key)).FirstOrDefault();

                    if (cliente != null)
                    {
                        frm.txtPrimerNombre.Text = cliente.Pnombre;
                        frm.txtSegundoNombre.Text = cliente.Snombre;
                        frm.txtPrimerApellido.Text = cliente.Papellido;
                        frm.txtSegundoApellido.Text = cliente.Sapellido;

                        frm.txtProfesion.Text = cliente.Profesion;
                        frm.mtxtCedula.Text = cliente.Cedula;
                        frm.mtxtCelular.Text = cliente.Celular;
                        frm.mtxtTelefono.Text = cliente.Telefono;
                        frm.TxtEmail.Text = cliente.Email;
                        frm.cmbDepartamento.SelectedValue = cliente.Departamento;
                        frm.cmbPais.SelectedValue = cliente.Pais;
                        frm.txtObservacion.Text = cliente.Observacion;
                        frm.txtDireccion.Text = cliente.Direccion;

                        frm.dtpFechaNac.Value = (DateTime)cliente.FechaNac;
                        frm.rbtnCasado.Checked = cliente.EstadoCivil == "Casado" ? true : false;
                        frm.rbtnSoltero.Checked = cliente.EstadoCivil == "Casado" ? false : true;
                        frm.TxtNoRuc.ReadOnly = true;
                        frm.TxtNoRuc.Text = cliente.NoRuc;

                        if(Utilidades.RolUsuario == "1" || Utilidades.RolUsuario == "3")
                        {
                            frm.TxtNoRuc.ReadOnly = false;
                        }

                        frm.LblDynamicoCliente.Text = "Cliente a Modificar: " + cliente.Pnombre + " " + cliente.Snombre + " " + cliente.Papellido + " " + cliente.Sapellido;
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

            return true;

        }

        public void FuncionesCrearModificarCliente(PanelModificarCliente frm =null)
        {
           
            switch (auxKeyUsuario)
            {

                case "Crear":

                    if (!Validaciones(frm))
                    {
                        return;
                    }

                    DateTime fechaSeleccionada = frm.dtpFechaNac.Value;
                    int edad = DateTime.Today.Year - fechaSeleccionada.Year - (DateTime.Today < fechaSeleccionada.AddYears(DateTime.Today.Year - fechaSeleccionada.Year) ? 1 : 0);

                    using (NeoCobranzaContext db = new NeoCobranzaContext())
                    {
                        Clientes clientes = new Clientes()
                        {
                            Pnombre = frm.txtPrimerNombre.Text.Trim(),
                            Snombre = frm.txtSegundoNombre.Text.Trim(),
                            Papellido = frm.txtPrimerApellido.Text.Trim(),
                            Sapellido = frm.txtSegundoApellido.Text.Trim(),
                            Estado = 1,
                            Direccion = frm.txtDireccion.Text.Trim(),
                            Cedula = frm.mtxtCedula.Text.Trim(),
                            Observacion = frm.txtObservacion.Text.Trim(),
                            Telefono = frm.mtxtTelefono.Text.Trim(),
                            Celular = frm.mtxtCelular.Text.Trim(),
                            Email = frm.TxtEmail.Text.Trim(),
                            EstadoCivil = frm.rbtnCasado.Checked == true ? "Casado" : "Soltero",
                            Sexo = frm.rbtnMasculino.Checked == true ? "Masculino" : "Femenino",
                            Edad = edad,
                            FechaNac = frm.dtpFechaNac.Value,
                            Departamento = frm.cmbDepartamento.Text.Trim() == "" ? "Managua" : frm.cmbDepartamento.Text.Trim(),
                            Pais = frm.cmbPais.Text.Trim() == "" ? "Nicaragua" : frm.cmbPais.Text.Trim(),
                            NoRuc = frm.TxtNoRuc.Text.Trim()
                        };

                        db.Add(clientes);
                        db.SaveChanges();

                        MessageBox.Show("El Cliente se ha creado correctamente.", "Correcto", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        ConfigUI(frm.frmPnlCatalogoCliente, "Catalogo");
                        frm.Close();
                    }

                    break;

                case "Modificar":

                    if (!Validaciones(frm))
                    {
                        return;
                    }

                    DateTime fechaSeleccionadaMod = frm.dtpFechaNac.Value;
                    int edadMod = DateTime.Today.Year - fechaSeleccionadaMod.Year - (DateTime.Today < fechaSeleccionadaMod.AddYears(DateTime.Today.Year - fechaSeleccionadaMod.Year) ? 1 : 0);

                    using (NeoCobranzaContext db = new NeoCobranzaContext())
                    {
                        Clientes clientes = new Clientes()
                        {
                            IdCliente = int.Parse(auxId),
                            Pnombre = frm.txtPrimerNombre.Text.Trim(),
                            Snombre = frm.txtSegundoNombre.Text.Trim(),
                            Papellido = frm.txtPrimerApellido.Text.Trim(),
                            Sapellido = frm.txtSegundoApellido.Text.Trim(),
                            Estado = 1,
                            Direccion = frm.txtDireccion.Text.Trim(),
                            Cedula = frm.mtxtCedula.Text.Trim(),
                            Observacion = frm.txtObservacion.Text.Trim(),
                            Telefono = frm.mtxtTelefono.Text.Trim(),
                            Celular = frm.mtxtCelular.Text.Trim(),
                            Email = frm.TxtEmail.Text.Trim(),
                            EstadoCivil = frm.rbtnCasado.Checked == true ? "Casado" : "Soltero",
                            Sexo = frm.rbtnMasculino.Checked == true ? "Masculino" : "Femenino",
                            Edad = edadMod,
                            FechaNac = frm.dtpFechaNac.Value,
                            Departamento = frm.cmbDepartamento.Text.Trim() == "" ? "Managua" : frm.cmbDepartamento.Text.Trim(),
                            Pais = frm.cmbPais.Text.Trim() == "" ? "Nicaragua" : frm.cmbPais.Text.Trim(),
                            NoRuc = frm.TxtNoRuc.Text.Trim()
                        };

                        db.Update(clientes);
                        db.SaveChanges();

                        MessageBox.Show("El Cliente se ha modificado correctamente.", "Correcto", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        ConfigUI(frm.frmPnlCatalogoCliente, "Catalogo");
                        frm.Close();
                    }
                    break;
                    
            }
        }

        public void CambiarEstadoCliente(PnlCatalogoClientes frm,string id)
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                Clientes clienteEstado = db.Clientes.Where(c => c.IdCliente == int.Parse(id)).FirstOrDefault();
                clienteEstado.Estado = clienteEstado.Estado == 0 ? 1 : 0;

                db.Update(clienteEstado);
                db.SaveChanges();

                FuncionesPrincipales(frm, "Buscar");
            }
        }

        public void ConfigUI(PnlCatalogoClientes frm, string opc)
        {
            switch (opc)
            {
                case "Catalogo":
                    frm.dgvCatalogoClientes.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#ECECEC");

                    //Datatable
                    dynamicDataTable.Columns.Clear();
                    dynamicDataTable.Rows.Clear();
                    frm.dgvCatalogoClientes.Columns.Clear();

                    //Agregar Boton de Cambiar de estado
                    DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

                    BtnCambioEstado.Text = "Cambiar Estado";
                    BtnCambioEstado.Name = "...";
                    BtnCambioEstado.UseColumnTextForButtonValue = true;
                    BtnCambioEstado.DefaultCellStyle.ForeColor = Color.Blue;
                    frm.dgvCatalogoClientes.Columns.Add(BtnCambioEstado);

                    // Definir las columnas
                    dynamicDataTable.Columns.Add("Id", typeof(string));
                    dynamicDataTable.Columns.Add("Nombre del Cliente", typeof(string));
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
                    dynamicDataTable.Columns.Add("Estado Civil", typeof(string));
                    dynamicDataTable.Columns.Add("Sexo", typeof(string));

                    frm.CmbBuscarPor.Items.Add("ID");
                    frm.CmbBuscarPor.Items.Add("Nombre");
                    frm.CmbBuscarPor.Items.Add("Cédula");

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
                    using (NeoCobranzaContext db = new NeoCobranzaContext())
                    {
                        List<Clientes> clientes = new List<Clientes>();

                        dynamicDataTable.Rows.Clear();
                        frm.dgvCatalogoClientes.DataSource = "";

                        if (frm.CmbBuscarPor.SelectedIndex == 0)
                        {
                            clientes = db.Clientes.Where(c => c.IdCliente.ToString() == frm.TxtFiltrar.Texts.Trim() && c.IdCliente != 1).OrderByDescending(c => c.IdCliente).ToList();
                        }
                        else if (frm.CmbBuscarPor.SelectedIndex == 1)
                        {
                            clientes = db.Clientes.Where(c => (c.Pnombre + " " + c.Snombre + " " + c.Papellido + " " + c.Sapellido).Contains(frm.TxtFiltrar.Texts.Trim()) && c.IdCliente != 1).OrderByDescending(c => c.IdCliente).ToList();
                        }
                        else if (frm.CmbBuscarPor.SelectedIndex == 2)
                        {
                            clientes = db.Clientes.Where(c => c.Cedula.Contains(frm.TxtFiltrar.Texts.Trim()) && c.IdCliente != 1).OrderByDescending(c => c.IdCliente).ToList();
                        }


                        foreach (var item in clientes)
                        {
                            string idCliente = item.IdCliente.ToString();
                            string nombreCliente = $"{item.Pnombre} {item.Snombre} {item.Papellido} {item.Sapellido}";
                            string cedula = item.Cedula;
                            string estado = item.Estado == null || item.Estado == 0 ? "Inactivo" : "Activo";
                            string direccion = item.Direccion == null || item.Direccion.Trim() == "" ? "Desconocido" : item.Direccion;
                            string pais = item.Pais == null ? "Desconocido" : item.Pais;
                            string departamento = item.Departamento == null ? "Desconocido" : item.Departamento;
                            string fechaNac = item.FechaNac.ToString();
                            string telefono = item.Telefono == null || item.Telefono.Trim() == "" || double.TryParse(item.Telefono.Trim(), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double valorNumericoTel) == false ? "Desconocido" : valorNumericoTel.ToString();
                            string celular = item.Celular == null || item.Celular.Trim() == "" || double.TryParse(item.Celular.Trim(), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double valorNumerico) == false ? "Desconocido" : valorNumerico.ToString();
                            string edad = item.Edad == 0 ? "Desconocido" : item.Edad.ToString();
                            string profesion = item.Profesion == null || item.Profesion.Trim() == "" ? "Desconocido" : item.Profesion;
                            string estadoCivil = item.EstadoCivil;
                            string sexo = item.Sexo;

                            dynamicDataTable.Rows.Add(idCliente, nombreCliente, cedula, estado, direccion, pais, departamento,
                                fechaNac, telefono, celular, edad, profesion, estadoCivil, sexo);
                        }

                        frm.dgvCatalogoClientes.DataSource = dynamicDataTable;
                        frm.dgvCatalogoClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Ajustar automáticamente al contenido

                    }
                    break;

            }
        }
    }
}
