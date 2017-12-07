using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Context.Interfaces
{
    public interface IEventContext : IContext<Event>
    {
        Event GetEvent(int idevent);
        IQueryable<Seat> GetSeats(int idevent);
        void InsertEvent(DateTime datetime, int cinemaid, int movieid);
    }
}
