using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class storeAcc
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string AccountType { get; set; }

        
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<bool> Sex { get; set; }

        
    }
}