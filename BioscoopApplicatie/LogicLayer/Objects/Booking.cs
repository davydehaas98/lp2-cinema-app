using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Booking
    {
        private int id;
        private DateTime datetime;
        private Client client;
        private Event event_;
        private List<Seat> seatsbooked;
        private decimal totalprice;

        public int Id { get { return this.id; } set { this.id = value; } }
        public DateTime DateTime { get { return this.datetime; } set { this.datetime = value; } }
        public Client Client { get { return this.client; } set { this.client = value; } }
        public Event Event_ { get { return this.event_; } set { this.event_ = value; } }
        public List<Seat> SeatsBooked { get { return this.seatsbooked; } set { this.seatsbooked = value; } }
        public decimal TotalPrice { get { return this.totalprice; } set { this.totalprice = value; } }
        public Booking(int id, DateTime datetime,  Client client, Event event_, int totalprice, List<Seat> seatsbooked)
        {
            this.id = id;
            this.datetime = datetime;
            this.client = client;
            this.event_ = event_;
            this.totalprice = totalprice;
            this.seatsbooked = seatsbooked;
        }
        public void CalcTotalPrice()
        {
            seatsbooked.ForEach(seat => totalprice += seat.Price);
        }
    }
}
