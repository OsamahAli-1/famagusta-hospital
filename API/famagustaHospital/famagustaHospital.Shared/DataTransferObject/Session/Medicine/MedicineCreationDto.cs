using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Shared.DataTransferObject.Session.Medicine;

public record MedicineCreationDto
{
    public string MedicineName { get; set; }
    public string Instruction { get; set; }
}
