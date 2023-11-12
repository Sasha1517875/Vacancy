using System.ComponentModel.DataAnnotations.Schema;

namespace Vacancy.DataAccess.Entities
{
    [Table("vacancy_statuses")]
    public class VacancyStatus : BaseEntity
    {
        public string Status { get; set; }
    }
}
