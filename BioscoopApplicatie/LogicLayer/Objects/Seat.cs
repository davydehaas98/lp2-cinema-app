using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Seat
    {
        
        private int number;
        private int price;
        private bool booked;
        public int Number { get { return this.number; } set { this.number = value; } }
        public int Price { get { return this.number; } set { this.price = value; } }
        public bool Booked { get { return this.booked; } set { this.booked = value; } }
        public Seat(int number, int price, bool booked)
        {
            this.number = number;
            this.price = price;
            this.booked = booked;
        }
    }
}
