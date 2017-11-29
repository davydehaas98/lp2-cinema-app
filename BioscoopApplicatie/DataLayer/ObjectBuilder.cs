using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataLayer.Context;
using System.Data;
using ImageConverter;

namespace DataLayer
{
    internal static class ObjectBuilder
    {
        private static MovieContext moviecontext = new MovieContext();
        private static CinemaContext cinemacontext = new CinemaContext();
        private static EventContext eventcontext = new EventContext();
        internal static Movie CreateMovie(DataRow row)
        {
            return new Movie((int)row["id"], (string)row["Name"], (bool)row["D3"], (int)row["Length"], (int)row["MinimumAge"], (DateTime)row["ReleaseDate"], ImageBuilder.ByteToImageSource((byte[])row["Image"]), moviecontext.GetGenres((int)row["id"]).ToList());
        }
        internal static Genre CreateGenre(DataRow row)
        {
            return new Genre((int)row["id"], (string)row["Name"]);
        }
        internal static Cinema CreateCinema(DataRow row)
        {
            return new Cinema((int)row["id"], (int)row["Name"], (bool)row["D3"]);
        }
        internal static MovieTheatre CreateMovieTheatre(DataRow row)
        {
            return new MovieTheatre((int)row["id"], (string)row["Name"], (string)row["Address"], (string)row["PostalCode"], (string)row["City"], cinemacontext.GetCinemas((int)row["id"]).ToList());
        }
        internal static Event CreateEvent(DataRow row)
        {
            return new Event((int)row["id"], (DateTime)row["DateTime"], moviecontext.GetMovie((int)row["MovieID"]), cinemacontext.GetCinema((int)row["CinemaID"]), cinemacontext.GetMovieTheatre((int)row["CinemaID"]), eventcontext.GetSeats((int)row["id"]).ToList());
        }
        private static Seat CreateSeat(DataRow row)
        {
            return new Seat((int)row["id"], (int)row["Row"], (int)row["Number"]);
        }
        internal static IQueryable<Movie> CreateMovieList(DataTable table)
        {
            if (table.Rows.Count > 0)
            {
                List<Movie> movies = new List<Movie>();
                foreach (DataRow row in table.Rows)
                {
                    movies.Add(CreateMovie(row));
                }
                return movies.AsQueryable();
            }
            return null;
        }
        internal static IQueryable<Genre> CreateGenreList(DataTable table)
        {
            if (table.Rows.Count > 0)
            {
                List<Genre> genres = new List<Genre>();
                foreach (DataRow row in table.Rows)
                {
                    genres.Add(CreateGenre(row));
                }
                return genres.AsQueryable();
            }
            return null;
        }
        internal static IQueryable<MovieTheatre> CreateMovieTheatreList(DataTable table)
        {
            if (table.Rows.Count > 0)
            {
                List<MovieTheatre> movietheatres = new List<MovieTheatre>();
                foreach (DataRow row in table.Rows)
                {
                    movietheatres.Add(CreateMovieTheatre(row));
                }
                return movietheatres.AsQueryable();
            }
            return null;
        }
        internal static IQueryable<Cinema> CreateCinemaList(DataTable table)
        {
            if (table.Rows.Count > 0)
            {
                List<Cinema> cinemas = new List<Cinema>();
                foreach (DataRow row in table.Rows)
                {
                    cinemas.Add(CreateCinema(row));
                }
                return cinemas.AsQueryable();
            }
            return null;
        }
        internal static IQueryable<Event> CreateEventList(DataTable table)
        {
            if (table.Rows.Count > 0)
            {
                List<Event> events = new List<Event>();
                foreach (DataRow row in table.Rows)
                {
                    events.Add(CreateEvent(row));
                }
                return events.AsQueryable();
            }
            return null;
        }
        internal static IQueryable<Seat> CreateSeatList(DataTable table)
        {
            List<Seat> seats = new List<Seat>();
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    seats.Add(CreateSeat(row));
                }
                return seats.AsQueryable();
            }
            return seats.AsQueryable();
        }
    }
}
