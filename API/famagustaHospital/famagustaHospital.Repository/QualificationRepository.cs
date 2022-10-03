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
    public class QualificationRepository : RepositoryBase<Qualification>, IQualificationRepository
    {
        public QualificationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public void CreateQualification(Qualification qualification) => Create(qualification);
        public async Task<Qualification> GetQualificationAsync(Guid qualificationId, bool trackChanges) =>
            await FindByCondition(q => q.Id.Equals(qualificationId), trackChanges).SingleOrDefaultAsync();
        public void DeleteQualification(Qualification qualification) => Delete(qualification);
    }
}
