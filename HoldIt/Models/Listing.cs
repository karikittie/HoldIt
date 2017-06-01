using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoldIt.Models
{
    public class Listing
    {
        public Listing(DateTime time, double cost, int provider, String title, String descr, String addr, String state, String cntr)
        {
            this.datetime = time;
            this.cost = cost;
            this.providerID = provider;
            this.description = descr;
            this.title = title;
            this.location = new Location(addr, state, cntr);
            this.customerID = -1;
        }
        private DateTime datetime { get; }
        private double cost { set; get; }
        private int providerID { get; }
        private int customerID { set; get; }
        private String title { set; get; }
        private String description { set; get; }
        private Location location { set; get; }
    }
}