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
            return View();
        }

        /*
         * Password should be handed off to our auth. API
         * which should give us a user ID of some sort to attach to the account
         * */
        [HttpPost]
        public ActionResult Index(String name, String email, String password, String passwordConfirm)
        {
            int id = -1;
            if(!password.Equals(passwordConfirm))
            {
                // TODO: handle error
            }
            if(id < 0)
            {
                // TODO: handle error
            }
            User newUser = new User(email, name, id);
            return View();
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
    }
}