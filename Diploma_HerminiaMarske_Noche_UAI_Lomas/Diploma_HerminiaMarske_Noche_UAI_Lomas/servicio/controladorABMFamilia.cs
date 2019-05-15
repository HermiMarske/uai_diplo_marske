using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio
{
    class controladorABMFamilia
    {
        private const string FAMILIA_CREADA = "FAMILIA_CREADA";
        private const string MISSING_DATA = "MISSING_DATA";


        public static string altaFam(Familia familia)
        {
            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            if (string.IsNullOrEmpty(familia.GetDescripcion()))
            {
                return MISSING_DATA;
            }
            else
            {

            const string altaFam = "INSERT INTO Familia (descripcion, dvh)" +
                    " VALUES (@descripcion, @dvh);" +
                    " SELECT SCOPE_IDENTITY();";
            const string insertarFamPat = "INSERT INTO Familia_Patente (familiaFK, patenteFK, dvh) VALUES {0}";

            SqlParameter[] pms = new SqlParameter[2];
            pms[0] = new SqlParameter("@descripcion", SqlDbType.VarChar);
            pms[0].Value = familia.GetDescripcion();
            pms[1] = new SqlParameter("@dvh", SqlDbType.Int);
            pms[1].Value = 1;

            DataTable dt = dataQuery.sqlExecute(altaFam, pms);
            int familiaCreada = Decimal.ToInt32((decimal)dt.Rows[0][0]);

            string valuesPatentes = "";
            foreach (Patente pat in familia.GetPatentes())
            {
                valuesPatentes += (!string.IsNullOrEmpty(valuesPatentes) ? "," : "");
                valuesPatentes += new StringBuilder("(").Append(familiaCreada + ",")
                    .Append(pat.GetId() + ",").Append(123).Append(")").ToString();
            }

            dataQuery.sqlUpsert(string.Format(insertarFamPat, valuesPatentes), null);
                return FAMILIA_CREADA;
            }


        }
    }
}
