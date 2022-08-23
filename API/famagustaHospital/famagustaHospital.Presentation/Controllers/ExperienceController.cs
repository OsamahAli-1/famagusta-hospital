using famagustaHospital.ServiceContracts;
using famagustaHospital.Shared.DataTransferObject.DoctorUser.Experience;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Presentation.Controllers
{
    [Route("api/doctors/{id}")]
    [ApiController]
    [Authorize]
    public class ExperienceController:ControllerBase
    {
        private readonly IServiceManager _service;
        public ExperienceController(IServiceManager service)
        {
            _service = service;
        }
        [HttpPost("experience")]
        [Authorize(Roles ="Doctor")]
        public async Task<IActionResult> CreateExperience(string id, ExperienceCreationDto experienceForCreation)
        {
            var doctor = _service.DoctorService.GetDoctor(id, trackChanges: false);
            var createdExperience = await _service.ExperienceService.CreateExperience(doctor.Id,experienceForCreation);
            return Ok(createdExperience);
        }

    }
}
