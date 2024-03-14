using NeoCobranza.ModelsCobranza;
using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles
{
    public partial class AgregarSala : Form
    {
        string auxKey = "";
        string auxOpc = "";
        public AgregarSala(string opc, string key)
        {
            InitializeComponent();
            auxKey = key; auxOpc = opc;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AgregarSala_Load(object sender, EventArgs e)
        {
            if (auxOpc == "Crear")
            {
                LblDynamico.Text = "Crear Sala";
                btnAgregar.Text = "Guardar";
            }
            else
            {
                using (NeoCobranzaContext db = new NeoCobranzaContext())
                {
                    Salas salas = db.Salas.Where(s => s.SalaId == int.Parse(auxKey)).FirstOrDefault();

                    if (salas != null)
                    {
                        TxtNombreSala.Text = salas.NombreSala;
                        TxtNoMesas.Text = salas.NoMesas.ToString();
                    }
                }

                LblDynamico.Text = $"Modificar Sala con ID: {auxKey}";
                btnAgregar.Text = "Modificar";
            }
        }

        private void TxtNoMesas_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter ingresado es un número o una tecla de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número ni una tecla de control, cancelar el evento para evitar que se ingrese el carácter
                e.Handled = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (TxtNombreSala.Text.Trim() == "")
            {
                MessageBox.Show("Debe digitar el Nombre de la Sala.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TxtNoMesas.Text.Trim() == "")
            {
                MessageBox.Show("Debe digitar el No de Mesas en Sala.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (int.Parse(TxtNoMesas.Text.Trim()) <= 0)
            {
                MessageBox.Show("El No de Mesas en Sala debe ser mayor a cero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                if (auxOpc == "Crear")
                {
                    Salas salas = new Salas()
                    {
                        NombreSala = TxtNombreSala.Text.Trim(),
                        NoMesas = int.Parse(TxtNoMesas.Text),
                        SucursalId = int.Parse(Utilidades.SucursalId),
                        Estado = "Activo"
                    };

                    db.Add(salas);
                    db.SaveChanges();
                }
                else
                {
                    Salas salas = db.Salas.Where(s => s.SalaId == int.Parse(auxKey)).FirstOrDefault();

                    if (salas != null)
                    {
                        salas.NombreSala = TxtNombreSala.Text.Trim();
                        salas.NoMesas = int.Parse(TxtNoMesas.Text);
                        db.Update(salas);
                        db.SaveChanges();
                    }
                }

                this.Close();
            }
        }
    }
}
