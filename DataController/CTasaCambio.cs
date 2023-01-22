using NeoCobranza.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            DataTable dtResultado = new DataTable("Tasa");


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "Tasa";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

            sqlData.Fill(dtResultado);

            try
            {
                return dtResultado.Rows[0]["Tasa"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay una tasa de cambio insertada","Error");

                return "";
            }
            
           
        }
        public string MostrarIdTasa()
        {
            DataTable dtResultado = new DataTable("Tasa");


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "Tasa";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

            sqlData.Fill(dtResultado);


            return dtResultado.Rows[0]["IdTasaCambio"].ToString();
        }


        public void AgregarTasa(double tasa)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];
            //1
            param[0] = new SqlParameter("@Tasa", SqlDbType.Float);
            param[0].Value = tasa;
         
           
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertarTasa";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();

              


                MessageBox.Show("Tasa del sistema actualizada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception ex)
            {
                MessageBox.Show("error", ex.ToString());
            }

        }

    }
}
