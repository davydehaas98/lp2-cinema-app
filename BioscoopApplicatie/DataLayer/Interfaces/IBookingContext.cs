using System;
using System.Linq;
using Models;
using System.Collections.Generic;

namespace Context.Interfaces
{
    public interface IBookingContext : IContext<Booking>
    {
        IQueryable<Booking> GetBookingsByEvent(int eventid);
        Client GetClientByID(int clientid);
        IQueryable<Client> GetClients();
        IQueryable<Ticket> GetTicketsByBooking(int bookingid);
        IQueryable<Seat> GetSeatsByBooking(int bookingid);
        void InsertBooking(int clientid, int amount, decimal totalprice, List<int> ticketsid, int eventid, List<int> seatsid);
        void InsertClient(string firstname, string lastname, string email, DateTime birthday, string gender, string password, string salt);
        void UpdateClient(int clientid, string firstname, string lastname, string email, DateTime birthday, string gender);
    }
}