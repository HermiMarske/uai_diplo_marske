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
        static private string Sql = "Data Source=HERMI-PC;Initial Catalog=UAI_GESTION_AGUILA;Integrated Security=True";

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

        public SqlDataAdapter getList(String storedProcedureName)
        {
            SqlConnection connection = new SqlConnection(Sql);
            SqlCommand command = new SqlCommand();
            DataTable dt = new DataTable();
          
     
            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
        
            connection.Close();
            return da;
        }
       

    }
}
