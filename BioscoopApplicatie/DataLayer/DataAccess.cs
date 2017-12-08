using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Context
{
    internal class DataAccess
    {
        private SqlDataAdapter adapter;
        private SqlConnection connection;
        //private string ConnectionString = @"Server=mssql.fhict.local;Database=dbi369008;User Id=dbi369008;Password=Pannenkoek123;Connection Timeout=2;";
        private string connectionstring = @"Server=tcp:davydehaas.database.windows.net,1433;Initial Catalog=CinemaApplicationDB;Persist Security Info=False;User ID=Davy98;Password=Pannenkoek123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=5;";
        public DataAccess()
        {
            adapter = new SqlDataAdapter();
        }
        /// <summary>
        /// Select query with parameterized query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        internal DataTable ExecSelectQuery(string query, List<SqlParameter> parameters)
        {
            DataTable table = new DataTable();
            DataSet set = new DataSet();
            using (connection = new SqlConnection(connectionstring))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                try
                {
                    connection.ConnectionString = connectionstring;
                    connection.Open();
                    cmd.Parameters.AddRange(parameters.ToArray());
                    cmd.ExecuteNonQuery();
                    adapter.SelectCommand = cmd;
                    adapter.Fill(set);
                    table = set.Tables[0];
                }
                catch (SqlException e)
                {
                    if (e.Number == 53)
                    {
                        throw new Exception("Database connection failed, error code: " + e.Number);
                    }
                    throw new Exception($"SQL Exception, error code: {e.Number}. {e.Message}");
                }
                return table;
            }
        }
        /// <summary>
        /// Select query without parameterized query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        internal DataTable ExecSelectQuery(string query)
        {
            DataTable table = new DataTable();
            DataSet set = new DataSet();
            using (connection = new SqlConnection(connectionstring))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                try
                {
                    connection.ConnectionString = connectionstring;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    adapter.SelectCommand = cmd;
                    adapter.Fill(set);
                    table = set.Tables[0];
                }
                catch (SqlException e)
                {
                    if (e.Number == 53)
                    {
                        throw new Exception("Database connection failed, error code: " + e.Number);
                    }
                    throw new Exception("SQL Exception, error code: " + e.Number);
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
        internal int? ExecInsertQuery(string query, List<SqlParameter> parameters)
        {
            int id;
            using (connection = new SqlConnection(connectionstring))
            using (SqlCommand cmd = new SqlCommand(query + " SELECT CAST(SCOPE_IDENTITY() AS INT)", connection))
            {
                try
                {
                    connection.ConnectionString = connectionstring;
                    connection.Open();
                    cmd.Parameters.AddRange(parameters.ToArray());
                    id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    return id;
                }
                catch (SqlException e)
                {
                    if (e.Number == 53)
                    {
                        throw new Exception("Database connection failed, error code: " + e.Number);
                    }
                    if (e.Number == 2627)
                    {
                        throw new Exception("That Username or Email is already taken, error code: " + e.Number);
                    }
                    throw new Exception("SQL Exception, error code: " + e.Number);
                }
            }
        }
        /// <summary>
        /// Executes an update query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        internal bool ExecUpdateQuery(string query, List<SqlParameter> parameters)
        {
            using (connection = new SqlConnection(connectionstring))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    cmd.Parameters.AddRange(parameters.ToArray());
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (StackOverflowException)
                {
                    throw new StackOverflowException();
                }
                catch (SqlException e)
                {
                    if (e.Number == 53)
                    {
                        throw new Exception("Database connection failed, error code: " + e.Number);
                    }
                    throw new Exception("SQL Exception, error code: " + e.Number);
                }
            }
        }
        internal DataSet ExecStoredProc(string name, List<SqlParameter> pars)
        {
            DataSet set = new DataSet();
            using (connection = new SqlConnection(connectionstring))
            using (SqlCommand cmd = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = name;
                    foreach(SqlParameter par in pars)
                    {
                        cmd.Parameters.Add(par);
                    }
                    cmd.ExecuteNonQuery();
                    adapter.SelectCommand = cmd;
                    adapter.Fill(set);
                    return set;
                }
                catch (StackOverflowException)
                {
                    throw new StackOverflowException();
                }
                catch (SqlException e)
                {
                    if (e.Number == 53)
                    {
                        throw new Exception("Database connection failed, error code: " + e.Number);
                    }
                    throw new Exception("SQL Exception, error code: " + e.Number);
                }
            }
        }
    }
}
