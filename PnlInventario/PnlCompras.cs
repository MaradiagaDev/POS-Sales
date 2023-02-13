using NeoCobranza.Clases;
using NeoCobranza.Data;
using NeoCobranza.DataController;
using NeoCobranza.Paneles;
using NeoCobranza.Paneles_ComprasComercial;
using NeoCobranza.Paneles_ComprasGenerales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.PnlInventario
{
    public partial class PnlCompras : Form
    {
        //Variable de conexion
        public Conexion conexion;

        //Variables de clases
        public Ataudes ataudes;
        public Auditorias auditorias;
        //Paneles utilizados para la compra
        public PnlProductoNuevo pnlProductoNuevo;
        public ProductoExistente productoExistente;


        //
        //Panel de proveedor

        public PnlSeleccionarProveedor pnlSeleccionar;

        //Paneles utilizados para los pagos
        PnlPagoEfectivoG pnlPagoEfectivoG = new PnlPagoEfectivoG();

        PanelPagoCreditoG pnlPagoCreditoG = new PanelPagoCreditoG();

       

        //Variable utilizada para verificar en que panel se encuentra la seleccion
        public int NoPanel=0;

        public PnlCompras(Conexion conexion)
        {
            InitializeComponent();




            //Inicializador
            this.conexion = conexion;

            this.ataudes = new Ataudes(conexion);
            this.auditorias = new Auditorias(conexion);

            pnlSeleccionar = new PnlSeleccionarProveedor(conexion);
            //Proveedor
            AddOwnedForm(pnlSeleccionar);

            //Departamentos

            cmbCategoria.DataSource = ataudes.CmbCategorias();
            cmbCategoria.ValueMember = "NombreEstandar";

            dgvStock.DataSource = ataudes.Mostra_Stock(txtFiltro.Texts, int.Parse(ataudes.Mostra_idXNombre_Categoria(cmbCategoria.Text)));
            color();
            //Estilo
            dgvStock.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvStock.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);

            //Mostrar datos de categorias

            try
            {

                txtMargen.Text = ataudes.MostraTodo_Categoria(int.Parse(ataudes.Mostra_idXNombre_Categoria(cmbCategoria.Text))).Rows[0]["MontoVD"].ToString();
                txtMargenContrato.Text = ataudes.MostraTodo_Categoria(int.Parse(ataudes.Mostra_idXNombre_Categoria(cmbCategoria.Text))).Rows[0]["MontoContrato"].ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void txtFiltro__TextChanged(object sender, EventArgs e)
        {
            //Llenado del data

            dgvStock.DataSource = ataudes.Mostra_Stock(txtFiltro.Texts, int.Parse(ataudes.Mostra_idXNombre_Categoria(cmbCategoria.Text)));
            color();
        }
        public void limpiar_PnlPrincipal()
        {
            if (PnlPrincipal.Controls.Count > 0)
            {
                PnlPrincipal.Controls.RemoveAt(0);

            }
        }

        
        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {

            //
            if (ataudes.Mostra_TipoxNombre_Categoria(cmbCategoria.Text)=="Servicio")
            {
                MessageBox.Show("No se puede comprar mas producto de un servicio");
                return;
            }
            if (cmbCategoria.Text== "")
            {
                MessageBox.Show("No hay ningun tipo de producto en el sistema");
                return;
            }

            //Verificaciones
            if (txtColor.Text == "")
            {
                MessageBox.Show("No ha digitado ningun Color");
                return;
            }
            if (txtNoSerie.Text == "")
            {
                MessageBox.Show("No ha digitado el NoSerie");
                return;
            }
            if (txtRemision.Text == "")
            {
                MessageBox.Show("No ha digitado en NoRemision");
                return;
            }

            //Insertar
            ataudes.Insertar_Ataud(txtColor.Text, txtNoSerie.Text, int.Parse(ataudes.Mostra_idXNombre_Categoria(cmbCategoria.Text)), txtRemision.Text);

            //Limpiar
            txtColor.Text = "";
            txtNoSerie.Text = "";
            txtRemision.Text = "";


            //Actualizacion 

            dgvStock.DataSource = ataudes.Mostra_Stock(txtFiltro.Texts, int.Parse(ataudes.Mostra_idXNombre_Categoria(cmbCategoria.Text)));
            color();

            //Insertar en auditorias
            auditorias.Insertar(conexion.usuario, "Compra de producto", dgvStock.Rows[0].Cells[0].Value.ToString(),"Inventario");

            //Mensaje
            MessageBox.Show("Compra de producto realizada","Correcto");
        }
    
        private void BtnProductoExistente_Click(object sender, EventArgs e)
        {

            //Verificar el si hay una seleccion

            if (dgvStock.SelectedRows.Count == 0)
            {

                MessageBox.Show("No ha seleccionado ningun servicio");
                return;
            }

            if (dgvStock.SelectedRows[0].Cells[3].Value.ToString() == "Disponible")
            {

                ataudes.Actualizar_Estado(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()), dgvStock.SelectedRows[0].Cells[3].Value.ToString());

                MessageBox.Show("Compra anulada","Correcto");
                
            }
            if (dgvStock.SelectedRows[0].Cells[3].Value.ToString() == "Servicio")
            {

               
                MessageBox.Show("El ataud ya fue dado como servicio", "Error");
                return;

            }
            if (dgvStock.SelectedRows[0].Cells[3].Value.ToString() == "Anulado")
            {

                ataudes.Actualizar_Estado(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()), dgvStock.SelectedRows[0].Cells[3].Value.ToString());

                MessageBox.Show("Se ha cambiado el estado", "Error");
            }
            if (dgvStock.SelectedRows[0].Cells[3].Value.ToString() == "Vendido")
            {


                MessageBox.Show("El ataud ya fue vendido.No se puede cambiar su estado", "Error");

                return;
            }
            if (dgvStock.SelectedRows[0].Cells[3].Value.ToString() == "Venta Futura")
            {


                MessageBox.Show("El ataud ya fue vendido, solo esta en espera de retiro", "Error");

                return;
            }
            if (dgvStock.SelectedRows[0].Cells[3].Value.ToString() == "Reservado")
            {


                MessageBox.Show("El ataud ya fue Reservado", "Error");

                return;
            }


            ataudes.Actualizar_Estado(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()), dgvStock.SelectedRows[0].Cells[3].Value.ToString());
            //Insertar en auditorias
            auditorias.Insertar(conexion.usuario, "Anulacion", dgvStock.SelectedRows[0].Cells[0].Value.ToString(),"Inventario");

           

            //Actualizar el estado
            dgvStock.DataSource = ataudes.Mostra_Stock(txtFiltro.Texts, int.Parse(ataudes.Mostra_idXNombre_Categoria(cmbCategoria.Text)));

            color();
        }

        private void color()
        {
            for (int i = 0; i < dgvStock.Rows.Count; i++)
            {
                if (dgvStock.Rows[i].Cells[3].Value.ToString() == "Disponible")
                {
                    dgvStock.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                }
                else if (dgvStock.Rows[i].Cells[3].Value.ToString() == "Anulado")
                {
                    dgvStock.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                else if (dgvStock.Rows[i].Cells[3].Value.ToString() == "Reservado")
                {
                    dgvStock.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (dgvStock.Rows[i].Cells[3].Value.ToString() == "Venta Futura")
                {
                    dgvStock.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (dgvStock.Rows[i].Cells[3].Value.ToString() == "Vendido")
                {
                    dgvStock.Rows[i].DefaultCellStyle.BackColor = Color.YellowGreen;
                }


            }
        }





        private void PnlCompras_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvStock.Rows.Count; i++)
            {
                if (dgvStock.Rows[i].Cells[3].Value.ToString() == "Disponible")
                {
                    dgvStock.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                }
                else if (dgvStock.Rows[i].Cells[3].Value.ToString() == "Anulado")
                {
                    dgvStock.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                else if (dgvStock.Rows[i].Cells[3].Value.ToString() == "Reservado")
                {
                    dgvStock.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (dgvStock.Rows[i].Cells[3].Value.ToString() == "Venta Futura")
                {
                    dgvStock.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (dgvStock.Rows[i].Cells[3].Value.ToString() == "Vendido")
                {
                    dgvStock.Rows[i].DefaultCellStyle.BackColor = Color.YellowGreen;
                }


            }
        }

        

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ataudes.Mostra_TipoxNombre_Categoria(cmbCategoria.Text) == "Servicio")
            {
                btnNuevoProducto.Enabled = false;
            }
            else
            {
                btnNuevoProducto.Enabled = true;
            }
            //Limpiar datos de nuevo producto
            txtColor.Text = "";
            txtNoSerie.Text = "";
            txtRemision.Text = "";

            //Actualizar el stock
            dgvStock.DataSource = ataudes.Mostra_Stock(txtFiltro.Texts, int.Parse(ataudes.Mostra_idXNombre_Categoria(cmbCategoria.Text)));
            color();
            //Actualizar Monto

            txtMargen.Text = ataudes.MostraTodo_Categoria(int.Parse(ataudes.Mostra_idXNombre_Categoria(cmbCategoria.Text))).Rows[0]["MontoVD"].ToString();
            txtMargenContrato.Text = ataudes.MostraTodo_Categoria(int.Parse(ataudes.Mostra_idXNombre_Categoria(cmbCategoria.Text))).Rows[0]["MontoContrato"].ToString();
            txtMostrarMejora.Text= ataudes.MostraTodo_Categoria(int.Parse(ataudes.Mostra_idXNombre_Categoria(cmbCategoria.Text))).Rows[0]["MontoMejora"].ToString();
        }

        private void BtnProveedor_Click(object sender, EventArgs e)
        {
            //Crear y abrir el Panel
            
            //Mostrar
            pnlSeleccionar.Show();

        }

        private void BtnAgregarModelo_Click(object sender, EventArgs e)
        {
            //Verificar la parte del modelo
            if (txtNombreServicio.Texts == "")
            {
                MessageBox.Show("El campo de categoria esta vacio. Digite el nombre de la categoria", "Error");
                return;

            }
            float prueba;
            if (txtPrecioContrato.Text == "" || float.TryParse(txtPrecioContrato.Text,out prueba)==false)
            {
                MessageBox.Show("Dato no valido en el precio de contrato", "Error");
                return;

            }
            if (txtPrecioVenta.Text == "" || float.TryParse(txtPrecioVenta.Text, out prueba) == false)
            {
                MessageBox.Show("Dato no valido en el precio de Venta", "Error");
                return;

            }
            if (txtMejora.Text == "" || float.TryParse(txtMejora.Text, out prueba) == false)
            {
                MessageBox.Show("Dato no valido en el precio de Mejora", "Error");
                return;

            }
            if (txtIdProveedor.Text == ".")
            {
                MessageBox.Show("Seleccione un proveedor", "Error");
                return;
            }
            if (cmbTipoServicio.Text == "")
            {
                MessageBox.Show("Seleccione el tipo de servicio a ingresar.", "Error");
                return;
            }

            //Verificar que la categoria no exista ya

            if (ataudes.Verificar_Categoria(txtNombreServicio.Texts) == "Ya existe")
            {

                MessageBox.Show("El Tipo de ataud ya esta en el sistema", "Error");

                txtNombreServicio.clear();

                txtNombreServicio.PlaceHolderText = "Nueva Categoria..";

                return;

            }

            //Insertar el nuevo producto
            ataudes.InsertarCategoria(txtNombreServicio.Texts,float.Parse(txtPrecioVenta.Text),float.Parse(txtPrecioContrato.Text),int.Parse(txtIdProveedor.Text),cmbTipoServicio.Text,float.Parse(txtMejora.Text));
            MessageBox.Show("Nuevo servicio insertado", "Correcto");

            //Insertar en auditorias
            auditorias.Insertar(conexion.usuario, "Creacion: Categoria", ataudes.Mostra_idXNombre_Categoria(txtNombreServicio.Texts),"Inventario");

            //Limpiar campos
            txtNombreServicio.Texts = "";
            txtNombreServicio.PlaceHolderText = "Nuevo Producto ...";
            txtPrecioContrato.Text = "";
            txtPrecioVenta.Text = "";
            

            //Limpiar la parte de proveedores

            txtNombreProveedor.Text = ".";
            txtIdProveedor.Text = ".";
            txtEstadoProveedor.Text = ".";

            //Actualizacion del combobox
            cmbCategoria.DataSource = ataudes.CmbCategorias();
            cmbCategoria.ValueMember = "NombreEstandar";

            //Auditoria
            

        }

        private void BtnFijarPrecio_Click(object sender, EventArgs e)
        {
            float prueba;
            if(txtMargen.Text==""||float.TryParse(txtMargen.Text,out prueba)==false)
            {
                MessageBox.Show("Dato no valido en el precio de venta", "Error");
                return;
            }
            if (txtMargenContrato.Text == "" || float.TryParse(txtMargenContrato.Text, out prueba)==false)
            {
                MessageBox.Show("Dato no valido en el precio de contrato", "Error");
                return;
            }
            if (txtMostrarMejora.Text == "" || float.TryParse(txtMostrarMejora.Text, out prueba) == false)
            {
                MessageBox.Show("Dato no valido en el precio de contrato", "Error");
                return;
            }

            //Realizar actualizacion

            ataudes.ActualizarPrecios_Categorias(float.Parse(txtMargen.Text),float.Parse(txtMargenContrato.Text),float.Parse(txtMostrarMejora.Text),int.Parse(ataudes.Mostra_idXNombre_Categoria(cmbCategoria.Text)));


            //Insertar en auditorias
            auditorias.Insertar(conexion.usuario, "Actualizacion en precios de ataud", ataudes.Mostra_idXNombre_Categoria(cmbCategoria.Text), "Inventario");

            MessageBox.Show("Precio Actualizado", "Correcto");
            //Volver a actualizar los datos
            txtMargen.Text = ataudes.MostraTodo_Categoria(int.Parse(ataudes.Mostra_idXNombre_Categoria(cmbCategoria.Text))).Rows[0]["MontoVD"].ToString();
            txtMargenContrato.Text = ataudes.MostraTodo_Categoria(int.Parse(ataudes.Mostra_idXNombre_Categoria(cmbCategoria.Text))).Rows[0]["MontoContrato"].ToString();
        }

        private void txtTraslado_Click(object sender, EventArgs e)
        {
            //Verificar que haya seleccion
            if (dgvStock.SelectedRows.Count == 0)
            {

                MessageBox.Show("No ha seleccionado ningun servicio");
                return;
            }
            //Veriificar que no haya sido vendido o anulado
            if (dgvStock.SelectedRows[0].Cells[3].Value.ToString() == "Servicio")
            {


                MessageBox.Show("El ataud ya fue dado como servicio", "Error");
                return;

            }
            if (dgvStock.SelectedRows[0].Cells[3].Value.ToString() == "Anulado")
            {

                ataudes.Actualizar_Estado(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()), dgvStock.SelectedRows[0].Cells[3].Value.ToString());

                MessageBox.Show("Se ha cambiado el estado", "Error");
            }
            if (dgvStock.SelectedRows[0].Cells[3].Value.ToString() == "Vendido")
            {


                MessageBox.Show("El ataud ya fue vendido.No se puede cambiar su estado", "Error");

                return;
            }
            if (dgvStock.SelectedRows[0].Cells[3].Value.ToString() == "Reservado")
            {


                MessageBox.Show("El ataud ya fue Reservado", "Error");

                return;
            }
            if (dgvStock.SelectedRows[0].Cells[3].Value.ToString() == "Venta Futura")
            {


                MessageBox.Show("El ataud ya fue pagado", "Error");

                return;
            }
            //Verificar que haya seleccion de departamento
            if (cmbDepartamento.Text=="")
            {

                MessageBox.Show("No ha seleccionado ningun Departamento");
                return;
            }
            if (txtNoRemisionReal.Text == "")
            {

                MessageBox.Show("No ha Digitado el numero de remision");
                return;
            }
            //Traslado

            ataudes.Traslado_Ataud(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()), cmbDepartamento.Text,txtNoRemisionReal.Text);

            //Insertar en auditorias
            auditorias.Insertar(conexion.usuario, "Traslado de ataud", dgvStock.SelectedRows[0].Cells[0].Value.ToString(),"Inventario");

            MessageBox.Show("Traslado realizado.","Correcto");

            txtNoRemisionReal.Text = "";

            //Actualizar los datos de la tabla
            dgvStock.DataSource = ataudes.Mostra_Stock(txtFiltro.Texts, int.Parse(ataudes.Mostra_idXNombre_Categoria(cmbCategoria.Text)));

            color();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnVentaAgencia_Click(object sender, EventArgs e)
        {
            //Comprobacion
            if (dgvStock.SelectedRows[0].Cells[3].Value.ToString() == "Disponible")
            {
                MessageBox.Show("No pudo ser vendido por una agencia ya que se encuentra en Managua", "Error");
                return;
            }
            if (dgvStock.SelectedRows[0].Cells[3].Value.ToString() == "Vendido")
            {
                MessageBox.Show("El ataud ya fue vendio", "Error");
                return;
            }
            if (dgvStock.SelectedRows[0].Cells[3].Value.ToString() == "Anulado")
            {
                MessageBox.Show("La compra fue anulada", "Error");
                return;
            }
            if (dgvStock.SelectedRows[0].Cells[3].Value.ToString() == "Reservado")
            {
                MessageBox.Show("El ataud ya esta reservado", "Error");
                return;
            }

            //Actualizado
            ataudes.VentaAgencia_Ataud(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));

                //Mensaje
                MessageBox.Show("Venta realizada.", "Correcto");

                //Actualizar los datos de la tabla
                dgvStock.DataSource = ataudes.Mostra_Stock(txtFiltro.Texts, int.Parse(ataudes.Mostra_idXNombre_Categoria(cmbCategoria.Text)));

            

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void especialButton1_Click(object sender, EventArgs e)
        {

            
            Pnl_InformeInventario pnl_InformeInventario = new Pnl_InformeInventario(conexion);
            pnl_InformeInventario.Show();
        }

        private void especialButton2_Click(object sender, EventArgs e)
        {
            //Verificar que haya seleccion
            if (dgvStock.SelectedRows.Count == 0)
            {

                MessageBox.Show("No ha seleccionado ningun servicio");
                return;
            }

            //Verificar que el ataud este en managua
            if (dgvStock.SelectedRows[0].Cells[3].Value.ToString() == "Vendido")
            {
                MessageBox.Show("El ataud ya fue vendio", "Error");
                return;
            }
            if (dgvStock.SelectedRows[0].Cells[3].Value.ToString() == "Anulado")
            {
                MessageBox.Show("La compra fue anulada", "Error");
                return;
            }
            if (dgvStock.SelectedRows[0].Cells[3].Value.ToString() == "Trasladado")
            {
                MessageBox.Show("El ataud no se encuentra en managua", "Error");
                return;
            }
            if (dgvStock.SelectedRows[0].Cells[3].Value.ToString() == "Reservado")
            {
                MessageBox.Show("La compra fue anulada", "Error");
                return;
            }

            //Actualizado
            ataudes.VentaAgencia_Ataud(int.Parse(dgvStock.SelectedRows[0].Cells[0].Value.ToString()));

            //Mensaje
            MessageBox.Show("Venta realizada.", "Correcto");

            //Actualizar los datos de la tabla
            dgvStock.DataSource = ataudes.Mostra_Stock(txtFiltro.Texts, int.Parse(ataudes.Mostra_idXNombre_Categoria(cmbCategoria.Text)));


        }
    }
}
