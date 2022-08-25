using famagustaHospital.Contracts;
using famagustaHospital.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Repository;

public class MedicineRepository : RepositoryBase<Medicine>, IMedicineRepository
{
    public MedicineRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
    public void CreateMedicine(Medicine medicine) => Create(medicine);
}
