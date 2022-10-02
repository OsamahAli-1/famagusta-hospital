using famagustaHospital.Entities.Models;
using famagustaHospital.Shared.DataTransferObject.PatientUser.Chronic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Contracts
{
    public interface IChronicRepository
    {
        void CreateChronic(Chronic chronic);
        void DeleteChronic(Chronic chronic);
        Task<Chronic> GetChronicAsync(Guid chronicId, bool trackChanges);
    }
}
