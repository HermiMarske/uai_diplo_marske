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
    class ControladorABMActividad
    {
        public const string ACTIVIDAD_CREADA = "ACTIVIDAD_CREADA";
        public const string ACTIVIDAD_ERROR = "ACTIVIDAD_ERROR";
        public const string ACTIVIDAD_BORRADA = "ACTIVIDAD_BORRADA";


        public static Actividad getActividad(int id)
        {

            return null;
        }

        public static string borrarActividad(int id)
        {
            const string borrarActividad = "DELETE FROM Actividades WHERE idActividad = @id";

            SqlParameter[] pms = new SqlParameter[1];
            pms[0] = new SqlParameter("@id", SqlDbType.Int);
            pms[0].Value = id;


            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();

            try
            {
                dataQuery.sqlExecute(borrarActividad, pms);
                return ACTIVIDAD_BORRADA;
            }
            catch
            {
                return ACTIVIDAD_ERROR;
            }
        }

        public static string altaActividad(Actividad actividad)
        {
            string alta = "insert into Actividades (horaInicio,horas, texto, pilotoFK, localidadFK, clienteFK, avionFK)" +
                " values(@horaInicio, @horas, @texto, @pilotoFK, @localidadFK, @clienteFK, @avionFK)";

            SqlParameter[] pms = new SqlParameter[7];
            pms[0] = new SqlParameter("@horaInicio", SqlDbType.DateTime);
            pms[0].Value = actividad.GetFechaHoraInicio();
            pms[1] = new SqlParameter("@horas", SqlDbType.Int);
            pms[1].Value = actividad.GetHoras();
            pms[2] = new SqlParameter("@texto", SqlDbType.VarChar);
            pms[2].Value = actividad.GetTexto();
            pms[3] = new SqlParameter("@pilotoFK", SqlDbType.Int);
            pms[3].Value = actividad.GetPiloto().GetId();
            pms[4] = new SqlParameter("@localidadFK", SqlDbType.Int);
            pms[4].Value = actividad.GetLocalidad().GetId();
            pms[5] = new SqlParameter("@clienteFK", SqlDbType.Int);
            pms[5].Value = actividad.GetCliente().GetId();
            pms[6] = new SqlParameter("@avionFK", SqlDbType.Int);
            pms[6].Value = actividad.GetAvion().GetId();

            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();

            try
            {
                dataQuery.sqlExecute(alta, pms);
                return ACTIVIDAD_CREADA;
            }
            catch
            {
                return ACTIVIDAD_ERROR;
            }



        }
    }
}
