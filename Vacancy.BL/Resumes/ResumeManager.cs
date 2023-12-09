using AutoMapper;
using Vacancy.BL.Exceptions;
using Vacancy.BL.Resumes.Entities;
using Vacancy.DataAccess.Entities;
using Vacancy.Repository;

namespace Vacancy.BL.Resumes
{
    public class ResumeManager : IResumeManager
    {
        private readonly IRepository<Resume> _repository;
        private readonly IRepository<SkillInResume> _skillsRepository;
        private readonly IMapper _mapper;

        public ResumeManager(IRepository<Resume> repository, IRepository<SkillInResume> skillsRepository, IMapper mapper)
        {
            _repository = repository;
            _skillsRepository = skillsRepository;
            _mapper = mapper;
        }

        public ResumeModel CreateResume(CreateResumeModel model)
        {

            var entity = _mapper.Map<Resume>(model);

            _repository.Save(entity);


            foreach (var item in model.SkillsIds)
            {
                var skill = new SkillInResume() { ResumeId = entity.Id, SkillId = item };
                _skillsRepository.Save(skill);
            }

            return _mapper.Map<ResumeModel>(entity);
        }

        public void DeleteResume(Guid id)
        {
            var entity = _repository.GetById(id);
            if (entity is null)
            {
                throw new NotFoundException();
            }
            var skills = _skillsRepository.GetAll(x => x.ResumeId == entity.Id);
            foreach (var skill in skills)
            {
                _skillsRepository.Delete(skill);
            }

            _repository.Delete(entity);
        }

        public ResumeModel UpdateResume(Guid id, UpdateResumeModel model)
        {
            var entity = _repository.GetById(id);
            if (entity is null)
            {
                throw new NotFoundException();
            }
            entity.Education = model.Education;
            entity.Experience = model.Experience;
            entity.ResumeStatusId = model.ResumeStatusId;
            entity.Description = model.Description;
            _repository.Save(entity);
            var currentSkills = _skillsRepository.GetAll(skill => skill.ResumeId == entity.Id).ToList();

            foreach (var item in currentSkills)
            {
                if (!model.SkillsIds.Contains(item.SkillId))
                {
                    _skillsRepository.Delete(item);
                }
            }

            foreach (var item in model.SkillsIds)
            {
                if (!currentSkills.Any(s => s.SkillId == item))
                {
                    var skill = new SkillInResume() { ResumeId = entity.Id, SkillId = item };
                    _skillsRepository.Save(skill);
                }
            }

            return _mapper.Map<ResumeModel>(entity);
        }
    }
}
