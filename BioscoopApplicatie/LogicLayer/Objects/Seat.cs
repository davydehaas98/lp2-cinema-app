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
        private int row;
        private int number;
        private decimal price;
        private bool booked;
        public int Id { get { return this.id; } set { this.id = value; } }
        public int Row { get { return this.row; } set { this.row = value; } }
        public int Number { get { return this.number; } set { this.number = value; } }
        public decimal Price { get { return this.price; } set { this.price = value; } }
        public bool Booked { get { return this.booked; } set { this.booked = value; } }
        public Seat(int id, int row, int number, decimal price)
        {
            this.id = id;
            this.row = row;
            this.number = number;
            this.price = price;
            this.booked = false;
        }
    }
}
