using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class MerchantReward
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> ChanceToGet { get; set; }
        public Nullable<int> ChanceToRoll { get; set; }
        public Nullable<bool> Status { get; set; }
        //public Nullable<int> TimeRemain { get; set; }
    }
}