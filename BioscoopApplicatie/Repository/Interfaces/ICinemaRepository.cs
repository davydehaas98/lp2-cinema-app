using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repository.Interfaces
{
    public interface ICinemaRepository
    {
        Cinema GetCinema(int idcinema);
        MovieTheatre GetMovieTheatre(int idcinema);
        List<MovieTheatre> GetMovieTheatres();
        List<MovieTheatre> GetMovieTheatresByType(bool d3);
        List<Cinema> GetCinemas(int idmovietheatre);
    }
}
