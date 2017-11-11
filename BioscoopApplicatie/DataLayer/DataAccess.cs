using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class DataAccess
    {
        private SqlDataAdapter adapter;
        private SqlConnection connection;
        private string ConnectionString = @"Server=mssql.fhict.local;Database=dbi369008;User Id=dbi369008;Password=Pannenkoek123;Connection Timeout=2;";
        public DataAccess()
        {
            adapter = new SqlDataAdapter();
            connection = new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// Select query with parameterized query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public DataTable ExecSelectQuery(string query, SqlParameter[] parameter)
        {
            DataTable table = new DataTable();
            table = null;
            DataSet set = new DataSet();

            using (connection = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                try
                {
                    connection.ConnectionString = ConnectionString;
                    connection.Open();
                    cmd.Parameters.AddRange(parameter);
                    cmd.ExecuteNonQuery();
                    adapter.SelectCommand = cmd;
                    adapter.Fill(set);
                    table = set.Tables[0];
                }

                catch (SqlException e)
                {
                    throw e;
                }
            }

            return table;
        }

        /// <summary>
        /// Select query without parameterized query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable ExecSelectQuery(string query)
        {
            DataTable table = new DataTable();
            DataSet set = new DataSet();

            using (connection = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                try
                {
                    connection.ConnectionString = ConnectionString;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    adapter.SelectCommand = cmd;
                    adapter.Fill(set);
                    table = set.Tables[0];
                }

                catch (SqlException e)
                {
                    throw e;
                }
            }
            return table;
        }


        /// <summary>
        /// Executes an insert query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public int? ExecInsertQuery(string query, SqlParameter[] parameter)
        {
            int id;
            using (connection = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query + "SELECT CAST(SCOPE_IDENTITY() AS INT)", connection))
            {
                try
                {
                    connection.ConnectionString = ConnectionString;
                    connection.Open();
                    cmd.Parameters.AddRange(parameter);
                    id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
                catch (Exception)
                {
                    return null;
                }

            }
            return id;
        }

        /// <summary>
        /// Executes an update query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool ExecUpdateQuery(string query, SqlParameter[] parameter)
        {
            using (connection = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                try
                {
                    connection.ConnectionString = ConnectionString;
                    connection.Open();
                    cmd.Parameters.AddRange(parameter);
                    cmd.ExecuteNonQuery();
                }
                catch (StackOverflowException)
                {
                    throw new StackOverflowException();
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
            return true;
        }
    }
}
