using famagustaHospital.ServiceContracts;
using famagustaHospital.Shared.DataTransferObject.DoctorUser.Qualification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Presentation.Controllers
{
    [Route("api/doctors/")]
    [ApiController]
    [Authorize]
    public class QualificationController:ControllerBase
    {
        private readonly IServiceManager _service;
        public QualificationController(IServiceManager service)
        {
            _service = service;
        }
        [HttpPost("{id}/qualifications")]
        [Authorize(Roles ="Doctor")]
        public async Task<IActionResult> CreateQualification(string id, [FromBody] QualificationCreationDto qualificationForCreation)
        {
            var doctor = _service.DoctorService.GetDoctor(id, trackChanges: false);
            var createdQualification =await _service.QualificationService.CreateQualification(doctor.Id, qualificationForCreation);
            return Ok(createdQualification);
        }

        [HttpDelete("{id}/qualifications/{qualificationId}")]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> DeleteQualification(string id, Guid qualificationId)
        {
            await _service.QualificationService.DeleteQualificationAsync(qualificationId, trackChanges: false);
            return NoContent();
        }
    }
}
