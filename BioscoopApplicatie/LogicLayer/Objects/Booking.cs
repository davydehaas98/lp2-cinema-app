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
        private string name;
        private Event event_;
        private int[][] seatsbooked;
        private int totalprice;

        public int Id { get { return this.id; } set { this.id = value; } }
        public string Name { get { return this.name; } set { this.name = value; } }
        public Event Event_ { get { return this.event_; } set { this.event_ = value; } }
        public int[][] SeatsBooked { get { return this.seatsbooked; } set { this.seatsbooked = value; } }
        public int TotalPrice { get { return this.totalprice; } set { this.totalprice = value; } }
        public Booking(int id,  string name, Event event_ ,int amountseats,int totalprice, int[][] seatsbooked)
        {
            this.id = id;
            this.name = name;
            this.event_ = event_;
            this.seatsbooked = seatsbooked;
            this.totalprice = totalprice;
        }
    }
}
