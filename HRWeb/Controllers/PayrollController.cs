using HRApi.Utils.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HRWeb.Controllers
{
    public class PayrollController : Controller
    {
        private readonly EmployeeHandler handler;

        public PayrollController()
        {
            handler = new EmployeeHandler();
        }


        //=> Employee List
        [HttpGet]
        public async Task<ActionResult> Payroll(int id)
        {
            var result = await handler.EmployeePayroll(id, 1);
            return View(result);
        }

    }
}