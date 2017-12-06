﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repository.Interfaces
{
    public interface IEventRepository
    {
        List<Event> GetAll();
        Event GetEvent(int idevent);
        List<Seat> GetSeats(int idevent);
        void InsertEvent(DateTime datetime, int idcinema, int idmovie);
    }
}