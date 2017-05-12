using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project6.Models
{
    public class UserGroup
    {
        [Key, Column(Order = 0)]
        public string Id { get; set; }

        [Key, Column(Order = 1)]
        public int GroupID { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Group Group { get; set; }
    }
}