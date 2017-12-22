using System.Collections.Generic;
using System.Linq;
using Models;

namespace Repository.Interfaces
{
    public interface ICinemaRepository : IRepository<Cinema>
    {
        List<MovieTheatre> GetMovieTheatres();
        List<Cinema> GetCinemasByMovieTheatre(int movietheatreid);
    }
}
