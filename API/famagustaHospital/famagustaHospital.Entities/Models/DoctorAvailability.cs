using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Entities.Models
{
    public class DoctorAvailability
    {
        public Guid Id { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public Guid DoctorUserId { get; set; }
        public DoctorUser DoctorUser { get; set; }
    }
}
