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
    public class CSeguridad
    {
        public Conexion conexion;

        public CSeguridad(Conexion conexion)
        {

            this.conexion = conexion;
        }

        public string MostrarRol(String nombre)
        {
            DataTable dtResultado = new DataTable("B");




            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "VerRolUsuario";
            sqlCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter filtroDato = new SqlParameter();
            filtroDato.ParameterName = "@nombre";
            filtroDato.SqlDbType = SqlDbType.NVarChar;
            filtroDato.Size = 100;
            filtroDato.Value = nombre;

            sqlCommand.Parameters.Add(filtroDato);

            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

            sqlData.Fill(dtResultado);


            return dtResultado.Rows[0]["Rol"].ToString();
        }

    }
}
