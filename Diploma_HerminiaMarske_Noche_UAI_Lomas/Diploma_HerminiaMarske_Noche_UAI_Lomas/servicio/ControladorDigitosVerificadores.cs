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

            int[] entradaArray = {0};

            for(int i=0; i<=entrada.Length; i++)
            {
                entradaArray[i] = Convert.ToInt32(new string(entradaParaProcesar[i], 1)) * i;
            }

            for(int i=0; i<=entradaArray.Length; i++)
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
