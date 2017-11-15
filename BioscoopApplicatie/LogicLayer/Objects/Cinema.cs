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
        private bool D3;
        private List<Seat> seats;
        public int Id { get { return this.id; } set { this.id = value; } }
        public int MovieTheatreID { get { return this.movietheatreid; } set { this.movietheatreid = value; } }
        public int Name { get { return this.name; } set { this.name = value; } }
        public bool IMAX { get { return this.D3; } set { this.D3 = value; } }
        public List<Seat> Seats { get { return this.seats; } set { this.seats = value; } }
        public Cinema(int id,int movietheatreid, int name, bool D3)
        {
            this.id = id;
            this.movietheatreid = movietheatreid;
            this.name = name;
            this.D3 = D3;
        }
        public string GetInfo()
        {
            return $"Screen: {name} - 3D {D3}"; ;
        }
        public override string ToString()
        {
            return $"{name}"; 
        }
    }
}
