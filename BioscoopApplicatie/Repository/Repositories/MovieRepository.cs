using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;
using DataLayer.Interfaces;
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
        public List<Movie> GetAll()
        {
            return context.GetAll().ToList();
        }
        public Movie GetMovie(int idmovie)
        {
            return context.GetMovie(idmovie);
        }
        public List<Movie> GetMoviesByReleaseDate(DateTime date)
        {
            return context.GetMoviesByReleaseDate(date).ToList();
        }
        public List<Genre> GetGenres()
        {
            return context.GetGenres().ToList();
        }
        public List<Genre> GetGenres(int idmovie)
        {
            return context.GetGenres(idmovie).ToList();
        }
        public void InsertMovie(string name, bool d3, int length, int minimumage, DateTime releasedate, Image image, List<int> idgenres)
        {
            context.InsertMovie(name, d3, length, minimumage, releasedate, ImageBuilder.ImageToByteArray(image), idgenres);
        }
        public void UpdateMovie(int idmovie, Image image)
        {
            context.UpdateMovie(idmovie, ImageBuilder.ImageToByteArray(image));
        }
        public bool CheckFields(string name, string length, DateTime releasedate, Image image, List<int> genres)
        {
            Int32.TryParse(length, out int result);
            if (String.IsNullOrWhiteSpace(name) || result <= 0 || image == null || GetAll().Exists(movie => movie.Name == name && movie.ReleaseDate == releasedate) || genres.Count < 1)
                return false;
            else
                return true;
        }
    }
}
