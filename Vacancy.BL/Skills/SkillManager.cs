using AutoMapper;
using Vacancy.BL.Exceptions;
using Vacancy.BL.Skills.Entities;
using Vacancy.DataAccess.Entities;
using Vacancy.Repository;

namespace Vacancy.BL.Skills
{
    public class SkillManager : ISkillManager
    {
        private readonly IRepository<Skill> _repository;
        private readonly IMapper _mapper;

        public SkillManager(IRepository<Skill> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public SkillModel CreateSkill(CreateSkillModel model)
        {

            var entity = _mapper.Map<Skill>(model);

            _repository.Save(entity);

            return _mapper.Map<SkillModel>(entity);
        }

        public void DeleteSkill(Guid id)
        {
            var entity = _repository.GetById(id);
            if (entity is null)
            {
                throw new NotFoundException();
            }
            _repository.Delete(entity);
        }

        public SkillModel UpdateSkill(Guid id, UpdateSkillModel model)
        {
            var entity = _repository.GetById(id);
            if (entity is null)
            {
                throw new NotFoundException();
            }
            entity.Name = model.SkillName;
            _repository.Save(entity);
            return _mapper.Map<SkillModel>(entity);
        }
    }
}
