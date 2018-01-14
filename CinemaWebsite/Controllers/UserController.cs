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
    public class UserController : Controller
    {
        private IBookingRepository bookingrepo;
        private ICinemaRepository cinemarepo;
        private IEventRepository eventrepo;
        private IMovieRepository movierepo;
        public UserController() : this(new BookingRepository(), new CinemaRepository(), new EventRepository(), new MovieRepository()) { }
        public UserController(IBookingRepository bookingrepo, ICinemaRepository cinemarepo, IEventRepository eventrepo, IMovieRepository movierepo)
        {
            this.bookingrepo = bookingrepo;
            this.cinemarepo = cinemarepo;
            this.eventrepo = eventrepo;
            this.movierepo = movierepo;
        }
        [Authorize]
        [HttpGet]
        public ActionResult Bookings()
        {
            try { return View(eventrepo.GetAll()); }
            catch { return RedirectToAction("Index", "Home"); }
        }
        [Authorize]
        [HttpGet]
        public new ActionResult Profile()
        {
            return View(bookingrepo.GetClientByEmail(HttpContext.User.Identity.Name));
        }
        [Authorize]
        [HttpGet]
        public ActionResult Edit()
        {
            return View(new EditProfileViewModel(bookingrepo.GetClientByEmail(HttpContext.User.Identity.Name)));
        }
        [Authorize]
        [HttpPost]
        public ActionResult Edit(EditProfileViewModel vm)
        {
            if (ModelState.IsValid && vm.Id == bookingrepo.GetClientByEmail(HttpContext.User.Identity.Name).Id)
            {
                if (!bookingrepo.CheckIfEmailExists(vm.Email) || bookingrepo.GetClientByID(vm.Id).Email == vm.Email)
                {
                    bookingrepo.UpdateClient(vm.Id, vm.FirstName, vm.LastName, vm.Email, vm.Birthday, vm.Gender);
                    FormsAuthentication.SetAuthCookie(vm.Email, false);
                    return RedirectToAction("Profile", "User");
                }
                else
                {
                    ModelState.AddModelError("", "The email you filled in is already being used");
                    return View(vm);
                }
            }
            return View(vm);
        }
        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        [HttpGet]
        public ActionResult Booking(int? bookingid)
        {
            try { return View(bookingrepo.GetByID((int)bookingid)); }
            catch { return RedirectToAction("Index", "Home"); }
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
            int empty = 0;
            foreach(int amount in vm.OrderedTickets.Values)
            {
                if (amount == 0) empty++;
            }
            if(empty == vm.OrderedTickets.Count)
            {
                ModelState.AddModelError(string.Empty, "Select the amount of Tickets");
                return View(new BookingViewModel(eventrepo.GetByID(vm.eventid), eventrepo.GetBookedSeatsByEvent(vm.eventid), bookingrepo.GetTickets()));
            }
            if(vm.OrderedSeat == null)
            {
                ModelState.AddModelError(string.Empty, "Select the Seats");
                return View(new BookingViewModel(eventrepo.GetByID(vm.eventid), eventrepo.GetBookedSeatsByEvent(vm.eventid), bookingrepo.GetTickets()));
            }
            if (ModelState.IsValid)
            {
                List<int> orderedticketsid = new List<int>();
                List<int> orderedseatsid = new List<int>();
                string[] rownumber = (vm.OrderedSeat.Split('-'));
                int firstseatid = bookingrepo.GetSeats().First(s => s.Row.ToString() == rownumber[0] && s.Number.ToString() == rownumber[1]).Id;
                foreach(KeyValuePair<int, int> ticket in vm.OrderedTickets)
                {
                    for (int i = 0; i < ticket.Value; i++)
                    {
                        orderedticketsid.Add(ticket.Key);
                        orderedseatsid.Add(firstseatid);
                        firstseatid++;
                    }
                }
                bookingrepo.InsertBooking(bookingrepo.GetClientByEmail(HttpContext.User.Identity.Name).Id, 0, 0, orderedticketsid, vm.eventid, orderedseatsid);
            }
            return RedirectToAction("Bookings", "User");
        }
    }
}