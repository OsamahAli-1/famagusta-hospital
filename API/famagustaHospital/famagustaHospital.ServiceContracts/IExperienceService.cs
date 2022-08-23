using famagustaHospital.Shared.DataTransferObject.DoctorUser.Experience;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.ServiceContracts
{
    public interface IExperienceService
    {
        Task<ExperienceDto> CreateExperience(Guid doctorId, ExperienceCreationDto experienceForCreation);
    }
}
