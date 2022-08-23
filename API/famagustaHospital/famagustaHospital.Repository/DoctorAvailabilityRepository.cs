using famagustaHospital.Contracts;
using famagustaHospital.Entities.Models;
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
    }
}
