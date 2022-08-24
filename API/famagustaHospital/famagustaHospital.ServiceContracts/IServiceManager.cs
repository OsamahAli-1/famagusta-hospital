using System;
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
    IChronicService ChronicService { get; }
    IDoctorService DoctorService { get; }
    IQualificationService QualificationService { get; }
    IExperienceService ExperienceService { get; }
    IDoctorAvailabilityService DoctorAvailabilityService { get; }
    ISessionService SessionService { get; }

    //IEntityService EntityService { get; }

}

