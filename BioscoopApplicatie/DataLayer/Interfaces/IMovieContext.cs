using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataLayer.Interfaces
{
    public interface IMovieContext : IContext<Movie>
    {
        Movie GetMovie(int idmovie);
        IQueryable<Movie> GetMoviesByReleaseDate(DateTime date);
        IQueryable<Genre> GetGenres();
        IQueryable<Genre> GetGenres(int idmovie);
        void InsertMovie(string name, bool d3, int length, int minimumage, DateTime releasedate, byte[] image, List<int> genreids);
        void UpdateMovie(int idmovie, byte[] image);
    }
}
