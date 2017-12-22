using System;
using System.Linq;
using Models;
using System.Collections.Generic;

namespace Context.Interfaces
{
    public interface IBookingContext : IContext<Booking>
    {
        List<Booking> GetBookingsByEvent(int eventid);
        List<Booking> GetBookingsByClient(int clientid);
        Client GetClientByID(int clientid);
        Client GetClientByEmail(string email);
        List<Client> GetClients();
        List<Ticket> GetTicketsByBooking(int bookingid);
        List<Seat> GetSeatsByBooking(int bookingid);
        void InsertBooking(int clientid, int amount, decimal totalprice, List<int> ticketsid, int eventid, List<int> seatsid);
        void InsertClient(string firstname, string lastname, string email, DateTime birthday, string gender, string password, string salt);
        void UpdateClient(int clientid, string firstname, string lastname, string email, DateTime birthday, string gender);
        bool CheckIfEmailExists(string email);
    }
}