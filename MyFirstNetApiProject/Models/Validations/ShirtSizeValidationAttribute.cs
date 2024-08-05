using System.ComponentModel.DataAnnotations;  

namespace MyFirstNetApiProject.Models.Validations
{
    public class ShirtSizeValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var shirt = validationContext.ObjectInstance as Shirt;
            
            if(shirt !=null && !string.IsNullOrWhiteSpace(shirt.Gender))
            {
                if(shirt.Gender.Equals("men", StringComparison.OrdinalIgnoreCase) && shirt.Size<8){
                    return new ValidationResult("For men, size should be 8 or greater.");
                }
                else if (shirt.Gender.Equals("women", StringComparison.OrdinalIgnoreCase) && shirt.Size<6){
                    return new ValidationResult("For men, size should be 6 or greater.");
                }
            }

            return ValidationResult.Success;
        }
    }
}