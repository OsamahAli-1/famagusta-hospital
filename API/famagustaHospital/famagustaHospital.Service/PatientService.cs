using AutoMapper;
using famagustaHospital.Contracts;
using famagustaHospital.Entities.Models;
using famagustaHospital.ServiceContracts;
using famagustaHospital.Shared.DataTransferObject.PatientUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Service
{
    public class PatientService:IPatientService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public PatientService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<PatientUserDto> CreatePatientAsync(PatientUser patientUser)
        {
            _repository.Patient.CreatePatient(patientUser);
            await _repository.SaveAsync();
            var patientToReturn = _mapper.Map<PatientUserDto>(patientUser);
            return patientToReturn;
        }
    }
}
