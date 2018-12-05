using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRApi.Models.DTO.LeaveScheme
{
    public class LeaveSchemeBaseDTO
    {
        public int lvsc_LeaveSchemeID { get; set; }
        public string lvsc_Name { get; set; }
        public string lvsc_Note { get; set; }
    }
}