using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HoldIt.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int customerID { get; set;  }
        public String title { get; set;  }
        public String comment { get; set;  }
        public int rating { get; set; }
    }
}