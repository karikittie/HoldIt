using System;
using System.Collections;
using System.Linq;
using System.Web;

namespace HoldIt.Models
{
    public class User
    {
        public User(String email, String name)
        {
            this.email = email;
            this.name = name;
            // TODO: add a way to generate ID from Database Schema
        }
        private String email { get; set; }
        private String name { get; set; }
        private int userID { get; }
        private SortedList reviews;
    }
}