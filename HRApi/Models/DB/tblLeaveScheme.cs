//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRApi.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblLeaveScheme
    {
        public int lvsc_LeaveSchemeID { get; set; }
        public string lvsc_Deleted { get; set; }
        public Nullable<int> lvsc_CreatedBy { get; set; }
        public Nullable<System.DateTime> lvsc_CreatedDate { get; set; }
        public Nullable<int> lvsc_UpdatedBy { get; set; }
        public Nullable<System.DateTime> lvsc_UpdatedDate { get; set; }
        public Nullable<int> lvsc_WorkflowID { get; set; }
        public Nullable<int> lvsc_WorkflowItemID { get; set; }
        public Nullable<int> lvsc_ZoneID { get; set; }
        public string lvsc_Name { get; set; }
        public string lvsc_Note { get; set; }
    }
}
