using HRApi.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace HRApi.Utils.Attribute
{
    public class TokenValidationAttribute : ActionFilterAttribute
    {


        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ActionDescriptor.GetCustomAttributes<SkipAuthentication>().Any())
            {
                // The controller action is decorated with the [SkipAuthentication]
                // custom attribute => don't do anything.
                return;
            }


            string token;

            try
            {
                // TODO: token should be encrypted token and when get it back should decrypt it 
                token = actionContext.Request.Headers.GetValues("token").First();
            }
            catch (Exception)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                return;
            }

            try
            {
                if (!SystemHelper.IsValidToken(token))
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }

            }
            catch (Exception)
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                {
                    Content = new StringContent("Unauthorized access")
                };
                return;
            }
        }



    }
}