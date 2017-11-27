using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Event
    {
        private int id;
        private DateTime datetime;
        private Cinema cinema;
        private Movie movie;
        private MovieTheatre movietheatre;
        private List<Seat> seats;
        public int Id { get { return this.id; } set { this.id = value; } }
        public DateTime DateTime { get { return this.datetime; } set { this.datetime = value; } }
        public Cinema Cinema { get { return this.cinema; } set { this.cinema = value; } }
        public MovieTheatre MovieTheatre { get { return this.movietheatre; } set { this.movietheatre = value; } }
        public Movie Movie { get { return this.movie; } set { this.movie = value; } }
        public List<Seat> Seats { get { return this.seats; } set { this.seats = value; } }
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
