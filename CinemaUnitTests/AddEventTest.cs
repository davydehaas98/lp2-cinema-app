using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Repositories;

namespace CinemaUnitTests
{
    [TestClass]
    public class AddEventTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "No Exception was thrown.")]
        public void AddEventWithWrongDate()
        {
            DateTime datetime = DateTime.Now.AddDays(-1);
            int idcinema = 1;
            int idmovie = 1;
            EventRepository eventrepo = new EventRepository();
            eventrepo.InsertEvent(datetime, idcinema, idmovie);
        }
    }
}
