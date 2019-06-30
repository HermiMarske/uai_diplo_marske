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
            Actividad actividad = new Actividad();
            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            string getActividad = "select horaInicio,horas,texto, pilotoFK, localidadFK, clienteFK, avionFK from Actividades where idActividad = @id";
            string getPiloto = "select per.nombre, per.apellido from Pilotos p, Personas per where per.ID_Persona = p.FK_Persona AND p.ID_Piloto = @idPiloto";
            SqlParameter[] pms = new SqlParameter[1];
            pms[0] = new SqlParameter("@id", SqlDbType.Int);
            pms[0].Value = id;

            SqlParameter[] pmsPiloto = new SqlParameter[1];
            int idPiloto = 0;
            int idCliente = 0;
            int idLocalidad = 0;
            int idAvion = 0;

            try
            {
                DataTable dt = new DataTable();
                dt = dataQuery.sqlExecute(getActividad, pms);
                foreach (DataRow dr in dt.Rows)
                {
                    actividad.SetFechaHoraInicio((DateTime)dr[0]);
                    actividad.SetHoras((int)dr[1]);
                    actividad.SetTexto((string)dr[2]);

                    idPiloto = ((int)dr[3]);
                    idLocalidad = ((int)dr[4]);
                    idCliente = ((int)dr[5]);
                    idAvion = ((int)dr[6]);
                   
                }

                DataTable dtPiloto = new DataTable();
                pmsPiloto[0] = new SqlParameter("@idPiloto", SqlDbType.Int);
                pmsPiloto[0].Value = idPiloto;
                dtPiloto = dataQuery.sqlExecute(getPiloto, pmsPiloto);

                Piloto piloto = new Piloto();
                Persona persona = new Persona();

                foreach(DataRow dr in dtPiloto.Rows)
                {
                    persona.SetNombre((string)dr[0]);
                    persona.SetApellido((string)dr[1]);
                    
                }
                piloto.SetPersona(persona);
                actividad.SetPiloto(piloto);

                string getCliente = "select razonSocial from Cliente c where c.ID_Cliente = @idCliente";
                SqlParameter[] pmsCliente = new SqlParameter[1];
                pmsCliente[0] = new SqlParameter("@idCliente", SqlDbType.Int);
                pmsCliente[0].Value = idCliente;

                DataTable dtCliente = new DataTable();
                dtCliente = dataQuery.sqlExecute(getCliente, pmsCliente);
                Cliente cliente = new Cliente();

                foreach(DataRow dr in dtCliente.Rows)
                {
                    cliente.SetRazonSocial((string)dr[0]);
                }

                actividad.SetCliente(cliente);

                string getArea = "select l.descripcion, pr.descripcion, p.nombre from Localidades l, Pais p, Provincias pr where l.FK_Provincia = pr.ID_Provincia AND pr.FK_Pais = p.ID_Pais AND l.ID_Localidad = @idLocalidad";

                SqlParameter[] pmsLocalidad = new SqlParameter[1];
                pmsLocalidad[0] = new SqlParameter("@idLocalidad", SqlDbType.Int);
                pmsLocalidad[0].Value = idLocalidad;

                DataTable dtArea = new DataTable();
                dtArea = dataQuery.sqlExecute(getArea, pmsLocalidad);

                Localidad localidad = new Localidad();
                Pais pais = new Pais();
                Provincia provincia = new Provincia();

                foreach(DataRow dr in dtArea.Rows)
                {
                    localidad.SetNombre((string)dr[0]);
                    provincia.SetNombre((string)dr[1]);
                    pais.SetNombre((string)dr[2]);
                }

                localidad.SetPais(pais);
                localidad.SetProvincia(provincia);
                actividad.SetLocalidad(localidad);


                string getAvion = "select matricula from Aviones where ID_Avion = @idAvion";
                SqlParameter[] pmsAvion = new SqlParameter[1];
                pmsAvion[0] = new SqlParameter("@idAvion", SqlDbType.Int);
                pmsAvion[0].Value = idAvion;

                DataTable dtAvion = new DataTable();
                dtAvion = dataQuery.sqlExecute(getAvion, pmsAvion);

                Avion avion = new Avion();

                foreach (DataRow dr in dtAvion.Rows)
                {
                    avion.SetMatricula((string)dr[0]);
                }

                actividad.SetAvion(avion);

                return actividad;

            }

            catch
            {
                return null;
                
            }

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
