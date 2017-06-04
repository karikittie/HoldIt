using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HoldIt.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public double latitude { get; set;  }
        public double longitude { get; set;  }
        public String address { get; set; }
        public String state { get; set; }
        public String country { get; set; }
    }
}