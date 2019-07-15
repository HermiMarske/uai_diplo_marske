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
