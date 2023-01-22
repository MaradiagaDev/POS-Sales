using NeoCobranza.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace NeoCobranza.DataController
{
    public class CFoto
    {
        public Conexion conexion;
        public CFoto(Conexion conexion)
        {
            this.conexion = conexion;   


        }

        
        
            public void ActualizarFoto(string nombre, Image monto)
            {
                SqlCommand cmd = new SqlCommand();

                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("@id", SqlDbType.Int);
                param[0].Value = nombre;

                param[1] = new SqlParameter("@image", SqlDbType.Image);
                param[1].Value = monto;


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ImagenContrato";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Imagen ingresada en el conreato", "Info");

            }

        


    }
}
