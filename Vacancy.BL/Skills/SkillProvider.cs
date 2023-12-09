using AutoMapper;
using Vacancy.BL.Exceptions;
using Vacancy.BL.Skills.Entities;
using Vacancy.DataAccess.Entities;
using Vacancy.Repository;

namespace Vacancy.BL.Skills
{
    public class SkillProvider : ISkillProvider
    {
        private readonly IRepository<Skill> _repository;
        private readonly IMapper _mapper;

        public SkillProvider(IRepository<Skill> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public SkillModel GetSkillInfo(Guid id)
        {
            var resume = _repository.GetById(id);
            if (resume is null)
            {
                throw new NotFoundException();
            }
            return _mapper.Map<SkillModel>(resume);
        }

        public IEnumerable<SkillModel> GetSkills(SkillModelFilter filter = null)
        {
            var name = filter?.SkillName;

            var companies = _repository.GetAll(x =>
                name == null || x.Name == name);

            return _mapper.Map<IEnumerable<SkillModel>>(companies);
        }
    }
}
