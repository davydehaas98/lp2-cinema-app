using System;
using System.Linq;
using Cryptography;
using Context.Context;
using Context.Interfaces;
using Repository.Interfaces;
using Models;
using System.Collections.Generic;

namespace Repository.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private IBookingContext context;
        public BookingRepository():this(new BookingContext()) { }
        public BookingRepository(IBookingContext context) { this.context = context; }
        public List<Booking> GetAll()
        {
            return context.GetAll();
        }
        public Booking GetByID(int bookingid)
        {
            return context.GetByID(bookingid);
        }
        public List<Booking> GetBookingsByEvent(int eventid)
        {
            return context.GetBookingsByEvent(eventid);
        }
        public List<Booking> GetBookingsByClient(int clientid)
        {
            return context.GetBookingsByClient(clientid);
        }
        public Client GetClientByID(int clientid)
        {
            return context.GetClientByID(clientid);
        }
        public Client GetClientByEmail(string email)
        {
            return context.GetClientByEmail(email);
        }
        public List<Client> GetClients()
        {
            return context.GetClients();
        }
        public List<Ticket> GetTickets()
        {
            return context.GetTickets();
        }
        public List<Ticket> GetTicketsByBooking(int bookingid)
        {
            return context.GetTicketsByBooking(bookingid);
        }
        public List<Seat> GetSeatsByBooking(int bookingid)
        {
            return context.GetSeatsByBooking(bookingid);
        }
        public void InsertBooking(int clientid, int amount, decimal totalprice, List<int> ticketsid, int eventid, List<int> seatsid)
        {
            context.InsertBooking(clientid, amount, totalprice, ticketsid, eventid, seatsid);
        }
        public void InsertClient(string firstname, string lastname, string email, DateTime birthday, string gender, string password)
        {
            string salt = Crypto.GenerateSalt();
            context.InsertClient(firstname, lastname, email, birthday, gender, Crypto.GenerateHash(password, salt), salt);
        }
        public void UpdateClient(int clientid, string firstname, string lastname, string email, DateTime birthday, string gender)
        {
            context.UpdateClient(clientid, firstname, lastname, email, birthday, gender);
        }
        public bool CheckIfEmailExists(string email)
        {
            return context.CheckIfEmailExists(email);
        }
    }
}
