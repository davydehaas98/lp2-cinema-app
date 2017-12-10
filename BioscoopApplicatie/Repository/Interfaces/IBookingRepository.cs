using System;
using System.Linq;
using Models;

namespace Repository.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Client GetClientByID(int clientid);
        IQueryable<Client> GetClients();
        IQueryable<Ticket> GetTicketsByBooking(int bookingid);
        IQueryable<Seat> GetSeatsByBooking(int bookingid);
        void InsertClient(string firstname, string lastname, string email, DateTime birthday, string gender, string password);
    }
}
