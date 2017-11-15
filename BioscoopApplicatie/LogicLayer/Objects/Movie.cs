using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace LogicLayer
{
    public class Movie
    {
        private int id;
        private string name;
        private string type;
        private int length;
        private int minimalage;
        private ImageSource image;
        private DateTime releasedate;
        private List<Genre> genres;
        public int Id { get { return this.id; } }
        public string Name { get { return this.name; } }
        public string Type { get { return this.type; } }
        public int Length { get { return this.length; } }
        public int MinimalAge { get { return this.minimalage; } }
        public ImageSource Image { get { return this.image; } }
        public List<Genre> Genres { get { return this.genres; } }
        public DateTime ReleaseDate { get { return this.releasedate; } }
        public Movie(int id, string name, string type, int length, int minimalage, DateTime releasedate, ImageSource image, List<Genre> genres)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.length = length;
            this.minimalage = minimalage;
            this.releasedate = releasedate;
            this.image = image;
            this.genres = genres;
        }
        public string GetInfo()
        {
            return $" Title: {name} {Environment.NewLine} Length: {length} min {Environment.NewLine} Minimal Age: {minimalage} {Environment.NewLine} Released: {releasedate.ToString("dd MMMM yyyy")}";
        }
        public override string ToString()
        {
            return $"{name}";
        }
    }
}
