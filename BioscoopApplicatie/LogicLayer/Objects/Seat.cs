using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Seat
    {
        private int id;
        private int number;
        private int price;
        private bool booked;
        public int Id { get { return this.id; } set { this.id = value; } }
        public int Number { get { return this.number; } set { this.number = value; } }
        public int Price { get { return this.number; } set { this.price = value; } }
        public bool Booked { get { return this.booked; } set { this.booked = value; } }
        public Seat(int id, int number, int price, bool booked)
        {
            this.id = id;
            this.number = number;
            this.price = price;
            this.booked = false;
        }
    }
}
