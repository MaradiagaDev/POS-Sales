using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles_Venta;
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
    public partial class PnlCancelarOrden : Form
    {
        public DataTable dynamicDataTable = new DataTable();
        public string auxKey = string.Empty;
        PnlVentas auxFrm= null;

        public PnlCancelarOrden(string key,PnlVentas frm)
        {
            this.auxKey = key;
            this.auxFrm = frm;
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelarOrden_Click(object sender, EventArgs e)
        {
            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                Ordenes ordenes = db.Ordenes.Where(s => s.OrdenId == int.Parse(this.auxKey)).FirstOrDefault();

                ordenes.OrdenProceso = "Orden Cancelada";
                ordenes.MotivoCancelacion = TxtMotivoCancelacion.Text.Trim();
                db.Update(ordenes);
                db.SaveChanges();
            }

            MessageBox.Show("La orden ha sido Cancelada", "Correcto",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
            auxFrm.Close();
        }

        private void PnlCancelarOrden_Load(object sender, EventArgs e)
        {
            dynamicDataTable.Columns.Add("Lista Motivos", typeof(string));
            DgvItems.DataSource = dynamicDataTable;

            // Agregar una columna de botón
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "...";
            buttonColumn.Text = "Agregar";
            buttonColumn.UseColumnTextForButtonValue = true;
            DgvItems.Columns.Add(buttonColumn);

            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                var Motivos = db.MotivosCancelacion.Where(s => s.Estado == "Activo").ToList();

                foreach(var item in Motivos)
                {
                    dynamicDataTable.Rows.Add(item.Motivo);
                }
            }
        }

        private void DgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                object cellValue = DgvItems.Rows[e.RowIndex].Cells[0].Value;

                if (TxtMotivoCancelacion.Text.Trim() == "")
                {
                    TxtMotivoCancelacion.Text = $"{cellValue.ToString()}";
                }
                else
                {
                    TxtMotivoCancelacion.Text = $"{TxtMotivoCancelacion.Text} ,{cellValue.ToString()}";
                }
                
            }
        }
    }
}
