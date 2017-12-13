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
        public IQueryable<Booking> GetAll()
        {
            return ObjectBuilder.CreateBookingList(db.ExecStoredProcedure("[GetBookings]").Tables[0]);
        }
        public Booking GetByID(int bookingid)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@bookingid", SqlDbType.Int) { Value = bookingid });
            return ObjectBuilder.CreateBooking(db.ExecStoredProcedure("[GetBookingByID]", pars).Tables[0].Rows[0]);
        }
        public IQueryable<Client> GetClients()
        {
            return ObjectBuilder.CreateClientList(db.ExecStoredProcedure("[GetClients]").Tables[0]);
        }
        public Client GetClientByID(int clientid)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@clientid", SqlDbType.Int) { Value = clientid });
            return ObjectBuilder.CreateClient(db.ExecStoredProcedure("[GetClientByID]").Tables[0].Rows[0]);
        }
        public IQueryable<Ticket> GetTicketsByBooking(int bookingid)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@bookingid", SqlDbType.Int) { Value = bookingid });
            return ObjectBuilder.CreateTicketList(db.ExecStoredProcedure("[GetTicketsByBooking]", pars).Tables[0]);
        }
        public IQueryable<Seat> GetSeatsByBooking(int bookingid)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@bookingid", SqlDbType.Int) { Value = bookingid });
            return ObjectBuilder.CreateSeatList(db.ExecStoredProcedure("[GetSeatsByBooking]", pars).Tables[0]);
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
    }
}
