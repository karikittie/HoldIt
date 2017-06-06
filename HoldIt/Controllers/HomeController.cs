using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoldIt.Models;

namespace HoldIt.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            MakeListings();

            MakeUsers();

            return View();
        }

        //TODO fill in better information
        private void MakeUsers()
        {
            if (Session["UserList"] == null)
            {
                List<User> uList = new List<User>();

                uList.Add(new User("a@a.com", "Alpah Betical", "aaaa"));
                uList.Add(new User("b@b.com", "Beta  Betical", "bbbb"));
                uList.Add(new User("c@c.com", "Gamma Betical", "cccc"));
                uList.Add(new User("d@d.com", "Delta Betical", "dddd"));

                Session["UserList"] = uList;
            }
        }
        //TODO fill in better information
        private void MakeListings()
        {
            if (Session["ListingList"] == null)
            {
                List<Listing> lList = new List<Listing>();

                lList.Add(new Listing(0, new DateTime(2089, 11, 16), 15.25, 0, -1, "Title0", "Desc0", "Add0", false));
                lList.Add(new Listing(1, new DateTime(2018, 12, 24), 15.25, 1, -1, "Title1", "Desc1", "Add1",false));
                lList.Add(new Listing(2, new DateTime(2017, 7, 4), 15.25, 0, 2, "Title2", "Desc2", "Add2", true));
                lList.Add(new Listing(3, new DateTime(2017, 6, 7), 15.25, 3, -1, "Title3", "Desc3", "Add3",false));

                Session["ListingList"] = lList;
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

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

        public ActionResult ListingList()
        {
            if (Session["ListingList"] != null)
                return View((List<Listing>)Session["ListingList"]);
            else
                return Redirect("/Home/Index");
        }

    }
    
}