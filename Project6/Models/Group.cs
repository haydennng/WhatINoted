using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project6.Models
{
    public class Group
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Content> Contents { get; set; }
    }
}