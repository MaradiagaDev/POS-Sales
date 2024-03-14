using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.ViewModels
{
    public class VMPromciones
    {
        public string auxKey = "";
        public string auxOpc = "";
        public DataTable dynamicDataTable = new DataTable();

        public class TipoPromocion
        {
            public int id { get; set; }
            public string opc { get; set; }
        }

        public void InitModuloPromociones(Promociones frm)
        {
            frm.TCMain.Appearance = TabAppearance.FlatButtons;
            frm.TCMain.SizeMode = TabSizeMode.Fixed;
            frm.TCMain.ItemSize = new System.Drawing.Size(1, 1);
            ConfigUI(frm,"Buscar","");   
        }

        public void ConfigUI(Promociones frm, string opc, string key)
        {
            auxOpc = opc;
            auxKey = key;

            switch(opc)
            {
                case "Buscar":
                    frm.TbTitulo.Text = "Buscar Promoción";
                    frm.TCMain.SelectedIndex = 0;

                    if (dynamicDataTable.Columns.Count < 3)
                    {

                        // Agregar una columna de botón
                        DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                        buttonColumn.HeaderText = "...";
                        buttonColumn.Text = "Actualizar";
                        buttonColumn.UseColumnTextForButtonValue = true;
                        frm.DgvPromociones.Columns.Add(buttonColumn);

                        DataGridViewButtonColumn buttonColumnDisponibilidad = new DataGridViewButtonColumn();
                        buttonColumnDisponibilidad.HeaderText = "...";
                        buttonColumnDisponibilidad.Text = "Bloquear";
                        buttonColumnDisponibilidad.UseColumnTextForButtonValue = true;
                        frm.DgvPromociones.Columns.Add(buttonColumnDisponibilidad);

                        dynamicDataTable.Columns.Add("Id", typeof(string));
                        dynamicDataTable.Columns.Add("Promoción", typeof(string));
                        dynamicDataTable.Columns.Add($"Fecha Inicial", typeof(string));
                        dynamicDataTable.Columns.Add($"Fecha Final", typeof(string));
                        dynamicDataTable.Columns.Add($"Estado", typeof(string));

                        frm.DgvPromociones.DataSource = dynamicDataTable;
                    }
                    break;
                case "Crear":
                    frm.TbTitulo.Text = "Crear Promoción";
                    frm.TCMain.SelectedIndex = 1;

                    TipoPromocion tipoUno = new TipoPromocion()
                    {
                        id = 1,
                        opc = "Por Producto"
                    };

                    TipoPromocion tipoDos = new TipoPromocion()
                    {
                        id = 2,
                        opc = "Por Servicio"
                    };

                    TipoPromocion tipoTres = new TipoPromocion()
                    {
                        id = 3,
                        opc = "Por Forma de Pago"
                    };

                    TipoPromocion tipoCuatro = new TipoPromocion()
                    {
                        id = 4,
                        opc = "Por Tipo Producto"
                    };

                    TipoPromocion tipoCinco = new TipoPromocion()
                    {
                        id = 5,
                        opc = "Por Tipo Tarjeta"
                    };

                    List<TipoPromocion> listaTipos = new List<TipoPromocion>();
                    listaTipos.Add(tipoUno);
                    listaTipos.Add(tipoDos);
                    listaTipos.Add(tipoTres);
                    listaTipos.Add(tipoCuatro);
                    listaTipos.Add(tipoCinco);

                    frm.CmbTipoPromocion.DataSource = listaTipos;
                    frm.CmbTipoPromocion.ValueMember = "id";
                    frm.CmbTipoPromocion.DisplayMember = "opc";

                    //Cargar Pantalla
                    using (NeoCobranzaContext db = new NeoCobranzaContext())
                    {

                    }

                    break;
                case "Modificar":
                    frm.TbTitulo.Text = "Modificar Promoción";
                    frm.TCMain.SelectedIndex = 1;
                    break;
            }
        }
    }
}
