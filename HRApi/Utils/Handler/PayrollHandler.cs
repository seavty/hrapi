using HRApi.Models.DB;
using HRApi.Models.DTO;
using HRApi.Models.DTO.Payroll;
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
    public class PayrollHandler
    {
        private HR_DHLEntities db;

        public PayrollHandler()
        {
            db = new HR_DHLEntities();
        }

        public PayrollHandler(HR_DHLEntities db)
        {
            this.db = db;
        }


        //=> SelectByID
        public async Task<PayrollViewDTO> SelectByID(int id)
        {
            var record = await db.tblPayrolls.FirstOrDefaultAsync(x => x.payr_Deleted == null && x.payr_PayrollID == id);
            if (record == null)
                throw new HttpException((int)HttpStatusCode.NotFound, ConstantHelper.RECORD_NOT_FOUND);
            return MappingHelper.MapDBClassToDTO<tblPayroll, PayrollViewDTO>(record);
        }

        //=> GetList
        public async Task<GetListDTO<PayrollViewDTO>> GetList(int currentPage)
        {
            var query = from x in db.tblPayrolls
                        where x.payr_Deleted == null
                        orderby x.payr_NWD ascending
                        select x;
            return await Listing(currentPage, query);
        }

        //-- private method --//
        //=>Listing
        private async Task<GetListDTO<PayrollViewDTO>> Listing(int currentPage, IQueryable<tblPayroll> query, string search = null)
        {
            var records = await query.Page(currentPage).ToListAsync();

            var myList = new List<PayrollViewDTO>();
            foreach (var record in records)
            {
                myList.Add(await SelectByID(record.payr_PayrollID));
            }
            var getList = new GetListDTO<PayrollViewDTO>();
            getList.metaData = await PaginationHelper.GetMetaData(currentPage, query, "name", "asc", search);
            getList.results = myList;
            return getList;
        }
    }
}