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

        private List<MovieTheatre> movietheatres;
        private List<Cinema> cinemas;
        private List<Seat> seats;

        public List<MovieTheatre> MovieTheatres
        {
            get { return this.movietheatres; }
            set { this.movietheatres = value; }
        }
        public List<Cinema> Cinemas
        {
            get { return this.cinemas; }
            set { this.cinemas = value; }
        }
        public List<Seat> Seats
        {
            get { return this.seats; }
            set { this.seats = value; }
        }
        public MovieTheatreLogic()
        {
            movietheatredata = new MovieTheatreData();
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
                    MovieTheatre movietheatre = new MovieTheatre((int)row["id"], (string)row["Name"], (string)row["Adress"], (string)row["City"], GetCinemasInMovieTheatre((int)row["id"]));
                    movietheatres.Add(movietheatre);
                }

                return movietheatres;
            }

            return null;
        }
        public List<Cinema> GetCinemasInMovieTheatre(int id)
        {
            DataTable result = movietheatredata.GetCinemasInMovieTheatre(id);
            cinemas = new List<Cinema>();
            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    Cinema cinema = new Cinema((int)row["id"], (string)row["Name"], (bool)row["IMAX"], GetSeatsInCinema((int)row["id"]));
                    cinemas.Add(cinema);
                }
                return cinemas;
            }
            return null;
        }
    }
}
