using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Models;

namespace CinemaWebsite.ViewModels
{
    public class MovieWithEventsViewModel
    {
        public MovieWithEventsViewModel(Movie movie, List<Event> events)
        {
            this.Movie = movie;
            this.Events = events;
        }
        [Required]
        public Movie Movie { get; set; }

        [Required]
        public List<Event> Events { get; set; }
    }
}