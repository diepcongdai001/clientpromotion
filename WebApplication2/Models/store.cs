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
    
    public partial class store
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public store()
        {
            this.promotions = new HashSet<promotion>();
            this.storeaccounts = new HashSet<storeaccount>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string MapAddress { get; set; }
        public string PhysicAddress { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string Description { get; set; }
        public Nullable<int> BussinessType { get; set; }
        public string PhoneNumber { get; set; }
    
        public virtual bussinesstype bussinesstype1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<promotion> promotions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<storeaccount> storeaccounts { get; set; }
    }
}
