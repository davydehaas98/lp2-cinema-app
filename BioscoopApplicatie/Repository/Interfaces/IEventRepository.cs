using System;
using System.Linq;
using System.Collections.Generic;
using Models;

namespace Repository.Interfaces
{
    public interface IEventRepository : IRepository<Event>
    {
        IQueryable<Seat> GetSeatsByEvent(int idevent);
        void InsertEvent(DateTime datetime, int idcinema, int idmovie);
    }
}
