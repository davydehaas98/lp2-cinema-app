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
        public MovieLogic()
        {
            moviedata = new MovieData();
        }
        public List<Movie> GetMovies()
        {
            DataTable result = moviedata.GetMovies();
            List<Movie> movies = new List<Movie>();
            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    movies.Add(new Movie((int)row["id"], (string)row["Name"], (string)row["Type"], (int)row["Length"], (int)row["MinimumAge"], (DateTime)row["ReleaseDate"], (byte[])row["Image"], GetGenres((int)row["id"])));
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
        public void InsertMovie(string name, string type, int length, int minimumage, DateTime releasedate, Image image, List<Genre> genres)
        {

            List<int> genreids = new List<int>();
            genres.ForEach(g => genreids.Add(g.Id));

            moviedata.InsertMovie(name, type, length, minimumage, releasedate, ImageToByteArray(image), genreids);
        }
        public byte[] ImageToByteArray(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        public ImageSource GetImageFromMovie(byte[] imagebytes)
        {
            BitmapImage bmi = new BitmapImage();
            MemoryStream ms = new MemoryStream(imagebytes);
            bmi.BeginInit();
            bmi.StreamSource = ms;
            bmi.EndInit();
            return bmi as ImageSource;
        }
    }
}
