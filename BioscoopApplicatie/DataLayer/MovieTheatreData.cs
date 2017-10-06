using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class MovieTheatreData : DataAccess
    {
        public MovieTheatreData()
        {

        }
        public DataTable GetMovieTheatres()
        {
            string query = "SELECT * FROM [MovieTheatres]";
            DataTable result = ExecSelectQuery(query);
            return result;
        }

    }
}
