﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace COMP4900Project.Models
{
    public class UserGroup
    {
        public UserGroup()
        {

        }

        public UserGroup(string userid, int groupid)
        {
            UserId = userid;
            GroupId = groupid;
        }

        public int UserGroupId { get; set; }

        public string UserId { get; set; }
        public int GroupId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public virtual Group Group { get; set; }
    }
}