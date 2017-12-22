using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Models;
using Context.Interfaces;

namespace Context.Context
{
    public class MovieContext : IMovieContext
    {
        private DataAccess db;
        public MovieContext()
        {
            db = new DataAccess();
        }
        public List<Movie> GetAll()
        {
            return ObjectBuilder.CreateMovieList(db.ExecStoredProcedure("[GetMovies]").Tables[0]);
        }
        public Movie GetByID(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@id", SqlDbType.Int) { Value = id });
            return ObjectBuilder.CreateMovie(db.ExecStoredProcedure("[GetMovieByID]", pars).Tables[0].Rows[0]);
        }
        public List<Movie> GetMoviesReleased(DateTime releasedate)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@releasedate", SqlDbType.Date) { Value = releasedate });
            return ObjectBuilder.CreateMovieList(db.ExecStoredProcedure("[GetMoviesReleased]", pars).Tables[0]);
        }
        public List<Genre> GetGenres()
        {
            return ObjectBuilder.CreateGenreList(db.ExecStoredProcedure("[GetGenres]").Tables[0]);
        }
        public List<Genre> GetGenresByMovie(int movieid)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@movieid", SqlDbType.Int) { Value = movieid });
            return ObjectBuilder.CreateGenreList(db.ExecStoredProcedure("[GetGenresByMovie]", pars).Tables[0]);
        }
        public void InsertMovie(string name, bool d3, int length, int minimumage, DateTime releasedate, string image, List<int> genreids)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@name", SqlDbType.NVarChar) { Value = name });
            pars.Add(new SqlParameter("@d3", SqlDbType.Bit) { Value = d3 });
            pars.Add(new SqlParameter("@length", SqlDbType.Int) { Value = length });
            pars.Add(new SqlParameter("@minimumage", SqlDbType.Int) { Value = minimumage });
            pars.Add(new SqlParameter("@releasedate", SqlDbType.Date) { Value = releasedate });
            pars.Add(new SqlParameter("@image", SqlDbType.NVarChar) { Value = image });
            int movieid = (int)db.ExecStoredProcedure("[InsertMovie]", pars).Tables[0].Rows[0]["Column1"];
            foreach (int genreid in genreids)
            {
                List<SqlParameter> pars2 = new List<SqlParameter>();
                pars2.Add(new SqlParameter("@genreid", SqlDbType.Int) { Value = genreid });
                pars2.Add(new SqlParameter("@movieid", SqlDbType.Int) { Value = movieid });
                db.ExecStoredProcedure("[AddGenreToMovie]", pars2);
            }
        }
        public void UpdateMovie(int id, string name, bool d3, int length, int minimumage, DateTime releasedate,  string image)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@id", SqlDbType.Int) { Value = id });
            pars.Add(new SqlParameter("@name", SqlDbType.NVarChar) { Value = name });
            pars.Add(new SqlParameter("@d3", SqlDbType.Bit) { Value = d3 });
            pars.Add(new SqlParameter("@length", SqlDbType.Int) { Value = length });
            pars.Add(new SqlParameter("@minimumage", SqlDbType.Int) { Value = minimumage });
            pars.Add(new SqlParameter("@releasedate", SqlDbType.Date) { Value = releasedate });
            pars.Add(new SqlParameter("@image", SqlDbType.NVarChar) { Value = image });
            db.ExecStoredProcedure("[UpdateMovie]", pars);
        }
    }
}
