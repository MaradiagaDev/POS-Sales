using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Data
{
    public class Conexion
    {
        public SqlConnection connect = new SqlConnection();
        public string usuario;
        public Conexion(string password,string user)
        {
            this.usuario = user;
            try
            {
                // mi servidor rolando DESKTOP-1F07ALD\SQLEXPRESS
                //connect = new SqlConnection("Server=DESKTOP-1F07ALD\\SQLEXPRESS;Database=NeoCobranza;UID=" + user + ";PWD=" + password);

                //server HenocFCYASERVIDOR
                connect = new SqlConnection("Server=192.168.1.165;Database=NeoCobranza;UID=" + user+";PWD="+password+ "; MultipleActiveResultSets=True");
                connect.Open();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());

            }
        }

        public void AbrirConexion()
        {
            connect.Close();
            connect.Open();
        }
        public string ObtenerUsuari()
        {
            return usuario;
        }

    }
}
