using famagustaHospital.Shared.DataTransferObject.DoctorUser.Qualification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.ServiceContracts
{
    public interface IQualificationService
    {
        Task<QualificationDto> CreateQualification(Guid doctorId,QualificationCreationDto qualificationForCreation);
        Task DeleteQualificationAsync(Guid qualificationId,bool trackChanges);
    }
}
