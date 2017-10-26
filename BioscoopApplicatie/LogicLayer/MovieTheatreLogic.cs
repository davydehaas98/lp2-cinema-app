using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;

namespace LogicLayer
{
    public class MovieTheatreLogic
    {
        private MovieTheatreData movietheatredata;
        private CinemaData cinemadata;
        private List<MovieTheatre> movietheatres;
        public List<MovieTheatre> MovieTheatres
        {
            get { return this.movietheatres; }
            set { this.movietheatres = value; }
        }
        public MovieTheatreLogic()
        {
            movietheatredata = new MovieTheatreData();
            cinemadata = new CinemaData();
        }
        public List<MovieTheatre> GetMovieTheatres()
        {
            DataTable result = movietheatredata.GetMovieTheatres();
            movietheatres = new List<MovieTheatre>();
            if (result != null)
            {
                //loop through datatable results
                foreach (DataRow row in result.Rows)
                {
                    MovieTheatre movietheatre = new MovieTheatre((int)row["id"], (string)row["Name"], (string)row["Adress"], (string)row["City"], GetCinemas((int)row["id"]));
                    movietheatres.Add(movietheatre);
                }

                return movietheatres;
            }
            return null;
        }
        public List<MovieTheatre> GetMovieTheatres(int id)
        {
            DataTable result = movietheatredata.GetMovieTheatres(id);
            movietheatres = new List<MovieTheatre>();
            if (result != null)
            {
                //loop through datatable results
                foreach (DataRow row in result.Rows)
                {
                    MovieTheatre movietheatre = new MovieTheatre((int)row["id"], (string)row["Name"], (string)row["Adress"], (string)row["City"], GetCinemas((int)row["id"]));
                    movietheatres.Add(movietheatre);
                }

                return movietheatres;
            }
            return null;
        }
        private List<Cinema> GetCinemas(int id)
        {
            DataTable result = cinemadata.GetCinemas(id);
            List<Cinema> cinemas = new List<Cinema>();
            if (result != null)
            {
                //loop through datatable results
                foreach (DataRow row in result.Rows)
                {
                    Cinema cinema = new Cinema((int)row["id"], (int)row["name"], (bool)row["imax"]);
                    cinemas.Add(cinema);
                }
                return cinemas;
            }
            return null;
        }
    }
}
