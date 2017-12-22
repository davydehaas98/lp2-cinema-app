using System;
using System.Collections.Generic;
using System.Linq;
using Context.Context;
using Context.Interfaces;
using Repository.Interfaces;
using Models;

namespace Repository.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private IMovieContext context;
        public MovieRepository() : this(new MovieContext()) { }
        public MovieRepository(IMovieContext context) { this.context = context; }
        public List<Movie> GetAll()
        {
            return context.GetAll();
        }
        public Movie GetByID(int idmovie)
        {
            return context.GetByID(idmovie);
        }
        public List<Movie> GetMoviesByReleaseDate(DateTime date)
        {
            return context.GetMoviesReleased(date);
        }
        public List<Genre> GetGenres()
        {
            return context.GetGenres();
        }
        public List<Genre> GetGenres(int idmovie)
        {
            return context.GetGenresByMovie(idmovie);
        }
        public void InsertMovie(string moviename, bool movied3, int movielength, int movieminimumage, DateTime moviereleasedate, string movieimage, List<int> genreids)
        {
            context.InsertMovie(moviename, movied3, movielength, movieminimumage, moviereleasedate, movieimage, genreids);
        }
        public void UpdateMovie(int movieid, string moviename, bool movied3, int movielength, int movieminimumage, DateTime moviereleasedate, string movieimage)
        {
            context.UpdateMovie(movieid, moviename, movied3, movielength, movieminimumage, moviereleasedate, movieimage);
        }
    }
}
