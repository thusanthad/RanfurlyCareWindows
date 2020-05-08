using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyBusiness
{
    public class UserRoleAction
    {
        public int UserRoleActionId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int RoleActionId { get; set; }
        public string Role { get; set; }
        public string RoleAction { get; set; }
    }
}
