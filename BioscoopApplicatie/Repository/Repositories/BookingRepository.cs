using System;
using System.Linq;
using Cryptography;
using Context.Context;
using Context.Interfaces;
using Repository.Interfaces;
using Models;

namespace Repository.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private IBookingContext context;
        public BookingRepository():this(new BookingContext()) { }
        public BookingRepository(IBookingContext context) { this.context = context; }
        public IQueryable<Booking> GetAll()
        {
            return context.GetAll();
        }
        public Booking GetByID(int bookingid)
        {
            return context.GetByID(bookingid);
        }
        public Client GetClientByID(int id)
        {
            return context.GetClientByID(id);
        }
        public IQueryable<Client> GetClients()
        {
            return context.GetClients();
        }
        public IQueryable<Ticket> GetTicketsByBooking(int bookingid)
        {
            return context.GetTicketsByBooking(bookingid);
        }
        public IQueryable<Seat> GetSeatsByBooking(int bookingid)
        {
            return context.GetSeatsByBooking(bookingid);
        }
        public void InsertClient(string firstname, string lastname, string email, DateTime birthday, string gender, string password)
        {
            string salt = Crypto.GenerateSalt();
            context.InsertClient(firstname, lastname, email, birthday, gender, Crypto.GenerateHash(password, salt), salt);
        }
    }
}
