using HRApi.Models.DB;
using HRApi.Models.DTO;
using HRApi.Models.DTO.Employee;
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
    public class EmployeeHandler
    {
        private HR_DHLEntities db;

        public EmployeeHandler()
        {
            db = new HR_DHLEntities();
        }

        public EmployeeHandler(HR_DHLEntities db)
        {
            this.db = db;
        }

        //=> SelectByID
        public async Task<EmployeeViewDTO> SelectByID(int id)
        {
            var record = await db.tblEmployees.FirstOrDefaultAsync(x => x.empl_Deleted== null && x.empl_EmployeeID == id);
            if (record == null)
                throw new HttpException((int)HttpStatusCode.NotFound, ConstantHelper.RECORD_NOT_FOUND);
            return MappingHelper.MapDBClassToDTO<tblEmployee, EmployeeViewDTO>(record);
        }

        //=> EmployeePayroll
        public async Task<GetListDTO<EmployeePayrollDTO>> EmployeePayroll(int empID, int currentPage)
        {
            var query = db.vEmployeePayrollAPIs.Where(x => x.empl_EmployeeID == empID).OrderByDescending(x => x.payr_FrDate);
            var records = await query.Page(currentPage).ToListAsync();

            var myList = new List<EmployeePayrollDTO>();
            foreach (var record in records)
            {
                myList.Add(MappingHelper.MapDBClassToDTO<vEmployeePayrollAPI, EmployeePayrollDTO>(record));
            }
            var getList = new GetListDTO<EmployeePayrollDTO>();
            getList.metaData = await PaginationHelper.GetMetaData(currentPage, query, "name", "asc", null);
            getList.results = myList;

            return getList;
        }

        //=>
        public async Task<GetListDTO<EmployeeLeaveDTO>> EmployeeLeave(int empID, int currentPage)
        {
            var query = db.tblLeaves.Where(x => x.leav_EmployeeID == empID.ToString()).OrderByDescending(x => x.leav_Date);
            var records = await query.Page(currentPage).ToListAsync();

            var myList = new List<EmployeeLeaveDTO>();
            foreach (var record in records)
            {
                myList.Add(MappingHelper.MapDBClassToDTO<tblLeave, EmployeeLeaveDTO>(record));
            }
            var getList = new GetListDTO<EmployeeLeaveDTO>();
            getList.metaData = await PaginationHelper.GetMetaData(currentPage, query, "name", "asc", null);
            getList.results = myList;

            return getList;
        }


        //=> GetList
        public async Task<GetListDTO<EmployeeViewDTO>> GetList(int currentPage)
        {
            var query = from x in db.tblEmployees
                        where x.empl_Deleted == null
                        orderby x.empl_Name ascending
                        select x;
            return await Listing(currentPage, query);
        }

        //=> Search
        public async Task<GetListDTO<EmployeeViewDTO>> Search(int currentPage, string search)
        {
            var query = from x in db.tblEmployees
                        where x.empl_Deleted == null && (x.empl_Name.Contains(search) || x.empl_Name.Contains(search))
                        orderby x.empl_Name ascending
                        select x;
            return await Listing(currentPage, query, search);
        }

        //-- private method --//
        //=>Listing
        private async Task<GetListDTO<EmployeeViewDTO>> Listing(int currentPage, IQueryable<tblEmployee> query, string search = null)
        {
            var records = await query.Page(currentPage).ToListAsync();

            var myList = new List<EmployeeViewDTO>();
            foreach (var record in records)
            {
                myList.Add(await SelectByID(record.empl_EmployeeID));
            }
            var getList = new GetListDTO<EmployeeViewDTO>();
            getList.metaData = await PaginationHelper.GetMetaData(currentPage, query, "name", "asc", search);
            getList.results = myList;
            return getList;
        }
    }
}