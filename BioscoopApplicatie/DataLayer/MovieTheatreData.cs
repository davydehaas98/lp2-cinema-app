using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class MovieTheatreData : DataAccess
    {
        public MovieTheatreData()
        {

        }
        public DataTable GetMovieTheatres()
        {
            string query = "SELECT * FROM [MovieTheatre]";
            DataTable result = ExecSelectQuery(query);
            return result;
        }
        public DataTable GetMovieTheatres(int id)
        {
            string query = "SELECT * FROM [MovieTheatre] WHERE id = @id";
            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@id", SqlDbType.Int);
            pars[0].Value = id;

            DataTable result = ExecSelectQuery(query, pars);
            return result;
        }
        public DataTable GetCinemasInMovieTheatre(int id)
        {
            string query = "SELECT c.id, c.Name, c.IMAX FROM [Cinema] c, MovieTheatre mt WHERE c.MovieTheatreID = @id";

            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@id", SqlDbType.Int);
            pars[0].Value = id;
            DataTable result = ExecSelectQuery(query, pars);
            return result;
        }
    }
}
