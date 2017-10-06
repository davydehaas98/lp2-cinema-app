using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;

namespace LogicLayer
{
    public class EventLogic
    {
        private Event event_;
        private EventData eventdata;
        private List<Event> events;
        public List<Event> Events
        {
            get { return this.events; }
            set { this.events = value; }
        }
        public EventLogic()
        {
            eventdata = new EventData();
        }
        //public List<Event> GetEvents()
        //{
        //    DataTable result = eventdata.GetEvents();
        //    events = new List<Event>();
        //    if (result != null)
        //    {
        //        //loop through datatable results
        //        foreach (DataRow row in result.Rows)
        //        {
        //            //event_ = new Event((DateTime)row[""], ,);
        //            events.Add(event_);
        //        }
        //        return events;
        //    }
        //    return null;
        //}
    }
}
