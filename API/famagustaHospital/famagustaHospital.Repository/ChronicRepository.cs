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
    public class ChronicRepository:RepositoryBase<Chronic>,IChronicRepository
    {
        public ChronicRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public void CreateChronic(Chronic chronic) => Create(chronic);
        public void DeleteChronic(Chronic chronic) => Delete(chronic);
        public async Task<Chronic> GetChronicAsync(Guid chronicId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(chronicId), trackChanges).SingleOrDefaultAsync();
    }
}
