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
    class ControladorABMUsuario
    {
        private const string USER_CREATED_EXISTING_PERSON = "USER_CREATED_EXISTING_PERSON";
        private const string MISSING_DATA = "MISSING_DATA";
        private const string USER_EXISTS = "USER_EXISTS";
        private const string USER_CREATED_PERSON_CREATED = "USER_CREATED_PERSON_CREATED";
        private const string PERSON_HAS_USER = "PERSON_HAS_USER";
        private const string MISSING_INFO = "MISSING_INFO";

        static public string alta(Usuario usuario, List<Domicilio> domicilios, List<Mail> mails, List<Telefono> telefonos)
        {
                 
            if (string.IsNullOrEmpty(usuario.GetPassword()) || string.IsNullOrEmpty(usuario.GetNombreUsuario()) || (usuario.GetPatentes().Count == 0 && usuario.GetFamilias().Count == 0)) 
            {
                return MISSING_INFO;

            } else if (domicilios.Count == 0 || mails.Count == 0 || telefonos.Count == 0 || string.IsNullOrWhiteSpace(usuario.GetPersona().GetDni()))
            {
                return MISSING_INFO;
            }
            else
            {
                string personaExiste = "SELECT TOP 1 ID_Persona FROM Personas WHERE dni = @dniPersona;";
                string usuarioExiste = "SELECT TOP 1 ID_Usuario FROM Usuarios WHERE FK_Persona = @idPersona;";
                string crearUsuario = "INSERT INTO Usuarios (usuario, clave, CII, habilitado, FK_Persona, respuesta, FK_Pregunta)" +
                    " VALUES (@usuario, @clave, 0, 1, @fkPersona, @respuesta, @fkPregunta);";
                string crearPersona = "INSERT INTO Persona (dni, nombre, apellido, sexo, fechaNacimiento)" +
                    " VALUES (@dni, @nombre, @apellido, @sexo, @fechaNacimiento);" +
                    " SELECT SCOPE_IDENTITY();";
                string crearDomicilios = "INSERT INTO Domicilio(calle,numero,piso,dpto, comentarios, codPostal,tipoDomicilio, FK_Localidad, FK_Persona) " +
                    "VALUES {0}";
                string crearMails = "INSERT INTO Mails(tipo, mail, FK_Persona) VALUES {0}";
                string crearTelefonos = "INSERT INTO Telefono(tipo,numero, FK_Persona) VALUES {0}";

                SqlParameter[] pms = new SqlParameter[1];
                pms[0] = new SqlParameter("@dniPersona", SqlDbType.VarChar);
                pms[0].Value = usuario.GetPersona().GetDni();

                DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
                DataTable dt = new DataTable();
                dt = dataQuery.sqlExecute(personaExiste, pms);
                int pExiste = dt.Rows.Count > 0 ? (int)dt.Rows[0][0] : 0;

                if (pExiste != 0)
                {
                    pms = new SqlParameter[1];
                    pms[0] = new SqlParameter("@idPersona", SqlDbType.Int);
                    pms[0].Value = pExiste;

                    dt = dataQuery.sqlExecute(usuarioExiste, pms);
                    int uExiste = dt.Rows.Count > 0 ? (int)dt.Rows[0][0] : 0;

                    if (uExiste != 0)
                    {
                        return PERSON_HAS_USER;
                    } else
                    {
                        pms = new SqlParameter[5];
                        pms[0] = new SqlParameter("@usuario", SqlDbType.VarChar);
                        pms[0].Value = usuario.GetIdUsuario();
                        pms[1] = new SqlParameter("@clave", SqlDbType.VarChar);
                        pms[1].Value = ControladorEncriptacion.Hash(usuario.GetPassword());
                        pms[2] = new SqlParameter("@fkPersona", SqlDbType.Int);
                        pms[2].Value = pExiste;
                        pms[3] = new SqlParameter("@respuesta", SqlDbType.VarChar);
                        pms[3].Value = usuario.GetRespuesta();
                        pms[4] = new SqlParameter("@fkPregunta", SqlDbType.Int);
                        pms[4].Value = usuario.GetFkPregunta();

                        dataQuery.sqlUpsert(crearUsuario, pms);

                        return USER_CREATED_EXISTING_PERSON;
                    }
                } else
                {
                    Persona p = usuario.GetPersona();
                    pms = new SqlParameter[5];
                    pms[0] = new SqlParameter("@dni", SqlDbType.VarChar);
                    pms[0].Value = p.GetDni();
                    pms[1] = new SqlParameter("@nombre", SqlDbType.VarChar);
                    pms[1].Value = p.GetNombre();
                    pms[2] = new SqlParameter("@apellido", SqlDbType.Int);
                    pms[2].Value = p.GetApellido();
                    pms[3] = new SqlParameter("@sexo", SqlDbType.VarChar);
                    pms[3].Value = p.GetSexo();
                    pms[4] = new SqlParameter("@fechaNacimiento", SqlDbType.Int);
                    pms[4].Value = p.GetFechaNacimiento();

                    dt = dataQuery.sqlExecute(crearPersona, pms);
                    int pCreada = (int)dt.Rows[0][0];

                    string valuesDomicilios = "";
                    foreach (Domicilio d in domicilios)
                    {
                        valuesDomicilios += (!string.IsNullOrEmpty(valuesDomicilios) ? "," : "");
                        valuesDomicilios += new StringBuilder("(").Append("'"+d.GetCalle()+"',")
                            .Append("'"+d.GetNumero()+"',").Append(d.GetPiso()+",").Append("'"+d.GetDpto()+"',")
                            .Append("'"+d.GetComentario()+"',").Append("'"+d.GetCodigoPostal()+"',").Append("'"+d.GetTipoDomicilio()+"',")
                            .Append(d.GetLocalidad()+",").Append(pCreada).Append(")").ToString();
                    }

                    string valuesMails = "";
                    foreach (Mail m in mails)
                    {
                        valuesMails += (!string.IsNullOrEmpty(valuesMails) ? "," : "");
                        valuesMails += new StringBuilder("(").Append("'"+m.GetTipo()+"',")
                            .Append("'"+m.GetMail()+"',").Append(pCreada).Append(")").ToString();
                    }

                    string valuesTelefonos = "";
                    foreach (Telefono t in telefonos)
                    {
                        valuesTelefonos += (!string.IsNullOrEmpty(valuesTelefonos) ? "," : "");
                        valuesTelefonos += new StringBuilder("(").Append("'" + t.GetTipo() + "',")
                            .Append("'" + t.GetNumero() + "',").Append(pCreada).Append(")").ToString();
                    }

                    dataQuery.sqlUpsert(string.Format(crearDomicilios, valuesDomicilios), null);
                    dataQuery.sqlUpsert(string.Format(crearMails, valuesMails), null);
                    dataQuery.sqlUpsert(string.Format(crearTelefonos, valuesTelefonos), null);
    
                    pms = new SqlParameter[5];
                    pms[0] = new SqlParameter("@usuario", SqlDbType.VarChar);
                    pms[0].Value = usuario.GetIdUsuario();
                    pms[1] = new SqlParameter("@clave", SqlDbType.VarChar);
                    pms[1].Value = ControladorEncriptacion.Hash(usuario.GetPassword());
                    pms[2] = new SqlParameter("@fkPersona", SqlDbType.Int);
                    pms[2].Value = pCreada;
                    pms[3] = new SqlParameter("@respuesta", SqlDbType.VarChar);
                    pms[3].Value = usuario.GetRespuesta();
                    pms[4] = new SqlParameter("@fkPregunta", SqlDbType.Int);
                    pms[4].Value = usuario.GetFkPregunta();

                    dataQuery.sqlUpsert(crearUsuario, pms);

                    return USER_CREATED_PERSON_CREATED;
                }
            }

            return null;
        }

    }
}
