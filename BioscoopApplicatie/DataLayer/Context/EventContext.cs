using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Models;
using Context.Interfaces;

namespace Context.Context
{
    public class EventContext : IEventContext
    {
        private DataAccess db;
        public EventContext()
        {
            db = new DataAccess();
        }
        public IQueryable<Event> GetAll()
        {
            return ObjectBuilder.CreateEventList(db.ExecStoredProcedure("[GetEvents]").Tables[0]);
        }
        public Event GetByID(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@id", SqlDbType.Int) { Value = id });
            return ObjectBuilder.CreateEvent(db.ExecStoredProcedure("[GetEventByID]", pars).Tables[0].Rows[0]);
        }
        public void InsertEvent(DateTime datetime, int cinemaid, int movieid)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@datetime", SqlDbType.DateTime) { Value = datetime });
            pars.Add(new SqlParameter("@cinemaid", SqlDbType.Int) { Value = cinemaid });
            pars.Add(new SqlParameter("@movieid", SqlDbType.Int) { Value = movieid });
            db.ExecStoredProcedure("[InsertEvent]", pars);
        }
    }
}
