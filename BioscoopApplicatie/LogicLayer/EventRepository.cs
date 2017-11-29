using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;
using DataLayer.Interfaces;
using Models;

namespace Repository
{
    public class EventRepository
    {
        private IEventContext context;
        public EventRepository() : this(new EventContext()) { }
        public EventRepository(IEventContext context) { this.context = context; }
        public List<Event> GetAll()
        {
            return context.GetAll().ToList();
        }
        public Event GetEvent(int idevent)
        {
            return context.GetEvent(idevent);
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
