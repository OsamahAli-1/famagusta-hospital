using famagustaHospital.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Contracts;

public interface IMedicineRepository
{
    void CreateMedicine(Medicine medicine);
    void DeleteMedicine(Medicine medicine);
    Task<Medicine> GetMedicineAsync(Guid medicineId,bool trackChanges);
}
