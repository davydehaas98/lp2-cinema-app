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
        //private string connectionstring = @"Server=mssql.fhict.local;Database=dbi369008;User Id=dbi369008;Password=Pannenkoek123;Connection Timeout=2;";
        private static string connectionstring = @"Server=tcp:davydehaas.database.windows.net,1433;Initial Catalog=CinemaApplicationDB;Persist Security Info=False;User ID=Davy98;Password=Pannenkoek123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=5;";
        public DataAccess()
        {
            adapter = new SqlDataAdapter();
        }
        internal DataSet ExecStoredProcedure(string name)
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
        internal DataSet ExecStoredProcedure(string name, List<SqlParameter> pars)
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
                    cmd.Parameters.AddRange(pars.ToArray());
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
