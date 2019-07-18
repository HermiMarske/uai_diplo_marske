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
    class ControladorDigitosVerificadores
    {
        public static int calcularDVH(string entrada)
        {
            int salida = 0;

            entrada.Trim();

            char[] entradaParaProcesar = entrada.ToCharArray();

            int[] entradaArray = new int[entrada.Length];


            for(int i=0; i<=entrada.Length-1; i++)
            {
                int val = Convert.ToInt32((entradaParaProcesar[i]));
                entradaArray[i] = val * (i+1);
                salida += entradaArray[i];
            }
            return salida;
        }



        public static void calcularDVV(string tableName)
        {
            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            SqlParameter[] pms = new SqlParameter[2];
            string calculoDVV = "SELECT SUM(dvh) FROM " + tableName;

            string insertDVV = "UPDATE DDVV SET dvv = (SELECT SUM(DVH) FROM " + tableName + ") WHERE tabla = '" + tableName + "'";

            dataQuery.sqlUpsert(insertDVV, null);

        }

        public static void recalcularDV()
        {

            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();

            //Tabla bitacora.
            string getBitacora = "select ID_Bitacora, descripcion from Bitacora";
            string setNuevoDVHBitacora = "update Bitacora set dvh = @dvh where ID_Bitacora = @id";
            DataTable dt = dataQuery.sqlExecute(getBitacora, null);

            SqlParameter[] pmsBitacora = new SqlParameter[2];

            foreach(DataRow dr in dt.Rows)
            {
                int id = (int)dr[0];
                string descripcion = (string)dr[1];
                int dvh = calcularDVH(descripcion);

                pmsBitacora[0] = new SqlParameter("@dvh", SqlDbType.Int);
                pmsBitacora[0].Value = dvh;
                pmsBitacora[1] = new SqlParameter("@id", SqlDbType.VarChar);
                pmsBitacora[1].Value = id;

                dataQuery.sqlUpsert(setNuevoDVHBitacora, pmsBitacora);

            }

            calcularDVV(ConstantesDDVV.TABLA_BITACORA);


            //Tabla Familia_Patente

            string getFamiliaPatente = "select idFamiliaPatente, familiaFK, patenteFK from  Familia_Patente";
            string setNuevoDVHFamiliaPatente = "update Familia_Patente set dvh = @dvh where idFamiliaPatente = @id";

            DataTable dtFamPat = dataQuery.sqlExecute(getFamiliaPatente, null);

            SqlParameter[] pmsFamPat = new SqlParameter[2];

            foreach (DataRow dr in dtFamPat.Rows)
            {
                int id = (int)dr[0];
                int fkFamilia = (int)dr[1];
                int fkPatente = (int)dr[2];
                int dvh = calcularDVH(fkFamilia.ToString()+fkPatente.ToString());

                pmsFamPat[0] = new SqlParameter("@dvh", SqlDbType.Int);
                pmsFamPat[0].Value = dvh;
                pmsFamPat[1] = new SqlParameter("@id", SqlDbType.VarChar);
                pmsFamPat[1].Value = id;

                dataQuery.sqlUpsert(setNuevoDVHFamiliaPatente, pmsFamPat);
            }

            calcularDVV(ConstantesDDVV.TABLA_FAMILIA_PATENTE);

            //Tabla Familia_Usuario

            string getUsuarioFamilia = "select idUsuFam, familiaFK, usuarioFK from Usuario_Familia";
            string setNuevoDVHUsuarioFamilia = "update Usuario_Familia set dvh = @dvh where idUsuFam = @id";

            DataTable dtUsuFam = dataQuery.sqlExecute(getUsuarioFamilia, null);

            SqlParameter[] pmsUsuFam = new SqlParameter[2];

            foreach (DataRow dr in dtUsuFam.Rows)
            {
                int id = (int)dr[0];
                int fkFamilia = (int)dr[1];
                int fkUsuario = (int)dr[2];
                int dvh = calcularDVH(fkFamilia.ToString() + fkUsuario.ToString());

                pmsUsuFam[0] = new SqlParameter("@dvh", SqlDbType.Int);
                pmsUsuFam[0].Value = dvh;
                pmsUsuFam[1] = new SqlParameter("@id", SqlDbType.VarChar);
                pmsUsuFam[1].Value = id;

                dataQuery.sqlUpsert(setNuevoDVHUsuarioFamilia, pmsUsuFam);
            }

            calcularDVV(ConstantesDDVV.TABLA_USUARIO_FAMILIA);


            //Tabla Usuario_Patente

            string getUsuarioPatente = "select idUsuarioPatente, patenteFK, usuarioFK, ISNULL(negado, 0) from Usuario_Patente";
            string setNuevoDVHUsuarioPatente = "update Usuario_Patente set dvh = @dvh where idUsuarioPatente = @id";

            DataTable dtUsuPat = dataQuery.sqlExecute(getUsuarioPatente, null);

            SqlParameter[] pmsUsuPat = new SqlParameter[2];

            foreach (DataRow dr in dtUsuPat.Rows)
            {
                int id = (int)dr[0];
                int fkPatente = (int)dr[1];
                int fkUsuario = (int)dr[2];
                bool negado = (bool)dr[3];

                int dvh = calcularDVH(fkPatente.ToString() + fkUsuario.ToString() + negado.ToString());

                pmsUsuPat[0] = new SqlParameter("@dvh", SqlDbType.Int);
                pmsUsuPat[0].Value = dvh;
                pmsUsuPat[1] = new SqlParameter("@id", SqlDbType.VarChar);
                pmsUsuPat[1].Value = id;

                dataQuery.sqlUpsert(setNuevoDVHUsuarioPatente, pmsUsuPat);
            }

            calcularDVV(ConstantesDDVV.TABLA_USUARIO_PATENTE);

            //Tabla Usuario

            string getUsuario = "select ID_Usuario, usuario, CII from Usuarios";
            string setNuevoDVHUsuario = "update Usuarios set DVH = @dvh where ID_Usuario = @id";

            DataTable dtUsuarios = dataQuery.sqlExecute(getUsuario, null);

            SqlParameter[] pmsUsuarios = new SqlParameter[2];

            foreach (DataRow dr in dtUsuarios.Rows)
            {
                int id = (int)dr[0];
                string usuario = (string)dr[1];
                int cii = (int)dr[2];
              

                int dvh = calcularDVH(usuario + cii.ToString());

                pmsUsuarios[0] = new SqlParameter("@dvh", SqlDbType.Int);
                pmsUsuarios[0].Value = dvh;
                pmsUsuarios[1] = new SqlParameter("@id", SqlDbType.VarChar);
                pmsUsuarios[1].Value = id;

                dataQuery.sqlUpsert(setNuevoDVHUsuario, pmsUsuarios);
            }

            calcularDVV(ConstantesDDVV.TABLA_USUARIOS);


        }

        public static void verificarIntegridad()
        {

            bool error = false;

            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();

            //ver si se borro un registro en bitacora

            string getSumBitacora = "SELECT SUM(DVH) FROM Bitacora";
            DataTable dtSumBitacora = dataQuery.sqlExecute(getSumBitacora, null);
            int dvvCalculadoBitacora = (int)dtSumBitacora.Rows[0][0];
            string getDVVBitacora = "select dvv from DDVV where tabla = 'Bitacora'";
            DataTable dtDDVVBitacora = dataQuery.sqlExecute(getDVVBitacora, null);
            long dvvBitacora = (long)dtDDVVBitacora.Rows[0][0];

            if(dvvBitacora != dvvCalculadoBitacora)
            {
                error = true;

                BitacoraRow bitacora = new BitacoraRow(DateTime.UtcNow, ConstantesBitacora.CRITICIDAD_ALTA, "Se elimino un registro en la tabla de Bitacora, error grave.", new Usuario());
                ControladorBitacora.grabarRegistro(bitacora);
            }

            //verificar si se borro uno o mas registros en familiaPatente


            string getSumFamPat = "SELECT SUM(dvh) FROM Familia_Patente";
            DataTable dtSumFamPat = dataQuery.sqlExecute(getSumFamPat, null);
            int dvvCalculadoFamPat = (int)dtSumFamPat.Rows[0][0];
            string getDVVFamPat = "select dvv from DDVV where tabla = 'Familia_Patente'";
            DataTable dtDDVVFamPat = dataQuery.sqlExecute(getDVVFamPat, null);
            long dvvFamPat = (long)dtDDVVFamPat.Rows[0][0];

            if (dvvFamPat != dvvCalculadoFamPat)
            {
                error = true;

                BitacoraRow bitacora = new BitacoraRow(DateTime.UtcNow, ConstantesBitacora.CRITICIDAD_ALTA, "Se elimino un registro en la tabla Familia_Patente, error grave.", new Usuario());
                ControladorBitacora.grabarRegistro(bitacora);
            }


            //verificar si se borro uno o mas registros en familiaUsuario


            string getSumUsuFam = "SELECT SUM(dvh) FROM Usuario_Familia";
            DataTable dtSumUsuFam = dataQuery.sqlExecute(getSumUsuFam, null);
            int dvvCalculadoUsuFam = (int)dtSumUsuFam.Rows[0][0];
            string getDVVUsuFam = "select dvv from DDVV where tabla = 'Usuario_Familia'";
            DataTable dtDDVVUsuFam = dataQuery.sqlExecute(getDVVUsuFam, null);
            long dvvUsuFam = (long)dtDDVVUsuFam.Rows[0][0];

            if (dvvUsuFam != dvvCalculadoUsuFam)
            {
                error = true;

                BitacoraRow bitacora = new BitacoraRow(DateTime.UtcNow, ConstantesBitacora.CRITICIDAD_ALTA, "Se elimino un registro en la tabla Usuario_Familia, error grave.", new Usuario());
                ControladorBitacora.grabarRegistro(bitacora);
            }


            //verificar si se borro uno o mas registros en usuariopatente


            string getSumUsuPat = "SELECT SUM(dvh) FROM Usuario_Patente";
            DataTable dtSumUsuPat = dataQuery.sqlExecute(getSumUsuPat, null);
            int dvvCalculadoUsuPat = (int)dtSumUsuPat.Rows[0][0];
            string getDVVUsuPat = "select dvv from DDVV where tabla = 'Usuario_Patente'";
            DataTable dtDDVVUsuPat = dataQuery.sqlExecute(getDVVUsuPat, null);
            long dvvUsuPat = (long)dtDDVVUsuPat.Rows[0][0];

            if (dvvUsuPat != dvvCalculadoUsuPat)
            {
                error = true;

                BitacoraRow bitacora = new BitacoraRow(DateTime.UtcNow, ConstantesBitacora.CRITICIDAD_ALTA, "Se elimino un registro en la tabla Usuario_Patente, error grave.", new Usuario());
                ControladorBitacora.grabarRegistro(bitacora);
            }


            //verificar si se borro uno o mas registros en usuario


            string getSumUsu = "SELECT SUM(DVH) FROM Usuarios";
            DataTable dtSumUsu = dataQuery.sqlExecute(getSumUsu, null);
            int dvvCalculadoUsu = (int)dtSumUsu.Rows[0][0];
            string getDVVUsu = "select dvv from DDVV where tabla = 'Usuarios'";
            DataTable dtDDVVUsu = dataQuery.sqlExecute(getDVVUsu, null);
            long dvvUsu = (long)dtDDVVUsu.Rows[0][0];

            if (dvvUsu != dvvCalculadoUsu)
            {
                error = true;

                BitacoraRow bitacora = new BitacoraRow(DateTime.UtcNow, ConstantesBitacora.CRITICIDAD_ALTA, "Se elimino un registro en la tabla Usuarios, error grave.", new Usuario());
                ControladorBitacora.grabarRegistro(bitacora);
            }


            /* SI SE MODIFICO UN REGISTRO PERO NO SE BORRO, TAMBIEN SE VALIDA */

            //Tabla bitacora.
            string getBitacora = "select ID_Bitacora, descripcion, dvh from Bitacora";
          
            DataTable dt = dataQuery.sqlExecute(getBitacora, null);

            foreach (DataRow dr in dt.Rows)
            {
                int id = (int)dr[0];
                string descripcion = (string)dr[1];
                int dvhBase = (int)dr[2];

                int dvhCalculado = calcularDVH(descripcion);

                if(dvhCalculado != dvhBase)
                {
                    error = true;

                    BitacoraRow bitacora = new BitacoraRow(DateTime.UtcNow, ConstantesBitacora.CRITICIDAD_ALTA, "Se modifico un registro en la tabla Bitacora, error grave.", new Usuario());
                    ControladorBitacora.grabarRegistro(bitacora);
                }

            }

            //Tabla Familia_Patente

            string getFamiliaPatente = "select idFamiliaPatente, familiaFK, patenteFK, dvh from  Familia_Patente";

            DataTable dtFamPat = dataQuery.sqlExecute(getFamiliaPatente, null);


            foreach (DataRow dr in dtFamPat.Rows)
            {
                int id = (int)dr[0];
                int fkFamilia = (int)dr[1];
                int fkPatente = (int)dr[2];
                int dvhBase = (int)dr[3];

                int dvhCalculado = calcularDVH(fkFamilia.ToString() + fkPatente.ToString());

                if (dvhBase != dvhCalculado)
                {
                    error = true;
                    BitacoraRow bitacora = new BitacoraRow(DateTime.UtcNow, ConstantesBitacora.CRITICIDAD_ALTA, "Se modifico un registro en la tabla Familia_Patente, error grave.", new Usuario());
                    ControladorBitacora.grabarRegistro(bitacora);
                }

            }


            //Tabla Familia_Usuario

            string getUsuarioFamilia = "select idUsuFam, familiaFK, usuarioFK, dvh from Usuario_Familia";

            DataTable dtUsuFam = dataQuery.sqlExecute(getUsuarioFamilia, null);
            

            foreach (DataRow dr in dtUsuFam.Rows)
            {
                int id = (int)dr[0];
                int fkFamilia = (int)dr[1];
                int fkUsuario = (int)dr[2];
                int dvhBase = (int)dr[3];

                int dvhCalculado = calcularDVH(fkFamilia.ToString() + fkUsuario.ToString());

                if (dvhBase != dvhCalculado)
                {
                    error = true;
                    BitacoraRow bitacora = new BitacoraRow(DateTime.UtcNow, ConstantesBitacora.CRITICIDAD_ALTA, "Se modifico un registro en la tabla Usuario_Familia, error grave.", new Usuario());
                    ControladorBitacora.grabarRegistro(bitacora);
                }

            }


            //Tabla Usuario_Patente

            string getUsuarioPatente = "select idUsuarioPatente, patenteFK, usuarioFK, ISNULL(negado, 0), dvh from Usuario_Patente";

            DataTable dtUsuPat = dataQuery.sqlExecute(getUsuarioPatente, null);

            foreach (DataRow dr in dtUsuPat.Rows)
            {
                int id = (int)dr[0];
                int fkPatente = (int)dr[1];
                int fkUsuario = (int)dr[2];
                bool negado = (bool)dr[3];
                int dvhBase = (int)dr[4];

                int dvhCalculado = calcularDVH(fkPatente.ToString() + fkUsuario.ToString() + negado.ToString());

                if (dvhBase != dvhCalculado)
                {
                    error = true;
                    BitacoraRow bitacora = new BitacoraRow(DateTime.UtcNow, ConstantesBitacora.CRITICIDAD_ALTA, "Se modifico un registro en la tabla Usuario_Patente, error grave.", new Usuario());
                    ControladorBitacora.grabarRegistro(bitacora);
                }

            }

            //Tabla Usuario

            string getUsuario = "select ID_Usuario, usuario, CII, DVH from Usuarios";

            DataTable dtUsuarios = dataQuery.sqlExecute(getUsuario, null);


            foreach (DataRow dr in dtUsuarios.Rows)
            {
                int id = (int)dr[0];
                string usuario = (string)dr[1];
                int cii = (int)dr[2];
                int dvhBase = (int)dr[3];


                int dvhCalculado = calcularDVH(usuario + cii.ToString());
                if (dvhBase != dvhCalculado)
                {
                    error = true;
                    BitacoraRow bitacora = new BitacoraRow(DateTime.UtcNow, ConstantesBitacora.CRITICIDAD_ALTA, "Se modifico un registro en la tabla Usuario, error grave.", new Usuario());
                    ControladorBitacora.grabarRegistro(bitacora);
                }
            }

            if (error)
            {
                BitacoraRow bitacora = new BitacoraRow(DateTime.UtcNow, ConstantesBitacora.CRITICIDAD_ALTA, "Error de consistencia en base de datos. GRAVE.", new Usuario());
                ControladorBitacora.grabarRegistro(bitacora);
            }

        }


    }


}
