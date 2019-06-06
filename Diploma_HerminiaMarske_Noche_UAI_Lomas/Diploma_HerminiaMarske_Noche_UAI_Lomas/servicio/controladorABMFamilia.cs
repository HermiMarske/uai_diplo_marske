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
    class ControladorABMFamilia
    {
        private const string FAMILIA_CREADA = "FAMILIA_CREADA";
        private const string MISSING_DATA = "MISSING_DATA";
        private const string FAMILIA_MODIFICADA = "FAMILIA_MODIFICADA";


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
            pms[1].Value = ControladorDigitosVerificadores.calcularDVV(familia.GetDescripcion());

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

        public static string modificarFam(Familia familia)
        {

            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();

            DataConnection.DataConnection dataQueryBP = new DataConnection.DataConnection();
            if (string.IsNullOrEmpty(familia.GetDescripcion()))
            {
                return MISSING_DATA;
            }
            else
            {
                const string modifFam = "UPDATE Familia SET descripcion = @descNueva, dvh = @dvh WHERE idFamilia = @idFamilia";
                const string borrarPat = "DELETE FROM Familia_Patente WHERE familiaFK = @idFamilia";
                const string insertarFamPat = "INSERT INTO Familia_Patente (familiaFK, patenteFK, dvh) VALUES {0}";

                SqlParameter[] pms = new SqlParameter[3];
                pms[0] = new SqlParameter("@descNueva", SqlDbType.VarChar);
                pms[0].Value = familia.GetDescripcion();
                pms[1] = new SqlParameter("@dvh", SqlDbType.Int);
                pms[1].Value = ControladorDigitosVerificadores.calcularDVV(familia.GetDescripcion());
                pms[2] = new SqlParameter("@idFamilia", SqlDbType.Int);
                pms[2].Value = familia.GetId();

                dataQuery.sqlUpsert(modifFam, pms);

                SqlParameter[] pmsBP = new SqlParameter[1];
                pmsBP[0] = new SqlParameter("@idFamilia", SqlDbType.Int);
                pmsBP[0].Value = familia.GetId();

                dataQuery.sqlUpsert(borrarPat, pmsBP);

                string valuesPatentes = "";
                foreach (Patente pat in familia.GetPatentes())
                {
                    string famPatDVV = pat.GetId().ToString() + familia.GetId().ToString();
                    int DVV = ControladorDigitosVerificadores.calcularDVV(famPatDVV);

                    valuesPatentes += (!string.IsNullOrEmpty(valuesPatentes) ? "," : "");
                    valuesPatentes += new StringBuilder("(").Append(familia.GetId() + ",")
                        .Append(pat.GetId() + ",").Append(DVV).Append(")").ToString();
                }

                dataQuery.sqlUpsert(string.Format(insertarFamPat, valuesPatentes), null);


                return FAMILIA_MODIFICADA;


            }

        }
    }
}
