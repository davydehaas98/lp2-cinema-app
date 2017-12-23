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
        public BookingViewModel(Event event_, List<Seat> bookedseats)
        {
            this.Event_ = event_;
            this.BookedSeats = bookedseats;
        }
        public Event Event_ { get; set; }
        public List<Seat> BookedSeats { get; set; }
    }
}