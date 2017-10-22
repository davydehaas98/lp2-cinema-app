using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class MovieTheatre
    {
        private int id;
        private string name;
        private string adress;
        private string city;
        private List<Cinema> cinemas;
        public int Id { get { return this.id; } set { this.id = value; } }
        public string Name { get { return this.name; } set { this.name = value; } }
        public string Adress { get { return this.adress; } set { this.adress = value; } }
        public string City { get { return this.city; } set { this.city = value; } }
        public List<Cinema> Cinemas { get { return this.cinemas; } set { this.cinemas = value; } }
        public MovieTheatre(int id, string name, string adress, string city)
        {
            this.id = id;
            this.name = name;
            this.adress = adress;
            this.city = city;
        }

        public void AddCinema(Cinema c)
        {
            cinemas.Add(c);
        }
    }
}
