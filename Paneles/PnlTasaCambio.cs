using NeoCobranza.Data;
using NeoCobranza.DataController;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.TcController;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NeoCobranza.Paneles
{
    public partial class PnlTasaCambio : Form
    {
        Conexion conexion;
        CTasaCambio cTasaCambio;
        List<Cambio> listaCambio;
        public PnlTasaCambio(Conexion conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
            cTasaCambio = new CTasaCambio(conexion);
        }
        private async void PnlTasaCambio_Load(object sender, EventArgs e)
        {
            //Obtener mediante la api
            double cambioDia = await ControlladorTC.CambioDia(DateTime.Now);
            LBTasaActual.Text = cambioDia.ToString() + " C$ (BANCO CENTRAL ON LINE)";

            DateTime fechaActual = DateTime.Now;
            List<Cambio> listaCambio = await ControlladorTC.CambioMes(fechaActual);
            this.listaCambio = listaCambio;
            // Llenar el DataGridView con los datos de la listaCambio
            DGVTasas.DataSource = listaCambio;
            //Verificar que la fecha de hoy este en la tabla
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                List<TipoCambio> list = db.TipoCambio.Where(t => t.FechaCambio.Equals(DateTime.Today)).ToList();

                if(list.Count == 0)
                {
                    LBDinEstado.ForeColor = Color.Red;
                    LBDinEstado.Text = "No se ha insertado este mes.";
                }
                else
                {
                    LBDinEstado.ForeColor = Color.Green;
                    LBDinEstado.Text = "Las tasas del mes están en el sistema.";
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
           
        }

        private async void BtnAgregarArchivo_Click(object sender, EventArgs e)
        {
            if (LBDinEstado.Text == "No se ha insertado este mes.")
            {
                using (NeoCobranzaContext db = new NeoCobranzaContext())
                {
                    List<TipoCambio> listaTipoCambio = listaCambio.Select(cambio => new TipoCambio
                    { // Asigna el valor adecuado a IdTasaCambio según tu lógica
                        Tasa = double.Parse(cambio.CambioDia),
                        FechaCambio = DateTime.Parse(cambio.Fecha)
                    }).ToList();
                    foreach (TipoCambio t in listaTipoCambio)
                    {
                        db.TipoCambio.Add(t);
                    }
                    db.SaveChanges();
                    LBDinEstado.ForeColor = Color.Green;
                    LBDinEstado.Text = "Las tasas del mes están en el sistema.";
                }
            }
            else
            {
                MessageBox.Show("Las tasas del mes ya están en el sistema.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       
    }
}
