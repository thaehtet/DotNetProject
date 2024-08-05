using Microsoft.AspNetCore.Mvc;
namespace MyFirstNetApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PantsController: ControllerBase
    {
        [HttpGet]
        public string GetPants()
        {
            return "Reading all pants";
        }

        [HttpGet("{id}")]
        public string GetPantsById(int id)
        {
            return $"Reading pant by id : {id}";
        }

        [HttpPut("{id}")]
        public string UpdatePantsById(int id)
        {
            return $"Updating the pant id : {id}";
        }

        [HttpDelete("{id}")]
        public string DeletePantsById(int id)
        {
            return $"Deeleting the pant id : {id}";
        }
    }
}