using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Shared.DataTransferObject.DoctorUser
{
    public record DoctorUserDto
    {
        public Guid Id { get; set; }
        public string? StaffNumber { get; set; }
        public string? Department { get; set; }
        public string? Position { get; set; }
        public string systemUserId { get; set; }
    }
}
