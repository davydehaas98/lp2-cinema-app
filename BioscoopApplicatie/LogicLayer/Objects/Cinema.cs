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
        private string type;
        private List<Seat> seats;
        public int Id { get { return this.id; } set { this.id = value; } }
        public string Name { get { return this.name; } set { this.name = value; } }
        public string Type { get { return this.type; } set { this.type = value; } }
        public List<Seat> Seats { get { return this.seats; } set { this.seats = value; } }
        public Cinema(int id, string name, string type, List<Seat> seats)
        {
            this.name = name;
            this.type = type;
            this.seats = seats;
        }
    }
}
