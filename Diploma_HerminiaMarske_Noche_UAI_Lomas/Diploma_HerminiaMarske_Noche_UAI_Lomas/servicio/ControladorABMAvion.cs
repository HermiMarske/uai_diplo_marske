using Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio
{
    class ControladorABMAvion
    {

        private const string AVION_CREADO = "AVION_CREADO";
        private const string AVION_ERROR = "AVION_ERROR";
        private const string AVION_BORRADO = "AVION_BORRADO";
        private const string AVION_MODIFICADO = "AVION_MODIFICADO";

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
                return AVION_CREADO;
            }
            catch
            {
                return AVION_ERROR;
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
                return AVION_MODIFICADO;
            }
            catch
            {
                return AVION_ERROR;
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
                return AVION_BORRADO;
            }
            catch
            {
                return AVION_ERROR;
            }
        }
    }
}
