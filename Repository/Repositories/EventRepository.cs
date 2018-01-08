using Context.Context;
using Context.Interfaces;
using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repository.Repositories
{
    public class EventRepository : IEventRepository
    {
        private IEventContext context;
        public EventRepository() : this(new EventContext()) { }
        public EventRepository(IEventContext context) { this.context = context; }
        public List<Event> GetAll()
        {
            return context.GetAll();
        }
        public Event GetByID(int eventid)
        {
            return context.GetByID(eventid);
        }
        public List<Seat> GetBookedSeatsByEvent(int eventid)
        {
            return context.GetBookedSeatsByEvent(eventid);
        }
        public List<Event> GetEventsByMovie(int movieid)
        {
            return context.GetEventsByMovie(movieid);
        }
        public void InsertEvent(DateTime datetime, int idcinema, int idmovie)
        {
            if(datetime.Date >= DateTime.Now)
            {
                try
                {
                    context.InsertEvent(datetime, idcinema, idmovie);
                }
                catch (SqlException ex)
                {
                    throw new Exception("Database Failure. Error Code: " + ex.Number, ex);
                }
            }
            else { throw new InvalidOperationException(); }
        }
    }
}
