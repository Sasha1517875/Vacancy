using System.ComponentModel.DataAnnotations.Schema;

namespace Vacancy.DataAccess.Entities
{
    [Table("vacancies")]
    public class Vacancy : BaseEntity
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int VacancyStatusId { get; set; }
        public VacancyStatus VacancyStatus { get; set; }
        public string Description { get; set; }
    }
}
