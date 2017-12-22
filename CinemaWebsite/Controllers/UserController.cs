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
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public ActionResult Bookings()
        {
            try { return View(eventrepo.GetAll()); }
            catch { return RedirectToAction("Index", "Home"); }
        }
        [Authorize]
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
    }
}