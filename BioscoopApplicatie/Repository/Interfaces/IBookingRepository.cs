using System;
using System.Linq;
using Models;
using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        IQueryable<Booking> GetBookingsByEvent(int eventid);
        IQueryable<Booking> GetBookingsByClient(int clientid);
        Client GetClientByID(int clientid);
        Client GetClientByEmail(string email);
        IQueryable<Client> GetClients();
        IQueryable<Ticket> GetTicketsByBooking(int bookingid);
        IQueryable<Seat> GetSeatsByBooking(int bookingid);
        void InsertBooking(int clientid, int amount, decimal totalprice, List<int> ticketsid, int eventid, List<int> seatsid);
        void InsertClient(string firstname, string lastname, string email, DateTime birthday, string gender, string password);
        void UpdateClient(int clientid, string firstname, string lastname, string email, DateTime birthday, string gender);
        bool CheckIfEmailExists(string email);
    }
}
