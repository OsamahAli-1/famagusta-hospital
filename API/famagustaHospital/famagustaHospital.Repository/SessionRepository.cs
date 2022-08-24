using famagustaHospital.Contracts;
using famagustaHospital.Entities.Models;
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
    }
}
