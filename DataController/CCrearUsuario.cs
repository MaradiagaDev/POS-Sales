using Microsoft.ReportingServices.Diagnostics.Internal;
using NeoCobranza.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.DataController
{
    public class CCrearUsuario
    {
        public SqlConnection connectLogn = new SqlConnection();
        public Conexion conexion;
        public CCrearUsuario(Conexion conexion)
        {
            this.conexion = conexion;   
        }


        public void CrearLogin(string nombre, string contra, string rol)
        {
            try
            {
                try
                {

                    connectLogn = new SqlConnection("Server=FCYASERVIDOR;Database=NeoCobranza;UID=sa;PWD=123456");
                    connectLogn.Open();
                }
                catch (Exception e)
                {

                    MessageBox.Show(e.ToString());

                }
                //

                string query = "Create Login " + nombre + " With password= " + "'" + contra + "'";
                SqlCommand sqlCommand = new SqlCommand(query, connectLogn);
                sqlCommand.ExecuteNonQuery();


                string queryUser = "sp_adduser " + nombre + " , " + nombre;
                SqlCommand sqlCommand2 = new SqlCommand(queryUser, connectLogn);
                sqlCommand2.ExecuteNonQuery();

                AgregarUsuario(nombre, rol);


                string queryGrant = "Grant execute to " + nombre + " with grant option";
                SqlCommand sqlCommand3 = new SqlCommand(queryGrant, conexion.connect);
                sqlCommand3.ExecuteNonQuery();

                string queryGrantD = "Grant Delete to " + nombre + " with grant option";
                SqlCommand sqlCommandDel = new SqlCommand(queryGrantD, conexion.connect);
                sqlCommandDel.ExecuteNonQuery();






                string queryGrantRoleServer2 = "Grant alter any user to " + nombre + " with grant option";
                SqlCommand sqlCommand7 = new SqlCommand(queryGrantRoleServer2, conexion.connect);
                sqlCommand7.ExecuteNonQuery();


                string queryGrantInsert = "Grant insert to " + nombre + " with grant option";
                SqlCommand sqlCommand5 = new SqlCommand(queryGrantInsert, conexion.connect);
                sqlCommand5.ExecuteNonQuery();

                string queryGrantAlter = "Grant alter to " + nombre + " with grant option";
                SqlCommand sqlCommand6 = new SqlCommand(queryGrantAlter, conexion.connect);
                sqlCommand6.ExecuteNonQuery();

                


                MessageBox.Show("Usuario creado con exito", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                

            }
            catch (Exception ex)
            {
                MessageBox.Show("El usuario ya existe en el sistema", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show(ex.ToString(), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void AgregarUsuario(string nombre, string rol)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[2];
            //1
            param[0] = new SqlParameter("@nombre", SqlDbType.NVarChar);
            param[0].Value = nombre;
            //2
            param[1] = new SqlParameter("@rol", SqlDbType.NVarChar);
            param[1].Value = rol;
            

            
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertarUsuario";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();


        }



    }
}
