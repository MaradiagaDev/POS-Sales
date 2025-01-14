using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Informes.Informes_Formato_Ticket
{
    public partial class FrmFacturaTicket : Form
    {
        string _sucursal;
        decimal _ordem;
        public FrmFacturaTicket(string sucusar, decimal orden)
        {
            InitializeComponent();
            _sucursal = sucusar;
            _ordem = orden;
        }

        private void FrmFacturaTicket_Load(object sender, EventArgs e)
        {
            facturacionDataset.EnforceConstraints = false; // Deshabilita restricciones
            this.vwFacturaTicketTableAdapter.Fill(this.facturacionDataset.vwFacturaTicket, _sucursal, _ordem);


            this.reportViewer1.RefreshReport();
        }
    }
}
