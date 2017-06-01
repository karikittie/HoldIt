using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoldIt.Models
{
    public class Review
    {
        private int customerID { get; }
        private String title { get; }
        private String comment { get; }
        private int rating { get; }
    }
}