using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRApi.Models.DTO.Employee
{
    public class EmployeeBaseDTO
    {
        public int empl_EmployeeID { get; set; }
        public string empl_Code { get; set; }
        public string empl_Name { get; set; }
        public string empl_PayrollAccountNo { get; set; }
        public string empl_DOB { get; set; }
        public string empl_Address { get; set; }
    }
}