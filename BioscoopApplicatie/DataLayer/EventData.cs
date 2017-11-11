using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class EventData : DataAccess
    {
        public DataTable GetEvents()
        {
            string query = "SELECT * FROM [Event]";
            DataTable result = ExecSelectQuery(query);
            return result;
        }
        public DataTable GetEventByID(int idevent)
        {
            string query = "SELECT * FROM [Event] WHERE id = @idevent";
            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@idevent", SqlDbType.Int);
            pars[0].Value = idevent;

            DataTable result = ExecSelectQuery(query, pars);

            return result;
        }
        
        public DataTable GetSeats(int idevent)
        {
            string query = "SELECT s.id, s.[Row], s.Number, s.Price, es.Booked FROM [Event_Seat] es INNER JOIN [Event] e ON es.EventID = e.id INNER JOIN [Seat] s ON es.SeatID = s.id WHERE e.id = @idevent";
            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@idevent", SqlDbType.Int);
            pars[0].Value = idevent;

            DataTable result = ExecSelectQuery(query, pars);
            return result;
        }
    }
}
