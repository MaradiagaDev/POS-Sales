using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoCobranza.Data;
using System.Data;
using System.Data.SqlClient;
namespace NeoCobranza.DataController
{
    
    public class CColector
    {
        public Conexion conexion;

        public CColector(Conexion conexion)
        {
            this.conexion = conexion;
        }
        //Procedimiento 1: FILTRAR COLECTOR
        public DataTable BuscarColector(String filtro)
        {
            DataTable dtResultado = new DataTable("Buscar Colector");
            
            
                

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion.connect;

                sqlCommand.CommandText = "dbo_FiltroColector";
                sqlCommand.CommandType = CommandType.StoredProcedure;


                SqlParameter filtroDato = new SqlParameter();
                filtroDato.ParameterName = "@filtro";
                filtroDato.SqlDbType = SqlDbType.VarChar;
                filtroDato.Size = 200;
                filtroDato.Value = filtro;

                sqlCommand.Parameters.Add(filtroDato);

                SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

                sqlData.Fill(dtResultado);
            
            
            return dtResultado;
        }


        //Corchetes finales
    }
}
