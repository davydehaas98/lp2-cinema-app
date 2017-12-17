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
        public Event GetByID(int eventid)
        {
            return context.GetByID(eventid);
        }
        public IQueryable<Event> GetEventsByMovie(int movieid)
        {
            return context.GetEventsByMovie(movieid);
        }
        public void InsertEvent(DateTime datetime, int idcinema, int idmovie)
        {
            context.InsertEvent(datetime, idcinema, idmovie);
        }
    }
}
