using AutoMapper;
using famagustaHospital.Contracts;
using famagustaHospital.Entities.Models;
using famagustaHospital.ServiceContracts;
using famagustaHospital.Shared.DataTransferObject.DoctorUser.Qualification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Service
{
    public class QualificationService:IQualificationService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public QualificationService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<QualificationDto> CreateQualification(Guid doctorId, QualificationCreationDto qualificationForCreation)
        {
            var qualificationEntity = _mapper.Map<Qualification>(qualificationForCreation);
            qualificationEntity.DoctorUserId = doctorId;
            _repository.Qualification.CreateQualification(qualificationEntity);
            await _repository.SaveAsync();
            var qualificationToReturn = _mapper.Map<QualificationDto>(qualificationEntity);
            return qualificationToReturn;
        }
    }
}
