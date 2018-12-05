using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRApi.Models.DTO.LeaveSchemeItem
{
    public class LeaveSchemeItemBaseDTO
    {
        public int lvsi_LeaveSchemeItemID { get; set; }
        public string lvsi_Name { get; set; }
        public int? lvsi_PositionID { get; set; }
        public int? lvsi_EmployeeID { get; set; }
        public decimal? lvsi_Order { get; set; }
        
    }
}