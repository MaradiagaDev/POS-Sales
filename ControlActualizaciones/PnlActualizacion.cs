using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.ControlActualizaciones
{
    public partial class PnlActualizacion : Form
    {
        string archivo;
        string ruta;
        public PnlActualizacion( string archivo,string ruta)
        {
            InitializeComponent();
            this.archivo = archivo;
            this.ruta = ruta;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"\\192.168.1.68\versionesneocobranza\" + archivo + @"\setup.exe");
            }catch (Exception ex) { }
            //\Cobranza-AnyCPU_Debug-SetupFiles\Cobranza.msi
        }
    }
}
