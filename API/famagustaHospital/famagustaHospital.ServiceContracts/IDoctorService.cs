using famagustaHospital.Shared.DataTransferObject.DoctorUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.ServiceContracts
{
    public interface IDoctorService
    {
        Task<DoctorUserDto> GetDoctorAsync(string userId, bool trackChanges);
        DoctorUserDto GetDoctor(string userId, bool trackChanges);
    }
}
