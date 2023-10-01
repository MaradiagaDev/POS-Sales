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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Web;

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

        public DataTable Contrato_ListarPrimerasCuotas_ID(int filtro)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@filtro", SqlDbType.Int);
            param[0].Value = filtro;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Contrato_Filtrar_PrimeraCuota_Por_Id";
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

        public DataTable Contrato_ListarContratosPagando_Id(int filtro)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@filtro", SqlDbType.Int);
            param[0].Value = filtro;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Contrato_Filtrar_Pagos_Id";
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

        public DataTable Contrato_Listar_Retirados_ID(int filtro)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@filtro", SqlDbType.Int);
            param[0].Value = filtro;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Contrato_Filtrar_Retirados_ID";
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

        public DataTable Contrato_ServiciosInfo_Cantidad(int id,string nombre)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@nombre", SqlDbType.NVarChar);
            param[1].Value = nombre;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "contrato_OtrosServicios_Cantidad";
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
            cmd.CommandText = "Contrato_Informacion_Economica_General";
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
        public void Contrato_Insertar_Valores(string idReff,
           float monto,
           float debito,
           int idContrato,
           string documento,
           string tasa
           )
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[6];
            //1
            param[0] = new SqlParameter("@idReff", SqlDbType.NVarChar);
            param[0].Value = idReff;
            //2
            param[1] = new SqlParameter("@montoD", SqlDbType.Float);
            param[1].Value = monto;

            param[2] = new SqlParameter("@debito", SqlDbType.Float);
            param[2].Value = debito;

            param[3] = new SqlParameter("@idContrato", SqlDbType.Int);
            param[3].Value = idContrato;

            param[4] = new SqlParameter("@Documento", SqlDbType.NVarChar);
            param[4].Value = documento;

            param[5] = new SqlParameter("@Tasa", SqlDbType.NVarChar);
            param[5].Value = tasa;

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

        //Actualizar Valores

        public void Contrato_Actualizar_Valores(int id,int idContrato,
           float debito,
           float credito,
            float cordoba

           )
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[5];
            //1
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            //2
            param[1] = new SqlParameter("@idContrato", SqlDbType.Int);
            param[1].Value = idContrato;

            param[2] = new SqlParameter("@debito", SqlDbType.Float);
            param[2].Value = debito;

            param[3] = new SqlParameter("@Credito", SqlDbType.Float);
            param[3].Value = credito;

            param[4] = new SqlParameter("@Cordoba", SqlDbType.Float);
            param[4].Value = cordoba;

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Actualizar_ValoresContrato";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        public void Contrato_Actualizar_Propietario(int id, int idContrato)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[2];
            //1
            param[0] = new SqlParameter("@idCliente", SqlDbType.Int);
            param[0].Value = id;
            //2
            param[1] = new SqlParameter("@idContrato", SqlDbType.Int);
            param[1].Value = idContrato;

         
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Contrato_ActualizarPropietario";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Propietario Actualizado");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Contrato_Actualizar_Colector(int id, int idContrato)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[2];
            //1
            param[0] = new SqlParameter("@idColector", SqlDbType.Int);
            param[0].Value = id;
            //2
            param[1] = new SqlParameter("@idContrato", SqlDbType.Int);
            param[1].Value = idContrato;


            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Contrato_ActualizarColector";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Colector Actualizado");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Contrato_Actualizar_Descripcion(string desc, int idContrato)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[2];
            //1
            param[0] = new SqlParameter("@descripcion", SqlDbType.NVarChar);
            param[0].Value = desc;
            //2
            param[1] = new SqlParameter("@idContrato", SqlDbType.Int);
            param[1].Value = idContrato;


            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Contrato_Descripcion_Actuaizar";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Descripcion Actualizada");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Contrato_Insertar_Historial(string Accion, string valor, string usuario,int idcontrato)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[4];
            //1
            param[0] = new SqlParameter("@Accion", SqlDbType.NVarChar);
            param[0].Value = Accion;
            //2
            param[1] = new SqlParameter("@Valor", SqlDbType.NVarChar);
            param[1].Value = valor;

            param[2] = new SqlParameter("@usuario", SqlDbType.NVarChar);
            param[2].Value = usuario;

            param[3] = new SqlParameter("@IdContrato", SqlDbType.Int);
            param[3].Value = idcontrato;


            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Historia_Contrato_Insertar";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public DataTable Contrato_Filtrar_Modificaciones(string filtro,int id)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@filtro", SqlDbType.NVarChar);
            param[0].Value = filtro;

            param[1] = new SqlParameter("@idContrato", SqlDbType.NVarChar);
            param[1].Value = id;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Historia_Contrato_Buscar";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }


        public DataTable Contrato_Filtrar_Modificaciones_Fecha(string fechaI,string fechaF, int id)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@fechaInicial", SqlDbType.Date);
            param[0].Value = fechaI;

            param[1] = new SqlParameter("@fechaFinal", SqlDbType.Date);
            param[1].Value = fechaF;

            param[2] = new SqlParameter("@idContrato", SqlDbType.Int);
            param[2].Value = id;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Historia_Contrato_BuscarFechas";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public DataTable Contrato_Listar_Todos_PorID(int id)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Contrato_Filtrar_Todos_PorId";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public string Retiros_Valor_Contrato(int id)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Retiros_Valores_Contrato";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado.Rows[0][0].ToString();
        }
        //Filtros para retiros donde no van los contratos retirados


        public DataTable Retirados_Listar_Todos_PorID(int id)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Retirados_Filtrar_Todos_PorId";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            try
            {
                sqlData.Fill(dtResultado);

            }
            catch (Exception)
            {

            }

            return dtResultado;
        }

        public DataTable Retirados_Listar_Todos(string id)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@filtro", SqlDbType.NVarChar);
            param[0].Value = id;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Retirados_Filtrar_Todos";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public DataTable Retirados_Listar_Estandares(float monto)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@monto", SqlDbType.NVarChar);
            param[0].Value = monto.ToString();


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Retiros_Estandares";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        public DataTable Retirados_Listar_ataudes(string estandar)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@nombre", SqlDbType.NVarChar);
            param[0].Value = estandar;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Retiros_Ataudes_Disponibles";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }


        //CREA LA FACTURA
        public void Retiro_RealizarFactura(int idContrato, int idTasa, string usuario)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[3];
            //1
            param[0] = new SqlParameter("@IdContrato", SqlDbType.Int);
            param[0].Value = idContrato;
            //2
            param[1] = new SqlParameter("@IdTasa", SqlDbType.Int);
            param[1].Value = idTasa;

            param[2] = new SqlParameter("@usuario", SqlDbType.NVarChar);
            param[2].Value = usuario;

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Retiro_CrearFactura";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //OBTIENE EL ULTIMO ID DE LA FACTURA
        public string Retiros_UltimoRetiroId()
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

           

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Retiros_UltimoRetiro";
            cmd.Connection = conexion.connect;
            

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado.Rows[0][0].ToString();
        }
        //INSERTA LOS DETALLES

        public void Retiro_FacturaDetalles(int idRetiro,int idBeneficiario, int idReferencial, string tipo, float extra)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[5];
            //1
            param[0] = new SqlParameter("@IdRetiro", SqlDbType.Int);
            param[0].Value = idRetiro;
            //2
            param[1] = new SqlParameter("@IdBeneficiario", SqlDbType.Int);
            param[1].Value = idBeneficiario;

            param[2] = new SqlParameter("@IdReferencial", SqlDbType.Int);
            param[2].Value = idReferencial;
            //2
            param[3] = new SqlParameter("@Tipo", SqlDbType.NVarChar);
            param[3].Value = tipo;

            param[4] = new SqlParameter("@Extra", SqlDbType.Float);
            param[4].Value = extra;


            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Retiros_Detalles";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void Retiro_CambioEstadoAtaud(int idAtaud)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];
            //1
            param[0] = new SqlParameter("@idAtaud", SqlDbType.Int);
            param[0].Value = idAtaud;


            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Retiro_ActualizarAtaud";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Modificar al beneficiario 
        public void Retiro_Beneficiario(int idAtaud,string noSerie)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[2];
            //1
            param[0] = new SqlParameter("@idBeneficiario", SqlDbType.Int);
            param[0].Value = idAtaud;

            param[1] = new SqlParameter("@NoSerie", SqlDbType.NVarChar);
            param[1].Value = noSerie;
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Retiro_ModificarBeneficiario";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Modificar tabla de servicios
        public void Retiro_Servicios(int idServicio, int retirados)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[2];
            //1
            param[0] = new SqlParameter("@idServicios", SqlDbType.Int);
            param[0].Value = idServicio;

            param[1] = new SqlParameter("@retirados", SqlDbType.Int);
            param[1].Value = retirados;

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Retiros_ModificarServicios";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        //Verificar
        public void Retiro_Vefiricar(int idContrato)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];
            //1
            param[0] = new SqlParameter("@idContrao", SqlDbType.Int);
            param[0].Value = idContrato;
          

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Retiros_Comprobacion";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //NoSerie ataud
        public string Retiros_NoSeriexIdAtaud(int idAtaud)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];
            //1
            param[0] = new SqlParameter("@IdAtaud", SqlDbType.Int);
            param[0].Value = idAtaud;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Retiro_ObtenerNoSerie";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);


            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado.Rows[0][0].ToString();
        }

        // obtener total retirado

        public string Retiros_Retirado_Contrato(int id)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Retiros_Retirados_Contrato";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado.Rows[0][0].ToString();
        }

        //Parte de facturas
        public DataTable Facturas_Listar(string filtro)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@filtro", SqlDbType.NVarChar);
            param[0].Value = filtro;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "FacturasContratos_Filtrar";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }


        public DataTable Facturas_Listar_ID(int filtro)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@filtro", SqlDbType.Int);
            param[0].Value = filtro;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "FacturasContratos_Filtrar_ID";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }


        public string Contrato_Estandar_PrecioxID(int id)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Contrato_Precio_Id";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado.Rows[0][0].ToString();
        }
        //Revalorizacion


        public DataTable Beneficiario_Mostrar_Activos(int id)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@idContrato", SqlDbType.Int);
            param[0].Value = id;




            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Contrato_Beneficiario_Activo";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado;
        }

        //TODO LO QUE TIENE QUE VER CON REVALORIZACION

        //Revalorizar el beneficiario
        public void Revalorizacion_Beneficiario(int idBeneficiario, float monto)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[2];
            //1
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = idBeneficiario;

            param[1] = new SqlParameter("@monto", SqlDbType.Float);
            param[1].Value = monto;

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Contrato_Revalorizacion_Beneficiario";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Desactivar el beneficiario

        public void Revalorizacion_Desactivar(int idBeneficiario)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];
            //1
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = idBeneficiario;

          

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Contrato_Revalorizacion_Desactivar";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Revalorizacion final del contrato

        public void Revalorizacion_Contrato(int idBeneficiario)
        {
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];
            //1
            param[0] = new SqlParameter("@idContrato", SqlDbType.Int);
            param[0].Value = idBeneficiario;



            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Contrato_Revalorizacion";
                cmd.Connection = conexion.connect;
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        //TODO LO QUE TIENE QUE VER CON TRASLADO DE SALDO

        public string Contrato_Verificar_Traslado(int id)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@idContrato", SqlDbType.Int);
            param[0].Value = id;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Contrato_Traslado_Verificar";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado.Rows[0][0].ToString();
        }

        //Procedimiento almacenado que valida que sea un contra nuevo
        public string Contrato_Verificar_Traslado_Final(int id)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@idContrato", SqlDbType.Int);
            param[0].Value = id;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Contrato_Traslado_Verificar_Final";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado.Rows[0][0].ToString();
        }

        //Pasar un contrato de retirado a activo
        public string Contrato_Retirados_Anular(int id)
        {
            DataTable dtResultado = new DataTable("Listar");

            //Procedimiento
            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@idContrato", SqlDbType.Int);
            param[0].Value = id;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Contrato_Anular_Retiro";
            cmd.Connection = conexion.connect;
            cmd.Parameters.AddRange(param);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtResultado);

            return dtResultado.Rows[0][0].ToString();
        }
    }
}
