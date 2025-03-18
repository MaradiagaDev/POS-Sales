using iText.StyledXmlParser.Jsoup.Helper;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace NeoCobranza.PanelesHoteles
{
    public partial class PnlDefinirHabitaciones : Form
    {
        DataUtilities dataUtilities = new DataUtilities();
        DataTable dynamicDataTable = new DataTable();
        public string auxId = "0";
        private List<PaqueteLista> listNuevas = new List<PaqueteLista>();
      
        public class PaqueteLista
        {
            public string idPaquete { get; set; }
            public string idHabitacion { get; set; }
            public string nombre { get; set; }
            public decimal precio { get; set; }
        }

        public PnlDefinirHabitaciones()
        {
            InitializeComponent();
            UIUtilities.PersonalizarDataGridViewPequeñosPlus(DgvItemsPaquete);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PnlDefinirHabitaciones_Load(object sender, EventArgs e)
        {
            dynamicDataTable.Columns.Add("Clave", typeof(string));
            dynamicDataTable.Columns.Add("Nombre", typeof(string));
            dynamicDataTable.Columns.Add("Precio", typeof(string));
            dynamicDataTable.Columns.Add("Estado", typeof(string));
            BtnBloquearPaquete.Visible = false;

            DgvItemsPaquete.DataSource = dynamicDataTable;  

            if (auxId != "0")
            {
                BtnBloquearPaquete.Visible = true;
                Buscar();
            }
        }

        private void Buscar()
        {
            dynamicDataTable.Rows.Clear();

            DataRow dtResponse = dataUtilities.getRecordByColumn("Habitaciones", "HabitacionId", auxId).Rows[0];
            TxtNombreAgrupacion.Text = Convert.ToString(dtResponse["Nombre"]);
            TxtDescripcion.Text = Convert.ToString(dtResponse["strDescripcion"]);
            TxtCostoxHabitacion.Text = Convert.ToString(dtResponse["decCosto"]);
            TxtCantidad.Text = Convert.ToString(dtResponse["Cantidad"]);
            TxtMonto.Text = Convert.ToString(dtResponse["decMonto"]);
            ChkPorcentaje.Checked = Convert.ToBoolean(dtResponse["bitPorcentaje"]);

            DataTable dtResponsePaquetes = dataUtilities.getRecordByColumn("PaquetesHabitaciones", "HabitacionId", auxId);

            foreach (DataRow dr in dtResponsePaquetes.Rows)
            {
                dynamicDataTable.Rows.Add(Convert.ToString(dr["PaqueteId"]), Convert.ToString(dr["NombrePaquete"]), Convert.ToString(dr["Precio"]), Convert.ToString(dr["Estado"]));
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validación del campo "Nombre"
            if (string.IsNullOrWhiteSpace(TxtNombreAgrupacion.Text))
            {
                MessageBox.Show("El campo 'Nombre' es obligatorio.", "Atención", MessageBoxButton.OK, MessageBoxImage.Warning);
                TxtNombreAgrupacion.Focus();
                return;
            }

            // Validación del campo "Descripción"
            if (string.IsNullOrWhiteSpace(TxtDescripcion.Text))
            {
                MessageBox.Show("El campo 'Descripción' es obligatorio.", "Atención", MessageBoxButton.OK, MessageBoxImage.Warning);
                TxtDescripcion.Focus();
                return;
            }

            // Validación del campo "Costo" (se espera un número decimal mayor que cero)
            decimal decCosto;
            if (!decimal.TryParse(TxtCostoxHabitacion.Text, out decCosto) || decCosto <= 0)
            {
                MessageBox.Show("Ingrese un costo válido (número mayor a cero).", "Atención", MessageBoxButton.OK, MessageBoxImage.Warning);
                TxtCostoxHabitacion.Focus();
                return;
            }

            // Validación del campo "Cantidad" (se espera un número entero mayor o igual a cero)
            int cantidad;
            if (!int.TryParse(TxtCantidad.Text, out cantidad) || cantidad < 0)
            {
                MessageBox.Show("Ingrese una cantidad válida (número entero mayor o igual a cero).", "Atención", MessageBoxButton.OK, MessageBoxImage.Warning);
                TxtCantidad.Focus();
                return;
            }

            // Validación del campo "Monto" (se espera un número decimal mayor o igual a cero)
            decimal decMonto;
            if (!decimal.TryParse(TxtMonto.Text, out decMonto) || decMonto < 0)
            {
                MessageBox.Show("Ingrese un monto válido (número mayor o igual a cero).", "Atención", MessageBoxButton.OK, MessageBoxImage.Warning);
                TxtMonto.Focus();
                return;
            }

            // Si se superan todas las validaciones, se procede a asignar los valores
            dataUtilities.SetColumns("Nombre", TxtNombreAgrupacion.Text);
            dataUtilities.SetColumns("strDescripcion", TxtDescripcion.Text);
            dataUtilities.SetColumns("decCosto", decCosto.ToString());
            dataUtilities.SetColumns("Cantidad", cantidad.ToString());
            dataUtilities.SetColumns("decMonto", decMonto.ToString());
            dataUtilities.SetColumns("bitPorcentaje", ChkPorcentaje.Checked);

            // Dependiendo de si es una actualización o una inserción
            if (auxId != "0")
            {
                dataUtilities.UpdateRecordByPrimaryKey("Habitaciones", auxId);
            }
            else
            {
                auxId = Guid.NewGuid().ToString().Substring(0, 10);
                dataUtilities.SetColumns("SucursalId", Utilidades.SucursalId);
                dataUtilities.SetColumns("HabitacionId", auxId);
                dataUtilities.SetColumns("Estado", "Activo");
                dataUtilities.InsertRecord("Habitaciones");
            }

            foreach(PaqueteLista item in listNuevas)
            {
                dataUtilities.SetColumns("HabitacionId", auxId);
                dataUtilities.SetColumns("PaqueteId",item.idPaquete);
                dataUtilities.SetColumns("NombrePaquete", item.nombre);
                dataUtilities.SetColumns("Precio", item.precio);
                dataUtilities.SetColumns("Estado", "Activo");
                dataUtilities.InsertRecord("PaquetesHabitaciones");
            }

            this.Close();
        }

        // Permite solo números en el campo Cantidad
        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Se permite la tecla de control (como Backspace)
            if (char.IsControl(e.KeyChar))
                return;

            // Si el carácter no es dígito, se cancela el evento
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Permite números y un único punto decimal en el campo Costo
        private void TxtCostoxHabitacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite teclas de control (como Backspace)
            if (char.IsControl(e.KeyChar))
                return;

            // Permite dígitos numéricos
            if (char.IsDigit(e.KeyChar))
                return;

            // Permite un único punto decimal
            if (e.KeyChar == '.')
            {
                // Convertimos el sender a TextBox para poder validar el contenido actual
                TextBox txt = sender as TextBox;
                // Si ya existe un punto, se cancela el evento
                if (txt != null && txt.Text.Contains("."))
                {
                    e.Handled = true;
                }
                return;
            }

            // Si no se cumple ninguna de las condiciones, se cancela el evento
            e.Handled = true;
        }

        // Permite números y un único punto decimal en el campo Monto
        private void TxtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite teclas de control (como Backspace)
            if (char.IsControl(e.KeyChar))
                return;

            // Permite dígitos numéricos
            if (char.IsDigit(e.KeyChar))
                return;

            // Permite un único punto decimal
            if (e.KeyChar == '.')
            {
                TextBox txt = sender as TextBox;
                if (txt != null && txt.Text.Contains("."))
                {
                    e.Handled = true;
                }
                return;
            }

            // Si no se cumple ninguna de las condiciones, se cancela el evento
            e.Handled = true;
        }

        private void TxtMonto_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtPrecioPaquete_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite teclas de control (como Backspace)
            if (char.IsControl(e.KeyChar))
                return;

            // Permite dígitos numéricos
            if (char.IsDigit(e.KeyChar))
                return;

            // Permite un único punto decimal
            if (e.KeyChar == '.')
            {
                TextBox txt = sender as TextBox;
                if (txt != null && txt.Text.Contains("."))
                {
                    e.Handled = true;
                }
                return;
            }

            // Si no se cumple ninguna de las condiciones, se cancela el evento
            e.Handled = true;
        }

        private void BtnGuardarPaquetes_Click(object sender, EventArgs e)
        {
            // Validación del campo "Costo" (se espera un número decimal mayor que cero)
            decimal decCosto;
            if (!decimal.TryParse(TxtPrecioPaquete.Text, out decCosto) || decCosto <= 0)
            {
                MessageBox.Show("Ingrese un costo de paquete válido (número mayor a cero).", "Atención", MessageBoxButton.OK, MessageBoxImage.Warning);
                TxtPrecioPaquete.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtNombrePaquete.Text))
            {
                MessageBox.Show("Debe digitar el nombre del paquete de precios.", "Atención", MessageBoxButton.OK, MessageBoxImage.Warning);
                TxtNombrePaquete.Focus();
                return;
            }

            PaqueteLista paqueteNuevo = new PaqueteLista();
            paqueteNuevo.nombre = TxtNombrePaquete.Text;
            paqueteNuevo.precio = decCosto;
            paqueteNuevo.idPaquete = Guid.NewGuid().ToString().Substring(0, 10);

            listNuevas.Add(paqueteNuevo);

            dynamicDataTable.Rows.Add(paqueteNuevo.idPaquete,TxtNombrePaquete.Text,TxtPrecioPaquete.Text,"Activo");

            TxtNombrePaquete.Text = "";
            TxtPrecioPaquete.Text = "";
        }

        private void BtnBloquearPaquete_Click(object sender, EventArgs e)
        {
            if(DgvItemsPaquete.SelectedRows.Count > 0)
            {
                string clave = Convert.ToString(DgvItemsPaquete.SelectedRows[0].Cells[0].Value);
                string estado = Convert.ToString(DgvItemsPaquete.SelectedRows[0].Cells[3].Value) == "Activo" ? "Bloqueado" : "Activo";

                if (dataUtilities.getRecordByPrimaryKey("PaquetesHabitaciones", clave).Rows.Count == 0) {
                    MessageBox.Show("Antes de bloquear el paquete de precios seleccionado debe guardarlo", "Atención", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                    dataUtilities.SetColumns("Estado", estado);
                dataUtilities.UpdateRecordByPrimaryKey("PaquetesHabitaciones", clave);

                Buscar();
            }
            else
            {
                MessageBox.Show("No hay paquetes seleccionados.", "Atención", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
