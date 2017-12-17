using System;
using System.Linq;
using Models;

namespace Context.Interfaces
{
    public interface IEventContext : IContext<Event>
    {
        void InsertEvent(DateTime datetime, int cinemaid, int movieid);
        IQueryable<Event> GetEventsByMovie(int movieid);
    }
}
