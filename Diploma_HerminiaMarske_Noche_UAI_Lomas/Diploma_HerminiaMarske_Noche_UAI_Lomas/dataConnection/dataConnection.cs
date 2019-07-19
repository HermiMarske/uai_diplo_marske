using System;
using System.Data.SqlClient;
using System.Data;

using System.Configuration;
using System.Text.RegularExpressions;

namespace DataConnection
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Revisar consultas SQL para comprobar si tienen vulnerabilidades de seguridad")]
    class DataConnection
    {
        private static string Sql;

        public DataConnection()
        {
            // Si el programa se ejecuta por primera vez, validar si ya se actualizó su Data Source. Solo se ejecuta una vez.

            Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationElement dataSourceChanged = configFile.AppSettings.Settings["DataSourceChanged"];
            if (dataSourceChanged.Value.Equals(bool.FalseString))
            {
                ConnectionStringsSection settings = configFile.ConnectionStrings;

                string conn = settings.ConnectionStrings["Diploma_HerminiaMarske_Noche_UAI_Lomas.Properties"].ConnectionString;

                settings.ConnectionStrings["Diploma_HerminiaMarske_Noche_UAI_Lomas.Properties"].ConnectionString = 
                    Regex.Replace(conn, "(Data Source)=[A-z\\-\\.\\,\\\\0-9\\/\\(\\)]+;", string.Format("$1={0}; ", Environment.MachineName));

                dataSourceChanged.Value = bool.TrueString;
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");
                ConfigurationManager.RefreshSection("appSettings");
            }

            Sql = ConfigurationManager.ConnectionStrings["Diploma_HerminiaMarske_Noche_UAI_Lomas.Properties"].ConnectionString;
        }

        public int databaseInsert(SqlParameter[] pms, string storedProcedureName)
        {
            using (SqlConnection connection = new SqlConnection(Sql))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = storedProcedureName;
                    command.Parameters.AddRange(pms);

                    int fk = (int)command.ExecuteScalar();
                    connection.Close();
                    return fk;
                }
            }
        }

        public void databaseInsertAditionalData(SqlParameter[] pms, string storedProcedureName)
        {
            using (SqlConnection connection = new SqlConnection(Sql))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = storedProcedureName;
                    command.Parameters.AddRange(pms);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void databaseModifyData(SqlParameter[] pms, string storedProcedureName)
        {
            using (SqlConnection connection = new SqlConnection(Sql))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = storedProcedureName;
                    command.Parameters.AddRange(pms);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public DataTable getList(string storedProcedureName, SqlParameter[] pms)
        {
            using (SqlConnection connection = new SqlConnection(Sql))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    DataTable dt = new DataTable();

                    connection.Open();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = storedProcedureName;
                    if (pms != null)
                    {
                        command.Parameters.AddRange(pms);
                    }
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);

                    connection.Close();
                    return dt;
                }
            }
        }

        public SqlDataAdapter getListParams(string storedProcedureName, SqlParameter[] pms)
        {
            using (SqlConnection connection = new SqlConnection(Sql))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    DataTable dt = new DataTable();

                    connection.Open();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = storedProcedureName;
                    command.Parameters.AddRange(pms);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);

                    connection.Close();
                    return da;
                }
            }
        }

        public string databaseDelete(SqlParameter[] pms, string storedProcedureName)
        {
            using (SqlConnection connection = new SqlConnection(Sql))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = storedProcedureName;
                    command.Parameters.AddRange(pms);

                    string mensaje = command.ExecuteScalar().ToString();
                    connection.Close();
                    return mensaje;
                }
            }
        }

        public DataTable sqlExecute(string sqlQuery, SqlParameter[] pms)
        {
            using (SqlConnection connection = new SqlConnection(Sql))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    DataTable dt = new DataTable();

                    connection.Open();
                    if (pms != null)
                    {
                        command.Parameters.AddRange(pms);
                    }
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);

                    connection.Close();
                    return dt;
                }
            }
        }

        public int sqlUpsert(string sqlQuery, SqlParameter[] pms)
        {
            using (SqlConnection connection = new SqlConnection(Sql))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    DataTable dt = new DataTable();

                    connection.Open();
                    if (pms != null)
                    {
                        command.Parameters.AddRange(pms);
                    }
                    int response = (int)command.ExecuteNonQuery();

                    connection.Close();
                    return response;
                }
            }
        }

        public void sqlCommand(string sqlQuery, SqlParameter[] pms)
        {
            using (SqlConnection connection = new SqlConnection(Sql))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    DataTable dt = new DataTable();
                    connection.Open();
                    if (pms != null)
                    {
                        command.Parameters.AddRange(pms);
                    }
                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }

        internal string databaseDelete(SqlParameter[] pms, object BORRAR_USUARIO)
        {
            throw new NotImplementedException();
        }
    }
}
