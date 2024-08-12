using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProiectFinalWON7.Exceptions;

namespace ProiectFinalWON7.MiddlewareFilters
{
    public class AddressNotFoundExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is AddressNotFoundException)
            {
                context.Result = new ObjectResult(context.Exception.Message)
                {
                    StatusCode = StatusCodes.Status404NotFound
                };

                context.ExceptionHandled = true;

            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
