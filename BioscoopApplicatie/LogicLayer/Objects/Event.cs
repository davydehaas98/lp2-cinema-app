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
        public int Id { get { return this.id; } set { this.id = value; } }
        public DateTime DateTime { get { return this.datetime; } set { this.datetime = value; } }
        public Cinema Cinema { get { return this.cinema; } set { this.cinema = value; } }
        public Movie Movie { get { return this.movie; } set { this.movie = value; } }
        public Event(int id, DateTime datetime, Cinema cinema, Movie movie)
        {
            this.id = id;
            this.datetime = datetime;
            this.cinema = cinema;
            this.movie = movie;
        }
    }
}
