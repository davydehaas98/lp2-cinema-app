using System.Linq;
using Models;

namespace Repository.Interfaces
{
    public interface ICinemaRepository : IRepository<Cinema>
    {
        IQueryable<MovieTheatre> GetMovieTheatres();
        IQueryable<Cinema> GetCinemasByMovieTheatre(int movietheatreid);
    }
}
