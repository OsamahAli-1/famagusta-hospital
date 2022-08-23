﻿using famagustaHospital.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Contracts
{
    public interface IDoctorAvailabilityRepository
    {
        void CreateDoctorAvailability(DoctorAvailability doctorAvailability);
    }
}