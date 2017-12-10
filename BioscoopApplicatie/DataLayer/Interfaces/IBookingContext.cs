using System;
using System.Linq;
using Models;

namespace Context.Interfaces
{
    public interface IBookingContext : IContext<Booking>
    {
        Client GetClientByID(int id);
        IQueryable<Client> GetClients();
        IQueryable<Ticket> GetTicketsByBooking(int bookingid);
        IQueryable<Seat> GetSeatsByBooking(int bookingid);
        void InsertClient(string firstname, string lastname, string email, DateTime birthday, string gender, string password, string salt);
    }
}