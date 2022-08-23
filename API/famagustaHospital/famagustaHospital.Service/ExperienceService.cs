using AutoMapper;
using famagustaHospital.Contracts;
using famagustaHospital.Entities.Models;
using famagustaHospital.ServiceContracts;
using famagustaHospital.Shared.DataTransferObject.DoctorUser.Experience;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Service
{
    public class ExperienceService:IExperienceService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public ExperienceService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<ExperienceDto> CreateExperience(Guid doctorId,ExperienceCreationDto experienceForCreation)
        {
            var experienceEntity = _mapper.Map<Experience>(experienceForCreation);
            experienceEntity.DoctorUserId= doctorId;
            _repository.Experience.CreateExperience(experienceEntity);
            await _repository.SaveAsync();
            var experienceToReturn = _mapper.Map<ExperienceDto>(experienceEntity);
            return experienceToReturn;
        }
    }
}
