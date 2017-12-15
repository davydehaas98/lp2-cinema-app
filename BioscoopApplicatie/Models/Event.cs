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
        public int Id { get { return this.id; } }
        public DateTime DateTime { get { return this.datetime; } }
        public Cinema Cinema { get { return this.cinema; } }
        public Movie Movie { get { return this.movie; } }
        public Event(int id, DateTime datetime, Movie movie, Cinema cinema)
        {
            this.id = id;
            this.datetime = datetime;
            this.movie = movie;
            this.cinema = cinema;
        }
        public void BookSeat(List<Seat> bookedseats)
        {

        }
    }
}
