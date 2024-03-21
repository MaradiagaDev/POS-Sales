using NeoCobranza.ModelsCobranza;
using OfficeOpenXml.Drawing.Chart;
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
    public partial class PnlEmpresa : Form
    {
        int auxEmpresa = 0;
        public PnlEmpresa()
        {
            InitializeComponent();
        }

        private void PnlEmpresa_Load(object sender, EventArgs e)
        {
            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                Empresa empresa = db.Empresa.FirstOrDefault();

                if (empresa != null)
                {
                   TxtNombreComercial.Text = empresa.NombreComercial ;
                   TxtNombreEmpresa.Text = empresa.NombreEmpresa;
                   TxtTelefono.Text = empresa.Telefono;
                   TxtNoRuc.Text = empresa.Ruc;
                   TxtEmail.Text = empresa.Email;
                   TxtDireccion.Text = empresa.Direccion;

                    auxEmpresa = empresa.IdEmpresa;
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
                MessageBox.Show("El nombre comercial de la empresa no puede estar vacío.","Atención",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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

            if (TxtDireccion.Text.Trim().Length == 0)
            {
                MessageBox.Show("La dirección no puede estar vacía.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                if (auxEmpresa == 0)
                {
                    Empresa empresa = new Empresa()
                    {
                        NombreComercial = TxtNombreComercial.Text,
                        NombreEmpresa = TxtNombreEmpresa.Text,
                        Telefono = TxtTelefono.Text,
                        Ruc = TxtNoRuc.Text,
                        Email = TxtEmail.Text,
                        Direccion = TxtDireccion.Text
                    };

                    db.Add(empresa);
                    db.SaveChanges();

                    MessageBox.Show("La empresa ha sido creada correctamente.","Correcto",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Empresa empresa = db.Empresa.Where(s => s.IdEmpresa == auxEmpresa).FirstOrDefault();
                    empresa.NombreComercial = TxtNombreComercial.Text;
                    empresa.NombreEmpresa = TxtNombreEmpresa.Text;
                    empresa.Telefono = TxtTelefono.Text;
                    empresa.Ruc = TxtNoRuc.Text;
                    empresa.Email = TxtEmail.Text;
                    empresa.Direccion = TxtDireccion.Text;

                    db.Update(empresa);
                    db.SaveChanges();

                    MessageBox.Show("La empresa ha sido actualizada correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }           
        }
    }
}
