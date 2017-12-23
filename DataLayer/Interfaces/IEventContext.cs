using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Context.Interfaces
{
    public interface IEventContext : IContext<Event>
    {
        void InsertEvent(DateTime datetime, int cinemaid, int movieid);
        List<Seat> GetBookedSeatsByEvent(int eventid);
        List<Event> GetEventsByMovie(int movieid);
    }
}
