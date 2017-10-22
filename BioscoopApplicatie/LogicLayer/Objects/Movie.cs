using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Movie
    {
        private int id;
        private string name;
        private string type;
        private int length;
        private int minimalage;
        private List<Genre> genres;
        public int Id { get { return this.id; } set { this.id = value; } }
        public string Name { get { return this.name; } set { this.name = value; } }
        public string Type { get { return this.type; } set { this.type = value; } }
        public int Length { get { return this.length; } set { this.length = value; } }
        public int MinimalAge { get { return this.minimalage; } set { this.minimalage = value; } }
        public List<Genre> Genres { get { return this.genres; } set { this.genres = value; } }
        public Movie(int id, string name, string type, int length, int minimalage, List<Genre> genres)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.length = length;
            this.minimalage = minimalage;
            this.genres = genres;
        }
        public void AddGenre(Genre genre)
        {
            genres.Add(genre);
        }
    }
}
