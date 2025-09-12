using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebMVC.API.Filters
{
    public class KeyNotFoundExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is KeyNotFoundException notFoundEx)
            {
                context.Result = new NotFoundObjectResult(new ProblemDetails
                {
                    Title = "Entity not found",
                    Detail = notFoundEx.Message,
                    Status = StatusCodes.Status404NotFound
                });
                context.ExceptionHandled = true;
            }
        }
    }
}
