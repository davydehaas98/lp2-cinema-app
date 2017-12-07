using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Context.Interfaces
{
    public interface ICinemaContext : IContext<Cinema>
    {
        Cinema GetCinema(int idcinema);
        MovieTheatre GetMovieTheatre(int idcinema);
        IQueryable<MovieTheatre> GetMovieTheatres();
        IQueryable<MovieTheatre> GetMovieTheatresByType(bool d3);
        IQueryable<Cinema> GetCinemas(int idmovietheatre);
    }
}
