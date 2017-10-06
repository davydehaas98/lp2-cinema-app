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
        private MovieTheatre movietheatre;
        private MovieTheatreData movietheatredata;
        private List<MovieTheatre> movietheatres;
        public List<MovieTheatre> MovieTheatres
        {
            get { return this.movietheatres; }
            set { this.movietheatres = value; }
        }
        public MovieTheatreLogic()
        {
            movietheatredata = new MovieTheatreData();
        }
    }
}
