using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Entities.Models
{
    public class Session
    {
        public Guid Id { get; set; }
        public string? Diagnostic { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string Status { get; set; }
        public ICollection<Medicine>? medicines { get; set; }
        public Guid PatientUserId { get; set; }
        public PatientUser PatientUser { get; set; }
        public Guid DoctorUserId { get; set; }
        public DoctorUser DoctorUser { get; set; }
    }
}
