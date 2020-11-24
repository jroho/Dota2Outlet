using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Outlet.Models
{
    public class User
    {
        public int ID { get; set; }
        public string SteamID { get; set; }
        public int Steam64ID { get; set; }
        public string CustomURL { get; set; }
        public int UserTypeID { get; set; }

        //public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}