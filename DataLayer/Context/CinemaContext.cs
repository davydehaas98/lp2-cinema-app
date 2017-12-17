using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Models;
using Context.Interfaces;

namespace Context.Context
{
    public class CinemaContext : ICinemaContext
    {
        private DataAccess db;
        public CinemaContext()
        {
            db = new DataAccess();
        }

        public IQueryable<Cinema> GetAll()
        {
            return ObjectBuilder.CreateCinemaList(db.ExecStoredProcedure("[GetCinemas]").Tables[0]);
        }
        public Cinema GetByID(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@id", SqlDbType.Int) { Value = id });
            return ObjectBuilder.CreateCinema(db.ExecStoredProcedure("[GetCinemaByID]", pars).Tables[0].Rows[0]);
        }
        public IQueryable<MovieTheatre> GetMovieTheatres()
        {
            return ObjectBuilder.CreateMovieTheatreList(db.ExecStoredProcedure("[GetMovieTheatres]").Tables[0]);
        }
        public MovieTheatre GetMovieTheatreByID(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@id", SqlDbType.Int) { Value = id });
            return ObjectBuilder.CreateMovieTheatre(db.ExecStoredProcedure("[GetMovieTheatreByID]", pars).Tables[0].Rows[0]);
        }
        public IQueryable<Cinema> GetCinemasByMovieTheatre(int movietheatreid)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@movietheatreid", SqlDbType.Int) { Value = movietheatreid });
            return ObjectBuilder.CreateCinemaList(db.ExecStoredProcedure("[GetCinemasByMovieTheatre]", pars).Tables[0]);
        }
    }
}
