using famagustaHospital.ServiceContracts;
using famagustaHospital.Shared.DataTransferObject.PatientUser.Chronic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using famagustaHospital.Entities.Models;

namespace famagustaHospital.Presentation.Controllers
{
    [Route("api/patient/{id}")]
    [ApiController]
    [Authorize(Roles ="Patient")]
    public class PatientController : ControllerBase
    {
        private readonly IServiceManager _service;
        
        public PatientController(IServiceManager service, UserManager<SystemUser> manager)
        {
            _service = service;
        }
        

        [HttpPost("chronic")]
        public async Task<IActionResult> CraeteChronic(string id,[FromBody] ChronicCreationDto chronicForCreation) 
        { 
            var patient = _service.PatientService.GetPatient(id, trackChanges: false);
            var createdChronic = await _service.ChronicService.CreateChronic(patient.Id, chronicForCreation);
            return Ok(createdChronic);
        }

    }
}
