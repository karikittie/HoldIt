using System;
using System.Collections;
using System.Linq;
using System.Web;

namespace HoldIt.Models
{
    public class User
    {
        public User(String email, String name, int id)
        {
            this.email = email;
            this.name = name;
            this.userID = id;
        }
        public String email;
        private String name;
        private int userID;
        private SortedList reviews;
    }
}