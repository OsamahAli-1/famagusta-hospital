using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Shared.DataTransferObject.PatientUser.Chronic
{
    public record ChronicDto
    {
        public Guid Id { get; init; }
        public string DiseaseName { get; init; }
        public DateTime DiagnosedOn { get; init; }
    }
}
