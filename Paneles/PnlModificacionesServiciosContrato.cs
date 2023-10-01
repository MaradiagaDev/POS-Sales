using Microsoft.ReportingServices.Diagnostics.Internal;
using Microsoft.ReportingServices.Interfaces;
using NeoCobranza.Clases;
using NeoCobranza.Data;
using NeoCobranza.DataController;
using System;
using System.Collections;
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

namespace NeoCobranza.Paneles
{
    public partial class PnlModificacionesServiciosContrato : Form
    {
        public Conexion conexion;
        public CServiciosCont cServiciosCont;
        public CFoto cFoto;
        public Image imagen;

        public Imagen imagenClase;

        public Ataudes ataudes;

        public PnlModificacionesServiciosContrato(Conexion conexion)
        {
            InitializeComponent();

            this.conexion = conexion;

            cServiciosCont = new CServiciosCont(conexion);
            
            cFoto = new CFoto(conexion);
            PnlInfo.Visible = false;
            PnlImagenes.Visible = false;
            PnlVer.Visible = false;

            //Nuevas clases
            ataudes = new Ataudes(conexion);
            imagenClase = new Imagen(conexion);

            DgvBusquedas.DataSource = ataudes.Mostra_TipoTotal_Categoria(txtfiltro.Texts);
        }

        private void txtfiltro__TextChanged(object sender, EventArgs e)
        {
            

            DgvBusquedas.DataSource = ataudes.Mostra_TipoTotal_Categoria(txtfiltro.Texts);


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                PnlImagenes.Visible = false;
                lblTitulo.Text = "Seleccione un servicio para cambiar de estado";
                PnlInfo.Show();
                txtId.Text = "";
                txtNombre.Text = "";
              
                txtDescripcion.Text = "";

                return;

            }

