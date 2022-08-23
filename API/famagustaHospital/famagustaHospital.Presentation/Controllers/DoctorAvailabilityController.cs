using famagustaHospital.ServiceContracts;
using famagustaHospital.Shared.DataTransferObject.DoctorUser.DoctorAvailability;
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
    public class DoctorAvailabilityController:ControllerBase
    {
        private readonly IServiceManager _service;

        public DoctorAvailabilityController(IServiceManager service)
        {
            _service = service;
        }
        [HttpPost("doctoravailability")]
        public async Task<IActionResult> CreateDoctorAvailability(string id,DoctorAvailabilityCreationDto doctorAvailabilityForCreation)
        {
            var doctor = _service.DoctorService.GetDoctor(id, trackChanges: false);
            var createdDoctorAvailability = await _service.DoctorAvailabilityService.CreateDoctorAvailability(doctor.Id, doctorAvailabilityForCreation);
            return Ok(createdDoctorAvailability);
        }
    }
}
