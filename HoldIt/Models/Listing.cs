using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HoldIt.Models
{
    public class Listing
    {
        public int ListingID { get; set; }
        public DateTime datetime { get; set; }
        public double cost { get; set; }
        public int providerID { get; set; }
        public int customerID { set; get; }
        public String title { set; get; }
        public String description { set; get; }
        public Location location { set; get; }
    }
}