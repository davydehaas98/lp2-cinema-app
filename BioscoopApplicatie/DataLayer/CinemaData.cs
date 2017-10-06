﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class CinemaData : DataAccess
    {
        public CinemaData()
        {

        }
        public DataTable GetCinemas()
        {
            string query = "SELECT * FROM [Cinemas]";
            DataTable result = ExecSelectQuery(query);
            return result;
        }
        public DataTable GetCinemas(string movietheatre)
        {
            string query = "SELECT * FROM [Cinemas] WHERE MovieTheatreID = (SELECT MovieTheatreID FROM MovieTheatres WHERE MovieTheatre.Name = '@movietheatre')";
            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@movietheatre", SqlDbType.VarChar);
            pars[0].Value = movietheatre;

            DataTable result = ExecSelectQuery(query, pars);

            return result;
        }
    }
}
