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
                    movies.Add(new Movie((int)row["id"], (string)row["Name"], (string)row["Type"], (int)row["Length"], (int)row["MinimumAge"], (DateTime)row["ReleaseDate"], imagelogic.ByteToImageSource((byte[])row["Image"]), GetGenres((int)row["id"])));
                }
                return movies;
            }
            return null;
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
        public void InsertMovie(string name, string type, int length, int minimumage, DateTime releasedate, Image image, List<int> genresID)
        {
            moviedata.InsertMovie(name, type, length, minimumage, releasedate, imagelogic.ImageToByteArray(image), genresID);
        }
        public void UpdateMovie(int idmovie, Image image)
        {
            moviedata.UpdateMovie(idmovie, imagelogic.ImageToByteArray(image));
        }
    }
}
