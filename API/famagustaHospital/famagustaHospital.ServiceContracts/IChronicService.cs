using famagustaHospital.Shared.DataTransferObject.PatientUser.Chronic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.ServiceContracts
{
    public interface IChronicService
    {
        Task<ChronicDto> CreateChronic(Guid patientId,ChronicCreationDto chronicForCreation);
        Task DeleteChronicAsync(Guid chronicId,bool trackChanges);
    }
}
