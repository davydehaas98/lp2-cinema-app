using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context.Context;
using Context.Interfaces;
using Models;
using ImageConverter;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private IMovieContext context;
        public MovieRepository() : this(new MovieContext()) { }
        public MovieRepository(IMovieContext context) { this.context = context; }
        public IQueryable<Movie> GetAll()
        {
            return context.GetAll();
        }
        public Movie GetByID(int idmovie)
        {
            return context.GetByID(idmovie);
        }
        public List<Movie> GetMoviesByReleaseDate(DateTime date)
        {
            return context.GetMoviesReleased(date).ToList();
        }
        public List<Genre> GetGenres()
        {
            return context.GetGenres().ToList();
        }
        public List<Genre> GetGenres(int idmovie)
        {
            return context.GetGenres(idmovie).ToList();
        }
        public void InsertMovie(string moviename, bool movied3, int movielength, int movieminimumage, DateTime moviereleasedate, Image movieimage, List<int> genreids)
        {
            context.InsertMovie(moviename, movied3, movielength, movieminimumage, moviereleasedate, ImageBuilder.ImageToByteArray(movieimage), genreids);
        }
        public void UpdateMovie(int movieid, string moviename, bool movied3, int movielength, int movieminimumage, DateTime moviereleasedate, Image movieimage)
        {
            context.UpdateMovie(movieid, moviename, movied3, movielength, movieminimumage, moviereleasedate, ImageBuilder.ImageToByteArray(movieimage));
        }
        public bool CheckFields(string name, string length, DateTime releasedate, Image image, List<int> genres)
        {
            Int32.TryParse(length, out int result);
            if (String.IsNullOrWhiteSpace(name) || result <= 0 || image == null || GetAll().ToList().Exists(movie => movie.Name == name && movie.ReleaseDate == releasedate) || genres.Count < 1)
                return false;
            else
                return true;
        }
    }
}
