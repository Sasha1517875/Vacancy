using System.ComponentModel.DataAnnotations;

namespace Vacancy.WebApi.Controllers.Entities
{
    public class CreateAdminRequest: IValidatableObject
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new List<ValidationResult>();
        }
    }
}
