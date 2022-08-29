using famagustaHospital.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Contracts
{
    public interface IDoctorRepository
    {
        void CreateDoctor(DoctorUser doctorUser);
        Task<DoctorUser> GetDoctorAsync(string userId, bool trackChanges);
        DoctorUser GetDoctor(string userId, bool trackChanges);
        Task<IEnumerable<DoctorUser>> GetAllDoctorsAsync(bool trackChanges);
    }
}
