using NeoCobranza.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles_Contrato
{
    public partial class PnlReciboColector : Form
    {
        public int idContrato;

        private Conexion conexion;
        public PnlReciboColector(int id,Conexion conexion)
        {
            InitializeComponent();
            this.idContrato = id;
            this.conexion = conexion;
        }

        private void PnlReciboColector_Load(object sender, EventArgs e)
        {
            try
                
            {
                //Conexion
                this.reporteria_ReciboColector1TableAdapter.Connection = conexion.connect;
                this.reporteria_ReciboColector2TableAdapter.Connection = conexion.connect;
                this.reporteria_ReciboColector3TableAdapter.Connection = conexion.connect;
                this.reporteria_ReciboColector5TableAdapter.Connection = conexion.connect;
                this.reporteria_ReciboColector4TableAdapter.Connection = conexion.connect;

                this.data_ReciboOficial.EnforceConstraints = false;
                // TODO: esta línea de código carga datos en la tabla 'data_ReciboOficial.Reporteria_ReciboColector1' Puede moverla o quitarla según sea necesario.
                this.reporteria_ReciboColector1TableAdapter.Fill(this.data_ReciboOficial.Reporteria_ReciboColector1, idContrato);
                // TODO: esta línea de código carga datos en la tabla 'data_ReciboOficial.Reporteria_ReciboColector2' Puede moverla o quitarla según sea necesario.
                this.reporteria_ReciboColector2TableAdapter.Fill(this.data_ReciboOficial.Reporteria_ReciboColector2, idContrato);
                // TODO: esta línea de código carga datos en la tabla 'data_ReciboOficial.Reporteria_ReciboColector3' Puede moverla o quitarla según sea necesario.
                this.reporteria_ReciboColector3TableAdapter.Fill(this.data_ReciboOficial.Reporteria_ReciboColector3, idContrato);
                // TODO: esta línea de código carga datos en la tabla 'data_ReciboOficial.Reporteria_ReciboColector5' Puede moverla o quitarla según sea necesario.
                this.reporteria_ReciboColector5TableAdapter.Fill(this.data_ReciboOficial.Reporteria_ReciboColector5, idContrato);
                // TODO: esta línea de código carga datos en la tabla 'data_ReciboOficial.Reporteria_ReciboColector4' Puede moverla o quitarla según sea necesario.
                this.reporteria_ReciboColector4TableAdapter.Fill(this.data_ReciboOficial.Reporteria_ReciboColector4);

                this.reportViewer1.RefreshReport();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(),"Error");
            }
        }
    }
}
