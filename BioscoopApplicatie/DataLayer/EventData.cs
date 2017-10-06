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
            string query = "SELECT * FROM [Events]";
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
    }
}
