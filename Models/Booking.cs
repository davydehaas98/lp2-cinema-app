using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Booking
    {
        private int id;
        private DateTime datetime;
        private Client client;
        private Event event_;
        private List<Ticket> tickets;
        private List<Seat> seatsbooked;
        private decimal totalprice;

        public int Id { get { return this.id; } }
        public DateTime DateTime { get { return this.datetime; } }
        public Client Client { get { return this.client; } }
        public Event Event_ { get { return this.event_; } }
        public List<Ticket> Tickets { get { return this.tickets; } }
        public List<Seat> SeatsBooked { get { return this.seatsbooked; } }
        public decimal TotalPrice { get { return this.totalprice; } }
        public Booking(int id, DateTime datetime, Client client, Event event_, List<Ticket> tickets, List<Seat> seatsbooked, decimal totalprice)
        {
            this.id = id;
            this.datetime = datetime;
            this.client = client;
            this.event_ = event_;
            this.tickets = tickets;
            this.seatsbooked = seatsbooked;
            this.totalprice = totalprice;
        }
        public void CalcTotalPrice()
        {
            //seatsbooked.ForEach(seat => totalprice += seat.Price);
        }
    }
}
