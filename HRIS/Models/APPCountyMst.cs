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
    
    public partial class APPCountyMst
    {
        public long APPCountyMstId { get; set; }
        public long APPStateMstId { get; set; }
        public string CountyName { get; set; }
        public string CountyCode { get; set; }
        public Nullable<byte> IsActive { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string WorkStation { get; set; }
    }
}
