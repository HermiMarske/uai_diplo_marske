using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.Constantes;
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

            const string altaFam = "INSERT INTO Familia (descripcion)" +
                    " VALUES (@descripcion);" +
                    " SELECT SCOPE_IDENTITY();";
            const string insertarFamPat = "INSERT INTO Familia_Patente (familiaFK, patenteFK, dvh) VALUES {0}";

            SqlParameter[] pms = new SqlParameter[1];
            pms[0] = new SqlParameter("@descripcion", SqlDbType.VarChar);
            pms[0].Value =  ControladorEncriptacion.Encrypt(familia.GetDescripcion());
       

            DataTable dt = dataQuery.sqlExecute(altaFam, pms);
            int familiaCreada = Decimal.ToInt32((decimal)dt.Rows[0][0]);

            string valuesPatentes = "";
            foreach (Patente pat in familia.GetPatentes())
            {

                    int dvh = ControladorDigitosVerificadores.calcularDVH(familiaCreada.ToString() + pat.GetId().ToString());

                valuesPatentes += (!string.IsNullOrEmpty(valuesPatentes) ? "," : "");
                valuesPatentes += new StringBuilder("(").Append(familiaCreada + ",")
                    .Append(pat.GetId() + ",").Append(dvh).Append(")").ToString();
            }

            dataQuery.sqlUpsert(string.Format(insertarFamPat, valuesPatentes), null);

                ControladorDigitosVerificadores.calcularDVV(ConstantesDDVV.TABLA_FAMILIA_PATENTE);

                //BitacoraRow rowBitacora = new BitacoraRow()
                //ControladorBitacora.grabarRegistro()

                BitacoraRow bitacora = new BitacoraRow(DateTime.UtcNow, ConstantesBitacora.CRITICIDAD_MEDIA, ConstantesBitacora.ALTA_FAMILIA, new Usuario());
                ControladorBitacora.grabarRegistro(bitacora);

                return FAMILIA_CREADA;
            }


        }

        public static string modificarFam(Familia familia)
        {

            if (familia.GetDescripcion().Equals(ConstantesFamilias.ADMIN_ACTIVIDADES) ||
               familia.GetDescripcion().Equals(ConstantesFamilias.ADMIN_CLIENTES) ||
               familia.GetDescripcion().Equals(ConstantesFamilias.ADMIN_EMPLEADOS) ||
               familia.GetDescripcion().Equals(ConstantesFamilias.ADMIN_RECURSOS) ||
               familia.GetDescripcion().Equals(ConstantesFamilias.ADMIN_SEGURIDAD) ||
               familia.GetDescripcion().Equals(ConstantesFamilias.ADMIN_USUARIOS))
            {
                return "No es posible modificar una familia del sistema.";
            }
            else
            {

                DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();

                DataConnection.DataConnection dataQueryBP = new DataConnection.DataConnection();
                if (string.IsNullOrEmpty(familia.GetDescripcion()))
                {
                    return MISSING_DATA;
                }
                else
                {
                    const string modifFam = "UPDATE Familia SET descripcion = @descNueva WHERE idFamilia = @idFamilia";
                    const string borrarPat = "DELETE FROM Familia_Patente WHERE familiaFK = @idFamilia";
                    const string insertarFamPat = "INSERT INTO Familia_Patente (familiaFK, patenteFK, dvh) VALUES {0}";

                    SqlParameter[] pms = new SqlParameter[2];
                    pms[0] = new SqlParameter("@descNueva", SqlDbType.VarChar);
                    pms[0].Value = ControladorEncriptacion.Encrypt(familia.GetDescripcion());
                    pms[1] = new SqlParameter("@idFamilia", SqlDbType.Int);
                    pms[1].Value = familia.GetId();

                    dataQuery.sqlUpsert(modifFam, pms);

                    SqlParameter[] pmsBP = new SqlParameter[1];
                    pmsBP[0] = new SqlParameter("@idFamilia", SqlDbType.Int);
                    pmsBP[0].Value = familia.GetId();

                    dataQuery.sqlUpsert(borrarPat, pmsBP);

                    string valuesPatentes = "";
                    foreach (Patente pat in familia.GetPatentes())
                    {
                        string famPatDVV = pat.GetId().ToString() + familia.GetId().ToString();
                        int DVV = ControladorDigitosVerificadores.calcularDVH(famPatDVV);

                        valuesPatentes += (!string.IsNullOrEmpty(valuesPatentes) ? "," : "");
                        valuesPatentes += new StringBuilder("(").Append(familia.GetId() + ",")
                            .Append(pat.GetId() + ",").Append(DVV).Append(")").ToString();
                    }

                    dataQuery.sqlUpsert(string.Format(insertarFamPat, valuesPatentes), null);
                    ControladorDigitosVerificadores.calcularDVV(ConstantesDDVV.TABLA_FAMILIA_PATENTE);

                    BitacoraRow bitacora = new BitacoraRow(DateTime.UtcNow, ConstantesBitacora.CRITICIDAD_ALTA, ConstantesBitacora.MODIFICAR_FAMILIA, new Usuario());
                    ControladorBitacora.grabarRegistro(bitacora);

                    return FAMILIA_MODIFICADA;


                }
            }


        }

        public static string borrarFamilia(Familia familia)
        {
            if(familia.GetDescripcion().Equals(ConstantesFamilias.ADMIN_ACTIVIDADES) || 
                familia.GetDescripcion().Equals(ConstantesFamilias.ADMIN_CLIENTES) ||
                familia.GetDescripcion().Equals(ConstantesFamilias.ADMIN_EMPLEADOS) ||
                familia.GetDescripcion().Equals(ConstantesFamilias.ADMIN_RECURSOS) ||
                familia.GetDescripcion().Equals(ConstantesFamilias.ADMIN_SEGURIDAD) ||
                familia.GetDescripcion().Equals(ConstantesFamilias.ADMIN_USUARIOS))
            {
                return "No es posible eliminar una familia del sistema.";
            } else
            {
                try
                {
                    DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
                    const string bajaFam = "UPDATE Familia SET borrado = @fechaBorrado WHERE descripcion = @familia";
                    SqlParameter[] pms = new SqlParameter[2];
                    pms[0] = new SqlParameter("@fechaBorrado", SqlDbType.DateTime);
                    pms[0].Value = DateTime.Now;
                    pms[1] = new SqlParameter("@familia", SqlDbType.VarChar);
                    pms[1].Value = ControladorEncriptacion.Encrypt(familia.GetDescripcion());

                    dataQuery.sqlUpsert(bajaFam, pms);

                    const string deleteFamUsuarios = "DELETE Usuario_Familia WHERE familiaFK IN (SELECT idFamilia FROM Familia WHERE descripcion = @familia)";
                    pms = new SqlParameter[1];
                    pms[0] = new SqlParameter("@familia", SqlDbType.VarChar);
                    pms[0].Value = ControladorEncriptacion.Encrypt(familia.GetDescripcion());

                    dataQuery.sqlUpsert(deleteFamUsuarios, pms);

                    BitacoraRow bitacora = new BitacoraRow(DateTime.UtcNow, ConstantesBitacora.CRITICIDAD_ALTA, ConstantesBitacora.BAJA_FAMILIA, new Usuario());
                    ControladorBitacora.grabarRegistro(bitacora);

                    return "Familia " + familia.GetDescripcion() + " borrada con exito.";
             
                } catch
                {
                    return "Error al borrar la familia seleccionada.";
                }


            }

        }
    }
}
