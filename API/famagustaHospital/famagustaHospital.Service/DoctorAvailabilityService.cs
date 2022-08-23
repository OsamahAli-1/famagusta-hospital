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
    }
}
