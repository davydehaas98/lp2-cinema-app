using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Booking
    {
        string name;
        Event event_;
        int[][] seatsbooked;
        int totalprice;
        public string Name { get { return this.name; } set { this.name = value; } }
        public Event Event_ { get { return this.event_; } set { this.event_ = value; } }
        public int[][] SeatsBooked { get { return this.seatsbooked; } set { this.seatsbooked = value; } }
        public int TotalPrice { get { return this.totalprice; } set { this.totalprice = value; } }
        public Booking(string name, Event event_ ,int amountseats,int totalprice, int[][] seatsbooked)
        {
            this.name = name;
            this.event_ = event_;
            this.seatsbooked = seatsbooked;
            this.totalprice = totalprice;
        }
    }
}
