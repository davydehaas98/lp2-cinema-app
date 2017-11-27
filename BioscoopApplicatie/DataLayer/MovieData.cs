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
        public DataTable GetMovies()
        {
            string query = "SELECT * FROM [Movie] ORDER BY [Name]";
            DataTable result = ExecSelectQuery(query);
            return result;
        }
        public DataTable GetMovieByID(int idmovie)
        {
            string query = "SELECT * FROM [Movie] WHERE id = @idmovie";
            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@idmovie", SqlDbType.Int);
            pars[0].Value = idmovie;

            DataTable result = ExecSelectQuery(query, pars);

            return result;
        }
        public DataTable GetMoviesByReleaseDate(DateTime date)
        {
            string query = "SELECT * FROM [Movie] WHERE ReleaseDate <= @date";
            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@date", SqlDbType.Date);
            pars[0].Value = date;

            DataTable result = ExecSelectQuery(query, pars);

            return result;
        }
        public DataTable GetGenres()
        {
            string query = "SELECT Genre.id, Genre.Name FROM [Genre]";
            DataTable result = ExecSelectQuery(query);
            return result;
        }
        public DataTable GetGenres(int idmovie)
        {
            string query = "SELECT Genre.id, Genre.Name FROM Movie_Genre INNER JOIN Movie ON Movie_Genre.MovieID = Movie.id INNER JOIN Genre ON Movie_Genre.GenreID = Genre.id WHERE Movie.id = @idmovie";
            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@idmovie", SqlDbType.Int);
            pars[0].Value = idmovie;

            DataTable result = ExecSelectQuery(query, pars);
            return result;
        }
        public void InsertMovie(string name, bool d3, int length, int minimumage, DateTime releasedate, byte[] image, List<int> genreids)
        {
            string query = "INSERT INTO [Movie] ([Name], [D3], [Length], [MinimumAge], [ReleaseDate], [Image]) VALUES (@name, @d3, @length, @minimumage, @releasedate, @image)";
            SqlParameter[] pars = new SqlParameter[6];
            pars[0] = new SqlParameter("@name", SqlDbType.NVarChar);
            pars[0].Value = name;

            pars[1] = new SqlParameter("@d3", SqlDbType.NVarChar);
            pars[1].Value = d3;

            pars[2] = new SqlParameter("@length", SqlDbType.Int);
            pars[2].Value = length;

            pars[3] = new SqlParameter("@minimumage", SqlDbType.Int);
            pars[3].Value = minimumage;

            pars[4] = new SqlParameter("@releasedate", SqlDbType.Date);
            pars[4].Value = releasedate;

            pars[5] = new SqlParameter("@image", SqlDbType.VarBinary);
            pars[5].Value = image;

            int? movieid = ExecInsertQuery(query, pars);
            foreach(int genreid in genreids)
            {
                string query2 = "INSERT INTO [Movie_Genre] (MovieID, GenreID) VALUES (@movieid, @genreid)";

                SqlParameter[] pars2 = new SqlParameter[2];

                pars2[0] = new SqlParameter("@movieid", SqlDbType.Int);
                pars2[0].Value = movieid;

                pars2[1] = new SqlParameter("@genreid", SqlDbType.Int);
                pars2[1].Value = genreid;
                ExecInsertQuery(query2, pars2);
            }
        }
        public void UpdateMovie(int idmovie, byte[] image)
        {
            string query = "UPDATE [Movie] SET Movie.[Image] = @image WHERE id = @idmovie";
            SqlParameter[] pars = new SqlParameter[2];

            pars[0] = new SqlParameter("@idmovie", SqlDbType.Int);
            pars[0].Value = idmovie;

            pars[1] = new SqlParameter("@image", SqlDbType.VarBinary);
            pars[1].Value = image;
            ExecInsertQuery(query, pars);
        }
    }
}
