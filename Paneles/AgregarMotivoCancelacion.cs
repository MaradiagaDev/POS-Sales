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
    public partial class AgregarMotivoCancelacion : Form
    {
        string auxKey = "";
        string auxOpc = "";
        public AgregarMotivoCancelacion(string opc,string key)
        {
            InitializeComponent();
            auxKey = key;
            auxOpc = opc;
        }

        private void AgregarMotivoCancelacion_Load(object sender, EventArgs e)
        {
            if (auxOpc == "Crear")
            {
                LblDynamico.Text = "Crear Motivo Cancelación";
                btnAgregar.Text = "Guardar";
            } 
            else 
            {
                using(NeoCobranzaContext db = new NeoCobranzaContext())
                {
                    MotivosCancelacion motivo = db.MotivosCancelacion.Where(s => s.MotivoCancelacionId == int.Parse(auxKey)).FirstOrDefault();

                    if (motivo != null)
                    {
                        TxtMotivoCancelacion.Text = motivo.Motivo;
                    }
                }

                LblDynamico.Text = $"Modificar Motivo Cancelación con ID: {auxKey}";
                btnAgregar.Text = "Modificar";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(TxtMotivoCancelacion.Text.Trim() == "")
            {
                MessageBox.Show("Debe digitar el motivo de cancelación.","Atención",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                if (auxOpc == "Crear")
                {
                    MotivosCancelacion motivo = new MotivosCancelacion()
                    {
                        Motivo = TxtMotivoCancelacion.Text.Trim(),
                        Estado = "Activo"
                    };

                    db.Add(motivo);
                    db.SaveChanges();
                }
                else
                {
                    MotivosCancelacion  motivo = db.MotivosCancelacion.Where(s => s.MotivoCancelacionId == int.Parse(auxKey)).FirstOrDefault();

                    if(motivo != null)
                    {
                        motivo.Motivo = TxtMotivoCancelacion.Text.Trim();
                        db.Update(motivo);
                        db.SaveChanges();
                    }
                }

                this.Close();
            }
        }
    }
}
