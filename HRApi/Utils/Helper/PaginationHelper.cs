using HRApi.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HRApi.Utils.Helper
{
    public static class PaginationHelper
    {
        public static async Task<MetaDataDTO> GetMetaData(int currentPage, IQueryable<dynamic> records, string orderColumn, string orderBy, string search, bool isMasterDetailList = false)
        {
            int myPageSize = ConstantHelper.PAGE_SIZE;
            if (isMasterDetailList)
                myPageSize = ConstantHelper.MASTER_DETAIL_PAGE_SIZE;

            int totalRecord = await records.CountAsync();
            double getTotalPage = ((double)totalRecord / myPageSize);
            int totalPage = (int)Math.Ceiling(getTotalPage);
            MetaDataDTO metaData = new MetaDataDTO();
            metaData.currentPage = currentPage;
            metaData.pageSize = myPageSize;
            metaData.totalPage = totalPage;
            metaData.totalRecord = totalRecord;
            metaData.orderColumn = orderColumn;
            metaData.orderBy = orderBy;
            metaData.search = search;
            return metaData;
        }
    }
}