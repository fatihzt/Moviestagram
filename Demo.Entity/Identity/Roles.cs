using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Entity.Identity
{
    public class RoleS
    {
        public static readonly string Admin = "ADMIN";
        public static readonly string User = "User";
        public static readonly List<string> RoleList = new()
        {
            Admin,
            User
        };
    }
}
