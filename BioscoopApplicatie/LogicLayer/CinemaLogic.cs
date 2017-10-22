using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;

namespace LogicLayer
{
    public class CinemaLogic
    {
        private Cinema cinema;
        private CinemaData cinemadata;
        private List<Cinema> cinemas;
        public List<Cinema> Cinemas
        {
            get { return this.cinemas; }
            set { this.cinemas = value; }
        }
        public CinemaLogic()
        {
            cinemadata = new CinemaData();
        }
        public List<Cinema> GetCinemas()
        {
            DataTable result = cinemadata.GetCinemas();
            cinemas = new List<Cinema>();
            if (result != null)
            {
                //loop through datatable results
                foreach (DataRow row in result.Rows)
                {
                    cinema = new Cinema((int)row["id"], (string)row["name"], (bool)row["imax"]);
                    cinemas.Add(cinema);
                }
                return cinemas;
            }
            return null;
        }
    }
}
