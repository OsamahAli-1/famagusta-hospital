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
    public class ExperienceRepository : RepositoryBase<Experience>, IExperienceRepository
    {
        public ExperienceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public void CreateExperience(Experience experience) => Create(experience);
        public void DeleteExperience(Experience experience) => Delete(experience);
        public async Task<Experience> GetExperienceAsync(Guid experienceId, bool trackChanges) =>
            await FindByCondition(e => e.Id.Equals(experienceId), trackChanges).SingleOrDefaultAsync();
    }
}