            //para actualizar
            if (comboBox1.SelectedIndex == 1 && DgvBusquedas.SelectedRows.Count == 0)
            {
           
                PnlImagenes.Visible = false;
             
                PnlVer.Visible = false;
                MessageBox.Show("Seleccione un servicio para actualizar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (comboBox1.SelectedIndex == 1)
            {
                if (DgvBusquedas.Rows.Count == 0)
                {
                    MessageBox.Show("No hay Tipos de productos en el sistema", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //Operaciones de Paneles
                PnlImagenes.Visible = false;
                lblTitulo.Text = "Digite los nuevos datos";
                PnlInfo.Show();

                //LLenados de campos de textos
                txtId.Text = DgvBusquedas.SelectedRows[0].Cells["IdEstandar"].Value.ToString();
                txtNombre.Text = DgvBusquedas.SelectedRows[0].Cells["NombreEstandar"].Value.ToString();
                txtDescripcion.Text = DgvBusquedas.SelectedRows[0].Cells["Descripcion"].Value.ToString();
               

                //Verificar que otros paneles no esten abiertos
                PnlImagenes.Visible = false;
                PnlVer.Visible = false;
            }


            //Para insertar
           

            if (comboBox1.SelectedIndex== 2)
            {
                PnlImagenes.Visible = true;
                PnlInfo.Visible = false;
                PnlVer.Visible = false;

            }
            if (comboBox1.SelectedIndex == 3)
            {
                PnlImagenes.Visible = false; ;
                PnlInfo.Visible = false;

                PnlVer.Visible = true;

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
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
            
            //CAMBIO DE ESTADO
            if (comboBox1.SelectedIndex == 0)
            {

                //Procedimiento para cambio de estado
                ataudes.CambioeEstado_Categorias(int.Parse(DgvBusquedas.SelectedRows[0].Cells["IdEstandar"].Value.ToString()));

                //Mensaje 

                MessageBox.Show("Cambio de estado realizado", "Modificacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //Actualizar tabla

                DgvBusquedas.DataSource = ataudes.Mostra_TipoTotal_Categoria(txtfiltro.Texts);



                return;
            }
          
            

            if (comboBox1.SelectedIndex == 1)
            {

                if (txtNombre.Text == "" )
                {
                    MessageBox.Show("Hay campos vacios", "error de Modificacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                //Verificar por lo menos el nombre
                if (txtNombre.Text == "")
                {
                    MessageBox.Show("El campo de nombre no puede estar en blanco", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                ataudes.Actualizar_Categorias(int.Parse(txtId.Text), txtNombre.Text, txtDescripcion.Text);

                //Actualizar tabla

                DgvBusquedas.DataSource = ataudes.Mostra_TipoTotal_Categoria(txtfiltro.Texts);

                //Limpiar

                txtId.Text = "";
                txtNombre.Text = "";
                txtDescripcion.Text = "";


                return;

            }
           
            
            
        }

        private void BtnSeleccionarImagen_Click(object sender, EventArgs e)
        {

            Me.SizeMode = PictureBoxSizeMode.StretchImage;

            openFileDialog1.Filter = "Imagenes JPG|*.jpg|Imagenes bitmasps|*.bmp|Imagenes JPEG|*.jpeg";
            if (openFileDialog1.ShowDialog()== System.Windows.Forms.DialogResult.OK)
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
            if(Me.Image == null)
            {
                MessageBox.Show("No ha seleccionado ninguna Imagen", "error de Modificacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            
            

            MemoryStream archivoMemoria = new MemoryStream();
            Me.Image.Save(archivoMemoria,ImageFormat.Bmp);


            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ImagenContrato";
            cmd.Connection = conexion.connect;

           
            cmd.Parameters.AddWithValue("@image",archivoMemoria.GetBuffer());

            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();

            //nueva clase

            


            ataudes.IdImagen = int.Parse(imagenClase.Mostrar_Ultima_Imagen());
            ataudes.IdAtaud = int.Parse(DgvBusquedas.SelectedRows[0].Cells[0].Value.ToString());

            ataudes.Actualizar_Imagen();


            MessageBox.Show("Imagen Insertada", "Modificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Me.Image = null;
            
        }

        private void ActualizarImagen()
        {

            try
            {
                Me2.Image = null;
                if (imagenClase.Mostrar_Imagen(int.Parse(DgvBusquedas.SelectedRows[0].Cells[0].Value.ToString())).IsDBNull(0))
                {
                    return;
                }

                if (imagenClase.Mostrar_Imagen(int.Parse(DgvBusquedas.SelectedRows[0].Cells[0].Value.ToString())).HasRows)
                {

                    
                    
                    MemoryStream ms = new MemoryStream((byte[])imagenClase.Mostrar_Imagen(int.Parse(DgvBusquedas.SelectedRows[0].Cells[0].Value.ToString()))["imagen"]);

                    Bitmap bm = new Bitmap(ms);
                    Me2.SizeMode = PictureBoxSizeMode.StretchImage;

                    Me2.Image = bm;
                }
                else
                {
                    MessageBox.Show("Imagen no encontrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }catch(Exception ex)
            {

            }


               
           


        }


        private void DgvBusquedas_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarImagen();

            if (comboBox1.SelectedIndex == 1)
            {
                PnlImagenes.Visible = false;
                lblTitulo.Text = "Digite los nuevos datos";
                PnlInfo.Show();

                if (DgvBusquedas.SelectedRows.Count == 0)
                {
                    return;
                }

                txtId.Text = DgvBusquedas.SelectedRows[0].Cells["IdEstandar"].Value.ToString(); 
                txtNombre.Text = DgvBusquedas.SelectedRows[0].Cells["NombreEstandar"].Value.ToString();

                txtDescripcion.Text = DgvBusquedas.SelectedRows[0].Cells["Descripcion"].Value.ToString();

                PnlImagenes.Visible = false;
                PnlVer.Visible = false;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void DgvBusquedas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void PnlInfo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
