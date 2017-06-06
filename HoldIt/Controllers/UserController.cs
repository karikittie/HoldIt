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
    /// <summary>
    /// UserController: Controller for User operations
    /// Inherits from Controller
    /// </summary>
    public class UserController : global::System.Web.Mvc.Controller
    {
       
        /// <remarks>
        /// This is the virtualized object containing all users from the DB 
        /// </remarks>
        [global::System.Web.Mvc.Authorize]
        public global::System.Web.Mvc.ActionResult Index()
        {
            return View();
        }

        public global::System.Web.Mvc.ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Attempts to log a User into the system.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>
        /// Success: Returns a view with User home screen
        /// Failure: Returns Redirect to /User/Index
        /// </returns>
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

        /// <summary>
        /// Logs a User out of the system
        /// </summary>
        /// <returns>
        /// Returns Redirect to /Home/Index
        /// </returns>
        public global::System.Web.Mvc.ActionResult Logout()
        {
            global::System.Web.Security.FormsAuthentication.SignOut();
            Session["userIsAuthenticated"] = false;
            Session["ActiveUser"] = null;

            return Redirect("/Home/Index");
        }

        /// <summary>
        /// Signs up a new User in the System
        /// </summary>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="passwordConfirm"></param>
        /// <returns>
        /// Success: returns Redirect to /User/Index
        /// Failure: returns Redirect to /Home/Index
        /// </returns>
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
            Session["ActiveUser"] = newuser;


            return Redirect("/User/Index");
        }

        /// <summary>
        /// Checks if a user with 'email' and 'password' exists in the database.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>
        /// Returns true on success, false on failure
        /// </returns>
        private bool validUser(System.String email, String password)
        {

            List<User> uList = ((List<User>) Session["UserList"]);

            /// <remarks>
            /// Finds a given user from the DB and checks password
            /// </remarks>
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
        /// <summary>
        /// Given a listing ID, Books a listing for a User.
        /// </summary>
        /// <param name="first"></param>
        /// <returns>
        /// Returns Redirect to /User/Index
        /// </returns>
        public global::System.Web.Mvc.ActionResult Book(int? first)
        {
            if (first != null)
            {
                int listID = (int)first;
                //Int32.TryParse(id, out listID);
                Listing list;

                var t = TempData;
                list = ((List<Listing>)Session["ListingList"]).Find((Listing l) => l.ListingID == listID);
                //TODO check for provider == Customer
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
            }


            return Redirect("/User/Index");
        }
        /// <summary>
        /// Given a Listing ID, Confirms a listing as completed
        /// </summary>
        /// <param name="first"></param>
        /// <returns>
        /// Returns redirect to /User/Index
        /// </returns>
        public ActionResult Confirm(int first)
        {
            Listing list;

            list = ((List<Listing>)Session["ListingList"]).Find((Listing l) => l.ListingID == first);
            if ((list != null) && (list.providerID == first))
            {
                List<Listing> tempList = (List<Listing>)Session["ListingList"];
                int pos = tempList.FindIndex(list.Equals);
                list.confirmed = true;

                tempList[pos] = list;
                Session["ListingList"] = tempList;

            }
            else
            {
                throw new SystemException("ID");

            }
            return Redirect("/User/Index");

        }

        //TODO
        public ActionResult CreateListing(  )
        {



            return View();
        }

        /// <summary>
        /// Creates listing
        /// </summary>
        /// <param name="lList"></param>
        /// <returns>
        /// Returns a redirect to /User/Index
        /// </returns>
        [HttpPost]
        public ActionResult Create(Listing lList)
        {
            int first = 1;
            Listing list;

            list = ((List<Listing>)Session["ListingList"]).Find((Listing l) => l.ListingID == first);
            if ((list != null) && (list.providerID == first))
            {
                List<Listing> tempList = (List<Listing>)Session["ListingList"];
                int pos = tempList.FindIndex(list.Equals);
                list.confirmed = true;

                tempList[pos] = list;
                Session["ListingList"] = tempList;

            }
            else
            {
                throw new SystemException("ID");

            }
            return Redirect("/User/Index");


        }

        [HttpPost]
        public ActionResult MakeListing( Listing list )
        {

            list.providerID = ((User) Session["ActiveUser"]).UserID;
            list.customerID = -1;
            list.confirmed = false;

            List<Listing> listing;

            listing = ((List<Listing>) Session["ListingList"]);

            listing.Add(list);

            Session["ListingList"] = listing; 


            return Redirect("Index");
        }
    }
}