using famagustaHospital.Contracts;
using famagustaHospital.Entities.Models;
using famagustaHospital.Shared.DataTransferObject.PatientUser;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Repository
{
    public class PatientRepository: RepositoryBase<PatientUser>,IPatientRepository
    {
        public PatientRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public void CreatePatient(PatientUser patientUser) => Create(patientUser);
        public async Task<PatientUser> GetPatientAsync(string userId, bool trackChanges) =>
            await FindByCondition(p => p.systemUserId.Equals(userId), trackChanges).SingleOrDefaultAsync();
        public PatientUser GetPatient(string userId, bool trackChanges) =>
            FindByCondition(p => p.systemUserId.Equals(userId), trackChanges).SingleOrDefault();
    }
}
