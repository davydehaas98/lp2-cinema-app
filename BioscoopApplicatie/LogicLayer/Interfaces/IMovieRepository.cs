using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repository.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        Movie GetMovie(int idmovie);
        List<Movie> GetMoviesByReleaseDate(DateTime date);
        List<Genre> GetGenres();
        List<Genre> GetGenres(int idmovie);
        void InsertMovie(string name, bool d3, int length, int minimumage, DateTime releasedate, Image image, List<int> idgenres);
        void UpdateMovie(int idmovie, Image image);
        bool CheckFields(string name, string length, DateTime releasedate, Image image, List<int> genres);
    }
}
