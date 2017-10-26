using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class CinemaData : DataAccess
    {
        public CinemaData()
        {

        }
        public DataTable GetCinemas()
        {
            string query = "SELECT * FROM [Cinema]";
            DataTable result = ExecSelectQuery(query);
            return result;
        }
        public DataTable GetCinemas(int movietheatreid)
        {
            string query = "SELECT * FROM [Cinema] WHERE MovieTheatreID = @id";
            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@movietheatre", SqlDbType.Int);
            pars[0].Value = movietheatreid;

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

        public DataTable GetSeat()
        {
            string query = "SELECT * FROM [Seat]";
            DataTable result = ExecSelectQuery(query);
            return result;
        }
    }
}
