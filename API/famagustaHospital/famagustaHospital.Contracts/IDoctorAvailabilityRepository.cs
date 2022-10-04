using famagustaHospital.Entities.Models;
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
        Task<DoctorAvailability> GetDoctorAvailabilityAsync(Guid doctorAvailabilityId, bool trackChanges);
        Task<IEnumerable<DoctorAvailability>> GetDoctorAvailabilitesOfDoctorAsync(Guid doctorId, bool trackChanges);
        DoctorAvailability GetDoctorAvailability(Guid doctorAvailabilityId, bool trackChanges);
        void DeleteDoctorAvailability(DoctorAvailability doctorAvailability);
    }
}
