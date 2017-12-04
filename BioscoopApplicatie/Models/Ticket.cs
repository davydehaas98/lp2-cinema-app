using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Ticket
    {
        private int id;
        private string name;
        private decimal price;
        public int ID { get { return this.id; } }
        public string Name { get { return this.name; } }
        public decimal Price { get { return this.price; } }
        public Ticket(int id, string name, decimal price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }
    }
}
