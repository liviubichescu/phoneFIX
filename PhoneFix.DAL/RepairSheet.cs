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
    
    public partial class RepairSheet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RepairSheet()
        {
            this.Parts = new HashSet<Part>();
            this.Workmanships = new HashSet<Workmanship>();
        }
    
        public int ID_repair { get; set; }
        public string defect_conclusion { get; set; }
        public Nullable<decimal> totalCost { get; set; }
        public Nullable<System.DateTime> estimatedDate { get; set; }
        public string status { get; set; }
        public int service_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Part> Parts { get; set; }
        public virtual ServiceSheet ServiceSheet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Workmanship> Workmanships { get; set; }
    }
}
