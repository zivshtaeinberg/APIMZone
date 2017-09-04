using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZivBackendSystem.Models
{
    public class UserDetails
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmailAddress { get; set; }
        public string UserImageLocation { get; set; }
        public System.DateTime TimeStamp { get; set; }
    }
}