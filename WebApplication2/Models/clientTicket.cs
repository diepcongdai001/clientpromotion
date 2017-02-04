using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class clientTicket
    {
        public int Id { get; set; }
        public string Promotion { get; set; }
        public string ReWard { get; set; }
        public string IdClientUser { get; set; }
        public bool IsWin { get; set; }
        public System.DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}