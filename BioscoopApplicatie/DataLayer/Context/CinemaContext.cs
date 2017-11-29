using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models;
using DataLayer.Interfaces;

namespace DataLayer.Context
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
            DataTable result = db.ExecSelectQuery(query);
            return ObjectBuilder.CreateCinemaList(result);
        }
        public Cinema GetCinema(int idcinema)
        {
            string query = "SELECT * FROM [Cinema] WHERE id = @idcinema";
            SqlParameter[] pars = new SqlParameter[1];
            pars[0] = new SqlParameter("@idcinema", SqlDbType.Int);
            pars[0].Value = idcinema;
            DataRow result = db.ExecSelectQuery(query, pars).Rows[0];
            return ObjectBuilder.CreateCinema(result);
        }
        public MovieTheatre GetMovieTheatre(int idcinema)
        {
            string query = "SELECT * FROM [MovieTheatre] INNER JOIN [Cinema] ON [MovieTheatre].id = [Cinema].MovietheatreID WHERE [Cinema].id = @idcinema";
            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@idcinema", SqlDbType.Int);
            pars[0].Value = idcinema;
            DataRow result = db.ExecSelectQuery(query, pars).Rows[0];
            return ObjectBuilder.CreateMovieTheatre(result);
        }
        public IQueryable<MovieTheatre> GetMovieTheatres()
        {
            string query = "SELECT * FROM [MovieTheatre]";
            DataTable result = db.ExecSelectQuery(query);
            return ObjectBuilder.CreateMovieTheatreList(result);
        }
        public IQueryable<MovieTheatre> GetMovieTheatresByType(bool d3)
        {
            string query = "SELECT Distinct MovieTheatre.* FROM [MovieTheatre] INNER JOIN [Cinema] ON [MovieTheatre].id = [Cinema].MovietheatreID WHERE EXISTS (SELECT * FROM MovieTheatre WHERE D3 = @d3)";
            SqlParameter[] pars = new SqlParameter[1];
            pars[0] = new SqlParameter("@d3", SqlDbType.Bit);
            pars[0].Value = d3;
            DataTable result = db.ExecSelectQuery(query, pars);
            return ObjectBuilder.CreateMovieTheatreList(result);
        }
        public IQueryable<Cinema> GetCinemas(int idmovietheatre)
        {
            string query = "SELECT * FROM [Cinema] WHERE MovieTheatreID = @idmovietheatre";
            SqlParameter[] pars = new SqlParameter[1];
            pars[0] = new SqlParameter("@idmovietheatre", SqlDbType.Int);
            pars[0].Value = idmovietheatre;
            DataTable result = db.ExecSelectQuery(query, pars);
            return ObjectBuilder.CreateCinemaList(result);
        }
    }
}
