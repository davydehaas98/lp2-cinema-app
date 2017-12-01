﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataLayer.Interfaces
{
    public interface IBookingContext : IContext<Booking>
    {
        Client GetClient(int id);
        IQueryable<Ticket> GetTickets(int bookingid);
        IQueryable<Seat> GetSeats(int bookingid);
    }
}
