using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;
using DataLayer.Interfaces;
using Models;
using Cryptography;

namespace Repository
{
    public class BookingRepository
    {
        private IBookingContext context;
        public BookingRepository():this(new BookingContext()) { }
        public BookingRepository(IBookingContext context) { this.context = context; }
        public Client GetClient(int id)
        {
            return context.GetClient(id);
        }
        public List<Ticket> GetTickets(int bookingid)
        {
            return context.GetTickets(bookingid).ToList();
        }
        public List<Seat> GetSeats(int bookingid)
        {
            return context.GetSeats(bookingid).ToList();
        }
        public void InsertClient(string firstname, string lastname, string email, DateTime birthday, string gender, string password)
        {
            string salt = Crypto.GenerateSalt();
            context.InsertClient(firstname, lastname, email, birthday, gender, Crypto.GenerateHash(password, salt), salt);
        }
    }
}
