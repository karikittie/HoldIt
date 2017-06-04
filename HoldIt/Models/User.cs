using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HoldIt.Models
{
    public class User
    {
        public int UserID { get; set; }
        public String email { get; set; }
        public String name { get; set; }
        public String password { get; set; }
        public List<int> reviewIDs { get; set; }
    }
}