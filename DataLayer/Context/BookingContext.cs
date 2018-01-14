using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Models;
using Context.Interfaces;

namespace Context.Context
{
    public class BookingContext : IBookingContext
    {
        private DataAccess db;
        public BookingContext()
        {
            db = new DataAccess();
        }
        public List<Booking> GetAll()
        {
            return ObjectBuilder.CreateBookingList(db.ExecStoredProcedure("[GetBookings]").Tables[0]);
        }
        public Booking GetByID(int bookingid)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@bookingid", SqlDbType.Int) { Value = bookingid });
            return ObjectBuilder.CreateBooking(db.ExecStoredProcedure("[GetBookingByID]", pars).Tables[0].Rows[0]);
        }
        public List<Booking> GetBookingsByEvent(int eventid)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@eventid", SqlDbType.Int) { Value = eventid });
            return ObjectBuilder.CreateBookingList(db.ExecStoredProcedure("[GetBookingsByEvent]", pars).Tables[0]);
        }
        public List<Booking> GetBookingsByClient(int clientid)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@clientid", SqlDbType.Int) { Value = clientid });
            return ObjectBuilder.CreateBookingList(db.ExecStoredProcedure("[GetBookingsByClient]", pars).Tables[0]);
        }
        public List<Client> GetClients()
        {
            return ObjectBuilder.CreateClientList(db.ExecStoredProcedure("[GetClients]").Tables[0]);
        }
        public Client GetClientByID(int clientid)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@clientid", SqlDbType.Int) { Value = clientid });
            return ObjectBuilder.CreateClient(db.ExecStoredProcedure("[GetClientByID]", pars).Tables[0].Rows[0]);
        }
        public Client GetClientByEmail(string email)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@email", SqlDbType.NVarChar) { Value = email });
            return ObjectBuilder.CreateClientWithPassword(db.ExecStoredProcedure("[GetClientByEmail]", pars).Tables[0].Rows[0]);
        }
        public List<Ticket> GetTickets()
        {
            return ObjectBuilder.CreateTicketList(db.ExecStoredProcedure("[GetTickets]").Tables[0]);
        }
        public List<Ticket> GetTicketsByBooking(int bookingid)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@bookingid", SqlDbType.Int) { Value = bookingid });
            return ObjectBuilder.CreateTicketList(db.ExecStoredProcedure("[GetTicketsByBooking]", pars).Tables[0]);
        }
        public List<Seat> GetSeats()
        {
            return ObjectBuilder.CreateSeatList(db.ExecStoredProcedure("[GetSeats]").Tables[0]);
        }
        public List<Seat> GetSeatsByBooking(int bookingid)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@bookingid", SqlDbType.Int) { Value = bookingid });
            return ObjectBuilder.CreateSeatList(db.ExecStoredProcedure("[GetSeatsByBooking]", pars).Tables[0]);
        }
        public void InsertBooking(int clientid, int amount, decimal totalprice, List<int> ticketsid, int eventid, List<int> seatsid)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@clientid", SqlDbType.Int) { Value = clientid });
            pars.Add(new SqlParameter("@amount", SqlDbType.Int) { Value = amount });
            pars.Add(new SqlParameter("@totalprice", SqlDbType.Decimal) { Value = totalprice });
            pars.Add(new SqlParameter("@eventid", SqlDbType.Int) { Value = eventid });
            int bookingid = (int)db.ExecStoredProcedure("InsertBooking", pars).Tables[0].Rows[0]["Column1"];
            foreach(int ticketid in ticketsid)
            {
                List<SqlParameter> parsticket = new List<SqlParameter>();
                parsticket.Add(new SqlParameter("@bookingid", SqlDbType.Int) { Value = bookingid });
                parsticket.Add(new SqlParameter("@ticketid", SqlDbType.Int) { Value = ticketid });
                db.ExecStoredProcedure("[AddTicketToBooking]", parsticket);
            }
            foreach(int seatid in seatsid)
            {
                List<SqlParameter> parsseat = new List<SqlParameter>();
                parsseat.Add(new SqlParameter("@seatid", SqlDbType.Int) { Value = seatid });
                parsseat.Add(new SqlParameter("@bookingid", SqlDbType.Int) { Value = bookingid });
                db.ExecStoredProcedure("[AddSeatToBooking]", parsseat);
            }
        }
        public void InsertClient(string firstname, string lastname, string email, DateTime birthday, string gender, string password, string salt)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@firstname", SqlDbType.NVarChar) { Value = firstname });
            pars.Add(new SqlParameter("@lastname", SqlDbType.NVarChar) { Value = lastname });
            pars.Add(new SqlParameter("@email", SqlDbType.NVarChar) { Value = email });
            pars.Add(new SqlParameter("@birthday", SqlDbType.Date) { Value = birthday });
            pars.Add(new SqlParameter("@gender", SqlDbType.NVarChar) { Value = gender });
            pars.Add(new SqlParameter("@password", SqlDbType.NVarChar) { Value = password });
            pars.Add(new SqlParameter("@salt", SqlDbType.NVarChar) { Value = salt });
            db.ExecStoredProcedure("[InsertClient]", pars);
        }
        public void UpdateClient(int clientid, string firstname, string lastname, string email, DateTime birthday, string gender)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@clientid", SqlDbType.Int) { Value = clientid });
            pars.Add(new SqlParameter("@firstname", SqlDbType.NVarChar) { Value = firstname });
            pars.Add(new SqlParameter("@lastname", SqlDbType.NVarChar) { Value = lastname });
            pars.Add(new SqlParameter("@email", SqlDbType.NVarChar) { Value = email });
            pars.Add(new SqlParameter("@birthday", SqlDbType.Date) { Value = birthday });
            pars.Add(new SqlParameter("@gender", SqlDbType.NVarChar) { Value = gender });
            db.ExecStoredProcedure("[UpdateClient]", pars);
        }
        public bool CheckIfEmailExists(string email)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@email", SqlDbType.NVarChar) { Value = email });
            DataTable result = db.ExecStoredProcedure("GetClientByEmail", pars).Tables[0];
            return result.Rows.Count > 0;
        }
    }
}
