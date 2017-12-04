using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Event
    {
        private int id;
        private DateTime datetime;
        private Cinema cinema;
        private Movie movie;
        private MovieTheatre movietheatre;
        private List<Seat> seats;
        public int Id { get { return this.id; } }
        public DateTime DateTime { get { return this.datetime; } }
        public Cinema Cinema { get { return this.cinema; } }
        public MovieTheatre MovieTheatre { get { return this.movietheatre; } }
        public Movie Movie { get { return this.movie; } }
        public List<Seat> Seats { get { return this.seats; } }
        public Event(int id, DateTime datetime, Movie movie, Cinema cinema, MovieTheatre movietheatre, List<Seat> seats)
        {
            this.id = id;
            this.datetime = datetime;
            this.movie = movie;
            this.cinema = cinema;
            this.movietheatre = movietheatre;
            this.seats = seats;
        }
        public void BookSeat(List<Seat> bookedseats)
        {

        }
    }
}
