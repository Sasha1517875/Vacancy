using Vacancy.BL.Skills.Entities;

namespace Vacancy.BL.Skills
{
    public interface ISkillManager
    {
        SkillModel CreateSkill(CreateSkillModel model);
        void DeleteSkill(Guid id);
        SkillModel UpdateSkill(Guid id, UpdateSkillModel model);
    }
}

