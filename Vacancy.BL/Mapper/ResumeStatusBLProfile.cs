using AutoMapper;
using Vacancy.BL.Resumes;
using Vacancy.DataAccess.Entities;

namespace Vacancy.BL.Mapper
{
    public class ResumeStatusBLProfile : Profile
    {
        public static ResumeStatusEnum ConvertResumeStatusToEnum(ResumeStatus src)
        {
            switch (src.Status)
            {
                case "Draft":
                    return ResumeStatusEnum.Draft;
                case "Completed":
                    return ResumeStatusEnum.Completed;
                case "Hidden":
                    return ResumeStatusEnum.Hidden;
                case "Archived":
                    return ResumeStatusEnum.Archived;
                default:
                    throw new ArgumentOutOfRangeException(nameof(src), $"Not expected status value: {src.Status}");
            }
        }

        public ResumeStatusBLProfile()
        {
            CreateMap<ResumeStatus, ResumeStatusEnum>().ConvertUsing((src, _, _)=> ConvertResumeStatusToEnum(src));
        }
    }
}
