using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Presentation.Controllers
{
    [Route("api")]
    public class DoctorsController: ControllerBase
    {
        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Content("This hospital app");
        }
    }
}
