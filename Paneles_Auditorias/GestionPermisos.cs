using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
        DataUtilities dataUtilities = new DataUtilities();
        VMPermisosUsuario vMPermisosUsuario = new VMPermisosUsuario();

        public GestionPermisos()
        {
            InitializeComponent();

            UIUtilities.PersonalizarDataGridViewPequeños(DTLvlUno);
            UIUtilities.PersonalizarDataGridViewPequeños(DtLvlDos);
            UIUtilities.PersonalizarDataGridViewPequeños(DtLvlTres);


            AjustarDataGridViews();
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

        private void GestionPermisos_Resize(object sender, EventArgs e)
        {
            AjustarDataGridViews();
        }

        // Asegúrate de declarar estos labels a nivel de clase, por ejemplo:
        Label lblNivelUno = new Label();
        Label lblNivelDos = new Label();
        Label lblNivelTres = new Label();

        private void AjustarDataGridViews()
        {
            int padding = 10;         // Espacio entre elementos
            int labelHeight = 25;     // Altura de los labels
            int totalWidth = this.ClientSize.Width - (padding * 4); // Espacio total restando padding
            int division = totalWidth / 3; // Dividimos en 3 partes iguales

            // Agregar los labels al formulario si aún no están
            if (!this.Controls.Contains(lblNivelUno))
            {
                this.Controls.Add(lblNivelUno);
            }
            if (!this.Controls.Contains(lblNivelDos))
            {
                this.Controls.Add(lblNivelDos);
            }
            if (!this.Controls.Contains(lblNivelTres))
            {
                this.Controls.Add(lblNivelTres);
            }

            // Configuración de los labels
            lblNivelUno.Text = "PERMISOS NIVEL UNO";
            lblNivelDos.Text = "PERMISOS NIVEL DOS";
            lblNivelTres.Text = "PERMISOS NIVEL TRES";

            lblNivelUno.Font = new Font("Arial", 12, FontStyle.Bold);
            lblNivelDos.Font = new Font("Arial", 12, FontStyle.Bold);
            lblNivelTres.Font = new Font("Arial", 12, FontStyle.Bold);

            lblNivelUno.ForeColor = Color.White;
            lblNivelDos.ForeColor = Color.White;
            lblNivelTres.ForeColor = Color.White;

            lblNivelUno.TextAlign = ContentAlignment.MiddleCenter;
            lblNivelDos.TextAlign = ContentAlignment.MiddleCenter;
            lblNivelTres.TextAlign = ContentAlignment.MiddleCenter;

            // Posicionar y dimensionar los labels
            lblNivelUno.Width = division;
            lblNivelUno.Height = labelHeight;
            lblNivelUno.Left = padding;
            lblNivelUno.Top = padding;

            lblNivelDos.Width = division;
            lblNivelDos.Height = labelHeight;
            // Posicionar lblNivelDos a la derecha de DTLvlUno (o bien calcular en base a padding y division)
            lblNivelDos.Left = lblNivelUno.Right + padding;
            lblNivelDos.Top = padding;

            lblNivelTres.Width = division;
            lblNivelTres.Height = labelHeight;
            // Posicionar lblNivelTres a la derecha de lblNivelDos
            lblNivelTres.Left = lblNivelDos.Right + padding;
            lblNivelTres.Top = padding;

            // Asegurarse de que los labels estén en frente
            lblNivelUno.BringToFront();
            lblNivelDos.BringToFront();
            lblNivelTres.BringToFront();

            // Configurar los DataGridView debajo de cada label
            // DataGridView Nivel Uno
            DTLvlUno.Width = division;
            DTLvlUno.Left = padding;
            DTLvlUno.Top = lblNivelUno.Bottom + padding;

            // DataGridView Nivel Dos
            DtLvlDos.Width = division;
            DtLvlDos.Left = DTLvlUno.Right + padding;
            DtLvlDos.Top = lblNivelDos.Bottom + padding;

            // DataGridView Nivel Tres
            DtLvlTres.Width = division;
            DtLvlTres.Left = DtLvlDos.Right + padding;
            DtLvlTres.Top = lblNivelTres.Bottom + padding;

            if (TCMain.SelectedIndex == 2)
            {
                lblNivelUno.Visible = true;
                lblNivelDos.Visible = true;
                lblNivelTres.Visible = true;
            }
            else
            {
                lblNivelUno.Visible = false;
                lblNivelDos.Visible = false;
                lblNivelTres.Visible = false;
            }
        }

        //GESTION DE PERMISOS LEVEL UNO

        private void DTLvlUno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DTLvlUno.Columns[e.ColumnIndex].Name == "Seleccionado")
            {
                DTLvlUno.EndEdit();
            }
        }

        private void DTLvlUno_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DTLvlUno.Columns[e.ColumnIndex].Name == "Seleccionado")
            {
                DataGridViewRow row = DTLvlUno.Rows[e.RowIndex];

                // Capturar el valor actualizado del checkbox
                bool seleccionado = Convert.ToBoolean(row.Cells["Seleccionado"].Value);
                string permisoSeleccionado = Convert.ToString(row.Cells[1].Value);

                dataUtilities.SetParameter("@IdRol",vMPermisosUsuario.idRol);
                dataUtilities.SetParameter("@IdPermiso", permisoSeleccionado);
                dataUtilities.SetParameter("@Nivel",1);
                dataUtilities.SetParameter("@Activar",seleccionado);

                dataUtilities.ExecuteStoredProcedure("spActualizarPermisoRol");
            }
        }

        private void DTLvlUno_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DTLvlUno.Rows[e.RowIndex];
                string permisoSeleccionado = Convert.ToString(row.Cells[1].Value);

                // 🔹 Limpiar la DataGridView antes de cargar nuevos datos
                DtLvlDos.DataSource = null;
                DtLvlDos.Rows.Clear();
                DtLvlDos.Columns.Clear(); // Eliminamos las columnas para evitar duplicados

                // 🔹 Agregar columna de CheckBox solo si no existe
                DataGridViewCheckBoxColumn chkCol = new DataGridViewCheckBoxColumn
                {
                    Name = "Seleccionado",
                    HeaderText = "Seleccionar"
                };
                DtLvlDos.Columns.Insert(0, chkCol);

                // 🔹 Ejecutar procedimiento almacenado con el nuevo permiso seleccionado
                dataUtilities.SetParameter("@idPermisosLvlUno", permisoSeleccionado);
                DtLvlDos.DataSource = dataUtilities.ExecuteStoredProcedure("sPPermisosLvlDos");

                // 🔹 Refrescar la tabla después de asignar los datos
                DtLvlDos.Refresh();

                vMPermisosUsuario.CargarPermisosDos(this);
            }
        }

        //GESTION DE PERMISOS LEVEL DOS

        private void DtLvlDos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DtLvlDos.Columns[e.ColumnIndex].Name == "Seleccionado")
            {
                DtLvlDos.EndEdit();
            }
        }

        private void DtLvlDos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DtLvlDos.Columns[e.ColumnIndex].Name == "Seleccionado")
            {
                DataGridViewRow row = DtLvlDos.Rows[e.RowIndex];

                // Capturar el valor actualizado del checkbox
                bool seleccionado = Convert.ToBoolean(row.Cells["Seleccionado"].Value);
                string permisoSeleccionado = Convert.ToString(row.Cells[1].Value);

                dataUtilities.SetParameter("@IdRol", vMPermisosUsuario.idRol);
                dataUtilities.SetParameter("@IdPermiso", permisoSeleccionado);
                dataUtilities.SetParameter("@Nivel", 2);
                dataUtilities.SetParameter("@Activar", seleccionado);

                dataUtilities.ExecuteStoredProcedure("spActualizarPermisoRol");
            }
        }

        private void DtLvlDos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DtLvlDos.Rows[e.RowIndex];
                string permisoSeleccionado = Convert.ToString(row.Cells[1].Value);

                // 🔹 Limpiar la DataGridView antes de cargar nuevos datos
                DtLvlTres.DataSource = null;
                DtLvlTres.Rows.Clear();
                DtLvlTres.Columns.Clear(); // Eliminamos las columnas para evitar duplicados

                // 🔹 Agregar columna de CheckBox solo si no existe
                DataGridViewCheckBoxColumn chkCol = new DataGridViewCheckBoxColumn
                {
                    Name = "Seleccionado",
                    HeaderText = "Seleccionar"
                };
                DtLvlTres.Columns.Insert(0, chkCol);

                // 🔹 Ejecutar procedimiento almacenado con el nuevo permiso seleccionado
                dataUtilities.SetParameter("@idPermisosLvlDos", permisoSeleccionado);
                DtLvlTres.DataSource = dataUtilities.ExecuteStoredProcedure("sPPermisosLvlTres");

                // 🔹 Refrescar la tabla después de asignar los datos
                DtLvlTres.Refresh();

                vMPermisosUsuario.CargarPermisosTres(this);
            }
        }

        private void DtLvlTres_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DtLvlTres.Columns[e.ColumnIndex].Name == "Seleccionado")
            {
                DtLvlDos.EndEdit();
            }
        }

        private void DtLvlTres_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DtLvlTres.Columns[e.ColumnIndex].Name == "Seleccionado")
            {
                DataGridViewRow row = DtLvlTres.Rows[e.RowIndex];

                // Capturar el valor actualizado del checkbox
                bool seleccionado = Convert.ToBoolean(row.Cells["Seleccionado"].Value);
                string permisoSeleccionado = Convert.ToString(row.Cells[1].Value);

                dataUtilities.SetParameter("@IdRol", vMPermisosUsuario.idRol);
                dataUtilities.SetParameter("@IdPermiso", permisoSeleccionado);
                dataUtilities.SetParameter("@Nivel", 3);
                dataUtilities.SetParameter("@Activar", seleccionado);

                dataUtilities.ExecuteStoredProcedure("spActualizarPermisoRol");
            }
        }

        private void TCMain_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void TCMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TCMain.SelectedIndex == 2)
            {
                lblNivelUno.Visible = true;
                lblNivelDos.Visible = true;
                lblNivelTres.Visible = true;
            }
            else
            {
                lblNivelUno.Visible = false;
                lblNivelDos.Visible = false;
                lblNivelTres.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vMPermisosUsuario.ConfigUI(this, "Buscar");
        }
    }
}
