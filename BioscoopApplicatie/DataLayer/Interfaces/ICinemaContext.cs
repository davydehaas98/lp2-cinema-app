using System;
using System.Linq;
using Models;

namespace Context.Interfaces
{
    public interface ICinemaContext : IContext<Cinema>
    {
        IQueryable<MovieTheatre> GetMovieTheatres();
        MovieTheatre GetMovieTheatreByID(int id);
        IQueryable<Cinema> GetCinemasByMovieTheatre(int movietheatreid);
    }
}
