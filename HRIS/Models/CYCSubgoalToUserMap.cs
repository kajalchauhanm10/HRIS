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
    
    public partial class CYCSubgoalToUserMap
    {
        public long CYCSubgoalToUserMapId { get; set; }
        public Nullable<long> CYCSubGoalMSTId { get; set; }
        public Nullable<long> UserId { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<System.DateTime> CompletedBy { get; set; }
        public Nullable<int> PriorityId { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
