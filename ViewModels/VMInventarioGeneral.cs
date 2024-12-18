using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.ViewModels
{
    public class VMInventarioGeneral
    {

        DataUtilities dataUtilities = new DataUtilities();

        public class MostrarInventarioGeneral
        {
            public string ID { get; set; }
            public string Producto { get; set; }
            public string Cantidad { get; set; }
            public string CantidadMinima { get; set; }
            public string CantidadMaxima { get; set; }

        }

        public PnlRevisionInventario auxFrm;

        public void InitPantallaRevision(PnlRevisionInventario frm)
        {
            auxFrm = frm;

            DataTable dtResponse = dataUtilities.GetAllRecords("Categorizacion");
            var filterRow = from row in dtResponse.AsEnumerable() where Convert.ToString(row.Field<string>("Estado")) == "Activo" select row;

            if (filterRow.Any())
            {
                DataTable dataCmbTipoServicio = new DataTable();
                dataCmbTipoServicio = filterRow.CopyToDataTable();
                DataRow newRow = dataCmbTipoServicio.NewRow();
                newRow["CategorizacionId"] = "0"; 
                newRow["Descripcion"] = "Mostrar Todo"; 
                newRow["Estado"] = "Activo"; 

                dataCmbTipoServicio.Rows.InsertAt(newRow, 0);

                auxFrm.CmbBuscarPor.ValueMember = "CategorizacionId";
                auxFrm.CmbBuscarPor.DisplayMember = "Descripcion";
                auxFrm.CmbBuscarPor.DataSource = dataCmbTipoServicio;
            }

            // Obtiene todos los registros de la tabla Sucursal
            DataTable dtResponseSucursales = dataUtilities.GetAllRecords("Sucursal");

            // Filtra las filas donde el campo Estado sea "Activo"
            var filterRowSucursales = from row in dtResponseSucursales.AsEnumerable()
                            where Convert.ToString(row.Field<string>("Estado")) == "Activo"
                            select row;

            if (filterRowSucursales.Any())
            {
                // Crea un DataTable para los datos filtrados
                DataTable dataCmbSucursal = new DataTable();
                dataCmbSucursal = filterRowSucursales.CopyToDataTable();

                // Crea una nueva fila para "Mostrar Todo"
                DataRow newRow = dataCmbSucursal.NewRow();
                newRow["IdSucursal"] = "0";
                newRow["NombreSucursal"] = "Mostrar Todo";
                newRow["Estado"] = "Activo"; // Puedes mantener el estado "Activo" para esta fila

                // Inserta la nueva fila en la posición 0
                dataCmbSucursal.Rows.InsertAt(newRow, 0);

                // Configura el DataSource del combo box
                auxFrm.CmbSucursales.ValueMember = "IdSucursal";
                auxFrm.CmbSucursales.DisplayMember = "NombreSucursal";
                auxFrm.CmbSucursales.DataSource = dataCmbSucursal;
            }

            BuscarInventario();
        }

        public void BuscarInventario()
        {
            dataUtilities.SetParameter("@IdSucursal", auxFrm.CmbSucursales.SelectedValue);
            dataUtilities.SetParameter("@CategoriaId", auxFrm.CmbBuscarPor.SelectedValue);
            dataUtilities.SetParameter("@Filtro", auxFrm.TxtFiltrar.Text);
            auxFrm.dgvCatalogo.DataSource = dataUtilities.ExecuteStoredProcedure("sp_ObtenerCantidadProductoPorSucursalYCategoria");
        }
    }
}
