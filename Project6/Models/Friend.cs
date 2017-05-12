using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project6.Models
{
    public class Friend
    {
        public string FriendId { get; set; }

        public string User1Id { get; set; }
        public string User2Id { get; set; }

        public virtual ApplicationUser User1 { get; set; }
        public virtual ApplicationUser User2 { get; set; }
    }
}