using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.Constantes;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio
{
    class ControladorBitacora
    {
        const string getBitacoraFiltradaQuery = "select b.ID_Bitacora, b.timeStamp, b.criticidad, b.descripcion, b.FK_Usuario, u.usuario " +
           "from Bitacora b, Usuarios u " +
           "where b.FK_Usuario = u.ID_Usuario";

        const string getBitacora = "select b.ID_Bitacora, b.timeStamp, b.criticidad, b.descripcion, b.FK_Usuario, u.usuario from Bitacora b left join Usuarios u ON b.FK_Usuario = u.ID_Usuario";

        public static void grabarRegistro(BitacoraRow row)
        {
            Usuario usuario = formInicio.usuarioLogueado;

            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            const string altaRegistro = "INSERT INTO Bitacora (timestamp, criticidad, descripcion, FK_Usuario, DVH) values (@timestamp, @criticidad, @descripcion, @idUsuario, @dvh)";

            string descripcionEncriptada = ControladorEncriptacion.Encrypt(row.GetDescripcion());

            SqlParameter[] pms = new SqlParameter[5];
            pms[0] = new SqlParameter("@timestamp", SqlDbType.DateTime);
            pms[0].Value = row.GetTimeStamp();
            pms[1] = new SqlParameter("@criticidad", SqlDbType.VarChar);
            pms[1].Value = row.GetCriticidad();
            pms[2] = new SqlParameter("@descripcion", SqlDbType.VarChar);
            pms[2].Value = descripcionEncriptada;
            pms[3] = new SqlParameter("@idUsuario", SqlDbType.Int);
            pms[3].Value = usuario != null ? usuario.GetIdUsuario() : row.GetUsuario().GetIdUsuario();
            pms[4] = new SqlParameter("@dvh", SqlDbType.Int);
            pms[4].Value = ControladorDigitosVerificadores.calcularDVH(row.GetDescripcion());

            dataQuery.sqlUpsert(altaRegistro, pms);
            ControladorDigitosVerificadores.calcularDVV(ConstantesDDVV.TABLA_BITACORA);
        }

        public static List<BitacoraRow> getBitacoraRows() 
        {
            DataTable dt = new DataTable();
            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
       
            List<BitacoraRow> bitacoraList = new List<BitacoraRow>();
            try
            {
                dt = dataQuery.sqlExecute(getBitacora, null);
                foreach (DataRow dr in dt.Rows)
                {
                    Object usuario = dr[5];
                    Usuario usuarioDesencriptado = new Usuario();
                    string descripcionDesencriptada;
                    if (!string.IsNullOrEmpty(usuario.ToString()))
                    {
                        string usuarioD = ControladorEncriptacion.Decrypt(usuario.ToString());
                        usuarioDesencriptado.SetIdUsuario((int)dr[4]);
                        usuarioDesencriptado.SetNombreUsuario(usuarioD);
                    }
                    else
                    {
                        usuarioDesencriptado.SetIdUsuario(0);
                        usuarioDesencriptado.SetNombreUsuario("SISTEMA");
                    }
                    try
                    {
                        descripcionDesencriptada = ControladorEncriptacion.Decrypt((string)dr[3]);

                    }
                    catch
                    {
                        descripcionDesencriptada = "DESCRIPCION NO COMPATIBLE";
                    }

                    BitacoraRow bRow = new BitacoraRow((int)dr[0], (DateTime)dr[1], (string)dr[2], descripcionDesencriptada, usuarioDesencriptado);

                    bitacoraList.Add(bRow);
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return bitacoraList;
        }


        //TODO Terminar esta garcha
        public static List<BitacoraRow> getBitacoraFiltrada(string nombreUsuario, string criticidad, DateTime fechaDesde, DateTime fechaHasta)
        {

            DataTable dt = new DataTable();
            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();

            string bitacoraFiltrada = getBitacoraFiltradaQuery;

            if(!String.IsNullOrEmpty(nombreUsuario))
            {
                bitacoraFiltrada += " AND u.usuario LIKE '" + ControladorEncriptacion.Encrypt(nombreUsuario) + "'";
            }
            if (!String.IsNullOrEmpty(criticidad))
            {
                bitacoraFiltrada += " AND b.criticidad = '" + criticidad + "'";
            }

            if (fechaDesde != null && fechaHasta != null) 
            {
                bitacoraFiltrada += " AND b.timeStamp BETWEEN '" + fechaDesde.ToString("dd/MM/yyyy HH:mm:ss") + "' AND '" + fechaHasta.ToString("dd/MM/yyyy HH:mm:ss") + "'";
            }

            List<BitacoraRow> bitacoraList = new List<BitacoraRow>();
            try
            {
                dt = dataQuery.sqlExecute(bitacoraFiltrada, null);
                foreach (DataRow dr in dt.Rows)
                {
                    string descripcionDesencriptada = ControladorEncriptacion.Decrypt((string)dr[3]);
                    string usuarioDesencriptado = ControladorEncriptacion.Decrypt((string)dr[5]);

                    Usuario usuario = new Usuario((int)dr[4], usuarioDesencriptado);
                    BitacoraRow bRow = new BitacoraRow((int)dr[0], (DateTime)dr[1], (string)dr[2], descripcionDesencriptada, usuario);

                    bitacoraList.Add(bRow);
                }
            }
            catch (Exception e)
            {
                return bitacoraList;
            }

            return bitacoraList;
        }
    }
}
