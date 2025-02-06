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

namespace NeoCobranza.Paneles_Venta
{
    public partial class PnlAgenda : Form
    {
        DataUtilities dataUtilities = new DataUtilities();
        public PnlAgenda()
        {
            InitializeComponent();
        }

        private void PnlAgenda_Load(object sender, EventArgs e)
        {
            UIUtilities.PersonalizarDataGridView(DgvItemsCitas);

            //Cargar los usuarios
            dataUtilities.SetParameter("@IdSucursal", Utilidades.SucursalId);
            CmbUsuarios.DataSource = dataUtilities.ExecuteStoredProcedure("sp_ObtenerUsuariosPorSucursal");
            CmbUsuarios.DisplayMember = "UsuarioNombreCompleto";
            CmbUsuarios.ValueMember = "Usuario";
            CmbUsuarios.SelectedIndex = 0;
        }
    }
}
