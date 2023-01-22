using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace NeoCobranza.Poo
{
    public class CuotaCalculos
    {

        public bool VerificarAños(int noBeneficiarios,int años)
        {
            bool añosRetorno;
            
            if(noBeneficiarios == 1 && años>3)
            {
                MessageBox.Show("Si solo hay un beneficiario el plazo maximo es para 3 años3", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
            if (noBeneficiarios==2 && años>5)
            {
                MessageBox.Show("Para dos beneficiarios el plazo maximo es de 5 años", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
            if (noBeneficiarios == 3 && años > 6)
            {
                MessageBox.Show("Para tres beneficiarios el plazo maximo es de 6 años", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }

        public double CalculoCuota(int años,float[] Nominales,int cantidadTotal)
        {
            double cuota=0;
            double tasaAñoDos = 1.10;
            double tasaAñoTres = 1.20;
            double tasaAñoCuatro = 1.25;
            double tasaAñoCinco = 1.30;

           
            //PARA UN BENEFICIARIO Y SU CANTIDAD DE AÑOS QUE SON 3
            if (cantidadTotal == 1 && años == 1)
            {
                cuota = Nominales[0]/12;
            }
            if (cantidadTotal == 1 && años == 2)
            {
                cuota = (Nominales[0] * tasaAñoDos) / (12*2);
            }
            if(cantidadTotal == 1 && años ==3)
            {
                cuota = (Nominales[0] * tasaAñoTres) / (12 * 3);
            }
            //PARA  Dos BENEFICIARIO Y SU CANTIDAD DE AÑOS QUE SON 5
            if (cantidadTotal == 2 && años == 1)
            {
                cuota = Nominales.Sum() / 12;
            }
            if (cantidadTotal == 2 && años == 2)
            {
                cuota = (Nominales.Sum() * tasaAñoDos) / (12 * 2);
            }
            if (cantidadTotal == 2 && años == 3)
            {
                cuota = (Nominales.Sum() * tasaAñoTres) / (12 * 3);
            }
            if (cantidadTotal == 2 && años == 4)
            {
                cuota = (Nominales.Sum() * tasaAñoCuatro) / (12 * 4);
            }
            if (cantidadTotal == 2 && años == 5)
            {
                cuota = (Nominales.Sum() * tasaAñoCinco) / (12 * 5);
            }
            //PARA 3 Beneficiarios
            if (cantidadTotal == 3 && años == 1)
            {
                cuota = Nominales.Sum() / 12;
            }
            if (cantidadTotal == 3 && años == 2)
            {
                cuota = (Nominales.Sum() * tasaAñoDos) / (12 * 2);
            }
            if (cantidadTotal == 3 && años == 3)
            {
                cuota = (Nominales.Sum() * tasaAñoTres) / (12 * 3);
            }
            if (cantidadTotal == 3 && años == 4)
            {
                cuota = (Nominales.Sum() * tasaAñoCuatro) / (12 * 4);
            }
            if (cantidadTotal == 3 && años == 5)
            {
                cuota = (Nominales.Sum() * tasaAñoCinco) / (12 * 5);
            }
            if (cantidadTotal == 3 && años == 6)
            {
                cuota = (Nominales.Sum() * tasaAñoCinco) / (12 * 6);
            }
            //PARA CUATRO BENEFICIARIOS DONDE YA TOCA EL MAXIMO DE 7
            if (cantidadTotal == 4 && años == 1)
            {
                cuota = Nominales.Sum() / 12;
            }
            if (cantidadTotal == 4 && años == 2)
            {
                cuota = (Nominales.Sum() * tasaAñoDos) / (12 * 2);
            }
            if (cantidadTotal == 4 && años == 3)
            {
                cuota = (Nominales.Sum() * tasaAñoTres) / (12 * 3);
            }
            if (cantidadTotal == 4 && años == 4)
            {
                cuota = (Nominales.Sum() * tasaAñoCuatro) / (12 * 4);
            }
            if (cantidadTotal == 4 && años == 5)
            {
                cuota = (Nominales.Sum() * tasaAñoCinco) / (12 * 5);
            }
            if (cantidadTotal == 4 && años == 6)
            {
                cuota = (Nominales.Sum() * tasaAñoCinco) / (12 * 6);
            }
            if (cantidadTotal == 4 && años == 7)
            {
                cuota = (Nominales.Sum() * tasaAñoCinco) / (12 * 7);
            }
            //PARA CINCO BENEFICIARIOS
            if (cantidadTotal == 5 && años == 1)
            {
                cuota = Nominales.Sum() / 12;
            }
            if (cantidadTotal == 5 && años == 2)
            {
                cuota = (Nominales.Sum() * tasaAñoDos) / (12 * 2);
            }
            if (cantidadTotal == 5 && años == 3)
            {
                cuota = (Nominales.Sum() * tasaAñoTres) / (12 * 3);
            }
            if (cantidadTotal == 5 && años == 4)
            {
                cuota = (Nominales.Sum() * tasaAñoCuatro) / (12 * 4);
            }
            if (cantidadTotal == 5 && años == 5)
            {
                cuota = (Nominales.Sum() * tasaAñoCinco) / (12 * 5);
            }
            if (cantidadTotal == 5 && años == 6)
            {
                cuota = (Nominales.Sum() * tasaAñoCinco) / (12 * 6);
            }
            if (cantidadTotal == 5 && años == 7)
            {
                cuota = (Nominales.Sum() * tasaAñoCinco) / (12 * 7);
            }
            //PARA 6 BENEFICIARIOS
            if (cantidadTotal == 6 && años == 1)
            {
                cuota = Nominales.Sum() / 12;
            }
            if (cantidadTotal == 6 && años == 2)
            {
                cuota = (Nominales.Sum() * tasaAñoDos) / (12 * 2);
            }
            if (cantidadTotal == 6 && años == 3)
            {
                cuota = (Nominales.Sum() * tasaAñoTres) / (12 * 3);
            }
            if (cantidadTotal == 6 && años == 4)
            {
                cuota = (Nominales.Sum() * tasaAñoCuatro) / (12 * 4);
            }
            if (cantidadTotal == 6 && años == 5)
            {
                cuota = (Nominales.Sum() * tasaAñoCinco) / (12 * 5);
            }
            if (cantidadTotal == 6 && años == 6)
            {
                cuota = (Nominales.Sum() * tasaAñoCinco) / (12 * 6);
            }
            if (cantidadTotal == 6 && años == 7)
            {
                cuota = (Nominales.Sum() * tasaAñoCinco) / (12 * 7);
            }
            //PARA 7 BENEFICIARIOS
            if (cantidadTotal == 7 && años == 1)
            {
                cuota = Nominales.Sum() / 12;
            }
            if (cantidadTotal == 7 && años == 2)
            {
                cuota = (Nominales.Sum() * tasaAñoDos) / (12 * 2);
            }
            if (cantidadTotal == 7 && años == 3)
            {
                cuota = (Nominales.Sum() * tasaAñoTres) / (12 * 3);
            }
            if (cantidadTotal == 7 && años == 4)
            {
                cuota = (Nominales.Sum() * tasaAñoCuatro) / (12 * 4);
            }
            if (cantidadTotal == 7 && años == 5)
            {
                cuota = (Nominales.Sum() * tasaAñoCinco) / (12 * 5);
            }
            if (cantidadTotal == 7 && años == 6)
            {
                cuota = (Nominales.Sum() * tasaAñoCinco) / (12 * 6);
            }
            if (cantidadTotal == 7  && años == 7)
            {
                cuota = (Nominales.Sum() * tasaAñoCinco) / (12 * 7);
            }
            if (cuota == 0)
            {
                MessageBox.Show("Los años de cancelacion son muy altos para la combinacion de contratos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return cuota;

            }
            return cuota;
        }

    }
}
