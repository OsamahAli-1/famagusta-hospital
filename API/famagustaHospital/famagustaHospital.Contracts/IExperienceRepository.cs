﻿using famagustaHospital.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Contracts
{
    public interface IExperienceRepository
    {
        void CreateExperience(Experience experience);
        void DeleteExperience(Experience experience);
        Task<Experience> GetExperienceAsync(Guid experienceId, bool trackChanges);
    }
}
