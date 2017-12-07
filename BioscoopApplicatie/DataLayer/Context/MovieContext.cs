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
            string query = "SELECT * FROM [Movie] ORDER BY [Name]";
            return ObjectBuilder.CreateMovieList(db.ExecSelectQuery(query));
        }
        public Movie GetMovie(int idmovie)
        {
            string query = "SELECT * FROM [Movie] WHERE id = @idmovie";
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@idmovie", SqlDbType.Int) { Value = idmovie });
            return ObjectBuilder.CreateMovie(db.ExecSelectQuery(query, pars).Rows[0]);
        }
        public IQueryable<Movie> GetMoviesByReleaseDate(DateTime date)
        {
            string query = "SELECT * FROM [Movie] WHERE ReleaseDate <= @date";
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@date", SqlDbType.Date) { Value = date });
            return ObjectBuilder.CreateMovieList(db.ExecSelectQuery(query, pars));
        }
        public IQueryable<Genre> GetGenres()
        {
            string query = "SELECT Genre.id, Genre.Name FROM [Genre]";
            return ObjectBuilder.CreateGenreList(db.ExecSelectQuery(query));
        }
        public IQueryable<Genre> GetGenres(int idmovie)
        {
            string query = "SELECT Genre.* FROM Movie_Genre INNER JOIN Movie ON Movie_Genre.MovieID = Movie.id INNER JOIN Genre ON Movie_Genre.GenreID = Genre.id WHERE Movie.id = @idmovie";
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@idmovie", SqlDbType.Int) { Value = idmovie });
            return ObjectBuilder.CreateGenreList(db.ExecSelectQuery(query, pars));
        }
        public void InsertMovie(string name, bool d3, int length, int minimumage, DateTime releasedate, byte[] image, List<int> genreids)
        {
            string query = "INSERT INTO [Movie] ([Name], [D3], [Length], [MinimumAge], [ReleaseDate], [Image]) VALUES (@name, @d3, @length, @minimumage, @releasedate, @image)";
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@name", SqlDbType.NVarChar) { Value = name });
            pars.Add(new SqlParameter("@d3", SqlDbType.NVarChar) { Value = d3 });
            pars.Add(new SqlParameter("@length", SqlDbType.Int) { Value = length });
            pars.Add(new SqlParameter("@minimumage", SqlDbType.Int) { Value = minimumage });
            pars.Add(new SqlParameter("@releasedate", SqlDbType.Date) { Value = releasedate });
            pars.Add(new SqlParameter("@image", SqlDbType.VarBinary) { Value = image });
            int? movieid = db.ExecInsertQuery(query, pars);
            foreach(int genreid in genreids)
            {
                string query2 = "INSERT INTO [Movie_Genre] (MovieID, GenreID) VALUES (@movieid, @genreid)";
                List<SqlParameter> pars2 = new List<SqlParameter>();
                pars2.Add(new SqlParameter("@movieid", SqlDbType.Int) { Value = movieid });
                pars2.Add(new SqlParameter("@genreid", SqlDbType.Int) { Value = genreid });
                db.ExecInsertQuery(query2, pars2);
            }
        }
        public void UpdateMovie(int idmovie, byte[] image)
        {
            string query = "UPDATE [Movie] SET Movie.[Image] = @image WHERE id = @idmovie";
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@idmovie", SqlDbType.Int) { Value = idmovie });
            pars.Add(new SqlParameter("@image", SqlDbType.VarBinary) { Value = image });
            db.ExecInsertQuery(query, pars);
        }
    }
}
