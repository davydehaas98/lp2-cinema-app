﻿using System;
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
        public int Id { get { return this.id; } }
        public string Name { get { return this.name; } }
        public string Address { get { return this.address; } }
        public string City { get { return this.city; } }
        public List<Cinema> Cinemas { get { return this.cinemas; } }
        public MovieTheatre(int id, string name, string address, string postalcode, string city, List<Cinema> cinemas)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.postalcode = postalcode;
            this.city = city;
            this.cinemas = cinemas;
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
