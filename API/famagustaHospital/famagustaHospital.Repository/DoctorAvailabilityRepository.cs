using famagustaHospital.Contracts;
using famagustaHospital.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Repository
{
    public class DoctorAvailabilityRepository:RepositoryBase<DoctorAvailability>,IDoctorAvailabilityRepository
    {
        public DoctorAvailabilityRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public void CreateDoctorAvailability(DoctorAvailability doctorAvailability) => Create(doctorAvailability);
        public async Task<DoctorAvailability> GetDoctorAvailabilityAsync(Guid doctorAvailabilityId, bool trackChanges) =>
            await FindByCondition(a => a.Id.Equals(doctorAvailabilityId), trackChanges).SingleOrDefaultAsync();
        public DoctorAvailability GetDoctorAvailability(Guid doctorAvailabilityId, bool trackChanges) =>
            FindByCondition(a => a.Id.Equals(doctorAvailabilityId), trackChanges).SingleOrDefault();
    }
}
