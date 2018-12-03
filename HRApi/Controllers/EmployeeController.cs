﻿using HRApi.Models.DTO;
using HRApi.Models.DTO.Employee;
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
    public class EmployeeController : ApiController
    {
        private const string route = ConstantHelper.API_VERSION + "employees";
        private const string routeWithConstraint = route + "/{id:int:min(1)}";
        private EmployeeHandler handler = null;

        public EmployeeController()
        {
            handler = new EmployeeHandler();
        }

        //=> Select Customer By ID
        [HttpGet]
        [Route(routeWithConstraint)]
        [ResponseType(typeof(EmployeeViewDTO))]
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
        [ResponseType(typeof(GetListDTO<EmployeeViewDTO>))]
        public async Task<IHttpActionResult> Get([FromUri] int currentPage)
        {
            return Ok(await handler.GetList(currentPage));
        }
    }
}
