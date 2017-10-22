using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class MovieData : DataAccess
    {
        public MovieData()
        {

        }
        public DataTable GetMovies()
        {
            string query = "SELECT * FROM [Movie]";
            DataTable result = ExecSelectQuery(query);
            return result;
        }
        public DataTable GetMovies(int id)
        {
            string query = "SELECT * FROM [Movie] WHERE id = @id";
            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@id", SqlDbType.Int);
            pars[0].Value = id;

            DataTable result = ExecSelectQuery(query, pars);
            return result;
        }
        public DataTable GetGenres(int idmovie)
        {
            string query = "SELECT  Genre.* FROM Movie_Genre INNER JOIN Movie ON Movie_Genre.MovieID = Movie.id INNER JOIN Genre ON Movie_Genre.GenreID = Genre.id WHERE Movie.id = @idmovie";
            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@idmovie", SqlDbType.Int);
            pars[0].Value = idmovie;

            DataTable result = ExecSelectQuery(query, pars);
            return result;
        }
    }
}
