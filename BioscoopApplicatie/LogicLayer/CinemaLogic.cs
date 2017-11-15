using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;

namespace LogicLayer
{
    public class CinemaLogic
    {
        private CinemaData cinemadata;
        public CinemaLogic()
        {
            cinemadata = new CinemaData();
        }
        public MovieTheatre GetMovieTheatre(int idcinema)
        {
            DataTable result = cinemadata.GetMovieTheatre(idcinema);
            if (result != null)
            {
                DataRow row = result.Rows[0];
                return new MovieTheatre((int)row["id"], (string)row["Name"], (string)row["Adress"], (string)row["city"]);
            }
            return null;
        }
        public List<MovieTheatre> GetMovieTheatres() 
        {
            DataTable result = cinemadata.GetMovieTheatres();
            List<MovieTheatre> movietheatres = new List<MovieTheatre>();
            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    movietheatres.Add(new MovieTheatre((int)row["id"], (string)row["Name"], (string)row["Adress"], (string)row["PostalCode"], (string)row["City"], GetCinemas((int)row["id"])));
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
                    cinemas.Add(new Cinema((int)row["id"], (int)row["MovieTheatreID"], (int)row["Name"], (bool)row["3D"]));
                }
                return cinemas;
            }
            return null;
        }
    }
}
