using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vacancy.BL.Admins;
using Vacancy.BL.Admins.Entities;
using Vacancy.BL.Exceptions;
using Vacancy.WebApi.Controllers.Entities;

namespace Vacancy.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminProvider _adminsProvider;
        private readonly IAdminManager _adminsManager;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AdminController(IAdminProvider adminsProvider, IAdminManager adminsManager, IMapper mapper, ILogger logger)
        {
            _adminsProvider = adminsProvider;
            _adminsManager = adminsManager;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetAllAdmins()
        {
            var admins = _adminsProvider.GetAdmins();
            return Ok(new AdminsListResponse()
            {
                Admins = admins.ToList()
            });
        }

        [HttpGet]
        [Route("filter")]
        public IActionResult GetFilteredAdmins([FromQuery] AdminsFilter filter)
        {
            var admins = _adminsProvider.GetAdmins(_mapper.Map<AdminModelFilter>(filter));
            return Ok(new AdminsListResponse()
            {
                Admins = admins.ToList()
            });
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAdminInfo([FromRoute] Guid id)
        {
            try
            {
                var admin = _adminsProvider.GetAdminInfo(id);
                return Ok(admin);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex.ToString());
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateAdmin([FromBody] CreateAdminRequest request)
        {
            try
            {
                var admin = _adminsManager.CreateAdmin(_mapper.Map<CreateAdminModel>(request));
                return Ok(admin);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateAdminInfo([FromRoute] Guid id, UpdateAdminRequest request)
        {
            try
            {
                var admin = _adminsManager.UpdateAdmin(id, _mapper.Map<UpdateAdminModel>(request));
                return Ok(admin);
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
        public IActionResult DeleteAdmin([FromRoute] Guid id)
        {
            try
            {
                _adminsManager.DeleteAdmin(id);
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
