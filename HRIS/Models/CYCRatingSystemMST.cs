//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRIS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CYCRatingSystemMST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CYCRatingSystemMST()
        {
            this.CYCParameterMSTs = new HashSet<CYCParameterMST>();
        }
    
        public long CYCRatingSystemMSTId { get; set; }
        public string RatingSystemName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CYCParameterMST> CYCParameterMSTs { get; set; }
    }
}
