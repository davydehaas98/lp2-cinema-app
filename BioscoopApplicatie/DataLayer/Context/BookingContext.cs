using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models;
using Context.Interfaces;

namespace Context.Context
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
            return ObjectBuilder.CreateBookingList(db.ExecSelectQuery(query));
        }
        public Client GetClient(int id)
        {
            string query = "SELECT * FROM [Client] WHERE id = @id";
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@clientid", SqlDbType.Int) { Value = id });
            return ObjectBuilder.CreateClient(db.ExecSelectQuery(query, pars).Rows[0]);
        }
        public IQueryable<Ticket> GetTickets(int bookingid)
        {
            string query = "SELECT * FROM Booking_Ticket INNER JOIN Booking ON Booking_Ticket.BookingID = Booking.id INNER JOIN Ticket ON Booking_Ticket.TicketID = Ticket.id WHERE BookingID = @bookingid";
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@bookingid", SqlDbType.Int) { Value = bookingid });
            return ObjectBuilder.CreateTicketList(db.ExecSelectQuery(query, pars));
        }
        public IQueryable<Seat> GetSeats(int bookingid)
        {
            string query = "SELECT * FROM Event_Seat INNER JOIN[Event] ON Event_Seat.EventID = [Event].id INNER JOIN[Seat] ON Event_Seat.SeatID = Seat.id WHERE Event_Seat.BookingID = @bookingid";
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@bookingid", SqlDbType.Int) { Value = bookingid });
            return ObjectBuilder.CreateSeatList(db.ExecSelectQuery(query, pars));
        }
        public int? InsertClient(string firstname, string lastname, string email, DateTime birthday, string gender, string password, string salt)
        {
            string query = "INSERT INTO [Client] ([FirstName], [LastName], [Email], [Birthday], [Gender], [Password], [Salt]) VALUES (@firstname, @lastname, @email, @birthday, @gender, @password, @salt)";
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@firstname", SqlDbType.NVarChar) { Value = firstname });
            pars.Add(new SqlParameter("@lastname", SqlDbType.NVarChar) { Value = lastname });
            pars.Add(new SqlParameter("@email", SqlDbType.NVarChar) { Value = email });
            pars.Add(new SqlParameter("@birthday", SqlDbType.Date) { Value = birthday });
            pars.Add(new SqlParameter("@gender", SqlDbType.NVarChar) { Value = gender });
            pars.Add(new SqlParameter("@password", SqlDbType.NVarChar) { Value = password });
            pars.Add(new SqlParameter("@salt", SqlDbType.NVarChar) { Value = salt });
            return db.ExecInsertQuery(query, pars);
        }
    }
}
