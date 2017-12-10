using System;
using System.Linq;
using Models;

namespace Context.Interfaces
{
    public interface IEventContext : IContext<Event>
    {
        IQueryable<Seat> GetSeatsByEvent(int idevent);
        void InsertEvent(DateTime datetime, int cinemaid, int movieid);
    }
}
