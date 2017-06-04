using System;
using System.Collections;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HoldIt.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> users { get; set; }
    }

    public class User
    {
        public User(String email, String name, int id)
        {
            this.email = email;
            this.name = name;
            this.userID = id;
        }
        public String email { get; set; }
        public String name { get; set; }
        public int userID { get; set; }
        public SortedList reviews { get; set; }
    }
}