using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeWebApi.Filters
{
    // Document 3: Custom Exception filter
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var message = $"[{DateTime.Now}] Exception: {exception.Message}\nStackTrace: {exception.StackTrace}\n";
            
            // Log to local file
            File.AppendAllText("error_log.txt", message);

            // Set result
            context.Result = new ObjectResult(new { error = "An internal error occurred. See logs for details." })
            {
                StatusCode = 500
            };
            
            context.ExceptionHandled = true;
        }
    }
}
