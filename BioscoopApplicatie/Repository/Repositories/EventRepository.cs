using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context.Context;
using Context.Interfaces;
using Models;
using Repository.Interfaces;

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
        public List<Seat> GetSeats(int idevent)
        {
            return context.GetSeats(idevent).ToList();
        }
        public void InsertEvent(DateTime datetime, int idcinema, int idmovie)
        {
            context.InsertEvent(datetime, idcinema, idmovie);
        }
    }
}
