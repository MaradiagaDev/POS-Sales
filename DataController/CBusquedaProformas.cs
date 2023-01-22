using NeoCobranza.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCobranza.DataController
{
    
    public class CBusquedaProformas
    {
        public Conexion conexion;

        public CBusquedaProformas(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public DataTable BuscarProforma(String filtro)
        {
            DataTable dtResultado = new DataTable("BuscarDeptp");




            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "MostrarProformas";
            sqlCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter filtroDato = new SqlParameter();
            filtroDato.ParameterName = "@filtro";
            filtroDato.SqlDbType = SqlDbType.NVarChar;
            filtroDato.Size = 200;
            filtroDato.Value = filtro;

            sqlCommand.Parameters.Add(filtroDato);

            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

            sqlData.Fill(dtResultado);


            return dtResultado; 
        }
    }
}
