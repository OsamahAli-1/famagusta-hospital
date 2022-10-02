using AutoMapper;
using famagustaHospital.Contracts;
using famagustaHospital.Entities.Models;
using famagustaHospital.ServiceContracts;
using famagustaHospital.Shared.DataTransferObject.PatientUser.Chronic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Service
{
    public class ChronicService:IChronicService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public ChronicService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<ChronicDto> CreateChronic(Guid patientId,ChronicCreationDto chronicForCreation)
        {
            var chronicEntity = _mapper.Map<Chronic>(chronicForCreation);
            chronicEntity.PatientUserId = patientId;
            _repository.Chronic.CreateChronic(chronicEntity);
            await _repository.SaveAsync();

            var chronicToReturn = _mapper.Map<ChronicDto>(chronicEntity);
            return chronicToReturn;
        }
        public async Task DeleteChronicAsync(Guid chronicId, bool trackChanges)
        {
            var chronic = await _repository.Chronic.GetChronicAsync(chronicId, trackChanges);
            _repository.Chronic.DeleteChronic(chronic);
            await _repository.SaveAsync();
        }
    }
}
