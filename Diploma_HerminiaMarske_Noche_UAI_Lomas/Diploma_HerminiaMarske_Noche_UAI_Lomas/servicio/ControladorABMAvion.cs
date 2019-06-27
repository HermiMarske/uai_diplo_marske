using Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Resources;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio
{
    class ControladorABMAvion
    {

        private const string AIRPLANE_CREATED = "AIRPLANE_CREATED";
        private const string AIRPLANE_ERROR = "AIRPLANE_ERROR";
        private const string AIRPLANE_DELETED = "AIRPLANE_DELETED";
        private const string AIRPLANE_MODIFIED = "AIRPLANE_MODIFIED";
        private static ResourceManager rm = new ResourceManager(typeof(Properties.strings));

        public static string crearAvion(Avion avion)
        {
            const string altaAvion = "INSERT INTO Aviones (matricula, marca, modelo, habilitado) values (@matricula, @marca, @modelo, @habilitado)";

            SqlParameter[] pms = new SqlParameter[4];
            pms[0] = new SqlParameter("@matricula", SqlDbType.VarChar);
            pms[0].Value = avion.GetMatricula();
            pms[1] = new SqlParameter("@marca", SqlDbType.VarChar);
            pms[1].Value = avion.GetMarca();
            pms[2] = new SqlParameter("@modelo", SqlDbType.VarChar);
            pms[2].Value = avion.GetModelo();
            pms[3] = new SqlParameter("@habilitado", SqlDbType.Bit);
            pms[3].Value = avion.GetHabilitado();

            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();

            try
            {
                dataQuery.sqlExecute(altaAvion, pms);
                return rm.GetString(AIRPLANE_CREATED.ToLower());
            }
            catch
            {
                throw new Exception(rm.GetString(AIRPLANE_ERROR.ToLower()));
            }
        }

        public static string modificarAvion(Avion avion)
        {
            const string modificarAvion = "UPDATE Aviones SET matricula=@matricula, marca=@marca, modelo=@modelo, habilitado=@habilitado WHERE ID_Avion = @idAvion";

            SqlParameter[] pms = new SqlParameter[5];
            pms[0] = new SqlParameter("@matricula", SqlDbType.VarChar);
            pms[0].Value = avion.GetMatricula();
            pms[1] = new SqlParameter("@marca", SqlDbType.VarChar);
            pms[1].Value = avion.GetMarca();
            pms[2] = new SqlParameter("@modelo", SqlDbType.VarChar);
            pms[2].Value = avion.GetModelo();
            pms[3] = new SqlParameter("@habilitado", SqlDbType.Bit);
            pms[3].Value = avion.GetHabilitado();
            pms[4] = new SqlParameter("@idAvion", SqlDbType.Int);
            pms[4].Value = avion.GetId();

            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();

            try
            {
                dataQuery.sqlExecute(modificarAvion, pms);
                return rm.GetString(AIRPLANE_MODIFIED.ToLower());
            }
            catch
            {
                throw new Exception(rm.GetString(AIRPLANE_ERROR.ToLower()));
            }
        }

        public static string borrarAvion(int id)
        {
            const string borrarAvion = "DELETE FROM Aviones WHERE ID_Avion = @idAvion";

            SqlParameter[] pms = new SqlParameter[1];
            pms[0] = new SqlParameter("@idAvion", SqlDbType.Int);
            pms[0].Value = id;
  
            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();

            try
            {
                dataQuery.sqlExecute(borrarAvion, pms);
                return rm.GetString(AIRPLANE_DELETED.ToLower());
            }
            catch
            {
                throw new Exception(rm.GetString(AIRPLANE_ERROR.ToLower()));
            }
        }

        public static List<Avion> getAviones()
        {
            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            DataTable dt = new DataTable();

            List<Avion> aviones = new List<Avion>();

            const string getAviones = "SELECT ID_Avion, matricula, marca, modelo, habilitado FROM Aviones";

            try
            {
                dt = dataQuery.sqlExecute(getAviones, null);

                foreach (DataRow dr in dt.Rows)
                {
                    Avion av = new Avion((int)dr[0], (string)dr[1], (string)dr[2], (string)dr[3], (bool)dr[4]);

                    aviones.Add(av);
                }

                return aviones;
            }
            catch
            {
                throw new Exception(rm.GetString(AIRPLANE_ERROR.ToLower()));
            }
            
        }
    }
}
