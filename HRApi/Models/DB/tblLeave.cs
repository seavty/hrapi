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
    
    public partial class tblLeave
    {
        public int leav_LeavID { get; set; }
        public string leav_Deleted { get; set; }
        public Nullable<int> leav_CreatedBy { get; set; }
        public Nullable<System.DateTime> leav_CreatedDate { get; set; }
        public Nullable<int> leav_UpdatedBy { get; set; }
        public Nullable<System.DateTime> leav_UpdatedDate { get; set; }
        public Nullable<int> leav_WorkflowID { get; set; }
        public Nullable<int> leav_WorkflowItemID { get; set; }
        public Nullable<int> leav_ZoneID { get; set; }
        public string leav_Name { get; set; }
        public Nullable<System.DateTime> leav_Date { get; set; }
        public string leav_Type { get; set; }
        public string leav_Reason { get; set; }
        public string leav_Remark { get; set; }
        public string leav_LeavSchemeID { get; set; }
        public string leav_LeaveSchemeItemID { get; set; }
        public string leav_Status { get; set; }
        public string leav_EmployeeID { get; set; }
        public Nullable<System.DateTime> leav_ToDate { get; set; }
        public string leav_HalfDay { get; set; }
    }
}
