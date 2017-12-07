using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context.Context;
using Context.Interfaces;
using Models;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class CinemaRepository : ICinemaRepository
    {
        private ICinemaContext context;
        public CinemaRepository() : this(new CinemaContext()) { }
        public CinemaRepository(ICinemaContext context) { this.context = context; }
        public Cinema GetCinema(int idcinema)
        {
            return context.GetCinema(idcinema);
        }
        public MovieTheatre GetMovieTheatre(int idcinema)
        {
            return context.GetMovieTheatre(idcinema);
        }
        public List<MovieTheatre> GetMovieTheatres()
        {
            return context.GetMovieTheatres().ToList();
        }
        public List<MovieTheatre> GetMovieTheatresByType(bool d3)
        {
            return context.GetMovieTheatresByType(d3).ToList();
        }
        public List<Cinema> GetCinemas(int idmovietheatre)
        {
            return context.GetCinemas(idmovietheatre).ToList();
        }
    }
}
