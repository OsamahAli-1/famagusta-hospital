using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Contracts;
public interface IRepositoryManager
{
    //IEntityRepository Entity { get; }
    ISystemUserRepository SystemUser { get; }
    IPatientRepository Patient { get; }
    IDoctorRepository Doctor { get; }
    IChronicRepository Chronic { get; }
    IQualificationRepository Qualification { get; }
    IExperienceRepository Experience { get; }
    IDoctorAvailabilityRepository DoctorAvailability { get; }
    ISessionRepository Session { get; }
    Task SaveAsync();

}
