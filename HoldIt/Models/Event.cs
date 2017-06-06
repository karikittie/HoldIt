using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HoldIt.Models
{
    /// <summary>
    /// Event: A HoldIt featured event.
    /// </summary>
    public class Event
    {
        public int EventID { get; set; }
        public int locationID { get; set; }
        public String title { get; set; }
        public String description { get; set; }
        public DateTime datetime { get; set; }
    }
}