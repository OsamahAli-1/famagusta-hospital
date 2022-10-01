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
    public class DoctorRepository: RepositoryBase<DoctorUser>, IDoctorRepository
    {
        public DoctorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public void CreateDoctor(DoctorUser doctorUser) => Create(doctorUser);
        public async Task<DoctorUser> GetDoctorAsync(string userId, bool trackChanges)=>
            await FindByCondition(d => d.systemUserId.Equals(userId), trackChanges)
            .Include(x => x.systemUser)
            .Include(x => x.experiences)
            .Include(x => x.qualifications)
            .SingleOrDefaultAsync();
        public DoctorUser GetDoctor(string userId, bool trackChanges) =>
            FindByCondition(d => d.systemUserId.Equals(userId), trackChanges)
            .Include(x => x.systemUser)
            .Include(x => x.experiences)
            .Include(x => x.qualifications)
            .SingleOrDefault();
        public async Task<IEnumerable<DoctorUser>> GetAllDoctorsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .Include(x=>x.systemUser)
            .Include(x=>x.experiences)
            .Include(x=>x.qualifications)
            .ToListAsync();

    }
}
