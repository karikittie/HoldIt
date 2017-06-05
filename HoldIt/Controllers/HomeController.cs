﻿using System;
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

        private void MakeListings()
        {
            if (Session["ListingList"] == null)
            {
                List<Listing> lList = new List<Listing>();

                lList.Add(new Listing(0, new DateTime(2089, 11, 16), 15.25, 0, 1, "Title0", "Desc0", "Add0"));
                lList.Add(new Listing(1, new DateTime(2018, 12, 24), 15.25, 1, -1, "Title1", "Desc1", "Add1"));
                lList.Add(new Listing(2, new DateTime(2017, 7, 4), 15.25, 0, 2, "Title2", "Desc2", "Add2", true));
                lList.Add(new Listing(3, new DateTime(2017, 6, 7), 15.25, 3, -1, "Title3", "Desc3", "Add3"));

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

        public ActionResult SearchListing()
        {
            throw new NotImplementedException();
        }

        public ActionResult ListingList()
        {
            if (Session["ListingList"] != null)
                return View((List<Listing>)Session["ListingList"]);
            else
                return Redirect("/Home/Index");
        }

        [HttpGet]
        public ActionResult Book(int first)
        {

            int listID= first;
            //Int32.TryParse(first, out listID);
            Listing list;

            var t = TempData;
            list = ((List<Listing>)Session["ListingList"]).Find((Listing l) => l.ListingID == listID);
            if ((list != null) && (list.customerID < 0))
            {
                List<Listing> tempList = (List<Listing>)Session["ListingList"];
                int pos = tempList.FindIndex(list.Equals);
                list.customerID = ((User)Session["ActiveUser"]).UserID;

                tempList[pos] = list;
                Session["ListingList"] = tempList;
            }
            else
            {
                throw new SystemException("ID");
                   
            }


            return Redirect("/User/Index");
        }
    }
}