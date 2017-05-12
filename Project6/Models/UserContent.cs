using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project6.Models
{
    public class UserContent
    {
        [Key, Column(Order = 0)]
        public int ApplicationUserID { get; set; }

        [Key, Column(Order = 1)]
        public int ContentID { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Content Content { get; set; }
    }
}