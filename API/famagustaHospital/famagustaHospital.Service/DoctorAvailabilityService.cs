using AutoMapper;
using famagustaHospital.Contracts;
using famagustaHospital.Entities.Models;
using famagustaHospital.ServiceContracts;
using famagustaHospital.Shared.DataTransferObject.DoctorUser.DoctorAvailability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Service
{
    public class DoctorAvailabilityService: IDoctorAvailabilityService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public DoctorAvailabilityService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<DoctorAvailabilityDto> CreateDoctorAvailability(Guid doctorId,DoctorAvailabilityCreationDto doctorAvailabilityForCreation)
        {
            var doctorAvailabilityEntity = _mapper.Map<DoctorAvailability>(doctorAvailabilityForCreation);
            doctorAvailabilityEntity.DoctorUserId = doctorId;
            _repository.DoctorAvailability.CreateDoctorAvailability(doctorAvailabilityEntity);
            await _repository.SaveAsync();
            var doctorAvailabilityToReturn = _mapper.Map<DoctorAvailabilityDto>(doctorAvailabilityEntity);
            return doctorAvailabilityToReturn;
        }
        public async Task<DoctorAvailabilityDto> GetDoctorAvailabilityAsync(Guid doctorAvailabilityId, bool trackChanges)
        {
            var doctorAvailabilityEntity = await _repository.DoctorAvailability.GetDoctorAvailabilityAsync(doctorAvailabilityId,trackChanges);
            var doctorAvailabilityToReturn = _mapper.Map<DoctorAvailabilityDto>(doctorAvailabilityEntity);
            return doctorAvailabilityToReturn;
        }
        public DoctorAvailabilityDto GetDoctorAvailability(Guid doctorAvailabilityId, bool trackChanges)
        {
            var doctorAvailabilityEntity = _repository.DoctorAvailability.GetDoctorAvailability(doctorAvailabilityId, trackChanges);
            var doctorAvailabilityToReturn = _mapper.Map<DoctorAvailabilityDto>(doctorAvailabilityEntity);
            return doctorAvailabilityToReturn;
        }
        public async Task UpdateDoctorAvailabilityAsync(Guid doctorAvailabilityId, DoctorAvailabilityUpdateDto doctorAvailabilityForUpdate, bool trackChanges)
        {
            var doctorAvailabilityEntity = await _repository.DoctorAvailability.GetDoctorAvailabilityAsync(doctorAvailabilityId, trackChanges);
            _mapper.Map(doctorAvailabilityForUpdate, doctorAvailabilityEntity);
            await _repository.SaveAsync();
        }
        public async Task<IEnumerable<DoctorAvailabilityDto>> GetDoctorAvailabilitesOfDoctorAsync(Guid doctorId, bool trackChanges)
        {
            var doctorAvailabilitiesEntities = await _repository.DoctorAvailability.GetDoctorAvailabilitesOfDoctorAsync(doctorId, trackChanges);
            var doctorAvailabilitiesToReturn = _mapper.Map<IEnumerable<DoctorAvailabilityDto>>(doctorAvailabilitiesEntities);
            return doctorAvailabilitiesToReturn;
        }
    }
}
