using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoldIt.Models;
using System.Web.Security;

namespace HoldIt.Controllers
{
    public class UserController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(String email, String password)
        {
            if(validUser(email, password))
            {
                FormsAuthentication.SetAuthCookie(email, false);
                return Redirect("/User/Index");
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
        }

        private bool validUser(String email, String password)
        {
            // DO DATABASE VALIDATION HERE
            return true;
        }
    }
}