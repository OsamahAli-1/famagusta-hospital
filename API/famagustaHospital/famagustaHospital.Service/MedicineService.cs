using AutoMapper;
using famagustaHospital.Contracts;
using famagustaHospital.Entities.Models;
using famagustaHospital.ServiceContracts;
using famagustaHospital.Shared.DataTransferObject.Session.Medicine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Service;

public class MedicineService:IMedicineService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    public MedicineService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }
    public async Task<MedicineDto> CreateMedicine(Guid sessionId, MedicineCreationDto medicineForCreation)
    {
        var medicineEntity = _mapper.Map<Medicine>(medicineForCreation);
        medicineEntity.SessionId = sessionId;
        _repository.Medicine.CreateMedicine(medicineEntity);
        await _repository.SaveAsync();
        var medicineToReturn = _mapper.Map<MedicineDto>(medicineEntity);
        return medicineToReturn;
    }
    public async Task DeleteMedicineAsync(Guid medicineId,bool trackChanges)
    {
        var medicine = await _repository.Medicine.GetMedicineAsync(medicineId, trackChanges);
        _repository.Medicine.DeleteMedicine(medicine);
        await _repository.SaveAsync();
    }
}
