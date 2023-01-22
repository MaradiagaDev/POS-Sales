using NeoCobranza.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCobranza.Clases
{
    public class Colector
    {
        private Conexion conexion;
        public Colector(Conexion conexion)
        {
            this.conexion = conexion;

        }
        //filtrar a los colectores

        public DataTable Colector_listar(string filtro)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@filtro", SqlDbType.NVarChar);
            param[0].Value = filtro;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Colector_Filtrar";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public DataTable Colector_PorId(int idContrato)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@idContrato", SqlDbType.NVarChar);
            param[0].Value = idContrato;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Contrato_ColectorVer";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }

    }
}
