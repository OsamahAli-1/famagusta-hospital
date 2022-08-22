using famagustaHospital.Entities.Models;
using famagustaHospital.Shared.DataTransferObject.PatientUser;
using famagustaHospital.Shared.DataTransferObject.PatientUser.Chronic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Contracts
{
    public interface IPatientRepository
    {
        void CreatePatient(PatientUser patientUser);
        Task<PatientUser> GetPatientAsync(string userId,bool trackChanges);
        PatientUser GetPatient(string userId, bool trackChanges);
    }
}
