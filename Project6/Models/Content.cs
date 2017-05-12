using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project6.Models
{
    public class Content
    {
        public int ContentID { get; set; }
        public string Note { get; set; }
        public string Reference { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}