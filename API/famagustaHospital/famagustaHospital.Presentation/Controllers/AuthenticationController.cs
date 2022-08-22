using famagustaHospital.Entities.Models;
using famagustaHospital.ServiceContracts;
using famagustaHospital.Shared.DataTransferObject;
using famagustaHospital.Shared.DataTransferObject.PatientUser;
using famagustaHospital.Shared.DataTransferObject.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Presentation.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;
        public AuthenticationController(IServiceManager service) => _service = service;

        [HttpPost("patient")]
        public async Task<IActionResult> RegisterPatient([FromBody] PatientUserCreationDto patientUserForCreation)
        {
            var result = await _service.PatientAuthenticationService.RegisterUser(patientUserForCreation);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }
        [HttpPost("doctor")]
        public async Task<IActionResult> RegisterDoctor([FromBody] DoctorUserCreationDto doctorUserForCreation)
        {
            var result = await _service.DoctorAuthenticationService.RegisterUser(doctorUserForCreation);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }


    }
}
