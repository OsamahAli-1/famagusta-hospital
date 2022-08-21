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
        Task<PatientUserDto> CreatePatientAsync(PatientUser patientUser);
    }
}
