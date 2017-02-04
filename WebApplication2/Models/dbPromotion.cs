using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class dbPromotion
    {
        public int Id { get; set; }
        public Nullable<int> IdSTORE { get; set; }
        public string Name { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> DateBegin { get; set; }
        public Nullable<System.DateTime> DateEnd { get; set; }
        public string Description { get; set; }
        
        public List<dbItemListReward> listReward { get; set; }
    }
}