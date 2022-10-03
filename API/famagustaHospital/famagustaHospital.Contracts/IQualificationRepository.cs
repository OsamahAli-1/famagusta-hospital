using famagustaHospital.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Contracts
{
    public interface IQualificationRepository
    {
        void CreateQualification(Qualification qualification);
        Task<Qualification> GetQualificationAsync(Guid qualificationId,bool trackChanges);
        void DeleteQualification(Qualification qualification);
    }
}
