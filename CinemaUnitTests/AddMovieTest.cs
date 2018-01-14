using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Repositories;

namespace CinemaUnitTests
{
    [TestClass]
    public class AddMovieTest
    {
        MovieRepository movierepo = new MovieRepository();
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "No Exception was thrown.")]
        public void AddMovieWithoutName()
        {
            string name = "";
            bool d3 = true;
            int length = 100;
            int minimumage = 2;
            DateTime releasedate = DateTime.Now;
            string image = "https://i.imgur.com/yaUGvHI.jpg";
            List<int> genreids = new List<int>() { 30, 31 };
            movierepo.InsertMovie(name, d3, length, minimumage, releasedate, image, genreids);
        }
        [TestMethod]
        [ExpectedException(typeof(OverflowException), "No Exception was thrown.")]
        public void AddMovieWithTooLongName()
        {
            string name = "12345678901234567892345678902345673456734567845675675434567876545678987654345678765434i89127894037218940732189407328194073814926531";
            bool d3 = true;
            int length = 100;
            int minimumage = 2;
            DateTime releasedate = DateTime.Now;
            string image = "https://i.imgur.com/yaUGvHI.jpg";
            List<int> genreids = new List<int>() { 30, 31 };
            movierepo.InsertMovie(name, d3, length, minimumage, releasedate, image, genreids);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "No Exception was thrown.")]
        public void AddMovieWithNegativeLength()
        {
            string name = "Interstellar";
            bool d3 = true;
            int length = -1;
            int minimumage = 2;
            DateTime releasedate = DateTime.Now;
            string image = "https://i.imgur.com/yaUGvHI.jpg";
            List<int> genreids = new List<int>() { 30, 31 };
            movierepo.InsertMovie(name, d3, length, minimumage, releasedate, image, genreids);
        }
    }
}