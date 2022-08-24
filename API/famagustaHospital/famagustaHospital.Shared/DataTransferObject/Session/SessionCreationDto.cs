using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Shared.DataTransferObject.Session
{
    public record SessionCreationDto
    {
        public DateTime CreatedOn { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string Status { get; set; }
        public Guid PatientUserId { get; set; }
        public Guid DoctorUserId { get; set; }
    }
}
