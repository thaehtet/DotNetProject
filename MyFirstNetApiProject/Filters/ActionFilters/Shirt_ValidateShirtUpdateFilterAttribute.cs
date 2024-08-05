using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyFirstNetApiProject.Models;

namespace MyFirstNetApiProject.Filters.ActionFilters
{
    public class Shirt_ValidateShirtUpdateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var id = context.ActionArguments["id"] as int?;
            var shirt = context.ActionArguments["shirt"] as Shirt;

            if(id.HasValue && shirt!=null && id != shirt.Id){
                context.ModelState.AddModelError("Shirt ID","Shirt Id must be same with updated shirt object.");
                var problemDetails = new ValidationProblemDetails(context.ModelState){
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }
    }
}