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
        public ActionResult Login(User user)
        {
            if(validUser(user))
            {
                FormsAuthentication.SetAuthCookie(user.email, false);
                return Redirect("/User/Index");
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
        }

        private bool validUser(User user)
        {
            // DO VALIDATION HERE
            return true;
        }
    }
}