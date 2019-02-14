using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace DataConnection
{
    class DataConnection
    {
        static private string Sql = "Data Source=CHARLOTTE-PC;Initial Catalog=UAI_GESTION_AGUILA;Integrated Security=True";

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
