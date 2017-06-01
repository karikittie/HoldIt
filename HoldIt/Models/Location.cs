using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoldIt.Models
{
    public class Location
    {
        public Location(String addr, String st, String cntr)
        {
            this.latitude = 0; // TODO: insert method for finding coordinates
            this.longitude = 0;
            this.address = addr;
            this.state = st;
            this.country = cntr;
        }
        private double latitude { get; }
        private double longitude { get; }
        private String address { get; }
        private String state { get; }
        private String country { get; }
    }
}