//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhoneFix.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Part
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Part()
        {
            this.Workmanships = new HashSet<Workmanship>();
        }
    
        public int partsID { get; set; }
        public int repairID { get; set; }
        public string partName { get; set; }
        public decimal price { get; set; }
    
        public virtual RepairSheet RepairSheet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Workmanship> Workmanships { get; set; }
    }
}
