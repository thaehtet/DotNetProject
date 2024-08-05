using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyFirstNetApiProject.Models;
using MyFirstNetApiProject.Models.Repositories;

namespace MyFirstNetApiProject.Filters.ActionFilters
{
    public class Shirt_ValidateShirtCreateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var shirt = context.ActionArguments["shirt"] as Shirt;
            if (shirt == null){
                context.ModelState.AddModelError("Shirt","There is no shirt object");
                var problemDetails = new ValidationProblemDetails(context.ModelState){
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }else{
                var existingShirt = ShirtRepository.GetShirtByProperties(shirt.Brand, shirt.Color, shirt.Gender, shirt.Size );
                if (existingShirt != null ) {
                    context.ModelState.AddModelError("Shirt","Existing shirt object");
                    var problemDetails = new ValidationProblemDetails(context.ModelState){
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }

        }
    }
}