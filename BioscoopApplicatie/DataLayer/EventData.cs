using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class EventData : DataAccess
    {
        public EventData()
        {

        }
        public DataTable GetEvents()
        {
            string query = "SELECT * FROM [Event]";
            DataTable result = ExecSelectQuery(query);
            return result;
        }
        public DataTable GetEvents(string filter)
        {
            string query = "";
            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@filter", SqlDbType.VarChar);
            pars[0].Value = filter;

            DataTable result = ExecSelectQuery(query, pars);

            return result;
        }
        public DataTable GetCinema(int id)
        {
            string query = "SELECT * FROM [Cinema] WHERE id = @id";
            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@id", SqlDbType.Int);
            pars[0].Value = id;

            DataTable result = ExecSelectQuery(query, pars);

            return result;
        }

        public DataTable GetMovie(int id)
        {
            string query = "SELECT * FROM [Movie] WHERE id = @id";
            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@id", SqlDbType.Int);
            pars[0].Value = id;

            DataTable result = ExecSelectQuery(query, pars);

            return result;
        }
    }
}
