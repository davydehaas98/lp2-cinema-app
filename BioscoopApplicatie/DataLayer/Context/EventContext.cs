using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models;
using Context.Interfaces;

namespace Context.Context
{
    public class EventContext : IEventContext
    {
        DataAccess db;
        public EventContext()
        {
            db = new DataAccess();
        }
        public IQueryable<Event> GetAll()
        {
            string query = "EXEC [GetEvents]";
            DataTable result = db.ExecSelectQuery(query);
            return ObjectBuilder.CreateEventList(result);
        }
        public Event GetByID(int eventid)
        {
            string query = "EXEC [GetEventByID] @id = @eventid";
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@eventid", SqlDbType.Int) { Value = eventid });
            return ObjectBuilder.CreateEvent(db.ExecSelectQuery(query, pars).Rows[0]);
        }
        public IQueryable<Seat> GetSeats(int eventid)
        {
            string query = "EXEC [GetSeatsByEvent] @id = @eventid";
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@eventid", SqlDbType.Int) { Value = eventid });
            return ObjectBuilder.CreateSeatList(db.ExecSelectQuery(query, pars));
        }
        public void InsertEvent(DateTime eventdatetime, int eventcinemaid, int eventmovieid)
        {
            string query = "EXEC [InsertEvent] @datetime = @eventdatetime, @cinemaid = @eventcinemaid, @movieid = @eventmovieid";
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@eventdatetime", SqlDbType.DateTime) { Value = eventdatetime });
            pars.Add(new SqlParameter("@eventcinemaid", SqlDbType.Int) { Value = eventcinemaid });
            pars.Add(new SqlParameter("@eventmovieid", SqlDbType.Int) { Value = eventmovieid });
            db.ExecInsertQuery(query, pars);
        }
    }
}
