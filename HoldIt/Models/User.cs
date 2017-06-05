using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HoldIt.Models
{
    public class User
    {
        public User(string email, string name, string password)
        {
            if (email == null) throw new ArgumentNullException(nameof(email));
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (password == null) throw new ArgumentNullException(nameof(password));
            this.email = email;
            this.name = name;
            this.password = password;
            UserID = num++;
        }
        public User(){}

        private static int num = 0;

        public int UserID { get; set; }
        public String email { get; set; }
        public String name { get; set; }
        public String password { get; set; }
        //public List<int> reviewIDs { get; set; }
    }
}