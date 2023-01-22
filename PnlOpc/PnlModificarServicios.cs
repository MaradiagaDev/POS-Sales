using NeoCobranza.Clases;
using NeoCobranza.Data;
using NeoCobranza.DataController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.PnlOpc
{
    public partial class PnlModificarServicios : Form
    {
        public CServiciosVD cServiciosVD;
        public Conexion conexion;

        //instancia de las nuevas clases
        public Servicios servicios;
        public Imagen imagenClase;

        public PnlModificarServicios(Conexion  conexion)
        {
            this.conexion = conexion;
            InitializeComponent();
            cServiciosVD= new CServiciosVD(conexion);
            PnlInfo.Hide();
            PnlVer.Hide();
            PnlImagenes.Hide();

            //Instancia de la nueva clase
            servicios= new Servicios(conexion);
            imagenClase = new Imagen(conexion);

            
            DgvBusquedas.DataSource = servicios.Mostra_Todo(txtfiltro.Texts);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

            //Verificar que este seleccionada una modificacion
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un tipo de Modificacion", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // verificar que haya una fila seleccionada(Actualizar/ cambiar estado)
            if (comboBox1.SelectedIndex == 0 && DgvBusquedas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un servicio para cambiar estado", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //
            if (comboBox1.SelectedIndex == 1 && DgvBusquedas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un servicio para actualizar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (comboBox1.SelectedIndex == 0)
            {
                //Uso de la nueva clase para cambiar estados
                servicios.IdServicio = int.Parse(DgvBusquedas.SelectedRows[0].Cells["IdServicio"].Value.ToString());
                servicios.Estado = DgvBusquedas.SelectedRows[0].Cells["Estado"].Value.ToString();

                //ejecutar procedimiento almacenado
                servicios.Actualizar_Estado();

                //Mensaje de comprobacion
                MessageBox.Show("Cambio de estado realizado", "Modificacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //LLenado de data
                DgvBusquedas.DataSource = servicios.Mostra_Todo(txtfiltro.Texts);
            }
           
            
            

            if (comboBox1.SelectedIndex == 1)
            {
                //Verificacion
                if (txtDescripcion.Text == "" || txtNombre.Text == "")
                {
                    MessageBox.Show("Hay campos vacios", "error de Modificacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //Llenado de la clase

                servicios.IdServicio = int.Parse(txtId.Text);
                servicios.Nombre = txtNombre.Text;
                servicios.Descripcion = txtDescripcion.Text;

                //Ejecucion del procedimiento almacenado
                servicios.Actualizar_Servicio();

                MessageBox.Show("Servicio Actualizado", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Llenado del data
                DgvBusquedas.DataSource = servicios.Mostra_Todo(txtfiltro.Texts);




                txtId.Text = "";
                txtNombre.Text = "";
                txtDescripcion.Text = "";
               


                return;

            }

            //insert
           


        }

        private void DgvBusquedas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex== 0)
            {
                lblTitulo.Text = "Seleccione un servicio para cambiar de estado";
                PnlInfo.Show();
                txtId.Text = "";
                txtNombre.Text = "";
                txtDescripcion.Text = "";
                

            }

            //para actualizar
            if(comboBox1.SelectedIndex== 1 && DgvBusquedas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un servicio para actualizar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return ;
            }

            if (comboBox1.SelectedIndex == 1)
            {
                lblTitulo.Text = "Digite los nuevos datos";
                PnlInfo.Show();

                txtId.Text = DgvBusquedas.SelectedRows[0].Cells["IdServicio"].Value.ToString();
                txtNombre.Text = DgvBusquedas.SelectedRows[0].Cells["Servicio"].Value.ToString();
                txtDescripcion.Text = DgvBusquedas.SelectedRows[0].Cells["Descripcion"].Value.ToString();
                PnlVer.Hide();
                PnlImagenes.Hide();
            }
            

            //Para insertar
         
            if (comboBox1.SelectedIndex == 2)
            {
                
                PnlInfo.Hide();
                PnlVer.Hide();
                PnlImagenes.Show();

                txtId.Text = "";
                txtNombre.Text = "";
                txtDescripcion.Text = "";


            }
            if (comboBox1.SelectedIndex == 3)
            {
                
                PnlImagenes.Hide();
                PnlInfo.Hide();
                PnlVer.Show();
                

                txtId.Text = "";
                txtNombre.Text = "";
                txtDescripcion.Text = "";
         

            }

        }

        private void DgvBusquedas_SelectionChanged(object sender, EventArgs e)
        {

            ActualizarImagen();


            {
                try
                {

                    if (comboBox1.SelectedIndex == 1)
                    {
                        lblTitulo.Text = "Digite los nuevos datos";
                        PnlInfo.Show();

                        txtId.Text = DgvBusquedas.SelectedRows[0].Cells["IdServicio"].Value.ToString();
                        txtNombre.Text = DgvBusquedas.SelectedRows[0].Cells["Servicio"].Value.ToString();
                        txtDescripcion.Text = DgvBusquedas.SelectedRows[0].Cells["Descripcion"].Value.ToString();
                        
                    }
                }catch (Exception)
                {

                }
               
            }
        }
        private void ActualizarImagen()
        {

            try
            {
                Me2.Image = null;
                if (imagenClase.Mostrar_Imagen_Ventas(int.Parse(DgvBusquedas.SelectedRows[0].Cells[0].Value.ToString())).IsDBNull(0))
                {
                    return;
                }

                if (imagenClase.Mostrar_Imagen_Ventas(int.Parse(DgvBusquedas.SelectedRows[0].Cells[0].Value.ToString())).HasRows)
                {



                    MemoryStream ms = new MemoryStream((byte[])imagenClase.Mostrar_Imagen_Ventas(int.Parse(DgvBusquedas.SelectedRows[0].Cells[0].Value.ToString()))["imagen"]);

                    Bitmap bm = new Bitmap(ms);
                    Me2.SizeMode = PictureBoxSizeMode.StretchImage;

                    Me2.Image = bm;
                }
                else
                {
                    MessageBox.Show("Imagen no encontrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            catch (Exception ex)
            {

            }






        }
        private void txtfiltro__TextChanged(object sender, EventArgs e)
        {
           
                DgvBusquedas.DataSource = servicios.Mostra_Todo(txtfiltro.Texts);

        }

        private void BtnSeleccionarImagen_Click(object sender, EventArgs e)
        {

            Me.SizeMode = PictureBoxSizeMode.StretchImage;

            openFileDialog1.Filter = "Imagenes JPG|*.jpg|Imagenes bitmasps|*.bmp|Imagenes JPEG|*.jpeg";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Me.Image = Image.FromFile(openFileDialog1.FileName);

            }

        }

        private void BtnGuardarImagen_Click(object sender, EventArgs e)
        {
            if (DgvBusquedas.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ningun fila", "error de Modificacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Me.Image == null)
            {
                MessageBox.Show("No ha seleccionado ninguna Imagen", "error de Modificacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
           

            MemoryStream archivoMemoria = new MemoryStream();
            Me.Image.Save(archivoMemoria, ImageFormat.Bmp);


            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ImagenContrato";
            cmd.Connection = conexion.connect;


            cmd.Parameters.AddWithValue("@image", archivoMemoria.GetBuffer());

            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();


            Thread.Sleep(2000);

            servicios.IdServicio = int.Parse(DgvBusquedas.SelectedRows[0].Cells[0].Value.ToString());
            servicios.IdImagen = int.Parse(imagenClase.Mostrar_Ultima_Imagen());

            servicios.Actualizar_Imagen();

            MessageBox.Show("Imagen Actualizada");
        }
    }
}
