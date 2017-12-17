using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Context.Interfaces
{
    public interface IMovieContext : IContext<Movie>
    {
        IQueryable<Movie> GetMoviesReleased(DateTime date);
        IQueryable<Genre> GetGenres();
        IQueryable<Genre> GetGenresByMovie(int movieid);
        void InsertMovie(string moviename, bool movied3, int movielength, int movieminimumage, DateTime moviereleasedate, string movieimage, List<int> genreids);
        void UpdateMovie(int movieid, string moviename, bool movied3, int movielength, int movieminimumage, DateTime moviereleasedate, string movieimage);
    }
}
