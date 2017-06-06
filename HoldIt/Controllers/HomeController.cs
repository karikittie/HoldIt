using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoldIt.Models;

namespace HoldIt.Controllers
{
    /// <summary>
    /// HomeController: ( ADD DESCRIPTION ).
    /// Inherits from Controller
    /// </summary>
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            MakeListings();

            MakeUsers();

            return View();
        }

        /// <summary>
        /// Creates example users
        /// </summary>
        private void MakeUsers()
        {
            if (Session["UserList"] == null)
            {
                List<User> uList = new List<User>();

                uList.Add(new User("adrianO@hotmail.com", "Adrian O'dowell", "mypasswordispassword"));
                uList.Add(new User("cornisnice@gmail.com", "Donisha Landes", "x9edj3#dx_corn"));
                uList.Add(new User("candlesticks@fancies.gov", "Alaska Rainwaters", "Quin0a"));
                uList.Add(new User("SBeticale@beticalephotos.com", "Shantrace Beticale", "cannon20d"));

                Session["UserList"] = uList;
            }
        }
        /// <summary>
        /// Creates example listings
        /// </summary>
        private void MakeListings()
        {
            if (Session["ListingList"] == null)
            {
                List<Listing> lList = new List<Listing>();

                lList.Add(new Listing(0, new DateTime(2089, 11, 16), 15.25, 0, -1, "iPad Pro Release", "Release event for the new iPad pro. Secure your spot!", "450 SW Yamhill St, Portland, OR 97204", false));
                lList.Add(new Listing(1, new DateTime(2018, 12, 24), 15.25, 1, -1, "Frank Ocean Concert", "Be one of the first ine line to see Frank Ocean at the Moda Center.", "1 N Center Ct St, Portland, OR 97227", false));
                lList.Add(new Listing(2, new DateTime(2017, 7, 4), 15.25, 0, 2, "BrewFest in the Park", "Legendary craft brew festival at the Overlook park. Get in before it fills up.", "1599 N Fremont St, Portland, OR 97227", true));
                lList.Add(new Listing(3, new DateTime(2017, 6, 7), 15.25, 3, -1, "Friday Dinner at Tasty n Alder", "Reservations are limited; make sure to secure your dinner plans!", "580 SW 12th Ave, Portland, OR 97205", false));

                Session["ListingList"] = lList;
            }
        }
        /// <returns>
        /// Returns a view containing User information
        /// </returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        /// <returns>
        /// Returns a view containing User contacts
        /// </returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        /// <summary>
        /// Searches active listings for provided keyword
        /// </summary>
        /// <param name="search"></param>
        /// <returns>
        /// Returns a view containing matching listing(s).
        /// </returns>
        public ActionResult SearchListing(String search)
        {
            List<Listing> listings = (List<Listing>) Session["ListingList"];
            List<Listing> searchedList = new List<Listing>();
            search = search.ToLower();
            foreach (Listing listing in listings)
            {
                if (listing.customerID >= 0) continue;
                if (listing.title.ToLower().Contains(search))
                    searchedList.Add(listing);
                else if (listing.description.ToLower().Contains(search))
                    searchedList.Add(listing);
                else if (listing.location.ToLower().Contains(search))
                    searchedList.Add(listing);
            }


            return View(searchedList);
        }
        /// <returns>
        /// Returns a view containing active listings
        /// </returns>
        public ActionResult ListingList()
        {
            if (Session["ListingList"] != null)
                return View((List<Listing>)Session["ListingList"]);
            else
                return Redirect("/Home/Index");
        }

    }
    
}