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
    [Route("api/patients")]
    [ApiController]
    //[Authorize]
    public class PatientController : ControllerBase
    {
        private readonly IServiceManager _service;
        
        public PatientController(IServiceManager service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientAsync(string id)
        {
            var patient = await _service.PatientService.GetPatientAsync(id,trackChanges: false);
            return Ok(patient);
        }


    }
}
