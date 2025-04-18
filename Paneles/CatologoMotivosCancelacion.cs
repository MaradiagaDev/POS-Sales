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
    public partial class CatologoMotivosCancelacion : Form
    {
        VMMotivosCancelacion vMMotivosCancelacion = new VMMotivosCancelacion();

        public CatologoMotivosCancelacion()
        {
            InitializeComponent();
        }

        private void CatologoMotivosCancelacion_Load(object sender, EventArgs e)
        {
            UIUtilities.PersonalizarDataGridView(dgvCatalogo);
            UIUtilities.EstablecerFondo(this);
            UIUtilities.ConfigurarBotonBuscar(BtnBuscar);
            UIUtilities.ConfigurarTextBoxBuscar(TxtFiltrar);
            UIUtilities.ConfigurarBotonCrear(btnAgregar);
            UIUtilities.ConfigurarBotonActualizar(btnActualizar);
            UIUtilities.ConfigurarTituloPantalla(TbTitulo, PnlTitulo);
            vMMotivosCancelacion.InitModuloMotivosCancelacion(this);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            vMMotivosCancelacion.FuncionesPrincipales(this, "Buscar", "");
        }

        private void dgvCatalogo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 60))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (e.ColumnIndex == 0)
            {
                object cellValue = dgvCatalogo.Rows[e.RowIndex].Cells[1].Value;
                vMMotivosCancelacion.FuncionesPrincipales(this, "Bloquear", cellValue.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 58))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AgregarMotivoCancelacion motivoCancelacion = new AgregarMotivoCancelacion("Crear", "");
            motivoCancelacion.ShowDialog();
            vMMotivosCancelacion.FuncionesPrincipales(this, "Buscar", "");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 59))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvCatalogo.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCatalogo.SelectedRows[0];
                object cellValue = selectedRow.Cells[1].Value;

                if (cellValue != null)
                {
                    AgregarMotivoCancelacion motivoCancelacion = new AgregarMotivoCancelacion("Modificar", cellValue.ToString());
                    motivoCancelacion.ShowDialog();
                    vMMotivosCancelacion.FuncionesPrincipales(this, "Buscar", "");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Almacén.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
