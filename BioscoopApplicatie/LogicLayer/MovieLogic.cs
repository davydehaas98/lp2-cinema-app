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
        private Movie movie;
        private MovieData moviedata;
        private List<Movie> movies;
        public List<Movie> Movies
        {
            get { return this.movies; }
            set { this.movies = value; }
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
                    movie = new Movie((string)row["Name"], (string)row["Type"], (int)row["Length"], (int)row["MinimalAge"]);
                    movies.Add(movie);
                }

                return movies;
            }

            return null;
        }
    }
}
