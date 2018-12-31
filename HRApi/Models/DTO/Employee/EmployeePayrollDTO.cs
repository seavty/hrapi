using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRApi.Models.DTO.Employee
{
    public class EmployeePayrollDTO
    {
        public int payr_PayrollID { get; set; }

        
        public DateTime? payr_FrDate { get; set; }
        public DateTime? payr_ToDate { get; set; }

        

        public decimal? payr_ExRate { get; set; }

        public int prit_PayrollItemID { get; set; }
        
        public decimal? prit_Salary { get; set; }
        
        public int empl_EmployeeID { get; set; }
        
        public string empl_Code { get; set; }
        public string empl_Name { get; set; }


        public string fromDate { get; set; }
        public string toDate { get; set; }

    }
}