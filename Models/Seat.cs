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
        public int Id { get { return this.id; } }
        public int Row { get { return row; } }
        public int Number { get { return number; } }
        public Seat(int id, int row, int number)
        {
            this.id = id;
            this.row = row;
            this.number = number;
        }
    }
}
