using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Context.Interfaces
{
    public interface IMovieContext : IContext<Movie>
    {
        List<Movie> GetMoviesReleased(DateTime date);
        List<Genre> GetGenres();
        List<Genre> GetGenresByMovie(int movieid);
        void InsertMovie(string moviename, bool movied3, int movielength, int movieminimumage, DateTime moviereleasedate, string movieimage, List<int> genreids);
        void UpdateMovie(int movieid, string moviename, bool movied3, int movielength, int movieminimumage, DateTime moviereleasedate, string movieimage);
    }
}
