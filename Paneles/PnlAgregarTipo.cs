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
    public partial class PnlAgregarTipo : Form
    {
        PnlCatologoTiposServicios frmPrincipal;
        string auxOpc;
        string auxId;

        public PnlAgregarTipo(PnlCatologoTiposServicios frm,string opc,string id)
        {
            InitializeComponent();
            this.frmPrincipal = frm;
            this.auxId = id;
            this.auxOpc = opc;
        }

        private void PnlAgregarTipo_Load(object sender, EventArgs e)
        {
            if(this.auxOpc != "Crear")
            {
                using (NeoCobranzaContext db = new NeoCobranzaContext())
                {
                    this.btnAgregar.Text = "Actualizar";

                    TipoServicios tipo = db.TipoServicios.Where(c => c.TipoServicionId == int.Parse(this.auxId)).FirstOrDefault();
                    if (tipo != null)
                    {
                        this.TxtNombreTipo.Text = tipo.Descripcion;
                    }
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(TxtNombreTipo.Text.Trim().Length == 0) 
            { 
               MessageBox.Show("El nombre del tipo no puede estar en blanco.","Atención",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            if (TxtNombreTipo.Text.Trim().Length >50)
            {
                MessageBox.Show("El nombre del tipo no puede tener más de 50 caracteres.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                if (this.auxOpc == "Crear")
                {
                    TipoServicios tipo = new TipoServicios()
                    {
                        Descripcion = TxtNombreTipo.Text.Trim(),
                        Estado = "Activo"
                    };

                    db.Add(tipo);
                    db.SaveChanges();
                }
                else
                {
                    TipoServicios tipo = db.TipoServicios.Where(c => c.TipoServicionId == int.Parse(this.auxId)).FirstOrDefault();
                    tipo.Descripcion = TxtNombreTipo.Text.Trim();
                    db.Update(tipo);
                    db.SaveChanges();
                }

                frmPrincipal.vMCatalogoTiposServicio.InitModuloPnlCatalogoServicio(frmPrincipal, "Buscar");
                this.Dispose();
             
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
