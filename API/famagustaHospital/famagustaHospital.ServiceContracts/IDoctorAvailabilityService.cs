using famagustaHospital.Entities.Models;
using famagustaHospital.Shared.DataTransferObject.DoctorUser.DoctorAvailability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.ServiceContracts
{
    public interface IDoctorAvailabilityService
    {
        Task<DoctorAvailabilityDto> CreateDoctorAvailability(Guid doctorId,DoctorAvailabilityCreationDto doctorAvailabilityForCreation);
        Task<DoctorAvailabilityDto> GetDoctorAvailabilityAsync(Guid doctorAvailabilityId,bool trackChanges);
        DoctorAvailabilityDto GetDoctorAvailability(Guid doctorAvailabilityId, bool trackChanges);
        Task UpdateDoctorAvailabilityAsync(Guid doctorAvailabilityId,DoctorAvailabilityUpdateDto doctorAvailabilityForUpdate, bool trackChanges);
        Task<IEnumerable<DoctorAvailabilityDto>> GetDoctorAvailabilitesOfDoctorAsync(Guid doctorId, bool trackChanges);
    }
}
