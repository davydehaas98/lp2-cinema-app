using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repository.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Client GetClient(int clientid);
        List<Ticket> GetTickets(int bookingid);
        List<Seat> GetSeats(int bookingid);
        void InsertClient(string firstname, string lastname, string email, DateTime birthday, string gender, string password);
    }
}
