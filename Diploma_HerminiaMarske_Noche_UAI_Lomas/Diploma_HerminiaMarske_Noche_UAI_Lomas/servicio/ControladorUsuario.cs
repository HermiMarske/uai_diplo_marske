using Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.Constantes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio
{
    class ControladorUsuario
    {

        static public Usuario logIn(string usuario, string clave)
        {
            string usuarioEncriptado = ControladorEncriptacion.Encrypt(usuario);
            string sql = "SELECT ID_Usuario, CII, habilitado, clave FROM Usuarios WHERE usuario = @usuario AND deleteTime IS NULL";
            SqlParameter[] pms = new SqlParameter[1];
            pms[0] = new SqlParameter("@usuario", SqlDbType.VarChar);
            pms[0].Value = usuarioEncriptado;

            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            DataTable dt = new DataTable();
            dt = dataQuery.sqlExecute(sql, pms);
            object[] result = dt.Rows.Count > 0 ? dt.Rows[0].ItemArray : null;

            if (result == null || (int)result[0] == 0)
            {
                
                BitacoraRow bitacora = new BitacoraRow(DateTime.UtcNow, ConstantesBitacora.CRITICIDAD_MEDIA, ConstantesBitacora.INTENTO_INGRESO_DESCONOCIDO, new Usuario());
                ControladorBitacora.grabarRegistro(bitacora);
                throw new Exception("AUTH_USR_NOT_EXISTS");

            }
            else if ((int)result[1] == 3 || !(bool)result[2])
            {
                Usuario usuarioBitacora = new Usuario((int)result[0], usuario);

                BitacoraRow bitacora = new BitacoraRow(DateTime.UtcNow, ConstantesBitacora.CRITICIDAD_ALTA, ConstantesBitacora.INTENTO_INGRESO_USUARIO_BLOQUEADO, usuarioBitacora);
                ControladorBitacora.grabarRegistro(bitacora);
                throw new Exception("USR_BLOCKED");
            }
            else
            {
                string claveDb = result[3].ToString();
                if (ControladorEncriptacion.SoportaHash(claveDb))
                {
                    bool coincide = ControladorEncriptacion.VerificarPass(clave, claveDb);

                    if (coincide)
                    {
                        pms = new SqlParameter[2];
                        pms[0] = new SqlParameter("@usuario", SqlDbType.VarChar);
                        pms[0].Value = usuarioEncriptado;
                        pms[1] = new SqlParameter("@dvh", SqlDbType.Int);
                        pms[1].Value = ControladorDigitosVerificadores.calcularDVH(usuarioEncriptado + "0");

                        string success = "UPDATE Usuarios SET habilitado = 1, CII = 0, DVH = @dvh WHERE usuario = @usuario; " +
                          "SELECT p.ID_Persona, p.dni, p.nombre, p.apellido, p.sexo, p.fechaNacimiento, u.ID_Usuario, u.usuario, u.idioma FROM Usuarios u, Personas p WHERE p.ID_Persona = u.FK_Persona AND u.usuario = @usuario;";
                        string perms = "SELECT DISTINCT p.idPatente, p.codigo, up.negado FROM Patente p " +
                            "LEFT JOIN Usuario_Patente up ON up.patenteFK = p.idPatente " +
                            "LEFT JOIN Familia_Patente fp ON fp.patenteFK = p.idPatente " +
                            "LEFT JOIN Usuario_Familia uf ON uf.familiaFK = fp.familiaFK " +
                            "LEFT JOIN Usuarios u ON uf.usuarioFK = u.ID_Usuario OR up.usuarioFK = u.ID_Usuario " +
                            "WHERE u.usuario = @usuario; ";
                        dt = dataQuery.sqlExecute(success, pms);
                        DataRow dr = dt.Rows[0];

                        pms = new SqlParameter[1];
                        pms[0] = new SqlParameter("@usuario", SqlDbType.VarChar);
                        pms[0].Value = usuarioEncriptado;
                        dt = dataQuery.sqlExecute(perms, pms);
                        DataRowCollection usrPerms = dt.Rows;
                        List<Patente> patentes = new List<Patente>();
                        foreach (DataRow row in usrPerms) {
                            patentes.Add(new Patente((int)row[0], row[1].ToString(), 0, row[2].GetType() == typeof(DBNull) ? false : (bool)row[2]));
                        }
                        Persona persona = new Persona((int)dr[0], dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), (DateTime)dr[5]);
                        
                        ControladorDigitosVerificadores.calcularDVV(ConstantesDDVV.TABLA_USUARIOS);
                        string usuarioDesencriptado = ControladorEncriptacion.Decrypt((string)dr[7]);

                        BitacoraRow bitacora = new BitacoraRow(DateTime.UtcNow, ConstantesBitacora.CRITICIDAD_BAJA, ConstantesBitacora.INGRESO_EXITOSO_USUARIO, new Usuario((int)dr[0], usuarioDesencriptado));
                        ControladorBitacora.grabarRegistro(bitacora);

                        return new Usuario((int)dr[6], usuarioDesencriptado, dr[8].ToString(), persona, patentes);
                    }
                    else
                    {
                        pms = new SqlParameter[1];
                        pms[0] = new SqlParameter("@usuario", SqlDbType.VarChar);
                        pms[0].Value = usuarioEncriptado;

                        string failed = "UPDATE Usuarios SET CII = CII + 1, habilitado = CAST(CASE WHEN CII + 1 = 3 THEN 0 ELSE 1 END AS bit) WHERE usuario = @usuario;";
                        dataQuery.sqlUpsert(failed, pms);

                        pms = new SqlParameter[1];
                        pms[0] = new SqlParameter("@usuario", SqlDbType.VarChar);
                        pms[0].Value = usuarioEncriptado;
                        string queryCII = "SELECT CII FROM Usuarios WHERE usuario = @usuario";

                        DataTable dataTable = dataQuery.sqlExecute(queryCII, pms);
                        int CII = (int)dataTable.Rows[0][0];

                        string setDVH = "UPDATE Usuarios SET DVH = @dvh WHERE usuario = @usuario";

                        SqlParameter[] pmsDVH = new SqlParameter[2];

                        pmsDVH[0] = new SqlParameter("@dvh", SqlDbType.Int);
                        pmsDVH[0].Value = ControladorDigitosVerificadores.calcularDVH(usuarioEncriptado + CII.ToString());
                        pmsDVH[1] = new SqlParameter("@usuario", SqlDbType.VarChar);
                        pmsDVH[1].Value = usuarioEncriptado;

                        dataQuery.sqlUpsert(setDVH, pmsDVH);
                        ControladorDigitosVerificadores.calcularDVV(ConstantesDDVV.TABLA_USUARIOS);

                        BitacoraRow bitacora = new BitacoraRow(DateTime.UtcNow, ConstantesBitacora.CRITICIDAD_MEDIA, "El usuario " + ControladorEncriptacion.Decrypt(usuarioEncriptado) + " intento ingresar con una clave erronea.", new Usuario((int)result[0], usuario));
                        ControladorBitacora.grabarRegistro(bitacora);

                        throw new Exception("AUTH_USR_FAILED");
                    }
                }
                else
                {
                    throw new Exception("NO_HASH_PASSWORD");
                }
            }


    
        }

    }
}
