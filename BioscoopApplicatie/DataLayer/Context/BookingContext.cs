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
    public class BookingContext : IBookingContext
    {
        DataAccess db;
        public BookingContext()
        {
            db = new DataAccess();
        }

        public IQueryable<Booking> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
