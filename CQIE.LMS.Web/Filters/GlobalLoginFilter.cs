using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;

namespace CQIE.LMS.Web.Filters
{
    public class GlobalLoginFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            foreach (var filter in context.ActionDescriptor.FilterDescriptors)
            {
                if (filter.Filter is Microsoft.AspNetCore.Mvc.Authorization.AllowAnonymousFilter)
                {
                    return;
                }
            }

            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = NotLogin();
            }
        }

        private IActionResult NotLogin()
        {
            
            return new RedirectResult("~/Account/AccessDenied");
        }
    }

}
