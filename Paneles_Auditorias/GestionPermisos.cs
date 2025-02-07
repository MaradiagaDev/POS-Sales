using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles_Auditorias
{
    public partial class GestionPermisos : Form
    {

        VMPermisosUsuario vMPermisosUsuario = new VMPermisosUsuario();

        public GestionPermisos()
        {
            InitializeComponent();
        }

        private void GestionPermisos_Load(object sender, EventArgs e)
        {
            vMPermisosUsuario.InitGestionPermisosUsuario(this);
        }

        private void BtnBuscarPermisos_Click(object sender, EventArgs e)
        {
            vMPermisosUsuario.FuncionesPrincipales(this, "Buscar");
        }

        private void BtnBloquear_Click(object sender, EventArgs e)
        {
            vMPermisosUsuario.FuncionesPrincipales(this, "Bloquear");
        }

        private void BtnConfigurar_Click(object sender, EventArgs e)
        {
            if(LvRol.SelectedRows.Count > 0) {

                vMPermisosUsuario.ConfigUI(this, "Generales");
            }
            else
            {
                MessageBox.Show("No ha seleccionado un rol.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TIGeneral_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChkSeguridad_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChkPersonal_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChkCaja_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChkInventario_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChkCatalogos_Click(object sender, EventArgs e)
        {
           
        }

        private void ChkContratos_Click(object sender, EventArgs e)
        {
          
        }

        private void ChkVentas_Click(object sender, EventArgs e)
        {
            
        }

        private void ChkInventario_Click(object sender, EventArgs e)
        {
            
        }

        private void ChkCaja_Click(object sender, EventArgs e)
        {
            
        }

        private void ChkPersonal_Click(object sender, EventArgs e)
        {
           
        }

        private void ChkSeguridad_Click(object sender, EventArgs e)
        {
            
        }

        private void ChkOpciones_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnCancelarGenerales_Click(object sender, EventArgs e)
        {
            vMPermisosUsuario.ConfigUI(this, "Buscar");
        }

        private void BtnGuardarGenerales_Click(object sender, EventArgs e)
        {
            vMPermisosUsuario.FuncionesPrincipales(this, "GuardarGenerales");
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            vMPermisosUsuario.ConfigUI(this, "CrearRol");
        }

        private void BtnCancelarRol_Click(object sender, EventArgs e)
        {
            vMPermisosUsuario.ConfigUI(this, "Buscar");
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (LvRol.SelectedRows.Count > 0)
            {

                vMPermisosUsuario.ConfigUI(this, "ActualizarRol");
            }
            else
            {
                MessageBox.Show("No ha seleccionado un rol.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnGuardarRol_Click(object sender, EventArgs e)
        {
            vMPermisosUsuario.VerificarRol(this);
        }

        private void DTLvlUno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DTLvlUno.Columns[e.ColumnIndex].Name == "Seleccionado")
            {
                DataGridViewRow row = DTLvlUno.Rows[e.RowIndex];

                // Se obtiene el valor actual del checkbox (se utiliza null-coalescing para evitar errores)
                bool seleccionado = Convert.ToBoolean(row.Cells["Seleccionado"].Value ?? false);
                bool nuevoValor = !seleccionado;
                //row.Cells["Seleccionado"].Value = nuevoValor;
                //int idPermiso = Convert.ToInt32(row.Cells["IdPermisoLvlUno"].Value);
                //// Obtenemos el Id del rol actual (esto dependerá de cómo lo tengas definido en tu formulario)

                //if (nuevoValor)
                //{
                //    // Si se marcó el checkbox, se inserta el registro
                //    InsertarRolPermiso(idRol, idPermiso);
                //}
                //else
                //{
                //    // Si se desmarcó, se puede eliminar el registro (si lo deseas)
                //    EliminarRolPermiso(idRol, idPermiso);
                //}
            }
        }
    }
}
