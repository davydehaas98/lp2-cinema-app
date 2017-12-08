using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repository.Interfaces
{
    public interface ICinemaRepository : IRepository<Cinema>
    {
        IQueryable<MovieTheatre> GetMovieTheatres();
        IQueryable<MovieTheatre> GetMovieTheatresByType(bool movietheatred3);
        IQueryable<Cinema> GetCinemas(int movietheatreid);
    }
}
