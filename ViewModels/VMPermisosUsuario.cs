using NeoCobranza.Clases;
using NeoCobranza.DataController;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles_Auditorias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace NeoCobranza.ViewModels
{
    public class VMPermisosUsuario
    {
        public string auxRol;
        public int idRol;
        public string auxAccion;
        DataUtilities dataUtilities = new DataUtilities();
        public void InitGestionPermisosUsuario(GestionPermisos frm)
        {
            frm.TCMain.Appearance = TabAppearance.FlatButtons;
            frm.TCMain.SizeMode = TabSizeMode.Fixed;
            frm.TCMain.ItemSize = new System.Drawing.Size(1, 1); // Establece un tamaño mínimo

            ConfigUI(frm, "Buscar");
        }

        public void ConfigUI(GestionPermisos frm, string option)
        {
            switch (option)
            {
                case "Generales":
                    frm.TCMain.SelectedIndex = 2;
                    frm.TbTitulo.Text = "Gestión de Acceso Por Rol";
                    auxRol = frm.LvRol.SelectedRows[0].Cells[1].Value.ToString();
                    idRol = int.Parse(frm.LvRol.SelectedRows[0].Cells[0].Value.ToString());
                    CargarPermisos(frm);
                    Limpiar(frm, "Generales");
                    break;
                case "CrearRol":
                    auxAccion = "Crear";
                    frm.TCMain.SelectedIndex = 1;
                    frm.TbTitulo.Text = "Creación de Rol de Usuario";
                    frm.TxtNombrePermiso.Text = string.Empty;
                    break;
                case "ActualizarRol":
                    auxRol = frm.LvRol.SelectedRows[0].Cells[1].Value.ToString();
                    idRol = int.Parse(frm.LvRol.SelectedRows[0].Cells[0].Value.ToString());
                    auxAccion = "Actualizar";
                    frm.TCMain.SelectedIndex = 1;
                    frm.TbTitulo.Text = "Actualización de Rol de Usuario";
                    frm.TxtNombrePermiso.Text = auxRol;
                    break;
                case "Buscar":
                    frm.TbTitulo.Text = "Configuración de Permisos de Ususario.";
                    frm.TCMain.SelectedIndex = 0;
                    FuncionesPrincipales(frm, "Buscar");
                    break;
            }
        }

        public void VerificarRol(GestionPermisos frm)
        {
            if (frm.TxtNombrePermiso.Text.Trim() == "")
            {
                System.Windows.Forms.MessageBox.Show("No ha digitado un nombre para el rol.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FuncionesPrincipales(frm, "Rol");
        }

        public void FuncionesPrincipales(GestionPermisos frm, string option)
        {
            switch (option)
            {
                case "Buscar":


                    frm.LvRol.DataSource = dataUtilities.GetAllRecords("vwRoles");

                    break;
                case "Bloquear":
                    using (NeoCobranzaContext db = new NeoCobranzaContext())
                    {
                        if (frm.LvRol.SelectedRows.Count > 0)
                        {
                            RolUsuario rol = db.RolUsuario.Where(r => r.RolId == int.Parse(frm.LvRol.SelectedRows[0].Cells[0].Value.ToString())).FirstOrDefault();
                            rol.Estado = rol.Estado == "Activo" ? "Bloqueado" : "Activo";
                            db.Update(rol);
                            db.SaveChanges();
                            FuncionesPrincipales(frm, "Buscar");
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("No ha seleccionado un rol.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    break;
                case "GuardarGenerales":
                    using (NeoCobranzaContext db = new NeoCobranzaContext())
                    {
                        RolPermisos permisos = db.RolPermisos.Where(r => r.RolId == idRol).FirstOrDefault();
                        db.Update(permisos);
                        db.SaveChanges();
                        ConfigUI(frm, "Buscar");
                    }
                    break;
                case "Rol":

                    if (auxAccion == "Crear")
                    {
                        if(dataUtilities.getRecordByColumn("Roles", "NombreRol",frm.TxtNombrePermiso.Text).Rows.Count == 0)
                        {
                            dataUtilities.SetColumns("NombreRol", frm.TxtNombrePermiso.Text);
                            dataUtilities.InsertRecord("Roles");
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("El nombre del rol digitado ya existe.","Atención",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        }
                        
                    }
                    else
                    {
                        idRol = int.Parse(frm.LvRol.SelectedRows[0].Cells[0].Value.ToString());

                        dataUtilities.SetColumns("NombreRol", frm.TxtNombrePermiso.Text);
                        dataUtilities.UpdateRecordByPrimaryKey("Roles", idRol);
                    }
                    ConfigUI(frm, "Buscar");
                    break;
            }
        }

        public void CargarPermisos(GestionPermisos frm)
        {
            idRol = int.Parse(frm.LvRol.SelectedRows[0].Cells[0].Value.ToString());

            //Cargar todos los permisos
            frm.DTLvlUno.DataSource = dataUtilities.GetAllRecords("vwPermisosLvlUno");

            //Colocar columna 
            if (!frm.DTLvlUno.Columns.Contains("Seleccionado"))
            {
                DataGridViewCheckBoxColumn chkCol = new DataGridViewCheckBoxColumn();
                chkCol.Name = "Seleccionado";
                chkCol.HeaderText = "Seleccionar";
                frm.DTLvlUno.Columns.Insert(0, chkCol);
            }

            //Cargar los permisos Actuales
            dataUtilities.SetParameter("@IdRol", idRol);
            DataTable dataResponse = dataUtilities.ExecuteStoredProcedure("spGetPermisosLvlUnoRol");

            HashSet<int> permisosAsignados = new HashSet<int>();
            foreach (DataRow dr in dataResponse.Rows)
            {
                // Se asume que la tabla tiene la columna "IdPermisoLvlUno"
                permisosAsignados.Add(Convert.ToInt32(dr["IdPermisoLvlUno"]));
            }

            foreach (DataGridViewRow row in frm.DTLvlUno.Rows)
            {
                // Se asume que la vista "vwPermisosLvlUno" incluye la columna "IdPermisoLvlUno"
                int idPermiso = Convert.ToInt32(row.Cells["Clave"].Value);

                if (permisosAsignados.Contains(idPermiso))
                {
                    row.Cells["Seleccionado"].Value = true;
                }
                else
                {
                    row.Cells["Seleccionado"].Value = false; // Opcional: para dejarlo en false si no está asignado
                }
            }
        }

        public void Limpiar(GestionPermisos frm, string option)
        {
            switch (option)
            {
                case "Generales":
                    //Catalogo

                    break;
            }
        }

    }
}
