using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace CinemaWebsite.ViewModels
{
    public class EventViewModel
    {
        public EventViewModel(Event event_, List<int> seatids)
        {
            this.Event_ = Event_;
        }
        public Event Event_ { get; set; }

    }
}