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
        public BookingViewModel(Event event_, List<Seat> seats, List<Ticket> tickets)
        {
            this.Event_ = event_;
            this.Seats = seats;
            this.Tickets = tickets;
        }
        public Event Event_ { get; set; }
        public List<Seat> Seats { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Seat> BookSeats { get; set; }
        public List<Ticket> BookTickets { get; set; }
    }
}