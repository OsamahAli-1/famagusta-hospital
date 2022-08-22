﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.ServiceContracts;
public interface IServiceManager
{
    ISystemUserService SystemUserService { get; }
    IAuthenticationService AuthenticationService { get; }
    IPatientAuthenticationService PatientAuthenticationService { get; }
    IDoctorAuthenticationService DoctorAuthenticationService { get; }
    IPatientService PatientService { get; }
   
    //IEntityService EntityService { get; }

}

