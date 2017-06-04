using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HoldIt.Models
{
    public class DBContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<Listing> listings { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<Location> locations { get; set; }
    }
}