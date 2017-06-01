using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoldIt.Models
{
    public class Event
    {
        public Event(String addr, String state, String cntr, String title, String descr, DateTime time)
        {
            this.location = new Location(addr, state, cntr);
            this.title = title;
            this.description = descr;
            this.datetime = time;
        }
        private Location location { get; }
        private String title { get; }
        private String description { set; get; }
        private DateTime datetime { get; }
    }
}