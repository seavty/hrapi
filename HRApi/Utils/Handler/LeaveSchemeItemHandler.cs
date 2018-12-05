using HRApi.Models.DB;
using HRApi.Models.DTO;
using HRApi.Models.DTO.LeaveSchemeItem;
using HRApi.Utils.Extension;
using HRApi.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace HRApi.Utils.Handler
{
    public class LeaveSchemeItemHandler
    {
        private HR_DHLEntities db;

        public LeaveSchemeItemHandler()
        {
            db = new HR_DHLEntities();
        }

        public LeaveSchemeItemHandler(HR_DHLEntities db)
        {
            this.db = db;
        }


        //=> SelectByID
        public async Task<LeaveSchemeItemViewDTO> SelectByID(int id)
        {
            var record = await db.tblLeaveSchemeItems.FirstOrDefaultAsync(x => x.lvsi_Deleted == null && x.lvsi_LeaveSchemeItemID == id);
            if (record == null)
                throw new HttpException((int)HttpStatusCode.NotFound, ConstantHelper.RECORD_NOT_FOUND);
            return MappingHelper.MapDBClassToDTO<tblLeaveSchemeItem, LeaveSchemeItemViewDTO>(record);
        }

        //=> GetList
        public async Task<GetListDTO<LeaveSchemeItemViewDTO>> GetList(int currentPage)
        {
            var query = from x in db.tblLeaveSchemeItems
                        where x.lvsi_Deleted == null
                        orderby x.lvsi_Name ascending
                        select x;
            return await Listing(currentPage, query);
        }

        //-- private method --//
        //=>Listing
        private async Task<GetListDTO<LeaveSchemeItemViewDTO>> Listing(int currentPage, IQueryable<tblLeaveSchemeItem> query, string search = null)
        {
            var records = await query.Page(currentPage).ToListAsync();

            var myList = new List<LeaveSchemeItemViewDTO>();
            foreach (var record in records)
            {
                myList.Add(await SelectByID(record.lvsi_LeaveSchemeItemID));
            }
            var getList = new GetListDTO<LeaveSchemeItemViewDTO>();
            getList.metaData = await PaginationHelper.GetMetaData(currentPage, query, "name", "asc", search);
            getList.results = myList;
            return getList;
        }
    }
}