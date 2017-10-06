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
        private CinemaLogic cinemadata;
        private List<Cinema> cinemas;
        public List<Cinema> Cinemas
        {
            get { return this.cinemas; }
            set { this.cinemas = value; }
        }
        public CinemaLogic()
        {
            //cinemadata = new CinemaData();
        }
    }
}
