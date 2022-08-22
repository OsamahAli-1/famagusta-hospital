using famagustaHospital.Contracts;
using famagustaHospital.Entities.Models;
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
    }
}
