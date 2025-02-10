using NeoCobranza.Clases;
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
    public partial class PnlAsistencia : Form
    {
        DateTime dateMarcado= DateTime.Now;
        DataUtilities dataUtilities = new DataUtilities();
        public PnlAsistencia()
        {
            InitializeComponent();
        }

        private void PnlAsistencia_Load(object sender, EventArgs e)
        {
            LblUsuario.Text = $"Usuario: {Utilidades.Usuario}";
        }

        private void BtnEntrada_Click(object sender, EventArgs e)
        {
            dataUtilities.SetParameter("@UsuarioID", Utilidades.IdUsuario);
            dataUtilities.SetParameter("@SucursalID", Utilidades.SucursalId);
            dataUtilities.SetParameter("@Accion", "entrada");
            DataTable dataresponse = dataUtilities.ExecuteStoredProcedure("sp_MarcarAsistencia");

            MessageBox.Show(dataresponse.Rows[0][0].ToString());

            this.Close();
        }

        private void BtnSalida_Click(object sender, EventArgs e)
        {
            dataUtilities.SetParameter("@UsuarioID", Utilidades.IdUsuario);
            dataUtilities.SetParameter("@SucursalID", Utilidades.SucursalId);
            dataUtilities.SetParameter("@Accion", "salida");
            DataTable dataresponse = dataUtilities.ExecuteStoredProcedure("sp_MarcarAsistencia");

            MessageBox.Show(dataresponse.Rows[0][0].ToString());
            this.Close();
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
