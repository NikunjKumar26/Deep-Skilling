using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeWebApi.Filters
{
    // Document 3: Custom Authorization filter 
    // (Note: As per Doc 5, this is typically removed/commented from EmployeeController
    // but the class is required to exist per Doc 3 instructions)
    public class CustomAuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                context.Result = new BadRequestObjectResult("Invalid request - No Auth token");
                return;
            }

            var authHeader = context.HttpContext.Request.Headers["Authorization"].ToString();
            if (!authHeader.Contains("Bearer"))
            {
                context.Result = new BadRequestObjectResult("Invalid request - Token present but Bearer unavailable");
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
