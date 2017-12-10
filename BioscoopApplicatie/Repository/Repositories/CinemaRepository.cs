using System;
using System.Linq;
using Context.Context;
using Context.Interfaces;
using Repository.Interfaces;
using Models;

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
        public IQueryable<Cinema> GetCinemasByMovieTheatre(int movietheatreid)
        {
            return context.GetCinemasByMovieTheatre(movietheatreid);
        }
    }
}
