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
        private string name;
        private bool imax;
        private List<Seat> seats;
        public int Id { get { return this.id; } set { this.id = value; } }
        public string Name { get { return this.name; } set { this.name = value; } }
        public bool IMAX { get { return this.imax; } set { this.imax = value; } }
        public List<Seat> Seats { get { return this.seats; } set { this.seats = value; } }
        public Cinema(int id, string name, bool imax)
        {
            this.id = id;
            this.name = name;
            this.imax = imax;
        }
        public void AddSeat(Seat s)
        {
            seats.Add(s);
        }
    }
}
