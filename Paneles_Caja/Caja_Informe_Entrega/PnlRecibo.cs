﻿using NeoCobranza.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles_Caja.Caja_Informe_Entrega
{
    public partial class PnlRecibo : Form
    {
        public int id;
        private Conexion conexion;
        public PnlRecibo( int id,Conexion conexion)
        {

            InitializeComponent();
            this.conexion = conexion;

            this.id = id;
        }

        private void PnlRecibo_Load(object sender, EventArgs e)
        {
            //COnexion
            this.caja_CordobaTableAdapter.Connection = conexion.connect;
            this.caja_OtrosPagosTableAdapter.Connection = conexion.connect;
            this.caja_Reporte_EntregaTableAdapter.Connection = conexion.connect;


            // TODO: esta línea de código carga datos en la tabla 'data_ReciboOficial.Caja_Cordoba' Puede moverla o quitarla según sea necesario.
            this.caja_CordobaTableAdapter.Fill(this.data_ReciboOficial.Caja_Cordoba,id);
            // TODO: esta línea de código carga datos en la tabla 'data_ReciboOficial.Caja_OtrosPagos' Puede moverla o quitarla según sea necesario.
            this.caja_OtrosPagosTableAdapter.Fill(this.data_ReciboOficial.Caja_OtrosPagos,id);
            // TODO: esta línea de código carga datos en la tabla 'data_ReciboOficial.Caja_Reporte_Entrega' Puede moverla o quitarla según sea necesario.
            this.caja_Reporte_EntregaTableAdapter.Fill(this.data_ReciboOficial.Caja_Reporte_Entrega,id);

            this.reportViewer1.RefreshReport();
        }
    }
}
