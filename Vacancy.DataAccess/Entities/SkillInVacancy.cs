using System.ComponentModel.DataAnnotations.Schema;

namespace Vacancy.DataAccess.Entities
{
    [Table("skill_in_vacancies")]
    public class SkillInVacancy : BaseEntity
    {
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public int VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }
    }
}
