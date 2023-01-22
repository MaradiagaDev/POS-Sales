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
    public class CBeneficiario
    {
        public Conexion conexion;
        public CBeneficiario(Conexion conexion)
        {
            this.conexion = conexion;

        }
        public string PrecioServicioContrato(String filtro)
        {
            DataTable dtResultado = new DataTable("BuscarCliente");




            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "Mostrar_PrecioServicio";
            sqlCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter filtroDato = new SqlParameter();
            filtroDato.ParameterName = "@nombre";
            filtroDato.SqlDbType = SqlDbType.NVarChar;
            filtroDato.Size = 100;
            filtroDato.Value = filtro;

            sqlCommand.Parameters.Add(filtroDato);

            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

            sqlData.Fill(dtResultado);


            return dtResultado.Rows[0]["Monto"].ToString();
        }




    }
}
