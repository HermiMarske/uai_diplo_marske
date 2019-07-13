using System;
using System.Data.SqlClient;
using System.Data;

using System.Configuration;

namespace DataConnection
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Revisar consultas SQL para comprobar si tienen vulnerabilidades de seguridad")]
    class DataConnection
    {
        private static string Sql = ConfigurationManager.ConnectionStrings["Diploma_HerminiaMarske_Noche_UAI_Lomas.Properties"].ConnectionString;

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
