using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Seat
    {
        private int id;
        private int row;
        private int number;
        public int Id { get { return this.id; } set { this.id = value; } }
        public int Row { get { return this.row; } set { this.row = value; } }
        public int Number { get { return this.number; } set { this.number = value; } }
        public Seat(int id, int row, int number)
        {
            this.id = id;
            this.row = row;
            this.number = number;
        }
    }
}
