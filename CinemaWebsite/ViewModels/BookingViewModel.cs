using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Models;

namespace CinemaWebsite.ViewModels
{
    public class BookingViewModel
    {
        public BookingViewModel(Event event_, List<Seat> bookedseats, List<Ticket> tickets)
        {
            this.Event_ = event_;
            this.BookedSeats = bookedseats;
            this.Tickets = tickets;
        }
        public Event Event_ { get; set; }
        public List<Seat> BookedSeats { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}