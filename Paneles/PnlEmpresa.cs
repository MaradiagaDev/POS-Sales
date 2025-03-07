using Microsoft.IdentityModel.Tokens;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.ViewModels;
using OfficeOpenXml.Drawing.Chart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles
{
    public partial class PnlEmpresa : Form
    {
        int auxEmpresa = 0;
        DataUtilities dataUtilities = new DataUtilities();
        public PnlEmpresa()
        {
            InitializeComponent();
        }

        private void PnlEmpresa_Load(object sender, EventArgs e)
        {
            UIUtilities.EstablecerFondo(this);
            UIUtilities.ConfigurarBotonActualizar(BtnActualizar);
            UIUtilities.ConfigurarTituloPantalla(TbTitulo, PnlTitulo);

            DataTable dtResponse = dataUtilities.GetAllRecords("Empresa");

            if (dtResponse.Rows.Count > 0)
            {
                TxtNombreComercial.Text = Convert.ToString(dtResponse.Rows[0]["NombreComercial"]);
                TxtNombreEmpresa.Text = Convert.ToString(dtResponse.Rows[0]["NombreEmpresa"]);
                TxtTelefono.Text = Convert.ToString(dtResponse.Rows[0]["Telefono"]);
                TxtNoRuc.Text = Convert.ToString(dtResponse.Rows[0]["Ruc"]);
                TxtEmail.Text = Convert.ToString(dtResponse.Rows[0]["Email"]);
                TxtPrimerColumna.Text = Convert.ToString(dtResponse.Rows[0]["PrimerColumna"]);
                TxtSegundaColumna.Text = Convert.ToString(dtResponse.Rows[0]["SegundaColumna"]);
                TxtProforma.Text = Convert.ToString(dtResponse.Rows[0]["proforma"]);
                TxtPropina.Text = Convert.ToString(dtResponse.Rows[0]["Propina"]);

                if(dtResponse.Rows[0]["BitImgFac"] != DBNull.Value)
                {
                    ChkImgFactura.Checked = Convert.ToBoolean(dtResponse.Rows[0]["BitImgFac"]);
                }

                if (dtResponse.Rows[0]["bitPorcentaje"] != DBNull.Value)
                {
                    RBMonto.Checked = !Convert.ToBoolean(dtResponse.Rows[0]["bitPorcentaje"]);
                    RBPorcentaje.Checked = Convert.ToBoolean(dtResponse.Rows[0]["bitPorcentaje"]);
                }
                else
                {
                    RBMonto.Checked = false; // O el valor por defecto que prefieras
                    RBPorcentaje.Checked = false;
                }

                auxEmpresa = Convert.ToInt32(dtResponse.Rows[0]["IdEmpresa"]);

                byte[] imagenBytes = dtResponse.Rows[0]["Logo"] as byte[];

                if (imagenBytes != null)
                {
                    using (MemoryStream ms = new MemoryStream(imagenBytes))
                    {
                        PbLogo.Image = Image.FromStream(ms);
                        PbLogo.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }

                //NoImagen
                byte[] imagenBytesNoImagen = dtResponse.Rows[0]["NoImagen"] as byte[];

                if (imagenBytesNoImagen != null)
                {
                    using (MemoryStream ms = new MemoryStream(imagenBytesNoImagen))
                    {
                        PBImagenProducto.Image = Image.FromStream(ms);
                        PBImagenProducto.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            //Validaciones
            if (TxtNombreEmpresa.Text.Trim().Length == 0)
            {
                MessageBox.Show("El nombre de la empresa no puede estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TxtNombreComercial.Text.Trim().Length == 0)
            {
                MessageBox.Show("El nombre comercial de la empresa no puede estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TxtTelefono.Text.Trim().Length == 0)
            {
                MessageBox.Show("El telefono no puede estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TxtNoRuc.Text.Trim().Length == 0)
            {
                MessageBox.Show("El No RUC no puede estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TxtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("El Email no puede estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }




            string Propina = TxtPropina.Text.IsNullOrEmpty() ? "0" : TxtPropina.Text.Trim();

            if (auxEmpresa == 0)
            {

                if(Propina != "0" && !RBPorcentaje.Checked && !RBMonto.Checked)
                {
                    MessageBox.Show("En la propina debe seleccionar si se hará por monto fijo o porcentaje.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                dataUtilities.SetColumns("NombreComercial", TxtNombreComercial.Text);
                dataUtilities.SetColumns("NombreEmpresa", TxtNombreEmpresa.Text);
                dataUtilities.SetColumns("Telefono", TxtTelefono.Text);
                dataUtilities.SetColumns("Ruc", TxtNoRuc.Text);
                dataUtilities.SetColumns("Email", TxtEmail.Text);
                dataUtilities.SetColumns("PrimerColumna", TxtPrimerColumna.Text);
                dataUtilities.SetColumns("SegundaColumna", TxtSegundaColumna.Text);
                dataUtilities.SetColumns("proforma", TxtProforma.Text);
                dataUtilities.SetColumns("Propina", Propina);
                dataUtilities.SetColumns("BitImgFac", ChkImgFactura.Checked);

                if (PbLogo.Image != null)
                {
                    byte[] imagenBytes = ImageToByteArray(PbLogo.Image);
                    dataUtilities.SetColumns("Logo", imagenBytes);
                }

                if (PBImagenProducto.Image != null)
                {
                    byte[] imagenBytes = ImageToByteArray(PBImagenProducto.Image);
                    dataUtilities.SetColumns("NoImagen", imagenBytes);
                }

                dataUtilities.InsertRecord("Empresa");

                MessageBox.Show("La empresa ha sido creada correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataUtilities.SetColumns("NombreComercial", TxtNombreComercial.Text);
                dataUtilities.SetColumns("NombreEmpresa", TxtNombreEmpresa.Text);
                dataUtilities.SetColumns("Telefono", TxtTelefono.Text);
                dataUtilities.SetColumns("Ruc", TxtNoRuc.Text);
                dataUtilities.SetColumns("Email", TxtEmail.Text);
                dataUtilities.SetColumns("PrimerColumna", TxtPrimerColumna.Text);
                dataUtilities.SetColumns("SegundaColumna", TxtSegundaColumna.Text);
                dataUtilities.SetColumns("proforma", TxtProforma.Text);
                dataUtilities.SetColumns("Propina", Propina);
                dataUtilities.SetColumns("bitPorcentaje", RBPorcentaje.Checked);
                dataUtilities.SetColumns("BitImgFac", ChkImgFactura.Checked);

                if (PbLogo.Image != null)
                {
                    byte[] imagenBytes = ImageToByteArray(PbLogo.Image);
                    dataUtilities.SetColumns("Logo", imagenBytes);
                }

                if (PBImagenProducto.Image != null)
                {
                    byte[] imagenBytes = ImageToByteArray(PBImagenProducto.Image);
                    dataUtilities.SetColumns("NoImagen", imagenBytes);
                }


                dataUtilities.UpdateRecordByPrimaryKey("Empresa", auxEmpresa);

                MessageBox.Show("La empresa ha sido actualizada correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();

        }

        private byte[] ImageToByteArray(Image image)
        {
            if (image == null)
                return null;

            using (MemoryStream ms = new MemoryStream())
            {
                // Copiar la imagen para evitar bloqueos
                using (Bitmap bmp = new Bitmap(image))
                {
                    bmp.Save(ms, image.RawFormat);
                }
                return ms.ToArray();
            }
        }


        private Image LoadImageWithoutLocking(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                return Image.FromStream(fs);
            }
        }


        private void BtnSeleccionarLogo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Seleccionar Imagen";
                openFileDialog.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Muestra la imagen en un PictureBox llamado "pbLogo"
                    PbLogo.Image = Image.FromFile(openFileDialog.FileName);
                    PbLogo.SizeMode = PictureBoxSizeMode.Zoom;

                    // Si necesitas guardar la ruta de la imagen
                    string rutaImagen = openFileDialog.FileName;
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números (0-9), el punto decimal (.) y la tecla de retroceso (Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Bloquea la tecla si no es válida
            }

            // Solo permitir un único punto decimal
            if (e.KeyChar == '.' && TxtPropina.Text.Contains("."))
            {
                e.Handled = true; // Bloquea la tecla si ya hay un punto en el texto
            }
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Seleccionar Imagen";
                openFileDialog.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Muestra la imagen en un PictureBox llamado "pbLogo"
                    PBImagenProducto.Image = Image.FromFile(openFileDialog.FileName);
                    PBImagenProducto.SizeMode = PictureBoxSizeMode.Zoom;

                    // Si necesitas guardar la ruta de la imagen
                    string rutaImagen = openFileDialog.FileName;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
