using Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio
{
    class ControladorUsuario
    {

        static public Persona logIn(string usuario, string clave)
        {
            string sql = "SELECT ID_Usuario, CII, habilitado, clave FROM Usuarios WHERE usuario = @usuario";
            SqlParameter[] pms = new SqlParameter[1];
            pms[0] = new SqlParameter("@usuario", SqlDbType.VarChar);
            pms[0].Value = usuario;

            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            DataTable dt = new DataTable();
            dt = dataQuery.sqlExecute(sql, pms);
            object[] result = dt.Rows.Count > 0 ? dt.Rows[0].ItemArray : null;

            if (result == null || (int)result[0] == 0)
            {
                throw new Exception("AUTH_USR_NOT_EXISTS");
            }
            else if ((int)result[1] == 3 || !(bool)result[2])
            {
                throw new Exception("USR_BLOCKED");
            }
            else
            {
                string claveDb = result[3].ToString();
                if (ControladorEncriptacion.SoportaHash(claveDb))
                {
                    bool coincide = ControladorEncriptacion.VerificarPass(clave, claveDb);

                    pms = new SqlParameter[1];
                    pms[0] = new SqlParameter("@usuario", SqlDbType.VarChar);
                    pms[0].Value = usuario;

                    if (coincide)
                    {
                        string success = "UPDATE Usuarios SET habilitado = 1, CII = 0 WHERE usuario = @usuario; " +
                            "SELECT p.ID_Persona, p.dni, p.nombre, p.apellido, p.sexo, p.fechaNacimiento FROM Usuarios u, Personas p WHERE p.ID_Persona = u.FK_Persona AND u.usuario = @usuario;";
                        dt = dataQuery.sqlExecute(success, pms);
                        DataRow dr = dt.Rows[0];
                        return new Persona((int)dr[0], (string)dr[1], (string)dr[2], (string)dr[3], (string)dr[4], (DateTime)dr[5]);
                    }
                    else
                    {
                        string failed = "UPDATE Usuarios SET CII = CII + 1, habilitado = CAST(CASE WHEN CII + 1 = 3 THEN 0 ELSE 1 END AS bit) WHERE usuario = @usuario;";
                        dataQuery.sqlUpsert(failed, pms);
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
