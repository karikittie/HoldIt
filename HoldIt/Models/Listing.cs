using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HoldIt.Models
{
    public class Listing
    {
        public Listing(int listingId, DateTime datetime, double cost, int providerId, int customerId, string title,
            string description, String location)
        {
            if (title == null) throw new ArgumentNullException(nameof(title));
            if (description == null) throw new ArgumentNullException(nameof(description));
            if (location == null) throw new ArgumentNullException(nameof(location));
            ListingID = listingId;
            this.datetime = datetime;
            this.cost = cost;
            providerID = providerId;
            customerID = customerId;
            this.title = title;
            this.description = description;
            this.location = location;
            this.confirmedBooking = false;
        }

        public Listing(int listingId, DateTime datetime, double cost, int providerId, int customerId, string title,
            string description, String location, bool b)
        {
            if (title == null) throw new ArgumentNullException(nameof(title));
            if (description == null) throw new ArgumentNullException(nameof(description));
            if (location == null) throw new ArgumentNullException(nameof(location));
            ListingID = listingId;
            this.datetime = datetime;
            this.cost = cost;
            providerID = providerId;
            customerID = customerId;
            this.title = title;
            this.description = description;
            this.location = location;
            this.confirmedBooking = b;
        }

        public Listing()
        {

            providerID = -1;
            customerID = -1;
            this.confirmedBooking = false;
        }

        public int ListingID { get; set; }
        public DateTime datetime { get; set; }
        public double cost { get; set; }
        public int providerID { get; set; }
        public int customerID { set; get; }
        public String title { set; get; }
        public String description { set; get; }
        public String location { set; get; }
        public bool confirmedBooking { set; get; }

    }
}
