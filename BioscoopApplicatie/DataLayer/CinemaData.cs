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
        public DataTable GetCinemas()
        {
            string query = "SELECT * FROM [Cinema]";
            DataTable result = ExecSelectQuery(query);
            return result;
        }
        public DataTable GetCinemaByID(int idcinema)
        {
            string query = "SELECT * FROM [Cinema] WHERE id = @idcinema";
            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@idcinema", SqlDbType.Int);
            pars[0].Value = idcinema;

            DataTable result = ExecSelectQuery(query, pars);

            return result;
        }
        public DataTable GetMovieTheatre(int idcinema)
        {
            string query = "SELECT * FROM [MovieTheatre] INNER JOIN [Cinema] ON [MovieTheatre].id = [Cinema].MovietheatreID WHERE [Cinema].id = @idcinema";
            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@idcinema", SqlDbType.Int);
            pars[0].Value = idcinema;

            DataTable result = ExecSelectQuery(query, pars);

            return result;
        }
        public DataTable GetMovieTheatres()
        {
            string query = "SELECT * FROM [MovieTheatre]";
            DataTable result = ExecSelectQuery(query);
            return result;
        }
        public DataTable GetCinemas(int idmovietheatre)
        {
            string query = "SELECT * FROM [Cinema] WHERE MovieTheatreID = @idmovietheatre";
            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@idmovietheatre", SqlDbType.Int);
            pars[0].Value = idmovietheatre;

            DataTable result = ExecSelectQuery(query, pars);

            return result;
        }
    }
}
