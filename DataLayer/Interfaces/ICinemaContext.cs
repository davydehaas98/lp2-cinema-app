using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Context.Interfaces
{
    public interface ICinemaContext : IContext<Cinema>
    {
        List<MovieTheatre> GetMovieTheatres();
        MovieTheatre GetMovieTheatreByID(int id);
        List<Cinema> GetCinemasByMovieTheatre(int movietheatreid);
    }
}
