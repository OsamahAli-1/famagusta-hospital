﻿using famagustaHospital.Shared.DataTransferObject.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.ServiceContracts
{
    public interface ISessionService
    {
        Task<SessionDto> CreateSession(SessionCreationDto sessionForCreation);
        Task UpdateSessionAsync(Guid sessionId,SessionUpdateDto sessionForUpdate,bool trackChanges);
        Task<SessionDto> GetSessionAsync(Guid sessionId, bool trackChanges);
        SessionDto GetSession(Guid sessionId, bool trackChanges);
    }
}
