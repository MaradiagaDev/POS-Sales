using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.ViewModels
{
    public class VMCatalogosInventario
    {
        DataUtilities dataUtilities = new DataUtilities();

        public string auxOpc;
        public string auxId;
        public CatalogosInventario auxFrm;
        DataTable dynamicDataTable = new DataTable();

        public void InitModuloCatalogosInventario(CatalogosInventario frm, string opc)
        {
            this.auxOpc = opc;
            this.auxFrm = frm;

            switch (opc)
            {
                case "Productos":
                    frm.TbTitulo.Text = "Catalogo de Productos";
                    frm.btnActualizar.Text = "Actualizar Producto";
                    frm.btnAgregar.Text = "Agregar Producto";
                    break;
                case "Servicios":
                    frm.TbTitulo.Text = "Catalogo de Servicios";
                    frm.btnActualizar.Text = "Actualizar Servicio";
                    frm.btnAgregar.Text = "Agregar Servicio";
                    break;
            }

            ConfigUI(frm);
        }

        public void ConfigUI(CatalogosInventario frm)
        {
            switch (auxOpc)
            {
                case "Productos":

                    if (dynamicDataTable.Columns.Count == 0)
                    {
                        //Agregar Boton de Cambiar de estado
                        DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

                        BtnCambioEstado.Text = "Cambiar Estado";
                        BtnCambioEstado.Name = "...";
                        BtnCambioEstado.UseColumnTextForButtonValue = true;
                        BtnCambioEstado.DefaultCellStyle.ForeColor = Color.Blue;
                        frm.dgvCatalogo.Columns.Add(BtnCambioEstado);

                        // Definir las columnas
                        dynamicDataTable.Columns.Add("Id", typeof(string));
                        dynamicDataTable.Columns.Add("Nombre del Producto", typeof(string));
                        dynamicDataTable.Columns.Add("Estado", typeof(string));
                        dynamicDataTable.Columns.Add("Precio", typeof(string));
                        dynamicDataTable.Columns.Add("Categoría", typeof(string));
                    }
                    break;

                case "Servicios":
                    if (dynamicDataTable.Columns.Count == 0)
                    {

                        //Agregar Boton de Cambiar de estado
                        DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

                        BtnCambioEstado.Text = "Cambiar Estado";
                        BtnCambioEstado.Name = "...";
                        BtnCambioEstado.UseColumnTextForButtonValue = true;
                        BtnCambioEstado.DefaultCellStyle.ForeColor = Color.Blue;
                        frm.dgvCatalogo.Columns.Add(BtnCambioEstado);

                        // Definir las columnas
                        dynamicDataTable.Columns.Add("Id", typeof(string));
                        dynamicDataTable.Columns.Add("Nombre del Servicio", typeof(string));
                        dynamicDataTable.Columns.Add("Estado", typeof(string));
                        dynamicDataTable.Columns.Add("Precio", typeof(string));
                        dynamicDataTable.Columns.Add("Categoría", typeof(string));
                    }
                    break;
            }

            FuncionesPrincipales(frm, "Buscar");
        }

        public void FuncionesPrincipales(CatalogosInventario frm, string opc)
        {
            if (opc == "Bloquear")
            {
                DataTable dtRespuesta = dataUtilities.getRecordByPrimaryKey("ProductosServicios", auxId);
                string statusActual = Convert.ToString(dtRespuesta.Rows[0]["Estado"]) == "Activo" ? "Bloqueado" : "Activo";

                dataUtilities.SetColumns("Estado", statusActual);
                dataUtilities.UpdateRecordByPrimaryKey("ProductosServicios", auxId);

                FuncionesPrincipales(frm, "Buscar");
            }

            if (opc == "Buscar")
            {
                dynamicDataTable.Rows.Clear();

                DataTable dtResponse = dataUtilities.getRecordByColumn("ProductosServicios", "ClasificacionProducto", auxOpc);

                foreach(DataRow row in dtResponse.Rows)
                {
                    DataTable dtResponseCategoria = dataUtilities.getRecordByPrimaryKey("Categorizacion", Convert.ToString(row["CategoriaId"]));

                    dynamicDataTable.Rows.Add(Convert.ToString(row["ProductoId"]),
                        Convert.ToString(row["NombreProducto"]),
                        Convert.ToString(row["Estado"]),
                        Convert.ToString(row["Precio"]),
                        Convert.ToString(dtResponseCategoria.Rows[0]["Descripcion"]));
                }

                frm.dgvCatalogo.DataSource = dynamicDataTable;
            }
        }

    }
}
