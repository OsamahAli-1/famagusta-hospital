using famagustaHospital.Shared.DataTransferObject.Session.Medicine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.ServiceContracts;

public interface IMedicineService
{
    Task<MedicineDto> CreateMedicine(Guid sessionId,MedicineCreationDto medicineForCreation);
    Task DeleteMedicineAsync(Guid medicineId,bool trackChanges);
}
