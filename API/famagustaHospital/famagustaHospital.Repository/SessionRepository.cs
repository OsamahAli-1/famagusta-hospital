﻿using famagustaHospital.Contracts;
using famagustaHospital.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Repository
{
    public class SessionRepository : RepositoryBase<Session>, ISessionRepository
    {
        public SessionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public void CreateSession(Session session) => Create(session);
        public async Task<Session> GetSessionAsync(Guid sessionId, bool trackChanges) =>
            await FindByCondition(s => s.Id.Equals(sessionId), trackChanges)
            .Include(x=>x.medicines)
            .SingleOrDefaultAsync();
        public Session GetSession(Guid sessionId, bool trackChanges) =>
            FindByCondition(s => s.Id.Equals(sessionId), trackChanges)
            .Include(x => x.medicines)
            .SingleOrDefault();
        public Session GetSessionByAvailabilityId(Guid doctorAvailabilityId, bool trackChanges) =>
            FindByCondition(s => s.DoctorAvailabilityId.Equals(doctorAvailabilityId), trackChanges).SingleOrDefault();
        public async Task<IEnumerable<Session>> GetPatientSessionsAsync(Guid patientId, bool trackChanges) =>
            await FindByCondition(s => s.PatientUserId.Equals(patientId), trackChanges).ToListAsync();
        public async Task<IEnumerable<Session>> GetDoctorSessionsAsync(Guid doctorId, bool trackChanges) =>
            await FindByCondition(s => s.DoctorUserId.Equals(doctorId), trackChanges).ToListAsync();
    }
}
