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
    [Route("api")]
    [ApiController]
    [Authorize]
    public class SessionController:ControllerBase
    {
        private readonly IServiceManager _service;
        public SessionController(IServiceManager service)
        {
            _service = service;
        }
        [HttpPost("{id}/{availabilityId}/sessions")]
        [Authorize(Roles ="Patient")]
        public async Task<IActionResult> CreateSession(string id,Guid availabilityId)
        {
            var doctorAvailability = _service.DoctorAvailabilityService.GetDoctorAvailability(availabilityId, trackChanges: false);
            if(doctorAvailability.IsAvailable == false)
            {
                return Content("doctor not available");
            }
            var patient = _service.PatientService.GetPatient(id, trackChanges: false);
            var sessionForCreation = new SessionCreationDto{ 
                CreatedOn = DateTime.Now,
                StartAt = doctorAvailability.StartAt,
                EndAt = doctorAvailability.EndAt,
                DoctorUserId = doctorAvailability.DoctorUserId,
                PatientUserId = patient.Id,
                DoctorAvailabilityId = doctorAvailability.Id,
                Status = "Reserved",
            };
            var createdSession = await _service.SessionService.CreateSession(sessionForCreation);
            var doctorAvailabilityForUpdate = new DoctorAvailabilityUpdateDto
            {
                StartAt = doctorAvailability.StartAt,
                EndAt= doctorAvailability.EndAt,
                IsAvailable = false
            };
            await _service.DoctorAvailabilityService.UpdateDoctorAvailabilityAsync(doctorAvailability.Id, doctorAvailabilityForUpdate, trackChanges: true);
            return Ok(createdSession);
        }
        [Authorize(Roles = "Doctor")]
        [HttpPut("{id}/sessions/{sessionId}")]
        public async Task<IActionResult> UpdateSession(string id,Guid sessionId, [FromBody] SessionUpdateDto sessionForUpdate)
        {
            await _service.SessionService.UpdateSessionAsync(sessionId,sessionForUpdate,trackChanges: true);
            return StatusCode(201);
        }
        [HttpPut("{id}/sessions/{sessionId}/cancel")]
        public async Task<IActionResult> CancelSession(string id, Guid sessionId)
        {
            var sessionCancel = new SessionCancelDto
            {
                Status = "cancelled"
            };
            await _service.SessionService.CancelSessionAsync(sessionId, sessionCancel, trackChanges: true);
            return StatusCode(201);
        }
        [HttpGet("{id}/sessions")]
        public async Task<IActionResult> GetUserSessions(string id)
        {
            var user = await _service.SystemUserService.GetUserAsync(id, trackChanges: false);
            if (user.Role.Equals("Patient")){
                var patient = _service.PatientService.GetPatient(id, trackChanges: false);
                var patientSessions = await _service.SessionService.GetPatientSessionsAsync(patient.Id, trackChanges: false);
                return Ok(patientSessions);
            }
            else if(user.Role.Equals("Doctor"))
            {
                var doctor = _service.DoctorService.GetDoctor(id, trackChanges: false);
                var doctorSessions = await _service.SessionService.GetDoctorSessionsAsync(doctor.Id, trackChanges: false);
                return Ok(doctorSessions);
            }
            return BadRequest();
            
        }
        
    }
}
