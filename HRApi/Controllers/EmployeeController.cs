using HRApi.Utils.Handler;
using HRApi.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HRApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private const string route = ConstantHelper.API_VERSION + "employees";
        private const string routeWithConstraint = route + "/{id:int:min(1)}";
        private EmployeeHandler handler = null;

        public EmployeeController()
        {
            handler = new EmployeeHandler();
        }
    }
}
