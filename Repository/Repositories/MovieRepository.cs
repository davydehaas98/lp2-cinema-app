using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            if (!string.IsNullOrWhiteSpace(moviename) && movielength > 0 && movieminimumage > 0 && moviereleasedate.Date != null && movieimage.Contains("i.imgur.com"))
            {
                if (moviename.Length < 51 && movielength.ToString().Length < 51 && movieminimumage.ToString().Length < 50 && movieimage.Length < 51)
                {
                    try
                    {
                        context.InsertMovie(moviename, movied3, movielength, movieminimumage, moviereleasedate, movieimage, genreids);
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Database Failure. Error Code: " + ex.Number, ex);
                    }
                }
                else
                {
                    throw new OverflowException();
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public void UpdateMovie(int movieid, string moviename, bool movied3, int movielength, int movieminimumage, DateTime moviereleasedate, string movieimage)
        {
            if (!string.IsNullOrWhiteSpace(moviename) && movielength > 0 && movieminimumage > 0 && moviereleasedate.Date != null && movieimage.Contains("i.imgur.com"))
            {
                if (moviename.Length < 51 && movielength.ToString().Length < 51 && movieminimumage.ToString().Length < 50 && movieimage.Length < 51)
                {
                    try
                    {
                        context.UpdateMovie(movieid, moviename, movied3, movielength, movieminimumage, moviereleasedate, movieimage);
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Database Failure. Error Code: " + ex.Number, ex);
                    }
                }
                else
                {
                    throw new OverflowException();
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
