using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegister
{
    public class ValidateUserSession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(context.HttpContext.Session.GetString("UserID"))))
                {
                    RedirectToRouteResult result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "ErrorView", controller = "Error" }));



                    var controller = context.Controller as Controller;
                    controller.ViewData["ErrorMessage"] = "You Session has been Expired";
                    controller.HttpContext.Session.Clear();
                    context.Result = result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
