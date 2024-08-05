using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyFirstNetApiProject.Models.Repositories;

namespace MyFirstNetApiProject.Filters.ExceptionFilters
{
    public class Shirt_ExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var  strShirtId = context.RouteData.Values["id"] as string;

            if (int.TryParse(strShirtId, out int shirtId))
            {
                if(!ShirtRepository.ShirtExits(shirtId))
                {
                    context.ModelState.AddModelError("Shirt ID","Shirt Id doesnt exit anymore.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState){
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }
        }
    }
}