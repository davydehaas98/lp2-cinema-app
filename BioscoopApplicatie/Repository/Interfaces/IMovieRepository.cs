using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repository.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        List<Movie> GetMoviesByReleaseDate(DateTime date);
        List<Genre> GetGenres();
        List<Genre> GetGenres(int movieid);
        void InsertMovie(string moviename, bool movied3, int movielength, int movieminimumage, DateTime moviereleasedate, Image movieimage, List<int> genreids);
        void UpdateMovie(int movieid, string moviename, bool movied3, int movielength, int movieminimumage, DateTime moviereleasedate, Image movieimage);
        bool CheckFields(string name, string length, DateTime releasedate, Image image, List<int> genres);
    }
}
