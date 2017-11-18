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
        private int movietheatreid;
        private int name;
        private bool d3;
        private List<Seat> seats;
        public int Id { get { return this.id; } set { this.id = value; } }
        public int MovieTheatreID { get { return this.movietheatreid; } set { this.movietheatreid = value; } }
        public int Name { get { return this.name; } set { this.name = value; } }
        public bool D3 { get { return this.d3; } set { this.d3 = value; } }
        public List<Seat> Seats { get { return this.seats; } set { this.seats = value; } }
        public Cinema(int id,int movietheatreid, int name, bool D3)
        {
            this.id = id;
            this.movietheatreid = movietheatreid;
            this.name = name;
            this.d3 = D3;
        }
        public string GetInfo()
        {
            return $"Screen: {name} - 3D {d3}"; ;
        }
        public override string ToString()
        {
            return $"{name}"; 
        }
    }
}
