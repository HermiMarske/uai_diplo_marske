using ConstantesData;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.Constantes;
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
    class ControladorABMPiloto
    {

        private const string PILOTO_CREADO = "PILOTO_CREADO";
        private const string PILOTO_ERROR = "PILOTO_ERROR";
        private const string PILOTO_BORRADO = "PILOTO_BORRADO";
        private const string PILOTO_MODIFICADO = "PILOTO_MODIFICADO";

        public static string crearPiloto(Piloto piloto)
        {
            const string altaPiloto = "INSERT INTO Pilotos (licencia, dvh, fechaInicioApto, fechaVencimientoApto, FK_Persona) values (@licencia, @dvh, @fechaInicioApto, @fechaVencimientoApto, @idPersona)";
            string personaExiste = "SELECT TOP 1 ID_Persona FROM Personas WHERE dni = @dniPersona;";
            string altaPersona = "INSERT INTO Personas (dni, nombre, apellido, sexo, fechaNacimiento)" +
                " VALUES (@dni, @nombre, @apellido, @sexo, @fechaNacimiento);" +
                " SELECT SCOPE_IDENTITY();";
            string crearDomicilios = "INSERT INTO Domicilio(calle,numero,piso,dpto, comentarios, codPostal,tipoDomicilio, FK_Localidad, FK_Persona) " +
                "VALUES {0}";
            string crearMails = "INSERT INTO Mails(tipo, mail, FK_Persona) VALUES {0}";
            string crearTelefonos = "INSERT INTO Telefono(tipo,numero, FK_Persona) VALUES {0}";


            SqlParameter[] pms = new SqlParameter[1];
            pms[0] = new SqlParameter("@dniPersona", SqlDbType.VarChar);
            pms[0].Value = piloto.GetPersona().GetDni();

            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            DataTable dt = new DataTable();
            dt = dataQuery.sqlExecute(personaExiste, pms);
            int pExiste = dt.Rows.Count > 0 ? (int)dt.Rows[0][0] : 0;

            try
            {
                if (pExiste == 0)
                {
                    Persona p = piloto.GetPersona();
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
                    int pCreada = decimal.ToInt32((decimal)dt.Rows[0][0]);

                    SqlParameter[] pmsPiloto = new SqlParameter[5];
                    pmsPiloto[0] = new SqlParameter("@licencia", SqlDbType.VarChar);
                    pmsPiloto[0].Value = piloto.GetLicencia();
                    pmsPiloto[1] = new SqlParameter("@dvh", SqlDbType.Int);
                    pmsPiloto[1].Value = ControladorDigitosVerificadores.calcularDVH(piloto.GetLicencia());
                    pmsPiloto[2] = new SqlParameter("@fechaInicioApto", SqlDbType.DateTime);
                    pmsPiloto[2].Value = piloto.GetFechaExpedicionPsicofisico();
                    pmsPiloto[3] = new SqlParameter("@fechaVencimientoApto", SqlDbType.DateTime);
                    pmsPiloto[3].Value = piloto.GetFechaVencimientoPsicofisico();
                    pmsPiloto[4] = new SqlParameter("@idPersona", SqlDbType.Int);
                    pmsPiloto[4].Value = pCreada;

                    dataQuery.sqlUpsert(altaPiloto, pmsPiloto);
                    ControladorDigitosVerificadores.calcularDVV(ConstantesDDVV.TABLA_PILOTOS);

                    string valuesDomicilios = "";
                    foreach (Domicilio d in piloto.GetPersona().GetDomicilios())
                    {
                        valuesDomicilios += (!string.IsNullOrEmpty(valuesDomicilios) ? "," : "");
                        valuesDomicilios += new StringBuilder("(").Append("'" + d.GetCalle() + "',")
                            .Append("'" + d.GetNumero() + "',").Append(d.GetPiso() + ",").Append("'" + d.GetDpto() + "',")
                            .Append("'" + d.GetComentario() + "',").Append("'" + d.GetCodigoPostal() + "',").Append("'" + d.GetTipoDomicilio() + "',")
                            .Append(d.GetLocalidad().GetId() + ",").Append(pCreada).Append(")").ToString();
                    }

                    string valuesMails = "";
                    foreach (Mail m in piloto.GetPersona().GetMails())
                    {
                        valuesMails += (!string.IsNullOrEmpty(valuesMails) ? "," : "");
                        valuesMails += new StringBuilder("(").Append("'" + m.GetTipo() + "',")
                            .Append("'" + m.GetMail() + "',").Append(pCreada).Append(")").ToString();
                    }

                    string valuesTelefonos = "";
                    foreach (Telefono t in piloto.GetPersona().GetTelefonos())
                    {
                        valuesTelefonos += (!string.IsNullOrEmpty(valuesTelefonos) ? "," : "");
                        valuesTelefonos += new StringBuilder("(").Append("'" + t.GetTipo() + "',")
                            .Append("'" + t.GetNumero() + "',").Append(pCreada).Append(")").ToString();
                    }

                    dataQuery.sqlUpsert(string.Format(crearDomicilios, valuesDomicilios), null);
                    dataQuery.sqlUpsert(string.Format(crearMails, valuesMails), null);
                    dataQuery.sqlUpsert(string.Format(crearTelefonos, valuesTelefonos), null);


                }
                return PILOTO_CREADO;

            }
            catch (Exception e)
            {
                return e.Message;
            }
       
        }

        public static string modificarPiloto(Piloto piloto)
        {

            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();

            const string modificarPiloto = "update Pilotos set licencia = @licencia, dvh= @dvh, fechaInicioApto = @fechaInicioApto, fechaVencimientoApto = @fechaVencimientoApto where ID_Piloto = @idPiloto";
            const string borrarDomicilios = "delete from Domicilio where FK_Persona = @idPersona";
            const string borrarMails = "delete from Mails where FK_Persona = @idPersona";
            const string borrarTels = "delete from Telefono where FK_Persona = @idPersona";
            const string modificarPersona = " update Personas set dni = @dni, nombre = @nombre, apellido = @apellido, sexo = @sexo, fechaNacimiento = @fechaNacimiento where ID_Persona = @idPersona";
            string crearDomicilios = "INSERT INTO Domicilio(calle,numero,piso,dpto, comentarios, codPostal,tipoDomicilio, FK_Localidad, FK_Persona) VALUES {0}";
            string crearMails = "INSERT INTO Mails(tipo, mail, FK_Persona) VALUES {0}";
            string crearTelefonos = "INSERT INTO Telefono(tipo,numero, FK_Persona) VALUES {0}";

            //Modificar Piloto
            SqlParameter[] pmsPiloto = new SqlParameter[5];
            pmsPiloto[0] = new SqlParameter("@licencia", SqlDbType.VarChar);
            pmsPiloto[0].Value = piloto.GetLicencia();
            pmsPiloto[1] = new SqlParameter("@dvh", SqlDbType.Int);
            pmsPiloto[1].Value = ControladorDigitosVerificadores.calcularDVH(piloto.GetLicencia());
            pmsPiloto[2] = new SqlParameter("@fechaInicioApto", SqlDbType.Date);
            pmsPiloto[2].Value = piloto.GetFechaExpedicionPsicofisico();
            pmsPiloto[3] = new SqlParameter("@fechaVencimientoApto", SqlDbType.Date);
            pmsPiloto[3].Value = piloto.GetFechaVencimientoPsicofisico();
            pmsPiloto[4] = new SqlParameter("@idPiloto", SqlDbType.Int);
            pmsPiloto[4].Value = piloto.GetId();

            //param para tels, mails y demas
            SqlParameter[] pmsP = new SqlParameter[1];
            pmsP[0] = new SqlParameter("@idPersona", SqlDbType.Int);
            pmsP[0].Value = (piloto.GetPersona().GetIdPersona());

            //param para tels, mails y demas
            SqlParameter[] pmsPer = new SqlParameter[1];
            pmsPer[0] = new SqlParameter("@idPersona", SqlDbType.Int);
            pmsPer[0].Value = (piloto.GetPersona().GetIdPersona());

            //param para tels, mails y demas
            SqlParameter[] pmsPers = new SqlParameter[1];
            pmsPers[0] = new SqlParameter("@idPersona", SqlDbType.Int);
            pmsPers[0].Value = (piloto.GetPersona().GetIdPersona());

            //Modificar Persona

            SqlParameter[] pmsPersona = new SqlParameter[6];
            pmsPersona[0] = new SqlParameter("@dni", SqlDbType.VarChar);
            pmsPersona[0].Value = piloto.GetPersona().GetDni();
            pmsPersona[1] = new SqlParameter("@nombre", SqlDbType.VarChar);
            pmsPersona[1].Value = piloto.GetPersona().GetNombre();
            pmsPersona[2] = new SqlParameter("@apellido", SqlDbType.VarChar);
            pmsPersona[2].Value = piloto.GetPersona().GetApellido();
            pmsPersona[3] = new SqlParameter("@sexo", SqlDbType.VarChar);
            pmsPersona[3].Value = piloto.GetPersona().GetSexo();
            pmsPersona[4] = new SqlParameter("@fechaNacimiento", SqlDbType.Date);
            pmsPersona[4].Value = piloto.GetPersona().GetFechaNacimiento();
            pmsPersona[5] = new SqlParameter("@idPersona", SqlDbType.Int);
            pmsPersona[5].Value = (piloto.GetPersona().GetIdPersona());

            try
            {
                dataQuery.sqlUpsert(modificarPiloto, pmsPiloto);
                ControladorDigitosVerificadores.calcularDVV(ConstantesDDVV.TABLA_PILOTOS);          
                dataQuery.sqlUpsert(borrarDomicilios, pmsP);
                dataQuery.sqlUpsert(borrarMails, pmsPer);
                dataQuery.sqlUpsert(borrarTels, pmsPers);
                dataQuery.sqlUpsert(modificarPersona, pmsPersona);

                string valuesDomicilios = "";
                foreach (Domicilio d in piloto.GetPersona().GetDomicilios())
                {
                    valuesDomicilios += (!string.IsNullOrEmpty(valuesDomicilios) ? "," : "");
                    valuesDomicilios += new StringBuilder("(").Append("'" + d.GetCalle() + "',")
                        .Append("'" + d.GetNumero() + "',").Append(d.GetPiso() + ",").Append("'" + d.GetDpto() + "',")
                        .Append("'" + d.GetComentario() + "',").Append("'" + d.GetCodigoPostal() + "',").Append("'" + d.GetTipoDomicilio() + "',")
                        .Append(d.GetLocalidad().GetId() + ",").Append(piloto.GetPersona().GetIdPersona()).Append(")").ToString();
                }

                string valuesMails = "";
                foreach (Mail m in piloto.GetPersona().GetMails())
                {
                    valuesMails += (!string.IsNullOrEmpty(valuesMails) ? "," : "");
                    valuesMails += new StringBuilder("(").Append("'" + m.GetTipo() + "',")
                        .Append("'" + m.GetMail() + "',").Append(piloto.GetPersona().GetIdPersona()).Append(")").ToString();
                }

                string valuesTelefonos = "";
                foreach (Telefono t in piloto.GetPersona().GetTelefonos())
                {
                    valuesTelefonos += (!string.IsNullOrEmpty(valuesTelefonos) ? "," : "");
                    valuesTelefonos += new StringBuilder("(").Append("'" + t.GetTipo() + "',")
                        .Append("'" + t.GetNumero() + "',").Append(piloto.GetPersona().GetIdPersona()).Append(")").ToString();
                }

                dataQuery.sqlUpsert(string.Format(crearDomicilios, valuesDomicilios), null);
                dataQuery.sqlUpsert(string.Format(crearMails, valuesMails), null);
                dataQuery.sqlUpsert(string.Format(crearTelefonos, valuesTelefonos), null);

                return PILOTO_MODIFICADO;

            }
            catch (Exception ex)
            {
                return PILOTO_ERROR;
            }

            
        }

        public static string borrarPiloto(int id)
        {
            
            const string borrarPiloto = "DELETE FROM Pilotos WHERE ID_Piloto = @id";

            SqlParameter[] pms = new SqlParameter[1];
            pms[0] = new SqlParameter("@id", SqlDbType.Int);
            pms[0].Value = id;


            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();

            try
            {
                dataQuery.sqlExecute(borrarPiloto, pms);
                ControladorDigitosVerificadores.calcularDVV(ConstantesDDVV.TABLA_PILOTOS);
                return PILOTO_BORRADO;
            }
            catch
            {
                return PILOTO_ERROR;
            }
           
        }

        public static Piloto getPiloto(int id)
        {

            Piloto piloto = new Piloto();
            SqlParameter[] pms = new SqlParameter[1];

            string getPiloto = "select ID_Piloto, licencia, fechaInicioApto, fechaVencimientoApto, FK_Persona from Pilotos where ID_Piloto = @id";

            pms[0] = new SqlParameter("@id", SqlDbType.Int);
            pms[0].Value = id;

            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            DataTable dt = new DataTable();
            dt = dataQuery.sqlExecute(getPiloto, pms);
            DataRow dr = dt.Rows[0];

            int idPersona = (int)dr[4];

            piloto.SetId((int)dr[0]);
            piloto.SetLicencia((string)dr[1]);
            piloto.SetFechaExpedicionPsicofisico((DateTime)dr[2]);
            piloto.SetFechaVencimientoPsicofisico((DateTime)dr[3]);


            string getPersona = "SELECT ID_Persona, dni, nombre,apellido,sexo,fechaNacimiento FROM Personas WHERE ID_Persona = @idPersona";
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


            try
            {

                foreach (DataRow drTel in dtTel.Rows)
                {
                    Telefono tel = new Telefono();
                    tel.SetId((int)drTel[0]);
                    tel.SetTipo((string)drTel[1]);
                    tel.SetNumero((string)drTel[2]);
                    telList.Add(tel);
                }
            }
            catch
            {
                telList.Add(new Telefono());
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
            }
            catch
            {
                domList.Add(new Domicilio());
            }

            persona.SetDomicilios(domList);
            piloto.SetPersona(persona);

            return piloto;
        }

    }
}
