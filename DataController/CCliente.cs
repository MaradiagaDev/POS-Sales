using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoCobranza.Data;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace NeoCobranza.DataController

{
    public class CCliente
    {
        public Conexion conexion;

        public CCliente(Conexion conexion)
        {
            this.conexion = conexion;
        }
        //
        public void AgregarCliente(string pn, string sn, string pa, string sa, int estado, string direccion, float tel, float cel,string mail,string estodCivil, string profesion, string fechanac,string sexo, string cedula, string departamento,string pais,string observacion)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[17];
            //1
            param[0] = new SqlParameter("@pnombre",SqlDbType.NVarChar);
            param[0].Value = pn;
            //2
            param[1] = new SqlParameter("@snombre", SqlDbType.NVarChar);
            param[1].Value = sn;
            //3
            param[2] = new SqlParameter("@pApellido", SqlDbType.NVarChar);
            param[2].Value = pa;
            //4
            param[3] = new SqlParameter("@sApellido", SqlDbType.NVarChar);
            param[3].Value = sa;
            //5
            param[4] = new SqlParameter("@Estado", SqlDbType.Int);
            param[4].Value = estado;
            //6
            param[5] = new SqlParameter("@Direccion", SqlDbType.NVarChar);
            param[5].Value = direccion;
            //7
            param[6] = new SqlParameter("@Telefono", SqlDbType.Float);
            param[6].Value = tel;
            //8
            param[7] = new SqlParameter("@Celular", SqlDbType.Float);
            param[7].Value = cel;
            //9
            param[8] = new SqlParameter("@Email", SqlDbType.NVarChar);
            param[8].Value = mail;
            //10
            //11
            param[9] = new SqlParameter("@EstadoCivil", SqlDbType.NVarChar);
            param[9].Value = estodCivil;
            //12
            param[10] = new SqlParameter("@profesion", SqlDbType.NVarChar);
            param[10].Value = profesion;
            //13
            param[11] = new SqlParameter("@FechaNac", SqlDbType.Date);
            param[11].Value = fechanac;
            //14
            param[12] = new SqlParameter("@Sexo", SqlDbType.NVarChar);
            param[12].Value = sexo;
            //15
            param[13] = new SqlParameter("@cedula", SqlDbType.NVarChar);
            param[13].Value =cedula ;
            //16
            param[14] = new SqlParameter("@Departamento", SqlDbType.NVarChar);
            param[14].Value = departamento;

            param[15] = new SqlParameter("@pais", SqlDbType.NVarChar);
            param[15].Value = pais;
            //16
            param[16] = new SqlParameter("@observacion", SqlDbType.NVarChar);
            param[16].Value = observacion;

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Add_Cliente";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                //cmd.ExecuteNonQuery();

                DataTable dtResultado = new DataTable("NombreDpto");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtResultado);

                MessageBox.Show(dtResultado.Rows[0]["id"].ToString(),"Agregado Correctamente");

            }
            catch(Exception ex)
            {
                MessageBox.Show("error",ex.ToString());
            }


            

        }

        public DataTable MostrarCliente(String filtro)
        {
            DataTable dtResultado = new DataTable("Buscar Colector");




            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "MostrarCliente";
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
        public void ActualizarCliente(int id, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido,
            int estado, string direccion, float tel, float cel, string mail, string estodCivil, string profesion, string fechanac, string sexo, string cedula, string departamento,string pais, string observacion)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[18];
            //1
            param[0] = new SqlParameter("@IdCliente", SqlDbType.NVarChar);
            param[0].Value = id;

            param[1] = new SqlParameter("@pnombre", SqlDbType.NVarChar);
            param[1].Value = primerNombre;
            //2
            param[2] = new SqlParameter("@snombre", SqlDbType.NVarChar);
            param[2].Value = segundoNombre;
            //3
            param[3] = new SqlParameter("@pApellido", SqlDbType.NVarChar);
            param[3].Value = primerApellido;
            //4
            param[4] = new SqlParameter("@sApellido", SqlDbType.NVarChar);
            param[4].Value = segundoApellido;
            //5
            param[5] = new SqlParameter("@Estado", SqlDbType.Int);
            param[5].Value = estado;
            //6
            param[6] = new SqlParameter("@Direccion", SqlDbType.NVarChar);
            param[6].Value = direccion;
            //7
            param[7] = new SqlParameter("@Telefono", SqlDbType.Float);
            param[7].Value = tel;
            //8
            param[8] = new SqlParameter("@Celular", SqlDbType.Float);
            param[8].Value = cel;
            //9
            param[9] = new SqlParameter("@Email", SqlDbType.NVarChar);
            param[9].Value = mail;
            //10
            //11
            param[10] = new SqlParameter("@EstadoCivil", SqlDbType.NVarChar);
            param[10].Value = estodCivil;
            //12
            param[11] = new SqlParameter("@profesion", SqlDbType.NVarChar);
            param[11].Value = profesion;
            //13
            param[12] = new SqlParameter("@FechaNac", SqlDbType.Date);
            param[12].Value = fechanac;
            //14
            param[13] = new SqlParameter("@Sexo", SqlDbType.NVarChar);
            param[13].Value = sexo;
            //15
            param[14] = new SqlParameter("@cedula", SqlDbType.NVarChar);
            param[14].Value = cedula;
            //16
            param[15] = new SqlParameter("@Departamento", SqlDbType.NVarChar);
            param[15].Value = departamento;

            param[16] = new SqlParameter("@pais", SqlDbType.NVarChar);
            param[16].Value = pais;
            //16
            param[17] = new SqlParameter("@observacion", SqlDbType.NVarChar);
            param[17].Value = observacion;


            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ActualizarCliente";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();

               

                MessageBox.Show("Actualizado", "Realizado!");

            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.ToString(), "error");
            }
        }

    }
}
