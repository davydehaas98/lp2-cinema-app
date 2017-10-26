using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;

namespace LogicLayer
{
    public class EventLogic
    {
        private EventData eventdata;
        private CinemaData cinemadata;
        private MovieData moviedata;
        private List<Event> events;
        public List<Event> Events
        {
            get { return this.events; }
            set { this.events = value; }
        }
        public EventLogic()
        {
            eventdata = new EventData();
            cinemadata = new CinemaData();
            moviedata = new MovieData();
        }
        public List<Event> GetEvents()
        {
            DataTable result = eventdata.GetEvents();
            events = new List<Event>();
            if (result != null)
            {
                //loop through datatable results
                foreach (DataRow row in result.Rows)
                {
                    Event event_ = new Event((int)row["id"], (DateTime)row["DateTime"], GetCinema((int)row["CinemaID"]), GetMovie((int)row["MovieID"]));
                    events.Add(event_);
                }
                return events;
            }
            return null;
        }
        private Cinema GetCinema(int id)
        {
            DataTable result = cinemadata.GetCinema(id);
            if (result != null)
            {
                //loop through datatable results
                foreach (DataRow row in result.Rows)
                {
                    Cinema cinema = new Cinema((int)row["id"], (int)row["Name"], (bool)row["IMAX"]);
                    return cinema;
                }
            }
            return null;
        }
        private Movie GetMovie(int id)
        {
            DataTable result = moviedata.GetMovie(id);
            if (result != null)
            {
                //loop through datatable results
                foreach (DataRow row in result.Rows)
                {
                    Movie movie = new Movie((int)row["id"], (string)row["Name"], (string)row["Type"], (int)row["Length"], (int)row["MinimumAge"], GetGenres((int)row["id"]));
                    return movie;
                }
            }
            return null;
        }
        public List<Genre> GetGenres(int idmovie)
        {
            DataTable result = moviedata.GetGenres(idmovie);
            List<Genre> genres = new List<Genre>();
            if (result != null)
            {
                //loop through datatable results
                foreach (DataRow row in result.Rows)
                {
                    Genre genre = new Genre((int)row["id"], (string)row["Name"]);
                    genres.Add(genre);
                }
                return genres;
            }
            return null;
        }
    }
}
