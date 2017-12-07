﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptography;
using Context.Context;
using Context.Interfaces;
using Models;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private IBookingContext context;
        public BookingRepository():this(new BookingContext()) { }
        public BookingRepository(IBookingContext context) { this.context = context; }
        public List<Booking> GetAll()
        {
            return context.GetAll().ToList();
        }
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
