using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRApi.Models.DTO
{
    public class MetaDataDTO
    {
        public int currentPage { get; set; }
        public int totalPage { get; set; }
        public int totalRecord { get; set; }
        public int pageSize { get; set; }
        public string orderColumn { get; set; }
        public string orderBy { get; set; }
        public string search { get; set; }
    }
}