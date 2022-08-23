using famagustaHospital.Contracts;
using famagustaHospital.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Repository
{
    public class ExperienceRepository:RepositoryBase<Experience>,IExperienceRepository
    {
        public ExperienceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public void CreateExperience(Experience experience)=>Create(experience);
    }
}
