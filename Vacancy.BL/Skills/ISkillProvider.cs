using Vacancy.BL.Skills.Entities;

namespace Vacancy.BL.Skills
{
    public interface ISkillProvider
    {
        IEnumerable<SkillModel> GetSkills(SkillModelFilter filter = null);
        SkillModel GetSkillInfo(Guid id);
    }
}
