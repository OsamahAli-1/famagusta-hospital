using famagustaHospital.ServiceContracts;
using famagustaHospital.Shared.DataTransferObject.DoctorUser.DoctorAvailability;
using famagustaHospital.Shared.DataTransferObject.Session;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Presentation.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    [Authorize]
    public class DoctorAvailabilityController:ControllerBase
    {
        private readonly IServiceManager _service;

        public DoctorAvailabilityController(IServiceManager service)
        {
            _service = service;
        }
        [HttpPost("{id}/availabilities")]
        public async Task<IActionResult> CreateDoctorAvailability(string id,DoctorAvailabilityCreationDto doctorAvailabilityForCreation)
        {
            var doctor = _service.DoctorService.GetDoctor(id, trackChanges: false);
            var createdDoctorAvailability = await _service.DoctorAvailabilityService.CreateDoctorAvailability(doctor.Id, doctorAvailabilityForCreation);
            return Ok(createdDoctorAvailability);
        }
        [HttpGet("{id}/availabilities")]
        public async Task<IActionResult> GetDoctorAvailabilitesOfDoctorAsync(string id)
        {
            var doctor = _service.DoctorService.GetDoctor(id, trackChanges: false);
            var doctorAvailabilities = await _service.DoctorAvailabilityService.GetDoctorAvailabilitesOfDoctorAsync(doctor.Id, trackChanges: false);
            return Ok(doctorAvailabilities);
        }
        [HttpDelete("{id}/availabilities/{availabilityId}")]
        public async Task<IActionResult> DeleteDoctorAvailability(string id,Guid availabilityId)
        {
            await _service.DoctorAvailabilityService.DeleteDoctorAvailability(availabilityId, trackChanges: false);
            var session = _service.SessionService.GetSessionByAvailabilityId(availabilityId, trackChanges: false);
            if(session != null)
            {
                var sessionCancel = new SessionCancelDto
                {
                    Status = "cancelled - doctor not available"
                };
                await _service.SessionService.CancelSessionAsync(session.Id, sessionCancel, trackChanges: true);
            }
            return NoContent();
        }

    }
}
