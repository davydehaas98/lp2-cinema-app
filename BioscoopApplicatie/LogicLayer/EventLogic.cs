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
        private CinemaLogic cinemalogic;
        private ImageLogic imagelogic;
        public EventLogic()
        {
            eventdata = new EventData();
            moviedata = new MovieData();
            cinemadata = new CinemaData();
            cinemalogic = new CinemaLogic();
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
                    events.Add(new Event((int)row["id"], (DateTime)row["DateTime"], GetMovie((int)row["MovieID"]), GetCinema((int)row["CinemaID"]), GetMovieTheatre((int)row["CinemaID"]), GetSeats((int)row["id"])));
                }
                return events;
            }
            return null;
        }
        public Event GetEvent(int id)
        {
            DataTable result = eventdata.GetEvent(id);
            if (result != null)
            {
                DataRow row = result.Rows[0];
                return new Event((int)row["id"], (DateTime)row["DateTime"], GetMovie((int)row["MovieID"]), GetCinema((int)row["CinemaID"]), GetMovieTheatre((int)row["CinemaID"]), GetSeats((int)row["id"]));
            }
            return null;
        }
        private Movie GetMovie(int idmovie)
        {
            DataTable result = moviedata.GetMovieByID(idmovie);
            if (result != null)
            {
                DataRow row = result.Rows[0];
                return new Movie((int)row["id"], (string)row["Name"], (bool)row["D3"], (int)row["Length"], (int)row["MinimumAge"], (DateTime)row["ReleaseDate"], imagelogic.ByteToImageSource((byte[])row["Image"]), GetGenres((int)row["id"]));
            }
            return null;
        }
        private Cinema GetCinema(int idcinema)
        {
            DataTable result = cinemadata.GetCinemaByID(idcinema);
            if (result != null)
            {
                DataRow row = result.Rows[0];
                return new Cinema((int)row["id"], (int)row["Name"], (bool)row["D3"]);
            }
            return null;
        }
        private MovieTheatre GetMovieTheatre(int idcinema)
        {
            DataTable result = cinemadata.GetMovieTheatre(idcinema);
            if (result != null)
            {
                DataRow row = result.Rows[0];
                return new MovieTheatre((int)row["id"], (string)row["Name"], (string)row["Address"], (string)row["PostalCode"], (string)row["City"]);
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
                    seats.Add(new Seat((int)row["id"], (int)row["Row"], (int)row["Number"]));
                }
                return seats;
            }
            return null;
        }
        public void InsertEvent(DateTime date, int cinemaid, int movieid)
        {
            eventdata.InsertEvent(date, cinemaid, movieid);
        }
    }
}
