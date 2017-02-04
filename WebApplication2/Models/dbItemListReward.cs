using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class dbItemListReward
    {
        public string name { get; set; }
        public Nullable<int> ChanceToGet { get; set; }
        public Nullable<int> ChanceToRoll { get; set; }
        public Nullable<bool> Status { get; set; }
        
        public int quantity { get; set; }
    }
}