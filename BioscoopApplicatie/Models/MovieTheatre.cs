using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MovieTheatre
    {
        private int id;
        private string name;
        private string address;
        private string postalcode;
        private string city;
        private List<Cinema> cinemas;
        public int Id { get { return this.id; } set { this.id = value; } }
        public string Name { get { return this.name; } set { this.name = value; } }
        public string Address { get { return this.address; } set { this.address = value; } }
        public string City { get { return this.city; } set { this.city = value; } }
        public List<Cinema> Cinemas { get { return this.cinemas; } set { this.cinemas = value; } }
        public MovieTheatre(int id, string name, string address, string postalcode, string city, List<Cinema> cinemas)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.postalcode = postalcode;
            this.city = city;
            this.cinemas = cinemas;
        }
        public MovieTheatre(int id, string name, string address, string postalcode, string city)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.postalcode = postalcode;
            this.city = city;
        }

        public void AddCinema(Cinema c)
        {
            cinemas.Add(c);
        }
        public override string ToString()
        {
            return $"{name} - {city}";
        }
    }
}
