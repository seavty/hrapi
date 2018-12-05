using HRApi.Models.DTO.LeaveSchemeItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace HRApi.Models.DTO.LeaveScheme
{
    public class LeaveSchemeViewDTO:LeaveSchemeBaseDTO
    {
        public List<LeaveSchemeItemViewDTO> leaveSchemeItems { get; set; } = new List<LeaveSchemeItemViewDTO>();
    }
}