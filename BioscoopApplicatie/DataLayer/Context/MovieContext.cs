using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models;
using Context.Interfaces;

namespace Context.Context
{
    public class MovieContext : IMovieContext
    {
        DataAccess db;
        public MovieContext()
        {
            db = new DataAccess();
        }
        public IQueryable<Movie> GetAll()
        {
            string query = "EXEC [GetMovies]";
            return ObjectBuilder.CreateMovieList(db.ExecSelectQuery(query));
        }
        public Movie GetByID(int movieid)
        {
            string query = "EXEC [GetMovieByID] @id = @movieid";
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@movieid", SqlDbType.Int) { Value = movieid });
            return ObjectBuilder.CreateMovie(db.ExecSelectQuery(query, pars).Rows[0]);
        }
        public IQueryable<Movie> GetMoviesReleased(DateTime moviereleasedate)
        {
            string query = "EXEC [GetMoviesReleased] @releasedate = @moviereleasedate";
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@moviereleasedate", SqlDbType.Date) { Value = moviereleasedate });
            return ObjectBuilder.CreateMovieList(db.ExecSelectQuery(query, pars));
        }
        public IQueryable<Genre> GetGenres()
        {
            string query = "EXEC [GetGenres]";
            return ObjectBuilder.CreateGenreList(db.ExecSelectQuery(query));
        }
        public IQueryable<Genre> GetGenres(int movieid)
        {
            string query = "EXEC [GetGenresByMovie] @id = @movieid";
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@movieid", SqlDbType.Int) { Value = movieid });
            return ObjectBuilder.CreateGenreList(db.ExecSelectQuery(query, pars));
        }
        public void InsertMovie(string moviename, bool movied3, int movielength, int movieminimumage, DateTime moviereleasedate, byte[] movieimage, List<int> genreids)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@name", SqlDbType.NVarChar) { Value = moviename });
            pars.Add(new SqlParameter("@d3", SqlDbType.Bit) { Value = movied3 });
            pars.Add(new SqlParameter("@length", SqlDbType.Int) { Value = movielength });
            pars.Add(new SqlParameter("@minimumage", SqlDbType.Int) { Value = movieminimumage });
            pars.Add(new SqlParameter("@releasedate", SqlDbType.Date) { Value = moviereleasedate });
            pars.Add(new SqlParameter("@image", SqlDbType.VarBinary) { Value = movieimage });
            DataRow row = db.ExecStoredProc("[InsertMovie]", pars).Tables[0].Rows[0];
            int movieid = (int)row["Column1"];

            List<SqlParameter> pars2 = new List<SqlParameter>();
            foreach (int genreid in genreids)
            {
                pars2.Add(new SqlParameter("@genreid", SqlDbType.Int) { Value = genreid });
            }
            pars2.Add(new SqlParameter("@movieid", SqlDbType.Int) { Value = movieid });
            db.ExecStoredProc("AddGenreToMovie", pars2);
        }
        public void UpdateMovie(int movieid, string moviename, bool movied3, int movielength, int movieminimumage, DateTime moviereleasedate,  byte[] movieimage)
        {
            string query = "EXEC [UpdateMovie] @id = @movieid, @name = @moviename, @d3 = @movied3, @length = @movielength, @minimumage = @movieminimumage, @releasedate = @moviereleasedate, @image = @movieimage";
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@movieid", SqlDbType.Int) { Value = movieid });
            pars.Add(new SqlParameter("moviename", SqlDbType.NVarChar) { Value = moviename });
            pars.Add(new SqlParameter("movied3", SqlDbType.Bit) { Value = movied3 });
            pars.Add(new SqlParameter("movielength", SqlDbType.Int) { Value = movielength });
            pars.Add(new SqlParameter("movieminimumage", SqlDbType.Int) { Value = movieminimumage });
            pars.Add(new SqlParameter("moviereleasedate", SqlDbType.Date) { Value = moviereleasedate });
            pars.Add(new SqlParameter("@movieimage", SqlDbType.VarBinary) { Value = movieimage });
            db.ExecInsertQuery(query, pars);
        }
    }
}
