﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRApi.Models.DTO.Employee
{
    public class EmployeeLeaveDTO
    {
        public int leav_LeavID { get; set; }
        public string leav_Name { get; set; }
        public string leav_Type { get; set; }
        public string leav_Reason { get; set; }
        public string leav_Status { get; set; }
        public string leav_EmployeeID { get; set; }
        public DateTime? leav_ToDate { get; set; }
        public string leav_HalfDay { get; set; }
    }
}