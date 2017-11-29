using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;
using Models;

namespace Repository
{
    public class CinemaLogic
    {
        private CinemaContext cinemadata;
        public CinemaLogic()
        {
            cinemadata = new CinemaContext();
        }
        public List<MovieTheatre> GetMovieTheatres() 
        {
            DataTable result = cinemadata.GetMovieTheatres();
            List<MovieTheatre> movietheatres = new List<MovieTheatre>();
            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    movietheatres.Add(new MovieTheatre((int)row["id"], (string)row["Name"], (string)row["Address"], (string)row["PostalCode"], (string)row["City"], GetCinemas((int)row["id"])));
                }
                return movietheatres;
            }
            return null;
        }
        public List<MovieTheatre> GetMovieTheatresByType(bool d3)
        {
            DataTable result = cinemadata.GetMovieTheatresByType(d3);
            List<MovieTheatre> movietheatres = new List<MovieTheatre>();
            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    movietheatres.Add(new MovieTheatre((int)row["id"], (string)row["Name"], (string)row["Address"], (string)row["PostalCode"], (string)row["City"], GetCinemas((int)row["id"])));
                }
                return movietheatres;
            }
            return null;
        }
        private List<Cinema> GetCinemas(int idmovietheatre)
        {
            DataTable result = cinemadata.GetCinemas(idmovietheatre);
            List<Cinema> cinemas = new List<Cinema>();
            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    cinemas.Add(new Cinema((int)row["id"], (int)row["Name"], (bool)row["D3"]));
                }
                return cinemas;
            }
            return null;
        }
    }
}
