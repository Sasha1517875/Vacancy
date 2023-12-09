using AutoMapper;
using Vacancy.BL.Exceptions;
using Vacancy.BL.Resumes.Entities;
using Vacancy.DataAccess.Entities;
using Vacancy.Repository;

namespace Vacancy.BL.Resumes
{
    public class ResumeProvider : IResumeProvider
    {
        private readonly IRepository<Resume> _repository;
        private readonly IRepository<SkillInResume> _skillsRepository;
        private readonly IMapper _mapper;

        public ResumeProvider(IRepository<Resume> repository, IRepository<SkillInResume> skillsRepository, IMapper mapper)
        {
            _repository = repository;
            _skillsRepository = skillsRepository;
            _mapper = mapper;
        }

        public ResumeModel GetResumeInfo(Guid id)
        {
            var resume = _repository.GetById(id);
            if (resume is null)
            {
                throw new NotFoundException();
            }
            return _mapper.Map<ResumeModel>(resume);
        }

        public IEnumerable<ResumeModel> GetResumes(ResumeModelFilter filter = null)
        {
            var experience = filter?.Experience;
            var userId = filter?.UserId;
            var statuId = filter?.ResumeStatusId;
            var education = filter.Education;
            var skills = filter.RequiredSkillsIds;


            var companies = _repository.GetAll(x =>
                (experience == null || x.Experience == experience) &&
                (userId == null || x.UserId == userId) &&
                (statuId == null || x.ResumeStatusId == statuId) &&
                (education == null || x.Education == education) &&
                (skills == null || ContainAllSkills(skills, x.Id)));

            return _mapper.Map<IEnumerable<ResumeModel>>(companies);
        }

        private bool ContainAllSkills(ICollection<int> skillsIds, int resumeId)
        {
            var skills = _skillsRepository.GetAll(y => y.ResumeId == resumeId)
                .Select(y => y.SkillId)
                .ToList();
            return skillsIds.All(skills.Contains);
        }
    }
}
