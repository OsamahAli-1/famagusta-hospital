﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Shared.DataTransferObject.DoctorUser.DoctorAvailability
{
    public record DoctorAvailabilityCreationDto
    {
        public DoctorAvailabilityCreationDto()
        {
            IsAvailable = true;
        }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public bool IsAvailable { get; set; }

    }
}
