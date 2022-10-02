using famagustaHospital.ServiceContracts;
using famagustaHospital.Shared.DataTransferObject.PatientUser.Chronic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Presentation.Controllers
{
    [Route("api/patient/{id}")]
    [ApiController]
    [Authorize]
    public class ChronicController: ControllerBase
    {
        private readonly IServiceManager _service;

        public ChronicController(IServiceManager service)
        {
            _service = service;
        }
        [HttpPost("chronic")]
        public async Task<IActionResult> CreateChronic(string id, [FromBody] ChronicCreationDto chronicForCreation)
        {
            var patient = _service.PatientService.GetPatient(id, trackChanges: false);
            var createdChronic = await _service.ChronicService.CreateChronic(patient.Id, chronicForCreation);
            return Ok(createdChronic);
        }
        [HttpDelete("chronic/{chronicId}")]
        public async Task<IActionResult> DeleteChronic(string id,Guid chronicId)
        {
            await _service.ChronicService.DeleteChronicAsync(chronicId, trackChanges: false);
            return NoContent();
        }
    }
}
