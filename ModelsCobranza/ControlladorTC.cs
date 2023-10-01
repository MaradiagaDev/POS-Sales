using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.ServiceReference1;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.JScript;
using StackExchange.Redis;
using System.Security.Cryptography;
using Convert = System.Convert;

namespace NeoCobranza.TcController
{
    static class ControlladorTC
    {

        //Cambio del dia
         public static async Task<double> CambioDia(DateTime date)
        {
            Tipo_Cambio_BCNSoapClient client = new Tipo_Cambio_BCNSoapClient();
            double cambioDia = client.RecuperaTC_Dia(date.Year, date.Month, date.Day);
            return cambioDia;
        }
        //Tipo de Cambio del mes
        public static async Task<List<Cambio>> CambioMes(DateTime date)
        {
            Tipo_Cambio_BCNSoapClient client = new Tipo_Cambio_BCNSoapClient();
            RecuperaTC_MesResponse response = await client.RecuperaTC_MesAsync(date.Year, date.Month);
            XElement tiposCambio = response.Body.RecuperaTC_MesResult;

            List<Cambio> listaCambio = new List<Cambio>();

            foreach (XElement elemento in tiposCambio.Elements())
            {
                string valor = elemento.Value;
                char delimiter = '-';

                int delimiterIndex = valor.IndexOf(delimiter);

                    string fechaStr = valor.Substring(0, 10);
                    string tipoCambioStr = valor.Substring(10);


                Cambio cambio = new Cambio
                {
                    CambioDia = tipoCambioStr.Substring(0, 7),
                    Fecha = DateTime.Parse(fechaStr).ToShortDateString().ToString()
                        };
                        listaCambio.Add(cambio);
             
            }

            return listaCambio;
        }
    }
}
