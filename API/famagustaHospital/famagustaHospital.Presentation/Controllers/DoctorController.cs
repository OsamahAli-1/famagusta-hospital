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
using famagustaHospital.Contracts;

namespace famagustaHospital.Presentation.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly IRepositoryManager _repository;
        public DoctorController(IServiceManager service,IRepositoryManager repository)
        {
            _service = service;
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDoctorsAsync()
        {
            //var doctors = await _repository.Doctor.GetAllDoctorsAsync(trackChanges: false);
            var doctors = await _service.DoctorService.GetAllDoctorsAsync(trackChanges: false);
            return Ok(doctors);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorAsync(string id)
        {
            //var doctors = await _repository.Doctor.GetAllDoctorsAsync(trackChanges: false);
            var doctor = await _service.DoctorService.GetDoctorAsync(id,trackChanges: false);
            return Ok(doctor);
        }




    }
}
