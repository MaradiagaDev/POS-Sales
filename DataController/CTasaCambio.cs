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

                return "36,6243";
                    
            }
        }

        public string MostrarIdTasa()
        {
           

                return "1198";


        }
    }
}
