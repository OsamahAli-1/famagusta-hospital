using famagustaHospital.ServiceContracts;
using famagustaHospital.Shared.DataTransferObject.Session.Medicine;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Presentation.Controllers;

[Route("api/doctors/{id}")]
[ApiController]
[Authorize]
public class MedicineController:ControllerBase
{
    private readonly IServiceManager _service;

    public MedicineController(IServiceManager service)
    {
        _service = service;
    }
    [HttpPost("sessions/{sessionId}")]
    [Authorize(Roles ="Doctor")]
    public async Task<IActionResult> CreateMedicine(Guid sessionId, [FromBody] MedicineCreationDto medicineForCreation)
    {
        var createdMedicine = await _service.MedicineService.CreateMedicine(sessionId, medicineForCreation);
        return Ok(createdMedicine);
    }

}
