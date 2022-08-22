using famagustaHospital.Entities.Models;
using famagustaHospital.Shared.DataTransferObject.PatientUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.ServiceContracts
{
    public interface IPatientService
    {
        Task<PatientUserDto> GetPatientAsync(string userId,bool trackChanges);
        PatientUserDto GetPatient(string userId,bool trackChanges);
    }
}
