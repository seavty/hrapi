using HRApi.Models.DB;
using HRApi.Models.DTO;
using HRApi.Models.DTO.LeaveScheme;
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
    public class LeaveSchemeHandler
    {
        private HR_DHLEntities db;

        public LeaveSchemeHandler()
        {
            db = new HR_DHLEntities();
        }

        public LeaveSchemeHandler(HR_DHLEntities db)
        {
            this.db = db;
        }


        //=> SelectByID
        public async Task<LeaveSchemeViewDTO> SelectByID(int id)
        {
            var record = await db.tblLeaveSchemes.FirstOrDefaultAsync(x => x.lvsc_Deleted == null && x.lvsc_LeaveSchemeID == id);
            if (record == null)
                throw new HttpException((int)HttpStatusCode.NotFound, ConstantHelper.RECORD_NOT_FOUND);

            var result = MappingHelper.MapDBClassToDTO<tblLeaveScheme, LeaveSchemeViewDTO>(record);
            record.leav
            return MappingHelper.MapDBClassToDTO<tblPayroll, LeaveSchemeViewDTO>(record);
        }

        //=> GetList
        public async Task<GetListDTO<LeaveSchemeViewDTO>> GetList(int currentPage)
        {
            var query = from x in db.tblLeaveSchemes
                        where x.lvsc_Deleted == null
                        orderby x.lvsc_Name ascending
                        select x;
            return await Listing(currentPage, query);
        }

        //-- private method --//
        //=>Listing
        private async Task<GetListDTO<LeaveSchemeViewDTO>> Listing(int currentPage, IQueryable<tblLeaveScheme> query, string search = null)
        {
            var records = await query.Page(currentPage).ToListAsync();

            var myList = new List<LeaveSchemeViewDTO>();
            foreach (var record in records)
            {
                myList.Add(await SelectByID(record.lvsc_LeaveSchemeID));
            }
            var getList = new GetListDTO<LeaveSchemeViewDTO>();
            getList.metaData = await PaginationHelper.GetMetaData(currentPage, query, "name", "asc", search);
            getList.results = myList;
            return getList;
        }
    }
}