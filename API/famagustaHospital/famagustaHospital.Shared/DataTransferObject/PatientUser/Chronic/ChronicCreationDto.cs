using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Shared.DataTransferObject.PatientUser.Chronic
{
    public record ChronicCreationDto
    {
        public string DiseaseName { get; set; }
        public DateTime DiagnosedOn { get; set; }
    }
}
