using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;

namespace LogicLayer
{
    public class BookingLogic
    {
        private Booking booking;
        private BookingData bookingdata;
        private List<Booking> bookings;
        public List<Booking> Bookings
        {
            get { return this.bookings; }
            set { this.bookings = value; }
        }
        public BookingLogic()
        {
            bookingdata = new BookingData();
        }
    }
}
