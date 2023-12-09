using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vacancy.BL.Exceptions;
using Vacancy.BL.Resumes;
using Vacancy.BL.Resumes.Entities;
using Vacancy.WebApi.Controllers.Entities;

namespace Vacancy.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {
        private readonly IResumeProvider _resumesProvider;
        private readonly IResumeManager _resumesManager;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ResumeController(IResumeProvider resumesProvider, IResumeManager resumesManager, IMapper mapper, ILogger logger)
        {
            _resumesProvider = resumesProvider;
            _resumesManager = resumesManager;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetAllResumes()
        {
            var resumes = _resumesProvider.GetResumes();
            return Ok(new ResumesListResponse()
            {
                Resumes = resumes.ToList()
            });
        }

        [HttpGet]
        [Route("filter")]
        public IActionResult GetFilteredResumes([FromQuery] ResumesFilter filter)
        {
            var resumes = _resumesProvider.GetResumes(_mapper.Map<ResumeModelFilter>(filter));
            return Ok(new ResumesListResponse()
            {
                Resumes = resumes.ToList()
            });
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetResumeInfo([FromRoute] Guid id)
        {
            try
            {
                var resume = _resumesProvider.GetResumeInfo(id);
                return Ok(resume);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex.ToString());
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateResume([FromBody] CreateResumeRequest request)
        {
            try
            {
                var resume = _resumesManager.CreateResume(_mapper.Map<CreateResumeModel>(request));
                return Ok(resume);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateResumeInfo([FromRoute] Guid id, UpdateResumeRequest request)
        {
            try
            {
                var resume = _resumesManager.UpdateResume(id, _mapper.Map<UpdateResumeModel>(request));
                return Ok(resume);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex.ToString());
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteResume([FromRoute] Guid id)
        {
            try
            {
                _resumesManager.DeleteResume(id);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex.ToString());
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }
    }
}
