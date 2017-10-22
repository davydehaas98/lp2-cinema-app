using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;

namespace LogicLayer
{
    public class MovieLogic
    {
        private MovieData moviedata;
        private Movie movie;
        private Genre genre;
        private List<Movie> movies;
        private List<Genre> genres;
        public List<Movie> Movies
        {
            get { return this.movies; }
            set { this.movies = value; }
        }
        public List<Genre> Genres
        {
            get { return this.genres; }
            set { this.genres = value; }
        }
        public MovieLogic()
        {
            moviedata = new MovieData();
        }
        public List<Movie> GetMovies()
        {
            DataTable result = moviedata.GetMovies();
            movies = new List<Movie>();
            if (result != null)
            {
                //loop through datatable results
                foreach (DataRow row in result.Rows)
                {
                    movie = new Movie((int)row["id"], (string)row["Name"], (string)row["Type"], (int)row["Length"], (int)row["MinimumAge"], GetGenres((int)row["id"]));
                    movies.Add(movie);
                }
                return movies;
            }
            return null;
        }
        public List<Genre> GetGenres(int idmovie)
        {
            DataTable result = moviedata.GetGenres(idmovie);
            genres = new List<Genre>();
            if (result != null)
            {
                //loop through datatable results
                foreach (DataRow row in result.Rows)
                {
                    genre = new Genre((int)row["id"], (string)row["Name"]);
                    genres.Add(genre);
                }
                return genres;
            }
            return null;
        }
    }
}
