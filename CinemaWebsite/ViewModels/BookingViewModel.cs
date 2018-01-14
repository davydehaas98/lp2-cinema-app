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
        public BookingViewModel() { }
        public Event Event_ { get; set; }
        public List<Seat> Seats { get; set; }
        public List<Ticket> Tickets { get; set; }
        public int eventid { get; set; }
        public string OrderedSeat { get; set; }
        public Dictionary<int, int> OrderedTickets { get; set; }
    }
}