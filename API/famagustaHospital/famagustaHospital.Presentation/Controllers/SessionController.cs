﻿using famagustaHospital.ServiceContracts;
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
            var patient = _service.PatientService.GetPatient(id, trackChanges: false);
            var sessionForCreation = new SessionCreationDto{ 
                CreatedOn = DateTime.Now,
                StartAt = doctorAvailability.StartAt,
                EndAt = doctorAvailability.EndAt,
                DoctorUserId = doctorAvailability.DoctorUserId,
                PatientUserId = patient.Id,
                Status = "Reserved"
            };
            var createdSession = await _service.SessionService.CreateSession(sessionForCreation);
            return Ok(createdSession);
        }
    }
}
