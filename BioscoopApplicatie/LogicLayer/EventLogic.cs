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

namespace LogicLayer
{
    public class EventLogic
    {
        private EventData eventdata;
        private MovieData moviedata;
        private CinemaData cinemadata;
        private ImageLogic imagelogic;
        public EventLogic()
        {
            eventdata = new EventData();
            moviedata = new MovieData();
            cinemadata = new CinemaData();
            imagelogic = new ImageLogic();
        }
        public List<Event> GetEvents()
        {
            DataTable result = eventdata.GetEvents();
            List<Event> events = new List<Event>();
            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    events.Add(new Event((int)row["id"], (DateTime)row["DateTime"], GetCinema((int)row["CinemaID"]), GetMovie((int)row["MovieID"]), GetSeats((int)row["id"])));
                }
                return events;
            }
            return null;
        }
        private Cinema GetCinema(int idcinema)
        {
            DataTable result = cinemadata.GetCinemaByID(idcinema);
            if (result != null)
            {
                DataRow row = result.Rows[0];
                return new Cinema((int)row["id"], (int)row["MovieTheatreID"], (int)row["Name"], (bool)row["3D"]);
            }
            return null;
        }
        private Movie GetMovie(int idmovie)
        {
            DataTable result = moviedata.GetMovieByID(idmovie);
            if (result != null)
            {
                DataRow row = result.Rows[0];
                return new Movie((int)row["id"], (string)row["Name"], (string)row["Type"], (int)row["Length"], (int)row["MinimumAge"], (DateTime)row["ReleaseDate"], imagelogic.ByteToImageSource((byte[])row["Image"]), GetGenres((int)row["id"]));
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
        private List<Seat> GetSeats(int idEvent)
        {
            DataTable result = eventdata.GetSeats(idEvent);
            List<Seat> seats = new List<Seat>();
            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    seats.Add(new Seat((int)row["id"], (int)row["Row"], (int)row["Number"], (decimal)row["Price"], (bool)row["Booked"]));
                }
                return seats;
            }
            return null;
        }
    }
}
