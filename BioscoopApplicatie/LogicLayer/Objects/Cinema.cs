using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Cinema
    {
        private int id;
        private int name;
        private bool imax;
        private List<Seat> seats;
        public int Id { get { return this.id; } set { this.id = value; } }
        public int Name { get { return this.name; } set { this.name = value; } }
        public bool IMAX { get { return this.imax; } set { this.imax = value; } }
        public List<Seat> Seats { get { return this.seats; } set { this.seats = value; } }
        public Cinema(int id, int name, bool imax)
        {
            this.id = id;
            this.name = name;
            this.imax = imax;
        }
        public void AddSeat(Seat s)
        {
            seats.Add(s);
        }
        public override string ToString()
        {
            return $"{name}"; 
        }
    }
}
