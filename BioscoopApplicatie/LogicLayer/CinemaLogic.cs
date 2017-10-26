using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;

namespace LogicLayer
{
    public class CinemaLogic
    {
        private CinemaData cinemadata;
        private List<Cinema> cinemas;
        private List<Seat> seats;
        public List<Cinema> Cinemas
        {
            get { return this.cinemas; }
            set { this.cinemas = value; }
        }
        public List<Seat> Seats
        {
            get { return this.seats; }
            set { this.seats = value; }
        }
        public CinemaLogic()
        {
            cinemadata = new CinemaData();
        }
        public List<Cinema> GetCinemas()
        {
            DataTable result = cinemadata.GetCinemas();
            cinemas = new List<Cinema>();
            if (result != null)
            {
                //loop through datatable results
                foreach (DataRow row in result.Rows)
                {
                    Cinema cinema = new Cinema((int)row["id"], (int)row["name"], (bool)row["imax"]);
                    cinemas.Add(cinema);
                }
                return cinemas;
            }
            return null;
        }
        public List<Seat> GetSeats(int idcinema)
        {
            DataTable result = cinemadata.GetSeat();
            seats = new List<Seat>();
            if (result != null)
            {
                //loop through datatable results
                foreach (DataRow row in result.Rows)
                {
                    Seat seat = new Seat((int)row["id"], (int)row["Row"], (int)row["Number"], (decimal)row["Price"]);
                    seats.Add(seat);
                }
                return seats;
            }
            return null;
        }
    }
}
