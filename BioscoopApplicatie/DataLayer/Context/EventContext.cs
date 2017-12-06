using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models;
using DataLayer.Interfaces;

namespace DataLayer.Context
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
            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@eventid", SqlDbType.Int);
            pars[0].Value = eventid;

            DataRow result = db.ExecSelectQuery(query, pars).Rows[0];

            return ObjectBuilder.CreateEvent(result);
        }
        
        public IQueryable<Seat> GetSeats(int eventid)
        {
            string query = "SELECT * FROM [AllSeats] WHERE EventID = @eventid";
            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@eventid", SqlDbType.Int);
            pars[0].Value = eventid;

            DataTable result = db.ExecSelectQuery(query, pars);
            return ObjectBuilder.CreateSeatList(result);
        }
        public void InsertEvent(DateTime datetime, int cinemaid, int movieid)
        {
            string query = "INSERT INTO [Event] ([DateTime], [CinemaID], [MovieID]) VALUES (@datetime, @cinemaid, @movieid)";
            SqlParameter[] pars = new SqlParameter[3];
            pars[0] = new SqlParameter("@datetime", SqlDbType.DateTime);
            pars[0].Value = datetime;

            pars[1] = new SqlParameter("@cinemaid", SqlDbType.Int);
            pars[1].Value = cinemaid;

            pars[2] = new SqlParameter("@movieid", SqlDbType.Int);
            pars[2].Value = movieid;

            int? eventid = db.ExecInsertQuery(query, pars);
        }
    }
}
