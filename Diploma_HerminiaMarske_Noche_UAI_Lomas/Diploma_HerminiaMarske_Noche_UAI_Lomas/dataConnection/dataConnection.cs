using System;
using System.Data.SqlClient;
using System.Data;

using System.Configuration;

namespace DataConnection
{
    class DataConnection
    {
        private static string Sql = ConfigurationManager.ConnectionStrings["Diploma_HerminiaMarske_Noche_UAI_Lomas.Properties"].ConnectionString;

        public int databaseInsert(SqlParameter[] pms, string storedProcedureName)
        {
            SqlConnection connection = new SqlConnection(Sql);
            SqlCommand command = new SqlCommand();
            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;
            command.Parameters.AddRange(pms);

            int fk = (int)command.ExecuteScalar();
            connection.Close(); 
            return fk;
        }

        public void databaseInsertAditionalData(SqlParameter[] pms, string storedProcedureName)
        {
            SqlConnection connection = new SqlConnection(Sql);
            SqlCommand command = new SqlCommand();
            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;
            command.Parameters.AddRange(pms);
            command.ExecuteNonQuery();
            connection.Close();   
        }

        public void databaseModifyData(SqlParameter[] pms, string storedProcedureName)
        {
            SqlConnection connection = new SqlConnection(Sql);
            SqlCommand command = new SqlCommand();
            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;
            command.Parameters.AddRange(pms);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public SqlDataAdapter getList(string storedProcedureName, SqlParameter[] pms)
        {
            SqlConnection connection = new SqlConnection(Sql);
            SqlCommand command = new SqlCommand();
            DataTable dt = new DataTable();
     
            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;
            if (pms != null) {
                command.Parameters.AddRange(pms);
            }
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
        
            connection.Close();
            return da;
        }

        public SqlDataAdapter getListParams(String storedProcedureName, SqlParameter[] pms)
        {
            SqlConnection connection = new SqlConnection(Sql);
            SqlCommand command = new SqlCommand();
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

        public string databaseDelete(SqlParameter[] pms, string storedProcedureName)
        {
            SqlConnection connection = new SqlConnection(Sql);
            SqlCommand command = new SqlCommand();
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
