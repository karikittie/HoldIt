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
        // This is the virtualized object containing all users from the DB
        private DBContext context = new DBContext();

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
                Session["userIsAuthenticated"] = true;
                return Redirect("/User/Index");
            }
            TempData["ErrorAlert"] = "Could not validate your credentials";
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["userIsAuthenticated"] = false;
            return Redirect("/Home/Index");
        }

        [HttpPost]
        public ActionResult Signup(String email, String name, String password, String passwordConfirm)
        {
            if(!password.Equals(passwordConfirm))
            {
                TempData["ErrorAlert"] = "Password and password confirmation do not match";
                return Redirect("/Home/Index");
            }
            User newuser = new User();
            newuser.email = email;
            newuser.name = name;
            newuser.password = password;
            context.users.Add(newuser); // Add new user to local context
            context.SaveChangesAsync(); // Migrate context to DB
            FormsAuthentication.SetAuthCookie(email, false);
            Session["userIsAuthenticated"] = true;
            return Redirect("/User/Index");
        }

        private bool validUser(String email, String password)
        {
            // Finds a given user from the DB and checks password
            User foundUser;
            try
            {
                foundUser = (User)context.users.Where(user => user.email == email).Single();
            } catch(Exception e) { return false; }
            if (foundUser.password == password) return true;
            return false;
        }
    }
}