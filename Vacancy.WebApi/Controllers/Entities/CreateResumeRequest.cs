using System.ComponentModel.DataAnnotations;

namespace Vacancy.WebApi.Controllers.Entities
{
    public class CreateResumeRequest: IValidatableObject
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        [MinLength(2)]
        public string Education { get; set; }
        [Required]
        [MinLength(2)]
        public string Experience { get; set; }
        [Required]
        public int ResumeStatusId { get; set; }
        [Required]
        [MinLength(10)]
        public string Description { get; set; }
        [Required]
        public List<int> SkillsIds { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new List<ValidationResult>();
        }
    }
}
