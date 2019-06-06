using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio
{
    class ControladorDigitosVerificadores
    {
        public static int calcularDVV(String entrada)
        {
            int salida = 0;

            entrada.Trim();

            char[] entradaParaProcesar = entrada.ToCharArray();

            int[] entradaArray = new int[entrada.Length];

            for(int i=0; i<=entrada.Length-1; i++)
            {
                int val = Convert.ToInt32((entradaParaProcesar[i]));
                entradaArray[i] = val * i;
            }

            for(int i=0; i<=entradaArray.Length-1; i++)
            { 
                salida += entradaArray[i];
            }

            return salida;
        }



        public static void calcularDVH()
        {

        }

        public static void recalcularDV()
        {

        }

        
    }


}
