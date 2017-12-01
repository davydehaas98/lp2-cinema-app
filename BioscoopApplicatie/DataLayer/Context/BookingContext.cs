using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models;
using DataLayer.Interfaces;

namespace DataLayer.Context
{
    public class BookingContext : IBookingContext
    {
        DataAccess db;
        public BookingContext()
        {
            db = new DataAccess();
        }
        public IQueryable<Booking> GetAll()
        {
            string query = "SELECT * FROM [Booking]";
            DataTable result = db.ExecSelectQuery(query);
            return ObjectBuilder.CreateBookingList(result);
        }

        public Client GetClient(int id)
        {
            string query = "SELECT * FROM [Client] WHERE id = @id";
            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@clientid", SqlDbType.Int);
            pars[0].Value = id;

            DataRow result = db.ExecSelectQuery(query, pars).Rows[0];

            return ObjectBuilder.CreateClient(result);
        }

        public IQueryable<Ticket> GetTickets(int bookingid)
        {
            string query = "SELECT * FROM Booking_Ticket INNER JOIN Booking ON Booking_Ticket.BookingID = Booking.id INNER JOIN Ticket ON Booking_Ticket.TicketID = Ticket.id WHERE BookingID = @bookingid";
            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@bookingid", SqlDbType.Int);
            pars[0].Value = bookingid;

            DataTable result = db.ExecSelectQuery(query, pars);

            return ObjectBuilder.CreateTicketList(result);
        }

        public IQueryable<Seat> GetSeats(int bookingid)
        {
            string query = "SELECT * FROM Event_Seat INNER JOIN[Event] ON Event_Seat.EventID = [Event].id INNER JOIN[Seat] ON Event_Seat.SeatID = Seat.id WHERE Event_Seat.BookingID = @bookingid";
            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@bookingid", SqlDbType.Int);
            pars[0].Value = bookingid;

            DataTable result = db.ExecSelectQuery(query, pars);

            return ObjectBuilder.CreateSeatList(result);
        }
    }
}
