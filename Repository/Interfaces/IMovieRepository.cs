using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Models;

namespace Repository.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IQueryable<Movie> GetMoviesByReleaseDate(DateTime date);
        IQueryable<Genre> GetGenres();
        IQueryable<Genre> GetGenres(int movieid);
        void InsertMovie(string moviename, bool movied3, int movielength, int movieminimumage, DateTime moviereleasedate, string movieimage, List<int> genreids);
        void UpdateMovie(int movieid, string moviename, bool movied3, int movielength, int movieminimumage, DateTime moviereleasedate, string movieimage);
    }
}
