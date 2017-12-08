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
        public IQueryable<Cinema> GetAll()
        {
            return context.GetAll();
        }
        public Cinema GetByID(int idcinema)
        {
            return context.GetByID(idcinema);
        }
        public IQueryable<MovieTheatre> GetMovieTheatres()
        {
            return context.GetMovieTheatres();
        }
        public IQueryable<MovieTheatre> GetMovieTheatresByType(bool d3)
        {
            return context.GetMovieTheatresByType(d3);
        }
        public IQueryable<Cinema> GetCinemas(int movietheatreid)
        {
            return context.GetCinemasByMovieTheatre(movietheatreid);
        }
    }
}
