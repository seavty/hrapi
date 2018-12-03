using HRApi.Models.DTO;
using HRApi.Models.DTO.Payroll;
using HRApi.Utils.Handler;
using HRApi.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace HRApi.Controllers
{
    public class PayrollController : ApiController
    {
        private const string route = ConstantHelper.API_VERSION + "payrolls";
        private const string routeWithConstraint = route + "/{id:int:min(1)}";
        private PayrollHandler handler = null;

        public PayrollController()
        {
            handler = new PayrollHandler();
        }

        //=> Select Customer By ID
        [HttpGet]
        [Route(routeWithConstraint)]
        [ResponseType(typeof(PayrollViewDTO))]
        public async Task<IHttpActionResult> SelectByID(int id)
        {
            try
            {
                return Ok(await handler.SelectByID(id));
            }
            catch (HttpException)
            {
                return NotFound();
            }
        }

        //=> Employee List
        [HttpGet]
        [Route(route)]
        [ResponseType(typeof(GetListDTO<PayrollViewDTO>))]
        public async Task<IHttpActionResult> Get([FromUri] int currentPage)
        {
            return Ok(await handler.GetList(currentPage));
        }
    }
}
