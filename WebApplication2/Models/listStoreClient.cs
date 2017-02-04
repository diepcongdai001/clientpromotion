using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class listStoreClient
    {
        
        public string Name { get; set; }
        public int id { get; set; }
        public string promotion { get; set; }
        public DateTime daystart { get; set; }
        public DateTime dayend { get; set; }

        public string img { get; set; }
        public string MapAddress { get; set; }
        public string PhysicalAddress { get; set; }
    }
}