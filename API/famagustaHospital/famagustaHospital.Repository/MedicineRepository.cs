using famagustaHospital.Contracts;
using famagustaHospital.Entities.Models;
using Microsoft.EntityFrameworkCore;
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
    public void DeleteMedicine(Medicine medicine) => Delete(medicine);
    public async Task<Medicine> GetMedicineAsync(Guid medicineId, bool trackChanges) =>
        await FindByCondition(m => m.Id.Equals(medicineId), trackChanges).SingleOrDefaultAsync();
}
