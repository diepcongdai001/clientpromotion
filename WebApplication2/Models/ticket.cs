//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ticket
    {
        public int Id { get; set; }
        public Nullable<int> IdPromotion { get; set; }
        public Nullable<int> IdReWard { get; set; }
        public Nullable<int> IdClientUser { get; set; }
        public Nullable<bool> IsWin { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<bool> Status { get; set; }
    
        public virtual clientaccount clientaccount { get; set; }
        public virtual promotion promotion { get; set; }
        public virtual reward reward { get; set; }
    }
}