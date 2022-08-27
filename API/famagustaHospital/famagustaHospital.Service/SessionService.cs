using AutoMapper;
using famagustaHospital.Contracts;
using famagustaHospital.Entities.Models;
using famagustaHospital.ServiceContracts;
using famagustaHospital.Shared.DataTransferObject.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Service
{
    public class SessionService:ISessionService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public SessionService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<SessionDto> CreateSession(SessionCreationDto sessionForCreation)
        {
            var sessionEntity = _mapper.Map<Session>(sessionForCreation);
            _repository.Session.CreateSession(sessionEntity);
            await _repository.SaveAsync();
            var sessionToReturn = _mapper.Map<SessionDto>(sessionEntity);
            return sessionToReturn;
        }
        public async Task UpdateSessionAsync(Guid sessionId, SessionUpdateDto sessionForUpdate, bool trackChanges)
        {
            var sessionEntity = await _repository.Session.GetSessionAsync(sessionId, trackChanges);
            _mapper.Map(sessionForUpdate, sessionEntity);
            await _repository.SaveAsync();
        }
        public async Task<SessionDto> GetSessionAsync(Guid sessionId, bool trackChanges)
        {
            var sessionEntity = await _repository.Session.GetSessionAsync(sessionId, trackChanges);
            var sessionToReturn = _mapper.Map<SessionDto>(sessionEntity);
            return sessionToReturn;
        }
        public SessionDto GetSession(Guid sessionId, bool trackChanges)
        {
            var sessionEntity = _repository.Session.GetSession(sessionId, trackChanges);
            var sessionToReturn = _mapper.Map<SessionDto>(sessionEntity);
            return sessionToReturn;
        }
    }
}
