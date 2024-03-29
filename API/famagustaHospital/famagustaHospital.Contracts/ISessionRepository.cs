﻿using famagustaHospital.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Contracts
{
    public interface ISessionRepository
    {
        void CreateSession(Session session);
        Task<Session> GetSessionAsync(Guid sessionId,bool trackChanges);
        Session GetSession(Guid sessionId, bool trackChanges);
        Session GetSessionByAvailabilityId(Guid doctorAvailabilityId, bool trackChanges);
        Task<IEnumerable<Session>> GetPatientSessionsAsync(Guid patientId, bool trackChanges);
        Task<IEnumerable<Session>> GetDoctorSessionsAsync(Guid doctorId, bool trackChanges);

    }
}
