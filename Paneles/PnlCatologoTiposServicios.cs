﻿using NeoCobranza.ViewModels;
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
    public partial class PnlCatologoTiposServicios : Form
    {
       public  VMCatalogoTiposServicio vMCatalogoTiposServicio = new VMCatalogoTiposServicio();

        public PnlCatologoTiposServicios()
        {
            InitializeComponent();
        }

        private void PnlCatologoTiposServicios_Load(object sender, EventArgs e)
        {
            dgvCatalogoTipos.EnableHeadersVisualStyles = false;
            dgvCatalogoTipos.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            dgvCatalogoTipos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCatalogoTipos.RowsDefaultCellStyle.Font = new Font("Century Gothic", 9);
            dgvCatalogoTipos.RowsDefaultCellStyle.BackColor = Color.White;
            vMCatalogoTiposServicio.auxBuscador = TxtFiltrar.Texts;
            vMCatalogoTiposServicio.InitModuloPnlCatalogoServicio(this,"Buscar");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            PnlAgregarTipo frm = new PnlAgregarTipo(this,"Crear","");
            frm.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if(dgvCatalogoTipos.Rows.Count > 0) {
                DataGridViewRow selectedRow = dgvCatalogoTipos.SelectedRows[0];
                object cellValue = selectedRow.Cells[1].Value;

                PnlAgregarTipo frm = new PnlAgregarTipo(this, "Actualizar", cellValue.ToString());
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay Tipos de Servicios agregados.","Atención",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            vMCatalogoTiposServicio.auxBuscador = TxtFiltrar.Texts;
            vMCatalogoTiposServicio.InitModuloPnlCatalogoServicio(this, "Buscar");
        }

        private void dgvCatalogoTipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                object cellValue = dgvCatalogoTipos.Rows[e.RowIndex].Cells[1].Value;
                vMCatalogoTiposServicio.auxId = cellValue.ToString();
                vMCatalogoTiposServicio.AccionesPrincipales(this, "Bloquear");
            }
        }
    }
}
