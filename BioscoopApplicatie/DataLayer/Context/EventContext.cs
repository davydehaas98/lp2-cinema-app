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
            string query = "SELECT * FROM [AllEvents]";
            DataTable result = db.ExecSelectQuery(query);
            return ObjectBuilder.CreateEventList(result);
        }
        public Event GetEvent(int eventid)
        {
            string query = "SELECT * FROM [AllEvents] WHERE id = @eventid";
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@eventid", SqlDbType.Int) { Value = eventid });
            return ObjectBuilder.CreateEvent(db.ExecSelectQuery(query, pars).Rows[0]);
        }
        public IQueryable<Seat> GetSeats(int eventid)
        {
            string query = "SELECT * FROM [AllSeats] WHERE EventID = @eventid";
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@eventid", SqlDbType.Int) { Value = eventid });
            return ObjectBuilder.CreateSeatList(db.ExecSelectQuery(query, pars));
        }
        public void InsertEvent(DateTime datetime, int cinemaid, int movieid)
        {
            string query = "INSERT INTO [Event] ([DateTime], [CinemaID], [MovieID]) VALUES (@datetime, @cinemaid, @movieid)";
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@datetime", SqlDbType.DateTime) { Value = datetime });
            pars.Add(new SqlParameter("@cinemaid", SqlDbType.Int) { Value = cinemaid });
            pars.Add(new SqlParameter("@movieid", SqlDbType.Int) { Value = movieid });
            db.ExecInsertQuery(query, pars);
        }
    }
}
