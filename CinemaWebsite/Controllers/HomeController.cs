using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CinemaWebsite.ViewModels;
using Cryptography;
using Models;
using Repository.Interfaces;
using Repository.Repositories;

namespace CinemaWebsite.Controllers
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
        [HttpGet]
        public ActionResult Index()
        {
            return View(movierepo.GetAll());
        }
        [HttpGet]
        public ActionResult Movies()
        {
            return View(movierepo.GetAll());
        }
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel vm)
        {
            if (ModelState.IsValid && bookingrepo.CheckIfEmailExists(vm.Username))
            {
                Client client = bookingrepo.GetClientByEmail(vm.Username);
                if (Crypto.GenerateHash(vm.Password, client.Salt) == client.Password)
                {
                    FormsAuthentication.SetAuthCookie(vm.Username, false);
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "The username or password is incorrect");
            return View(vm);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (!bookingrepo.CheckIfEmailExists(vm.Email))
                {
                    FormsAuthentication.SignOut();
                    bookingrepo.InsertClient(vm.FirstName, vm.LastName, vm.Email, vm.Birthday, vm.Gender, vm.Password);
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "This email is already being used");
                    return View(vm);
                }
            }
            return View(vm);
        }
        [HttpGet]
        public ActionResult Movie(int? movieid)
        {
            try { return View(new MovieWithEventsViewModel(movierepo.GetByID((int)movieid),eventrepo.GetEventsByMovie((int)movieid))); }
            catch { return RedirectToAction("Movies", "Home"); }
        }
        [HttpGet]
        public ActionResult Book(int? eventid)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                try { return View(new BookingViewModel(eventrepo.GetByID((int)eventid), eventrepo.GetBookedSeatsByEvent((int)eventid), bookingrepo.GetTickets())); }
                catch { return RedirectToAction("Index", "Home"); }
            }
            return RedirectToAction("Login", "Home");
        }
        [HttpPost]
        public ActionResult Book(BookingViewModel vm)
        {
            if (ModelState.IsValid)
            {

            }
            return View(vm);
        }
    }
}