using NeoCobranza.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeoCobranza.ModelsCobranza;

namespace NeoCobranza.DataController
{
    public class CTasaCambio
    {
        Conexion conexion;

        public CTasaCambio(Conexion conexion)
        {
        this.conexion = conexion;   
        }

        public string MostrarTasa()
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                    TipoCambio tipo = db.TipoCambio.Where(t => t.FechaCambio.Equals(DateTime.Today)).FirstOrDefault();

                    if (tipo == null)
                    {
                        MessageBox.Show("No se han insertado las tasas de cambio de este mes","Atención",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        return "";
                    }
                    else
                    {
                        return tipo.Tasa.ToString().Substring(0,6);
                    }
            }
        }
        public string MostrarIdTasa()
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                TipoCambio tipo = db.TipoCambio.Where(t => t.FechaCambio.Equals(DateTime.Today)).FirstOrDefault();

                if (tipo == null)
                {
                    MessageBox.Show("No se han insertado las tasas de cambio de este mes", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return "";
                }
                else
                {
                    return tipo.IdTasaCambio.ToString();
                }
            }
        }
    }
}
