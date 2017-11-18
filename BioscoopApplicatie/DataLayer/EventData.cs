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

            int? eventid = ExecInsertQuery(query, pars);
            for (int seatid = 0; seatid < 51; seatid++)
            {
                string query2 = "INSERT INTO [Event_Seat] (EventID, SeatID, Booked) VALUES (@eventid, @seatid, 0)";

                SqlParameter[] pars2 = new SqlParameter[2];

                pars2[0] = new SqlParameter("@eventid", SqlDbType.Int);
                pars2[0].Value = eventid;

                pars2[1] = new SqlParameter("@seatid", SqlDbType.Int);
                pars2[1].Value = seatid;
                ExecInsertQuery(query2, pars2);

            }
        }
    }
}
