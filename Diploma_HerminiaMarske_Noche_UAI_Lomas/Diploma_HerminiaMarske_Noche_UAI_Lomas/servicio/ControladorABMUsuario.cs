﻿using ConstantesData;
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

        private static void crearUsuario(Usuario usuario, int persona, DataConnection.DataConnection dataQuery)
        {
            const string altaUsuario = "INSERT INTO Usuarios (usuario, clave, CII, habilitado, DVH, FK_Persona, respuesta, FK_Pregunta)" +
                    " VALUES (@usuario, @clave, 0, 1, @dvh, @fkPersona, @respuesta, @fkPregunta);" +
                    " SELECT SCOPE_IDENTITY();";
            const string insertarPatentes = "INSERT INTO Usuario_Patente (patenteFK, usuarioFK, negado) VALUES {0}";
            const string insertarFamilia = "INSERT INTO Usuario_Familia (familiaFK, usuarioFK) VALUES {0}";

            string usuarioEncriptado = ControladorEncriptacion.Encrypt(usuario.GetNombreUsuario());

            SqlParameter[] pms = new SqlParameter[6];
            pms[0] = new SqlParameter("@usuario", SqlDbType.VarChar);
            pms[0].Value = usuarioEncriptado;
            pms[1] = new SqlParameter("@clave", SqlDbType.VarChar);
            pms[1].Value = ControladorEncriptacion.Hash(usuario.GetPassword());
            pms[2] = new SqlParameter("@dvh", SqlDbType.Int);
            pms[2].Value = ControladorDigitosVerificadores.calcularDVH(usuarioEncriptado + "0");
            pms[3] = new SqlParameter("@fkPersona", SqlDbType.Int);
            pms[3].Value = persona;
            pms[4] = new SqlParameter("@respuesta", SqlDbType.VarChar);
            pms[4].Value = usuario.GetRespuesta();
            pms[5] = new SqlParameter("@fkPregunta", SqlDbType.Int);
            pms[5].Value = usuario.GetFkPregunta();

            DataTable dt = dataQuery.sqlExecute(altaUsuario, pms);
            int uCreado = Decimal.ToInt32((decimal)dt.Rows[0][0]);

            string valuesPatentes = "";
            foreach (Patente pat in usuario.GetPatentes())
            {
                valuesPatentes += (!string.IsNullOrEmpty(valuesPatentes) ? "," : "");
                valuesPatentes += new StringBuilder("(").Append(pat.GetId() + ",")
                    .Append(uCreado + ",").Append(pat.GetNegado() ? 1 : 0).Append(")").ToString();
            }

            string valuesFamilias = "";
            foreach (Familia fam in usuario.GetFamilias())
            {
                valuesFamilias += (!string.IsNullOrEmpty(valuesFamilias) ? "," : "");
                valuesFamilias += new StringBuilder("(").Append(fam.GetId() + ",")
                    .Append(uCreado).Append(")").ToString();
            }

            dataQuery.sqlUpsert(string.Format(insertarPatentes, valuesPatentes), null);
            dataQuery.sqlUpsert(string.Format(insertarFamilia, valuesFamilias), null);
        }

        static public string alta(Usuario usuario, List<Domicilio> domicilios, List<Mail> mails, List<Telefono> telefonos)
        {
                 
            if (string.IsNullOrEmpty(usuario.GetPassword()) || string.IsNullOrEmpty(usuario.GetNombreUsuario()) || (usuario.GetPatentes().Count == 0 && usuario.GetFamilias().Count == 0)) 
            {
                return MISSING_INFO;

            } else if ((domicilios.Count == 0 && mails.Count == 0 && telefonos.Count == 0) || string.IsNullOrWhiteSpace(usuario.GetPersona().GetDni()))
            {
                return MISSING_INFO;
            }
            else
            {
                string personaExiste = "SELECT TOP 1 ID_Persona FROM Personas WHERE dni = @dniPersona;";
                string usuarioExiste = "SELECT TOP 1 ID_Usuario FROM Usuarios WHERE {0};";
                string altaPersona = "INSERT INTO Personas (dni, nombre, apellido, sexo, fechaNacimiento)" +
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

                pms = new SqlParameter[1];
                pms[0] = new SqlParameter("@usuario", SqlDbType.VarChar);
                pms[0].Value = usuario.GetNombreUsuario();

                dt = dataQuery.sqlExecute(string.Format(usuarioExiste, "usuario = @usuario"), pms);
                int eUsuario = dt.Rows.Count > 0 ? (int)dt.Rows[0][0] : 0;

                
                if (eUsuario != 0)
                {
                    return USER_EXISTS;
                }
                else if (pExiste != 0)
                {
                    pms = new SqlParameter[1];
                    pms[0] = new SqlParameter("@idPersona", SqlDbType.Int);
                    pms[0].Value = pExiste;

                    dt = dataQuery.sqlExecute(string.Format(usuarioExiste, "FK_Persona = @idPersona"), pms);
                    int pUsuario = dt.Rows.Count > 0 ? (int)dt.Rows[0][0] : 0;

                    if (pUsuario != 0)
                    {
                        return PERSON_HAS_USER;
                    }
                    else
                    {
                        crearUsuario(usuario, pExiste, dataQuery);

                        return USER_CREATED_EXISTING_PERSON;
                    }
                }
                else
                {
                    Persona p = usuario.GetPersona();
                    pms = new SqlParameter[5];
                    pms[0] = new SqlParameter("@dni", SqlDbType.VarChar);
                    pms[0].Value = p.GetDni();
                    pms[1] = new SqlParameter("@nombre", SqlDbType.VarChar);
                    pms[1].Value = p.GetNombre();
                    pms[2] = new SqlParameter("@apellido", SqlDbType.VarChar);
                    pms[2].Value = p.GetApellido();
                    pms[3] = new SqlParameter("@sexo", SqlDbType.VarChar);
                    pms[3].Value = p.GetSexo();
                    pms[4] = new SqlParameter("@fechaNacimiento", SqlDbType.Date);
                    pms[4].Value = p.GetFechaNacimiento();

                    dt = dataQuery.sqlExecute(altaPersona, pms);
                    int pCreada = Decimal.ToInt32((decimal)dt.Rows[0][0]);

                    string valuesDomicilios = "";
                    foreach (Domicilio d in domicilios)
                    {
                        valuesDomicilios += (!string.IsNullOrEmpty(valuesDomicilios) ? "," : "");
                        valuesDomicilios += new StringBuilder("(").Append("'"+d.GetCalle()+"',")
                            .Append("'"+d.GetNumero()+"',").Append(d.GetPiso()+",").Append("'"+d.GetDpto()+"',")
                            .Append("'"+d.GetComentario()+"',").Append("'"+d.GetCodigoPostal()+"',").Append("'"+d.GetTipoDomicilio()+"',")
                            .Append(d.GetLocalidad().GetId()+",").Append(pCreada).Append(")").ToString();
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

                    crearUsuario(usuario, pCreada, dataQuery);

                    return USER_CREATED_PERSON_CREATED;
                }
            }
        }



        //Metodo de obtener el usuario a modificar, le paso el id del seleccionado.

        public static Usuario getUsuario (int id)
        {
            Usuario usuario = new Usuario();
            SqlParameter[] pms = new SqlParameter[1];
          

            string getUsuario = "select ID_Usuario, usuario, clave, CII, habilitado, DVH, FK_Persona, respuesta, FK_Pregunta, deleteTime from Usuarios where ID_Usuario = @id";
            


            pms[0] = new SqlParameter("@id", SqlDbType.Int);
            pms[0].Value = id;

            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            DataTable dt = new DataTable();
            dt = dataQuery.sqlExecute(getUsuario, pms);
            DataRow dr = dt.Rows[0];

            int idPersona = (int)dr[6];

            usuario.SetIdUsuario((int) dr[0]);
            usuario.SetNombreUsuario(ControladorEncriptacion.Decrypt((string)dr[1]));
            usuario.SetPassword((string)dr[2]);
            usuario.SetCii((int)dr[3]);
            usuario.SetHabilitado((bool)dr[4]);
            usuario.SetRespuesta((string)dr[7]);
            usuario.SetFkPregunta((int)dr[8]);


            string getPersona = "select ID_Persona, dni, nombre,apellido,sexo,fechaNacimiento from Personas where ID_Persona = @idPersona";
            SqlParameter[] pmsPersona = new SqlParameter[1];
            pmsPersona[0] = new SqlParameter("@idPersona", SqlDbType.Int);
            pmsPersona[0].Value = idPersona;

            DataTable dtPersona = new DataTable();
            dataQuery = new DataConnection.DataConnection();
            dtPersona = dataQuery.sqlExecute(getPersona, pmsPersona);
            DataRow drP = dtPersona.Rows[0];

            Persona persona = new Persona();

            persona.SetIdPersona((int)drP[0]);
            persona.SetDni((string)drP[1]);
            persona.SetNombre((string)drP[2]);
            persona.SetApellido((string)drP[3]);
            persona.SetSexo((string)drP[4]);
            persona.SetFechaNacimiento((DateTime)drP[5]);


            DataTable dtTel = new DataTable();
            SqlParameter[] pmsTel = new SqlParameter[1];
            pmsTel[0] = new SqlParameter("@id", SqlDbType.Int);
            pmsTel[0].Value = idPersona;


            dtTel = dataQuery.getList(SP.OBTENER_TELEFONOS, pmsTel);
            List<Telefono> telList = new List<Telefono>();

            foreach (DataRow drTel in dtTel.Rows)
            {
                Telefono tel = new Telefono();
                tel.SetId((int)drTel[0]);
                tel.SetTipo((string)drTel[1]);
                tel.SetNumero((string)drTel[2]);
                telList.Add(tel);
            }

            persona.SetTelefonos(telList);

            DataTable dtMail = new DataTable();
            pmsTel[0] = new SqlParameter("@id", SqlDbType.Int);
            pmsTel[0].Value = idPersona;


            dtMail = dataQuery.getList(SP.OBTENER_MAILS, pmsTel);
            List<Mail> mailList = new List<Mail>();

            try
            {

                foreach (DataRow drMail in dtMail.Rows)
                {
                    Mail mail = new Mail();
                    mail.SetId((int)drMail[0]);
                    mail.SetTipo((string)drMail[1]);
                    mail.SetMail((string)drMail[2]);
                    mailList.Add(mail);
                }
            }
            catch
            {
                mailList.Add(new Mail());
            }

            persona.SetMails(mailList);

            /** Lleno lista de domicilios **/
            DataTable dtDom = new DataTable();
            pmsTel[0] = new SqlParameter("@id", SqlDbType.Int);
            pmsTel[0].Value = idPersona;


            dtDom = dataQuery.getList(SP.OBTENER_DOMICILIOS, pmsTel);
            List<Domicilio> domList = new List<Domicilio>();


            try
            {
                foreach (DataRow drDom in dtDom.Rows)
                {
                    Localidad lc = new Localidad((string)drDom[10], (int)drDom[9], 0);
                    Provincia pv = new Provincia((string)drDom[12], (int)drDom[11]);
                    Pais p = new Pais((int)drDom[13], (string)drDom[14]);
                    Domicilio dom = new Domicilio((int)drDom[0], (string)drDom[1], (string)drDom[2], (int)drDom[3], (string)drDom[4], (string)drDom[5], (string)drDom[6], (string)drDom[7], lc, p, pv);

                    domList.Add(dom);

                }
            } catch
            {
                domList.Add(new Domicilio());
            }

            persona.SetDomicilios(domList);


            usuario.SetPersona(persona);


            return usuario;
        }



    }
}
