using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Models;
using Repository.Interfaces;
using Repository.Repositories;

namespace CinemaApplication.Controllers
{
    public class HomeController : Controller
    {
        private IBookingRepository bookingrepo;
        private ICinemaRepository cinemarepo;
        private IEventRepository eventrepo;
        private IMovieRepository movierepo;
        public HomeController() : this(new BookingRepository(), new CinemaRepository(), new EventRepository(), new MovieRepository()) { }
        public HomeController(IBookingRepository bookingrepo, ICinemaRepository cinemarepo, IEventRepository eventrepo, IMovieRepository movierepo)
        {
            this.bookingrepo = bookingrepo;
            this.cinemarepo = cinemarepo;
            this.eventrepo = eventrepo;
            this.movierepo = movierepo;
        }
        public ActionResult Index()
        {
            return View(eventrepo.GetAll().ToList());
        }
        public ActionResult Booking()
        {
            ViewBag.Message = "Your application booking page.";
            return View(bookingrepo.GetAll().ToList());
        }
        public ActionResult Movies()
        {
            ViewBag.Message = "Your application movies page.";
            return View(movierepo.GetAll().ToList());
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}