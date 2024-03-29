﻿using famagustaHospital.Shared.DataTransferObject.DoctorUser.Experience;
using famagustaHospital.Shared.DataTransferObject.DoctorUser.Qualification;
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
        public string? Name { get; set; }
        public string? StaffNumber { get; set; }
        public string? Department { get; set; }
        public string? Position { get; set; }
        public string systemUserId { get; set; }
        public UserViewDto UserViewDto { get; set; }
        public ICollection<ExperienceDto> ExperienceDtos { get; set; }
        public ICollection<QualificationDto> QualificationDtos { get; set; }
      
    }
}
