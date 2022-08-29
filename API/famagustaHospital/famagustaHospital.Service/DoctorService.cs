using AutoMapper;
using famagustaHospital.Contracts;
using famagustaHospital.ServiceContracts;
using famagustaHospital.Shared.DataTransferObject.DoctorUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Service
{
    public class DoctorService:IDoctorService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public DoctorService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<DoctorUserDto> GetDoctorAsync(string userId, bool trackChanges)
        {
            var doctorEntity = await _repository.Doctor.GetDoctorAsync(userId, trackChanges);
            var doctorToReturn = _mapper.Map<DoctorUserDto>(doctorEntity);
            return doctorToReturn;
        }
        public DoctorUserDto GetDoctor(string userId, bool trackChanges)
        {
            var doctorEntity = _repository.Doctor.GetDoctor(userId, trackChanges);
            var doctorToReturn = _mapper.Map<DoctorUserDto>(doctorEntity);
            return doctorToReturn;
        }
        public async Task<IEnumerable<DoctorUserDto>> GetAllDoctorsAsync(bool trackChanges)
        {
            var doctorsEntities = await _repository.Doctor.GetAllDoctorsAsync(trackChanges);
            var doctorsToReturn = _mapper.Map<IEnumerable<DoctorUserDto>>(doctorsEntities);
            return doctorsToReturn;
        }
    }
}
