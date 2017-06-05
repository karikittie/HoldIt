using global::System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.EnterpriseServices;
using System.Security.Principal;
using global::System.Linq;
using global::System.Web;
using System.Web.Mvc;
using global::HoldIt.Models;
using System.Web.Security;

namespace HoldIt.Controllers
{
    public class UserController : global::System.Web.Mvc.Controller
    {
        // This is the virtualized object containing all users from the DB

        [global::System.Web.Mvc.Authorize]
        public global::System.Web.Mvc.ActionResult Index()
        {
            return View();
        }

        public global::System.Web.Mvc.ActionResult Login()
        {
            return View();
        }

        [global::System.Web.Mvc.HttpPost]
        public global::System.Web.Mvc.ActionResult Login(global::System.String email, global::System.String password)
        {
            if(validUser(email, password))
            {
                global::System.Web.Security.FormsAuthentication.SetAuthCookie(email, false);
                Session["userIsAuthenticated"] = true;
                return Redirect("/User/Index");
            }
            TempData["ErrorAlert"] = "Could not validate your credentials";
            return View();
        }

        public global::System.Web.Mvc.ActionResult Logout()
        {
            global::System.Web.Security.FormsAuthentication.SignOut();
            Session["userIsAuthenticated"] = false;
            return Redirect("/Home/Index");
        }

        [global::System.Web.Mvc.HttpPost]
        public global::System.Web.Mvc.ActionResult Signup(global::System.String email, global::System.String name, global::System.String password, global::System.String passwordConfirm)
        {
            if(!password.Equals(passwordConfirm))
            {
                TempData["ErrorAlert"] = "Password and password confirmation do not match";
                return Redirect("/Home/Index");
            }
            User newuser = new User(email,name,password);

            List<User> uList = ((List<User>) Session["UserList"]);
            uList.Add(newuser);
            Session["UserList"] = uList;


            FormsAuthentication.SetAuthCookie(email, false);
            Session["userIsAuthenticated"] = true;
            return Redirect("/User/Index");
        }


        private bool validUser(System.String email, String password)
        {
            List<User> uList = ((List<User>) Session["UserList"]);

            // Finds a given user from the DB and checks password
            global::HoldIt.Models.User foundUser;
            try
            {
                foundUser = uList.Find( u => (u.email.Equals(email)));
                Session["ActiveUser"] = foundUser;

                if (foundUser.password.Equals(password))
                {
                    return true;
                }
                return false;

            } catch(Exception e) { return false; }

            
        }

        public ActionResult Book( int listID )
        {
            Listing list;


            list = ((List<Listing>) Session["ListingList"]).Find(  (Listing l) => l.ListingID== listID);



            return View( list );
        }

    }
}