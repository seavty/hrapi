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
    
    public partial class tblDepartment
    {
        public int Depa_DepartmentID { get; set; }
        public string Depa_Deleted { get; set; }
        public Nullable<int> Depa_CreatedBy { get; set; }
        public Nullable<System.DateTime> Depa_CreatedDate { get; set; }
        public Nullable<int> Depa_UpdatedBy { get; set; }
        public Nullable<System.DateTime> Depa_UpdatedDate { get; set; }
        public Nullable<int> Depa_WorkflowID { get; set; }
        public Nullable<int> Depa_WorkflowItemID { get; set; }
        public Nullable<int> Depa_ZoneID { get; set; }
        public string Depa_Name { get; set; }
    }
}
