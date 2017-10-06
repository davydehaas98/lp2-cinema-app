using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Movie
    {
        private string name;
        private string type;
        private int length;
        private int minimalage;
        public string Name { get { return this.name; } set { this.name = value; } }
        public string Type { get { return this.type; } set { this.type = value; } }
        public int Length { get { return this.length; } set { this.length = value; } }
        public int MinimalAge { get { return this.minimalage; } set { this.minimalage = value; } }
        public Movie(string name, string type, int length, int minimalage)
        {
            this.name = name;
            this.type = type;
            this.length = length;
            this.minimalage = minimalage;
        }
    }
}
