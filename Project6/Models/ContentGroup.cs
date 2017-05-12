using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project6.Models
{
    public class ContentGroup
    {
        [Key, Column(Order = 0)]
        public int ContentID { get; set; }

        [Key, Column(Order = 1)]
        public int GroupID { get; set; }

        public virtual Content Content { get; set; }
        public virtual Group Group { get; set; }
    }
}