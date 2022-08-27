using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Shared.DataTransferObject.Session;

public record SessionUpdateDto
{
    public string? Diagnostic { get; set; }
    public string? Status { get; set; }
   
}
