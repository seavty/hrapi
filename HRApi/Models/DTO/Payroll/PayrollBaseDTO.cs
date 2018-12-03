using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRApi.Models.DTO.Payroll
{
    public class PayrollBaseDTO
    {
        public int payr_PayrollID { get; set; }
        public decimal? payr_NWD { get; set; }
        public decimal? payr_ExRate { get; set; }
    }
}