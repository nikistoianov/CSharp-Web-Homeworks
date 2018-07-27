using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Rewrite.Internal.UrlActions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Web.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AuthorizationAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
            var session = context.HttpContext.Session;
            var user = session.GetString("user");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session;
            session.SetString("user", "niki");
            context.Result = new RedirectResult("/Login");
        }
    }
}
