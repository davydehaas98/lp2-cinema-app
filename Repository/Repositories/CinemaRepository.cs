using System;
using System.Collections.Generic;
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
        public List<Cinema> GetAll()
        {
            return context.GetAll();
        }
        public Cinema GetByID(int idcinema)
        {
            return context.GetByID(idcinema);
        }
        public List<MovieTheatre> GetMovieTheatres()
        {
            return context.GetMovieTheatres();
        }
        public List<Cinema> GetCinemasByMovieTheatre(int movietheatreid)
        {
            return context.GetCinemasByMovieTheatre(movietheatreid);
        }
    }
}
