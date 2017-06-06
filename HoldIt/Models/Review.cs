using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HoldIt.Models
{
    /// <summary>
    /// Review: A customer review of their interaction with a provider.
    /// </summary>
    public class Review
    {
        // ADD: Associated Provider ID?
        // ADD: Associated Listing ID? (Check for confirmed listing as a class invariant?)
        public int ReviewID { get; set; }
        public int customerID { get; set;  }
        public String title { get; set;  }
        public String comment { get; set;  }
        public int rating { get; set; }
    }
}