using NeoCobranza.Data;
using NeoCobranza.DataController;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Clases
{
    public class Contrato
    {
        //Clase de conexion
        private Conexion conexion;

        //Constructor
        public Contrato(Conexion conexion)
        {

            this.conexion = conexion;
        }

        //AGREGAR CONTRATO

        public void Contrato_Agregar(int year, int totaCuotas, float vNominal, float VCuota, string Observaciones, int idFirma, int tasaCambio, int idVendedor, string modalidad)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[9];
            //1
            param[0] = new SqlParameter("@year", SqlDbType.Int);
            param[0].Value = year;
            //2
            param[1] = new SqlParameter("@TotalCuotas", SqlDbType.Int);
            param[1].Value = totaCuotas;
            //3
            param[2] = new SqlParameter("@VNominal", SqlDbType.Float);
            param[2].Value = vNominal;
            //4
            param[3] = new SqlParameter("@VCuota", SqlDbType.Float);
            param[3].Value = VCuota;
            //5
            param[4] = new SqlParameter("@Observaciones", SqlDbType.NVarChar);
            param[4].Value = Observaciones;
            //6
            param[5] = new SqlParameter("@idFirma", SqlDbType.Int);
            param[5].Value = idFirma;
            //7

            param[6] = new SqlParameter("@idTasa", SqlDbType.Int);
            param[6].Value = tasaCambio;
            //9
            param[7] = new SqlParameter("@idVendedor", SqlDbType.Int);
            param[7].Value = idVendedor;
            //10
            param[8] = new SqlParameter("@Modalidad", SqlDbType.NVarChar);
            param[8].Value = modalidad;


            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Contrato_Insertar_Nuevo";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Contrato proforma agregado correctamente", "Agregado Correctamente");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //
        public DataTable Contrato_ListarUltimaFactura(int idContrato)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@idContrato", SqlDbType.Int);
            param[0].Value = idContrato;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Contrato_VerUltimaFactura";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }


        public DataTable Contrato_ListarPrimerasCuotas(string filtro)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@filtro", SqlDbType.NVarChar);
            param[0].Value = filtro;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Contrato_Filtrar_PrimeraCuota";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public DataTable Contrato_ListarContratosPagando(string filtro)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@filtro", SqlDbType.NVarChar);
            param[0].Value = filtro;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Contrato_Filtrar_Pagos";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }
        public DataTable Contrato_ProximaCuota(int id)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@idContrato", SqlDbType.Int);
            param[0].Value = id;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Reporteria_ReciboColector2";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }
        //Agregar pago de cuotas
        public void Contrato_PagoCuota(float montoCordoba,
            float montoDolar,
            int cuotas,
            int idColector,
            int idContrato,
            string observaciones)
            
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[6];
            //1
            param[0] = new SqlParameter("@MontoCordoba", SqlDbType.Float);
            param[0].Value = montoCordoba;
            //2
            param[1] = new SqlParameter("@MontoDolar", SqlDbType.Float);
            param[1].Value = montoDolar;
            //3
            param[2] = new SqlParameter("@CuotasPagadas", SqlDbType.Int);
            param[2].Value = cuotas;
            //4
            param[3] = new SqlParameter("@IdColector", SqlDbType.Int);
            param[3].Value = idColector;
            //5
            param[4] = new SqlParameter("@IdContrato", SqlDbType.Int);
            param[4].Value = idContrato;
            //6
            param[5] = new SqlParameter("@Observacion", SqlDbType.NVarChar);
            param[5].Value = observaciones;
            //6
           


            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Contrato_PagoCuotas";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Pago de cuotas realizado correctamente", "Agregado Correctamente");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void Contrato_PagoCuota2(float montoCordoba,
            float montoDolar,
            int cuotas,
            int idColector,
            int idContrato,
            string observaciones,
            string fecha)


        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[7];
            //1
            param[0] = new SqlParameter("@MontoCordoba", SqlDbType.Float);
            param[0].Value = montoCordoba;
            //2
            param[1] = new SqlParameter("@MontoDolar", SqlDbType.Float);
            param[1].Value = montoDolar;
            //3
            param[2] = new SqlParameter("@CuotasPagadas", SqlDbType.Int);
            param[2].Value = cuotas;
            //4
            param[3] = new SqlParameter("@IdColector", SqlDbType.Int);
            param[3].Value = idColector;
            //5
            param[4] = new SqlParameter("@IdContrato", SqlDbType.Int);
            param[4].Value = idContrato;
            //6
            param[5] = new SqlParameter("@Observacion", SqlDbType.NVarChar);
            param[5].Value = observaciones;
            //6
            //6
            param[6] = new SqlParameter("@fecha", SqlDbType.NVarChar);
            param[6].Value = fecha;


            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Contrato_PagoCuotas2";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Pago de cuotas realizado correctamente", "Agregado Correctamente");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void Contrato_Servicios(int idContrato,
            int cantidad,
            float montoNominal,
            string estado,
            int idEstandar
            )
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[5];
            //1
            param[0] = new SqlParameter("@idContrato", SqlDbType.Int);
            param[0].Value = idContrato;
            //2
            param[1] = new SqlParameter("@idEstandar", SqlDbType.Int);
            param[1].Value = idEstandar;

            param[2] = new SqlParameter("@Cantidad", SqlDbType.Int);
            param[2].Value = cantidad;
            //3
            param[3] = new SqlParameter("@montoNominal", SqlDbType.Float);
            param[3].Value = montoNominal;
            //4
            param[4] = new SqlParameter("@estado", SqlDbType.NVarChar);
            param[4].Value = estado;
            //5
            



            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Contrato_Servicios";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();

               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void Contrato_ActualizarCuota(int idRecibo,
           float MontoCordoba,
           float MontoDolar,
           int  NoCuotas,
           string observaciones,
           int idColector
           )
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[6];
            //1
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = idRecibo;
            //2
            param[1] = new SqlParameter("@MontoCordoba", SqlDbType.Float);
            param[1].Value = MontoCordoba;

            param[2] = new SqlParameter("@MontoDolar", SqlDbType.Float);
            param[2].Value = MontoDolar;
            //3
            param[3] = new SqlParameter("@noCuotas", SqlDbType.Int);
            param[3].Value = NoCuotas;
            //4
            param[4] = new SqlParameter("@observaciones", SqlDbType.NVarChar);
            param[4].Value = observaciones;
            //5
            param[5] = new SqlParameter("@idColector", SqlDbType.Int);
            param[5].Value = idColector;



            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Contrato_Actualizar_Cuota";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Contrato_Actualizar_Pagando(int idContrato
            )
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];
            //1
            param[0] = new SqlParameter("@idContrato", SqlDbType.Int);
            param[0].Value = idContrato;
         

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Contrato_Actualizar_Pagando";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        public void Contrato_Retirar(int id
          )

        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];
            //1
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Contrato_Retirar";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Contrato retirado", " Correctamente");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public DataTable Contrato_Listar_Retirados(string filtro)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@filtro", SqlDbType.NVarChar);
            param[0].Value = filtro;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Contrato_Filtrar_Retirados";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }
        public DataTable Mostrar_Todos_Nombres()
        {

            DataTable dtResultado = new DataTable("NombreServicio");


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conexion.connect;

            sqlCommand.CommandText = "Nuevo_Mostrar_Nombre_Ataudes_Contrato";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

            sqlData.Fill(dtResultado);

            return dtResultado;

        }


        public void Contrato_Cancelado(int id,float monto
          )

        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[2];
            //1
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@monto", SqlDbType.Float);
            param[1].Value = monto;


            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Cancelar_Contrato";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);


                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Contrato Cancelado", " Correctamente");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public DataTable Contrato_Listar_Todos(string filtro)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@filtro", SqlDbType.NVarChar);
            param[0].Value = filtro;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Contrato_Filtrar_Todos";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public DataTable Contrato_Listar_Beneficiarios(int id)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Contrato_Beneficiario";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public DataTable Contrato_Listar_Beneficiarios_individual(int id)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Contrato_Beneficiario_Individual";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }


        public DataTable Contrato_Listar_Montos(int id)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Contrato_Montos";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public DataTable Contrato_Informacion_Beneficiario(int id)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Contrato_Informacion_Beneficiario";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public void AgregarBeneficiario(
            string pNombre,
            string sNombre,
            string pApellido,
            string sApellido,
            string fechaNac,
            string observaciones,
            string sexo,
            string Direccion,
            string cedula,
            string idDepartamento,
            int idAtaud
            )
        {


            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[11];
            //1
            param[0] = new SqlParameter("@Pnombre", SqlDbType.NVarChar);
            param[0].Value = pNombre;
            //2
            param[1] = new SqlParameter("@Snombre", SqlDbType.NVarChar);
            param[1].Value = sNombre;
            //3
            param[2] = new SqlParameter("@Papellido", SqlDbType.NVarChar);
            param[2].Value = pApellido;
            //4
            param[3] = new SqlParameter("@Sapellido", SqlDbType.NVarChar);
            param[3].Value = sApellido;
            //5
            param[4] = new SqlParameter("@FechaNac", SqlDbType.Date);
            param[4].Value = fechaNac;
            //6
            param[5] = new SqlParameter("@Observaciones", SqlDbType.NVarChar);
            param[5].Value = observaciones;
            //7
            param[6] = new SqlParameter("@Sexo", SqlDbType.NVarChar);
            param[6].Value = sexo;
            //8
            param[7] = new SqlParameter("@Direccion", SqlDbType.NVarChar);
            param[7].Value = Direccion;
            //9
            param[8] = new SqlParameter("@Cedula", SqlDbType.NVarChar);
            param[8].Value = cedula;

            param[9] = new SqlParameter("@IdDepartamento", SqlDbType.NVarChar);
            param[9].Value = idDepartamento;

            param[10] = new SqlParameter("@idBeneficiario", SqlDbType.Int);
            param[10].Value = idAtaud;


            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Contrato_ActualizarBeneficiario";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }




        }
        public DataTable Contrato_ServiciosInfo(int id)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Contrato_OtrosServicios";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public DataTable Contrato_ApartadoServicio(int id,int idServicio)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@idServicio", SqlDbType.Int);
            param[1].Value = idServicio;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Contrato_ApartadoServicios";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public DataTable Contrato_ApartadoEconomico(int id)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Contrato_Informacion_Economica";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }


        public DataTable Contrato_Reporteria_Totales(int id)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;




            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Contrato_Reportes_Totales";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }
        public void Contrato_Actualizar_Cuota_Existente(int id,
           float Cordoba,
           float dolar,
           int cuotas,
           string observaciones
           )
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[5];
            //1
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            //2
            param[1] = new SqlParameter("@MontoCordoba", SqlDbType.Float);
            param[1].Value = Cordoba;

            param[2] = new SqlParameter("@MontoDolar", SqlDbType.Float);
            param[2].Value = dolar;
            //3
            param[3] = new SqlParameter("@noCuotas", SqlDbType.Int);
            param[3].Value = cuotas;
            //4
            param[4] = new SqlParameter("@observaciones", SqlDbType.NVarChar);
            param[4].Value = observaciones;
            //5




            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Contrato_Actualizar_Cuota_Existente";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Valores del contrato
        public void Contrato_Insertar_Valores(int id,
           float monto,
           float debito
          
           )
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[3];
            //1
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            //2
            param[1] = new SqlParameter("@montoD", SqlDbType.Float);
            param[1].Value = monto;

            param[2] = new SqlParameter("@debito", SqlDbType.Float);
            param[2].Value = debito;

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Contrato_Valores_Insertar";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


    }
}
