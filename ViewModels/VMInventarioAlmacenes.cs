using NeoCobranza.Clases;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NeoCobranza.ViewModels.VMInventarioGeneral;

namespace NeoCobranza.ViewModels
{
    public class VMInventarioAlmacenes
    {
        PnlInventarioAlmacenes auxFrm;
        DataUtilities dataUtilities = new DataUtilities();

        public void InitModuloInventarioAlmacenes(PnlInventarioAlmacenes frm)
        {
            auxFrm = frm;

            //Agregar Boton de Cambiar de estado
            DataGridViewButtonColumn BtnRealizarMerma = new DataGridViewButtonColumn();

            BtnRealizarMerma.Text = "Agregar Ajuste";
            BtnRealizarMerma.Name = "...";
            BtnRealizarMerma.UseColumnTextForButtonValue = true;
            BtnRealizarMerma.DefaultCellStyle.ForeColor = Color.Blue;
            frm.dgvCatalogo.Columns.Add(BtnRealizarMerma);

            DataTable dtResponse = dataUtilities.GetAllRecords("Categorizacion");
            var filterRow = from row in dtResponse.AsEnumerable() where Convert.ToString(row.Field<string>("Estado")) == "Activo" select row;

            if (filterRow.Any())
            {
                DataTable dataCmbTipoServicio = new DataTable();
                dataCmbTipoServicio = filterRow.CopyToDataTable();
                DataRow newRow = dataCmbTipoServicio.NewRow();
                newRow["CategorizacionId"] = "0";
                newRow["Descripcion"] = "Mostrar Todo";
                newRow["Estado"] = "Actio";

                dataCmbTipoServicio.Rows.InsertAt(newRow, 0);

                auxFrm.CmbBuscarPor.ValueMember = "CategorizacionId";
                auxFrm.CmbBuscarPor.DisplayMember = "Descripcion";
                auxFrm.CmbBuscarPor.DataSource = dataCmbTipoServicio;
            }

            //ALMACENES
            DataTable dtResponseAlmacenes = dataUtilities.GetAllRecords("Almacenes");
            var filterRowAlmacenes = from row in dtResponseAlmacenes.AsEnumerable() where Convert.ToString(row.Field<string>("Estatus")) == "Activo" select row;

            if (filterRowAlmacenes.Any())
            {
                DataTable dataCmbAlmacenes = new DataTable();
                dataCmbAlmacenes = filterRowAlmacenes.CopyToDataTable();
                DataRow newRow = dataCmbAlmacenes.NewRow();
                newRow[0] = "0";
                newRow[1] = "Mostrar Todo";
                newRow[2] = true;

                dataCmbAlmacenes.Rows.InsertAt(newRow, 0);

                auxFrm.CmbAlmacenes.ValueMember = "AlmacenId";
                auxFrm.CmbAlmacenes.DisplayMember = "NombreAlmacen";
                auxFrm.CmbAlmacenes.DataSource = dataCmbAlmacenes;
            }

                BuscarInventario();
        }

        public void BuscarInventario()
        {
            if (auxFrm.CmbAlmacenes.SelectedValue != null)
            {
                dataUtilities.SetParameter("@AlmacenId", auxFrm.CmbAlmacenes.SelectedValue);
                dataUtilities.SetParameter("@CategoriaId", auxFrm.CmbBuscarPor.SelectedValue);
                dataUtilities.SetParameter("@Filtro", auxFrm.TxtFiltrar.Text);
                auxFrm.dgvCatalogo.DataSource = dataUtilities.ExecuteStoredProcedure("sp_ObtenerCantidadProductoPorAlmacen");
            }
         
        }
    }
}
