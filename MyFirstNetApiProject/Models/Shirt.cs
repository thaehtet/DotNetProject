using System.ComponentModel.DataAnnotations;
using MyFirstNetApiProject.Models.Validations;

namespace MyFirstNetApiProject.Models
{
    public class Shirt
    {
        public int Id { get; set; } 

        [Required]
        public string? Brand { get; set; }

        [Required]
        public string? Color { get; set; }
        
        [ShirtSizeValidation]
        public int? Size { get; set; }

        [Required]
        public string? Gender { get; set; }

        public double Price{ get; set; }

    }
}