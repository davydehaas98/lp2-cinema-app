using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Context.Context;
using System.Data;
using ImageConverter;

namespace Context
{
    internal static class ObjectBuilder
    {
        private static MovieContext moviecontext = new MovieContext();
        private static CinemaContext cinemacontext = new CinemaContext();
        private static EventContext eventcontext = new EventContext();
        private static BookingContext bookingcontext = new BookingContext();
        internal static Movie CreateMovie(DataRow row)
        {
            return new Movie((int)row["id"], (string)row["Name"], (bool)row["D3"], (int)row["Length"], (int)row["MinimumAge"], (DateTime)row["ReleaseDate"], (string)row["Image"], moviecontext.GetGenresByMovie((int)row["id"]));
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
            return new MovieTheatre((int)row["id"], (string)row["Name"], (string)row["Address"], (string)row["PostalCode"], (string)row["City"], cinemacontext.GetCinemasByMovieTheatre((int)row["id"]));
        }
        internal static Event CreateEvent(DataRow row)
        {
            return new Event((int)row["id"], (DateTime)row["DateTime"], moviecontext.GetByID((int)row["MovieID"]), cinemacontext.GetByID((int)row["CinemaID"]), bookingcontext.GetBookingsByEvent((int)row["id"]));
        }
        internal static Seat CreateSeat(DataRow row)
        {
            return new Seat((int)row["id"], (int)row["Row"], (int)row["Number"]);
        }
        internal static Booking CreateBooking(DataRow row)
        {
            return new Booking((int)row["id"], bookingcontext.GetClientByID((int)row["ClientID"]), (DateTime)row["DateTime"],(int)row["Amount"], (decimal)row["TotalPrice"], bookingcontext.GetTicketsByBooking((int)row["id"]), bookingcontext.GetSeatsByBooking((int)row["id"]));
        }
        internal static Client CreateClientWithPassword(DataRow row)
        {
            return new Client((int)row["id"], (string)row["FirstName"], (string)row["LastName"], (DateTime)row["Birthday"], (string)row["Gender"], (string)row["Email"], (string)row["Password"], (string)row["Salt"], (bool)row["Admin"]);
        }
        internal static Client CreateClient(DataRow row)
        {
            return new Client((int)row["id"], (string)row["FirstName"], (string)row["LastName"], (DateTime)row["Birthday"], (string)row["Gender"], (string)row["Email"]);
        }
        internal static Ticket CreateTicket(DataRow row)
        {
            return new Ticket((int)row["id"], (string)row["Name"], (decimal)row["Price"]);
        }
        internal static List<Movie> CreateMovieList(DataTable table)
        {
            List<Movie> movies = new List<Movie>();
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    movies.Add(CreateMovie(row));
                }
            }
            return movies;
        }
        internal static List<Genre> CreateGenreList(DataTable table)
        {
            List<Genre> genres = new List<Genre>();
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    genres.Add(CreateGenre(row));
                }
            }
            return genres;
        }
        internal static List<MovieTheatre> CreateMovieTheatreList(DataTable table)
        {
            List<MovieTheatre> movietheatres = new List<MovieTheatre>();
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    movietheatres.Add(CreateMovieTheatre(row));
                }
            }
            return movietheatres;
        }
        internal static List<Cinema> CreateCinemaList(DataTable table)
        {
            List<Cinema> cinemas = new List<Cinema>();
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    cinemas.Add(CreateCinema(row));
                }
            }
            return cinemas;
        }
        internal static List<Event> CreateEventList(DataTable table)
        {
            List<Event> events = new List<Event>();
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    events.Add(CreateEvent(row));
                }
            }
            return events;
        }
        internal static List<Seat> CreateSeatList(DataTable table)
        {
            List<Seat> seats = new List<Seat>();
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    seats.Add(CreateSeat(row));
                }
            }
            return seats;
        }
        internal static List<Booking> CreateBookingList(DataTable table)
        {
            List<Booking> bookings = new List<Booking>();
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    bookings.Add(CreateBooking(row));
                }
            }
            return bookings;
        }
        internal static List<Client> CreateClientList(DataTable table)
        {
            List<Client> clients = new List<Client>();
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    clients.Add(CreateClient(row));
                }
            }
            return clients;
        }
        internal static List<Ticket> CreateTicketList(DataTable table)
        {
            List<Ticket> tickets = new List<Ticket>();
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    tickets.Add(CreateTicket(row));
                }
            }
            return tickets;
        }
    }
}
