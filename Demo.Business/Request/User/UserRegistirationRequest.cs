using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business.Request.User
{
    public class UserRegistirationRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string EMail { get; set; }
        public string TelNo { get; set; }

    }
}
