using System;
using System.Linq;
using Context.Context;
using Context.Interfaces;
using Repository.Interfaces;
using Models;

namespace Repository.Repositories
{
    public class EventRepository : IEventRepository
    {
        private IEventContext context;
        public EventRepository() : this(new EventContext()) { }
        public EventRepository(IEventContext context) { this.context = context; }
        public IQueryable<Event> GetAll()
        {
            return context.GetAll();
        }
        public Event GetByID(int idevent)
        {
            return context.GetByID(idevent);
        }
        public IQueryable<Seat> GetSeatsByEvent(int idevent)
        {
            return context.GetSeatsByEvent(idevent);
        }
        public void InsertEvent(DateTime datetime, int idcinema, int idmovie)
        {
            context.InsertEvent(datetime, idcinema, idmovie);
        }
    }
}
