using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio
{
    class ControladorDigitosVerificadores
    {
        public static int calcularDVH(String entrada)
        {
            int salida = 0;

            entrada.Trim();

            char[] entradaParaProcesar = entrada.ToCharArray();

            int[] entradaArray = new int[entrada.Length];


            for(int i=0; i<=entrada.Length-1; i++)
            {
                int val = Convert.ToInt32((entradaParaProcesar[i]));
                entradaArray[i] = val * (i+1);
                salida += entradaArray[i];
            }
            return salida;
        }



        public static void calcularDVV(string tableName)
        {
            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            SqlParameter[] pms = new SqlParameter[2];
            string calculoDVV = "SELECT SUM(dvh) FROM " + tableName;

            string insertDVV = "UPDATE DDVV SET dvv = (SELECT SUM(DVH) FROM " + tableName + ") WHERE tabla = '" + tableName + "'";

            dataQuery.sqlUpsert(insertDVV, null);

        }

        public static void recalcularDV()
        {

        }

        
    }


}
