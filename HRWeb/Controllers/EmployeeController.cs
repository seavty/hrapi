using HRApi.Utils.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HRWeb.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeHandler handler;

        public EmployeeController()
        {
            handler = new EmployeeHandler();
        }


        //=> Payroll List
        [HttpGet]
        public async Task<ActionResult> Payroll(int id)
        {
            var result = await handler.EmployeePayroll(id, 1);
            return View(result);
        }


        //=> Leave List
        [HttpGet]
        public async Task<ActionResult> Leave(int id)
        {
            var result = await handler.EmployeeLeave(id, 1);
            return View(result);
        }

        //=> WorkHisotry List
        [HttpGet]
        public async Task<ActionResult> WorkHistory(int id)
        {
            var result = await handler.EmployeeWorkHistory(id, 1);
            return View(result);
        }
    }
}