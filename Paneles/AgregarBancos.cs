using NeoCobranza.ModelsCobranza;
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
    public partial class AgregarBancos : Form
    {
        string auxKey = "";
        string auxOpc = "";
        public AgregarBancos(string opc, string key)
        {
            InitializeComponent();
            auxKey = key; auxOpc = opc;
        }

        private void AgregarBancos_Load(object sender, EventArgs e)
        {
            if (auxOpc == "Crear")
            {
                LblDynamico.Text = "Crear Banco";
                btnAgregar.Text = "Guardar";
            }
            else
            {
                using (NeoCobranzaContext db = new NeoCobranzaContext())
                {
                    Bancos banco = db.Bancos.Where(s => s.BancoId == int.Parse(auxKey)).FirstOrDefault();

                    if (banco != null)
                    {
                        TxtBanco.Text = banco.Banco;
                    }
                }

                LblDynamico.Text = $"Modificar Banco con ID: {auxKey}";
                btnAgregar.Text = "Modificar";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (TxtBanco.Text.Trim() == "")
            {
                MessageBox.Show("Debe digitar el Banco.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                if (auxOpc == "Crear")
                {
                    Bancos motivo = new Bancos()
                    {
                        Banco = TxtBanco.Text.Trim(),
                        Estado = "Activo"
                    };

                    db.Add(motivo);
                    db.SaveChanges();
                }
                else
                {
                    Bancos motivo = db.Bancos.Where(s => s.BancoId == int.Parse(auxKey)).FirstOrDefault();

                    if (motivo != null)
                    {
                        motivo.Banco = TxtBanco.Text.Trim();
                        db.Update(motivo);
                        db.SaveChanges();
                    }
                }

                this.Close();
            }
        }
    }
}
