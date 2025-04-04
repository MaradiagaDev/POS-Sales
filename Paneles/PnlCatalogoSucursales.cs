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
    public partial class PnlCatalogoSucursales : Form
    {

        public VMCatalogoSucursales vMCatalogoSucursales = new VMCatalogoSucursales();

        public PnlCatalogoSucursales()
        {
            InitializeComponent();
        }

        private void PnlCatalogoSucursales_Load(object sender, EventArgs e)
        {
            UIUtilities.PersonalizarDataGridView(dgvCatalogoSucursales);
            UIUtilities.EstablecerFondo(this);
            UIUtilities.ConfigurarBotonBuscar(BtnBuscarCliente);
            UIUtilities.ConfigurarTextBoxBuscar(TxtFiltrar);
            UIUtilities.ConfigurarBotonCrear(btnAgregar);
            UIUtilities.ConfigurarBotonActualizar(btnActualizar);
            UIUtilities.ConfigurarTituloPantalla(TbTitulo, PnlTitulo);
            vMCatalogoSucursales.InitModuloCatalogoSucursales(this, "Buscar");
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            vMCatalogoSucursales.auxSearch = TxtFiltrar.Text;
            vMCatalogoSucursales.InitModuloCatalogoSucursales(this, "Buscar");
        }

        private void dgvCatalogoSucursales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 57))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (e.ColumnIndex == 0)
            {
                object cellValue = dgvCatalogoSucursales.Rows[e.RowIndex].Cells[1].Value;
                vMCatalogoSucursales.auxId = cellValue.ToString();
                vMCatalogoSucursales.FuncionesPrincipales(this, "Bloquear");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 55))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PnlAgregarSucursal frm = new PnlAgregarSucursal(this,"Crear","");
            frm.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 56))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvCatalogoSucursales.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCatalogoSucursales.SelectedRows[0];
                object cellValue = selectedRow.Cells[1].Value;

                if (cellValue != null)
                {
                    PnlAgregarSucursal frm = new PnlAgregarSucursal(this, "Modificar", cellValue.ToString());
                    frm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Sucursal.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
