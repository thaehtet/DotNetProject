using Microsoft.AspNetCore.Mvc;
using MyFirstNetApiProject.Filters.ActionFilters;
using MyFirstNetApiProject.Filters.ExceptionFilters;
using MyFirstNetApiProject.Models;
using MyFirstNetApiProject.Models.Repositories;
namespace MyFirstNetApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController: ControllerBase
    {
        [HttpGet]
        public IActionResult GetShirts()
        {
            return Ok(ShirtRepository.GetShirts());
        }

        // [HttpGet("{id}/{color}")] // Data from route
        [HttpGet("{id}")]
        [Shirt_ValidateIdFilter]
        public IActionResult GetShirtsById(int id)
        {
            return Ok(ShirtRepository.GetShirtById(id));
        }

        [HttpPost]
        [Shirt_ValidateShirtCreateFilter]
        public IActionResult  CreateShirt([FromBody]Shirt shirt)
        {
            // if(shirt == null) return BadRequest();
            
            ShirtRepository.AddShirt(shirt);
            return CreatedAtAction(nameof(GetShirtsById),new Shirt{ Id = shirt.Id},shirt);
        }
        
        [HttpPut("{id}")]
        // public string UpdateShirtsById(int id,[FromQuery] string color)   // Data from query
        [Shirt_ValidateIdFilter]
        [Shirt_ValidateShirtUpdateFilter]
        [Shirt_ExceptionFilter]
        public IActionResult UpdateShirtsById(int id,[FromBody]Shirt shirt)
        {
            
            ShirtRepository.UpdateShirt(shirt);
            
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        // public string DeleteShirtsById(int id,[FromHeader( Name = "Color" )] string color) // Data from header
        public IActionResult DeleteShirtsById(int id)
        {
            return Ok("Deleting the shirt id : {id}");
        }
    }
}