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
    }
}
