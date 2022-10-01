using famagustaHospital.Shared.DataTransferObject.PatientUser.Chronic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Shared.DataTransferObject.PatientUser
{
    public record PatientUserDto
    {
        public Guid Id { get; set; }
        public string? MedicalNumber { get; set; }
        public string? Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public float? Length { get; set; }
        public float? Weight { get; set; }
        public string systemUserId { get; set; }
        public UserViewDto UserViewDto { get; set; }
        public ICollection<ChronicDto> ChronicDtos{get; set;}
    }
}
