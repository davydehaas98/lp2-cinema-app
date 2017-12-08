using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models;
using Context.Interfaces;

namespace Context.Context
{
    public class CinemaContext : ICinemaContext
    {
        DataAccess db;
        public CinemaContext()
        {
            db = new DataAccess();
        }

        public IQueryable<Cinema> GetAll()
        {
            string query = "SELECT * FROM [Cinema]";
            return ObjectBuilder.CreateCinemaList(db.ExecSelectQuery(query));
        }
        public Cinema GetByID(int id)
        {
            string query = "SELECT * FROM [Cinema] WHERE id = @id";
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@id", SqlDbType.Int) { Value = id });
            return ObjectBuilder.CreateCinema(db.ExecSelectQuery(query, pars).Rows[0]);
        }
        public IQueryable<MovieTheatre> GetMovieTheatres()
        {
            string query = "SELECT * FROM [MovieTheatre]";
            return ObjectBuilder.CreateMovieTheatreList(db.ExecSelectQuery(query));
        }
        public IQueryable<MovieTheatre> GetMovieTheatresByType(bool d3)
        {
            string query = "SELECT Distinct MovieTheatre.* FROM [MovieTheatre] INNER JOIN [Cinema] ON [MovieTheatre].id = [Cinema].MovietheatreID WHERE EXISTS (SELECT * FROM [MovieTheatre] WHERE D3 = @d3)";
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@d3", SqlDbType.Bit) { Value = d3 });
            return ObjectBuilder.CreateMovieTheatreList(db.ExecSelectQuery(query, pars));
        }
        public IQueryable<Cinema> GetCinemas(int movietheatreid)
        {
            string query = "SELECT * FROM [Cinema] WHERE MovieTheatreID = @movietheatreid";
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@movietheatreid", SqlDbType.Int) { Value = movietheatreid });
            return ObjectBuilder.CreateCinemaList(db.ExecSelectQuery(query, pars));
        }
    }
}
