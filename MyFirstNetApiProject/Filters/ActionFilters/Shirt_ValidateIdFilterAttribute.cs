using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyFirstNetApiProject.Models.Repositories;

namespace MyFirstNetApiProject.Filters.ActionFilters
{
    public class Shirt_ValidateIdFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var shirt_id = context.ActionArguments["Id"] as int?;
            if (shirt_id.HasValue){
                if (shirt_id.Value <= 0){
                    context.ModelState.AddModelError("Id","Id is invalid");
                    var problemDetails = new ValidationProblemDetails(context.ModelState){
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);

                }else if(!ShirtRepository.ShirtExits(shirt_id.Value)){
                    context.ModelState.AddModelError("Id","Id is not exist.");
                     var problemDetails = new ValidationProblemDetails(context.ModelState){
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }
        }
    }
}