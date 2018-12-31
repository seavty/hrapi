using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRApi.Models.DTO.Employee
{
    public class EmployeeWorkHistory
    {
        public int wkhs_WorkHistoryID { get; set; }
        
        public Nullable<System.DateTime> wkhs_FrDate { get; set; }
        public Nullable<System.DateTime> wkhs_ToDate { get; set; }
        public Nullable<int> wkhs_FrPositionID { get; set; }
        public Nullable<int> wkhs_ToPositionID { get; set; }
        public Nullable<decimal> wkhs_Salary { get; set; }
        public Nullable<int> wkhs_EmployeeID { get; set; }
        public string wkhs_Status { get; set; }
        public Nullable<System.DateTime> wkhs_Resign { get; set; }
        public string FrPosition { get; set; }
        public string ToPosition { get; set; }

        public string fromDate { get; set; }
        public string toDate { get; set; }
    }
}