using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Models;

namespace LogicLayer
{
    public class MovieLogic
    {
        private MovieData moviedata;
        private ImageLogic imagelogic;
        public MovieLogic()
        {
            moviedata = new MovieData();
            imagelogic = new ImageLogic();
        }
        public List<Movie> GetMovies()
        {
            DataTable result = moviedata.GetMovies();
            List<Movie> movies = new List<Movie>();
            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    movies.Add(new Movie((int)row["id"], (string)row["Name"], (bool)row["D3"], (int)row["Length"], (int)row["MinimumAge"], (DateTime)row["ReleaseDate"], imagelogic.ByteToImageSource((byte[])row["Image"]), GetGenres((int)row["id"])));
                }
                return movies;
            }
            return null;
        }
        public List<Movie> GetMoviesByReleaseDate(DateTime date)
        {
            DataTable result = moviedata.GetMoviesByReleaseDate(date);
            List<Movie> movies = new List<Movie>();
            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    movies.Add(new Movie((int)row["id"], (string)row["Name"], (bool)row["D3"], (int)row["Length"], (int)row["MinimumAge"], (DateTime)row["ReleaseDate"], imagelogic.ByteToImageSource((byte[])row["Image"]), GetGenres((int)row["id"])));
                }
                return movies;
            }
            return null;
        }

        public bool CheckFields(string name, string length, DateTime releasedate, Image image, List<int> genres)
        {
            Int32.TryParse(length, out int result);
            if (String.IsNullOrWhiteSpace(name) || result <= 0 || image == null || GetMovies().Exists(movie => movie.Name == name && movie.ReleaseDate == releasedate) || genres.Count < 1)
                return false;
            else
                return true;
        }

        public List<Genre> GetGenres()
        {
            DataTable result = moviedata.GetGenres();
            List<Genre> genres = new List<Genre>();
            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    genres.Add(new Genre((int)row["id"], (string)row["Name"]));
                }
                return genres;
            }
            return null;
        }
        private List<Genre> GetGenres(int idmovie)
        {
            DataTable result = moviedata.GetGenres(idmovie);
            List<Genre> genres = new List<Genre>();
            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    genres.Add(new Genre((int)row["id"], (string)row["Name"]));
                }
                return genres;
            }
            return null;
        }
        public void InsertMovie(string name, bool d3, int length, int minimumage, DateTime releasedate, Image image, List<int> genresID)
        {
            moviedata.InsertMovie(name, d3, length, minimumage, releasedate, imagelogic.ImageToByteArray(image), genresID);
        }
        public void UpdateMovie(int idmovie, Image image)
        {
            moviedata.UpdateMovie(idmovie, imagelogic.ImageToByteArray(image));
        }
    }
}
