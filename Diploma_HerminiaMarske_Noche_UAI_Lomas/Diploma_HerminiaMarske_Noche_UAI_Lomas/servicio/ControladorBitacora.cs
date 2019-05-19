using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio
{
    class ControladorBitacora
    {
        private void grabarRegistro(BitacoraRow row)
        {
            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            const string altaRegistro = "INSERT INTO Bitacora (timestamp, criticidad, descripcion, FK_Usuario, dvh) values (@timestamp, @criticidad, @descripcion, @idUsuario, @dvh)";

            SqlParameter[] pms = new SqlParameter[5];
            pms[0] = new SqlParameter("@timestamp", SqlDbType.DateTime);
            pms[0].Value = row.GetTimeStamp();
            pms[1] = new SqlParameter("@criticidad", SqlDbType.VarChar);
            pms[1].Value = row.GetCriticidad();
            pms[2] = new SqlParameter("@descripcion", SqlDbType.VarChar);
            pms[2].Value = row.GetDescripcion();
            pms[3] = new SqlParameter("@idUsuario", SqlDbType.Int);
            pms[3].Value = row.GetUsuario().GetIdUsuario();
            pms[4] = new SqlParameter("@dvh", SqlDbType.Int);
            pms[4].Value = 123;

            dataQuery.sqlUpsert(altaRegistro, pms);

        }
    }
}
