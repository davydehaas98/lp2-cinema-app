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
        public int? InsertClient(string firstname, string lastname, string email, DateTime birthday, string gender, string password, string salt)
        {
            string query = "INSERT INTO [Client] ([FirstName], [LastName], [Email], [Birthday], [Gender], [Password], [Salt]) VALUES (@firstname, @lastname, @email, @birthday, @gender, @password, @salt)";
            SqlParameter[] pars = new SqlParameter[7];
            pars[0] = new SqlParameter("@firstname", SqlDbType.NVarChar);
            pars[0].Value = firstname;
            pars[1] = new SqlParameter("@lastname", SqlDbType.NVarChar);
            pars[1].Value = lastname;
            pars[2] = new SqlParameter("@email", SqlDbType.NVarChar);
            pars[2].Value = email;
            pars[3] = new SqlParameter("@birthday", SqlDbType.Date);
            pars[3].Value = birthday;
            pars[4] = new SqlParameter("@gender", SqlDbType.NVarChar);
            pars[4].Value = gender;
            pars[5] = new SqlParameter("@password", SqlDbType.NVarChar);
            pars[5].Value = password;
            pars[6] = new SqlParameter("@salt", SqlDbType.NVarChar);
            pars[6].Value = salt;
            return db.ExecInsertQuery(query, pars);
        }
    }
}
