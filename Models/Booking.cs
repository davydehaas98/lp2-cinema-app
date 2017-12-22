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
        private int amount;
        private decimal totalprice;
        private List<Ticket> tickets;
        private List<Seat> seats;

        public int Id { get { return this.id; } }
        public DateTime DateTime { get { return this.datetime; } }
        public Client Client { get { return this.client; } }
        public decimal Amount { get { return this.amount; } }
        public decimal TotalPrice { get { return this.totalprice; } }
        public List<Ticket> Tickets { get { return this.tickets; } }
        public List<Seat> Seats { get { return this.seats; } }
        public Booking(int id, Client client, DateTime datetime,int amount, decimal totalprice, List<Ticket> tickets, List<Seat> seats)
        {
            this.id = id;
            this.client = client;
            this.datetime = datetime;
            this.amount = amount;
            this.totalprice = totalprice;
            this.tickets = tickets;
            this.seats = seats;
        }
        public void CalcTotalPrice()
        {
            //seatsbooked.ForEach(seat => totalprice += seat.Price);
        }
    }
}
