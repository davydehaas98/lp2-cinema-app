using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class MovieTheatre
    {
        private string name;
        private string adress;
        private string city;
        private List<Cinema> cinemas;
        public string Name { get { return this.name; } set { this.name = value; } }
        public string Adress { get { return this.adress; } set { this.adress = value; } }
        public string City { get { return this.city; } set { this.city = value; } }
        public List<Cinema> Cinemas { get { return this.cinemas; } set { this.cinemas = value; } }
        public MovieTheatre(string name, string adress, string city, List<Cinema> cinemas)
        {
            this.name = name;
            this.adress = adress;
            this.city = city;
            this.cinemas = cinemas;
        }

        //public void AddCinema(Cinema c)
        //{
        //    Cinemas.Add(c);
        //}
    }
}
