using famagustaHospital.Contracts;
using famagustaHospital.Entities.Models;
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
        public void CreatePatient(DoctorUser doctorUser) => Create(doctorUser);
    }
}
